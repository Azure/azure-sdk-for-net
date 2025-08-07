// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HybridNetwork.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;

namespace Azure.ResourceManager.HybridNetwork.Tests
{
    public class HybridNetworkManagementTestBase : ManagementRecordedTestBase<HybridNetworkManagementTestEnvironment>
    {
        protected ArmClient Client { get; set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        private readonly string TestAssetPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Scenario", "TestAssets");
        protected readonly string VnetArmTemplateArtifactName = "vnet-arm-template";
        protected readonly string VnetArmTemplateFileName = "VnetArmTemplate.json";
        protected readonly string VnetArmTemplateMappingFileName = "VnetArmTemplateMappings.json";
        protected readonly string NfArmTemplateArtifactName = "nf-arm-template";
        protected readonly string NfArmTemplateFileName = "NfArmTemplate.json";
        protected readonly string NfArmTemplateMappingFileName = "NfArmTemplateMappings.json";
        protected readonly string DeployParametersFileName = "DeployParameters.json";
        protected readonly string DeployValuesFileName = "DeploymentValues.json";
        protected readonly string NfviName = "exampleNFVI";
        protected readonly string CGSchemaFileName = "CGSchema.json";

        protected HybridNetworkManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$..acrToken");
        }

        protected HybridNetworkManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            JsonPathSanitizers.Add("$..acrToken");
        }

        protected void UploadArmTemplate(
            string fileName,
            string artifactName,
            string artifactVersion,
            AzureContainerRegistryScopedTokenCredential creds)
        {
            string templateFilePath = Path.Combine(TestAssetPath, fileName);
            string acrName = creds.AcrServerUri.ToString().Replace("https://", "").TrimEnd('/');

            if (File.Exists(templateFilePath))
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

        protected JObject ReadJsonFile(string filePath)
        {
            var json = File.ReadAllText(Path.Combine(TestAssetPath, filePath));
            return JObject.Parse(json);
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
                    SchemaDefinition = ReadJsonFile(CGSchemaFileName).ToString(Newtonsoft.Json.Formatting.None),
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
                ArtifactName = VnetArmTemplateArtifactName,
                ArtifactType = ArtifactType.OCIArtifact,
                ArtifactVersion = "1.0.0",
            };
            var nfArtifact = new ManifestArtifactFormat()
            {
                ArtifactName = NfArmTemplateArtifactName,
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
                    TemplateParameters = ReadJsonFile(VnetArmTemplateMappingFileName).ToString(Newtonsoft.Json.Formatting.None)
                },
                ArtifactProfile = new AzureCoreArmTemplateArtifactProfile()
                {
                    ArtifactStoreId = artifactStore.Id,
                    TemplateArtifactProfile = new ArmTemplateArtifactProfile()
                    {
                        TemplateName = VnetArmTemplateArtifactName,
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
                DeployParameters = ReadJsonFile(DeployParametersFileName).ToString(Newtonsoft.Json.Formatting.None)
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
                Name = NfviName,
                NfviDetailsType = "AzureCore"
            });

            nsdvData.Properties.ConfigurationGroupSchemaReferences.Add("vnet_ConfigGroupSchema", new Resources.Models.WritableSubResource() { Id = cgs.Id });

            var vnetResourceElementTemplate = new NetworkFunctionDefinitionResourceElementTemplateDetails()
            {
                Name = "VnetRET",
                DependsOnProfile = new DependsOnProfile(),
                Configuration = new ArmResourceDefinitionResourceElementTemplate()
                {
                    ArtifactProfile = new NSDArtifactProfile()
                    {
                        ArtifactName = NfArmTemplateArtifactName,
                        ArtifactVersion = "1.0.0",
                        ArtifactStoreReferenceId = artifactStore.Id,
                    },
                    ParameterValues = ReadJsonFile(NfArmTemplateMappingFileName).ToString(Newtonsoft.Json.Formatting.None),
                    TemplateType = TemplateType.ArmTemplate
                }
            };

            nsdvData.Properties.ResourceElementTemplates.Add(vnetResourceElementTemplate);

            var lro = await nsdg
                .GetNetworkServiceDesignVersions()
                .CreateOrUpdateAsync(WaitUntil.Completed, nsdvName, nsdvData);

            return lro.Value;
        }

        protected async Task<SiteResource> CreateSiteResource(
            ResourceGroupResource resourceGroup,
            string siteName,
            AzureLocation location)
        {
            var nfvi = new AzureCoreNfviDetails() { Name = NfviName, Location = location };

            var siteData = new SiteData(location)
            {
                Properties = new SitePropertiesFormat()
            };

            siteData.Properties.Nfvis.Add(nfvi);

            var lro = await resourceGroup
                .GetSites()
                .CreateOrUpdateAsync(WaitUntil.Completed, siteName, siteData);

            return lro.Value;
        }

        protected async Task<ConfigurationGroupValueResource> CreateCGVResource(
            ResourceGroupResource resourceGroup,
            ConfigurationGroupSchemaResource cgs,
            string cgvName,
            ResourceIdentifier nfdvId,
            AzureLocation location)
        {
            var deploymentValues = ReadJsonFile(DeployValuesFileName);
            deploymentValues["nfdvId"] = nfdvId.ToString();

            var cgvData = new ConfigurationGroupValueData(location)
            {
                Properties = new ConfigurationValueWithoutSecrets()
                {
                    ConfigurationGroupSchemaResourceReference = new OpenDeploymentResourceReference()
                    {
                        Id = cgs.Id
                    },
                    ConfigurationValue = deploymentValues.ToString(Newtonsoft.Json.Formatting.None)
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
            NetworkServiceDesignVersionResource nsdv,
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
                        Id = nsdv.Id
                    }
                },
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Sku = new HybridNetworkSku(HybridNetworkSkuName.Standard)
            };

            snsData.Properties.DesiredStateConfigurationGroupValueReferences.Add("vnet_ConfigGroupSchema", new Resources.Models.WritableSubResource() { Id = cgv.Id });

            var lro = await resourceGroup
                .GetSiteNetworkServices()
                .CreateOrUpdateAsync(WaitUntil.Completed, snsName, snsData);

            return lro.Value;
        }
    }
}
