using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests
{
    internal static class StorageConfiguration
    {
        private const string AccountNameEnvironmentVariable = "MABFC_StorageAccount";
        private const string AccountKeyEnvironmentVariable = "MABFC_StorageKey";

        internal static CloudStorageAccount GetAccount(ITestOutputHelper output)
        {
            var accountName = Environment.GetEnvironmentVariable(AccountNameEnvironmentVariable);
            var accountKey = Environment.GetEnvironmentVariable(AccountKeyEnvironmentVariable);

            var unset = new List<string>();

            if (String.IsNullOrEmpty(accountName))
            {
                unset.Add(AccountNameEnvironmentVariable);
            }

            if (String.IsNullOrEmpty(accountKey))
            {
                unset.Add(AccountKeyEnvironmentVariable);
            }

            if (unset.Any())
            {
                var error = $"Storage account not configured for integration tests: environment variable(s) {string.Join(" and ", unset)} not set.";
                output?.WriteLine(error);
                throw new InvalidOperationException(error);
            }

            try
            {
                var credentials = new StorageCredentials(accountName, accountKey);
                var account = new CloudStorageAccount(credentials, true);
                return account;
            }
            catch (Exception ex)
            {
                var error = $"Storage account incorrectly configured for integration tests: error creating account object '{ex.Message}'.";
                output?.WriteLine(error);
                throw new InvalidOperationException(error, ex);
            }
        }
    }
}
