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
    public class StaffManager : IStaffService
    {
        IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public IResult Add(Staff staff)
        {
            _staffDal.Add(staff);
            return new SuccessResult(Messages.StaffAdded);
        }

        public IResult Delete(int id)
        {
            var deletedStaff = _staffDal.Get(x => x.StaffID == id);
            _staffDal.Delete(deletedStaff);
            return new SuccessResult($"Deleted Data : {id} number's {Messages.StaffDeleted}");
        }

        public IDataResult<List<Staff>> GetAll()
        {
            var listedStaff = _staffDal.GetAll();
            return new SuccessDataResult<List<Staff>>(listedStaff, Messages.StaffGetAll);
        }

        public IDataResult<Staff> GetById(int id)
        {
            var getByIdStaff = _staffDal.Get(x => x.StaffID == id);
            return new SuccessDataResult<Staff>(getByIdStaff, Messages.StaffGetById);
        }

        public IResult Update(Staff staff)
        {
            var updateStaff = _staffDal.Get(x => x.StaffID == staff.StaffID);
            Staff updatedStaff = new Staff
            {
                StaffID = staff.StaffID,
                Name = staff.Name,
                SocialMedia1 = staff.SocialMedia1,
                SocialMedia2 = staff.SocialMedia2,
                SocialMedia3 = staff.SocialMedia3,
                Title = staff.Title
            };
            _staffDal.Update(updatedStaff);
            return new SuccessResult(Messages.StaffUpdated);
        }
    }
}
