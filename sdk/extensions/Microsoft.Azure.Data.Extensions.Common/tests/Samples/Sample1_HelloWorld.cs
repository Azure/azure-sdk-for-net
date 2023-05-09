// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Microsoft.Azure.Data.Extensions.Microsoft.Azure.Data.Extensions.Common.Tests.Samples
{
    public partial class Microsoft.Azure.Data.Extensions.CommonSamples: SamplesBase<Microsoft.Azure.Data.Extensions.CommonClientTestEnvironment>
    {
        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/Samples/Sample1.HelloWorld.cs to write samples. */
        [Test]
        [SyncOnly]
        public void Scenario()
        {
            #region Snippet:Azure_Microsoft_Azure_Data_Extensions_Microsoft.Azure.Data.Extensions.Common_Scenario
            Console.WriteLine("Hello, world!");
            #endregion
        }
    }
}
