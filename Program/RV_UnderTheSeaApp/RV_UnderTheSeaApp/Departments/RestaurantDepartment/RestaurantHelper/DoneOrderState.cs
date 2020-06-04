using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RV_UnderTheSeaApp.Departments.RestaurantDepartment.RestaurantHelper
{
    class DoneOrderState : State
    {
        public override void Progress()
        {
            Console.WriteLine("Wrapping Up Finished Order");
        }
    }
}
