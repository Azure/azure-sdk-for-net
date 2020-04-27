// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Azure.ServiceBus.UnitTests.Infrastructure;

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using Core;
    using Xunit;

    public class MessageSenderTests
    {
        private MessageSender _viaSender;
        private MessageSender _nonViaSender;

        public MessageSenderTests()
        {
            var builder = new ServiceBusConnectionStringBuilder("blah.com", "path", "key-name", "key-value");
            var connection = new ServiceBusConnection(builder);
            _viaSender = new MessageSender(connection, "path", "via");
            _nonViaSender = new MessageSender(connection, "path");
        }

        [Fact]
        [DisplayTestMethodName]
        public void Path_reflects_actual_link_destination()
        {
            Assert.Equal("via", _viaSender.Path);
            Assert.Equal("path", _nonViaSender.Path);
        }

        [Fact]
        [DisplayTestMethodName]
        public void TransferDestinationPath_should_be_final_destination_name()
        {
            Assert.Equal("path", _viaSender.TransferDestinationPath);
            Assert.Null(_nonViaSender.TransferDestinationPath);
        }

        [Fact]
        [DisplayTestMethodName]
        public void ViaEntityPath_should_be_via_entity_name()
        {
            Assert.Equal("via", _viaSender.ViaEntityPath);
            Assert.Null(_nonViaSender.ViaEntityPath);
        }
    }
}
