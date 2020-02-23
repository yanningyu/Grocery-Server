// Copyright @JJSoft - All Rights Reserved
// Filename: AppsettingService.cs
// Created By  :  Frankie
// Created Date:  23/02/2020  10:01
// Last Edit:
//    Author:   Frankie
//    Date:     23/02/2020  10:05

namespace GroceryServer.Services
{
    using System.Data.SqlClient;

    using GroceryServer.Services.Interfaces;

    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// The appsetting service.
    /// </summary>
    public class AppsettingService : IAppSettingService
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppsettingService"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public AppsettingService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// The grocery context.
        /// </summary>
        public SqlConnection GroceryContext => this.GetSqlConnection("GroceryContext");

        /// <summary>
        /// The get server database connection.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>
        /// The <see cref="System.Data.SqlClient.SqlConnection" /> . return
        /// database connection
        /// </returns>
        private SqlConnection GetSqlConnection(string context) => new SqlConnection(this.configuration.GetConnectionString(context));
    }
}