// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Models;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="TableServiceClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class TableServiceClientLiveTests : TableServiceLiveTestsBase
    {

        public TableServiceClientLiveTests(bool isAsync) : base(isAsync /* To record tests, add this argument, RecordedTestMode.Record */)
        { }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        [TestCase(null)]
        [TestCase(5)]
        public async Task GetTablesReturnsTablesWithAndWithoutPagination(int? pageCount)
        {
            var createdTables = new List<string>();

            try
            {
                // Create some extra tables.

                for (int i = 0; i < 10; i++)
                {
                    var table = Recording.GenerateId("testtable", 15);
                    await service.CreateTableAsync(table).ConfigureAwait(false);
                    createdTables.Add(table);
                }

                // Get the table list.

                var tableResponses = (await service.GetTablesAsync(top: pageCount).ToEnumerableAsync().ConfigureAwait(false)).ToList();

                Assert.That(() => tableResponses, Is.Not.Empty);
                Assert.That(() => tableResponses.Select(r => r.TableName), Contains.Item(tableName));
            }
            finally
            {
                foreach (var table in createdTables)
                {
                    await service.DeleteTableAsync(table);
                }
            }
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        public async Task GetTablesReturnsTablesWithFilter()
        {
            var createdTables = new List<string>();

            try
            {
                // Create some extra tables.

                for (int i = 0; i < 10; i++)
                {
                    var table = Recording.GenerateId("testtable", 15);
                    await service.CreateTableAsync(table).ConfigureAwait(false);
                    createdTables.Add(table);
                }

                // Query with a filter.

                var tableResponses = (await service.GetTablesAsync(filter: $"TableName eq '{tableName}'").ToEnumerableAsync().ConfigureAwait(false)).ToList();

                Assert.That(() => tableResponses, Is.Not.Empty);
                Assert.That(() => tableResponses.Select(r => r.TableName), Contains.Item(tableName));
            }
            finally
            {
                foreach (var table in createdTables)
                {
                    await service.DeleteTableAsync(table);
                }
            }
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        [Ignore("requires https://github.com/Azure/azure-sdk-for-net/issues/11764")]
        public async Task GetAccessPoliciesReturnsPolicies()
        {
            // Cratae some policies.

            var policyToCreate = new List<SignedIdentifier>
            {
                new SignedIdentifier("MTIzNDU2Nzg5MDEyMzQ1Njc4OTAxMjM0NTY3ODkwMTI=", new AccessPolicy(new DateTime(2020, 1,1,1,1,0,DateTimeKind.Utc), new DateTime(2021, 1,1,1,1,0,DateTimeKind.Utc), "r"))
            };

            await service.SetAccessPolicyAsync(tableName, tableAcl: policyToCreate);


            // Get the created policy.

            var policies = await service.GetAccessPolicyAsync(tableName);

            Assert.That(policies.Value, Is.EquivalentTo(policyToCreate));
        }
    }
}
