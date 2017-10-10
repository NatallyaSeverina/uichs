using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class VechicleRepository : IVechicleRepository
    {

        DAL.ModelDB context = new DAL.ModelDB();
        public string GetNameByID(int _id)
        {
          return  context.Vechicles.Find(_id).nameVechicle;
        }
    }
}
