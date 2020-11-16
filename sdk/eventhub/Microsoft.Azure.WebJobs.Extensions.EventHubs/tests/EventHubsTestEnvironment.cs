// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Core.TestFramework;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class EventHubsTestEnvironment: TestEnvironment
    {
        /// <summary>The Event Hubs namespace to use for the test run.</summary>
        public string EventHubsNamespaceConnectionString => GetVariable("EVENTHUB_NAMESPACE_CONNECTION_STRING");

        /// <summary>The environment variable value for the storage account connection string, lazily evaluated.</summary>
        public string StorageAccountConnectionString => GetVariable("EVENTHUB_PROCESSOR_STORAGE_CONNECTION_STRING");

        public EventHubsTestEnvironment() : base("eventhub")
        {
        }
    }
}