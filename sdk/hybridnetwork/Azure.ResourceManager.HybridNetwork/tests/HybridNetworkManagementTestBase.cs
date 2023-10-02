// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HybridNetwork.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Azure.ResourceManager.HybridNetwork.Tests
{
    public class HybridNetworkManagementTestBase : ManagementRecordedTestBase<HybridNetworkManagementTestEnvironment>
    {
        protected ArmClient Client { get; set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        private static readonly string TestAssetPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Scenario", "TestAssets");

        protected HybridNetworkManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected HybridNetworkManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected void UploadArmTemplate(
            string fileName,
            string artifactName,
            string artifactVersion,
            AzureContainerRegistryScopedTokenCredential creds)
        {
            string templateFilePath = Path.Combine(TestAssetPath, fileName);
            string configFilePath = Path.Combine(TestAssetPath, "empty.json");
            string acrName = creds.AcrServerUri.ToString().Replace("https://", "").TrimEnd('/');

            if (File.Exists(templateFilePath) && File.Exists(configFilePath))
            {
                // Create a process to run the oras commands
                Process process = new Process();
                process.StartInfo.FileName = "oras";

                // Run login command
                process.StartInfo.Arguments = $"login {acrName} --username {creds.Username} --password {creds.AcrToken}";
                process.Start();
                process.WaitForExit();

                // Run push command
                process.StartInfo.Arguments = $"push {acrName}/{artifactName}:{artifactVersion} {templateFilePath}:application/vnd.microsoft.azure.resource+json --disable-path-validation";
                process.Start();
                process.WaitForExit();
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        protected JsonElement ReadJsonFile(string filePath)
        {
            var json = File.ReadAllText(Path.Combine(TestAssetPath, filePath));
            JsonDocument document = JsonDocument.Parse(json);

            return document.RootElement;
        }

        protected async Task<PublisherResource> CreatePublisherResource(
            ResourceGroupResource resourceGroup,
            string publisherName,
            AzureLocation location)
        {
            var publisherData = new PublisherData(location)
            {
                Properties = new PublisherPropertiesFormat()
                {
                    Scope = PublisherScope.Private
                }
            };
            var lro = await resourceGroup
                .GetPublishers()
                .CreateOrUpdateAsync(WaitUntil.Completed, publisherName, publisherData);

            return lro.Value;
        }

        protected async Task<ConfigurationGroupSchemaResource> CreateConfigGroupSchemaResource(
            PublisherResource publisher,
            string cgSchemaName,
            AzureLocation location)
        {
            var cgSchemaData = new ConfigurationGroupSchemaData(location)
            {
                Properties = new ConfigurationGroupSchemaPropertiesFormat()
                {
                    SchemaDefinition = ReadJsonFile("CGSchema.json").GetRawText(),
                }
            };
            var lro = await publisher
                .GetConfigurationGroupSchemas()
                .CreateOrUpdateAsync(WaitUntil.Completed, cgSchemaName, cgSchemaData);

            return lro.Value;
        }

        protected async Task<ArtifactStoreResource> CreateArtifactStoreResource(
            PublisherResource publisher,
            string artifactStoreName,
            AzureLocation location)
        {
            var artifactStoreData = new ArtifactStoreData(location)
            {
                Properties = new ArtifactStorePropertiesFormat()
                {
                    StoreType = ArtifactStoreType.AzureContainerRegistry,
                    ReplicationStrategy = ArtifactReplicationStrategy.SingleReplication,
                }
            };
            var lro = await publisher
                .GetArtifactStores()
                .CreateOrUpdateAsync(WaitUntil.Completed, artifactStoreName, artifactStoreData);

            return lro.Value;
        }

        protected async Task<NetworkFunctionDefinitionGroupResource> CreateNFDGResource(
            PublisherResource publisher,
            string nfdgName,
            AzureLocation location)
        {
            var nfdgData = new NetworkFunctionDefinitionGroupData(location)
            {
                Properties = new NetworkFunctionDefinitionGroupPropertiesFormat()
                {
                    Description = "NFD for .NET SDK UTs."
                }
            };
            var lro = await publisher
                .GetNetworkFunctionDefinitionGroups()
                .CreateOrUpdateAsync(WaitUntil.Completed, nfdgName, nfdgData);

            return lro.Value;
        }

        protected async Task<NetworkServiceDesignGroupResource> CreateNSDGResource(
            PublisherResource publisher,
            string nsdgName,
            AzureLocation location)
        {
            var nsdgData = new NetworkServiceDesignGroupData(location)
            {
                Properties = new NetworkServiceDesignGroupPropertiesFormat()
                {
                    Description = "NSD for .NET SDK UTs."
                }
            };
            var lro = await publisher
                .GetNetworkServiceDesignGroups()
                .CreateOrUpdateAsync(WaitUntil.Completed, nsdgName, nsdgData);

            return lro.Value;
        }

        protected async Task<ArtifactManifestResource> CreateArtifactManifestResource(
            ArtifactStoreResource artifactStore,
            string artifactManifestName,
            AzureLocation location)
        {
            var vnetArtifact = new ManifestArtifactFormat()
            {
                ArtifactName = "vnet-arm-template",
                ArtifactType = ArtifactType.OCIArtifact,
                ArtifactVersion = "1.0.0",
            };
            var nfArtifact = new ManifestArtifactFormat()
            {
                ArtifactName = "nf-arm-template",
                ArtifactType = ArtifactType.OCIArtifact,
                ArtifactVersion = "1.0.0",
            };
            var artifactManifestData = new ArtifactManifestData(location)
            {
                Properties = new ArtifactManifestPropertiesFormat(),
            };

            artifactManifestData.Properties.Artifacts.Add(vnetArtifact);
            artifactManifestData.Properties.Artifacts.Add(nfArtifact);
            var lro = await artifactStore
                .GetArtifactManifests()
                .CreateOrUpdateAsync(WaitUntil.Completed, artifactManifestName, artifactManifestData);

            return lro.Value;
        }

        protected async Task<NetworkFunctionDefinitionVersionResource> CreateNFDVResource(
            NetworkFunctionDefinitionGroupResource nfdg,
            ArtifactStoreResource artifactStore,
            string nfdvName,
            AzureLocation location)
        {
            var vnetArmApp = new AzureCoreNetworkFunctionArmTemplateApplication()
            {
                Name = "vnetArmApp",
                DeployParametersMappingRuleProfile = new AzureCoreArmTemplateDeployMappingRuleProfile()
                {
                    ApplicationEnablement = ApplicationEnablement.Unknown,
                    TemplateParameters = ReadJsonFile("VnetArmTemplateMappings.json").GetRawText()
                },
                ArtifactProfile = new AzureCoreArmTemplateArtifactProfile()
                {
                    ArtifactStoreId = artifactStore.Id,
                    TemplateArtifactProfile = new ArmTemplateArtifactProfile()
                    {
                        TemplateName = "vnet-arm-template",
                        TemplateVersion = "1.0.0",
                    }
                }
            };

            AzureCoreNetworkFunctionTemplate nfTemplate = new AzureCoreNetworkFunctionTemplate()
            {
                NfviType = VirtualNetworkFunctionNfviType.AzureCore,
            };

            nfTemplate.NetworkFunctionApplications.Add(vnetArmApp);

            VirtualNetworkFunctionDefinitionVersion vnfProps = new VirtualNetworkFunctionDefinitionVersion()
            {
                NetworkFunctionType = NetworkFunctionType.VirtualNetworkFunction,
                NetworkFunctionTemplate = nfTemplate,
                DeployParameters = ReadJsonFile("DeployParameters.json").GetRawText()
            };

            var nfdvData = new NetworkFunctionDefinitionVersionData(location)
            {
                Properties = vnfProps
            };

            var lro = await nfdg
                .GetNetworkFunctionDefinitionVersions()
                .CreateOrUpdateAsync(WaitUntil.Completed, nfdvName, nfdvData);

            return lro.Value;
        }

        protected async Task<NetworkServiceDesignVersionResource> CreateNSDVResource(
            NetworkServiceDesignGroupResource nsdg,
            ConfigurationGroupSchemaResource cgs,
            ArtifactStoreResource artifactStore,
            string nsdvName,
            AzureLocation location)
        {
            var nsdvData = new NetworkServiceDesignVersionData(location)
            {
                Properties = new NetworkServiceDesignVersionPropertiesFormat()
                {
                    Description = "An SNS that defploys an NF that deploys a VNET."
                }
            };

            nsdvData.Properties.NfvisFromSite.Add("nfvi1", new NfviDetails()
            {
                Name = "exampleNFVI",
                NfviDetailsType = "AzureCore"
            });

            nsdvData.Properties.ConfigurationGroupSchemaReferences.Add("VnetValues", new Resources.Models.WritableSubResource() { Id = cgs.Id });

            var vnetResourceElementTemplate = new NetworkFunctionDefinitionResourceElementTemplateDetails()
            {
                Name = "VnetRET",
                DependsOnProfile = new DependsOnProfile(),
                Configuration = new ArmResourceDefinitionResourceElementTemplate()
                {
                    ArtifactProfile = new NSDArtifactProfile()
                    {
                        ArtifactName = "nf-arm-template",
                        ArtifactVersion = "1.0.0",
                        ArtifactStoreReferenceId = artifactStore.Id,
                    },
                    ParameterValues = ReadJsonFile("VnetArmTemplateMappings.json").GetRawText(),
                    TemplateType = TemplateType.ArmTemplate
                }
            };

            nsdvData.Properties.ResourceElementTemplates.Add(vnetResourceElementTemplate);

            var lro = await nsdg
                .GetNetworkServiceDesignVersions()
                .CreateOrUpdateAsync(WaitUntil.Completed, nsdvName, nsdvData);

            return lro.Value;
        }

        protected async Task<NetworkFunctionResource> CreateNetworkFunctionResource(
            ResourceGroupResource resourceGroup,
            NetworkFunctionDefinitionVersionResource nfdv,
            string networkFunctionName,
            AzureLocation location)
        {
            var networkFunctionData = new NetworkFunctionData(location)
            {
                Properties = new NetworkFunctionPropertiesFormat()
                {
                    NetworkFunctionDefinitionVersionResourceReference = new OpenDeploymentResourceReference()
                    {
                        Id = nfdv.Id,
                    },
                    NfviType = NfviType.AzureCore,
                    NfviId = resourceGroup.Id,
                    AllowSoftwareUpdate = false,
                    DeploymentValues = ReadJsonFile("DeploymentValues.json").GetRawText(),
                }
            };

            var lro = await resourceGroup
                .GetNetworkFunctions()
                .CreateOrUpdateAsync(WaitUntil.Completed, networkFunctionName, networkFunctionData);

            return lro.Value;
        }

        protected async Task<SiteResource> CreateSiteResource(
            ResourceGroupResource resourceGroup,
            string siteName,
            AzureLocation location)
        {
            var nfvis = new List<NFVIs>() { new AzureCoreNfviDetails() { Name = "exampleNFVI", Location = location } };

            var siteData = new SiteData(location)
            {
                Properties = new SitePropertiesFormat(nfvis)
            };

            var lro = await resourceGroup
                .GetSites()
                .CreateOrUpdateAsync(WaitUntil.Completed, siteName, siteData);

            return lro.Value;
        }

        protected async Task<ConfigurationGroupValueResource> CreateCGVResource(
            ResourceGroupResource resourceGroup,
            ConfigurationGroupSchemaResource cgs,
            string cgvName,
            AzureLocation location)
        {
            var cgvData = new ConfigurationGroupValueData(location)
            {
                Properties = new ConfigurationValueWithoutSecrets()
                {
                    ConfigurationGroupSchemaResourceReference = new OpenDeploymentResourceReference()
                    {
                        Id = cgs.Id
                    },
                    ConfigurationValue = ReadJsonFile("DeploymentValues.json").GetRawText()
                }
            };

            var lro = await resourceGroup
                .GetConfigurationGroupValues()
                .CreateOrUpdateAsync(WaitUntil.Completed, cgvName, cgvData);

            return lro.Value;
        }

        protected async Task<SiteNetworkServiceResource> CreateSNSResource(
            ResourceGroupResource resourceGroup,
            SiteResource site,
            NetworkFunctionDefinitionVersionResource nfdv,
            ConfigurationGroupValueResource cgv,
            string snsName,
            AzureLocation location)
        {
            var snsData = new SiteNetworkServiceData(location)
            {
                Properties = new SiteNetworkServicePropertiesFormat()
                {
                    SiteReferenceId = site.Id,
                    NetworkServiceDesignVersionResourceReference = new OpenDeploymentResourceReference()
                    {
                        Id = nfdv.Id
                    }
                }
            };

            snsData.Properties.DesiredStateConfigurationGroupValueReferences.Add("VnetValues", new Resources.Models.WritableSubResource() { Id = cgv.Id });

            var lro = await resourceGroup
                .GetSiteNetworkServices()
                .CreateOrUpdateAsync(WaitUntil.Completed, snsName, snsData);

            return lro.Value;
        }
    }
}
