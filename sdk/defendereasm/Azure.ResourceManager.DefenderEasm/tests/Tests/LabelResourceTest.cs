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

        [TestCase]
        [RecordedTest]
        public async Task LabelCRUDTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(TestEnvironment.ResourceGroupName);
            WorkspaceResource workspace = await resourceGroup.GetWorkspaceResourceAsync(TestEnvironment.WorkspaceName);
            LabelResourceCollection labels = workspace.GetLabelResources();
            String labelName = Recording.GenerateAssetName("label");
            String newLabelName = Recording.GenerateAssetName("label");
            String color = "red";
            String newColor = "blue";

            // create
            LabelResourceData labelResourceData = new LabelResourceData();
            labelResourceData.Color = color;
            var createLabelOperation = await labels.CreateOrUpdateAsync(WaitUntil.Completed, labelName, labelResourceData);
            Assert.AreEqual(labelName, createLabelOperation.Value.Data.Name);
            Assert.AreEqual(color, createLabelOperation.Value.Data.Color);

            // get
            LabelResource getLabelOperation = await labels.GetAsync(labelName);
            Assert.AreEqual(labelName, getLabelOperation.Data.Name);
            Assert.AreEqual(color, getLabelOperation.Data.Color);

            // update
            LabelResourcePatch labelResourcePatch = new LabelResourcePatch();
            labelResourcePatch.Color = newColor;
            labelResourcePatch.DisplayName = newLabelName;
            LabelResource updateLabelOperation = await getLabelOperation.UpdateAsync(labelResourcePatch);
            Assert.AreEqual(newLabelName, updateLabelOperation.Data.DisplayName);
            Assert.AreEqual(newColor, updateLabelOperation.Data.Color);

            // delete
            LabelResource labelResource = await workspace.GetLabelResourceAsync(labelName);
            ArmOperation op = await labelResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(op.HasCompleted);
        }
    }
}
