// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Developer.Signing.Tests.Samples
{
    public partial class Sample_GetCustomerEku : SamplesBase<DevSigningClientTestEnvironment>
    {
        [Test]
        public void GetExtendedKeyUsages()
        {
            string accountName = TestEnvironment.AccountName;
            string profileName = TestEnvironment.ProfileName;
            string region = TestEnvironment.Region;
            var credential = new DefaultAzureCredential();

            #region Snippet:Azure_Developer_Signing_GetExtendedKeyUsages
            CertificateProfile certificateProfileClient = new SigningClient(credential).GetCertificateProfileClient(region);

            List<string> ekus = new();

            foreach (BinaryData item in certificateProfileClient.GetExtendedKeyUsages(accountName, profileName, null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                string eku = result.GetProperty("eku").ToString();

                ekus.Add(eku);
            }
            #endregion Snippet:Azure_Developer_Signing_GetExtendedKeyUsages
        }
    }
}
