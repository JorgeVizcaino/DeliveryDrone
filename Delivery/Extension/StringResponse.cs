using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Extension
{
    public static class StringResponse
    {
        public static string ToResponse(this string item)
        {
            switch (item)
            {
                case "X-":
                    return "Oeste";
                case "X":
                    return "Este";
                case "Y":
                    return "Norte";
                case "Y-":
                    return "Sur";
            }

            return "";
        }
    }
}
