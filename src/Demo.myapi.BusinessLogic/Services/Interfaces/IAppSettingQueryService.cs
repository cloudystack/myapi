using Demo.myapi.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.myapi.BusinessLogic.Services.Interfaces
{
    public interface IAppSettingQueryService
    {
        Task<AppSettingListRp> GetAppSettings();
        Task<AppSettingGetRp> GetAppSettingById(string id);
    }
}
