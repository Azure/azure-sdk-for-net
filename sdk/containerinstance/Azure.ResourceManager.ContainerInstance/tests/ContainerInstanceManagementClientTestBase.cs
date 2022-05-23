// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerInstance.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.ContainerInstance.Tests
{
    public abstract class ContainerInstanceManagementClientTestBase : ManagementRecordedTestBase<ContainerInstanceManagementTestEnvironment>
    {
        public string ResourceGroupPrefix { get; private set; }
        public string ResourceLocation { get; private set; }
        public ArmClient ArmClient { get; set; }

        protected ContainerInstanceManagementClientTestBase(bool isAsync)
            : base(isAsync)
        {
            Init();
        }

        protected ContainerInstanceManagementClientTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
            Init();
        }

        private void Init()
        {
            ResourceGroupPrefix = "ContainerGroup-RG-";
            ResourceLocation = "eastus";
        }

        internal async Task<ContainerGroupResource> CreateDefaultContainerGroup(string containerGroupName, ResourceGroupResource _resourceGroup)
        {
            var resourceRequests = new ResourceRequests(1.5, 1) { Gpu = new GpuResource(1, GpuSku.K80)};
            var container = new Container("demo1", "nginx", new ResourceRequirements(resourceRequests))
            {
                VolumeMounts = {
                    new VolumeMount("volume1", "/mnt/volume1") {  ReadOnly = false },
                    new VolumeMount("volume2", "/mnt/volume2") {  ReadOnly = false },
                    new VolumeMount("volume3", "/mnt/volume3") {  ReadOnly = true }
                }
            };
            ContainerGroupData data = new ContainerGroupData(ResourceLocation, new List<Container>{ container }, OperatingSystemTypes.Linux)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
                {
                    UserAssignedIdentities = { { new ResourceIdentifier("userassignedid"), new UserAssignedIdentity()} }
                },
                Diagnostics = new ContainerGroupDiagnostics()
                {
                    LogAnalytics = new LogAnalytics("workspaceid", "workspaceKey")
                    {
                        LogType = LogAnalyticsLogType.ContainerInsights,
                        Metadata = { { "test-key", "test-metadata-value" } }
                    }
                },
                SubnetIds = { { "subnetid" } }
            };
            var communicationServiceLro = await _resourceGroup.GetCommunicationServices().CreateOrUpdateAsync(WaitUntil.Completed, communicationServiceName, data);
            return communicationServiceLro.Value;
        }
    }
}
