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
            var channelRegistrationId = new Guid(TestEnvironment.SenderChannelRegistrationId);

            // Act
            AsyncPageable<MessageTemplateItem> templates = messageTemplateClient.GetTemplatesAsync(channelRegistrationId);

            // Assert
            Assert.That(templates, Is.Not.Null);
            List<MessageTemplateItem> templatesEnumerable = templates.ToEnumerableAsync().Result;
            Assert.That(templatesEnumerable, Is.Not.Empty);
            foreach (WhatsAppMessageTemplateItem template in templatesEnumerable.Cast<WhatsAppMessageTemplateItem>())
            {
                Assert.That(template.Name, Is.Not.Null);
                Assert.That(template.Language, Is.Not.Null);
                Assert.That(template.Content, Is.Not.Null);
            }

            return Task.CompletedTask;
        }

        [Test]
        public Task GetTemplatesWithAzureKeyCredentialShouldSucceed()
        {
            // Arrange
            MessageTemplateClient messageTemplateClient = CreateInstrumentedMessageTemplateClientWithAzureKeyCredential();
            var channelRegistrationId = new Guid(TestEnvironment.SenderChannelRegistrationId);

            // Act
            AsyncPageable<MessageTemplateItem> templates = messageTemplateClient.GetTemplatesAsync(channelRegistrationId);

            // Assert
            Assert.That(templates, Is.Not.Null);
            List<MessageTemplateItem> templatesEnumerable = templates.ToEnumerableAsync().Result;
            Assert.That(templatesEnumerable, Is.Not.Empty);
            foreach (WhatsAppMessageTemplateItem template in templatesEnumerable.Cast<WhatsAppMessageTemplateItem>())
            {
                Assert.That(template.Name, Is.Not.Null);
                Assert.That(template.Language, Is.Not.Null);
                Assert.That(template.Content, Is.Not.Null);
            }

            return Task.CompletedTask;
        }
    }
}
