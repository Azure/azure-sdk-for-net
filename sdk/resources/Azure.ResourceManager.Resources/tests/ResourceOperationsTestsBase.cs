// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resource.Tests;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.Resources.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class ResourceOperationsTestsBase : ManagementRecordedTestBase<ResourceManagementTestEnvironment>
    {
        public ResourcesManagementClient ResourcesManagementClient { get; set; }
        public ResourceGroupsOperations ResourceGroupsOperations { get; set; }
        public DeploymentsOperations DeploymentsOperations { get; set; }
        public DeploymentScriptsOperations DeploymentScriptsOperations { get; set; }
        public DeploymentOperations DeploymentOperations { get; set; }
        public ProvidersOperations ProvidersOperations { get; set; }
        public ResourcesOperations ResourcesOperations { get; set; }
        public TagsOperations TagsOperations { get; set; }
        public SubscriptionsOperations SubscriptionsOperations { get; set; }
        public TenantsOperations TenantsOperations { get; set; }
        public PolicyAssignmentsOperations PolicyAssignmentsOperations { get; set; }
        public PolicyDefinitionsOperations PolicyDefinitionsOperations { get; set; }
        public PolicySetDefinitionsOperations PolicySetDefinitionsOperations { get; set; }

        protected ResourceOperationsTestsBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected void Initialize()
        {
            ResourcesManagementClient = GetResourceManagementClient();
            ResourceGroupsOperations = ResourcesManagementClient.ResourceGroups;
            DeploymentsOperations = ResourcesManagementClient.Deployments;
            DeploymentScriptsOperations = ResourcesManagementClient.DeploymentScripts;
            DeploymentOperations = ResourcesManagementClient.Deployment;
            ProvidersOperations = ResourcesManagementClient.Providers;
            ResourcesOperations = ResourcesManagementClient.Resources;
            TagsOperations = ResourcesManagementClient.Tags;
            SubscriptionsOperations = ResourcesManagementClient.Subscriptions;
            TenantsOperations = ResourcesManagementClient.Tenants;
            PolicyAssignmentsOperations = ResourcesManagementClient.PolicyAssignments;
            PolicyDefinitionsOperations = ResourcesManagementClient.PolicyDefinitions;
            PolicySetDefinitionsOperations = ResourcesManagementClient.PolicySetDefinitions;
        }
    }
}
