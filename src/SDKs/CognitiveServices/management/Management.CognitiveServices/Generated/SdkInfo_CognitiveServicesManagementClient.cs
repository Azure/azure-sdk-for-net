
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_CognitiveServicesManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("CognitiveServices", "Accounts", "2017-04-18"),
                new Tuple<string, string, string>("CognitiveServices", "CheckSkuAvailability", "2017-04-18"),
                new Tuple<string, string, string>("CognitiveServices", "Operations", "2017-04-18"),
            }.AsEnumerable();
        }
    }
}
