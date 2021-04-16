using Kutup.Core.Domain.Common;
using System.Collections.Generic;

namespace Kutup.Core.Domain.Entities
{
    public class DataImportHistory : BaseEntity 
    {
        public int DataImportId { get; set; }
        public virtual DataImport DataImport { get; set; }
        public string Url { get; set; }
        public int RowCount { get; set; }
        public int SuccessfulCount { get; set; }
        public int FailedCount { get; set; }
        public IDictionary<int, string> ErrorLogs { get; set; } 
    }

}
