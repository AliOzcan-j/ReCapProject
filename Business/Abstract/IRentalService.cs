using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetRentalById(int id);
        IDataResult<List<Rental>> GetRentalByCarId(int id);
        IDataResult<List<Rental>> GetRentalByCustomerId(int id);
        IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarID(int id);
        IDataResult<List<RentalDetailDto>> GetRentalDetailsByRentDate(DateTime date);
        IDataResult<List<RentalDetailDto>> GetRentalDetailsAll();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
