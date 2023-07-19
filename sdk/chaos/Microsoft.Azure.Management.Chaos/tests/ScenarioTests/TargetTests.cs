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
    public class TargetTests : ChaosTestBase
    {
        private RecordedDelegatingHandler handler;

        public TargetTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        /// <summary>
        /// Test the lifecycle of the Microsoft.Chaos/targets resource.
        /// Along the way hit all the possible operations on Microsoft.Chaos/targets.
        /// </summary>
        [Fact]
        public void TargetLifecycleTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var chaosManagementClient = this.GetChaosManagementClient(context, handler);

                var putTargetResponse = chaosManagementClient.Targets.CreateOrUpdateWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ParentProvicerNamespace, TestConstants.ParentProvicerType, TestConstants.ParentResourceName, TestConstants.TargetTypeName, new Target(properties: new Dictionary<string, object>())).GetAwaiter().GetResult();
                Assert.NotNull(putTargetResponse);
                Assert.Equal(HttpStatusCode.OK, putTargetResponse.Response.StatusCode);

                var getTargetResponse = chaosManagementClient.Targets.GetWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ParentProvicerNamespace, TestConstants.ParentProvicerType, TestConstants.ParentResourceName, TestConstants.TargetTypeName).GetAwaiter().GetResult();
                Assert.NotNull(getTargetResponse);
                Assert.Equal(HttpStatusCode.OK, getTargetResponse.Response.StatusCode);

                var listTargetResponse = chaosManagementClient.Targets.ListWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ParentProvicerNamespace, TestConstants.ParentProvicerType, TestConstants.ParentResourceName).GetAwaiter().GetResult();
                Assert.NotNull(listTargetResponse);

                var targetsList = ResponseContentToTargetsList(listTargetResponse.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Assert.True(targetsList.Count > 0);

                var deleteTargetResponse = chaosManagementClient.Targets.DeleteWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ParentProvicerNamespace, parentResourceType: TestConstants.ParentProvicerType, parentResourceName: TestConstants.ParentResourceName, targetName: TestConstants.TargetTypeName).GetAwaiter().GetResult();
                Assert.NotNull(deleteTargetResponse);
                Assert.Equal(HttpStatusCode.NoContent, deleteTargetResponse.Response.StatusCode);
            }
        }


        private static IList<Target> ResponseContentToTargetsList(string responseContent)
        {
            _ = responseContent ?? throw new ArgumentNullException(nameof(responseContent));

            Page<Target> aPageOfTargets;

            try
            {
                aPageOfTargets = Rest.Serialization.SafeJsonConvert.DeserializeObject<Page<Target>>(responseContent);
            }
            catch (Newtonsoft.Json.JsonException je)
            {
                throw new ArgumentException("The response content passed in is not a valid Page<Target> formatted json string.", nameof(responseContent), je);
            }

            return aPageOfTargets.ToList();
        }
    }
}
