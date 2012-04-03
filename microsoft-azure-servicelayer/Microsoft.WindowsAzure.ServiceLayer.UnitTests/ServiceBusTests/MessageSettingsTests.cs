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
        public void InvalidArgumentsInMethods()
        {
            Assert.Throws<ArgumentNullException>(() => new BrokeredMessageSettings(null));
            Assert.Throws<ArgumentNullException>(() => BrokeredMessageSettings.CreateFromText(null));
            Assert.Throws<ArgumentNullException>(() => BrokeredMessageSettings.CreateFromText("Test", null));
            Assert.Throws<ArgumentException>(() => BrokeredMessageSettings.CreateFromText("Test", ""));
            Assert.Throws<ArgumentException>(() => BrokeredMessageSettings.CreateFromText("Test", " "));
            Assert.Throws<ArgumentNullException>(() => BrokeredMessageSettings.CreateFromByteArray(null));
            Assert.Throws<ArgumentNullException>(() => BrokeredMessageSettings.CreateFromStream(null));
        }
    }
}
