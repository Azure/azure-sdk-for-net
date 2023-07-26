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
        public async Task GetTemplatesShouldSucceed()
        {
            // Arrange
            MessageTemplateClient messageTemplateClient = CreateInstrumentedMessageTemplateClient();
            string channelRegistrationId = TestEnvironment.SenderChannelRegistrationId;

            // Act
            AsyncPageable<MessageTemplateItem> templates = messageTemplateClient.GetTemplatesAsync(channelRegistrationId);

            var geTemplatesCount = templates.ToEnumerableAsync().Result.Count;

            await foreach (MessageTemplateItem template in templates)
            {
                Console.WriteLine($"{template.Name}");
            }

            // Assert
            Assert.IsNotNull(templates);
        }
    }
}
