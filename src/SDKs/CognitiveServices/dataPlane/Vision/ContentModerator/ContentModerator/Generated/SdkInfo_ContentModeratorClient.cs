
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_ContentModeratorClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("ContentModeratorClient", "ImageModeration", "1.0"),
                new Tuple<string, string, string>("ContentModeratorClient", "ListManagementImage", "1.0"),
                new Tuple<string, string, string>("ContentModeratorClient", "ListManagementImageLists", "1.0"),
                new Tuple<string, string, string>("ContentModeratorClient", "ListManagementTerm", "1.0"),
                new Tuple<string, string, string>("ContentModeratorClient", "ListManagementTermLists", "1.0"),
                new Tuple<string, string, string>("ContentModeratorClient", "Reviews", "1.0"),
                new Tuple<string, string, string>("ContentModeratorClient", "TextModeration", "1.0"),
            }.AsEnumerable();
        }
    }
}
