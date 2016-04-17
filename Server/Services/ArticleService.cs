using System.Collections.Generic;
using Chloe.Server.Data.Contracts;
using Chloe.Server.Dtos;
using Chloe.Server.Services.Contracts;
using System.Linq;
using Chloe.Server.Models;

namespace Chloe.Server.Services
{
    public class ArticleService : IArticleService
    {
        public ArticleService(IChloeUow uow, ICacheProvider cacheProvider)
        {
            this.uow = uow;
            this.repository = uow.Articles;
            this.cache = cacheProvider.GetCache();
        }

        public ArticleAddOrUpdateResponseDto AddOrUpdate(ArticleAddOrUpdateRequestDto request)
        {
            var entity = repository.GetAll()
                .Where(x => x.Id == request.Id && x.IsDeleted == false)
                .FirstOrDefault();
            if (entity == null) repository.Add(entity = new Article());
            entity.Name = request.Name;
            uow.SaveChanges();
            return new ArticleAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = repository.GetById(id);
            entity.IsDeleted = true;
            uow.SaveChanges();
            return id;
        }

        public ICollection<ArticleDto> Get(string tenantName = null)
        {
            ICollection<ArticleDto> response = new HashSet<ArticleDto>();
            var entities = repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new ArticleDto(entity)); }    
            return response;
        }


        public ArticleDto GetById(int id)
        {
            return new ArticleDto(repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IChloeUow uow;
        protected readonly IRepository<Article> repository;
        protected readonly ICache cache;
    }
}
