using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Interface
{
    public interface ICommonClass
    {
        Response NextStep(string move, int x, int y);
    }
}
