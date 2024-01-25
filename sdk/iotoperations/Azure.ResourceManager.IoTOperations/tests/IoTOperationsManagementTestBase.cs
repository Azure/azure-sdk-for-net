// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IoTOperations.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.ResourceManager.IoTOperations.Tests
{
    public class IoTOperationsManagementTestBase : ManagementRecordedTestBase<IoTOperationsManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ArmClient ArmClient { get; private set; }
        public ResourceGroupCollection ResourceGroupsOperations { get; set; }
        public SubscriptionResource Subscription { get; set; }

        protected IoTOperationsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected IoTOperationsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected async Task InitializeClients()
        {
            ArmClient = GetArmClient();
            Subscription = await ArmClient.GetDefaultSubscriptionAsync();
            ResourceGroupsOperations = Subscription.GetResourceGroups();
        }

        public async Task<ResourceGroupResource> GetResourceGroupAsync(string name)
        {
            return await Subscription.GetResourceGroups().GetAsync(name);
        }

        protected async Task<TargetCollection> GetTargetsResourceCollectionAsync(string resourceGroupName)
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            return rg.GetTargets();
        }
        protected async Task<InstanceCollection> GetInstancesResourceCollectionAsync(string resourceGroupName)
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            return rg.GetInstances();
        }

        protected async Task<SolutionCollection> GetSolutionsResourceCollectionAsync(string resourceGroupName)
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            return rg.GetSolutions();
        }

        protected static ComponentProperties GetComponentProperties()
        {
            return new ComponentProperties("basic-configmap", "yaml.k8s")
            {
                Name = "basic-configmap",
                Properties = {
                    { "resource", BinaryData.FromObjectAsJson(new {
                        apiVersion = "v1",
                        kind= "ConfigMap",
                        metadata = new {
                            name = "basic-configmap-1"
                        },
                        data = new {
                            foo = "bar",
                        }})
                    },
                 },
            };
        }

        protected static TopologiesProperties GetTopologiesProperties()
        {
            return new TopologiesProperties()
            {
                Bindings =
                    {
                        new BindingProperties(new Dictionary<string, BinaryData>()
                            {
                                { "inCluster", BinaryData.FromString("\"true\"") },
                            },
                            "providers.target.k8s",
                            "instance"
                        ),
                        new BindingProperties(new Dictionary<string, BinaryData>()
                            {
                                { "inCluster", BinaryData.FromString("\"true\"") },
                            },
                            "providers.target.helm",
                            "helm.v3"
                        ),
                        new BindingProperties(new Dictionary<string, BinaryData>()
                            {
                                { "inCluster", BinaryData.FromString("\"true\"") },
                            },
                            "providers.target.kubectl",
                            "yaml.k8s"
                        ),
                    },
            };
        }
        protected static ReconciliationPolicyModel GetReconciliationPolicy()
        {
            return new ReconciliationPolicyModel(ReconciliationPolicy.Periodic)
            {
                Interval = "1h",
            };
        }
    }
}
