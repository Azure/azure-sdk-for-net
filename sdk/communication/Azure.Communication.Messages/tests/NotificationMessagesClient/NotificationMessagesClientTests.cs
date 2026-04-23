// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Azure.Communication.Messages.Tests
{
    public class NotificationMessagesClientTests : ClientTestBase
    {
        protected const string ConnectionString = "endpoint=https://contoso.azure.com/;accesskey=ZHVtbXlhY2Nlc3NrZXk=";

        private const string SendMessageApiResponsePayload = "{\"receipts\":[{\"messageId\":\"d53605de-2f6e-437d-9e40-8d83b2111cb8\",\"to\":\"+1(123)456-7890\"}]}";

        public NotificationMessagesClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void Constructor_InvalidConnectionString_ShouldThrow()
        {
            ClassicAssert.Throws<ArgumentNullException>(() => new NotificationMessagesClient((string)null));
            ClassicAssert.Throws<ArgumentException>(() => new NotificationMessagesClient(string.Empty));
            ClassicAssert.Throws<ArgumentException>(() => new NotificationMessagesClient(""));
            ClassicAssert.Throws<InvalidOperationException>(() => new NotificationMessagesClient("  "));
            ClassicAssert.Throws<InvalidOperationException>(() => new NotificationMessagesClient("test"));
        }

        [Test]
        public void Constructor_NullEndpoint_ShouldThrowArgumentNullException()
        {
            // Arrange
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("ZHVtbXlhY2Nlc3NrZXk=");

            // Act & Assert
            ClassicAssert.Throws<ArgumentNullException>(() => new NotificationMessagesClient(endpoint, credential));
        }

        [Test]
        public void CreateClient_InvalidCredential_ShouldThrow()
        {
            // Arrange
            var validEndpoint = new Uri("https://contoso.azure.com/");

            // Act and Assert
            ClassicAssert.Throws<ArgumentNullException>(() => new NotificationMessagesClient(validEndpoint, new AzureKeyCredential(null)));
            ClassicAssert.Throws<ArgumentException>(() => new NotificationMessagesClient(validEndpoint, new AzureKeyCredential(string.Empty)));
            ClassicAssert.Throws<ArgumentException>(() => new NotificationMessagesClient(validEndpoint, new AzureKeyCredential("")));
        }

        [Test]
        public async Task SendMessage_ValidParams_ShouldSucceed()
        {
            //arrange
            NotificationMessagesClient notificationMessagesClient = CreateMockNotificationMessagesClient(202, SendMessageApiResponsePayload);

            //act
            TextNotificationContent content = new(Guid.NewGuid(), new List<string> { "+1(123)456-7890" }, "testMessage");
            SendMessageResult sendMessageResult = await notificationMessagesClient.SendAsync(content);

            //assert
            ClassicAssert.IsNotNull(sendMessageResult.Receipts[0].MessageId);
            ClassicAssert.IsNotNull(sendMessageResult.Receipts[0].To);
            ClassicAssert.AreEqual("d53605de-2f6e-437d-9e40-8d83b2111cb8", sendMessageResult.Receipts[0].MessageId);
            ClassicAssert.AreEqual("+1(123)456-7890", sendMessageResult.Receipts[0].To);
        }

        [Test]
        public void SendNotificationMessage_NullSendMessageOptions_Throws()
        {
            //arrange
            NotificationMessagesClient notificationMessagesClient = CreateMockNotificationMessagesClient();

            //act & assert
            ClassicAssert.ThrowsAsync<ArgumentNullException>(async () => await notificationMessagesClient.SendAsync((NotificationContent)null));
        }

        [Test]
        public async Task SendMessage_InvalidChannelRegistrationId_ThrowsBadRequestException()
        {
            //arrange
            NotificationMessagesClient notificationMessagesClient = CreateMockNotificationMessagesClient(400);

            try
            {
                //act
                TextNotificationContent content = new(Guid.NewGuid(), new List<string> { "+1(123)456-7890" }, "testMessage");
                await notificationMessagesClient.SendAsync(content);
            }
            catch (RequestFailedException requestFailedException)
            {
                //assert
                ClassicAssert.AreEqual(400, requestFailedException.Status);
            }
        }

        private static NotificationMessagesClient CreateMockNotificationMessagesClient(int responseCode = 202, string responseContent = null)
        {
            var mockResponse = new MockResponse(responseCode);
            if (responseContent != null)
            {
                mockResponse.SetContent(responseContent);
            }

            var notificationMessagesClientOptions = new CommunicationMessagesClientOptions
            {
                Transport = new MockTransport(mockResponse)
            };

            return new NotificationMessagesClient(ConnectionString, notificationMessagesClientOptions);
        }
    }
}
