// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Chaos.Tests.Helpers;
using Microsoft.Azure.Management.Chaos.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Microsoft.Azure.Management.Chaos.Tests.TestDependencies;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.Chaos.Tests.ScenarioTests
{
    public class CapabilityTypesTests : ChaosTestBase
    {
        private RecordedDelegatingHandler handler;

        public CapabilityTypesTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        /// <summary>
        /// Validate the List All Capability Types for a target type operation.
        /// </summary>
        [Fact]
        public void ListCapabilityTypesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var chaosManagementClient = this.GetChaosManagementClient(context, handler);

                var listCapabilityTypesResponse = chaosManagementClient.CapabilityTypes.ListWithHttpMessagesAsync(TestConstants.Region, TestConstants.TargetTypeName).GetAwaiter().GetResult();
                Assert.NotNull(listCapabilityTypesResponse);

                var capabilityTypesList = ResponseContentToCapabilityTypesList(listCapabilityTypesResponse.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Assert.True(capabilityTypesList.Count > 0);
            }
        }

        /// <summary>
        /// Validate the Get Capability Types for a given target type and capability type operation.
        /// </summary>
        [Fact]
        public void GetCapabilityTypesInALocationTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var chaosManagementClient = this.GetChaosManagementClient(context, handler);

                var getCapabilityTypeResponse = chaosManagementClient.CapabilityTypes.GetWithHttpMessagesAsync(TestConstants.Region, TestConstants.TargetTypeName, TestConstants.CapabilityTypeName).GetAwaiter().GetResult();

                Assert.NotNull(getCapabilityTypeResponse);
                Assert.Equal(HttpStatusCode.OK, getCapabilityTypeResponse.Response.StatusCode);
            }
        }

        private static IList<CapabilityType> ResponseContentToCapabilityTypesList(string responseContent)
        {
            _ = responseContent ?? throw new ArgumentNullException(nameof(responseContent));

            Page<CapabilityType> aPageOfCapabilityTypes;

            try
            {
                aPageOfCapabilityTypes = Rest.Serialization.SafeJsonConvert.DeserializeObject<Page<CapabilityType>>(responseContent);
            }
            catch (Newtonsoft.Json.JsonException je)
            {
                throw new ArgumentException("The response content passed in is not a valid Page<CapabilityType> formatted json string.", nameof(responseContent), je);
            }

            return aPageOfCapabilityTypes.ToList();
        }
    }
}
