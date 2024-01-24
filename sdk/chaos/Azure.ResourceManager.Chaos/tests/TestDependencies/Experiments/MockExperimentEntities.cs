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

        public ChaosExperimentData GetVmssShutdownV2v0Experiment()
        {
            _ = vmssName ?? throw new ArgumentNullException(nameof(vmssName));
            IEnumerable<Models.ChaosKeyValuePair> actionParams = new List<Models.ChaosKeyValuePair>() { new Models.ChaosKeyValuePair("abruptShutdown", "true") };
            Models.ChaosExperimentAction action = new ChaosContinuousAction(
                "urn:csci:microsoft:virtualMachineScaleSet:shutdown/2.0",
                TimeSpan.FromMinutes(2),
                actionParams,
                "selector1");
            IEnumerable<Models.ChaosExperimentAction> actions = new List<Models.ChaosExperimentAction>() { action };
            IEnumerable<Models.ChaosExperimentBranch> branches = new List<Models.ChaosExperimentBranch>() { new Models.ChaosExperimentBranch("branch1", actions) };
            IEnumerable<Models.ChaosExperimentStep> steps = new List<Models.ChaosExperimentStep>() { new Models.ChaosExperimentStep ("step1", branches) };
            IEnumerable<Models.ChaosTargetReference> targets = new List<Models.ChaosTargetReference>() { new Models.ChaosTargetReference(ChaosTargetReferenceType.ChaosTarget, new ResourceIdentifier($"/subscriptions/{this.subscriptionId}/resourceGroups/{this.resourceGroup}/providers/Microsoft.Compute/virtualMachineScaleSets/{this.vmssName}/providers/Microsoft.Chaos/targets/microsoft-virtualMachineScaleSet")) };
            IEnumerable<Models.ChaosTargetSelector> selectors = new List<Models.ChaosTargetSelector>() { new Models.ChaosTargetListSelector ("selector1", targets) };
            var experimentData = new ChaosExperimentData(AzureLocation.WestUS2, steps, selectors);
            experimentData.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            return experimentData;
        }
    }
}
