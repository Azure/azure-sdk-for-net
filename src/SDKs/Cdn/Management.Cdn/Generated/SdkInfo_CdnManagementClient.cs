
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_CdnManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Cdn", "CheckNameAvailability", "2017-10-12"),
                new Tuple<string, string, string>("Cdn", "CustomDomains", "2017-10-12"),
                new Tuple<string, string, string>("Cdn", "EdgeNodes", "2017-10-12"),
                new Tuple<string, string, string>("Cdn", "Endpoints", "2017-10-12"),
                new Tuple<string, string, string>("Cdn", "Operations", "2017-10-12"),
                new Tuple<string, string, string>("Cdn", "Origins", "2017-10-12"),
                new Tuple<string, string, string>("Cdn", "Profiles", "2017-10-12"),
                new Tuple<string, string, string>("Cdn", "ResourceUsage", "2017-10-12"),
                new Tuple<string, string, string>("Cdn", "ValidateProbe", "2017-10-12"),
            }.AsEnumerable();
        }
    }
}
