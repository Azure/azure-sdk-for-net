// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.CheckpointStore.Blobs.Tests.Infrastructure;

namespace Azure.Messaging.EventHubs.CheckpointStore.Blobs.Tests
{
    /// <summary>
    ///   Represents the ambient environment for Azure storage resource in which the test suite is
    ///   being run, offering access to information such as environment variables.
    /// </summary>
    ///
    public static class StorageTestEnvironment
    {
        /// <summary>The active Azure storage connection for this test run, lazily created.</summary>
        private static readonly Lazy<StorageScope.StorageProperties> s_activeStorageAccount =
            new Lazy<StorageScope.StorageProperties>(CreateStorageAccount, LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>
        ///   Indicates whether or not an ephemeral storage account was created for the current test execution.
        /// </summary>
        ///
        /// <value><c>true</c> if an Azure storage account was created; otherwise, <c>false</c>.</value>
        ///
        public static bool WasStorageAccountCreated => s_activeStorageAccount.IsValueCreated;

        /// <summary>
        ///   The name of the Azure storage account to be used for Live tests.
        /// </summary>
        ///
        /// <value>The name will be determined by creating an ephemeral Azure storage account for the test execution.</value>
        ///
        public static string StorageAccountName => s_activeStorageAccount.Value.Name;

        /// <summary>
        ///   The connection string for the Azure storage instance to be used for Live tests.
        /// </summary>
        ///
        /// <value>The connection string will be determined by creating an ephemeral Azure storage account for the test execution.</value>
        ///
        public static string StorageConnectionString => s_activeStorageAccount.Value.ConnectionString;

        /// <summary>
        ///   Requests creation of an Azure storage account to use for a specific test run,
        ///   transforming the asynchronous request into a synchronous one that can be used with
        ///   lazy instantiation.
        /// </summary>
        ///
        /// <returns>The active Azure storage account for this test run./returns>
        ///
        private static StorageScope.StorageProperties CreateStorageAccount() =>
            Task
                .Run(async () => await StorageScope.CreateStorageAccountAsync().ConfigureAwait(false))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
    }
}
