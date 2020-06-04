using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RV_UnderTheSeaApp.Departments.RestaurantDepartment.RestaurantHelper
{
    abstract class State
    {
        protected Order order;

        public void SetOrder(Order order)
        {
            this.order = order;
        }

        public abstract void Progress();
    }
}
