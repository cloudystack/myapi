using Demo.myapi.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.myapi.BusinessLogic.Services.Interfaces
{
    public interface IAppSettingService
    {
        Task CreateAppSetting(AppSettingPostRp resource);
        Task UpdateAppSetting(string id, AppSettingPutRp resource);
        Task DeleteAppSetting(string id);
    }
}
