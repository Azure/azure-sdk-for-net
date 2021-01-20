// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.ServiceBus.Triggers;
using Microsoft.Azure.ServiceBus;
using Xunit;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class MessageToByteArrayConverterTests
    {
        private const string TestString = "This is a test!";

        [Theory]
        [InlineData(ContentTypes.TextPlain)]
        [InlineData(ContentTypes.ApplicationJson)]
        [InlineData(ContentTypes.ApplicationOctetStream)]
        [InlineData("some-other-contenttype")]
        [InlineData(null)]
        public async Task ConvertAsync_ReturnsExpectedResults(string contentType)
        {
            Message message = new Message(Encoding.UTF8.GetBytes(TestString));
            message.ContentType = contentType;
            MessageToByteArrayConverter converter = new MessageToByteArrayConverter();

            byte[] result = await converter.ConvertAsync(message, CancellationToken.None);
            string decoded = Encoding.UTF8.GetString(result);
            Assert.Equal(TestString, decoded);
        }
    }
}
