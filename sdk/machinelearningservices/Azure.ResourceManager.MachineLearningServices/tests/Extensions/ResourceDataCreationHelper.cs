// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            return new BatchEndpointTrackedResourceData(
                Location.WestUS2,
                new BatchEndpoint
                {
                    AuthMode = EndpointAuthMode.AADToken,
                    Description = "Test",
                });
        }

        public CodeContainer GenerateCodeContainerResourceData()
        {
            return new CodeContainer()
            {
                // BUGBUG
                //Description = "Test"
            };
        }

        public CodeVersion GenerateCodeVersion()
        {
            return new CodeVersion("hello.py");
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

        public DataContainer GenerateDataContainerResourceData()
        {
            throw new NotImplementedException();
        }

        public DatastoreProperties GenerateDatastorePropertiesResourceData()
        {
            return new DatastoreProperties(
                new AzureBlobContents(
                    "track2mlstorage",
                    "datastore-container",
                    new AccountKeyDatastoreCredentials() { Secrets = new AccountKeyDatastoreSecrets() { Key = "key" } },
                    "core.windows.net",
                    "https")
                ) {
                Description = "Description",
                IsDefault = true,
                LinkedInfo = new LinkedInfo() { LinkedId = "string", LinkedResourceName = "string", Origin = OriginType.Synapse },
                //Properties = { { "additionalProp1", "vaule1" } },
                Tags = { { "key1", "value1" }, { "key2", "value2" } }
            };
        }

        public DataVersion GenerateDataVersionResourceData()
        {
            throw new NotImplementedException();
        }

        public EnvironmentContainer GenerateEnvironmentContainerResourceData()
        {
            return new EnvironmentContainer
            {
                //Description = "Test"
            };
        }

        public EnvironmentSpecificationVersion GenerateEnvironmentSpecificationVersionResourceData()
        {
            return new EnvironmentSpecificationVersion
            {
                Description = "Test",
                Docker = new DockerBuild("FROM python:3.7-slim")
            };
        }

        public JobBase GenerateJobBaseResourceData()
        {
            return new CommandJob("cd ~", new ComputeConfiguration() { IsLocal = true }) { Tags = { { "key1", "value1" } } };
        }

        public LabelingJob GenerateLabelingJobResourceData()
        {
            throw new NotImplementedException();
        }

        public ModelContainer GenerateModelContainerResourceData()
        {
            return new ModelContainer() { Properties = { { "key1", "value1" } }, Description = "Description", Tags = { { "key1", "value1" } } };
        }

        public ModelVersion GenerateModelVersionResourceData(DatastorePropertiesResource datastore)
        {
            return new ModelVersion("Test.txt")
            {
                DatastoreId = datastore.Data.Id,
                Description = "Model version description",
                Flavors = { { "python_function", new FlavorData() { Data = { { "loader_module", "myLoaderModule" } } } } },
                Tags = { { "key1", "value1" },{ "key2", "value2" } },
                Properties = { { "key1", "value1" }, { "key2", "value2" } }
            };
        }

        public OnlineDeploymentTrackedResourceData GenerateOnlineDeploymentTrackedResourceData()
        {
            throw new NotImplementedException();
        }

        public OnlineEndpointTrackedResourceData GenerateOnlineEndpointTrackedResourceData(Workspace workspace)
        {
            OnlineEndpoint properties = new OnlineEndpoint(EndpointAuthMode.AMLToken)
            {
                Keys = new EndpointAuthKeys() { PrimaryKey = "string", SecondaryKey = "string" },
                Target = workspace.GetComputeResources().GetAsync("").Result.Value.Id.ToString(),
                Traffic = { { "myDeployment1", 0 }, { "myDeployment2", 1 } },
                Description = "Description"
            };
            return new OnlineEndpointTrackedResourceData(Location.WestUS2, properties) { Kind = "string"};
        }

        public PrivateEndpointConnectionData GeneratePrivateEndpointConnectionData()
        {
            throw new NotImplementedException();
        }

        public WorkspaceConnectionData GenerateWorkspaceConnectionData()
        {
            return new WorkspaceConnectionData()
            {
                Category = "ACR",
                Target = "www.facebook.com",
                AuthType = "PAT",
                Value = "secrets"
            };
        }
    }
}
