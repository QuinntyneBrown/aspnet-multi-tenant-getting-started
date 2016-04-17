using Chloe.Server.Dtos;
using System.Collections.Generic;

namespace Chloe.Server.Services.Contracts
{
    public interface IArticleService
    {
        ArticleAddOrUpdateResponseDto AddOrUpdate(ArticleAddOrUpdateRequestDto request);
        ICollection<ArticleDto> Get(string tenantName = null);
        ArticleDto GetById(int id);
        dynamic Remove(int id);
    }
}
