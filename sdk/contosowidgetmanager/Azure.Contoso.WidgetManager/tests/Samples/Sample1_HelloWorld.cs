// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Contoso.WidgetManager.Tests.Samples
{
    public partial class WidgetManagerSamples: SamplesBase<WidgetManagerClientTestEnvironment>
    {
        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/Samples/Sample1.HelloWorld.cs to write samples. */
        [Test]
        [SyncOnly]
        public void Scenario()
        {
            #region Snippet:Azure_Contoso_WidgetManager_Scenario
            Console.WriteLine("Hello, world!");
            #endregion
        }
    }
}
