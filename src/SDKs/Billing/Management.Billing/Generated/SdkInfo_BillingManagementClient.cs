
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_BillingManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Billing", "BillingPeriods", "2018-03-01-preview"),
                new Tuple<string, string, string>("Billing", "EnrollmentAccounts", "2018-03-01-preview"),
                new Tuple<string, string, string>("Billing", "Invoices", "2018-03-01-preview"),
                new Tuple<string, string, string>("Billing", "Operations", "2018-03-01-preview"),
            }.AsEnumerable();
        }
    }
}
