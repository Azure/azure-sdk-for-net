// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.ServiceBus.Triggers;
using Microsoft.Azure.ServiceBus;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class MessageToByteArrayConverterTests
    {
        private const string TestString = "This is a test!";

        [Test]
        [TestCase(ContentTypes.TextPlain)]
        [TestCase(ContentTypes.ApplicationJson)]
        [TestCase(ContentTypes.ApplicationOctetStream)]
        [TestCase("some-other-contenttype")]
        [TestCase(null)]
        public async Task ConvertAsync_ReturnsExpectedResults(string contentType)
        {
            Message message = new Message(Encoding.UTF8.GetBytes(TestString));
            message.ContentType = contentType;
            MessageToByteArrayConverter converter = new MessageToByteArrayConverter();

            byte[] result = await converter.ConvertAsync(message, CancellationToken.None);
            string decoded = Encoding.UTF8.GetString(result);
            Assert.AreEqual(TestString, decoded);
        }
    }
}
