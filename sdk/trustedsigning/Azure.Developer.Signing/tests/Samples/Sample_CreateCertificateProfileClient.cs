// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Developer.Signing.Tests.Samples
{
    public partial class DeveloperSigningSample : SamplesBase<DevSigningClientTestEnvironment>
    {
        [Test]
        public void CreateClients(string region)
        {
            #region Snippet:Azure_Developer_Signing_CreateCertificateProfileClient

            var credential = new DefaultAzureCredential();
            CertificateProfile certificateProfileClient = new SigningClient(region, credential).GetCertificateProfileClient();

            #endregion Snippet:Azure_Developer_Signing_CreateCertificateProfileClient
        }
    }
}
