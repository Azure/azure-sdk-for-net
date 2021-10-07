// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Data.Tables.Performance
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Allow the framework to execute the test scenarios.
            await PerfProgram.Main(Assembly.GetEntryAssembly(), args);
        }
    }
}
