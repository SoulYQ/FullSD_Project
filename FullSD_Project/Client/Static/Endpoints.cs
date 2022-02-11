using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullSD_Project.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string StatesEndpoint = $"{Prefix}/states";
        public static readonly string BrandsEndpoint = $"{Prefix}/brands";
        public static readonly string ToolsEndpoint = $"{Prefix}/tools";
        public static readonly string MembersEndpoint = $"{Prefix}/members";
        public static readonly string BookingsEndpoint = $"{Prefix}/bookings";
    }
}
