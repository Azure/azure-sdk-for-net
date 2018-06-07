
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_GalleryAdminClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Gallery.Admin", "Operations", "2015-04-01"),
                new Tuple<string, string, string>("gallery.admin", "GalleryItems", "2015-04-01"),
            }.AsEnumerable();
        }
    }
}
