using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    public class UriHelperTests
    {
        [Fact]
        public void ValidAuthorityTest()
        {
           Assert.Equal("abc", UriHelper.GetTenantByAuthority("https://login.microsoftonline.com/abc"));
           Assert.Equal("abc", UriHelper.GetTenantByAuthority("https://login.microsoftonline.com/abc/"));
           Assert.Equal("abc", UriHelper.GetTenantByAuthority("https://login.microsoftonline.com/abc/def"));
        }

        [Fact]
        public void InvalidAuthorityTest()
        {
            Assert.Equal(null, UriHelper.GetTenantByAuthority("https://login.microsoftonline.com/"));
            Assert.Equal(null, UriHelper.GetTenantByAuthority("login.microsoftonline.com"));
        }

        [Fact]
        public void NullAuthorityTest()
        {
            Assert.Equal(null, UriHelper.GetTenantByAuthority(string.Empty));
            Assert.Equal(null, UriHelper.GetTenantByAuthority(null));
        }
    }
}
