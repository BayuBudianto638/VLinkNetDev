using AutoMapper;
using MCF_AppData.Tables;
using MCF_AppService.Services.BpkbAppService.Dto;
using MCF_AppService.Services.LoginAppService.Dto;

namespace MCF_BackEnd.ConfigProfile
{
    public class Config: Profile
    {
        public Config()
        {
            CreateMap<LoginModel, Login>();
            CreateMap<Login, LoginModel>();

            CreateMap<TrBpkbModel, Tr_Bpkb>();
            CreateMap<Tr_Bpkb, TrBpkbModel>();
        }
    }
}
