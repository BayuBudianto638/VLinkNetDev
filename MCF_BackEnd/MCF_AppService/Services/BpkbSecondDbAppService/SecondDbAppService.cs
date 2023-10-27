using AutoMapper;
using MCF_AppData.Database;
using MCF_AppData.Tables;
using MCF_AppService.Services.BpkbFirstDbAppService.Dto;
using MCF_AppService.Services.BpkbFirstDbAppService;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCF_AppService.Helpers;

namespace MCF_AppService.Services.BpkbSecondDbAppService
{
    public class SecondDbAppService : IFirstDbAppService
    {
        private readonly SecondDbContext _secondDbContext;
        private readonly IMapper _mapper;

        public SecondDbAppService(SecondDbContext secondDbContext, IMapper mapper)
        {
            _secondDbContext = secondDbContext;
            _mapper = mapper;
        }

        public void Create(TrBpkbModel model)
        {
            try
            {
                _secondDbContext.Database.BeginTransaction();

                var data = _mapper.Map<Tr_Bpkb>(model);
                _secondDbContext.Add(data);
                _secondDbContext.SaveChanges();
                _secondDbContext.Database.CommitTransaction();

            }
            catch (DbException dbex)
            {
                _secondDbContext.Database.RollbackTransaction();
            }
        }

        public void Delete(string AgreementNumber)
        {
            try
            {
                _secondDbContext.Database.BeginTransaction();

                var data = GetById(AgreementNumber);

                _secondDbContext.Remove(data);
                _secondDbContext.SaveChanges();

                _secondDbContext.Database.CommitTransaction();

            }
            catch (DbException dbex)
            {
                _secondDbContext.Database.RollbackTransaction();
            }
        }

        public PagedResult<TrBpkbModel> GetAll(PageInfo pageInfo)
        {
            var pagedResult = new PagedResult<TrBpkbModel>
            {
                Data = (from a in _secondDbContext.Tr_Bpkb
                        join b in _secondDbContext.Location
                                 on a.LocationId equals b.Id
                        select new TrBpkbModel
                        {
                            AgreementNumber = a.AgreementNumber,
                            Bpkb_No = a.Bpkb_No,
                            Bpkb_Date = a.Bpkb_Date,
                            Faktur_No = a.Faktur_No,
                            Faktur_Date = a.Faktur_Date,
                            LocationId = a.LocationId,
                            Police_No = a.Police_No,
                            Bpkb_Date_In = a.Bpkb_Date_In,
                            LocationName = b.Location_Name
                        })
                        .Skip(pageInfo.Skip)
                        .Take(pageInfo.PageSize)
                        .OrderBy(w => w.AgreementNumber),
                Total = _secondDbContext.Tr_Bpkb.Count()
            };

            return pagedResult;
        }

        public TrBpkbModel GetById(string AgreementNumber)
        {
            var data = _secondDbContext.Tr_Bpkb.FirstOrDefault(w => w.AgreementNumber == AgreementNumber);
            if (data != null)
            {
                var model = _mapper.Map<TrBpkbModel>(data);
                return model;
            }

            var notFound = new TrBpkbModel();
            return notFound;
        }

        public void Update(TrBpkbModel model)
        {
            try
            {
                _secondDbContext.Database.BeginTransaction();

                var data = _mapper.Map<Tr_Bpkb>(model);

                _secondDbContext.Update(data);
                _secondDbContext.SaveChanges();

                _secondDbContext.Database.CommitTransaction();

            }
            catch (DbException dbex)
            {
                _secondDbContext.Database.RollbackTransaction();
            }
        }
    }
}