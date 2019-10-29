using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    public class UriHelperTests
    {
        [Fact]
        public void GetAzureAdInstanceValidAuthorityTest()
        {
            Assert.Equal("https://login.microsoftonline.com/",
                UriHelper.GetAzureAdInstanceByAuthority("https://login.microsoftonline.com/abc"));
            Assert.Equal("https://login.microsoftonline.us/",
                UriHelper.GetAzureAdInstanceByAuthority("https://login.microsoftonline.us/abc/"));
        }

        [Fact]
        public void GetAzureAdInstanceInvalidAuthorityTest()
        {
            Assert.Null(UriHelper.GetAzureAdInstanceByAuthority("http://login.microsoftonline.com/abc"));
            Assert.Null(UriHelper.GetAzureAdInstanceByAuthority("https://login.microsoftonline.com/"));
            Assert.Null(UriHelper.GetAzureAdInstanceByAuthority("login.microsoftonline.com"));
        }

        [Fact]
        public void GetAzureAdInstanceNullAuthorityTest()
        {
            Assert.Null(UriHelper.GetAzureAdInstanceByAuthority(" "));
            Assert.Null(UriHelper.GetAzureAdInstanceByAuthority(string.Empty));
            Assert.Null(UriHelper.GetAzureAdInstanceByAuthority(null));
        }

        [Fact]
        public void GetTenantValidAuthorityTest()
        {
            Assert.Equal("abc", UriHelper.GetTenantByAuthority("https://login.microsoftonline.com/abc"));
            Assert.Equal("abc", UriHelper.GetTenantByAuthority("https://login.microsoftonline.com/abc/"));
            Assert.Equal("abc", UriHelper.GetTenantByAuthority("https://login.microsoftonline.com/abc/def"));
        }

        [Fact]
        public void GetTenantInvalidAuthorityTest()
        {
            Assert.Null(UriHelper.GetTenantByAuthority("https://login.microsoftonline.com/"));
            Assert.Null(UriHelper.GetTenantByAuthority("login.microsoftonline.com"));
        }

        [Fact]
        public void GetTenantNullAuthorityTest()
        {
            Assert.Null(UriHelper.GetTenantByAuthority(" "));
            Assert.Null(UriHelper.GetTenantByAuthority(string.Empty));
            Assert.Null(UriHelper.GetTenantByAuthority(null));
        }
    }
}
