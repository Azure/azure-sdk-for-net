// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Test.Stress;

namespace Azure.Quantum.Jobs.Stress
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await StressProgram.Main(typeof(Program).Assembly, args);
        }
    }
}
