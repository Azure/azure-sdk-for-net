// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

#if false // $$$
namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class DefaultStorageCredentialsValidator : IStorageCredentialsValidator
    {
        public async Task ValidateCredentialsAsync(IStorageAccount account, CancellationToken cancellationToken)
        {
            if (account == null)
            {
                throw new ArgumentNullException("account");
            }

            await ValidateCredentialsAsyncCore(account, cancellationToken);
        }

        // Test that the credentials are valid and classify the account.Type as one of StorageAccountTypes
        private static async Task ValidateCredentialsAsyncCore(IStorageAccount account, CancellationToken cancellationToken)
        {
            // Verify the credentials are correct.
            // Have to actually ping a storage operation.
            IStorageBlobClient client = account.CreateBlobClient();

            try
            {
                // This can hang for a long time if the account name is wrong. 
                // If will fail fast if the password is incorrect.
                await client.GetServicePropertiesAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                var storageException = e as StorageException;
                var isDevStoreAccount = GetIsDevStoreAccountFromCloudStorageAccount(account.SdkObject);

                if (storageException?.RequestInformation?.HttpStatusCode == 400 &&
                    storageException?.RequestInformation?.ExtendedErrorInformation?.ErrorCode == "InvalidQueryParameterValue")
                {
                    // Premium storage accounts do not support the GetServicePropertiesAsync call, and respond with a 400 'InvalidQueryParameterValue'.
                    // If we see this error response classify the account as a premium account
                    account.Type = StorageAccountType.Premium;
                    return;
                }
                else if (isDevStoreAccount)
                {
                    // If using the storage emulator, it might not be running
                    throw new InvalidOperationException(Constants.CheckAzureStorageEmulatorMessage, e);
                }
                else
                {
                    // If not a recognized error, the credentials are invalid
                    string message = String.Format(CultureInfo.CurrentCulture,
                        "Invalid storage account '{0}'. Please make sure your credentials are correct.",
                        account.Credentials.AccountName);
                    throw new InvalidOperationException(message, e);
                }
            }

            IStorageQueueClient queueClient = account.CreateQueueClient();
            IStorageQueue queue = queueClient.GetQueueReference("name");
            try
            {
                await queue.ExistsAsync(cancellationToken);
            }
            catch (StorageException exception) when (IsBlobOnlyStorageException(exception))
            {
                account.Type = StorageAccountType.BlobOnly;
            }
        }

        private static bool IsBlobOnlyStorageException(StorageException storageException)
        {
            const int errorWinhttpNameNotResolved = 0x2ee7;

            switch (storageException.InnerException)
            {
                // Inner exception when using WindowsAzure.Storage for net45
                case WebException webException:
                    return webException.Status == WebExceptionStatus.NameResolutionFailure;
                // Inner exception when using WindowsAzure.Storage for netstandard1.3 as WebException does not exist
                case System.Net.Http.HttpRequestException httpRequestException:
                    return (httpRequestException.HResult & 0xFFFF) == errorWinhttpNameNotResolved;
                default:
                    return false;
            }
        }

        internal static bool GetIsDevStoreAccountFromCloudStorageAccount(CloudStorageAccount account)
        {
            var isDevStoreAccountProperty = typeof(CloudStorageAccount).GetProperty("IsDevStoreAccount", BindingFlags.NonPublic | BindingFlags.Instance);
            if (isDevStoreAccountProperty == null)
            {
                throw new InvalidOperationException("Reflection call to obtain CloudStorageAccount.IsDevStoreAccount property info failed. Did a storage package update occur?");
            }

            var isDevStoreAccount = isDevStoreAccountProperty.GetValue(account);
            if (isDevStoreAccount == null)
            {
                throw new InvalidOperationException("Reflection call to obtain value of CloudStorageAccount.IsDevStoreAccount failed. Did a storage package update occur?");
            }

            return (bool)isDevStoreAccount;
        }
    }
}


#endif