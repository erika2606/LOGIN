using SIBKMNetErika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNetErika.Repositories.Interface
{
    public interface IProvinceRepository
    {
        //GET
        List<Province> Get();
        //GET BY ID
        Province Get(int id);
        //POST
        int Post(Province province);
        //PUT
        int Put(int id, Province province);
        //DELETE
        int Delete(Province province);

    }
}
