// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Stress;
using System.Threading.Tasks;

namespace Azure.Sample.Stress
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await StressProgram.Main(typeof(Program).Assembly, args);
        }
    }
}
