using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Extension
{
    [Serializable]
    public class DroneExecption : Exception
    {
        public DroneExecption()
        {

        }
        public DroneExecption(string name)
            : base(String.Format("Invalid Student Name: {0}", name))
        {

        }
    }
}
