using AutoMapper;
using MCF_AppData.Database;
using MCF_AppData.Tables;
using MCF_AppService.Helpers;
using MCF_AppService.Services.BpkbAppService.Dto;
using MCF_AppService.Services.LocationAppService.Dto;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCF_AppService.Services.LocationAppService
{
    public class LocationAppService : ILocationAppService
    {
        private readonly FirstDbContext _firstDbContext;
        private readonly SecondDbContext _secondDbContext;
        private readonly IMapper _mapper;

        public LocationAppService(FirstDbContext firstDbContext, SecondDbContext secondDbContext, IMapper mapper)
        {
            _firstDbContext = firstDbContext;
            _secondDbContext = secondDbContext;
            _mapper = mapper;
        }

        public void Create(LocationModel model, string userType)
        {
            if (userType == "001")
            {
                try
                {
                    _firstDbContext.Database.BeginTransaction();

                    var data = _mapper.Map<Location>(model);
                    _firstDbContext.Location.Add(data);
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

                    var data = _mapper.Map<Location>(model);
                    _secondDbContext.Location.Add(data);
                    _secondDbContext.SaveChanges();
                    _secondDbContext.Database.CommitTransaction();
                }
                catch (DbException dbex)
                {
                    _secondDbContext.Database.RollbackTransaction();
                }
            }
        }

        public void Delete(int id, string userType)
        {
            if (userType == "001")
            {
                try
                {
                    _firstDbContext.Database.BeginTransaction();

                    var data = GetById(id, userType);
                    var model = _mapper.Map<Location>(data);

                    _firstDbContext.Location.Remove(model);
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

                    var data = GetById(id, userType);
                    var model = _mapper.Map<Location>(data);

                    _secondDbContext.Location.Remove(model);
                    _secondDbContext.SaveChanges();

                    _secondDbContext.Database.CommitTransaction();

                }
                catch (DbException dbex)
                {
                    _secondDbContext.Database.RollbackTransaction();
                }
            }
        }

        public PagedResult<LocationModel> GetAll(PageInfo pageInfo, string userType)
        {
            if (userType == "001")
            {
                var pagedResult = new PagedResult<LocationModel>
                {
                    Data = (from a in _firstDbContext.Location
                            select new LocationModel
                            {
                               Id = a.Id,
                               Location_Name = a.Location_Name
                            })
                            .Skip(pageInfo.Skip)
                            .Take(pageInfo.PageSize)
                            .OrderBy(w => w.Id),
                    Total = _firstDbContext.Location.Count()
                };

                return pagedResult;
            }
            else
            {
                var pagedResult = new PagedResult<LocationModel>
                {
                    Data = (from a in _secondDbContext.Location
                            select new LocationModel
                            {
                                Id = a.Id,
                                Location_Name = a.Location_Name
                            })
                            .Skip(pageInfo.Skip)
                            .Take(pageInfo.PageSize)
                            .OrderBy(w => w.Id),
                    Total = _secondDbContext.Location.Count()
                };

                return pagedResult;
            }
        }

        public LocationModel GetById(int id, string userType)
        {
            if (userType == "001")
            {
                var data = _firstDbContext.Location.FirstOrDefault(w => w.Id == id);
                if (data != null)
                {
                    var model = _mapper.Map<LocationModel>(data);
                    return model;
                }

                var notFound = new LocationModel();
                return notFound;
            }
            else
            {
                var data = _secondDbContext.Location.FirstOrDefault(w => w.Id == id);
                if (data != null)
                {
                    var model = _mapper.Map<LocationModel>(data);
                    return model;
                }

                var notFound = new LocationModel();
                return notFound;
            }
        }

        public void Update(LocationModel model, string userType)
        {
            if (userType == "001")
            {
                try
                {
                    _firstDbContext.Database.BeginTransaction();

                    var data = _mapper.Map<Location>(model);

                    _firstDbContext.Location.Update(data);
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

                    var data = _mapper.Map<Location>(model);

                    _secondDbContext.Location.Update(data);
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
