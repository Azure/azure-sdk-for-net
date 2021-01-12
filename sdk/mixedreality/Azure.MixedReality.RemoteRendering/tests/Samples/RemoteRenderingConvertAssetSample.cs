// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
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

            client.CreateConversion(conversionId, settings);

            ConversionInformation conversion;
            for (int i = 0; i < 10; ++i)
            {
                conversion = client.GetConversion(conversionId).Value;
                if (conversion.Status == CreatedByType.Succeeded)
                {
                    Console.WriteLine($"Output written to {conversion.Settings.OutputLocation}");
                    break;
                }
                Thread.Sleep(5000);
            }
        }
    }
}
