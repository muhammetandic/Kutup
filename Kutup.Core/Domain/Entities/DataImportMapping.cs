using Kutup.Core.Domain.Common;

namespace Kutup.Core.Domain.Entities
{
    public class DataImportMapping : BaseEntity
    {
        public int DataImportId { get; set; }
        public virtual DataImport DataImport { get; set; }
        public string ColumnName { get; set; }
        public string NodeName { get; set; }
        public string Formula { get; set; }
    }
}
