using AutoMapper;
using MCF_AppData.Database;
using MCF_AppData.Tables;
using MCF_AppService.Services.LoginAppService.Dto;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MCF_AppService.Services.LoginAppService
{
    public class LoginAppService : ILoginAppService
    {
        private readonly LoginDbContext _loginDbContext;
        private readonly IMapper _mapper;
        public LoginAppService(LoginDbContext loginDbContext, IMapper mapper)
        {
            _loginDbContext = loginDbContext;
            _mapper = mapper;
        }

        public void Create(LoginModel model)
        {
            try
            {
                var sha256 = SHA256.Create();
                var passwordHash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(model.Password));

                _loginDbContext.Database.BeginTransaction();

                var data = _mapper.Map<Login>(model);
                data.Password = BitConverter.ToString(passwordHash).Replace("-", "").ToLower();

                _loginDbContext.Add(data);
                _loginDbContext.SaveChanges();
                _loginDbContext.Database.CommitTransaction();
            }
            catch (DbException dbex)
            {
                _loginDbContext.Database.RollbackTransaction();
            }
        }

        public LoginModel Login(string username, string password)
        {
            var data = _loginDbContext.Login.FirstOrDefault(w => w.UserName == username && w.Password == password);

            if (data != null)
            {
                return _mapper.Map<LoginModel>(data);
            }
            var loginModel = new LoginModel();
            return loginModel;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

    }
}
