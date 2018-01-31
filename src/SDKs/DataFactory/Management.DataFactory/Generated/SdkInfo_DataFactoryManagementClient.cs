
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_DataFactoryManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("DataFactory", "ActivityRuns", "2017-09-01-preview"),
                new Tuple<string, string, string>("DataFactory", "Datasets", "2017-09-01-preview"),
                new Tuple<string, string, string>("DataFactory", "Factories", "2017-09-01-preview"),
                new Tuple<string, string, string>("DataFactory", "IntegrationRuntimeNodes", "2017-09-01-preview"),
                new Tuple<string, string, string>("DataFactory", "IntegrationRuntimes", "2017-09-01-preview"),
                new Tuple<string, string, string>("DataFactory", "LinkedServices", "2017-09-01-preview"),
                new Tuple<string, string, string>("DataFactory", "Operations", "2017-09-01-preview"),
                new Tuple<string, string, string>("DataFactory", "PipelineRuns", "2017-09-01-preview"),
                new Tuple<string, string, string>("DataFactory", "Pipelines", "2017-09-01-preview"),
                new Tuple<string, string, string>("DataFactory", "Triggers", "2017-09-01-preview"),
            }.AsEnumerable();
        }
    }
}
