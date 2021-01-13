// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.TestFramework;
using Azure.MixedReality.RemoteRendering.Models;

namespace Azure.MixedReality.RemoteRendering.Tests.Samples
{
    public class RemoteRenderingConvertAssetSample : SamplesBase<RemoteRenderingTestEnvironment>
    {
        private readonly RemoteRenderingAccount _account;
        private readonly string _accountKey;

        public RemoteRenderingConvertAssetSample()
        {
            _account = new RemoteRenderingAccount(TestEnvironment.AccountId, TestEnvironment.AccountDomain);
            _accountKey = TestEnvironment.AccountKey;
        }

        public void ConvertAsset()
        {
            #region Snippet:ConvertingAnAsset

            AzureKeyCredential accountKeyCredential = new AzureKeyCredential(_accountKey);

            RemoteRenderingClient client = new RemoteRenderingClient(_account, accountKeyCredential);

            ConversionInputSettings input = new ConversionInputSettings("MyInputContainer", "box.fbx");
            ConversionOutputSettings output = new ConversionOutputSettings("MyOutputContainer");
            ConversionSettings settings = new ConversionSettings(input, output);

            string conversionId = "ConversionId1";

            client.CreateConversion(conversionId, settings);

            ConversionInformation conversion;

            // Poll every 10 seconds completion every ten seconds.
            while (true)
            {
                Thread.Sleep(10000);

                conversion = client.GetConversion(conversionId).Value;
                if (conversion.Status == CreatedByType.Succeeded)
                {
                    Console.WriteLine($"Conversion succeeded: Output written to {conversion.Settings.OutputLocation}");
                    break;
                }
                else if (conversion.Status == CreatedByType.Failed)
                {
                    Console.WriteLine($"Conversion failed: {conversion.Error.Code} {conversion.Error.Message}");
                    break;
                }
            }
            #endregion Snippet:ConvertingAnAsset
        }
    }
}
