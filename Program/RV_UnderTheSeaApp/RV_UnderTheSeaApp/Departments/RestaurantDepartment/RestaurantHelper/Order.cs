using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RV_UnderTheSeaApp.Departments.RestaurantDepartment.RestaurantHelper
{
    class Order
    {
        private State state = null;

        public Order(State state)
        {
            this.TransitionTo(state);
        }

        public void TransitionTo(State state)
        {   
            this.state = state;
            this.state.SetOrder(this);
        }

        public void StartOrder()
        {
            this.state.Progress();
        }

    }
}
