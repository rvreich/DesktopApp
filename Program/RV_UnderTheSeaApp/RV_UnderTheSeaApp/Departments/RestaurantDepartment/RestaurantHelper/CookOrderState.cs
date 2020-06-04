using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RV_UnderTheSeaApp.Departments.RestaurantDepartment.RestaurantHelper
{
    class CookOrderState : State
    {
        public override void Progress(int ID)
        {
            Console.WriteLine("Cooking Order");
            this.order.TransitionTo(new MadeOrderState(), ID);
        }
    }
}
