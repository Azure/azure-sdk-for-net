// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.CallAutomation.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.CommunicationIdentifiers
{
    public class CommunicationIdentiferTests : CallAutomationTestBase
    {
        private const string TestTeamsAppId = "testteamsappid";

        [Test]
        public void SerializeMicrosoftTeamsApp()
        {
            CommunicationIdentifierModel model = CommunicationIdentifierSerializer.Serialize(
                new MicrosoftTeamsAppIdentifier(TestTeamsAppId, CommunicationCloudEnvironment.Public));

            Assert.AreEqual(TestTeamsAppId, model.MicrosoftTeamsApp.AppId);
            Assert.AreEqual(CommunicationCloudEnvironmentModel.Public, model.MicrosoftTeamsApp.Cloud);
            Assert.AreEqual($"28:orgid:{TestTeamsAppId}", model.RawId);
        }
    }
}
