
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_ConsumptionManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Consumption", "Operations", "2017-11-30"),
                new Tuple<string, string, string>("Consumption", "ReservationsDetails", "2017-11-30"),
                new Tuple<string, string, string>("Consumption", "ReservationsSummaries", "2017-11-30"),
                new Tuple<string, string, string>("Consumption", "UsageDetails", "2017-11-30"),
            }.AsEnumerable();
        }
    }
}
