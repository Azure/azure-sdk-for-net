// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests.Samples
{
    public partial class EasmSamples: SamplesBase<EasmClientTestEnvironment>
    {
        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/Samples/Sample1.HelloWorldAsync.cs to write samples. */
        [Test]
        [AsyncOnly]
        public async System.Threading.Tasks.Task ScenarioAsync()
        {
            #region Snippet:Azure_Analytics_Defender_Easm_ScenarioAsync
            Console.WriteLine("Hello, world!");
            #endregion

            await System.Threading.Tasks.Task.Yield();
        }
    }
}
