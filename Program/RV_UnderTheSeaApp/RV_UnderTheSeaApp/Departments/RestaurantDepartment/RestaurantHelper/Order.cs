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
        private int ID = -1;

        public Order(State state, int ID)
        {
            this.TransitionTo(state, ID);
        }

        public void TransitionTo(State state, int ID)
        {   
            this.state = state;
            this.ID = ID;
            this.state.SetOrder(this);
        }

        public void StartOrder(int ID)
        {
            this.state.Progress(ID);
        }

    }
}
