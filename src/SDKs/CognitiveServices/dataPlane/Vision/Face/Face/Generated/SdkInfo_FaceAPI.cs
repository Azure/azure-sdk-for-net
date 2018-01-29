
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_FaceAPI
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("FaceAPI", "Face", "1.0"),
                new Tuple<string, string, string>("FaceAPI", "FaceList", "1.0"),
                new Tuple<string, string, string>("FaceAPI", "PersonGroup", "1.0"),
                new Tuple<string, string, string>("FaceAPI", "PersonGroupPerson", "1.0"),
            }.AsEnumerable();
        }
    }
}
