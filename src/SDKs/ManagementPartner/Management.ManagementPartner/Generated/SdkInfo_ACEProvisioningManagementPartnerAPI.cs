
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_ACEProvisioningManagementPartnerAPI
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("ManagementPartner", "Operation", "2018-02-01"),
                new Tuple<string, string, string>("ManagementPartner", "Partner", "2018-02-01"),
            }.AsEnumerable();
        }
    }
}
