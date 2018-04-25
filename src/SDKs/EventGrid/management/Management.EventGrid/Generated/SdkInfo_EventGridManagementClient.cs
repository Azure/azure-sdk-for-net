
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_EventGridManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("EventGrid", "EventSubscriptions", "2018-01-01"),
                new Tuple<string, string, string>("EventGrid", "Operations", "2018-01-01"),
                new Tuple<string, string, string>("EventGrid", "TopicTypes", "2018-01-01"),
                new Tuple<string, string, string>("EventGrid", "Topics", "2018-01-01"),
            }.AsEnumerable();
        }
    }
}
