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
        public static TokenCredential _credential(this EnvironmentCredential provider)
        {
            return (TokenCredential)typeof(EnvironmentCredential).GetField("_credential", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(provider);
        }
    }

    [CollectionDefinition("EnvironmentTests", DisableParallelization = true)]
    public class EnvironmentTestsCollection
    {
    }


    [Collection("EnvironmentTests")]
    public class EnvironmentCredentialProviderTests
    {
        [Fact]
        public void CredentialConstruction()
        {
            string clientIdBackup = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
            string tenantIdBackup = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
            string clientSecretBackup = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");

            try
            {
                Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", "mockclientid");

                Environment.SetEnvironmentVariable("AZURE_TENANT_ID", "mocktenantid");

                Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", "mockclientsecret");

                var provider = new EnvironmentCredential();

                ClientSecretCredential cred = provider._credential() as ClientSecretCredential;

                Assert.NotNull(cred);

                Assert.Equal("mockclientid", cred.ClientId);

                Assert.Equal("mocktenantid", cred.TenantId);

                Assert.Equal("mockclientsecret", cred.ClientSecret);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", clientIdBackup);
                Environment.SetEnvironmentVariable("AZURE_TENANT_ID", tenantIdBackup);
                Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", clientSecretBackup);

            }
        }
    }
}
