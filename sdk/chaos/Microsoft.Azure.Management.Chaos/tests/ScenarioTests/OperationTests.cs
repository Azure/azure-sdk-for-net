// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Chaos.Tests.Helpers;
using Microsoft.Azure.Management.Chaos.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.Chaos.Tests.ScenarioTests
{
    public class OperationTests : ChaosTestBase
    {
        private RecordedDelegatingHandler handler;

        public OperationTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        /// <summary>
        /// Validate the List All Operations operation.
        /// </summary>
        [Fact]
        public void ListOperationsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var chaosManagementClient = this.GetChaosManagementClient(context, handler);

                var listOperationsResponse = chaosManagementClient.Operations.ListAllWithHttpMessagesAsync().GetAwaiter().GetResult();
                Assert.NotNull(listOperationsResponse);

                var operationsList = ResponseContentToOperationsList(listOperationsResponse.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Assert.True(operationsList.Count > 0);
            }
        }

        public static IList<Operation> ResponseContentToOperationsList(string responseContent)
        {
            _ = responseContent ?? throw new ArgumentNullException(nameof(responseContent));

            Page<Operation> aPageOfOperations;

            try
            {
                aPageOfOperations = Rest.Serialization.SafeJsonConvert.DeserializeObject<Page<Operation>>(responseContent);
            }
            catch (Newtonsoft.Json.JsonException je)
            {
                throw new ArgumentException("The response content passed in is not a valid Page<Operation> formatted json string.", nameof(responseContent), je);
            }

            return aPageOfOperations.ToList();
        }
    }
}
