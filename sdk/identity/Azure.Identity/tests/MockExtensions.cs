using Azure.Core.Testing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Identity.Tests
{
    internal static class MockExtensions
    {
        public static MockResponse WithContent(this MockResponse response, string content)
        {
            response.SetContent(content);

            return response;
        }
    }
}
