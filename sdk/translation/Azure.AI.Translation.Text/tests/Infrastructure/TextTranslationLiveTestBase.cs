// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using static Azure.AI.Translation.Text.TextTranslationClientOptions;

namespace Azure.AI.Translation.Text.Tests
{
    public abstract class TextTranslationLiveTestBase : RecordedTestBase<TextTranslationTestEnvironment>
    {
        public TextTranslationLiveTestBase(bool isAsync)
            : base(isAsync)
        {
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
            SanitizedHeaders.Add("Ocp-Apim-ResourceId");
        }

        public TextTranslationClient GetClient(
            Uri endpoint = default,
            AzureKeyCredential credential = default,
            string region = default,
            TokenCredential token = default,
            bool useAADAuth = false,
            TextTranslationClientOptions options = default)
        {
            endpoint ??= new Uri(TestEnvironment.Endpoint);
            options ??= new TextTranslationClientOptions()
            {
                Diagnostics =
                {
                    LoggedHeaderNames = { "x-ms-request-id", "X-RequestId" },
                    IsLoggingContentEnabled = true
                }
            };

            if (useAADAuth)
            {
                TokenCredential aadCredential;
                if (Mode == RecordedTestMode.Playback)
                {
                    aadCredential = new StaticAccessTokenCredential(new AccessToken(string.Empty, DateTimeOffset.Now.AddDays(1)));
                }
                else
                {
                    aadCredential = new Azure.Identity.ClientSecretCredential(TestEnvironment.AADTenantId, TestEnvironment.AADClientId, TestEnvironment.AADSecret);
                }

                return InstrumentClient(new TextTranslationClient(aadCredential, resourceId: TestEnvironment.AADResourceId, region: TestEnvironment.AADRegion, options: InstrumentClientOptions(options)));
            }
            else if (token != null)
            {
                return InstrumentClient(new TextTranslationClient(token, endpoint, options: InstrumentClientOptions(options)));
            }
            else
            {
                credential ??= new AzureKeyCredential(TestEnvironment.ApiKey);
                region ??= TestEnvironment.Region;
                return InstrumentClient(new TextTranslationClient(credential, endpoint, region: region, InstrumentClientOptions(options)));
            }
        }

        public async Task<string> GetAzureAuthorizationTokenAsync()
        {
            string issueTokenURL = string.Format("https://{0}.api.cognitive.microsoft.com/sts/v1.0/issueToken?", TestEnvironment.Region);

            HttpClient httpClient = new HttpClient();
            UriBuilder requestUri = new UriBuilder(issueTokenURL);
            requestUri.Query = $"Subscription-Key={TestEnvironment.ApiKey}";
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri.Uri);
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}
