// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    public class CloudStorageAccountTests
    {
        [Fact]
        public async Task CloudStorageAccount_CanCall()
        {
            // Arrange
            CloudStorageAccount realAccount = CloudStorageAccount.DevelopmentStorageAccount;

            StorageAccount account = StorageAccount.New(realAccount, "");

            // Act
            var t = typeof(CloudStorageAccountProgram);
            var result = await FunctionalTest.CallAsync<CloudStorageAccount>(
                account,
                t,
                t.GetMethod(nameof(CloudStorageAccountProgram.BindToCloudStorageAccount)),
                null, // args
                (s) => CloudStorageAccountProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.Same(realAccount, result);
        }

        private class CloudStorageAccountProgram
        {
            public static TaskCompletionSource<CloudStorageAccount> TaskSource { get; set; }

            [NoAutomaticTrigger]
            public static void BindToCloudStorageAccount(CloudStorageAccount account)
            {
                TaskSource.TrySetResult(account);
            }
        }
    }
}
