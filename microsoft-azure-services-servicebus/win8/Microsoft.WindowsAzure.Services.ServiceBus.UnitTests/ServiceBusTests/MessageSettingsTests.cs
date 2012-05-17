using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Services.ServiceBus;
using Windows.Storage.Streams;

namespace Microsoft.WindowsAzure.Services.ServiceBus.UnitTests.ServiceBusTests
{
    /// <summary>
    /// Unit tests for the BrokeredMessageSettings class.
    /// </summary>
    [TestClass]
    public sealed class MessageSettingsTests
    {
        /// <summary>
        /// Tests specifying null arguments in constructors.
        /// </summary>
        [TestMethod]
        public void InvalidArgumentsInMethods()
        {
            Assert.ThrowsException<ArgumentNullException>(() => BrokeredMessageSettings.CreateFromHttpContent(null));
            Assert.ThrowsException<ArgumentNullException>(() => BrokeredMessageSettings.CreateFromText(null));
            Assert.ThrowsException<ArgumentNullException>(() => BrokeredMessageSettings.CreateFromText(null, "Test"));
            Assert.ThrowsException<ArgumentNullException>(() => BrokeredMessageSettings.CreateFromText("Test", null));
            Assert.ThrowsException<ArgumentException>(() => BrokeredMessageSettings.CreateFromText("Test", ""));
            Assert.ThrowsException<ArgumentException>(() => BrokeredMessageSettings.CreateFromText("Test", " "));
            Assert.ThrowsException<ArgumentNullException>(() => BrokeredMessageSettings.CreateFromByteArray(null));
            Assert.ThrowsException<ArgumentNullException>(() => BrokeredMessageSettings.CreateFromStream(null));
        }
    }
}
