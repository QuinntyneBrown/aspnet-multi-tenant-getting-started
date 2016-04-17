using Chloe.Server.Models;

namespace Chloe.Server.Dtos
{
    public class ArticleAddOrUpdateResponseDto: ArticleDto
    {
        public ArticleAddOrUpdateResponseDto(Article entity)
            :base(entity)
        {

        }
    }
}
