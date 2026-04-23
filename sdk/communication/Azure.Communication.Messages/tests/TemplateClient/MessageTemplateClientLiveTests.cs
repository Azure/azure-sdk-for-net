// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.Messages.Models.Channels;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Legacy;

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
            ClassicAssert.IsNotNull(templates);
            List<MessageTemplateItem> templatesEnumerable = templates.ToEnumerableAsync().Result;
            ClassicAssert.IsNotEmpty(templatesEnumerable);
            foreach (WhatsAppMessageTemplateItem template in templatesEnumerable.Cast<WhatsAppMessageTemplateItem>())
            {
                ClassicAssert.IsNotNull(template.Name);
                ClassicAssert.IsNotNull(template.Language);
                ClassicAssert.IsNotNull(template.Content);
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
            ClassicAssert.IsNotNull(templates);
            List<MessageTemplateItem> templatesEnumerable = templates.ToEnumerableAsync().Result;
            ClassicAssert.IsNotEmpty(templatesEnumerable);
            foreach (WhatsAppMessageTemplateItem template in templatesEnumerable.Cast<WhatsAppMessageTemplateItem>())
            {
                ClassicAssert.IsNotNull(template.Name);
                ClassicAssert.IsNotNull(template.Language);
                ClassicAssert.IsNotNull(template.Content);
            }

            return Task.CompletedTask;
        }
    }
}
