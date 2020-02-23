using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryServer.Infrastructure.Helpers
{
    using Dapper;
    using System.Data;

    public static class ConvertToTvpHelper
    {
        /// <summary>
        /// The to tvp.
        /// </summary>
        /// <typeparam name="TEntity">
        /// </typeparam>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// The <see cref="Dapper.SqlMapper.ICustomQueryParameter"/> .
        /// </returns>
        public static SqlMapper.ICustomQueryParameter ToTvp<TEntity>(this List<TEntity> list, string typeName)
          where TEntity : class
        {
            var dt = CreateTable(typeof(TEntity));
            foreach (var entity in list)
            {
                dt.Rows.Add(CreateDataRow(entity));
            }

            return dt.AsTableValuedParameter(typeName);
        }

        /// <summary>
        /// The to tvp.
        /// </summary>
        /// <param name="list">
        /// The <paramref name="list{int}"/>
        /// </param>
        /// <returns>
        /// The <see cref="SqlMapper.ICustomQueryParameter"/>.
        /// </returns>
        public static SqlMapper.ICustomQueryParameter ToTvp(this List<int> list)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            list.ForEach(x => dt.Rows.Add(x));

            return dt.AsTableValuedParameter("IntTvp");
        }

        /// <summary>
        /// The create data row.
        /// </summary>
        /// <typeparam name="TEntity">
        /// </typeparam>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="System.Object"/> .
        /// </returns>
        private static object[] CreateDataRow<TEntity>(TEntity entity)
        {
            var type = typeof(TEntity);

            return type.GetProperties().Where(x => x.GetCustomAttributes(typeof(TvpAttr), true).Length == 1).OrderBy(x => x.Name).Select(prop => prop.GetValue(entity)).ToArray();
        }

        /// <summary>
        /// The create table.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="System.Data.DataTable"/> .
        /// </returns>
        private static DataTable CreateTable(Type type)
        {
            var dt = new DataTable();
            foreach (var prop in type.GetProperties().Where(x => x.GetCustomAttributes(typeof(TvpAttr), true).Length == 1).OrderBy(x => x.Name))
            {
                dt.Columns.Add(prop.Name, prop.PropertyType);
            }

            return dt;
        }
    }
}
