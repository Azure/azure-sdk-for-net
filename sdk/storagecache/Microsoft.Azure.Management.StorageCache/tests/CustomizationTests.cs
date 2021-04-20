// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.Management.StorageCache.Tests.Fixtures;
    using Microsoft.Azure.Management.StorageCache.Tests.Utilities;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Defines the <see cref="CustomizationTests" />.
    /// </summary>
    [Collection("StorageCacheCollection")]
    public class CustomizationTests
    {
        /// <summary>
        /// Defines the testOutputHelper.
        /// </summary>
        private readonly ITestOutputHelper testOutputHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomizationTests"/> class.
        /// </summary>
        /// <param name="testOutputHelper">The testOutputHelper<see cref="ITestOutputHelper"/>.</param>
        public CustomizationTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        /// <summary>
        /// Verify the ApiVersion property of the client is default to the correct version."
        /// </summary>
        [Fact]
        public void TestApiVersion()
        {
            RecordedDelegatingHandler recordedDelegatingHandlers = new RecordedDelegatingHandler();
            ServiceClientCredentials credentials = new TokenCredentials("abc");
            StorageCacheManagementClient storageCacheManagementClient = new StorageCacheManagementClient(credentials, recordedDelegatingHandlers);
            Assert.Equal(Constants.DefaultAPIVersion, storageCacheManagementClient.ApiVersion);
        }
    }
}