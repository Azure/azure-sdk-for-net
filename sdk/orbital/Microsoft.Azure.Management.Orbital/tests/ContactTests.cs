using Microsoft.Azure.Management.Orbital.Models;
using Microsoft.Azure.Management.Orbital.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net;
using Xunit;

namespace Microsoft.Azure.Management.Orbital.Tests.Tests
{
    public class ContactTests  : TestBase
    {

        [Fact]
        public void ContactApiTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
            }
        }
    }
}