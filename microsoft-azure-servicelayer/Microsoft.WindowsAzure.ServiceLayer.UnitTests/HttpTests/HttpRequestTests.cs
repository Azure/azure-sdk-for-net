using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceLayer.Http;
using Xunit;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.HttpTests
{
    /// <summary>
    /// Unit tests for the HttpRequest class.
    /// </summary>
    public class HttpRequestTests
    {
        /// <summary>
        /// Tests passing invalid arguments in the constructor.
        /// </summary>
        [Fact]
        public void InvalidArgsInConstructor()
        {
            Uri validUri = new Uri("http://microsoft.com");
            Assert.Throws<ArgumentNullException>(() => new HttpRequest(null, validUri));
            Assert.Throws<ArgumentNullException>(() => new HttpRequest("PUT", null));
        }
    }
}
