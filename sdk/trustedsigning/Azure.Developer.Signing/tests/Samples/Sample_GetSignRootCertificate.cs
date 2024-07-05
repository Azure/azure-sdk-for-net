// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Developer.Signing.Tests.Samples
{
    public partial class Sample_GetSignRootCertificate : SamplesBase<DevSigningClientTestEnvironment>
    {
        [Test]
        public void GetSignRootCertificate()
        {
            string accountName = TestEnvironment.AccountName;
            string profileName = TestEnvironment.ProfileName;
            string region = TestEnvironment.Region;
            var credential = new DefaultAzureCredential();

            #region Snippet:Azure_Developer_Signing_GetSignRootCertificate
            CertificateProfile certificateProfileClient = new SigningClient(region, credential).GetCertificateProfileClient();

            Response<BinaryData> response = certificateProfileClient.GetSignRootCertificate(accountName, profileName);

            byte[] rootCertificate = response.Value.ToArray();
            #endregion Snippet:Azure_Developer_Signing_GetSignRootCertificate
        }
    }
}
