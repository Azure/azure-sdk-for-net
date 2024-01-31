// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.Messages.Models.Channels;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.Communication.Messages.Tests
{
    public class MessageTemplateClientLiveTests : MessagesLiveTestBase
    {
        public MessageTemplateClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public Task GetTemplatesShouldSucceed()
        {
            // Arrange
            MessageTemplateClient messageTemplateClient = CreateInstrumentedMessageTemplateClient();
            string channelRegistrationId = TestEnvironment.SenderChannelRegistrationId;

            // Act
            AsyncPageable<MessageTemplateItem> templates = messageTemplateClient.GetTemplatesAsync(channelRegistrationId);

            // Assert
            Assert.IsNotNull(templates);
            List<MessageTemplateItem> templatesEnumerable = templates.ToEnumerableAsync().Result;
            Assert.IsNotEmpty(templatesEnumerable);
            foreach (WhatsAppMessageTemplateItem template in templatesEnumerable.Cast<WhatsAppMessageTemplateItem>())
            {
                Assert.IsNotNull(template.Name);
                Assert.IsNotNull(template.Language);
                Assert.IsNotNull(template.Content);
            }

            return Task.CompletedTask;
        }

        [Test]
        public Task GetTemplatesWithAzureKeyCredentialShouldSucceed()
        {
            // Arrange
            MessageTemplateClient messageTemplateClient = CreateInstrumentedMessageTemplateClientWithAzureKeyCredential();
            string channelRegistrationId = TestEnvironment.SenderChannelRegistrationId;

            // Act
            AsyncPageable<MessageTemplateItem> templates = messageTemplateClient.GetTemplatesAsync(channelRegistrationId);

            // Assert
            Assert.IsNotNull(templates);
            List<MessageTemplateItem> templatesEnumerable = templates.ToEnumerableAsync().Result;
            Assert.IsNotEmpty(templatesEnumerable);
            foreach (WhatsAppMessageTemplateItem template in templatesEnumerable.Cast<WhatsAppMessageTemplateItem>())
            {
                Assert.IsNotNull(template.Name);
                Assert.IsNotNull(template.Language);
                Assert.IsNotNull(template.Content);
            }

            return Task.CompletedTask;
        }

        [Test]
        public void Constructor_NullEndpoint_ShouldThrowArgumentNullException()
        {
            // Arrange
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.LiveTestDynamicAccessKey);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new MessageTemplateClient(endpoint, credential));
        }

        [Test]
        public void Constructor_InvalidConnectionString_ShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() => new MessageTemplateClient(null));
            Assert.Throws<ArgumentException>(() => new MessageTemplateClient(string.Empty));
            Assert.Throws<InvalidOperationException>(() => new MessageTemplateClient(""));
            Assert.Throws<InvalidOperationException>(() => new MessageTemplateClient("  "));
            Assert.Throws<InvalidOperationException>(() => new MessageTemplateClient("test"));
        }

        [Test]
        public void GetTemplates_NullOrEmptyChannelId_ShouldThrowArgumentNullException()
        {
            // Arrange
            MessageTemplateClient messageTemplateClient = CreateInstrumentedMessageTemplateClient();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => messageTemplateClient.GetTemplatesAsync(null));
            Assert.Throws<ArgumentNullException>(() => messageTemplateClient.GetTemplatesAsync(string.Empty));
            Assert.Throws<ArgumentNullException>(() => messageTemplateClient.GetTemplatesAsync(""));
            Assert.Throws<ArgumentNullException>(() => messageTemplateClient.GetTemplatesAsync("  "));
            Assert.Throws<ArgumentNullException>(() => messageTemplateClient.GetTemplatesAsync("test"));
        }

        [Test]
        public Task GetTemplates_InvalidChannelId_ShouldThrowBadRequestException()
        {
            //arrange
            MessageTemplateClient messageTemplateClient = CreateInstrumentedMessageTemplateClient();

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
    }
}
