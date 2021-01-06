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
        private readonly string _accountDomain;
        private readonly string _accountId;
        private readonly string _accountKey;

        public RemoteRenderingCreateConversionSample()
        {
            _accountDomain = TestEnvironment.AccountDomain;
            _accountId = TestEnvironment.AccountId;
            _accountKey = TestEnvironment.AccountKey;
        }

        public void CreateConversion()
        {
            RemoteRenderingClient client = new RemoteRenderingClient(_accountId);

            // TODO Fill in with viable details.
            ConversionInputSettings input = new ConversionInputSettings("foo", "bar.fbx");
            ConversionOutputSettings output = new ConversionOutputSettings("foobar.arrAsset");
            ConversionSettings settings = new ConversionSettings(input, output);

            Response<Conversion> conversion = client.CreateConversion("MyConversionId", settings);
        }
    }
}
