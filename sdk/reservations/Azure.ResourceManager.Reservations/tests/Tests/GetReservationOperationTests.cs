// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Reservations.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Reservations.Tests
{
    public class GetReservationOperationTests : ReservationsManagementClientBase
    {
        private TenantResource Tenant { get; set; }

        public GetReservationOperationTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();

                AsyncPageable<TenantResource> tenantResourcesResponse = ArmClient.GetTenants().GetAllAsync();
                List<TenantResource> tenantResources = await tenantResourcesResponse.ToEnumerableAsync();
                Tenant = tenantResources.ToArray()[0];
            }
        }

        //[TestCase]
        //[RecordedTest]
        //public async Task TestGetReservationOperations()
        //{
        //    var response = Tenant.GetOperationsAsync();
        //    List<OperationResponse> operations = await response.ToEnumerableAsync();

        //    Assert.AreEqual(40, operations.Count);
        //}
    }
}
