using Kutup.Core.Domain.Common;

namespace Kutup.Core.Domain.Entities
{
    public class BookMap : BaseEntity
    {
        public string NameMap { get; set; }
        public string ISBNMap { get; set; }
        public string PageMap { get; set; }
        public string PublisherMap { get; set; }
        public string PublishingYearMap { get; set; }
        public string CoverImageMap { get; set; }
        public string CategoryIdMap { get; set; }
        public string AuthorIdMap { get; set; }
    }
}
