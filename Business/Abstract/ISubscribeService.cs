using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISubscribeService
    {

        IDataResult<List<Subscribe>> GetAll();
        IDataResult<Subscribe> GetById(int id);
        IResult Add(Subscribe subscribe);
        IResult Update(Subscribe subscribe);
        IResult Delete(int id);
    }
}
