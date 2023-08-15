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
    public class RoomManager : IRoomService
    {
        IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public IResult Add(Room room)
        {
            _roomDal.Add(room);
            return new SuccessResult(Messages.RoomAdded);
        }

        public IResult Delete(int id)
        {
            var deletedRoom = _roomDal.Get(x=>x.RoomID == id);
            _roomDal.Delete(deletedRoom);
            return new SuccessResult($"Deleted Data : {id} number's {Messages.RoomDeleted}");
        }

        public IDataResult<List<Room>> GetAll()
        {
            var listedRoom = _roomDal.GetAll();
            return new SuccessDataResult<List<Room>>(listedRoom, Messages.RoomGetAll);
        }

        public IDataResult<Room> GetById(int id)
        {
            var listGetById = _roomDal.Get(x => x.RoomID == id);
            return new SuccessDataResult<Room>(listGetById, Messages.RoomGetById);
        }

        public IResult Update(Room room)
        {
            var updateRoom = _roomDal.Get(x => x.RoomID == room.RoomID);
            Room updatedRoom = new Room
            {
                RoomID = room.RoomID,
                BathCount = room.BathCount,
                BedCount = room.BedCount,
                Description = room.Description,
                Price = room.Price,
                RoomCoverImage = room.RoomCoverImage,
                RoomNumber = room.RoomNumber,
                Title = room.Title,
                Wifi = room.Wifi
            };
            _roomDal.Update(updatedRoom);
            return new SuccessResult(Messages.RoomUpdated);
            
        }
    }
}
