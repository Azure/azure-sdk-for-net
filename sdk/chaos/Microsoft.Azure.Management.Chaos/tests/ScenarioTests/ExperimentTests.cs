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
using System.Threading;

namespace Microsoft.Azure.Management.Chaos.Tests.ScenarioTests
{
    public class ExperimentTests : ChaosTestBase
    {
        private RecordedDelegatingHandler handler;

        public ExperimentTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        /// <summary>
        /// Run through an Microsoft.Chaos/experiments' lifecycle and validate the response of each operation.
        /// Along the way, validating all of the operations for Microsoft.Chaos/experiments resource.
        /// </summary>
        [Fact]
        public void ExperimentLifecycleTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var chaosManagementClient = this.GetChaosManagementClient(context, handler);
                var experiment = ExperimentFactory.CreateDelayActionExperiment(
                    experimentName: TestConstants.ExperimentName,
                    branchName: TestConstants.BranchName,
                    stepName: TestConstants.StepName,
                    location: TestConstants.Region,
                    principalId: TestConstants.ExperimentIdentityPrincipalId,
                    tenantId: TestConstants.ExperimentIdentityTenantId);

                var createdExperimentResponse = chaosManagementClient.Experiments.CreateOrUpdateWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ExperimentName, experiment).GetAwaiter().GetResult();

                Assert.NotNull(createdExperimentResponse);
                Assert.Equal(HttpStatusCode.OK, createdExperimentResponse.Response.StatusCode);

                var getExperimentResponse = chaosManagementClient.Experiments.GetAsync(TestConstants.ResourceGroupName, TestConstants.ExperimentName).GetAwaiter().GetResult();

                Assert.NotNull(getExperimentResponse);

                var listExperimentsResponse = chaosManagementClient.Experiments.ListWithHttpMessagesAsync(TestConstants.ResourceGroupName, false).GetAwaiter().GetResult();
                Assert.NotNull(listExperimentsResponse);

                var listExperiments = ResponseContentToListExperiments(listExperimentsResponse.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Assert.True(listExperiments.Count > 0);

                var startExperimentResponse = chaosManagementClient.Experiments.StartWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ExperimentName).GetAwaiter().GetResult();

                Assert.NotNull(startExperimentResponse);
                Assert.Equal(HttpStatusCode.Accepted, startExperimentResponse.Response.StatusCode);

                var statusElements = new Uri(startExperimentResponse.Body.StatusUrl).AbsolutePath.Split('/');
                Assert.True(statusElements.Length == 11);

                var statusName = statusElements[10];
                var status = string.Empty;

                do
                {
                    Thread.Sleep(1000 * 120); // Sleep for 2 minute so we let the experiment execution run to completion.
                    var getStatusResponse = chaosManagementClient.Experiments.GetStatusWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ExperimentName, statusName).GetAwaiter().GetResult();
                    Assert.NotNull(getStatusResponse);
                    Assert.Equal(HttpStatusCode.OK, getStatusResponse.Response.StatusCode);
                    status = getStatusResponse.Body.Status;
                }
                while (!IsStatusTerminal(status));

                Assert.Equal("success", status, StringComparer.InvariantCultureIgnoreCase);

                var getExecutionDetailResponse = chaosManagementClient.Experiments.GetExecutionDetailsWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ExperimentName, statusName).GetAwaiter().GetResult();
                Assert.NotNull(getExecutionDetailResponse);
                Assert.Equal(HttpStatusCode.OK, getExecutionDetailResponse.Response.StatusCode);

                var listStatusesResponse = chaosManagementClient.Experiments.ListAllStatusesWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ExperimentName).GetAwaiter().GetResult();
                Assert.NotNull(listStatusesResponse);

                var listExperimentStatuses = ResponseContentToListExperimentStatus(listStatusesResponse.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Assert.True(listExperimentStatuses.Count > 0);

                var listExecutionDetailsResponse = chaosManagementClient.Experiments.ListExecutionDetailsWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ExperimentName).GetAwaiter().GetResult();
                Assert.NotNull(listExecutionDetailsResponse);

                var listExecutionDetails = ResponseContentToChaosExperimentExecutionDetailsList(listExecutionDetailsResponse.Response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Assert.True(listExecutionDetails.Count > 0);

                var deleteResponse = chaosManagementClient.Experiments.DeleteWithHttpMessagesAsync(TestConstants.ResourceGroupName, TestConstants.ExperimentName).GetAwaiter().GetResult();

                Assert.NotNull(deleteResponse);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);
            }
        }

        public static IList<ExperimentExecutionDetails> ResponseContentToChaosExperimentExecutionDetailsList(string responseContent)
        {
            _ = responseContent ?? throw new ArgumentNullException(nameof(responseContent));

            Page<ExperimentExecutionDetails> aPageOfChaosExperimentExecutionDetails;

            try
            {
                aPageOfChaosExperimentExecutionDetails = Rest.Serialization.SafeJsonConvert.DeserializeObject<Page<ExperimentExecutionDetails>>(responseContent);
            }
            catch (Newtonsoft.Json.JsonException je)
            {
                throw new ArgumentException("The response content passed in is not a valid Page<ChaosExperimentExecutionDetailsResponse> formatted json string.", nameof(responseContent), je);
            }

            return aPageOfChaosExperimentExecutionDetails.ToList();
        }

        private static IList<ExperimentStatus> ResponseContentToListExperimentStatus(string responseContent)
        {
            _ = responseContent ?? throw new ArgumentNullException(nameof(responseContent));

            Page<ExperimentStatus> aPageOfChaosExperimentStatuses;

            try
            {
                aPageOfChaosExperimentStatuses = Rest.Serialization.SafeJsonConvert.DeserializeObject<Page<ExperimentStatus>>(responseContent);
            }
            catch (Newtonsoft.Json.JsonException je)
            {
                throw new ArgumentException("The response content passed in is not a valid Page<ExperimentStatus> formatted json string.", nameof(responseContent), je);
            }

            return aPageOfChaosExperimentStatuses.ToList();
        }

        private static IList<Experiment> ResponseContentToListExperiments(string responseContent)
        {
            _ = responseContent ?? throw new ArgumentNullException(nameof(responseContent));

            Page<Experiment> aPageOfChaosExperiments;

            try
            {
                aPageOfChaosExperiments = Rest.Serialization.SafeJsonConvert.DeserializeObject<Page<Experiment>>(responseContent);
            }
            catch (Newtonsoft.Json.JsonException je)
            {
                throw new ArgumentException("The response content passed in is not a valid Page<Experiment> formatted json string.", nameof(responseContent), je);
            }

            return aPageOfChaosExperiments.ToList();
        }

        private static bool IsStatusTerminal(string status)
        {
            if (string.Equals(status, "failed", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else if (string.Equals(status, "canceled", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else if (string.Equals(status, "success", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
