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
    public class SubscribeManager : ISubscribeService
    {
        ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public IResult Add(Subscribe subscribe)
        {
            _subscribeDal.Add(subscribe);
            return new SuccessResult(Messages.SubscribeAdded);
        }

        public IResult Delete(int id)
        {
            var deletedSubscribe = _subscribeDal.Get(x => x.SubscribeID == id);
            _subscribeDal.Delete(deletedSubscribe);
            return new SuccessResult($"Deleted Data : {id} number's {Messages.SubscribeDeleted}");
        }

        public IDataResult<List<Subscribe>> GetAll()
        {
            var listedSubscribe = _subscribeDal.GetAll();
            return new SuccessDataResult<List<Subscribe>>(listedSubscribe, Messages.SubscribeGetAll);
        }

        public IDataResult<Subscribe> GetById(int id)
        {
            var getByIdSubscribe = _subscribeDal.Get(x => x.SubscribeID == id);
            return new SuccessDataResult<Subscribe>(getByIdSubscribe, Messages.SubscribeGetById);
        }

        public IResult Update(Subscribe subscribe)
        {
            var updateSubscribe = _subscribeDal.Get(x => x.SubscribeID == subscribe.SubscribeID);
            Subscribe updatedSubscribe = new Subscribe
            {
                SubscribeID = subscribe.SubscribeID,
                Mail = subscribe.Mail
            };
            _subscribeDal.Update(updatedSubscribe);
            return new SuccessResult(Messages.SubscribeUpdated);
        }
    }
}
