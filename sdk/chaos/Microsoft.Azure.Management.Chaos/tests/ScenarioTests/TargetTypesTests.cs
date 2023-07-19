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
    public class TargetTypesTests : ChaosTestBase
    {
        private RecordedDelegatingHandler handler;

        public TargetTypesTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        /// <summary>
        /// Validate the List All Target Types operation.
        /// </summary>
        [Fact]
        public void ListTargetTypesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var chaosManagementClient = this.GetChaosManagementClient(context, handler);

                var listTargetTypesResponse = chaosManagementClient.TargetTypes.ListWithHttpMessagesAsync(TestConstants.Region).GetAwaiter().GetResult();
                Assert.NotNull(listTargetTypesResponse);

                var targetTypesList = ResponseContentToTargetTypesList(listTargetTypesResponse.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Assert.True(targetTypesList.Count > 0);
            }
        }

        /// <summary>
        /// Validate the Get Target Types for a given target type operation.
        /// </summary>
        [Fact]
        public void GetTargetTypesInALocationTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var chaosManagementClient = this.GetChaosManagementClient(context, handler);

                var getTargetTypesResponse = chaosManagementClient.TargetTypes.GetWithHttpMessagesAsync(TestConstants.Region, TestConstants.TargetTypeName).GetAwaiter().GetResult();
                Assert.NotNull(getTargetTypesResponse);
                Assert.Equal(HttpStatusCode.OK, getTargetTypesResponse.Response.StatusCode);
            }
        }

        private static IList<TargetType> ResponseContentToTargetTypesList(string responseContent)
        {
            _ = responseContent ?? throw new ArgumentNullException(nameof(responseContent));

            Page<TargetType> aPageOfTargetTypes;

            try
            {
                aPageOfTargetTypes = Rest.Serialization.SafeJsonConvert.DeserializeObject<Page<TargetType>>(responseContent);
            }
            catch (Newtonsoft.Json.JsonException je)
            {
                throw new ArgumentException("The response content passed in is not a valid Page<TargetType> formatted json string.", nameof(responseContent), je);
            }

            return aPageOfTargetTypes.ToList();
        }
    }
}
