
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_SpellCheckAPI
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("SpellCheckAPI", "SpellChecker", "1.0"),
            }.AsEnumerable();
        }
    }
}
