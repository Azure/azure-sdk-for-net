// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Models;
using Azure.Data.Tables.Sas;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Azure.Data.Tables.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="TableServiceClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class EnableTenantDiscoveryLiveTests : TableServiceLiveTestsBase
    {
        public EnableTenantDiscoveryLiveTests(bool isAsync, TableEndpointType endpointType) : base(
            isAsync,
            endpointType,
            enableTenantDiscovery: true/* To record tests, add this argument, RecordedTestMode.Record */)
        { }

        [RecordedTest]
        public async Task EnableTenantDiscoveryDoesNotFailAuth()
        {
            (await client.QueryAsync<TableEntity>().ToEnumerableAsync()).ToList();
            (await service.QueryAsync().ToEnumerableAsync()).ToList();
        }
   }
}
