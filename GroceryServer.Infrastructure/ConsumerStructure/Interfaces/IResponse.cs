using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryServer.Infrastructure.ConsumerStructure.Interfaces
{
    public interface IResponse<T>
     where T : class, new()
    {
        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        T Entity { get; set; }
    }
}
