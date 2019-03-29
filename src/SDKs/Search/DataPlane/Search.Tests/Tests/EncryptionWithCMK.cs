using Microsoft.Azure.Search.Tests.Utilities;
using Search.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Search.Tests.Tests
{
    public sealed class EncryptionWithCMKTests : SearchTestBase<EncryptionFixture>
    {
        [Fact]
        public void CreateIndexWithCMK()
        {
            Run(() =>
            {
                string test = "";
                Assert.Equal(0, test.Length); ;
            });
        }
    }
}
