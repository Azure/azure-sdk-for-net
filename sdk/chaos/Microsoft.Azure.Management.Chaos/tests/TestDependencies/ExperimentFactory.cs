// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Chaos.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Chaos.Tests.TestDependencies
{
    internal static class ExperimentFactory
    {
        internal static Experiment CreateDelayActionExperiment(string experimentName, string branchName, string stepName, string location, string principalId, string tenantId)
        {
            var selectors = new List<Selector>
            {
                {
                    new Selector(SelectorType.List, "Selector1", new List<TargetReference>
                    {
                        { new TargetReference(id: string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.DocumentDb/databaseAccounts/msft-chaos-cosmos/providers/Microsoft.Chaos/targets/microsoft-cosmosdb", TestConstants.DefaultTestSubscriptionId, TestConstants.ResourceGroupName)) },
                    })
                },
            };

            var delayActions = new List<Action>
            {
                { new DelayAction(name: "urn:csci:microsoft:chaosStudio:TimedDelay/1.0", duration: "PT1M") },
            };
            var delayActionBranches = new List<Branch>
            {
                { new Branch(branchName, delayActions) },
            };
            var delayActionExperimentSteps = new List<Step>
            {
                { new Step(stepName, delayActionBranches) },
            };

            return new Experiment(
                location: location,
                identity: new ResourceIdentity(ResourceIdentityType.SystemAssigned),
                type: TestConstants.ExperimentResourceType,
                name: experimentName,
                steps: delayActionExperimentSteps,
                selectors: selectors);
        }
    }
}
