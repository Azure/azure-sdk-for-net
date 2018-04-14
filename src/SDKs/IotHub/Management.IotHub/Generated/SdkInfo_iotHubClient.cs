
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_iotHubClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Devices", "Certificates", "2018-04-01"),
                new Tuple<string, string, string>("Devices", "IotHubResource", "2018-04-01"),
                new Tuple<string, string, string>("Devices", "Operations", "2018-04-01"),
            }.AsEnumerable();
        }
    }
}
