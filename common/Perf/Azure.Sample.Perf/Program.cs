// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs.PerfStress
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await PerfStressProgram.Main(typeof(Program).Assembly, args);
        }
    }
}
