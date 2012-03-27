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
    /// Unit tests for the HttpResponse class.
    /// </summary>
    public class HttpResponseTests
    {
        /// <summary>
        /// Tests passing invalid arguments to the constructor.
        /// </summary>
        [Fact]
        public void InvalidArgsInConstructor()
        {
            HttpRequest validRequest = new HttpRequest("PUT", new Uri("http://microsoft.com"));
            Assert.Throws<ArgumentNullException>(() => new HttpResponse(null, 200));
        }
    }
}
