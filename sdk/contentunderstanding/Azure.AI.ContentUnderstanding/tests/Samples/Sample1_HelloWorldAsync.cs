// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests.Samples
{
    public partial class ContentUnderstandingSamples: SamplesBase<ContentUnderstandingClientTestEnvironment>
    {
        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/Samples/Sample1.HelloWorldAsync.cs to write samples. */
        [Test]
        [AsyncOnly]
        public async Task ScenarioAsync()
        {
            #region Snippet:Azure_AI_ContentUnderstanding_ScenarioAsync
            Console.WriteLine("Hello, world!");
            #endregion

            await Task.Yield();
        }
    }
}
