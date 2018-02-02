
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
                new Tuple<string, string, string>("Billing", "Marketplaces", "2018-01-31"),
                new Tuple<string, string, string>("Billing", "PriceSheet", "2018-01-31"),
                new Tuple<string, string, string>("Billing", "UsageDetails", "2018-01-31"),
                new Tuple<string, string, string>("Capacity", "ReservationsDetails", "2018-01-31"),
                new Tuple<string, string, string>("Capacity", "ReservationsSummaries", "2018-01-31"),
                new Tuple<string, string, string>("Consumption", "Budgets", "2018-01-31"),
                new Tuple<string, string, string>("Consumption", "Marketplaces", "2018-01-31"),
                new Tuple<string, string, string>("Consumption", "Operations", "2018-01-31"),
                new Tuple<string, string, string>("Consumption", "PriceSheet", "2018-01-31"),
                new Tuple<string, string, string>("Consumption", "UsageDetails", "2018-01-31"),
            }.AsEnumerable();
        }
    }
}
