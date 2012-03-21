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
            Assert.Throws<ArgumentNullException>(() => new BrokeredMessageSettings(null));
        }
    }
}
