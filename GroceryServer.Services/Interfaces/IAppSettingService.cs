using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryServer.Services.Interfaces
{
    public interface IAppSettingService
    {
        SqlConnection GroceryContext { get; }
    }
}
