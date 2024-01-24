// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Messages.Tests
{
    public class MessageTemplateClientTests : ClientTestBase
    {
        protected const string ConnectionString = "endpoint=https://contoso.azure.com/;accesskey=ZHVtbXlhY2Nlc3NrZXk=";
        private const string GetTemplatesApiResponsePayload = "{\"value\":[{\"name\":\"optin_confirmation\",\"language\":\"en_US\",\"channelType\":\"whatsApp\",\"status\":\"approved\",\"whatsApp\":{\"content\":[{\"type\":\"BODY\",\"text\":\"Reply {{1}} to receive {{2}}. Txt {{3}} for HELP, Txt {{4}} to opt-out.\"}]}},{\"name\":\"sample_flight_confirmation\",\"language\":\"en_US\",\"channelType\":\"whatsApp\",\"status\":\"approved\",\"whatsApp\":{\"content\":[{\"type\":\"HEADER\",\"format\":\"DOCUMENT\"},{\"type\":\"BODY\",\"text\":\"This is your flight confirmation for {{1}}-{{2}} on {{3}}.\"},{\"type\":\"FOOTER\",\"text\":\"This message is from an unverified business.\"}]}},{\"name\":\"sample_happy_hour_announcement\",\"language\":\"pt_BR\",\"channelType\":\"whatsApp\",\"status\":\"approved\",\"whatsApp\":{\"content\":[{\"type\":\"HEADER\",\"format\":\"VIDEO\"},{\"type\":\"BODY\",\"text\":\"O happy hour chegou! \\ud83c\\udf7a😀\\ud83c\\udf78\\nSeja feliz e aproveite o dia. \\ud83c\\udf89\\nLocal: {{1}}\\nHorário: {{2}}\"},{\"type\":\"FOOTER\",\"text\":\"Esta mensagem é de uma empresa não verificada.\"}]}}]}";

        public MessageTemplateClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void Constructor_InvalidParamsThrows()
        {
            Assert.Throws<ArgumentNullException>(() => new MessageTemplateClient(null));
            Assert.Throws<ArgumentException>(() => new MessageTemplateClient(string.Empty));
            Assert.Throws<InvalidOperationException>(() => new MessageTemplateClient(" "));
            Assert.Throws<InvalidOperationException>(() => new MessageTemplateClient("test"));
        }

        [Test]
        public async Task GetTemplates_ValidParams_ShouldSucceed()
        {
            //arrange
            MessageTemplateClient messageTemplateClient = CreateMockMessageTemplateClient(200, GetTemplatesApiResponsePayload);
            var channelId = Guid.NewGuid().ToString();

            //act
            AsyncPageable<MessageTemplateItem> templates = messageTemplateClient.GetTemplatesAsync(channelId);

            //assert
            await foreach (MessageTemplateItem template in templates)
            {
                Assert.IsNotNull(template.Name);
                Assert.IsNotNull(template.Language);
                Assert.IsNotNull(template.Status);
                Assert.AreEqual(template.ChannelType, CommunicationMessagesChannelType.WhatsApp);
            }
        }

        [Test]
        public void GetTemplates_NullChannelId_Throws()
        {
            //arrange
            MessageTemplateClient messageTemplateClient = CreateMockMessageTemplateClient();

            //act & assert
            Assert.Throws<ArgumentNullException>(() => messageTemplateClient.GetTemplatesAsync(null));
        }

        [Test]
        public Task GetTemplates_InvalidChannelRegistrationId_ThrowsBadRequestException()
        {
            //arrange
            MessageTemplateClient messageTemplateClient = CreateMockMessageTemplateClient(400);

            try
            {
                //act
                messageTemplateClient.GetTemplatesAsync("invalidChannelRegistrationId");
            }
            catch (RequestFailedException requestFailedException)
            {
                //assert
                Assert.AreEqual(400, requestFailedException.Status);
            }

            return Task.CompletedTask;
        }

        private MessageTemplateClient CreateMockMessageTemplateClient(int responseCode = 200, string responseContent = null)
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
