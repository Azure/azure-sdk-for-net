// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

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
            AsyncPageable<MessageTemplateItem> templates = messageTemplateClient.GetMessageTemplateItemsAsync(channelRegistrationId);

            // Assert
            Assert.IsNotNull(templates);
            System.Collections.Generic.List<MessageTemplateItem> templatesEnumerable = templates.ToEnumerableAsync().Result;
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
            AsyncPageable<MessageTemplateItem> templates = messageTemplateClient.GetMessageTemplateItemsAsync(channelRegistrationId);

            // Assert
            Assert.IsNotNull(templates);
            System.Collections.Generic.List<MessageTemplateItem> templatesEnumerable = templates.ToEnumerableAsync().Result;
            Assert.IsNotEmpty(templatesEnumerable);
            foreach (WhatsAppMessageTemplateItem template in templatesEnumerable.Cast<WhatsAppMessageTemplateItem>())
            {
                Assert.IsNotNull(template.Name);
                Assert.IsNotNull(template.Language);
                Assert.IsNotNull(template.Content);
            }

            return Task.CompletedTask;
        }
    }
}
