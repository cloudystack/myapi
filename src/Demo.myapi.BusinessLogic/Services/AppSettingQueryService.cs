using Demo.myapi.BusinessLogic.Models;
using Demo.myapi.BusinessLogic.Services.Interfaces;
using Demo.myapi.DataAccess.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.myapi.BusinessLogic.Services
{
    public class AppSettingQueryService : IAppSettingQueryService
    {
        private readonly IAppSettingDataService _appSettingDataService;

        public AppSettingQueryService(IAppSettingDataService appSettingDataService)
        {
            this._appSettingDataService = appSettingDataService;
        }

        public async Task<AppSettingGetRp> GetAppSettingById(string id)
        {
            var entity = await this._appSettingDataService.GetById(id);
            return new AppSettingGetRp { Id = entity.Id, Value = entity.Value };
        }

        public async Task<AppSettingListRp> GetAppSettings()
        {
            var entities = await this._appSettingDataService.GetAll();

            return new AppSettingListRp() {
                Items = entities.Select(entity => new AppSettingListItemRp { Id = entity.Id, Value = entity.Value }).ToList()
            };
        }
    }
}
