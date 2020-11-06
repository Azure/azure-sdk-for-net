// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Test.Perf;

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
