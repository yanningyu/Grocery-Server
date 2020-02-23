using GroceryServer.Infrastructure.ConsumerStructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryServer.Infrastructure.ConsumerStructure
{
    public abstract class AbstractResponse<T> : IResponse<T>
     where T : class, new()
    {
        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        public T Entity { get; set; }
    }
}
