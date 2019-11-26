// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using Core;
    using Xunit;

    public class MessageSenderTests
    {
        private MessageSender viaSender;
        private MessageSender nonViaSender;

        public MessageSenderTests()
        {
            var builder = new ServiceBusConnectionStringBuilder("blah.com", "path", "key-name", "key-value");
            var connection = new ServiceBusConnection(builder);
            viaSender = new MessageSender(connection, "path", "via");
            nonViaSender = new MessageSender(connection, "path");
        }

        [Fact]
        [DisplayTestMethodName]
        public void Path_reflects_actual_link_destination()
        {
            Assert.Equal("via", viaSender.Path);
            Assert.Equal("path", nonViaSender.Path);
        }

        [Fact]
        [DisplayTestMethodName]
        public void TransferDestinationPath_should_be_final_destination_name()
        {
            Assert.Equal("path", viaSender.TransferDestinationPath);
            Assert.Null(nonViaSender.TransferDestinationPath);
        }

        [Fact]
        [DisplayTestMethodName]
        public void ViaEntityPath_should_be_via_entity_name()
        {
            Assert.Equal("via", viaSender.ViaEntityPath);
            Assert.Null(nonViaSender.ViaEntityPath);
        }
    }
}
