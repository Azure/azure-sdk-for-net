// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests
{
    public class CallingServerClientsTests : CallingServerTestBase
    {
        [TestCaseSource(nameof(TestData_CreateCall))]
        public async Task CreateCallAsync_Returns201Created(CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions createCallOptions)
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(201, CreateOrJoinCallPayload);

            var response = await callingServerClient.CreateCallConnectionAsync(source, targets, createCallOptions).ConfigureAwait(false);

            Assert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            Assert.AreEqual("cad9df7b-f3ac-4c53-96f7-c76e7437b3c1", response.Value.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCall_Returns201Created(CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions createCallOptions)
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(201, CreateOrJoinCallPayload);

            var response = callingServerClient.CreateCallConnection(source, targets, createCallOptions);

            Assert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            Assert.AreEqual("cad9df7b-f3ac-4c53-96f7-c76e7437b3c1", response.Value.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_JoinCall))]
        public async Task JoinCallAsync_Returns202Accepted(string serverCallId, CommunicationIdentifier source, JoinCallOptions joinCallOptions)
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(202, CreateOrJoinCallPayload);

            var response = await callingServerClient.JoinCallAsync(serverCallId, source, joinCallOptions).ConfigureAwait(false);

            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual("cad9df7b-f3ac-4c53-96f7-c76e7437b3c1", response.Value.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_JoinCall))]
        public void JoinCall_Returns202Accepted(string serverCallId, CommunicationIdentifier source, JoinCallOptions joinCallOptions)
        {
            CallingServerClient callingServerClient = CreateMockCallingServerClient(202, CreateOrJoinCallPayload);

            var response = callingServerClient.JoinCall(serverCallId, source, joinCallOptions);

            Assert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            Assert.AreEqual("cad9df7b-f3ac-4c53-96f7-c76e7437b3c1", response.Value.CallConnectionId);
        }

        private static IEnumerable<object?[]> TestData_CreateCall()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationUserIdentifier("8:acs:resource_source"),
                    new CommunicationIdentifier[]
                    {
                        new CommunicationUserIdentifier("8:acs:resource_target"),
                        new PhoneNumberIdentifier("+14250001234")
                    },
                    new CreateCallOptions(
                        new Uri("https://bot.contoso.com/callback"),
                        new[]
                        {
                            MediaType.Video
                        },
                        new[]
                        {
                            EventSubscriptionType.ParticipantsUpdated
                        }
                    )
                    {
                        AlternateCallerId = new PhoneNumberIdentifier("+17781234567"),
                        Subject = "testsubject"
                    }
                },
            };
        }

        private static IEnumerable<object?[]> TestData_JoinCall()
        {
            return new[]
            {
                new object?[]
                {
                    "guid",
                    new CommunicationUserIdentifier("8:acs:resource_source"),
                    new JoinCallOptions(
                        new Uri("https://bot.contoso.com/callback"),
                        new[]
                        {
                            MediaType.Video
                        },
                        new[]
                        {
                            EventSubscriptionType.ParticipantsUpdated
                        }
                    )
                    {
                        Subject = "testsubject"
                    }
                },
            };
        }
    }
}
