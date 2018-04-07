
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_PredictionEndpoint
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("PredictionEndpoint", "PredictImage", "1.1"),
                new Tuple<string, string, string>("PredictionEndpoint", "PredictImageUrl", "1.1"),
                new Tuple<string, string, string>("PredictionEndpoint", "PredictImageUrlWithNoStore", "1.1"),
                new Tuple<string, string, string>("PredictionEndpoint", "PredictImageWithNoStore", "1.1"),
            }.AsEnumerable();
        }
    }
}
