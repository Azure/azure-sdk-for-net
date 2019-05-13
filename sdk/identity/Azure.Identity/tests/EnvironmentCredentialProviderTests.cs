using Azure.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace Azure.Identity.Tests
{
    public static class TestAccessibilityExtensions
    {
        public static TokenCredential _credential(this EnvironmentCredentialProvider provider)
        {
            return (TokenCredential)typeof(EnvironmentCredentialProvider).GetField("_credential", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(provider);
        }
    }

    public class EnvironmentCredentialProviderTests
    {
        [Fact]
        public void CredentialConstruction()
        {
            Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", "mockclientid");

            Environment.SetEnvironmentVariable("AZURE_TENANT_ID", "mocktenantid");

            Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", "mockclientsecret");

            var provider = new EnvironmentCredentialProvider();

            ClientSecretCredential cred = provider._credential() as ClientSecretCredential;

            Assert.NotNull(cred);

            Assert.Equal("mockclientid", cred.ClientId);

            Assert.Equal("mocktenantid", cred.TenantId);

            Assert.Equal("mockclientsecret", cred.ClientSecret);
        }
    }
}
