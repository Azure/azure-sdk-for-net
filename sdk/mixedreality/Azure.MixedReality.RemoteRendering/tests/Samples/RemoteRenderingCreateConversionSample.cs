// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.MixedReality.RemoteRendering.Models;
using Azure.MixedReality.RemoteRendering.Tests;

namespace Azure.MixedReality.RemoteRendering.Tests.Samples
{
    public class RemoteRenderingCreateConversionSample : SamplesBase<RemoteRenderingTestEnvironment>
    {
        public RemoteRenderingCreateConversionSample()
        {
            string mixedRealityAccountDomain = TestEnvironment.AccountDomain;
            string mixedRealityAccountId = TestEnvironment.AccountId;
            string mixedRealityAccountKey = TestEnvironment.AccountKey;

            RemoteRenderingClient client = new RemoteRenderingClient(mixedRealityAccountId);

            // TODO Fill in details.
            ConversionRequest request = new ConversionRequest();

            Response<Conversion> conversion = client.CreateConversion("test", request);
        }
    }
}
