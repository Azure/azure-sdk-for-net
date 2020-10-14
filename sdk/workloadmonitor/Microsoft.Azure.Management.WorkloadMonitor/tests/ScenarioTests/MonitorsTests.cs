// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using WorkloadMonitor.Tests.Helpers;
using Microsoft.Azure.Management.WorkloadMonitor;
using Microsoft.Azure.Management.WorkloadMonitor.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System;
using System.Linq;

namespace WorkloadMonitor.Tests.ScenarioTests
{
    public class MonitorsTests : TestBase
    {
        private RecordedDelegatingHandler handler;
        private const string expectedMonitorsType = "microsoft.workloadmonitor/monitors";
        private const string expectedHistoryType = "microsoft.workloadmonitor/monitors/history";

        private readonly string subId = "bc27da3b-3ba2-4e00-a6ec-1fde64aa1e21";
        private readonly string rgName = "ZESUI-SCALE-RG";
        private readonly string resourceNamespace = "Microsoft.Compute";
        private readonly string resourceType = "virtualMachines";
        private readonly string resourceName = "zesui-lin55-s-vm";

        public MonitorsTests() : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListMonitorsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);

                // List monitors for the VM.
                IPage<Monitor> monitorListResult = workloadMonitorClient.Monitors.List(subId, rgName, resourceNamespace, resourceType, resourceName);

                if (!this.IsRecording)
                {
                    Assert.NotNull(monitorListResult);
                    CheckListedMonitors(monitorListResult);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListMonitorsExpandConfigurationTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);
                var expandConfiguration = "configuration";

                // List monitors for the VM.
                IPage<Monitor> monitorListResult = workloadMonitorClient.Monitors.List(subId, rgName, resourceNamespace, resourceType, resourceName, default, expandConfiguration);

                if (!this.IsRecording)
                {
                    Assert.NotNull(monitorListResult);
                    CheckListedMonitorsExpandConfig(monitorListResult);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListMonitorsExpandEvidenceTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);
                var expandConfiguration = "evidence";

                // List monitors for the VM.
                IPage<Monitor> monitorListResult = workloadMonitorClient.Monitors.List(subId, rgName, resourceNamespace, resourceType, resourceName, default, expandConfiguration);

                if (!this.IsRecording)
                {
                    Assert.NotNull(monitorListResult);
                    CheckListedMonitorsExpandEvidence(monitorListResult);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListMonitorsExpandConfigurationAndEvidenceTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);
                var expandConfiguration = "configuration,evidence";

                // List monitors for the VM.
                IPage<Monitor> monitorListResult = workloadMonitorClient.Monitors.List(subId, rgName, resourceNamespace, resourceType, resourceName, default, expandConfiguration);

                if (!this.IsRecording)
                {
                    Assert.NotNull(monitorListResult);
                    CheckListedMonitorsExpandConfigAndEvidence(monitorListResult);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListMonitorsFilterForRootTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);
                var rootName = "root";
                var filterForRoot = "monitorName eq '" + rootName + "'";

                // List monitors for the VM.
                IPage<Monitor> monitorListResult = workloadMonitorClient.Monitors.List(subId, rgName, resourceNamespace, resourceType, resourceName, filterForRoot);

                if (!this.IsRecording)
                {
                    Assert.NotNull(monitorListResult);
                    Assert.Single(monitorListResult);
                    Assert.Equal(rootName, monitorListResult.First().Name);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListMonitorsInvalidFilterTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);
                var filter = "bad-filter";

                var ex = Assert.Throws<DefaultErrorException>(() => workloadMonitorClient.Monitors.List(subId, rgName, resourceNamespace, resourceType, resourceName, filter));

                if (!this.IsRecording)
                {
                    Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetRootMonitorTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);
                var rootName = "root";

                // Get a monitor for the VM.
                Monitor monitorResult = workloadMonitorClient.Monitors.Get(subId, rgName, resourceNamespace, resourceType, resourceName, rootName);

                if (!this.IsRecording)
                {
                    Assert.NotNull(monitorResult);
                    Assert.Equal(rootName, monitorResult.Name);
                    Assert.Equal(rootName, monitorResult.MonitorName);
                    Assert.Equal(expectedMonitorsType, monitorResult.Type);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetFreeDiskMonitorTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);
                var monitorId = "filesystems|@2F|free-space";
                var monitorName = "filesystems|/|free-space";
                var monitorType = "filesystems|*|free-space";
                var monitoredObject = "/";

                // Get a monitor for the VM.
                Monitor monitorResult = workloadMonitorClient.Monitors.Get(subId, rgName, resourceNamespace, resourceType, resourceName, monitorId);

                if (!this.IsRecording)
                {
                    Assert.NotNull(monitorResult);
                    Assert.Equal(expectedMonitorsType, monitorResult.Type);
                    Assert.Equal(monitorId, monitorResult.Name);
                    Assert.Equal(monitorName, monitorResult.MonitorName);
                    Assert.Equal(monitorType, monitorResult.MonitorType);
                    Assert.Equal(monitoredObject, monitorResult.MonitoredObject);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetNonexistentMonitorIdTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);
                var monitorId = "fake-monitor";

                var ex = Assert.Throws<DefaultErrorException>(() => workloadMonitorClient.Monitors.Get(subId, rgName, resourceNamespace, resourceType, resourceName, monitorId));

                if (!this.IsRecording)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetRootMonitorHistoryTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);
                var monitorId = "root";

                // Get a monitor for the VM.
                IPage<MonitorStateChange> monitorHistoryResult = workloadMonitorClient.Monitors.ListStateChanges(subId, rgName, resourceNamespace, resourceType, resourceName, monitorId);

                if (!this.IsRecording)
                {
                    Assert.NotNull(monitorHistoryResult);
                    Assert.NotEmpty(monitorHistoryResult);
                    CheckMonitorHistory(monitorHistoryResult, monitorId);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetRootMonitorHistoryOnlyHeartbeatsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);
                var monitorId = "root";
                var onlyHbFilter = "isHeartbeat eq true";

                // Get a monitor for the VM.
                IPage<MonitorStateChange> monitorHistoryResult = workloadMonitorClient.Monitors.ListStateChanges(subId, rgName, resourceNamespace, resourceType, resourceName, monitorId, onlyHbFilter);

                if (!this.IsRecording)
                {
                    Assert.NotNull(monitorHistoryResult);
                    Assert.NotEmpty(monitorHistoryResult);
                    CheckMonitorHistoryOnlyHeartbeats(monitorHistoryResult, monitorId);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetRootMonitorHistoryNoHeartbeatsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);
                var monitorId = "root";
                var noHbFilter = "isHeartbeat eq false";

                // Get a monitor for the VM.
                IPage<MonitorStateChange> monitorHistoryResult = workloadMonitorClient.Monitors.ListStateChanges(subId, rgName, resourceNamespace, resourceType, resourceName, monitorId, noHbFilter);

                if (!this.IsRecording)
                {
                    Assert.NotNull(monitorHistoryResult);
                    Assert.Empty(monitorHistoryResult);
                    CheckMonitorHistoryNoHeartbeats(monitorHistoryResult, monitorId);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetCpuMonitorStateChangeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);
                var monitorId = "cpu-utilization";
                var timestampUtc = "1602185025000";

                // Get a monitor for the VM.
                MonitorStateChange monitorStateChangeResult = workloadMonitorClient.Monitors.GetStateChange(subId, rgName, resourceNamespace, resourceType, resourceName, monitorId, timestampUtc);

                if (!this.IsRecording)
                {
                    Assert.NotNull(monitorStateChangeResult);
                    Assert.Equal(timestampUtc, monitorStateChangeResult.Name);
                    Assert.Equal(monitorId, monitorStateChangeResult.MonitorName);
                    Assert.Equal(expectedHistoryType, monitorStateChangeResult.Type);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetCpuMonitorStateChangeIncorrectTimestampTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);
                var monitorId = "cpu-utilization";
                var timestampUtc = "1602185025002";

                var ex = Assert.Throws<DefaultErrorException>(() => workloadMonitorClient.Monitors.GetStateChange(subId, rgName, resourceNamespace, resourceType, resourceName, monitorId, timestampUtc));

                if (!this.IsRecording)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
        }

        private static void CheckListedMonitors(IPage<Monitor> monitorListResult)
        {
            List<String> expectedNames = new List<String>
            {
                "cpu-utilization",
                "filesystems",
                "filesystems|@2Fmnt",
                "filesystems|@2F",
                "filesystems|@2Fmnt|free-space",
                "filesystems|@2F|free-space",
                "memory",
                "memory|available",
                "root"
            };

            var enumerator = monitorListResult.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Monitor current = enumerator.Current;
                Assert.Contains(current.Name, expectedNames);
                Assert.NotNull(current.CurrentMonitorState);
                Assert.Equal(expectedMonitorsType, current.Type);
            }
        }

        private static void CheckListedMonitorsExpandConfig(IPage<Monitor> monitorListResult)
        {
            var enumerator = monitorListResult.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Monitor current = enumerator.Current;
                Assert.NotNull(current.MonitorConfiguration);
                Assert.Null(current.Evidence);
                Assert.Equal(expectedMonitorsType, current.Type);
            }
        }

        private static void CheckListedMonitorsExpandEvidence(IPage<Monitor> monitorListResult)
        {
            var enumerator = monitorListResult.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Monitor current = enumerator.Current;
                Assert.Null(current.MonitorConfiguration);
                Assert.NotNull(current.Evidence);
                Assert.Equal(expectedMonitorsType, current.Type);
            }
        }

        private static void CheckListedMonitorsExpandConfigAndEvidence(IPage<Monitor> monitorListResult)
        {
            var enumerator = monitorListResult.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Monitor current = enumerator.Current;
                Assert.NotNull(current.MonitorConfiguration);
                Assert.NotNull(current.Evidence);
                Assert.Equal(expectedMonitorsType, current.Type);
            }
        }

        private static void CheckMonitorHistory(IPage<MonitorStateChange> monitorHistoryResult, string expectedName)
        {
            var enumerator = monitorHistoryResult.GetEnumerator();
            while (enumerator.MoveNext())
            {
                MonitorStateChange current = enumerator.Current;
                Assert.Equal(current.MonitorName, expectedName);
                Assert.Equal(expectedHistoryType, current.Type);
            }
        }

        private static void CheckMonitorHistoryNoHeartbeats(IPage<MonitorStateChange> monitorHistoryResult, string expectedName)
        {
            var enumerator = monitorHistoryResult.GetEnumerator();
            while (enumerator.MoveNext())
            {
                MonitorStateChange current = enumerator.Current;
                Assert.Equal(current.MonitorName, expectedName);
                Assert.NotEqual(current.PreviousMonitorState, current.CurrentMonitorState);
                Assert.Equal(expectedHistoryType, current.Type);
            }
        }

        private static void CheckMonitorHistoryOnlyHeartbeats(IPage<MonitorStateChange> monitorHistoryResult, string expectedName)
        {
            var enumerator = monitorHistoryResult.GetEnumerator();
            while (enumerator.MoveNext())
            {
                MonitorStateChange current = enumerator.Current;
                Assert.Equal(current.MonitorName, expectedName);
                Assert.Equal(current.PreviousMonitorState, current.CurrentMonitorState);
                Assert.Equal(expectedHistoryType, current.Type);
            }
        }
    }
}
