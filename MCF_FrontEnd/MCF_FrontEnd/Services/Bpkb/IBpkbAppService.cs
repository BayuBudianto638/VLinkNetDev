using MCF_FrontEnd.Models.Bpkb;

namespace MCF_FrontEnd.Services.Bpkb
{
    public interface IBpkbAppService
    {
        void Create(BpkbModel model, string userType);
        void Update(BpkbModel model, string userType);
        void Delete(string agreementNo, string userType);
        Task<Response> GetAll();
    }
}
