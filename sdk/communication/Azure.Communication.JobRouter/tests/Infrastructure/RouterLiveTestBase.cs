// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Infrastructure
{
    public class RouterLiveTestBase : RecordedTestBase<RouterTestEnvironment>
    {
        internal ConcurrentBag<Task> _cleanupTasks;
        protected const string Delimeter = "-";

        public RouterLiveTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
            _cleanupTasks = new ConcurrentBag<Task>();
            Sanitizer = new RouterClientRecordedTestSanitizer();
        }

        [SetUp]
        public void SetIdPrefix()
        {
            IdPrefix = Recording.GetVariable("id-prefix", $"sdk-{GetSmallGuid()}-");
        }

        [OneTimeTearDown]
        public async Task CleanUp()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                // Cleanup resources only during Live and Record modes
                Parallel.ForEach(_cleanupTasks, t => t.Start());
                await Task.WhenAll(_cleanupTasks);
            }
        }

        protected RouterClient CreateRouterClientWithConnectionString()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            var client = new RouterClient(connectionString, CreateRouterClientOptionsWithCorrelationVectorLogs());
            var instrumentedRouterClient = InstrumentClient(client);
            return instrumentedRouterClient;
        }

        #region Support assertions

        protected void AssertQueueResponseIsEqual(Response<UpsertQueueResponse> upsertQueueResponse, string queueId, string distributionPolicyId, string? queueName = default, LabelCollection? queueLabels = default, string? exceptionPolicyId = default)
        {
            var response = upsertQueueResponse.Value;

            Assert.AreEqual(queueId, response.Id);
            Assert.AreEqual(queueName, response.Name);
            Assert.AreEqual(distributionPolicyId, response.DistributionPolicyId);
            if (queueLabels != default)
            {
                Assert.AreEqual(queueLabels, response.Labels);
            }

            if (exceptionPolicyId != default)
            {
                Assert.AreEqual(exceptionPolicyId, response.ExceptionPolicyId);
            }
        }

        protected void AssertRegisteredWorkerIsValid(Response<RouterWorker> routerWorkerResponse, string workerId, IEnumerable<string> queueAssignmentList, int? totalCapacity, LabelCollection? workerLabels = default, List<ChannelConfiguration>? channelConfigList = default)
        {
            var response = routerWorkerResponse.Value;

            Assert.AreEqual(workerId, response.Id);
            Assert.AreEqual(queueAssignmentList.Count(), response.QueueAssignments.Count);
            Assert.AreEqual(totalCapacity, response.TotalCapacity);
            Assert.AreEqual(workerLabels, response.Labels);

            if (channelConfigList != default)
            {
                Assert.AreEqual(channelConfigList.Count, response.ChannelConfigurations.Count);
            }
        }

        protected void AddForCleanup(Task t)
        {
            _cleanupTasks.Add(t);
        }

        #endregion

        #region private functions

        private RouterClientOptions CreateRouterClientOptionsWithCorrelationVectorLogs()
        {
            RouterClientOptions routerClientOptions = new RouterClientOptions();
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

        protected string ReduceToFiftyCharacters(params string?[] value)
        {
            var result = string.Join("", value);
            var underFiftyCharacters = result.Length > 50 ? result.Substring(0, 50) : result;
            return underFiftyCharacters;
        }
    }
}
