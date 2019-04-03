using System;
using System.Threading.Tasks;
using Demo.myapi.BusinessLogic.Core.Services.Interfaces;
using Demo.myapi.BusinessLogic.Interfaces;
using Demo.myapi.BusinessLogic.Models;
using Demo.myapi.BusinessLogic.Services.Interfaces;
using Demo.myapi.DataAccess.Core.Interfaces;
using Demo.myapi.DataAccess.Core.Models;

namespace Demo.myapi.BusinessLogic.Services
{
    public class AppSettingService : IAppSettingService
    {
        private readonly IAppSettingDataService _appSettingDataService;
        private readonly IBusinessManagerService _businessManagerService;
        private readonly IIdentityService _identityService;

        public AppSettingService(IAppSettingDataService appSettingRepository,
                                 IBusinessManagerService businessManagerService, 
                                 IIdentityService identityService)
        {
            this._businessManagerService = businessManagerService;
            this._appSettingDataService = appSettingRepository;
            this._identityService = identityService;
        }

        public async Task CreateAppSetting(AppSettingPostRp resource)
        {
            var createdBy = this._identityService.GetUserId();
            var appSetting = AppSetting.Factory.Create(resource.Id, resource.Value, createdBy);

            var entity = await this._appSettingDataService.GetById(resource.Id);
            if (entity != null)
            {
                await _businessManagerService.AddConflict($"The Id {resource.Id} has already been taken.");
                return;
            }

            await this._appSettingDataService.Add(appSetting);

            await this._appSettingDataService.SaveChanges();

            await _businessManagerService.AddResult("Key", appSetting.Id);
        }

        public async Task UpdateAppSetting(string id, AppSettingPutRp resource)
        {
            var appSetting = await this._appSettingDataService.GetById(id);

            if (appSetting == null)
            {
                await _businessManagerService.AddNotFound($"The Id {id} doesn't exists.");
                return;
            }

            appSetting.Value = resource.Value;

            appSetting.Update(this._identityService.GetUserId());

            await this._appSettingDataService.Update(appSetting);

            await this._appSettingDataService.SaveChanges();
        }

        public async Task DeleteAppSetting(string id)
        {
            var appSetting = await this._appSettingDataService.GetById(id);

            if (appSetting == null)
            {
                await _businessManagerService.AddNotFound($"The Id {id} doesn't exists.");
                return;
            }

            appSetting.Delete();

            appSetting.Update(this._identityService.GetUserId());

            await this._appSettingDataService.Update(appSetting);

            await this._appSettingDataService.SaveChanges();
        }

    }
}
