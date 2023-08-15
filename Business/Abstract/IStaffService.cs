using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStaffService
    {
        IDataResult<List<Staff>> GetAll();
        IDataResult<Staff> GetById(int id);
        IResult Add(Staff staff);
        IResult Update(Staff staff);
        IResult Delete(int id);
    }
}
