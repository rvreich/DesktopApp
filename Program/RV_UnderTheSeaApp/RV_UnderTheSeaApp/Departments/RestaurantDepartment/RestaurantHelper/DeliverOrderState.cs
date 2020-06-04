using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RV_UnderTheSeaApp.Departments.RestaurantDepartment.RestaurantHelper
{
    class DeliverOrderState : State
    {
        public override void Progress()
        {
            Console.WriteLine("Delivering Order");
            this.order.TransitionTo(new DoneOrderState());
        }
    }
}
