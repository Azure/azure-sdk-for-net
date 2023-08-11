// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests
{
    internal class TasksTest : EasmClientTest
    {
        private string ExistingTaskId;
        private string CancelTaskId;

        public TasksTest(bool isAsync) : base(isAsync)
        {
            ExistingTaskId = "62ccdc21-a3d8-434e-8f3d-fc08c7e45796";
            CancelTaskId = "62ccdc21-a3d8-434e-8f3d-fc08c7e45796";
        }

        [RecordedTest]
        public async Task TasksListTest()
        {
            Response<TaskPageResult> response = await client.GetTasksAsync();
            TaskResource taskResponse = response.Value.Value[0];
            Assert.IsNotEmpty(UUID_REGEX.Matches(taskResponse.Id));
        }

        [RecordedTest]
        public async Task TasksGetTest()
        {
            Response<TaskResource> response = await client.GetTaskAsync(ExistingTaskId);
            TaskResource taskResponse = response.Value;
            Assert.IsNotEmpty(UUID_REGEX.Matches(taskResponse.Id));
        }

        [RecordedTest]
        public async Task TasksCancelTest()
        {
            Response<TaskResource> response = await client.CancelTaskAsync(CancelTaskId);
            TaskResource taskResponse = response.Value;
            Assert.IsNotEmpty(UUID_REGEX.Matches(taskResponse.Id));
        }
    }
}
