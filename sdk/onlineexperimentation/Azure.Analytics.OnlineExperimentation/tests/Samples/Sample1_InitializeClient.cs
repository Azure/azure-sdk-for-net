// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.OnlineExperimentation.Samples
{
    public partial class OnlineExperimentationSamples : OnlineExperimentationSamplesBase
    {
        [Test]
        [SyncOnly]
        public void InitializeClient()
        {
            #region Snippet:OnlineExperimentation_InitializeClient
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());
            #endregion
        }

        [Test]
        [SyncOnly]
        public void InitializeClientWithApiVersion()
        {
            #region Snippet:OnlineExperimentation_InitializeClientApiVersion
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var options = new OnlineExperimentationClientOptions(OnlineExperimentationClientOptions.ServiceVersion.V2025_05_31_Preview);
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential(), options);
            #endregion
        }

        [Test]
        [SyncOnly]
        public void InitializeClientWithDiagnostics()
        {
            #region Snippet:OnlineExperimentation_InitializeClientDiagnostics
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var options = new OnlineExperimentationClientOptions()
            {
                Diagnostics =
                {
                    IsLoggingContentEnabled = true
                }
            };
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential(), options);
            #endregion
        }
    }
}
