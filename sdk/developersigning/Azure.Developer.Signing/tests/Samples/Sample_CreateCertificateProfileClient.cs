// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Developer.Signing.Tests.Samples
{
    public partial class DeveloperSigningSample : SamplesBase<DevSigningTestEnvironment>
    {
        public void CreateClients(string region)
        {
            #region Snippet:Azure_Developer_Signing_CreateCertificateProfileClient_Scenario

            var credential = new DefaultAzureCredential();
            var signClient = new SigningClient(credential);
            var CertificatProfileClient = signClient.GetCertificateProfileClient(region);

            #endregion Snippet:Azure_Developer_Signing_CreateCertificateProfileClient_Scenario
        }
    }
}
