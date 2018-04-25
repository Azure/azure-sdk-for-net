
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_SearchManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Search", "AdminKeys", "2015-08-19"),
                new Tuple<string, string, string>("Search", "Operations", "2015-08-19"),
                new Tuple<string, string, string>("Search", "QueryKeys", "2015-08-19"),
                new Tuple<string, string, string>("Search", "Services", "2015-08-19"),
            }.AsEnumerable();
        }
    }
}
