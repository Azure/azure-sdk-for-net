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
        private readonly Uri _serviceEndpoint;

        public RemoteRenderingConvertAssetSample()
        {
            _account = new RemoteRenderingAccount(TestEnvironment.AccountId, TestEnvironment.AccountDomain);
            _accountKey = TestEnvironment.AccountKey;
            _serviceEndpoint = new Uri(TestEnvironment.ServiceEndpoint);
        }

        public void ConvertAsset()
        {
            AzureKeyCredential accountKeyCredential = new AzureKeyCredential(_accountKey);

            RemoteRenderingClient client = new RemoteRenderingClient(_account, accountKeyCredential, _serviceEndpoint);

            #region Snippet:StartAnAssetConversion

            ConversionInputSettings input = new ConversionInputSettings("MyInputContainer", "box.fbx");
            ConversionOutputSettings output = new ConversionOutputSettings("MyOutputContainer");
            ConversionSettings settings = new ConversionSettings(input, output);

            // A randomly generated GUID is a good choice for a conversionId.
            string conversionId = Guid.NewGuid().ToString();

            client.CreateConversion(conversionId, settings);

            #endregion Snippet:StartAnAssetConversion
            #region Snippet:QueryConversionStatus

            // Poll every 10 seconds completion every ten seconds.
            while (true)
            {
                Thread.Sleep(10000);

                ConversionInformation conversion = client.GetConversion(conversionId).Value;
                if (conversion.Status == ConversionStatus.Succeeded)
                {
                    Console.WriteLine($"Conversion succeeded: Output written to {conversion.Settings.OutputLocation}");
                    break;
                }
                else if (conversion.Status == ConversionStatus.Failed)
                {
                    Console.WriteLine($"Conversion failed: {conversion.Error.Code} {conversion.Error.Message}");
                    break;
                }
            }
            #endregion Snippet:QueryConversionStatus
        }

        public void ListConversions()
        {
            AzureKeyCredential accountKeyCredential = new AzureKeyCredential(_accountKey);

            RemoteRenderingClient client = new RemoteRenderingClient(_account, accountKeyCredential, _serviceEndpoint);

            ConversionInputSettings input = new ConversionInputSettings("MyInputContainer", "box.fbx");
            ConversionOutputSettings output = new ConversionOutputSettings("MyOutputContainer");
            ConversionSettings settings = new ConversionSettings(input, output);

            string conversionId = Guid.NewGuid().ToString();

            client.CreateConversion(conversionId, settings);

            #region Snippet:ListConversions

            Console.WriteLine("The ids of currently active conversions are:");
            foreach (var conversion in client.ListConversions())
            {
                if (conversion.Status == ConversionStatus.Running)
                {
                    Console.WriteLine(conversion.Id);
                }
            }

            #endregion
        }
    }
}
