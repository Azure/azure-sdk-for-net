// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using Azure.Core.TestFramework;
using Azure.MixedReality.RemoteRendering.Models;
using Azure.MixedReality.RemoteRendering.Tests;

namespace Azure.MixedReality.RemoteRendering.Tests.Samples
{
    public class RemoteRenderingConvertAssetSample : SamplesBase<RemoteRenderingTestEnvironment>
    {
        private readonly string _accountDomain;
        private readonly string _accountId;
        private readonly string _accountKey;

        public RemoteRenderingConvertAssetSample()
        {
            _accountDomain = TestEnvironment.AccountDomain;
            _accountId = TestEnvironment.AccountId;
            _accountKey = TestEnvironment.AccountKey;
        }

        public void ConvertAsset()
        {
            RemoteRenderingClient client = new RemoteRenderingClient(_accountId);

            // TODO Fill in with viable details.
            ConversionInputSettings input = new ConversionInputSettings("foo", "bar.fbx");
            ConversionOutputSettings output = new ConversionOutputSettings("foobar.arrAsset");
            ConversionSettings settings = new ConversionSettings(input, output);

            string conversionId = "MyConversionId";

            ConversionInformation conversion = client.CreateConversion(conversionId, settings).Value;

            ConversionInformation conversion2 = client.GetConversion(conversionId).Value;
        }
    }
}
