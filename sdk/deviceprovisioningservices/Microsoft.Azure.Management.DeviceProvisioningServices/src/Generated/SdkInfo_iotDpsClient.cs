
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_iotDpsClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Devices", "DpsCertificate", "2017-11-15"),
                new Tuple<string, string, string>("Devices", "DpsCertificates", "2017-11-15"),
                new Tuple<string, string, string>("Devices", "IotDpsResource", "2017-11-15"),
                new Tuple<string, string, string>("Devices", "Operations", "2017-11-15"),
            }.AsEnumerable();
        }
    }
}
