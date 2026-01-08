// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DefenderEasm.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DefenderEasm.Tests.Tests
{
    public class LabelResourceTest : DefenderEasmManagementTestBase
    {
        public LabelResourceTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("Service not ready.")]
        public async Task LabelCRUDTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(TestEnvironment.ResourceGroupName);
            EasmWorkspaceResource workspace = await resourceGroup.GetEasmWorkspaceAsync(TestEnvironment.WorkspaceName);
            EasmLabelCollection labels = workspace.GetEasmLabels();
            String labelName = Recording.GenerateAssetName("label");
            String newLabelName = Recording.GenerateAssetName("label");
            String color = "red";
            String newColor = "blue";

            // create
            EasmLabelData labelResourceData = new EasmLabelData();
            labelResourceData.Color = color;
            var createLabelOperation = await labels.CreateOrUpdateAsync(WaitUntil.Completed, labelName, labelResourceData);
            Assert.Multiple(() =>
            {
                Assert.That(createLabelOperation.Value.Data.Name, Is.EqualTo(labelName));
                Assert.That(createLabelOperation.Value.Data.Color, Is.EqualTo(color));
            });

            // get
            EasmLabelResource getLabelOperation = await labels.GetAsync(labelName);
            Assert.Multiple(() =>
            {
                Assert.That(getLabelOperation.Data.Name, Is.EqualTo(labelName));
                Assert.That(getLabelOperation.Data.Color, Is.EqualTo(color));
            });

            // update
            EasmLabelPatch labelResourcePatch = new EasmLabelPatch();
            labelResourcePatch.Color = newColor;
            labelResourcePatch.DisplayName = newLabelName;
            EasmLabelResource updateLabelOperation = await getLabelOperation.UpdateAsync(labelResourcePatch);
            Assert.Multiple(() =>
            {
                Assert.That(updateLabelOperation.Data.DisplayName, Is.EqualTo(newLabelName));
                Assert.That(updateLabelOperation.Data.Color, Is.EqualTo(newColor));
            });

            // delete
            EasmLabelResource labelResource = await workspace.GetEasmLabelAsync(labelName);
            ArmOperation op = await labelResource.DeleteAsync(WaitUntil.Completed);
            Assert.That(op.HasCompleted, Is.True);
        }
    }
}
