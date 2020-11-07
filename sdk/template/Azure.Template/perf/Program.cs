// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Template.Perf
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await PerfProgram.Main(typeof(Program).Assembly, args);
        }
    }
}
