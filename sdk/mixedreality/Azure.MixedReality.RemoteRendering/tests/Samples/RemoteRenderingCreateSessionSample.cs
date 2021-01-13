// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.TestFramework;
using Azure.MixedReality.RemoteRendering.Models;

namespace Azure.MixedReality.RemoteRendering.Tests.Samples
{
    public class RemoteRenderingCreateSessionSample : SamplesBase<RemoteRenderingTestEnvironment>
    {
        private readonly RemoteRenderingAccount _account;
        private readonly string _accountKey;

        public RemoteRenderingCreateSessionSample()
        {
            _account = new RemoteRenderingAccount(TestEnvironment.AccountId, TestEnvironment.AccountDomain);
            _accountKey = TestEnvironment.AccountKey;
        }

        public void CreateSession()
        {
            AzureKeyCredential accountKeyCredential = new AzureKeyCredential(_accountKey);

            RemoteRenderingClient client = new RemoteRenderingClient(_account, accountKeyCredential);

            #region Snippet:CreateASession

            string sessionId = "SessionId1";

            CreateSessionBody settings = new CreateSessionBody(10, SessionSize.Standard);

            client.CreateSession(sessionId, settings);

            #endregion Snippet:CreateASession
            #region Snippet:QuerySessionStatus

            // Poll every 10 seconds until the session is ready.
            while (true)
            {
                Thread.Sleep(10000);

                SessionProperties properties = client.GetSession(sessionId).Value;
                if (properties.Status == SessionStatus.Ready)
                {
                    Console.WriteLine($"The session is ready. The session hostname is: {properties.Hostname}");
                    break;
                }
                else if (properties.Status == SessionStatus.Error)
                {
                    Console.WriteLine($"Session creation encountered an error: {properties.Error.Code} {properties.Error.Message}");
                    break;
                }
            }

            #endregion Snippet:QuerySessionStatus
        }
    }
}
