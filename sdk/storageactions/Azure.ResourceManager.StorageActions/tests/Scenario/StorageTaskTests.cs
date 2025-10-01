// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageActions.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageActions.Tests.Scenario
{
    public class StorageTaskTests : StorageActionsManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private StorageTaskCollection _taskCollection;
        private StorageTaskOperationInfo _setBlobTierOp;
        private StorageTaskOperationInfo _deleteBlobOp;
        private StorageTaskOperationInfo _undeleteBlobOp;
        private StorageTaskOperationInfo _setBlobTagsOp;
        private StorageTaskOperationInfo _setBlobImmutabilityPolicyOp;
        private StorageTaskOperationInfo _setBlobLegalHoldOp;

        public StorageTaskTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task PrepareTest()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            _taskCollection = _resourceGroup.GetStorageTasks();
            PrepareOperations();
        }

        [TearDown]
        public async Task RemoveResourceGroup()
        {
            //remove all storage accounts under current resource group
            if (_resourceGroup != null)
            {
                await _resourceGroup.DeleteAsync(WaitUntil.Started);
            }
        }

        [Test]
        [RecordedTest]
        public async Task CreateUpdateGetDelete()
        {
            string storageTaskName = Recording.GenerateAssetName("sdktest");

            StorageTaskData taskData = new StorageTaskData(
                new AzureLocation("eastus2"),
                new ManagedServiceIdentity("SystemAssigned"),
                new StorageTaskProperties(
                    true,
                    "My Storage task",
                    new StorageTaskAction(
                        new StorageTaskIfCondition("[[equals(AccessTier, 'Cool')]]", new StorageTaskOperationInfo[] { _deleteBlobOp }),
                        new StorageTaskElseCondition(new StorageTaskOperationInfo[] { _undeleteBlobOp, _setBlobTagsOp, _setBlobTierOp, _setBlobLegalHoldOp, _setBlobImmutabilityPolicyOp }),
                        null)));

            // Create
            StorageTaskResource storageTask = (await _taskCollection.CreateOrUpdateAsync(WaitUntil.Completed, storageTaskName, taskData)).Value;
            CompareStorageTaskData(taskData, storageTask.Data);

            storageTask = (await storageTask.GetAsync()).Value;
            CompareStorageTaskData(taskData, storageTask.Data);

            StorageTaskUpdateProperties updateProperties = new StorageTaskUpdateProperties()
            {
                Enabled = false,
                Description = "sdk test patch description",
                Action = new StorageTaskAction(
                        new StorageTaskIfCondition("[[equals(AccessTier, 'Cool')]]", new StorageTaskOperationInfo[] { _undeleteBlobOp }),
                        new StorageTaskElseCondition(new StorageTaskOperationInfo[] { _setBlobLegalHoldOp }),
                        null)
            };

            // Prepare task data to Patch
            StorageTaskPatch taskPatch = new StorageTaskPatch(
                new ManagedServiceIdentity("SystemAssigned"),
                new Dictionary<string, string>()
                {
                    ["tag1"] = "value1",
                    ["tag2"] = "value2",
                },
                updateProperties,
                null);

            //Patch
            storageTask = (await storageTask.UpdateAsync(WaitUntil.Completed, taskPatch)).Value;
            CompareStorageTaskPatch(storageTask.Data, taskPatch);

            storageTask = (await storageTask.GetAsync()).Value;
            CompareStorageTaskPatch(storageTask.Data, taskPatch);

            // Delete
            var operation = await storageTask.DeleteAsync(WaitUntil.Completed);
            bool storageTaskExist = true;
            try
            {
                storageTask = (await storageTask.GetAsync()).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                storageTaskExist = false;
            }
            Assert.IsFalse(storageTaskExist, "StorageTask should not exist after delete.");
        }

        [Test]
        [RecordedTest]
        public async Task List()
        {
            string storageTaskName1 = Recording.GenerateAssetName("sdktest1");
            string storageTaskName2 = Recording.GenerateAssetName("sdktest2");

            // Create task1
            StorageTaskData taskData1 = new StorageTaskData(
                new AzureLocation("eastus2"),
                new ManagedServiceIdentity("SystemAssigned"),
                new StorageTaskProperties(
                    true,
                    "My Storage task1",
                    new StorageTaskAction(
                        new StorageTaskIfCondition("[[equals(AccessTier, 'Cool')]]", new StorageTaskOperationInfo[] { _undeleteBlobOp, _setBlobTagsOp }),
                        null,
                        null)));
            StorageTaskResource storageTask1 = (await _taskCollection.CreateOrUpdateAsync(WaitUntil.Completed, storageTaskName1, taskData1)).Value;
            CompareStorageTaskData(taskData1, storageTask1.Data);

            // Create task2
            StorageTaskData taskData2 = new StorageTaskData(
                new AzureLocation("eastus2"),
                new ManagedServiceIdentity("SystemAssigned"),
                new StorageTaskProperties(
                    true,
                    "My Storage task2",
                    new StorageTaskAction(
                        new StorageTaskIfCondition("[[equals(AccessTier, 'Cool')]]", new StorageTaskOperationInfo[] { _undeleteBlobOp, _setBlobTagsOp }),
                        new StorageTaskElseCondition(new StorageTaskOperationInfo[] { _setBlobTierOp, _setBlobImmutabilityPolicyOp }),
                        null)));
            StorageTaskResource storageTask2 = (await _taskCollection.CreateOrUpdateAsync(WaitUntil.Completed, storageTaskName2, taskData2)).Value;
            CompareStorageTaskData(taskData2, storageTask2.Data);

            // List
            int count = 0;
            await foreach (StorageTaskResource taskResource in _taskCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [Test]
        [RecordedTest]
        public async Task PreviewAction()
        {
            string storageTaskName = Recording.GenerateAssetName("sdktest");

            StorageTaskData taskData = new StorageTaskData(
                new AzureLocation("eastus2"),
                new ManagedServiceIdentity("SystemAssigned"),
                new StorageTaskProperties(
                    true,
                    "My Storage task",
                    new StorageTaskAction(
                        new StorageTaskIfCondition("[[equals(AccessTier, 'Cool')]]", new StorageTaskOperationInfo[] { _deleteBlobOp }),
                        new StorageTaskElseCondition(new StorageTaskOperationInfo[] { _undeleteBlobOp, _setBlobTagsOp, _setBlobTierOp, _setBlobLegalHoldOp, _setBlobImmutabilityPolicyOp }),
                        null)));

            // Create
            StorageTaskResource storageTask = (await _taskCollection.CreateOrUpdateAsync(WaitUntil.Completed, storageTaskName, taskData)).Value;
            CompareStorageTaskData(taskData, storageTask.Data);

            // invoke preview action
            StorageTaskPreviewAction storageTaskPreviewAction = new StorageTaskPreviewAction(
                new StorageTaskPreviewActionProperties(new StorageTaskPreviewContainerProperties
                {
                    Name = "firstContainer",
                    Metadata = {new StorageTaskPreviewKeyValueProperties
                        {
                            Key = "mContainerKey1",
                            Value = "mContainerValue1",
                        }},
                    },
                    new StorageTaskPreviewBlobProperties[]
                    {
                        new StorageTaskPreviewBlobProperties
                        {
                            Name = "folder1/file1.txt",
                            Properties = {
                                new StorageTaskPreviewKeyValueProperties
                                {
                                    Key = "Creation-Time",
                                    Value = "Wed, 07 Jun 2023 05:23:29 GMT",
                                },
                                new StorageTaskPreviewKeyValueProperties
                                {
                                    Key = "Last-Modified",
                                    Value = "Wed, 07 Jun 2023 05:23:29 GMT",
                                },
                                new StorageTaskPreviewKeyValueProperties
                                {
                                    Key = "TagCount",
                                    Value = "1",
                                }},
                            Metadata = {new StorageTaskPreviewKeyValueProperties
                            {
                                Key = "mKey1",
                                Value = "mValue1",
                            }},
                            Tags = {new StorageTaskPreviewKeyValueProperties
                            {
                                Key = "tKey1",
                                Value = "tValue1",
                            }},
                        },
                        new StorageTaskPreviewBlobProperties
                        {
                            Name = "folder2/file1.txt",
                            Properties = {new StorageTaskPreviewKeyValueProperties
                            {
                                Key = "Etag",
                                Value = "0x6FB67175454D36D",
                            }},
                            Metadata = {new StorageTaskPreviewKeyValueProperties
                            {
                                Key = "mKey2",
                                Value = "mValue2",
                            }},
                            Tags = {new StorageTaskPreviewKeyValueProperties
                            {
                                Key = "tKey2",
                                Value = "tValue2",
                            }},
                        }
                    },
                    new StorageTaskPreviewActionCondition(new StorageTaskPreviewActionIfCondition
                    {
                        Condition = "[[equals(AccessTier, 'Hot')]]",
                    }, true)));
            StorageTaskPreviewAction result = await DefaultSubscription.PreviewActionsAsync("eastus2", storageTaskPreviewAction);
            Assert.AreEqual(storageTaskPreviewAction.Properties.Container.Name, result.Properties.Container.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetTaskAssignment()
        {
            string storageTaskName = Recording.GenerateAssetName("sdktest");

            StorageTaskData taskData = new StorageTaskData(
                new AzureLocation("eastus2"),
                new ManagedServiceIdentity("SystemAssigned"),
                new StorageTaskProperties(
                    true,
                    "My Storage task",
                    new StorageTaskAction(
                        new StorageTaskIfCondition("[[equals(AccessTier, 'Cool')]]", new StorageTaskOperationInfo[] { _deleteBlobOp }),
                        new StorageTaskElseCondition(new StorageTaskOperationInfo[] { _undeleteBlobOp, _setBlobTagsOp, _setBlobTierOp, _setBlobLegalHoldOp, _setBlobImmutabilityPolicyOp }),
                        null)));

            // Create
            StorageTaskResource storageTask = (await _taskCollection.CreateOrUpdateAsync(WaitUntil.Completed, storageTaskName, taskData)).Value;
            CompareStorageTaskData(taskData, storageTask.Data);

            // Get task report
            int count = 0;
            await foreach (var taskAssignment in storageTask.GetStorageTaskAssignmentsAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 0);
        }

        [Test]
        [RecordedTest]
        public async Task GetTasksReport()
        {
            string storageTaskName = Recording.GenerateAssetName("sdktest");

            StorageTaskData taskData = new StorageTaskData(
                new AzureLocation("eastus2"),
                new ManagedServiceIdentity("SystemAssigned"),
                new StorageTaskProperties(
                    true,
                    "My Storage task",
                    new StorageTaskAction(
                        new StorageTaskIfCondition("[[equals(AccessTier, 'Cool')]]", new StorageTaskOperationInfo[] { _deleteBlobOp }),
                        new StorageTaskElseCondition(new StorageTaskOperationInfo[] { _undeleteBlobOp, _setBlobTagsOp, _setBlobTierOp, _setBlobLegalHoldOp, _setBlobImmutabilityPolicyOp }),
                        null)));

            // Create
            StorageTaskResource storageTask = (await _taskCollection.CreateOrUpdateAsync(WaitUntil.Completed, storageTaskName, taskData)).Value;
            CompareStorageTaskData(taskData, storageTask.Data);

            // Get task report
            int count = 0;
            await foreach (StorageTaskReportInstance taskReport in storageTask.GetStorageTasksReportsAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 0);
        }

        internal void CompareStorageTaskData(StorageTaskData expected, StorageTaskData actual)
        {
            Assert.AreEqual(expected.Location, actual.Location);
            Assert.AreEqual(expected.Identity.ManagedServiceIdentityType, actual.Identity.ManagedServiceIdentityType);
            // skip for server issue
            // Assert.AreEqual(expected.Tags, actual.Tags);
            CompareStorageTaskProperties(expected.Properties, actual.Properties);
        }

        internal void CompareStorageTaskPatch(StorageTaskData expected, StorageTaskPatch actual)
        {
            Assert.AreEqual(expected.Identity.ManagedServiceIdentityType, actual.Identity.ManagedServiceIdentityType);
            // skip for server issue
            // Assert.AreEqual(expected.Tags, actual.Tags);
            CompareStorageTaskProperties(expected.Properties, actual.Properties);
        }

        internal void CompareStorageTaskProperties(StorageTaskProperties expected, StorageTaskProperties actual)
        {
            Assert.AreEqual(expected.IsEnabled, actual.IsEnabled);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.Action.If.Condition, actual.Action.If.Condition);
            Assert.AreEqual(expected.Action.If.Operations.Count, actual.Action.If.Operations.Count);
            for (int i = 0; i < expected.Action.If.Operations.Count; i++)
            {
                CompareStorageTaskOperation(expected.Action.If.Operations[i], actual.Action.If.Operations[i]);
            }

            if (expected.Action.Else == null)
            {
                Assert.IsNull(actual.Action.Else);
            }
            else
            {
                Assert.AreEqual(expected.Action.Else.Operations.Count, actual.Action.Else.Operations.Count);
                for (int i = 0; i < expected.Action.Else.Operations.Count; i++)
                {
                    CompareStorageTaskOperation(expected.Action.Else.Operations[i], actual.Action.Else.Operations[i]);
                }
            }
        }

        internal void CompareStorageTaskProperties(StorageTaskProperties expected, StorageTaskUpdateProperties actual)
        {
            Assert.AreEqual(expected.IsEnabled, actual.Enabled);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.Action.If.Condition, actual.Action.If.Condition);
            Assert.AreEqual(expected.Action.If.Operations.Count, actual.Action.If.Operations.Count);
            for (int i = 0; i < expected.Action.If.Operations.Count; i++)
            {
                CompareStorageTaskOperation(expected.Action.If.Operations[i], actual.Action.If.Operations[i]);
            }

            if (expected.Action.Else == null)
            {
                Assert.IsNull(actual.Action.Else);
            }
            else
            {
                Assert.AreEqual(expected.Action.Else.Operations.Count, actual.Action.Else.Operations.Count);
                for (int i = 0; i < expected.Action.Else.Operations.Count; i++)
                {
                    CompareStorageTaskOperation(expected.Action.Else.Operations[i], actual.Action.Else.Operations[i]);
                }
            }
        }

        internal void CompareStorageTaskOperation(StorageTaskOperationInfo expected, StorageTaskOperationInfo actual)
        {
            Assert.AreEqual(expected.OnSuccess, actual.OnSuccess);
            Assert.AreEqual(expected.OnFailure, actual.OnFailure);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Parameters.Count, actual.Parameters.Count);
            foreach (var parameter in actual.Parameters)
            {
                {
                    Assert.AreEqual(parameter.Value, actual.Parameters[parameter.Key]);
                }
            }
        }

        internal void PrepareOperations()
        {
            _setBlobTierOp = new StorageTaskOperationInfo(StorageTaskOperationName.SetBlobTier)
            {
                Parameters =
                    {
                        ["tier"] = "Hot"
                    },
                OnSuccess = OnSuccessAction.Continue,
                OnFailure = OnFailureAction.Break,
            };
            _deleteBlobOp = new StorageTaskOperationInfo(StorageTaskOperationName.DeleteBlob)
            {
                OnSuccess = OnSuccessAction.Continue,
                OnFailure = OnFailureAction.Break,
            };
            _undeleteBlobOp = new StorageTaskOperationInfo(StorageTaskOperationName.UndeleteBlob)
            {
                OnSuccess = OnSuccessAction.Continue,
                OnFailure = OnFailureAction.Break,
            };
            _setBlobTagsOp = new StorageTaskOperationInfo(StorageTaskOperationName.SetBlobTags)
            {
                Parameters =
                    {
                        ["tag1"] = "value1",
                        ["tag2"] = "value2",
                    },
                OnSuccess = OnSuccessAction.Continue,
                OnFailure = OnFailureAction.Break,
            }
            ;
            _setBlobImmutabilityPolicyOp = new StorageTaskOperationInfo(StorageTaskOperationName.SetBlobImmutabilityPolicy)
            {
                Parameters =
                    {
                        ["untilDate"] = "2025-07-01T01:01:01",
                        ["mode"] = "locked",
                    },
                OnSuccess = OnSuccessAction.Continue,
                OnFailure = OnFailureAction.Break,
            };
            _setBlobLegalHoldOp = new StorageTaskOperationInfo(StorageTaskOperationName.SetBlobLegalHold)
            {
                Parameters =
                    {
                        ["legalHold"] = "true"
                    },
                OnSuccess = OnSuccessAction.Continue,
                OnFailure = OnFailureAction.Break,
            };
        }
    }
}
