// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading;

namespace Azure.MixedReality.RemoteRendering.Tests.Samples
{
    public class RemoteRenderingCreateSessionSample : SamplesBase<RemoteRenderingTestEnvironment>
    {
        private readonly RemoteRenderingAccount _account;
        private readonly string _accountKey;
        private readonly Uri _serviceEndpoint;

        public RemoteRenderingCreateSessionSample()
        {
            _account = new RemoteRenderingAccount(new Guid(TestEnvironment.AccountId), TestEnvironment.AccountDomain);
            _accountKey = TestEnvironment.AccountKey;
            _serviceEndpoint = new Uri(TestEnvironment.ServiceEndpoint);
        }

        //[Test]
        public void CreateSession()
        {
            AzureKeyCredential accountKeyCredential = new AzureKeyCredential(_accountKey);

            RemoteRenderingClient client = new RemoteRenderingClient(_serviceEndpoint, _account, accountKeyCredential);

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

        //[Test]
        public void QueryAndUpdateASession()
        {
            AzureKeyCredential accountKeyCredential = new AzureKeyCredential(_accountKey);

            RemoteRenderingClient client = new RemoteRenderingClient(_serviceEndpoint, _account, accountKeyCredential);

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

        //[Test]
        public void GetInformationAboutSessions()
        {
            AzureKeyCredential accountKeyCredential = new AzureKeyCredential(_accountKey);

            RemoteRenderingClient client = new RemoteRenderingClient(_serviceEndpoint, _account, accountKeyCredential);

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
    }
}
