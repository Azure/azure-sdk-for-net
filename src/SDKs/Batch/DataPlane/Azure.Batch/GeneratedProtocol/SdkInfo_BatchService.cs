
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_BatchService
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("BatchService", "Account", "2018-02-01.6.1"),
                new Tuple<string, string, string>("BatchService", "Application", "2018-02-01.6.1"),
                new Tuple<string, string, string>("BatchService", "Certificate", "2018-02-01.6.1"),
                new Tuple<string, string, string>("BatchService", "ComputeNode", "2018-02-01.6.1"),
                new Tuple<string, string, string>("BatchService", "File", "2018-02-01.6.1"),
                new Tuple<string, string, string>("BatchService", "Job", "2018-02-01.6.1"),
                new Tuple<string, string, string>("BatchService", "JobSchedule", "2018-02-01.6.1"),
                new Tuple<string, string, string>("BatchService", "Pool", "2018-02-01.6.1"),
                new Tuple<string, string, string>("BatchService", "Task", "2018-02-01.6.1"),
            }.AsEnumerable();
        }
    }
}
