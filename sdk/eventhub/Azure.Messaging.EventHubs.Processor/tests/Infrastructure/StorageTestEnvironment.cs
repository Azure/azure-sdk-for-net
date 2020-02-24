// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Processor.Tests
{
    /// <summary>
    ///   Represents the ambient environment for Azure storage resource in which the test suite is
    ///   being run, offering access to information such as environment variables.
    /// </summary>
    ///
    public static class StorageTestEnvironment
    {
        /// <summary>The active Azure storage connection for this test run, lazily created.</summary>
        private static readonly Lazy<StorageScope.StorageProperties> ActiveStorageAccount =
            new Lazy<StorageScope.StorageProperties>(EnsureStorageAccount, LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>The environment variable value for the storage account connection string, lazily evaluated.</summary>
        private static readonly Lazy<string> ActiveStorageAccountConnectionString =
            new Lazy<string>(() => ReadEnvironmentVariable("EVENT_HUBS_OVERRIDE_BLOBS_CONNECTION_STRING"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        ///   Indicates whether or not an ephemeral storage account was created for the current test execution.
        /// </summary>
        ///
        /// <value><c>true</c> if an Azure storage account was created; otherwise, <c>false</c>.</value>
        ///
        public static bool WasStorageAccountCreated => ActiveStorageAccount.IsValueCreated && ActiveStorageAccount.Value.WasStorageAccountCreated;

        /// <summary>
        ///   The name of the Azure storage account to be used for Live tests.
        /// </summary>
        ///
        /// <value>The name will be determined by creating an ephemeral Azure storage account for the test execution.</value>
        ///
        public static string StorageAccountName => ActiveStorageAccount.Value.Name;

        /// <summary>
        ///   The connection string for the Azure storage instance to be used for Live tests.
        /// </summary>
        ///
        /// <value>The connection string will be determined by creating an ephemeral Azure storage account for the test execution.</value>
        ///
        public static string StorageConnectionString => ActiveStorageAccount.Value.ConnectionString;

        /// <summary>
        ///   It tries to read the <see cref="ActiveStorageAccountConnectionString" />.
        ///   If not found, it creates a new storage account on Azure.
        /// </summary>
        ///
        /// <returns>The active Azure storage account for this test run.</returns>
        ///
        private static StorageScope.StorageProperties EnsureStorageAccount()
        {
            if (!string.IsNullOrEmpty(ActiveStorageAccountConnectionString.Value))
            {
                return StorageScope.PopulateStoragePropertiesFromConnectionString(ActiveStorageAccountConnectionString.Value);
            }

            return CreateStorageAccount();
        }

        /// <summary>
        ///   Reads an environment variable.
        /// </summary>
        ///
        /// <param name="variableName">The name of the environment variable to read.</param>
        ///
        /// <returns>The value of the environment variable, if present and populated; null otherwise</returns>
        ///
        private static string ReadEnvironmentVariable(string variableName) =>
            Environment.GetEnvironmentVariable(variableName);

        /// <summary>
        ///   Requests creation of an Azure storage account to use for a specific test run,
        ///   transforming the asynchronous request into a synchronous one that can be used with
        ///   lazy instantiation.
        /// </summary>
        ///
        /// <returns>The active Azure storage account for this test run.</returns>
        ///
        private static StorageScope.StorageProperties CreateStorageAccount() =>
            Task
                .Run(async () => await StorageScope.CreateStorageAccountAsync().ConfigureAwait(false))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
    }
}
