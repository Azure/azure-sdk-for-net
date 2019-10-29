// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.Primitives
{
    using Xunit;

    public class EntityNameHelperTests
    {
        [Fact]
        public void TransferDeadLetterQueueName_is_formatted_correctly()
        {
            var result = EntityNameHelper.Format​Transfer​Dead​Letter​Path("queue");
            Assert.Equal("queue/$Transfer/$DeadLetterQueue", result);
        }

        [Fact]
        public void DeadLetterQueueName_is_formatted_correctly()
        {
            var result = EntityNameHelper.FormatDeadLetterPath("queue");
            Assert.Equal("queue/$DeadLetterQueue", result);
        }

        [Fact]
        public void FormatSubscriptionPath_is_formatted_correctly()
        {
            var result = EntityNameHelper.FormatSubscriptionPath("topic", "sub");
            Assert.Equal("topic/Subscriptions/sub", result);
        }

        [Fact]
        public void FormatSubQueuePath_is_formatted_correctly()
        {
            var result = EntityNameHelper.FormatSubQueuePath("entityPath", "subQueue");
            Assert.Equal("entityPath/subQueue", result);
        }
    }
}