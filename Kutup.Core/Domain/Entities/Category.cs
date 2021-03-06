using Kutup.Core.Domain.Common;
using System.Collections.Generic;

namespace Kutup.Core.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
