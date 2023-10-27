using MCF_FrontEnd.Models.Account;
using MCF_FrontEnd.Models.Bpkb;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace MCF_FrontEnd.Services.Bpkb
{
    public class BpkbAppService : IBpkbAppService
    {
        public async void Create(BpkbModel model, string userType)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7057/api/Bpkb/SaveBpkb?userType={userType}");

            #region Hide
            //var payload = new
            //{
            //    agreementNumber = "009809",
            //    bpkb_No = "string",
            //    bpkb_Date = "2023-02-08T14:05:20.257Z",
            //    faktur_No = "string",
            //    faktur_Date = "2023-02-08T14:05:20.257Z",
            //    locationId = 1,
            //    locationName = "string",
            //    police_No = "string",
            //    bpkb_Date_In = "2023-02-08T14:05:20.257Z"
            //};
            #endregion

            request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
        }

        public async void Delete(string agreementNo, string userType)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7057/api/Bpkb/DeleteBpkb?agreementNo={agreementNo}&userType={userType}");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
            }
        }

        public async Task<Response> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7057/");

                var response = await client.GetAsync("api/Bpkb/GetAllBpkb?Page=1&PageSize=10&userType=001");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Response>(content);

                    return data;
                }
            }

            return null;
        }

        public void Update(BpkbModel model, string userType)
        {
            throw new NotImplementedException();
        }
    }
}
