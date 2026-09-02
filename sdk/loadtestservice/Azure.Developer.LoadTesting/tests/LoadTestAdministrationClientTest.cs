// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Developer.LoadTesting.Tests
{
    public class LoadTestAdministrationClientTest : LoadTestTestsBase
    {
        public LoadTestAdministrationClientTest(bool isAsync) : base(isAsync) { }

        [SetUp]
        public async Task SetUp()
        {
            _loadTestAdministrationClient = CreateAdministrationClient();

            // Call all Requires*() methods first to set resource IDs (avoid short-circuit issues)
            bool needsLoadTest = RequiresLoadTest();
            bool needsTestFile = RequiresTestFile();
            bool needsTrigger = RequiresTrigger();
            bool needsNotificationRule = RequiresNotificationRule();

            if (needsLoadTest || needsTestFile || needsTrigger)
            {
                await _testHelper.SetupLoadTestAsync(_loadTestAdministrationClient, _testId);
            }

            if (needsTestFile)
            {
                await _testHelper.SetupTestScriptAsync(_loadTestAdministrationClient, _testId, _fileName);
            }

            if (needsTrigger)
            {
                await _testHelper.SetupTriggerAsync(_loadTestAdministrationClient, _testId, _triggerId);
            }

            if (needsNotificationRule)
            {
                await _testHelper.SetupNotificationRuleAsync(
                    _loadTestAdministrationClient,
                    _notificationRuleId,
                    TestEnvironment.ActionGroupId);
            }
        }

        [TearDown]
        public async Task TearDown()
        {
            if (_loadTestAdministrationClient == null)
            {
                return;
            }

            if (!CheckForSkipDeleteNotificationRule())
            {
                try
                {
                    await _loadTestAdministrationClient.DeleteNotificationRuleAsync(_notificationRuleId);
                }
                catch (Exception)
                {
                    // Swallow - notification rule may not exist or already be deleted
                }
            }

            if (!CheckForSkipDeleteTrigger())
            {
                try
                {
                    await _loadTestAdministrationClient.DeleteTriggerAsync(_triggerId);
                }
                catch (Exception)
                {
                    // Swallow - trigger may not exist or already be deleted
                }
            }

            if (!SkipTearDown())
            {
                await _loadTestAdministrationClient.DeleteTestAsync(_testId);
            }
        }

        [Test]
        public async Task CreateOrUpdateTest()
        {
            Response response = await _loadTestAdministrationClient.CreateOrUpdateTestAsync(
                _testId,
                RequestContent.Create(
                        new
                        {
                            description = "This test was created through loadtesting C# SDK",
                            displayName = "Dotnet Testing Framework Loadtest",
                            loadTestConfig = new
                            {
                                engineInstance = 1,
                                splitAllCSVs = false,
                            },
                            secrets = new { },
                            enviornmentVariables = new { },
                            passFailCriteria = new
                            {
                                passFailMetrics = new { },
                            }
                        }
                    )
                );
            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.That(response.Content, Is.Not.Null);
            Assert.That(jsonDocument.RootElement.GetProperty("testId").ToString(), Is.EqualTo(_testId));
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        [Category(SKIP_TEAR_DOWN)]
        public async Task DeleteTest()
        {
            Response response = await _loadTestAdministrationClient.DeleteTestAsync(_testId);
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task GetLoadTest()
        {
            var loadTestResponse = await _loadTestAdministrationClient.GetTestAsync(_testId);
            var loadTest = loadTestResponse.Value;
            Assert.That(loadTest, Is.Not.Null);
            Assert.That(loadTest.TestId, Is.EqualTo(_testId));
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task ListLoadTest()
        {
            int pageSizeHint = 2;
            var pagedResponse = _loadTestAdministrationClient.GetTestsAsync();

            int count = 0;

            await foreach (var page in pagedResponse.AsPages(pageSizeHint: pageSizeHint))
            {
                count++;

                foreach (var value in page.Values)
                {
                    Assert.That(value.TestId, Is.Not.Null);

                    Console.WriteLine(value.ToString());
                }
            }

            int i = 0;
            await foreach (var page in pagedResponse.AsPages(pageSizeHint: pageSizeHint))
            {
                i++;

                if (i < count)
                {
                    Assert.That(page.Values.Count, Is.EqualTo(pageSizeHint));
                }
                else
                {
                    Assert.That(page.Values.Count, Is.LessThanOrEqualTo(pageSizeHint));
                }
            }
        }

        [Test]
        [Category(REQUIRES_TEST_FILE)]
        public async Task GetTestFile()
        {
            var fileGetResponse = await _loadTestAdministrationClient.GetTestFileAsync(_testId, _fileName);

            var file = fileGetResponse.Value;
            Assert.That(file, Is.Not.Null);
            Assert.That(file.FileName, Is.EqualTo(_fileName));
        }

        [Test]
        [Category(REQUIRES_TEST_FILE)]
        public async Task DeleteTestFile()
        {
            Response response = await _loadTestAdministrationClient.DeleteTestFileAsync(_testId, _fileName);

            try
            {
                await _loadTestAdministrationClient.DeleteTestFileAsync(_testId, _fileName);
                Assert.Fail();
            }
            catch (RequestFailedException)
            {
                Assert.Pass();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        [Category(REQUIRES_TEST_FILE)]
        public async Task ListTestFiles()
        {
            var pagedResponse = _loadTestAdministrationClient.GetTestFilesAsync(_testId);

            await foreach (var page in pagedResponse.AsPages())
            {
                foreach (var value in page.Values)
                {
                    Assert.That(value.FileName, Is.EqualTo(_fileName));
                }
            }
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task CreateOrUpdateAppComponents()
        {
            _resourceId = TestEnvironment.ResourceId;
            Response response = await _loadTestAdministrationClient.CreateOrUpdateAppComponentsAsync(
                    _testId,
                    RequestContent.Create(
                        new Dictionary<string, Dictionary<string, Dictionary<string, string>>>
                        {
                            { "components",  new Dictionary<string, Dictionary<string, string>>
                                {
                                    { _resourceId, new Dictionary<string, string>
                                        {
                                            { "resourceId", _resourceId },
                                            { "resourceName", "App-Service-Sample-Demo" },
                                            { "resourceType", "Microsoft.Web/sites" },
                                            { "kind", "web" }
                                        }
                                    }
                                }
                            }
                        }
                    )
                );
            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.That(jsonDocument.RootElement.GetProperty("components").GetProperty(_resourceId).GetProperty("resourceId").ToString(), Is.EqualTo(_resourceId));
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task GetAppComponents()
        {
            _resourceId = TestEnvironment.ResourceId;
            await _loadTestAdministrationClient.CreateOrUpdateAppComponentsAsync(
                    _testId,
                    RequestContent.Create(
                        new Dictionary<string, Dictionary<string, Dictionary<string, string>>>
                        {
                            { "components",  new Dictionary<string, Dictionary<string, string>>
                                {
                                    { _resourceId, new Dictionary<string, string>
                                        {
                                            { "resourceId", _resourceId },
                                            { "resourceName", "App-Service-Sample-Demo" },
                                            { "resourceType", "Microsoft.Web/sites" },
                                            { "kind", "web" }
                                        }
                                    }
                                }
                            }
                        }
                    )
                );

            var appComponentsResponse = await _loadTestAdministrationClient.GetAppComponentsAsync(_testId);
            var appComponents = appComponentsResponse.Value;
            Assert.That(appComponents, Is.Not.Null);
            var component = appComponents.Components.Values.FirstOrDefault();
            Assert.That(component, Is.Not.Null);
            Assert.That(component.ResourceId.ToString(), Is.EqualTo(_resourceId));
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task CreateOrUpdateServerMetricsConfig()
        {
            _resourceId = TestEnvironment.ResourceId;

            Response response = await _loadTestAdministrationClient.CreateOrUpdateServerMetricsConfigAsync(
                    _testId,
                    RequestContent.Create(
                        new Dictionary<string, Dictionary<string, Dictionary<string, string>>>
                        {
                            {
                                "metrics", new Dictionary<string, Dictionary<string, string>>
                                {
                                    {
                                        _resourceId, new Dictionary<string, string>
                                        {
                                            {"resourceId", _resourceId },
                                            {"metricNamespace", "microsoft.insights/components"},
                                            {"displayDescription", "sample description"},
                                            {"name",  "requests/duration"},
                                            {"aggregation", "Average"},
                                            {"unit", ""},
                                            {"resourceType", "microsoft.insights/components"}
                                        }
                                    }
                                }
                            }
                        }
                    )
                );
            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.That(jsonDocument.RootElement.GetProperty("metrics").GetProperty(_resourceId).GetProperty("resourceId").ToString(), Is.EqualTo(_resourceId));
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task GetServerMetricsConfig()
        {
            _resourceId = TestEnvironment.ResourceId;
            await _loadTestAdministrationClient.CreateOrUpdateServerMetricsConfigAsync(
                    _testId,
                    RequestContent.Create(
                        new Dictionary<string, Dictionary<string, Dictionary<string, string>>>
                        {
                            {
                                "metrics", new Dictionary<string, Dictionary<string, string>>
                                {
                                    {
                                        _resourceId, new Dictionary<string, string>
                                        {
                                            {"resourceId", _resourceId },
                                            {"metricNamespace", "microsoft.insights/components"},
                                            {"displayDescription", "sample description"},
                                            {"name",  "requests/duration"},
                                            {"aggregation", "Average"},
                                            {"unit", ""},
                                            {"resourceType", "microsoft.insights/components"}
                                        }
                                    }
                                }
                            }
                        }
                    )
                );

            var serverMetricsResponse = await _loadTestAdministrationClient.GetServerMetricsConfigAsync(_testId);
            var serverMetrics = serverMetricsResponse.Value;
            Assert.That(serverMetrics, Is.Not.Null);
            var metric = serverMetrics.Metrics.Values.FirstOrDefault();
            Assert.That(metric, Is.Not.Null);
            Assert.That(metric.ResourceId.ToString(), Is.EqualTo(_resourceId));
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task UploadTestFile_WaitUntilCompleted()
        {
            var fileContentStream = await _testHelper.GetFileContentStreamAsync(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _fileName));
            FileUploadResultOperation fileUploadOperation = await _loadTestAdministrationClient.UploadTestFileAsync(
                WaitUntil.Completed, _testId, _fileName, RequestContent.Create(
                    fileContentStream
                    )
                );

            JsonDocument jsonDocument = JsonDocument.Parse(fileUploadOperation.Value.ToString());
            Assert.That(jsonDocument.RootElement.GetProperty("fileName").ToString(), Is.EqualTo(_fileName));
            Assert.That(jsonDocument.RootElement.GetProperty("validationStatus").ToString(), Is.EqualTo("VALIDATION_SUCCESS"));
            Assert.That(fileUploadOperation.HasValue, Is.True);
            Assert.That(fileUploadOperation.HasCompleted, Is.True);
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task UploadTestFile_PollOperation()
        {
            var fileContentStream = await _testHelper.GetFileContentStreamAsync(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _fileName));
            FileUploadResultOperation fileUploadOperation = await _loadTestAdministrationClient.UploadTestFileAsync(
                   WaitUntil.Started, _testId, _fileName, RequestContent.Create(
                        fileContentStream
                    )
                );

            await fileUploadOperation.WaitForCompletionAsync();

            JsonDocument jsonDocument = JsonDocument.Parse(fileUploadOperation.Value.ToString());
            Assert.That(jsonDocument.RootElement.GetProperty("fileName").ToString(), Is.EqualTo(_fileName));
            Assert.That(jsonDocument.RootElement.GetProperty("validationStatus").ToString(), Is.EqualTo("VALIDATION_SUCCESS"));
            Assert.That(fileUploadOperation.HasValue, Is.True);
            Assert.That(fileUploadOperation.HasCompleted, Is.True);
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task CloneTest()
        {
            string clonedTestId = Recording.GenerateId("cloned-", 50);

            try
            {
                Operation<LoadTest> cloneOperation = await _loadTestAdministrationClient.CloneTestAsync(
                    WaitUntil.Completed,
                    _testId,
                    clonedTestId,
                    displayName: "Cloned Test from SDK",
                    description: "This test was cloned through loadtesting C# SDK"
                );

                Assert.That(cloneOperation.HasCompleted, Is.True);
                Assert.That(cloneOperation.HasValue, Is.True);

                LoadTest loadTest = await _loadTestAdministrationClient.GetTestAsync(clonedTestId);

                Assert.That(loadTest.TestId, Is.EqualTo(clonedTestId));
                Assert.That(loadTest.DisplayName, Is.EqualTo("Cloned Test from SDK"));
            }
            finally
            {
                // Cleanup the cloned test
                try
                {
                    await _loadTestAdministrationClient.DeleteTestAsync(clonedTestId);
                }
                catch (RequestFailedException)
                {
                    // Swallow exception if the cloned test was not created successfully
                }
            }
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task CreateOrUpdateTrigger()
        {
            Response response = await _loadTestAdministrationClient.CreateOrUpdateTriggerAsync(
                _triggerId,
                RequestContent.Create(
                    new
                    {
                        displayName = "Test Trigger from SDK",
                        kind = "ScheduleTestsTrigger",
                        testIds = new[] { _testId },
                        startDateTime = "2030-01-15T00:00:00.000Z",
                        recurrence = new
                        {
                            interval = 1,
                            frequency = "Daily"
                        }
                    }
                )
            );
            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.That(response.Content, Is.Not.Null);
            Assert.That(jsonDocument.RootElement.GetProperty("triggerId").ToString(), Is.EqualTo(_triggerId));

            // Cleanup trigger created by test itself
            await _loadTestAdministrationClient.DeleteTriggerAsync(_triggerId);
        }

        [Test]
        [Category(REQUIRES_TRIGGER)]
        public async Task GetTrigger()
        {
            var triggerResponse = await _loadTestAdministrationClient.GetTriggerAsync(_triggerId);
            var trigger = triggerResponse.Value;
            Assert.That(trigger, Is.Not.Null);
            Assert.That(trigger.TriggerId, Is.EqualTo(_triggerId));
            Assert.That(trigger.DisplayName, Is.EqualTo("Test Trigger from SDK"));
        }

        [Test]
        [Category(REQUIRES_TRIGGER)]
        [Category(SKIP_DELETE_TRIGGER)]
        public async Task DeleteTrigger()
        {
            Response response = await _loadTestAdministrationClient.DeleteTriggerAsync(_triggerId);
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        [Category(REQUIRES_TRIGGER)]
        public async Task ListTriggers()
        {
            var pagedResponse = _loadTestAdministrationClient.GetTriggersAsync(testIds: _testId);
            bool found = false;

            await foreach (var trigger in pagedResponse)
            {
                Assert.That(trigger.TriggerId, Is.Not.Null);
                if (trigger.TriggerId == _triggerId)
                {
                    found = true;
                }
            }

            Assert.That(found, Is.True, "Created trigger should appear in the list");
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task CreateOrUpdateNotificationRule()
        {
            string notificationRuleId = Recording.GenerateId("notif-rule-", 50);

            Response response = await _loadTestAdministrationClient.CreateOrUpdateNotificationRuleAsync(
                notificationRuleId,
                RequestContent.Create(
                    new
                    {
                        displayName = "Test Notification Rule from SDK",
                        scope = "Tests",
                        actionGroupIds = new[] { TestEnvironment.ActionGroupId },
                        events = new object[]
                        {
                            new
                            {
                                eventType = "TestRunEnded",
                                condition = new
                                {
                                    testRunStatuses = new[] { "DONE", "CANCELLED", "FAILED" },
                                    testRunResults = new[] { "PASSED", "NOT_APPLICABLE" }
                                }
                            },
                            new
                            {
                                eventType = "TestRunStarted"
                            }
                        }
                    }
                )
            );

            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.That(response.Content, Is.Not.Null);
            Assert.That(jsonDocument.RootElement.GetProperty("notificationRuleId").ToString(), Is.EqualTo(notificationRuleId));
            Assert.That(jsonDocument.RootElement.GetProperty("displayName").ToString(), Is.EqualTo("Test Notification Rule from SDK"));
            Assert.That(jsonDocument.RootElement.GetProperty("scope").ToString(), Is.EqualTo("Tests"));

            // Cleanup
            await _loadTestAdministrationClient.DeleteNotificationRuleAsync(notificationRuleId);
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        [Category(REQUIRES_NOTIFICATION_RULE)]
        public async Task GetNotificationRule()
        {
            Response<NotificationRule> response = await _loadTestAdministrationClient.GetNotificationRuleAsync(_notificationRuleId);
            NotificationRule notificationRule = response.Value;
            Assert.That(notificationRule, Is.Not.Null);
            Assert.That(notificationRule.NotificationRuleId, Is.EqualTo(_notificationRuleId));
            Assert.That(notificationRule.DisplayName, Is.EqualTo("Test Notification Rule from SDK"));
            Assert.That(notificationRule.ActionGroupIds, Is.Not.Empty);
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        [Category(REQUIRES_NOTIFICATION_RULE)]
        [Category(SKIP_DELETE_NOTIFICATION_RULE)]
        public async Task DeleteNotificationRule()
        {
            Response response = await _loadTestAdministrationClient.DeleteNotificationRuleAsync(_notificationRuleId);
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        [Category(REQUIRES_NOTIFICATION_RULE)]
        public async Task ListNotificationRules()
        {
            AsyncPageable<NotificationRule> pagedResponse = _loadTestAdministrationClient.GetNotificationRulesAsync();
            bool found = false;

            await foreach (NotificationRule notificationRule in pagedResponse)
            {
                Assert.That(notificationRule.NotificationRuleId, Is.Not.Null);
                if (notificationRule.NotificationRuleId == _notificationRuleId)
                {
                    found = true;
                    Assert.That(notificationRule.DisplayName, Is.EqualTo("Test Notification Rule from SDK"));
                }
            }

            Assert.That(found, Is.True, "Created notification rule should appear in the list");
        }
    }
}
