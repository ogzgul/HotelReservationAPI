using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ServiceManager : IServiceService
    {
        IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public IResult Add(Service service)
        {
            _serviceDal.Add(service);
            return new SuccessResult(Messages.RoomAdded);
        }

        public IResult Delete(int id)
        {
            var deletedService = _serviceDal.Get(x=>x.ServiceID== id);
            return new SuccessResult($"Deleted Data : {id} number's {Messages.ServiceDeleted}");
        }

        public IDataResult<List<Service>> GetAll()
        {
            var listedService = _serviceDal.GetAll();
            return new SuccessDataResult<List<Service>>(listedService, Messages.ServiceGetAll);
        }

        public IDataResult<Service> GetById(int id)
        {
            var GetByIdService = _serviceDal.Get(x => x.ServiceID == id);
            return new SuccessDataResult<Service>(GetByIdService, Messages.ServiceGetById);
        }

        public IResult Update(Service service)
        {
            var updateService = _serviceDal.Get(x => x.ServiceID == service.ServiceID);
            Service updatedService = new Service
            {
                ServiceID = service.ServiceID,
                Description = service.Description,
                ServiceIcon = service.ServiceIcon,
                Title = service.Title
            };
            _serviceDal.Update(updatedService);
            return new SuccessResult(Messages.ServiceUpdated);
            
        }
    }
}
