using Microsoft.EntityFrameworkCore;
using SIBKMNetErika.Context;
using SIBKMNetErika.Models;
using SIBKMNetErika.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNetErika.Repositories.Data
{
    public class ProvinceRepository : IProvinceRepository
    {
        MyContext myContext;
        public ProvinceRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(Province province)
        {
            myContext.Provinces.Remove(province);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Province> Get()
        {
            var data = myContext.Provinces.Include(x => x.Region).ToList();
            return data;
        }

        public Province Get(int id)
        {
            var data = myContext.Provinces.Include(x => x.Region).Where(x => x.Id.Equals(id)).FirstOrDefault();
            return data;
        }

        public int Post(Province province)
        {
            myContext.Provinces.Add(province);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(int id, Province province)
        {
            var data = myContext.Provinces.Find(id);
            data.Name = province.Name;
            data.RegionId = province.RegionId;
            myContext.Provinces.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
