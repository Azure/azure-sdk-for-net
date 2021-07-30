// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.MachineLearningServices.Models;
using Azure.ResourceManager.Resources.Models;
using ResourceIdentityType = Azure.ResourceManager.Resources.Models.ResourceIdentityType;

namespace Azure.ResourceManager.MachineLearningServices.Tests.Extensions
{
    public class ResourceDataCreationHelper
    {
        private readonly MachineLearningServicesManagerTestBase _testBase;

        public ResourceDataCreationHelper(MachineLearningServicesManagerTestBase testBase)
        {
            _testBase = testBase;
        }

        public WorkspaceData GenerateWorkspaceData()
        {
            return new WorkspaceData
            {
                Location = Location.WestUS2,
                ApplicationInsights = _testBase.CommonAppInsightId,
                ContainerRegistry = _testBase.CommonAcrId,
                StorageAccount = _testBase.CommonStorageId,
                KeyVault = _testBase.CommonKeyVaultId,
                Identity = new Models.Identity
                {
                    Type = (Models.ResourceIdentityType?)ResourceIdentityType.SystemAssigned
                }
            };
        }

        public BatchDeploymentTrackedResourceData GenerateBatchDeploymentTrackedResourceDataData()
        {
            throw new NotImplementedException();
        }

        public BatchDeploymentTrackedResourceData GenerateBatchDeploymentTrackedResourceData()
        {
            throw new NotImplementedException();
        }

        public BatchEndpointTrackedResourceData GenerateBatchEndpointTrackedResourceData()
        {
            throw new NotImplementedException();
        }

        public CodeContainerResourceData GenerateCodeContainerResourceData()
        {
            throw new NotImplementedException();
        }

        public CodeVersionResourceData GenerateCodeVersionResourceData()
        {
            throw new NotImplementedException();
        }

        public ComputeResourceData GenerateComputeResourceData()
        {
            // TODO: Take input to create different compute resource
            return new ComputeResourceData
            {
                Location = Location.WestUS2,
                Properties = new AmlCompute
                {
                    Properties = new AmlComputeProperties
                    {
                        ScaleSettings = new ScaleSettings(2),
                        VmSize = "Standard_DS2_v2",
                    }
                }
            };
        }

        public DataContainerResourceData GenerateDataContainerResourceData()
        {
            throw new NotImplementedException();
        }

        public DatastorePropertiesResourceData GenerateDatastorePropertiesResourceData()
        {
            throw new NotImplementedException();
        }

        public DataVersionResourceData GenerateDataVersionResourceData()
        {
            throw new NotImplementedException();
        }

        public EnvironmentContainerResourceData GenerateEnvironmentContainerResourceData()
        {
            throw new NotImplementedException();
        }

        public EnvironmentSpecificationVersionResourceData GenerateEnvironmentSpecificationVersionResourceData()
        {
            throw new NotImplementedException();
        }

        public JobBaseResourceData GenerateJobBaseResourceData()
        {
            throw new NotImplementedException();
        }

        public LabelingJobResourceData GenerateLabelingJobResourceData()
        {
            throw new NotImplementedException();
        }

        public ModelContainerResourceData GenerateModelContainerResourceData()
        {
            throw new NotImplementedException();
        }

        public ModelVersionResourceData GenerateModelVersionResourceData()
        {
            throw new NotImplementedException();
        }

        public OnlineDeploymentTrackedResourceData GenerateOnlineDeploymentTrackedResourceData()
        {
            throw new NotImplementedException();
        }

        public OnlineEndpointTrackedResourceData GenerateOnlineEndpointTrackedResourceData()
        {
            throw new NotImplementedException();
        }

        public PrivateEndpointConnectionData GeneratePrivateEndpointConnectionData()
        {
            throw new NotImplementedException();
        }

        public WorkspaceConnectionData GenerateWorkspaceConnectionData()
        {
            throw new NotImplementedException();
        }
    }
}
