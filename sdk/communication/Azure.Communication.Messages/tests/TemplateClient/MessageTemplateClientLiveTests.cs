// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            AsyncPageable<MessageTemplateItem> templates = messageTemplateClient.GetTemplatesAsync(channelRegistrationId);

            // Assert
            Assert.IsNotNull(templates);
            var templatesEnumerable = templates.ToEnumerableAsync().Result;
            Assert.IsNotEmpty(templatesEnumerable);
            foreach (MessageTemplateItem template in templatesEnumerable)
            {
                Assert.IsNotNull(template.Name);
                Assert.IsNotNull(template.Language);
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
            var templatesEnumerable = templates.ToEnumerableAsync().Result;
            Assert.IsNotEmpty(templatesEnumerable);
            foreach (MessageTemplateItem template in templatesEnumerable)
            {
                Assert.IsNotNull(template.Name);
                Assert.IsNotNull(template.Language);
            }

            return Task.CompletedTask;
        }
    }
}
