using Kutup.Core.Domain.Common;

namespace Kutup.Core.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public long ISBN { get; set; }
        public int Page { get; set; }
        public string Publisher { get; set; }
        public int PublishingYear { get; set; }
        public string CoverImage { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
