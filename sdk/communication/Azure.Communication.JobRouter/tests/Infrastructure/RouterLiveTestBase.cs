// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Infrastructure
{
    public class RouterLiveTestBase : RecordedTestBase<RouterTestEnvironment>
    {
        private ConcurrentDictionary<string, Stack<Task>> _testCleanupTasks;
        private const string URIDomainRegEx = @"https://([^/?]+)";

        public RouterLiveTestBase(bool isAsync, RecordedTestMode? mode = RecordedTestMode.Playback) : base(isAsync, mode)
        {
            _testCleanupTasks = new ConcurrentDictionary<string, Stack<Task>>();
            JsonPathSanitizers.Add("$..token");
            JsonPathSanitizers.Add("$..accessToken");
            JsonPathSanitizers.Add("$..functionKey");
            JsonPathSanitizers.Add("$..appKey");
            SanitizedHeaders.Add("x-ms-content-sha256");
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainRegEx, "https://sanitized.comminication.azure.com"));
        }

        [SetUp]
        public void SetIdPrefix()
        {
            IdPrefix = Recording.GetVariable("id-prefix", $"sdk-{GetSmallGuid()}-");
        }

        [TearDown]
        public async Task CleanUp()
        {
            var mode = TestEnvironment.Mode ?? Mode;
            if (mode != RecordedTestMode.Playback)
            {
                await Task.Delay(TimeSpan.FromSeconds(3));

                var testName = TestContext.CurrentContext.Test.FullName;

                var popTestResources = _testCleanupTasks.TryRemove(testName, out var cleanupTasks);
                if (popTestResources)
                {
                    if (cleanupTasks != null && cleanupTasks.Any())
                    {
                        while (cleanupTasks.Count > 0)
                        {
                            await Task.Delay(TimeSpan.FromSeconds(1));

                            var executableTask = cleanupTasks.Pop();
                            try
                            {
                                await Task.Run(() => executableTask.Start());
                            }
                            catch (Exception)
                            {
                                // Retry after delay
                                await Task.Delay(TimeSpan.FromSeconds(3));
                                await Task.Run(() => executableTask.Start());
                            }
                        }
                    }
                }
            }
        }

        protected DateTimeOffset GetOrSetScheduledTimeUtc(DateTimeOffset scheduledTime)
        {
            var mode = TestEnvironment.Mode ?? Mode;
            DateTimeOffset? result = null;

            if (mode == RecordedTestMode.Playback)
            {
                var resultAsString = Recording.GetVariable("scheduled-time-utc", string.Empty);
                result = DateTimeOffset.ParseExact(resultAsString, "O", CultureInfo.InvariantCulture);
            }
            else
            {
                Recording.SetVariable("scheduled-time-utc", scheduledTime.ToString("O"));
            }

            return result ?? scheduledTime;
        }

        protected JobRouterClient CreateRouterClientWithConnectionString()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            var client = new JobRouterClient(connectionString, CreateRouterClientOptionsWithCorrelationVectorLogs());
            var instrumentedRouterClient = InstrumentClient(client);
            return instrumentedRouterClient;
        }

        protected JobRouterAdministrationClient CreateRouterAdministrationClientWithConnectionString()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            var client = new JobRouterAdministrationClient(connectionString, CreateRouterClientOptionsWithCorrelationVectorLogs());
            var instrumentedRouterClient = InstrumentClient(client);
            return instrumentedRouterClient;
        }

        #region CRUD Helpers

        protected async Task<Response<ClassificationPolicy>> CreateQueueSelectionCPAsync(string? uniqueIdentifier = default)
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();

            var classificationPolicyId = GenerateUniqueId($"{IdPrefix}{uniqueIdentifier}");
            var classificationPolicyName = $"QueueSelection-ClassificationPolicy";
            var createQueueResponse = await CreateQueueAsync(nameof(CreateQueueSelectionCPAsync));
            var createClassificationPolicyResponse = await routerClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId)
                {
                    Name = classificationPolicyName,
                    FallbackQueueId = createQueueResponse.Value.Id,
                    QueueSelectorAttachments =
                    {
                        new StaticQueueSelectorAttachment(new RouterQueueSelector("Id", LabelOperator.Equal, new RouterValue(createQueueResponse.Value.Id)))
                    }
                });
            AddForCleanup(new Task(async () => await routerClient.DeleteClassificationPolicyAsync(createClassificationPolicyResponse.Value.Id)));

            return createClassificationPolicyResponse;
        }

        protected async Task<Response<RouterQueue>> CreateQueueAsync(string? uniqueIdentifier = default)
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();
            var createDistributionPolicyResponse = await CreateDistributionPolicy(uniqueIdentifier);
            var queueId = GenerateUniqueId($"{IdPrefix}-{uniqueIdentifier}");
            var queueName = "DefaultQueue-Sdk-Test" + queueId;
            var queueLabels = new Dictionary<string, RouterValue?> { ["Label_1"] = new("Value_1") };
            var createQueueResponse = await routerClient.CreateQueueAsync(
                new CreateQueueOptions(queueId, createDistributionPolicyResponse.Value.Id)
                {
                    Name = queueName,
                    Labels = { ["Label_1"] = new RouterValue("Value_1") }
                });

            AssertQueueResponseIsEqual(createQueueResponse, queueId, createDistributionPolicyResponse.Value.Id, queueName, queueLabels);
            AddForCleanup(new Task(async () => await routerClient.DeleteQueueAsync(createQueueResponse.Value.Id)));
            return createQueueResponse;
        }

        protected async Task<Response<DistributionPolicy>> CreateDistributionPolicy(string? uniqueIdentifier = default)
        {
            JobRouterAdministrationClient routerClient = CreateRouterAdministrationClientWithConnectionString();
            var distributionId = GenerateUniqueId($"{IdPrefix}{uniqueIdentifier}");
            var distributionPolicyName = "LongestIdleDistributionPolicy" + distributionId;
            var createDistributionPolicyResponse = await routerClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(distributionId, TimeSpan.FromSeconds(30), new LongestIdleMode())
                {
                    Name = distributionPolicyName,
                });

            Assert.AreEqual(distributionId, createDistributionPolicyResponse.Value.Id);
            Assert.AreEqual(distributionPolicyName, createDistributionPolicyResponse.Value.Name);
            Assert.IsNotNull(createDistributionPolicyResponse.Value.Mode);
            Assert.IsTrue(createDistributionPolicyResponse.Value.Mode.GetType() == typeof(LongestIdleMode));
            AddForCleanup(new Task(async () => await routerClient.DeleteDistributionPolicyAsync(createDistributionPolicyResponse.Value.Id)));
            return createDistributionPolicyResponse;
        }

        #endregion CRUD Helpers

        #region Support assertions

        protected void AssertQueueResponseIsEqual(Response<RouterQueue> upsertQueueResponse, string queueId, string distributionPolicyId, string? queueName = default, IDictionary<string, RouterValue?>? queueLabels = default, string? exceptionPolicyId = default)
        {
            var response = upsertQueueResponse.Value;

            Assert.AreEqual(queueId, response.Id);
            Assert.AreEqual(queueName, response.Name);
            Assert.AreEqual(distributionPolicyId, response.DistributionPolicyId);
            if (queueLabels != default)
            {
                var labelsWithID = queueLabels.ToDictionary(k => k.Key, k => k.Value);

                if (!labelsWithID.ContainsKey("Id"))
                {
                    labelsWithID.Add("Id", new RouterValue(queueId));
                }

                Assert.AreEqual(labelsWithID.ToDictionary(x => x.Key, x => x.Value?.Value), response.Labels.ToDictionary(x => x.Key, x => x.Value?.Value));
            }

            if (exceptionPolicyId != default)
            {
                Assert.AreEqual(exceptionPolicyId, response.ExceptionPolicyId);
            }
        }

        protected void AssertRegisteredWorkerIsValid(Response<RouterWorker> routerWorkerResponse, string workerId,
            IList<string> queues, int? capacity,
            IDictionary<string, RouterValue?>? workerLabels = default,
            IList<RouterChannel>? channelsList = default,
            IDictionary<string, RouterValue?>? workerTags = default)
        {
            var response = routerWorkerResponse.Value;

            Assert.AreEqual(workerId, response.Id);
            Assert.AreEqual(queues.Count(), response.Queues.Count);
            Assert.AreEqual(capacity, response.Capacity);

            if (workerLabels != default)
            {
                var labelsWithID = workerLabels.ToDictionary(k => k.Key, k => k.Value);
                labelsWithID.Add("Id", new RouterValue(workerId));
                Assert.AreEqual(labelsWithID, response.Labels);
            }

            if (workerTags != default)
            {
                var tags = workerTags.ToDictionary(k => k.Key, k => k.Value);
                Assert.AreEqual(tags, response.Tags);
            }

            if (channelsList != default)
            {
                Assert.AreEqual(channelsList.Count, response.Channels.Count);
            }
        }

        protected void AddForCleanup(Task t)
        {
            var testName = TestContext.CurrentContext.Test.FullName;

            if (!_testCleanupTasks.ContainsKey(testName))
            {
                _testCleanupTasks[testName] = new Stack<Task>();
            }
            _testCleanupTasks[testName].Push(t);
        }

        #endregion

        #region private functions

        private JobRouterClientOptions CreateRouterClientOptionsWithCorrelationVectorLogs()
        {
            JobRouterClientOptions routerClientOptions = new JobRouterClientOptions();
            routerClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(routerClientOptions);
        }

        #endregion

        protected async Task<T> Poll<T>(Func<Task<T>> query, Func<T, bool> untilCondition, TimeSpan timeOut)
        {
            var result = await query();
            if (untilCondition(result))
                return result;

            var timeOutTime = DateTime.Now.Add(timeOut);
            while (DateTime.Now < timeOutTime)
            {
                if (Mode != RecordedTestMode.Playback)
                    await Task.Delay(TimeSpan.FromSeconds(1));
                result = await query();
                if (untilCondition(result))
                    return result;
            }

            return result;
        }

        protected string? IdPrefix { get; set; }

        private static string GetSmallGuid()
        {
            string encoded = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            encoded = encoded.Replace("/", "_").Replace("+", "-");
            return encoded.Substring(0, 22);
        }

        protected string GenerateUniqueId(params string?[] value)
        {
            var result = GenerateSHA256Id(value);
            var underFiftyCharacters = ReduceToFiftyCharactersInternal(result);
            return underFiftyCharacters;
        }

        private string GenerateSHA256Id(params string?[] values)
        {
            var result = string.Join("", values);
            var input = Encoding.UTF8.GetBytes(result);
            var encoded = SHA256.Create().ComputeHash(input);
            var response = BitConverter.ToString(encoded);
            return string.Join("", response.Split('-'));
        }

        private string ReduceToFiftyCharactersInternal(params string?[] value)
        {
            var result = string.Join("", value);
            var underFiftyCharacters = result.Length > 50 ? result.Substring(0, 50) : result;
            return underFiftyCharacters;
        }
    }
}
