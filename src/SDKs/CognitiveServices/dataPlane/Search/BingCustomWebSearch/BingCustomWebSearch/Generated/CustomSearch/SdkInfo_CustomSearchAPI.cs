
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_CustomSearchAPI
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("CustomSearchAPI", "CustomInstance", "1.0"),
            }.AsEnumerable();
        }
    }
}
