// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.MixedReality.Authentication.Tests.Samples
{
    public class MixedRealityStsClientSamples : SamplesBase<MixedRealityTestEnvironment>
    {
        [Test]
        public void GetTokenUsingAccountKeyCredential()
        {
            string mixedRealityAccountDomain = TestEnvironment.AccountDomain;
            string mixedRealityAccountId = TestEnvironment.AccountId;
            string mixedRealityAccountKey = TestEnvironment.AccountKey;

            #region Snippet:GetTokenUsingAccountKeyCredential

            MixedRealityStsClient client = new MixedRealityStsClient(mixedRealityAccountId, mixedRealityAccountDomain, new AzureKeyCredential(mixedRealityAccountKey));

            AccessToken token = client.GetToken();

            Console.WriteLine($"My access token ({token.Token}) expires on {token.ExpiresOn}.");

            #endregion Snippet:GetTokenUsingAccountKeyCredential
        }

        [Test]
        public void GetTokenUsingClientSecretCredential()
        {
            string clientId = TestEnvironment.ClientId;
            string clientSecret = TestEnvironment.ClientSecret;
            string tenantId = TestEnvironment.TenantId;
            string mixedRealityAccountDomain = TestEnvironment.AccountDomain;
            string mixedRealityAccountId = TestEnvironment.AccountId;

            #region Snippet:GetTokenUsingClientSecretCredential

            TokenCredential clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret, new TokenCredentialOptions
            {
                AuthorityHost = new Uri($"https://login.microsoftonline.com/{tenantId}")
            });

            MixedRealityStsClient client = new MixedRealityStsClient(mixedRealityAccountId, mixedRealityAccountDomain, clientSecretCredential);

            AccessToken token = client.GetToken();

            Console.WriteLine($"My access token ({token.Token}) expires on {token.ExpiresOn}.");

            #endregion Snippet:GetTokenUsingClientSecretCredential
        }

        [Test]
        public void GetTokenUsingDefaultAzureCredential()
        {
            string mixedRealityAccountDomain = TestEnvironment.AccountDomain;
            string mixedRealityAccountId = TestEnvironment.AccountId;

            #region Snippet:GetTokenUsingDefaultAzureCredential

            MixedRealityStsClient client = new MixedRealityStsClient(mixedRealityAccountId, mixedRealityAccountDomain, new DefaultAzureCredential());

            AccessToken token = client.GetToken();

            Console.WriteLine($"My access token ({token.Token}) expires on {token.ExpiresOn}.");

            #endregion Snippet:GetTokenUsingDefaultAzureCredential
        }

        [Test]
        public void GetTokenUsingDeviceCodeCredential()
        {
            string tenantId = TestEnvironment.TenantId;
            string clientId = TestEnvironment.ClientId;
            string mixedRealityAccountDomain = TestEnvironment.AccountDomain;
            string mixedRealityAccountId = TestEnvironment.AccountId;

            #region Snippet:GetTokenUsingDefaultAzureCredential

            string authority = $"https://login.microsoftonline.com/{tenantId}";

            Task deviceCodeCallback(DeviceCodeInfo deviceCodeInfo, CancellationToken cancellationToken)
            {
                Debug.WriteLine(deviceCodeInfo.Message);
                Console.WriteLine(deviceCodeInfo.Message);
                return Task.FromResult(0);
            }

            TokenCredential deviceCodeCredential = new DeviceCodeCredential(deviceCodeCallback, tenantId, clientId, new TokenCredentialOptions
            {
                AuthorityHost = new Uri(authority),
            });

            MixedRealityStsClient client = new MixedRealityStsClient(mixedRealityAccountId, mixedRealityAccountDomain, deviceCodeCredential);

            AccessToken token = client.GetToken();

            Console.WriteLine($"My access token ({token.Token}) expires on {token.ExpiresOn}.");

            #endregion Snippet:GetTokenUsingDefaultAzureCredential
        }

        [Test]
        public void GetTokenUsingVisualStudioCredential()
        {
            string tenantId = TestEnvironment.TenantId;
            string mixedRealityAccountDomain = TestEnvironment.AccountDomain;
            string mixedRealityAccountId = TestEnvironment.AccountId;

            #region Snippet:GetTokenUsingVisualStudioCredential

            string authority = $"https://login.microsoftonline.com/{tenantId}";

            VisualStudioCredential visualStudioCredential = new VisualStudioCredential(new VisualStudioCredentialOptions
            {
                AuthorityHost = new Uri(authority),
                TenantId = tenantId,
            });

            MixedRealityStsClient client = new MixedRealityStsClient(mixedRealityAccountId, mixedRealityAccountDomain, visualStudioCredential);

            AccessToken token = client.GetToken();

            Console.WriteLine($"My access token ({token.Token}) expires on {token.ExpiresOn}.");

            #endregion Snippet:GetTokenUsingVisualStudioCredential
        }
    }
}
