// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading;
using Azure.Core;
using Azure.Identity;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Azure.MixedReality.RemoteRendering.Tests.Samples
{
    public class RemoteRenderingCreateSessionSample : SamplesBase<RemoteRenderingTestEnvironment>
    {
        /// <summary>
        /// Demonstrates how to obtain a client with an AzureKeyCredential.
        /// Methods which demonstrate other authentication schemes are at the bottom of the file.
        /// </summary>
        /// <returns></returns>
        private RemoteRenderingClient GetClientWithAccountKey()
        {
            Guid accountId = new Guid(TestEnvironment.AccountId);
            string accountDomain = TestEnvironment.AccountDomain;
            string accountKey = TestEnvironment.AccountKey;
            Uri remoteRenderingEndpoint = new Uri(TestEnvironment.ServiceEndpoint);

            #region Snippet:CreateAClient
            AzureKeyCredential accountKeyCredential = new AzureKeyCredential(accountKey);

            RemoteRenderingClient client = new RemoteRenderingClient(remoteRenderingEndpoint, accountId, accountDomain, accountKeyCredential);
            #endregion Snippet:CreateAClient
            return client;
        }

        [Test]
        [Explicit("To avoid launching too many sessions during testing, we rely on the live tests.")]
        public void CreateSession()
        {
            RemoteRenderingClient client = GetClientWithAccountKey();

            #region Snippet:CreateASession

            RenderingSessionOptions options = new RenderingSessionOptions(TimeSpan.FromMinutes(30), RenderingServerSize.Standard);

            // A randomly generated GUID is a good choice for a sessionId.
            string sessionId = Guid.NewGuid().ToString();

            StartRenderingSessionOperation startSessionOperation = client.StartSession(sessionId, options);

            RenderingSession newSession = startSessionOperation.WaitForCompletionAsync().Result;
            if (newSession.Status == RenderingSessionStatus.Ready)
            {
                Console.WriteLine($"Session {sessionId} is ready.");
            }
            else if (newSession.Status == RenderingSessionStatus.Error)
            {
                Console.WriteLine($"Session {sessionId} encountered an error: {newSession.Error.Code} {newSession.Error.Message}");
            }

            #endregion Snippet:CreateASession

            // Use the session here.
            // ...

            // The session will automatically timeout, but in this sample we also demonstrate how to shut it down explicitly.
            #region Snippet:StopSession

            client.StopSession(sessionId);

            #endregion Snippet:StopSession
        }

        [Test]
        [Explicit("To avoid launching too many sessions during testing, we rely on the live tests.")]
        public void QueryAndUpdateASession()
        {
            RemoteRenderingClient client = GetClientWithAccountKey();

            string sessionId = Guid.NewGuid().ToString();

            RenderingSessionOptions settings = new RenderingSessionOptions(TimeSpan.FromMinutes(30), RenderingServerSize.Standard);

            RenderingSession newSession = client.StartSession(sessionId, settings).WaitForCompletionAsync().Result;

            #region Snippet:UpdateSession

            RenderingSession currentSession = client.GetSession(sessionId);

            if (currentSession.MaxLeaseTime - DateTimeOffset.Now.Subtract(currentSession.CreatedOn.Value) < TimeSpan.FromMinutes(2))
            {
                TimeSpan newLeaseTime = currentSession.MaxLeaseTime.Value.Add(TimeSpan.FromMinutes(30));

                UpdateSessionOptions longerLeaseSettings = new UpdateSessionOptions(newLeaseTime);

                client.UpdateSession(sessionId, longerLeaseSettings);
            }

            #endregion Snippet:UpdateSession

            client.StopSession(sessionId);
        }

        [Test]
        [Explicit("To avoid launching too many sessions during testing, we rely on the live tests.")]
        public void GetInformationAboutSessions()
        {
            RemoteRenderingClient client = GetClientWithAccountKey();

            // Ensure there's at least one session to query.
            string sessionId = Guid.NewGuid().ToString();
            RenderingSessionOptions settings = new RenderingSessionOptions(TimeSpan.FromMinutes(30), RenderingServerSize.Standard);
            client.StartSession(sessionId, settings);
            Thread.Sleep(TimeSpan.FromSeconds(10));

            #region Snippet:ListSessions

            foreach (var properties in client.GetSessions())
            {
                if (properties.Status == RenderingSessionStatus.Starting)
                {
                    Console.WriteLine($"Session \"{properties.SessionId}\" is starting.");
                }
                else if (properties.Status == RenderingSessionStatus.Ready)
                {
                    Console.WriteLine($"Session \"{properties.SessionId}\" is ready at host {properties.Host}");
                }
            }

            #endregion Snippet:ListSessions

            client.StopSession(sessionId);
        }

        #region Other ways of authenticating the RemoteRenderingClient.

        private RemoteRenderingClient GetClientWithAAD()
        {
            Guid accountId = new Guid(TestEnvironment.AccountId);
            string accountDomain = TestEnvironment.AccountDomain;
            string tenantId = TestEnvironment.TenantId;
            string clientId = TestEnvironment.ClientId;
            string clientSecret = TestEnvironment.ClientSecret;
            Uri remoteRenderingEndpoint = new Uri(TestEnvironment.ServiceEndpoint);

            #region Snippet:CreateAClientWithAAD

            TokenCredential credential = new ClientSecretCredential(tenantId, clientId, clientSecret, new TokenCredentialOptions
            {
                AuthorityHost = new Uri($"https://login.microsoftonline.com/{tenantId}")
            });

            RemoteRenderingClient client = new RemoteRenderingClient(remoteRenderingEndpoint, accountId, accountDomain, credential);
            #endregion Snippet:CreateAClientWithAAD
            return client;
        }

        private RemoteRenderingClient GetClientWithDeviceCode()
        {
            Guid accountId = new Guid(TestEnvironment.AccountId);
            string accountDomain = TestEnvironment.AccountDomain;
            string tenantId = TestEnvironment.TenantId;
            string clientId = TestEnvironment.ClientId;
            Uri remoteRenderingEndpoint = new Uri(TestEnvironment.ServiceEndpoint);

            #region Snippet:CreateAClientWithDeviceCode

            Task deviceCodeCallback(DeviceCodeInfo deviceCodeInfo, CancellationToken cancellationToken)
            {
                Console.WriteLine(deviceCodeInfo.Message);
                return Task.FromResult(0);
            }

            TokenCredential credential = new DeviceCodeCredential(deviceCodeCallback, tenantId, clientId, new TokenCredentialOptions
            {
                AuthorityHost = new Uri($"https://login.microsoftonline.com/{tenantId}"),
            });

            RemoteRenderingClient client = new RemoteRenderingClient(remoteRenderingEndpoint, accountId, accountDomain, credential);
            #endregion Snippet:CreateAClientWithDeviceCode
            return client;
        }

        private RemoteRenderingClient GetClientWithDefaultAzureCredential()
        {
            Guid accountId = new Guid(TestEnvironment.AccountId);
            string accountDomain = TestEnvironment.AccountDomain;
            Uri remoteRenderingEndpoint = new Uri(TestEnvironment.ServiceEndpoint);

            #region Snippet:CreateAClientWithAzureCredential

            TokenCredential credential = new DefaultAzureCredential(includeInteractiveCredentials: true);

            RemoteRenderingClient client = new RemoteRenderingClient(remoteRenderingEndpoint, accountId, accountDomain, credential);
            #endregion Snippet:CreateAClientWithAzureCredential

            return client;
        }

        private AccessToken GetMixedRealityAccessTokenFromWebService()
        {
            return new AccessToken("TokenObtainedFromStsClientRunningInWebservice", DateTimeOffset.MaxValue);
        }

        private RemoteRenderingClient GetClientWithStaticAccessToken()
        {
            Guid accountId = new Guid(TestEnvironment.AccountId);
            string accountDomain = TestEnvironment.AccountDomain;
            Uri remoteRenderingEndpoint = new Uri(TestEnvironment.ServiceEndpoint);

            #region Snippet:CreateAClientWithStaticAccessToken

            // GetMixedRealityAccessTokenFromWebService is a hypothetical method that retrieves
            // a Mixed Reality access token from a web service. The web service would use the
            // MixedRealityStsClient and credentials to obtain an access token to be returned
            // to the client.
            AccessToken accessToken = GetMixedRealityAccessTokenFromWebService();

            RemoteRenderingClient client = new RemoteRenderingClient(remoteRenderingEndpoint, accountId, accountDomain, accessToken);
            #endregion Snippet:CreateAClientWithStaticAccessToken

            return client;
        }

        #endregion
    }
}
