// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Azure.Core.TestFramework;

using Microsoft.AspNetCore.Http;

using NUnit.Framework;

namespace Azure.Analytics.OnlineExperimentation.Tests
{
    public class OnlineExperimentationClientTests : RecordedTestBase<OnlineExperimentationClientTestEnvironment>
    {
        private OnlineExperimentationClient _client;

        public OnlineExperimentationClientTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup()
        {
            var testEndpoint = new Uri(TestEnvironment.Endpoint);
            OnlineExperimentationClientOptions testClientOptions = InstrumentClientOptions(new OnlineExperimentationClientOptions());
            var testClient = new OnlineExperimentationClient(testEndpoint, TestEnvironment.Credential, testClientOptions);
            _client = InstrumentClient(testClient);
        }

        [RecordedTest]
        public async Task CreateExperimentMetric()
        {
            string metricId = base.Recording.GenerateId("test_metric_create", 10);

            await _client.DeleteMetricAsync(metricId); // make sure it doesn't exist

            var metricDefinition = new ExperimentMetric(
                LifecycleStage.Active,
                "New Test Metric",
                "A metric created for testing purposes",
                ["Test"],
                DesiredDirection.Increase,
                new EventCountMetricDefinition("TestEvent"));

            Response<ExperimentMetric> response = await _client.CreateMetricAsync(metricId, metricDefinition);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Id, Is.EqualTo(metricId));
            Assert.That(response.Value.DisplayName, Is.EqualTo(metricDefinition.DisplayName));
            Assert.That(response.Value.Description, Is.EqualTo(metricDefinition.Description));
        }

        [RecordedTest]
        public async Task CreateExperimentMetricOnlyIfNotExists()
        {
            string metricId = "test_metric_create_if_not_exists";

            try
            {
                await _client.DeleteMetricAsync(metricId); // make sure it doesn't exist
            }
            catch (RequestFailedException deleteException)
            {
                Assert.That(deleteException.Status, Is.EqualTo(StatusCodes.Status404NotFound));
            }

            var metricDefinition = new ExperimentMetric(
                LifecycleStage.Active,
                "If-None-Match Test Metric",
                "A metric created with If-None-Match header",
                ["Test", "Conditional"],
                DesiredDirection.Increase,
                new EventCountMetricDefinition("ConditionalCreateEvent"));

            Response<ExperimentMetric> response = await _client.CreateMetricAsync(metricId, metricDefinition);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Id, Is.EqualTo(metricId));
            Assert.That(response.Value.DisplayName, Is.EqualTo(metricDefinition.DisplayName));

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await _client.CreateMetricAsync(metricId, metricDefinition);
            });

            Assert.That(exception.Status, Is.EqualTo(StatusCodes.Status412PreconditionFailed));
        }

        [RecordedTest]
        public async Task UpdateExistingExperimentMetric()
        {
            string metricId = "test_metric_update_existing";

            ExperimentMetric originalMetric = await SetupTestMetricAsync(metricId);

            var updatedDefinition = new ExperimentMetricUpdate
            {
                DisplayName = "Updated Metric",
                Description = "This metric has been updated",
            };

            Response<ExperimentMetric> response = await _client.UpdateMetricAsync(metricId, updatedDefinition);
            ExperimentMetric updatedMetric = response.Value;

            Assert.That(updatedMetric, Is.Not.Null);
            Assert.That(updatedMetric.Id, Is.EqualTo(metricId));
            Assert.That(updatedMetric.DisplayName, Is.EqualTo(updatedDefinition.DisplayName));
            Assert.That(updatedMetric.Description, Is.EqualTo(updatedDefinition.Description));
            Assert.That(updatedMetric.ETag, Is.Not.EqualTo(originalMetric.ETag));
        }

        [RecordedTest]
        public void CreateOrUpdateExperimentMetricInvalidInputRejected()
        {
            string metricId = "test_metric_invalid";

            var invalidDefinition = new ExperimentMetric(
                LifecycleStage.Active,
                displayName: "", // missing required value
                description: "", // missing required value
                categories: ["Test"],
                DesiredDirection.Increase,
                definition: new EventCountMetricDefinition("EventName"));

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await _client.CreateOrUpdateMetricAsync(metricId, invalidDefinition);
            });

            Assert.That(exception.Status, Is.EqualTo(StatusCodes.Status400BadRequest));
            Assert.That(exception.ErrorCode, Is.EqualTo("InvalidOrUnsupportedError"));
        }

        [RecordedTest]
        public async Task UpdateExperimentMetricWithETag()
        {
            string metricId = "test_metric_conditional_update";

            ExperimentMetric originalMetric = await SetupTestMetricAsync(metricId);

            var updatedDefinition = new ExperimentMetricUpdate
            {
                DisplayName = "Updated With ETag",
                Description = "This metric has been updated with ETag condition"
            };

            Response<ExperimentMetric> response = await _client.UpdateMetricAsync(
                metricId,
                updatedDefinition,
                ifMatch: originalMetric.ETag);

            ExperimentMetric updatedMetric = response.Value;

            Assert.That(updatedMetric, Is.Not.Null);
            Assert.That(updatedMetric.Id, Is.EqualTo(metricId));
            Assert.That(updatedMetric.DisplayName, Is.EqualTo(updatedDefinition.DisplayName));
            Assert.That(updatedMetric.ETag, Is.Not.EqualTo(originalMetric.ETag));
        }

        [RecordedTest]
        public async Task UpdateExperimentMetricWithETagPreconditionFailed()
        {
            string metricId = "test_metric_if_match_fail";

            await SetupTestMetricAsync(metricId);

            var updatedDefinition = new ExperimentMetricUpdate
            {
                DisplayName = "This Should Not Update",
                Description = "This update should fail due to ETag mismatch",
            };

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await _client.UpdateMetricAsync(metricId, updatedDefinition, ifMatch: new ETag("incorrect-etag-value"));
            });

            Assert.That(exception.Status, Is.EqualTo(StatusCodes.Status412PreconditionFailed));
        }

        [RecordedTest]
        public async Task ListExperimentMetrics()
        {
            const int numMetrics = 3;

            for (int i = 0; i < numMetrics; i++)
            {
                await SetupTestMetricAsync($"test_metric_list_{i}");
            }

            List<ExperimentMetric> metrics = [];
            await foreach (ExperimentMetric metric in _client.GetMetricsAsync())
            {
                metrics.Add(metric);
            }

            Assert.That(metrics.Count, Is.GreaterThanOrEqualTo(numMetrics));
        }

        [RecordedTest]
        public async Task ListExperimentMetricsWithTopParameter()
        {
            const int numMetrics = 5;
            const int topCount = 2;

            for (int i = 0; i < numMetrics; i++)
            {
                await SetupTestMetricAsync($"test_metric_list_{i}");
            }

            List<ExperimentMetric> metrics = await _client.GetMetricsAsync(maxCount: topCount).ToEnumerableAsync();

            Assert.That(metrics.Count, Is.GreaterThanOrEqualTo(numMetrics));
        }

        [RecordedTest]
        public async Task GetExperimentMetricById()
        {
            string metricId = "test_metric_retrieve";

            ExperimentMetric createdMetric = await SetupTestMetricAsync(metricId);

            Response<ExperimentMetric> response = await _client.GetMetricAsync(metricId);
            ExperimentMetric retrievedMetric = response.Value;

            Assert.That(retrievedMetric, Is.Not.Null);
            Assert.That(retrievedMetric.Id, Is.EqualTo(metricId));
            Assert.That(retrievedMetric.DisplayName, Is.EqualTo(createdMetric.DisplayName));
            Assert.That(retrievedMetric.Description, Is.EqualTo(createdMetric.Description));
            Assert.That(retrievedMetric.ETag, Is.EqualTo(createdMetric.ETag));
        }

        [RecordedTest]
        public void GetExperimentMetricByIdNotFound()
        {
            string nonExistentMetricId = "test_metric_does_not_exist";

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await _client.GetMetricAsync(nonExistentMetricId);
            });

            Assert.That(exception.Status, Is.EqualTo(StatusCodes.Status404NotFound));
        }

        [RecordedTest]
        public async Task ValidateExperimentMetricValid()
        {
            var validDefinition = new ExperimentMetric(
                LifecycleStage.Active,
                "Valid Metric",
                "A valid metric for validation testing",
                ["Test", "Validation"],
                DesiredDirection.Increase,
                new EventCountMetricDefinition("ValidationEvent"));

            Response<ExperimentMetricValidationResult> response = await _client.ValidateMetricAsync(validDefinition);
            ExperimentMetricValidationResult result = response.Value;

            if (result.Diagnostics != null)
            {
                foreach (DiagnosticDetail diagnostic in result.Diagnostics)
                {
                    Console.WriteLine($"- {diagnostic.Code}: {diagnostic.Message}");
                }
            }

            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsValid, Is.True);
            Assert.That(result.Diagnostics, Is.Null.Or.Empty);
        }

        [RecordedTest]
        public async Task ValidateExperimentMetricInvalid()
        {
            var invalidDefinition = new ExperimentMetric(
                LifecycleStage.Active,
                "Invalid Metric",
                "An invalid metric for validation testing",
                ["Test"],
                DesiredDirection.Increase,
                new EventCountMetricDefinition("ValidationEvent")
                {
                    Event = { Filter = "this is not a valid filter expression." }
                });

            Response<ExperimentMetricValidationResult> response = await _client.ValidateMetricAsync(invalidDefinition);
            ExperimentMetricValidationResult result = response.Value;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Diagnostics, Is.Not.Null);
            Assert.That(result.Diagnostics, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task DeleteExperimentMetric()
        {
            string metricId = "test_metric_delete";

            // Create a test metric that will be deleted
            await SetupTestMetricAsync(metricId);

            // Delete the metric
            await _client.DeleteMetricAsync(metricId);

            // Verify the metric was deleted
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await _client.GetMetricAsync(metricId);
            });

            Assert.That(exception.Status, Is.EqualTo(StatusCodes.Status404NotFound));
        }

        [RecordedTest]
        public async Task DeleteExperimentMetricWithETag()
        {
            string metricId = "test_metric_delete_etag";

            // Create a test metric and capture its ETag for conditional deletion
            ExperimentMetric createdMetric = await SetupTestMetricAsync(metricId);
            string etag = createdMetric.ETag.ToString();

            // Delete the metric using ETag condition
            await _client.DeleteMetricAsync(metricId, new RequestConditions { IfMatch = new ETag(etag) });

            // Verify the metric was deleted
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await _client.GetMetricAsync(metricId);
            });

            Assert.That(exception.Status, Is.EqualTo(StatusCodes.Status404NotFound));
        }

        [RecordedTest]
        public async Task DeleteExperimentMetricPreconditionFailed()
        {
            string metricId = "test_metric_delete_etag_fail";

            // Create a test metric
            await SetupTestMetricAsync(metricId);

            // Attempt to delete with incorrect ETag should fail
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await _client.DeleteMetricAsync(
                    metricId,
                    new RequestConditions { IfMatch = new ETag("incorrect-etag-value") });
            });

            Assert.That(exception.Status, Is.EqualTo(StatusCodes.Status412PreconditionFailed));

            // Verify metric still exists
            Response<ExperimentMetric> response = await _client.GetMetricAsync(metricId);
            ExperimentMetric stillExists = response.Value;

            Assert.That(stillExists, Is.Not.Null);
            Assert.That(stillExists.Id, Is.EqualTo(metricId));
        }

        [RecordedTest]
        public async Task ActivateExperimentMetric()
        {
            string metricId = "test_metric_activate";

            await SetupTestMetricAsync(metricId, LifecycleStage.Inactive);

            // Activate the metric
            Response<ExperimentMetric> response = await _client.ActivateMetricAsync(metricId);

            // Verify the metric was activated
            ExperimentMetric activatedMetric = response.Value;

            Assert.That(activatedMetric, Is.Not.Null);
            Assert.That(activatedMetric.Id, Is.EqualTo(metricId));
            Assert.That(activatedMetric.Lifecycle, Is.EqualTo(LifecycleStage.Active));
        }

        [RecordedTest]
        public async Task DeactivateExperimentMetric()
        {
            string metricId = "test_metric_deactivate";

            // Create a test metric with Active status
            await SetupTestMetricAsync(metricId, LifecycleStage.Active);

            // Deactivate the metric
            Response<ExperimentMetric> response = await _client.DeactivateMetricAsync(metricId);

            // Verify the metric was deactivated
            ExperimentMetric deactivatedMetric = response.Value;

            Assert.That(deactivatedMetric, Is.Not.Null);
            Assert.That(deactivatedMetric.Id, Is.EqualTo(metricId));
            Assert.That(deactivatedMetric.Lifecycle, Is.EqualTo(LifecycleStage.Inactive));
        }

        [RecordedTest]
        public async Task DeactivateExperimentMetricWithETag()
        {
            string metricId = "test_metric_deactivate_etag";

            // Create an inactive metric and capture its ETag
            ExperimentMetric activeMetric = await SetupTestMetricAsync(metricId, LifecycleStage.Active);

            // Activate the metric with ETag condition
            Response<ExperimentMetric> response = await _client.DeactivateMetricAsync(metricId, ifMatch: activeMetric.ETag);

            // Verify the metric was activated
            ExperimentMetric deactivatedMetric = response.Value;

            Assert.That(deactivatedMetric.Lifecycle, Is.EqualTo(LifecycleStage.Inactive));
            Assert.That(deactivatedMetric.ETag.ToString(), Is.Not.EqualTo(activeMetric.ETag), "ETag should change when metric is modified");
        }

        [RecordedTest]
        public async Task DeactivateExperimentMetricPreconditionFailed()
        {
            string metricId = "test_metric_deactivate_etag_fail";
            ExperimentMetric activeMetric = await SetupTestMetricAsync(metricId, LifecycleStage.Active);

            // Attempt to deactivate with incorrect ETag should fail
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await _client.DeactivateMetricAsync(metricId, ifMatch: new ETag("some-other-value"));
            });

            Assert.That(exception.Status, Is.EqualTo(StatusCodes.Status412PreconditionFailed));
        }

        [RecordedTest]
        public async Task ActivateExperimentMetricWithETag()
        {
            string metricId = "test_metric_activate_etag";

            // Create an inactive metric and capture its ETag
            ExperimentMetric inactiveMetric = await SetupTestMetricAsync(metricId, LifecycleStage.Inactive);

            // Activate the metric with ETag condition
            Response<ExperimentMetric> response = await _client.ActivateMetricAsync(metricId, ifMatch: inactiveMetric.ETag);

            // Verify the metric was activated
            ExperimentMetric activatedMetric = response.Value;

            Assert.That(activatedMetric.Lifecycle, Is.EqualTo(LifecycleStage.Active));
            Assert.That(activatedMetric.ETag.ToString(), Is.Not.EqualTo(inactiveMetric.ETag), "ETag should change when metric is modified");
        }

        [RecordedTest]
        public async Task ActivateExperimentMetricWithETagPreconditionFailed()
        {
            string metricId = "test_metric_activate_etag_fail";

            // Create an inactive metric and capture its ETag
            await SetupTestMetricAsync(metricId, LifecycleStage.Inactive);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await _client.ActivateMetricAsync(metricId, ifMatch: new ETag("some-other-value"));
            });

            // Verify the metric was activated
            Assert.That(exception.Status, Is.EqualTo(StatusCodes.Status412PreconditionFailed));
        }

        private async Task<ExperimentMetric> SetupTestMetricAsync(string metricId, LifecycleStage lifecycle = default)
        {
            var currentTest = TestContext.CurrentContext.Test;
            var metricDefinition = new ExperimentMetric(
                lifecycle == default ? LifecycleStage.Active : lifecycle,
                displayName: $"Test Metric {currentTest.Name}",
                description: $"A metric created for testing purposes ({currentTest.FullName})",
                ["Test"],
                DesiredDirection.Increase,
                new EventCountMetricDefinition("TestEvent"));

            Response<ExperimentMetric> response = await _client.CreateOrUpdateMetricAsync(metricId, metricDefinition);

            return response.Value;
        }
    }
}
