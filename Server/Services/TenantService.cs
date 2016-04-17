using System;
using System.Collections.Generic;
using Chloe.Server.Data.Contracts;
using Chloe.Server.Dtos;
using Chloe.Server.Services.Contracts;
using System.Data.Entity;
using System.Linq;
using Chloe.Server.Models;
using Chloe.Server.Exceptions;

namespace Chloe.Server.Services
{
    public class TenantService : ITenantService
    {
        public TenantService(IChloeUow uow, ICacheProvider cacheProvider)
        {
            this.uow = uow;
            this.repository = uow.Tenants;
            this.cache = cacheProvider.GetCache();
        }

        public TenantAddOrUpdateResponseDto AddOrUpdate(TenantAddOrUpdateRequestDto request)
        {
            var entity = repository.GetAll()
                .Where(x => x.Id == request.Id && x.IsDeleted == false)
                .FirstOrDefault();
            if (entity == null) repository.Add(entity = new Tenant());
            entity.Name = request.Name;
            uow.SaveChanges();
            return new TenantAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = repository.GetById(id);
            entity.IsDeleted = true;
            uow.SaveChanges();
            return id;
        }

        public ICollection<TenantDto> Get()
        {
            ICollection<TenantDto> response = new HashSet<TenantDto>();
            var entities = repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new TenantDto(entity)); }    
            return response;
        }


        public TenantDto GetById(int id)
        {
            return new TenantDto(repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public Tenant GetByUri(string uri)
        {
            var tenant = cache.FromCacheOrService<Tenant>(() => 
            this.uow.Tenants.GetAll().Where(x => x.Host == uri).FirstOrDefault(), $"Tenant: {uri}");

            if (tenant == null)
                throw new TenantNotFoundException();

            return tenant;

        }

        protected readonly IChloeUow uow;
        protected readonly IRepository<Tenant> repository;
        protected readonly ICache cache;
    }
}
