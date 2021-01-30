// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Messaging.EventHubs.Processor.Tests
{
    /// <summary>
    ///   Represents the ambient environment for Azure storage resource in which the test suite is
    ///   being run, offering access to information such as environment variables.
    /// </summary>
    ///
    public class StorageTestEnvironment: TestEnvironment
    {
        /// <summary>The singleton instance of the <see cref="StorageTestEnvironment" />, lazily created.</summary>
        private static readonly Lazy<StorageTestEnvironment> Singleton = new Lazy<StorageTestEnvironment>(() => new StorageTestEnvironment(), LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>The active Azure storage connection for this test run, lazily created.</summary>
        private readonly Lazy<StorageProperties> ActiveStorageAccount;

        /// <summary>
        ///   The shared instance of the <see cref="StorageTestEnvironment"/> to be used during test runs.
        /// </summary>
        ///
        public static StorageTestEnvironment Instance => Singleton.Value;

        /// <summary>The environment variable value for the storage account connection string, lazily evaluated.</summary>
        private string StorageAccountConnectionString => GetOptionalVariable("EVENTHUB_PROCESSOR_STORAGE_CONNECTION_STRING");

        /// <summary>
        ///   The storage account endpoint suffix of the cloud to use during Live tests.
        /// </summary>
        public new string StorageEndpointSuffix => base.StorageEndpointSuffix ?? "core.windows.net";

        /// <summary>
        ///   Indicates whether or not an ephemeral storage account was created for the current test execution.
        /// </summary>
        ///
        /// <value><c>true</c> if an Azure storage account was created; otherwise, <c>false</c>.</value>
        ///
        public bool ShouldRemoveStorageAccountAfterTestRunCompletion => (ActiveStorageAccount.IsValueCreated && ActiveStorageAccount.Value.ShouldRemoveAtCompletion);

        /// <summary>
        ///   The name of the Azure storage account to be used for Live tests.
        /// </summary>
        ///
        /// <value>The name will be determined by creating an ephemeral Azure storage account for the test execution.</value>
        ///
        public string StorageAccountName => ActiveStorageAccount.Value.Name;

        /// <summary>
        ///   The connection string for the Azure storage instance to be used for Live tests.
        /// </summary>
        ///
        /// <value>The connection string will be determined by creating an ephemeral Azure storage account for the test execution.</value>
        ///
        public string StorageConnectionString => ActiveStorageAccount.Value.ConnectionString;

        /// <summary>
        ///   Initializes a new instance of the <see cref="StorageTestEnvironment"/> class.
        /// </summary>
        ///
        public StorageTestEnvironment()
        {
            ActiveStorageAccount = new Lazy<StorageProperties>(EnsureStorageAccount, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        /// <summary>
        ///   It tries to read the <see cref="StorageAccountConnectionString" />.
        ///   If not found, it creates a new storage account on Azure.
        /// </summary>
        ///
        /// <returns>The active Azure storage account for this test run.</returns>
        ///
        private StorageProperties EnsureStorageAccount()
        {
            if (!string.IsNullOrEmpty(StorageAccountConnectionString))
            {
                var connectionString = StorageAccountConnectionString;
                var nameStart = (connectionString.IndexOf('=', connectionString.IndexOf("AccountName")) + 1);
                var nameLength = (connectionString.IndexOf(';', nameStart) - nameStart);

                return new StorageProperties(connectionString.Substring(nameStart, nameLength), connectionString, shouldRemoveAtCompletion: false);
            }

            return Task
                .Run(async () => await StorageScope.CreateStorageAccountAsync().ConfigureAwait(false))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }

        /// <summary>
        ///   The key attributes for identifying and accessing a dynamically created Azure storage account,
        ///   intended to serve as an ephemeral container for the checkpoints created during a test run.
        /// </summary>
        ///
        public struct StorageProperties
        {
            /// <summary>The name of the Azure storage account to be used for the test run.</summary>
            public readonly string Name;

            /// <summary>The connection string to use for accessing the Azure storage account.</summary>
            public readonly string ConnectionString;

            /// <summary>Flags whether the storage account was created for the current test run or was retrieved from environment variables.</summary>
            public readonly bool ShouldRemoveAtCompletion;

            /// <summary>
            ///   Initializes a new instance of the <see cref="StorageProperties"/> struct.
            /// </summary>
            ///
            /// <param name="name">The name of the storage account.</param>
            /// <param name="connectionString">The connection string to use for accessing the Azure storage account.</param>
            /// <param name="shouldRemoveAtCompletion">Sets whether the storage account was created or read from environment variables.</param>
            ///
            internal StorageProperties(string name,
                                       string connectionString,
                                       bool shouldRemoveAtCompletion)
            {
                Name = name;
                ConnectionString = connectionString;
                ShouldRemoveAtCompletion = shouldRemoveAtCompletion;
            }
        }
    }
}
