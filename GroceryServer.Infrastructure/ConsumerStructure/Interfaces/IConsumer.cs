using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryServer.Infrastructure.ConsumerStructure.Interfaces
{
    public interface IConsumer<in TRequest, TResponse>
     where TRequest : IRequest
     where TResponse : class
    {
        /// <summary>
        /// The process async.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TResponse> ProcessAsync(TRequest request);
    }
}
