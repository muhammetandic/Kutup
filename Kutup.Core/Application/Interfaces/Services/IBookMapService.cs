using Kutup.Core.Domain.Entities;
using System.Collections.Generic;

namespace Kutup.Core.Application.Interfaces.Services
{
    public interface IBookMapService : ICrudService<BookMap>
    {
        public List<string> XmlGetNodes(string filePath);
    }
}
