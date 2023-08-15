using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoomService
    {
        IDataResult<List<Room>> GetAll();
        IDataResult<Room> GetById(int id);
        IResult Add(Room room);
        IResult Update(Room room);
        IResult Delete(int id);
    }
}
