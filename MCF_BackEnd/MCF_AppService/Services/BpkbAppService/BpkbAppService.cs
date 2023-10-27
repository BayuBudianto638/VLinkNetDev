using AutoMapper;
using MCF_AppData.Database;
using MCF_AppData.Tables;
using MCF_AppService.Helpers;
using MCF_AppService.Services.BpkbAppService.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCF_AppService.Services.BpkbAppService
{
    public class BpkbAppService : IBpkbAppService
    {
        private readonly FirstDbContext _firstDbContext;
        private readonly SecondDbContext _secondDbContext;
        private readonly IMapper _mapper;

        public BpkbAppService(FirstDbContext firstDbContext, SecondDbContext secondDbContext, IMapper mapper)
        {
            _firstDbContext = firstDbContext;
            _secondDbContext = secondDbContext;
            _mapper = mapper;
        }

        public void Create(TrBpkbModel model, string userType)
        {

            if (userType == "001")
            {
                try
                {
                    _firstDbContext.Database.BeginTransaction();

                    var data = _mapper.Map<Tr_Bpkb>(model);
                    _firstDbContext.Tr_Bpkb.Add(data);
                    _firstDbContext.SaveChanges();
                    _firstDbContext.Database.CommitTransaction();
                }
                catch (DbException dbex)
                {
                    _firstDbContext.Database.RollbackTransaction();
                }
            }
            else
            {
                try
                {
                    _secondDbContext.Database.BeginTransaction();

                    var data = _mapper.Map<Tr_Bpkb>(model);
                    _secondDbContext.Tr_Bpkb.Add(data);
                    _secondDbContext.SaveChanges();
                    _secondDbContext.Database.CommitTransaction();
                }
                catch (DbException dbex)
                {
                    _secondDbContext.Database.RollbackTransaction();
                }
            }
        }

        public void Delete(string AgreementNumber, string userType)
        {
            if (userType == "001")
            {
                try
                {
                    _firstDbContext.Database.BeginTransaction();

                    var data = _firstDbContext.Tr_Bpkb.FirstOrDefault(w => w.AgreementNumber == AgreementNumber);

                    _firstDbContext.Tr_Bpkb.Remove(data);
                    _firstDbContext.SaveChanges();

                    _firstDbContext.Database.CommitTransaction();

                }
                catch (DbException dbex)
                {
                    _firstDbContext.Database.RollbackTransaction();
                }
            }
            else
            {
                try
                {
                    _secondDbContext.Database.BeginTransaction();

                    var data = _secondDbContext.Tr_Bpkb.FirstOrDefault(w => w.AgreementNumber == AgreementNumber);

                    _secondDbContext.Tr_Bpkb.Remove(data);
                    _secondDbContext.SaveChanges();

                    _secondDbContext.Database.CommitTransaction();

                }
                catch (DbException dbex)
                {
                    _secondDbContext.Database.RollbackTransaction();
                }
            }
        }

        public PagedResult<TrBpkbModel> GetAll(PageInfo pageInfo, string userType)
        {
            if (userType == "001")
            {
                var pagedResult = new PagedResult<TrBpkbModel>
                {
                    Data = (from a in _firstDbContext.Tr_Bpkb
                            join b in _firstDbContext.Location
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
                    Total = _firstDbContext.Tr_Bpkb.Count()
                };

                return pagedResult;
            }
            else
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
        }

        public TrBpkbModel GetById(string AgreementNumber, string userType)
        {
            if (userType == "001")
            {
                var data = _firstDbContext.Tr_Bpkb.FirstOrDefault(w => w.AgreementNumber == AgreementNumber);
                if (data != null)
                {
                    var model = _mapper.Map<TrBpkbModel>(data);
                    return model;
                }

                var notFound = new TrBpkbModel();
                return notFound;
            }
            else
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
        }

        public void Update(TrBpkbModel model, string userType)
        {
            if (userType == "001")
            {
                try
                {
                    _firstDbContext.Database.BeginTransaction();

                    var data = _mapper.Map<Tr_Bpkb>(model);

                    _firstDbContext.Tr_Bpkb.Update(data);
                    _firstDbContext.SaveChanges();

                    _firstDbContext.Database.CommitTransaction();

                }
                catch (DbException dbex)
                {
                    _firstDbContext.Database.RollbackTransaction();
                }
            }
            else
            {
                try
                {
                    _secondDbContext.Database.BeginTransaction();

                    var data = _mapper.Map<Tr_Bpkb>(model);

                    _secondDbContext.Tr_Bpkb.Update(data);
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
}
