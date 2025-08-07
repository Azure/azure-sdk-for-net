// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Messages.Models.Channels;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Messages.Tests
{
    public class MessageTemplateClientTests : ClientTestBase
    {
        protected const string ConnectionString = "endpoint=https://contoso.azure.com/;accesskey=ZHVtbXlhY2Nlc3NrZXk=";
        private const string GetTemplatesApiResponsePayload = "{\"value\":[{\"name\":\"optin_confirmation\",\"language\":\"en_US\",\"kind\":\"whatsApp\",\"status\":\"approved\",\"whatsApp\":{\"content\":[{\"type\":\"BODY\",\"text\":\"Reply {{1}} to receive {{2}}. Txt {{3}} for HELP, Txt {{4}} to opt-out.\"}]}},{\"name\":\"sample_flight_confirmation\",\"language\":\"en_US\",\"kind\":\"whatsApp\",\"status\":\"approved\",\"whatsApp\":{\"content\":[{\"type\":\"HEADER\",\"format\":\"DOCUMENT\"},{\"type\":\"BODY\",\"text\":\"This is your flight confirmation for {{1}}-{{2}} on {{3}}.\"},{\"type\":\"FOOTER\",\"text\":\"This message is from an unverified business.\"}]}},{\"name\":\"sample_happy_hour_announcement\",\"language\":\"pt_BR\",\"kind\":\"whatsApp\",\"status\":\"approved\",\"whatsApp\":{\"content\":[{\"type\":\"HEADER\",\"format\":\"VIDEO\"},{\"type\":\"BODY\",\"text\":\"O happy hour chegou! \\ud83c\\udf7a😀\\ud83c\\udf78\\nSeja feliz e aproveite o dia. \\ud83c\\udf89\\nLocal: {{1}}\\nHorário: {{2}}\"},{\"type\":\"FOOTER\",\"text\":\"Esta mensagem é de uma empresa não verificada.\"}]}}]}";

        public MessageTemplateClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void Constructor_NullEndpoint_ShouldThrowArgumentNullException()
        {
            // Arrange
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("ZHVtbXlhY2Nlc3NrZXk=");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new MessageTemplateClient(endpoint, credential));
        }

        [Test]
        public void Constructor_InvalidConnectionString_ShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() => new MessageTemplateClient(null));
            Assert.Throws<ArgumentException>(() => new MessageTemplateClient(string.Empty));
            Assert.Throws<ArgumentException>(() => new MessageTemplateClient(""));
            Assert.Throws<InvalidOperationException>(() => new MessageTemplateClient("  "));
            Assert.Throws<InvalidOperationException>(() => new MessageTemplateClient("test"));
        }

        [Test]
        public Task GetTemplates_InvalidChannelId_ShouldThrowBadRequestException()
        {
            //arrange
            MessageTemplateClient messageTemplateClient = CreateMockMessageTemplateClient();
            var emptyChannelId = Guid.Empty;

            // Act & Assert
            try
            {
                //act
                messageTemplateClient.GetTemplatesAsync(emptyChannelId);
            }
            catch (RequestFailedException requestFailedException)
            {
                //assert
                Assert.AreEqual(400, requestFailedException.Status);
            }

            return Task.CompletedTask;
        }

        [Test]
        public async Task GetTemplates_ValidParams_ShouldSucceed()
        {
            //arrange
            MessageTemplateClient messageTemplateClient = CreateMockMessageTemplateClient(200, GetTemplatesApiResponsePayload);
            var channelId = Guid.NewGuid();

            //act
            AsyncPageable<MessageTemplateItem> templates = messageTemplateClient.GetTemplatesAsync(channelId);

            //assert
            await foreach (MessageTemplateItem template in templates)
            {
                Assert.IsNotNull(template.Name);
                Assert.IsNotNull(template.Language);
                Assert.IsNotNull(template.Status);
                Assert.IsTrue(template is WhatsAppMessageTemplateItem);
            }
        }

        [Test]
        public void GetTemplates_NullChannelId_Throws()
        {
            //arrange
            MessageTemplateClient messageTemplateClient = CreateMockMessageTemplateClient();

            //act & assert
            Assert.Throws<FormatException>(() => messageTemplateClient.GetTemplatesAsync(new Guid(string.Empty)));
        }

        private static MessageTemplateClient CreateMockMessageTemplateClient(int responseCode = 200, string responseContent = null)
        {
            var mockResponse = new MockResponse(responseCode);
            if (responseContent != null)
            {
                mockResponse.SetContent(responseContent);
            }

            var MessageTemplateClientOptions = new CommunicationMessagesClientOptions
            {
                Transport = new MockTransport(mockResponse)
            };

            return new MessageTemplateClient(ConnectionString, MessageTemplateClientOptions);
        }
    }
}
