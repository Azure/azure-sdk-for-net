
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_AzureMediaServices
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Media", "Assets", "2018-03-30-preview"),
                new Tuple<string, string, string>("Media", "ContentKeyPolicies", "2018-03-30-preview"),
                new Tuple<string, string, string>("Media", "Jobs", "2018-03-30-preview"),
                new Tuple<string, string, string>("Media", "LiveEvents", "2018-03-30-preview"),
                new Tuple<string, string, string>("Media", "LiveOutputs", "2018-03-30-preview"),
                new Tuple<string, string, string>("Media", "Locations", "2018-03-30-preview"),
                new Tuple<string, string, string>("Media", "Mediaservices", "2018-03-30-preview"),
                new Tuple<string, string, string>("Media", "Operations", "2018-03-30-preview"),
                new Tuple<string, string, string>("Media", "StreamingEndpoints", "2018-03-30-preview"),
                new Tuple<string, string, string>("Media", "StreamingLocators", "2018-03-30-preview"),
                new Tuple<string, string, string>("Media", "StreamingPolicies", "2018-03-30-preview"),
                new Tuple<string, string, string>("Media", "Transforms", "2018-03-30-preview"),
            }.AsEnumerable();
        }
    }
}
