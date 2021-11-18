// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.TestFramework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   Represents the ambient environment for Azure storage resource in which the test suite is
    ///   being run, offering access to information such as environment variables.
    /// </summary>
    ///
    public class StorageTestEnvironment : TestEnvironment
    {
        /// <summary>The environment variable name of the storage account connection string.</summary>
        private const string StorageAccountConnectionStringEnvironmentVariable = "EVENTHUB_PROCESSOR_STORAGE_CONNECTION_STRING";

        /// <summary>The singleton instance of the <see cref="StorageTestEnvironment" />, lazily created.</summary>
        private static readonly Lazy<StorageTestEnvironment> Singleton = new Lazy<StorageTestEnvironment>(() => new StorageTestEnvironment(), LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>The active Azure storage connection for this test run, lazily created.</summary>
        private readonly Lazy<StorageProperties> ActiveStorageAccount;

        /// <summary>
        ///   The shared instance of the <see cref="StorageTestEnvironment"/> to be used during test runs.
        /// </summary>
        ///
        public static StorageTestEnvironment Instance => Singleton.Value;

        /// <summary>
        ///   The storage account endpoint suffix of the cloud to use during Live tests.
        /// </summary>
        ///
        public new string StorageEndpointSuffix => base.StorageEndpointSuffix ?? "core.windows.net";

        /// <summary>
        ///   The name of the Azure storage account to be used for Live tests.
        /// </summary>
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
        ///   Ensures that the storage account is available and captures its properties.
        /// </summary>
        ///
        /// <returns>The active Azure storage account for this test run.</returns>
        ///
        private StorageProperties EnsureStorageAccount()
        {
            // The call to "GetVariable" will validate the environment variable and bootstrap
            // test resource creation if needed.

            var connectionString = GetVariable(StorageAccountConnectionStringEnvironmentVariable);
            var nameStart = (connectionString.IndexOf('=', connectionString.IndexOf("AccountName")) + 1);
            var nameLength = (connectionString.IndexOf(';', nameStart) - nameStart);

            return new StorageProperties(connectionString.Substring(nameStart, nameLength), connectionString);
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

            /// <summary>
            ///   Initializes a new instance of the <see cref="StorageProperties"/> struct.
            /// </summary>
            ///
            /// <param name="name">The name of the storage account.</param>
            /// <param name="connectionString">The connection string to use for accessing the Azure storage account.</param>
            ///
            internal StorageProperties(string name,
                                       string connectionString)
            {
                Name = name;
                ConnectionString = connectionString;
            }
        }
    }
}
