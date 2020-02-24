using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryServer.API.Controllers
{
    using GroceryServer.Admin.Requests;
    using GroceryServer.Admin.Response;
    using GroceryServer.Infrastructure.ConsumerStructure.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/fruit")]
    public class FruitController: ControllerBase
    {
        /// <summary>
        /// The consumer factory.
        /// </summary>
        private readonly IConsumerFactory consumerFactory;

        public FruitController(IConsumerFactory consumerFactory)
        {
            this.consumerFactory = consumerFactory;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] MergeFruitRequest request)
        {
            var response =
                await this.consumerFactory
                    .CreateConsumer<MergeFruitRequest, MergeFruitResponse>()
                    .ProcessAsync(request).ConfigureAwait(false);

            return this.Ok(response.Entity);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UpdatePriceRequest request)
        {
            var response =
                await this.consumerFactory
                    .CreateConsumer<UpdatePriceRequest, UpdatePriceResponse>()
                    .ProcessAsync(request)
                    .ConfigureAwait(false);

            return this.Ok(response.Entity);
        }
    }
}
