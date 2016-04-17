using Chloe.Server.Models;

namespace Chloe.Server.Dtos
{
    public class ArticleDto
    {
        public ArticleDto(Article entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public ArticleDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
