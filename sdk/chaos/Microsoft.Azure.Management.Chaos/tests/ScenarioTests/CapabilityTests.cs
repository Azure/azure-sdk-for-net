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
    public class CapabilityTests : ChaosTestBase
    {
        private RecordedDelegatingHandler handler;

        public CapabilityTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        /// <summary>
        /// Test the lifecycle of the Microsoft.Chaos/capability resource.
        /// Along the way hit all the possible operations on Microsoft.Chaos/capability.
        /// </summary>
        [Fact]
        public void CapabilityLifecycleTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var chaosManagementClient = this.GetChaosManagementClient(context, handler);

                // Set up the parent resource of capability resource.
                var putTargetResponse = chaosManagementClient.Targets.CreateOrUpdateWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ParentProvicerNamespace, TestConstants.ParentProvicerType, TestConstants.ParentResourceName, TestConstants.TargetTypeName, new Target(properties: new Dictionary<string, object>())).GetAwaiter().GetResult();
                Assert.NotNull(putTargetResponse);
                Assert.Equal(HttpStatusCode.OK, putTargetResponse.Response.StatusCode);

                var getTargetResponse = chaosManagementClient.Targets.GetWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ParentProvicerNamespace, TestConstants.ParentProvicerType, TestConstants.ParentResourceName, TestConstants.TargetTypeName).GetAwaiter().GetResult();
                Assert.NotNull(getTargetResponse);
                Assert.Equal(HttpStatusCode.OK, getTargetResponse.Response.StatusCode);

                // Set up capability resource.
                var putCapabilityResponse = chaosManagementClient.Capabilities.CreateOrUpdateWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ParentProvicerNamespace, TestConstants.ParentProvicerType, TestConstants.ParentResourceName, TestConstants.TargetTypeName, TestConstants.CapabilityTypeName).GetAwaiter().GetResult();
                Assert.NotNull(putCapabilityResponse);
                Assert.Equal(HttpStatusCode.OK, putCapabilityResponse.Response.StatusCode);

                var listCapabilitiesResponse = chaosManagementClient.Capabilities.ListWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ParentProvicerNamespace, TestConstants.ParentProvicerType, TestConstants.ParentResourceName, TestConstants.TargetTypeName).GetAwaiter().GetResult();
                Assert.NotNull(listCapabilitiesResponse);

                var capabilitiesList = ResponseContentToCapabilityList(listCapabilitiesResponse.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Assert.True(capabilitiesList.Count > 0);

                var getCapabilityResponse = chaosManagementClient.Capabilities.GetWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ParentProvicerNamespace, TestConstants.ParentProvicerType, TestConstants.ParentResourceName, TestConstants.TargetTypeName, TestConstants.CapabilityTypeName).GetAwaiter().GetResult();
                Assert.NotNull(getCapabilityResponse);
                Assert.Equal(HttpStatusCode.OK, getCapabilityResponse.Response.StatusCode);

                var deleteCapabilityResponse = chaosManagementClient.Capabilities.DeleteWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ParentProvicerNamespace, TestConstants.ParentProvicerType, TestConstants.ParentResourceName, TestConstants.TargetTypeName, TestConstants.CapabilityTypeName).GetAwaiter().GetResult();
                Assert.NotNull(deleteCapabilityResponse);
                Assert.Equal(HttpStatusCode.OK, getCapabilityResponse.Response.StatusCode);
            }
        }

        private static IList<Capability> ResponseContentToCapabilityList(string responseContent)
        {
            _ = responseContent ?? throw new ArgumentNullException(nameof(responseContent));

            Page<Capability> aPageOfCapabilities;

            try
            {
                aPageOfCapabilities = Rest.Serialization.SafeJsonConvert.DeserializeObject<Page<Capability>>(responseContent);
            }
            catch (Newtonsoft.Json.JsonException je)
            {
                throw new ArgumentException("The response content passed in is not a valid Page<CapabilityType> formatted json string.", nameof(responseContent), je);
            }

            return aPageOfCapabilities.ToList();
        }
    }
}
