using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryServer.Infrastructure.ConsumerStructure.Interfaces
{
    public interface IConsumerFactory
    {
        /// <summary>
        /// The create consumer.
        /// </summary>
        /// <typeparam name="TRequest">
        /// The entity for requesting.
        /// </typeparam>
        /// <typeparam name="TResponse">
        /// The entity for responding
        /// </typeparam>
        /// <returns>
        /// The <see cref="IConsumer{TRequest, TResponse}"/>
        /// Return object implementing IConsumer interfaces
        /// </returns>
        IConsumer<TRequest, TResponse> CreateConsumer<TRequest, TResponse>()
          where TRequest : IRequest where TResponse : class;
    }
}
