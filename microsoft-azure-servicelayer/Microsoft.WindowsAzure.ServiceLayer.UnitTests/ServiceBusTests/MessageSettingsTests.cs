using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceLayer.ServiceBus;
using Windows.Storage.Streams;
using Xunit;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.ServiceBusTests
{
    /// <summary>
    /// Unit tests for the BrokeredMessageSettings class.
    /// </summary>
    public sealed class MessageSettingsTests
    {
        /// <summary>
        /// Tests specifying null arguments in constructors.
        /// </summary>
        [Fact]
        public void NullArgumentsInConstructors()
        {
            Assert.Throws<ArgumentNullException>(() => new BrokeredMessageSettings(null, new byte[] { 1 }));
            Assert.Throws<ArgumentNullException>(() => new BrokeredMessageSettings("text/plain", (byte[])null));
            Assert.Throws<ArgumentNullException>(() => new BrokeredMessageSettings(null, "This is a test."));
            Assert.Throws<ArgumentNullException>(() => new BrokeredMessageSettings("text/plain", (string)null));
            using (Stream stream = new MemoryStream())
            {
                Assert.Throws<ArgumentNullException>(() => new BrokeredMessageSettings(null, stream.AsInputStream()));
            }
            Assert.Throws<ArgumentNullException>(() => new BrokeredMessageSettings("text/plain", (IInputStream)null));
        }

        /// <summary>
        /// Tests specifying null arguments in methods of a brokered message.
        /// </summary>
        [Fact]
        public void NullArgumentsInMethods()
        {
            BrokeredMessageSettings message = new BrokeredMessageSettings("text/plain", "This is a test.");
            Assert.Throws<ArgumentNullException>(() => message.CopyContentToAsync(null));
        }

        /// <summary>
        /// Tests reading a message as a string.
        /// </summary>
        [Fact]
        public void ReadAsString()
        {
            string originalBody = "This is only a test!";
            BrokeredMessageSettings message = new BrokeredMessageSettings("text/plain", originalBody);

            // Do it twice to make sure the position in the stream is restored after each read.
            for (int i = 0; i < 2; i++)
            {
                string newBody = message.ReadContentAsStringAsync().AsTask().Result;
                Assert.Equal(originalBody, newBody, StringComparer.Ordinal);
            }
        }

        /// <summary>
        /// Tests reading content of the message into a stream.
        /// </summary>
        [Fact]
        public void ReadIntoStream()
        {
            Byte[] bytes = new byte[] { 1, 2, 3 };
            BrokeredMessageSettings message = new BrokeredMessageSettings("foo", bytes);

            // Do it twice to make sure the position in the stream is restored after each read.
            for (int i = 0; i < 2; i++)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    message.CopyContentToAsync(stream.AsOutputStream()).AsTask().Wait();
                    stream.Flush();
                    stream.Position = 0;

                    BinaryReader reader = new BinaryReader(stream);
                    byte[] readBytes = reader.ReadBytes(bytes.Length + 1);
                    Assert.Equal(bytes, readBytes);
                }
            }
        }
    }
}
