// Copyright @JJSoft - All Rights Reserved
// Filename: MergeFruitConsumer.cs
// Created By  :  Frankie
// Created Date:  23/02/2020  10:54
// Last Edit:
//    Author:   Frankie
//    Date:     23/02/2020  11:58

namespace GroceryServer.Admin.Consumers
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    using Dapper;

    using GroceryServer.Admin.DtoModels;
    using GroceryServer.Admin.Requests;
    using GroceryServer.Admin.Response;
    using GroceryServer.Infrastructure.ConsumerStructure.Interfaces;
    using GroceryServer.Infrastructure.Helpers;
    using GroceryServer.Services.Interfaces;

    /// <summary>
    /// The merge fruit consumer.
    /// </summary>
    public class MergeFruitConsumer : IConsumer<MergeFruitRequest, MergeFruitResponse>
    {
        /// <summary>
        /// The appsetting service.
        /// </summary>
        private readonly IAppSettingService appsettingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MergeFruitConsumer" />
        /// class.
        /// </summary>
        /// <param name="appsettingService">The appsetting service.</param>
        public MergeFruitConsumer(IAppSettingService appsettingService)
        {
            this.appsettingService = appsettingService;
        }

        public async Task<MergeFruitResponse> ProcessAsync(MergeFruitRequest request)
        {
            var response = new MergeFruitResponse();

            try
            {
                using (var conn = this.appsettingService.GroceryContext)
                {
                    var results = await conn.QueryAsync<FruitDto>(
                                      "dbo.MergeFruits",
                                      new
                                          {
                                              fruits = request.Fruits.ToTvp("FruitTvp")
                                          },
                                      commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                    response.Entity = results.ToList();
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errors occured on merging fruits.", ex);
            }
        }
    }
}