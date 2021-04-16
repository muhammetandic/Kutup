using Kutup.Core.Domain.Common;
using System.Collections.Generic;

namespace Kutup.Core.Domain.Entities
{
    public class DataImport : BaseEntity
    {
        public string Name { get; set; }
        public DataImportType DataImportType { get; set; }
        public bool IsSystemImport { get; set; }
        public IList<string> Nodes { get; set; }
        public ICollection<DataImportMapping> DataImportMappings { get; set; }
        public ICollection<DataImportHistory> DataImportHistories { get; set; }
    }
}
