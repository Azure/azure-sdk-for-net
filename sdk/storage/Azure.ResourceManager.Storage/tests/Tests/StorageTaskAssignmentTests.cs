// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using Azure.Core;
using Azure.ResourceManager.Models;
using System;
using Azure.Core.TestFramework.Models;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Azure.ResourceManager.Storage.Tests
{
    public class StorageTaskAssignmentTests : StorageManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private StorageAccountResource _storageAccount;
        private StorageTaskAssignmentCollection _storageTaskAssignmentCollection;
        private ResourceIdentifier _storageTaskId;
        public StorageTaskAssignmentTests(bool async) : base(async) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task CreateStorageAccount()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var storageTask = await CreateStorageTaskAsync();
            _storageTaskId = storageTask.Id;

            string accountName = await CreateValidAccountNameAsync("teststoragemgmt");
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            _storageAccount = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), kind: StorageKind.StorageV2, location: "eastus2"))).Value;
            _storageTaskAssignmentCollection = _storageAccount.GetStorageTaskAssignments();
        }

        [TearDown]
        public async Task ClearStorageAccount()
        {
            if (_resourceGroup != null)
            {
                StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
                await foreach (StorageAccountResource account in storageAccountCollection.GetAllAsync())
                {
                    await account.DeleteAsync(WaitUntil.Completed);
                }
                await _resourceGroup.DeleteAsync(WaitUntil.Started);
                _resourceGroup = null;
                _storageAccount = null;
            }
        }

        private async Task<GenericResource> CreateStorageTaskAsync()
        {
            string storageTaskName = Recording.GenerateAssetName("testtask");
            ResourceIdentifier storageTaskId = new ResourceIdentifier($"{_resourceGroup.Id}/providers/Microsoft.StorageActions/storageTasks/{storageTaskName}");

            var input = new GenericResourceData("eastus2")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.None),
                Properties = BinaryData.FromString("{\r\n    \"action\": {\r\n      \"if\": {\r\n        \"condition\": \"[[equals(AccessTier, 'Cool')]]\",\r\n        \"operations\": [\r\n          {\r\n            \"name\": \"DeleteBlob\",\r\n            \"onSuccess\": \"continue\",\r\n            \"onFailure\": \"break\"\r\n          }\r\n        ]\r\n      }\r\n    },\r\n    \"enabled\": true,\r\n    \"description\": \"test description\"\r\n  }")
            };
            var response = await Client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, storageTaskId, input);
            return response.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateUpdateGetDeleteTaskAssignement()
        {
            //create TaskAssignement
            string taskAssignementName = Recording.GenerateAssetName("taskassignement1");
            StorageTaskAssignmentProperties assignmentProperties = new StorageTaskAssignmentProperties(
                _storageTaskId,
                false,
                "test storage task assignment 1",
                new StorageTaskAssignmentExecutionContext(
                    new ExecutionTarget(
                        new string[] { "prefix1", "prefix2" },
                        new string[] { },
                        null),
                    new ExecutionTrigger(
                        ExecutionTriggerType.OnSchedule,
                        new ExecutionTriggerParameters(
                            new DateTimeOffset(2025, 7, 1, 1, 1, 1, new TimeSpan()),
                            10,
                            ExecutionIntervalUnit.Days,
                            new DateTimeOffset(2025, 8, 1, 1, 1, 1, new TimeSpan()),
                            null,
                            null)),
                    null),
                report: new StorageTaskAssignmentReport("containers"));
            var taskAssignment1 = (await _storageTaskAssignmentCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                taskAssignementName,
                new StorageTaskAssignmentData(assignmentProperties))).Value;

            //validate
            Assert.AreEqual(taskAssignementName, taskAssignment1.Data.Name);
            Assert.AreEqual(assignmentProperties.TaskId, taskAssignment1.Data.Properties.TaskId);
            Assert.AreEqual(assignmentProperties.IsEnabled, taskAssignment1.Data.Properties.IsEnabled);
            Assert.AreEqual(assignmentProperties.Description, taskAssignment1.Data.Properties.Description);
            Assert.AreEqual(assignmentProperties.Report.Prefix, taskAssignment1.Data.Properties.Report.Prefix);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Target.Prefix, taskAssignment1.Data.Properties.ExecutionContext.Target.Prefix);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Target.ExcludePrefix, taskAssignment1.Data.Properties.ExecutionContext.Target.ExcludePrefix);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.TriggerType, taskAssignment1.Data.Properties.ExecutionContext.Trigger.TriggerType);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.StartFrom, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.StartFrom);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.Interval, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.Interval);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.IntervalUnit, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.IntervalUnit);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.EndBy, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.EndBy);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.StartOn, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.StartOn);

            // Get TaskAssignement
            taskAssignment1 = (await taskAssignment1.GetAsync()).Value;

            //validate
            Assert.AreEqual(taskAssignementName, taskAssignment1.Data.Name);
            Assert.AreEqual(assignmentProperties.TaskId, taskAssignment1.Data.Properties.TaskId);
            Assert.AreEqual(assignmentProperties.IsEnabled, taskAssignment1.Data.Properties.IsEnabled);
            Assert.AreEqual(assignmentProperties.Description, taskAssignment1.Data.Properties.Description);
            Assert.AreEqual(assignmentProperties.Report.Prefix, taskAssignment1.Data.Properties.Report.Prefix);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Target.Prefix, taskAssignment1.Data.Properties.ExecutionContext.Target.Prefix);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Target.ExcludePrefix, taskAssignment1.Data.Properties.ExecutionContext.Target.ExcludePrefix);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.TriggerType, taskAssignment1.Data.Properties.ExecutionContext.Trigger.TriggerType);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.StartFrom, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.StartFrom);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.Interval, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.Interval);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.IntervalUnit, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.IntervalUnit);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.EndBy, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.EndBy);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.StartOn, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.StartOn);

            //udpate TaskAssignement
            var assignmentPatchProperties = new StorageTaskAssignmentPatchProperties(
                assignmentProperties.TaskId,
                true,
                "test storage task assignment 2",
                new StorageTaskAssignmentUpdateExecutionContext(
                    new ExecutionTarget(
                        new string[] { "prefix1" },
                        new string[] { "prefix3", "prefix4" },
                        null),
                    null,
                    null),
                new StorageTaskAssignmentUpdateReport("container2", null),
                null,
                null,
                null);
            taskAssignment1 = (await taskAssignment1.UpdateAsync(
                WaitUntil.Completed,
                new StorageTaskAssignmentPatch(assignmentPatchProperties, null))).Value;

            //validate
            Assert.AreEqual(taskAssignementName, taskAssignment1.Data.Name);
            Assert.AreEqual(assignmentPatchProperties.TaskId, taskAssignment1.Data.Properties.TaskId.ToString());
            Assert.AreEqual(assignmentPatchProperties.IsEnabled, taskAssignment1.Data.Properties.IsEnabled);
            Assert.AreEqual(assignmentPatchProperties.Description, taskAssignment1.Data.Properties.Description);
            Assert.AreEqual(assignmentPatchProperties.Report.Prefix, taskAssignment1.Data.Properties.Report.Prefix);
            Assert.AreEqual(assignmentPatchProperties.ExecutionContext.Target.Prefix, taskAssignment1.Data.Properties.ExecutionContext.Target.Prefix);
            Assert.AreEqual(assignmentPatchProperties.ExecutionContext.Target.ExcludePrefix, taskAssignment1.Data.Properties.ExecutionContext.Target.ExcludePrefix);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.TriggerType, taskAssignment1.Data.Properties.ExecutionContext.Trigger.TriggerType);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.StartFrom, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.StartFrom);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.Interval, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.Interval);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.IntervalUnit, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.IntervalUnit);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.EndBy, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.EndBy);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.StartOn, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.StartOn);

            // list single TaskAssignement
            taskAssignment1 = (await _storageTaskAssignmentCollection.GetAsync(taskAssignementName)).Value;

            //validate
            Assert.AreEqual(taskAssignementName, taskAssignment1.Data.Name);
            Assert.AreEqual(assignmentPatchProperties.TaskId, taskAssignment1.Data.Properties.TaskId.ToString());
            Assert.AreEqual(assignmentPatchProperties.IsEnabled, taskAssignment1.Data.Properties.IsEnabled);
            Assert.AreEqual(assignmentPatchProperties.Description, taskAssignment1.Data.Properties.Description);
            Assert.AreEqual(assignmentPatchProperties.Report.Prefix, taskAssignment1.Data.Properties.Report.Prefix);
            Assert.AreEqual(assignmentPatchProperties.ExecutionContext.Target.Prefix, taskAssignment1.Data.Properties.ExecutionContext.Target.Prefix);
            Assert.AreEqual(assignmentPatchProperties.ExecutionContext.Target.ExcludePrefix, taskAssignment1.Data.Properties.ExecutionContext.Target.ExcludePrefix);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.TriggerType, taskAssignment1.Data.Properties.ExecutionContext.Trigger.TriggerType);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.StartFrom, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.StartFrom);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.Interval, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.Interval);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.IntervalUnit, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.IntervalUnit);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.EndBy, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.EndBy);
            Assert.AreEqual(assignmentProperties.ExecutionContext.Trigger.Parameters.StartOn, taskAssignment1.Data.Properties.ExecutionContext.Trigger.Parameters.StartOn);

            //delete TaskAssignement
            try
            {
                await taskAssignment1.DeleteAsync(WaitUntil.Completed);
            }
            catch { }

            //validate if deleted successfully
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _storageTaskAssignmentCollection.GetAsync(taskAssignementName); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await _storageTaskAssignmentCollection.ExistsAsync(taskAssignementName));
        }

        [Test]
        [RecordedTest]
        public async Task ListStorageTaskAssignments()
        {
            //create TaskAssignement
            string taskAssignementName1 = Recording.GenerateAssetName("taskassignement1");
            string taskAssignementName2 = Recording.GenerateAssetName("taskassignement2");
            StorageTaskAssignmentProperties assignmentProperties = new StorageTaskAssignmentProperties(
                _storageTaskId,
                false,
                "test storage task assignment 1",
                new StorageTaskAssignmentExecutionContext(
                    new ExecutionTarget(
                        new string[] { "prefix1", "prefix2" },
                        new string[] { },
                        null),
                    new ExecutionTrigger(
                        ExecutionTriggerType.RunOnce,
                        new ExecutionTriggerParameters(null,null,null,null,
                            startOn: new DateTimeOffset(2025, 8, 1, 1, 1, 1, new TimeSpan()),
                            null)),
                    null),
                report: new StorageTaskAssignmentReport("container1"));
            var taskAssignment1 = (await _storageTaskAssignmentCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                taskAssignementName1,
                new StorageTaskAssignmentData(assignmentProperties))).Value;
            var taskAssignment2 = (await _storageTaskAssignmentCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                taskAssignementName2,
                new StorageTaskAssignmentData(assignmentProperties))).Value;

            // list TaskAssignmentInstancesReport
            var assignments = await _storageTaskAssignmentCollection.GetAllAsync(maxpagesize:1).ToEnumerableAsync();
            Assert.IsTrue(assignments.Count >= 2);
        }

        [Test]
        [RecordedTest]
        public async Task ListStorageTaskAssignmentsInstancesReport()
        {
            var reports = await _storageAccount.GetStorageTaskAssignmentsInstancesReportsAsync().ToEnumerableAsync();
            Assert.AreEqual(0, reports.Count);
        }

        [Test]
        [RecordedTest]
        public async Task ListStorageTaskAssignmentInstancesReport()
        {
            //create TaskAssignement
            string taskAssignementName = Recording.GenerateAssetName("taskassignement");
            StorageTaskAssignmentProperties assignmentProperties = new StorageTaskAssignmentProperties(
                _storageTaskId,
                false,
                "test storage task assignment 1",
                new StorageTaskAssignmentExecutionContext(
                    new ExecutionTarget(
                        new string[] { "prefix1", "prefix2" },
                        new string[] { },
                        null),
                    new ExecutionTrigger(
                        ExecutionTriggerType.RunOnce,
                        new ExecutionTriggerParameters(null, null, null, null,
                            startOn: new DateTimeOffset(2025, 8, 1, 1, 1, 1, new TimeSpan()),
                            null)),
                    null),
                report: new StorageTaskAssignmentReport("container1"));
            var taskAssignment = (await _storageTaskAssignmentCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                taskAssignementName,
                new StorageTaskAssignmentData(assignmentProperties))).Value;

            // list TaskAssignmentInstancesReport
            var reports = await taskAssignment.GetStorageTaskAssignmentInstancesReportsAsync(maxpagesize: 3, null).ToEnumerableAsync();
            Assert.AreEqual(0, reports.Count);
        }
    }
}
