// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using Xunit;

    public class BrokeredMessageTests
    {
        public class When_BrokeredMessage_message_id_generator_is_not_specified
        {
            [Fact]
            public void Message_should_have_MessageId_set()
            {
                var message = new BrokeredMessage();

                Assert.Null(message.MessageId);
            }
        }

        public class When_BrokeredMessage_id_generator_throws
        {
            [Fact]
            public void Should_throw_with_original_exception_included()
            {
                var exceptionToThrow = new Exception("boom!");
                Func<string> idGenerator = () =>
                {
                    throw exceptionToThrow;
                };
                BrokeredMessage.SetMessageIdGenerator(idGenerator);

                var exception = Assert.Throws<InvalidOperationException>(() => new BrokeredMessage());
                Assert.Equal(exceptionToThrow, exception.InnerException);

                BrokeredMessage.SetMessageIdGenerator(null);
            }
        }

        public class When_BrokeredMessage_message_id_generator_is_specified
        {
            [Fact]
            public void Message_should_have_MessageId_set()
            {
                var seed = 1;
                BrokeredMessage.SetMessageIdGenerator(() => $"id-{seed++}");

                var message1 = new BrokeredMessage();
                var message2 = new BrokeredMessage();

                Assert.Equal("id-1", message1.MessageId);
                Assert.Equal("id-2", message2.MessageId);

                BrokeredMessage.SetMessageIdGenerator(null);
            }
        }
    }
}