using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RV_UnderTheSeaApp.Departments.RestaurantDepartment.RestaurantHelper
{
    class MadeOrderState : State
    {
        public override void Progress()
        {
            Console.WriteLine("Making Order");
            this.order.TransitionTo(new DeliverOrderState());
        }
    }
}
