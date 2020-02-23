using GroceryServer.Infrastructure.ConsumerStructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryServer.Infrastructure.ConsumerStructure
{
    /// <summary>
    /// The consumer factory.
    /// </summary>
    public class ConsumerFactory : IConsumerFactory
    {
        /// <summary>
        /// The service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumerFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">
        /// The service provider.
        /// </param>
        public ConsumerFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// The create consumer.
        /// </summary>
        /// <typeparam name="TRequest">
        /// The entity for requesting.
        /// </typeparam>
        /// <typeparam name="TResponse">
        /// The responding entity.
        /// </typeparam>
        /// <returns>
        /// The <see><cref>IConsumer</cref></see>
        /// </returns>
        public IConsumer<TRequest, TResponse> CreateConsumer<TRequest, TResponse>()
          where TRequest : IRequest where TResponse : class
        {
            try
            {
                var consumer = this.serviceProvider.GetService<IConsumer<TRequest, TResponse>>();
                return consumer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
