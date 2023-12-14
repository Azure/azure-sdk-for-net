// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Chaos.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Chaos.Tests.TestDependencies.Experiments
{
    public class MockExperimentEntities
    {
        private readonly string subscriptionId;
        private readonly string resourceGroup;
        private readonly string vmssName;

        public MockExperimentEntities(string subscriptionId, string resourceGroup, string vmssName)
        {
            this.subscriptionId = subscriptionId ?? throw new ArgumentNullException(nameof(subscriptionId));
            this.resourceGroup = resourceGroup ?? throw new ArgumentNullException(nameof(resourceGroup));
            this.vmssName = vmssName ?? throw new ArgumentNullException(nameof(vmssName));
         }

        public ExperimentData GetVmssShutdownV2v0Experiment()
        {
            _ = vmssName ?? throw new ArgumentNullException(nameof(vmssName));
            IEnumerable<Models.KeyValuePair> actionParams = new List<Models.KeyValuePair>() { new Models.KeyValuePair("abruptShutdown", "true") };
            Models.Action action = new ContinuousAction(
                "urn:csci:microsoft:virtualMachineScaleSet:shutdown/2.0",
                TimeSpan.FromMinutes(2),
                actionParams,
                "selector1");
            IEnumerable<Models.Action> actions = new List<Models.Action>() { action };
            IEnumerable<Models.Branch> branches = new List<Models.Branch>() { new Models.Branch("branch1", actions) };
            IEnumerable<Models.Step> steps = new List<Models.Step>() { new Models.Step("step1", branches) };
            IEnumerable<Models.TargetReference> targets = new List<Models.TargetReference>() { new Models.TargetReference(TargetReferenceType.ChaosTarget, $"/subscriptions/{this.subscriptionId}/resourceGroups/{this.resourceGroup}/providers/Microsoft.Compute/virtualMachineScaleSets/{this.vmssName}/providers/Microsoft.Chaos/targets/microsoft-virtualMachineScaleSet") };
            IEnumerable<Models.Selector> selectors = new List<Models.Selector>() { new Models.ListSelector("selector1", targets) };
            var experimentData = new ExperimentData(AzureLocation.WestUS2, steps, selectors);
            experimentData.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            return experimentData;
        }
    }
}
