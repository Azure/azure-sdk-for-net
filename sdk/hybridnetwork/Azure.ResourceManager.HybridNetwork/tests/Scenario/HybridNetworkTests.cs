// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HybridNetwork.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HybridNetwork.Tests.Scenario
{
    internal class HybridNetworkTests : HybridNetworkManagementTestBase
    {
        public HybridNetworkTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            DefaultResourceGroupName = SessionRecording.GenerateAssetName("HybridNetworkUTRG");
            DefaultResourceLocation = new AzureLocation("eastus2euap");

            ResourceGroupData rgData = new ResourceGroupData(DefaultResourceLocation);
            var rgLro = await GlobalClient
                .GetDefaultSubscriptionAsync().Result
                .GetResourceGroups()
                .CreateOrUpdateAsync(WaitUntil.Completed, DefaultResourceGroupName, rgData);
            ResourceGroupResource rg = rgLro.Value;
            ResourceGroupId = rg.Id;

            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            Client = GetArmClient();

            ResourceGroup = await Client.GetResourceGroupResource(ResourceGroupId).GetAsync();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [Order(0)]
        [RecordedTest]
        public async Task CanCreateGetPublisher()
        {
            var publisherName = Recording.GenerateAssetName("publisher");

            // Create Publisher
            PublisherResource publisher = await CreatePublisherResource(ResourceGroup, publisherName, DefaultResourceLocation);
            PublisherId = publisher.Id;

            // Get Publisher
            Response<PublisherResource> getPublisherResponse = await publisher.GetAsync();
            PublisherResource publisherResourceRetrieved = getPublisherResponse.Value;
            Assert.IsNotNull(publisherResourceRetrieved);
            Assert.AreEqual(publisher.Data.Location, publisherResourceRetrieved.Data.Location);
            Assert.AreEqual(PublisherScope.Private, publisherResourceRetrieved.Data.Properties.Scope);
        }

        [TestCase]
        [Order(0)]
        [RecordedTest]
        public async Task CanCreateGetSite()
        {
            var siteName = Recording.GenerateAssetName("site");

            // Create Publisher
            SiteResource site = await CreateSiteResource(ResourceGroup, siteName, DefaultResourceLocation);
            SiteId = site.Id;

            // Get Publisher
            Response<SiteResource> getSiteResponse = await site.GetAsync();
            SiteResource siteResourceRetrieved = getSiteResponse.Value;
            Assert.IsNotNull(siteResourceRetrieved);
            Assert.AreEqual(site.Data.Location, siteResourceRetrieved.Data.Location);
            Assert.AreEqual(NfviName, siteResourceRetrieved.Data.Properties.Nfvis[0].Name);
            Assert.AreEqual(NfviType.AzureCore, siteResourceRetrieved.Data.Properties.Nfvis[0].NfviType);
        }

        [TestCase]
        [Order(1)]
        [RecordedTest]
        public async Task CanCreateGetConfigGroupSchema()
        {
            var cgSchemaName = Recording.GenerateAssetName("cgSchema");

            // Create Artifact Store
            PublisherResource publisher = Client.GetPublisherResource(PublisherId);
            ConfigurationGroupSchemaResource cgSchema = await CreateConfigGroupSchemaResource(publisher, cgSchemaName, DefaultResourceLocation);
            CGSchemaId = cgSchema.Id;

            // Get Artifact Store
            Response<ConfigurationGroupSchemaResource> getArtifactStoreResponse = await cgSchema.GetAsync();
            ConfigurationGroupSchemaResource cgSchemaResourceRetrieved = getArtifactStoreResponse.Value;
            ConfigurationGroupSchemaData retrievedData = cgSchemaResourceRetrieved.Data;
            Assert.IsNotNull(cgSchemaResourceRetrieved);
            var schema = ReadJsonFile(CGSchemaFileName).ToString(Newtonsoft.Json.Formatting.None);
            Assert.AreEqual(cgSchema.Data.Location, retrievedData.Location);
            Assert.AreEqual(schema, retrievedData.Properties.SchemaDefinition);
        }

        [TestCase]
        [Order(1)]
        [RecordedTest]
        public async Task CanCreateGetArtifactStore()
        {
            var artifactStoreName = Recording.GenerateAssetName("artifactStore");

            // Create Artifact Store
            PublisherResource publisher = Client.GetPublisherResource(PublisherId);
            ArtifactStoreResource artifactStore = await CreateArtifactStoreResource(publisher, artifactStoreName, DefaultResourceLocation);
            ArtifactStoreId = artifactStore.Id;

            // Get Artifact Store
            Response<ArtifactStoreResource> getArtifactStoreResponse = await artifactStore.GetAsync();
            ArtifactStoreResource artifactStoreResourceRetrieved = getArtifactStoreResponse.Value;
            ArtifactStoreData retrievedData = artifactStoreResourceRetrieved.Data;
            Assert.IsNotNull(artifactStoreResourceRetrieved);
            Assert.AreEqual(artifactStore.Data.Location, retrievedData.Location);
            Assert.AreEqual(ArtifactStoreType.AzureContainerRegistry, retrievedData.Properties.StoreType);
            Assert.AreEqual(ArtifactReplicationStrategy.SingleReplication, retrievedData.Properties.ReplicationStrategy);
        }

        [TestCase]
        [Order(1)]
        [RecordedTest]
        public async Task CanCreateGetNFDG()
        {
            var nfdgName = Recording.GenerateAssetName("nfdg");

            // Create NFDG
            PublisherResource publisher = Client.GetPublisherResource(PublisherId);
            NetworkFunctionDefinitionGroupResource nfdg = await CreateNFDGResource(publisher, nfdgName, DefaultResourceLocation);
            NFDGId = nfdg.Id;

            // Get NFDG
            Response<NetworkFunctionDefinitionGroupResource> getNfdgResponse = await nfdg.GetAsync();
            NetworkFunctionDefinitionGroupResource nfdgResourceRetrieved = getNfdgResponse.Value;
            NetworkFunctionDefinitionGroupData retrievedData = nfdgResourceRetrieved.Data;
            Assert.IsNotNull(nfdgResourceRetrieved);
            Assert.AreEqual(nfdg.Data.Location, retrievedData.Location);
            Assert.AreEqual("NFD for .NET SDK UTs.", retrievedData.Properties.Description);
        }

        [TestCase]
        [Order(1)]
        [RecordedTest]
        public async Task CanCreateGetNSDG()
        {
            var nsdgName = Recording.GenerateAssetName("nsdg");

            // Create NSDG
            PublisherResource publisher = Client.GetPublisherResource(PublisherId);
            NetworkServiceDesignGroupResource nsdg = await CreateNSDGResource(publisher, nsdgName, DefaultResourceLocation);
            NSDGId = nsdg.Id;

            // Get NSDG
            Response<NetworkServiceDesignGroupResource> getNsdgResponse = await nsdg.GetAsync();
            NetworkServiceDesignGroupResource nsdgResourceRetrieved = getNsdgResponse.Value;
            NetworkServiceDesignGroupData retrievedData = nsdgResourceRetrieved.Data;
            Assert.IsNotNull(nsdgResourceRetrieved);
            Assert.AreEqual(nsdg.Data.Location, retrievedData.Location);
            Assert.AreEqual("NSD for .NET SDK UTs.", retrievedData.Properties.Description);
        }

        [TestCase]
        [Order(2)]
        [RecordedTest]
        public async Task CanCreateGetArtifactManifest()
        {
            string artifactManifestName = Recording.GenerateAssetName("artifactManifest");

            // Create Artifact Manifest
            ArtifactStoreResource artifactStore = Client.GetArtifactStoreResource(ArtifactStoreId);
            ArtifactManifestResource artifactManifest = await CreateArtifactManifestResource(artifactStore, artifactManifestName, DefaultResourceLocation);

            // Get credential and upload artifact if we are recording.
            if (Mode == RecordedTestMode.Record)
            {
                AzureContainerRegistryScopedTokenCredential creds = (AzureContainerRegistryScopedTokenCredential)await artifactManifest.GetCredentialAsync();
                UploadArmTemplate(VnetArmTemplateFileName, VnetArmTemplateArtifactName, "1.0.0", creds);
                UploadArmTemplate(NfArmTemplateFileName, NfArmTemplateArtifactName, "1.0.0", creds);
            }

            // Get Artifact Manifest
            Response<ArtifactManifestResource> getArtifactManifestResponse = await artifactManifest.GetAsync();
            ArtifactManifestResource artifactManifestResourceRetrieved = getArtifactManifestResponse.Value;
            ArtifactManifestData retrievedData = artifactManifestResourceRetrieved.Data;
            Assert.IsNotNull(artifactManifestResourceRetrieved);
            Assert.AreEqual(artifactManifest.Data.Location, retrievedData.Location);
            Assert.AreEqual(VnetArmTemplateArtifactName, retrievedData.Properties.Artifacts[0].ArtifactName);
            Assert.AreEqual(ArtifactType.OCIArtifact, retrievedData.Properties.Artifacts[0].ArtifactType);
            Assert.AreEqual("1.0.0", retrievedData.Properties.Artifacts[0].ArtifactVersion);
            Assert.AreEqual(NfArmTemplateArtifactName, retrievedData.Properties.Artifacts[1].ArtifactName);
            Assert.AreEqual(ArtifactType.OCIArtifact, retrievedData.Properties.Artifacts[1].ArtifactType);
            Assert.AreEqual("1.0.0", retrievedData.Properties.Artifacts[1].ArtifactVersion);
        }

        [TestCase]
        [Order(3)]
        [RecordedTest]
        public async Task CanCreateGetNFDV()
        {
            string nfdvName = "1.0.0";

            // Create NFDV
            NetworkFunctionDefinitionGroupResource nfdg = Client.GetNetworkFunctionDefinitionGroupResource(NFDGId);
            ArtifactStoreResource artifactStore = Client.GetArtifactStoreResource(ArtifactStoreId);
            NetworkFunctionDefinitionVersionResource nfdv = await CreateNFDVResource(nfdg, artifactStore, nfdvName, DefaultResourceLocation);
            NFDVId = nfdv.Id;

            // Get NFDV
            Response<NetworkFunctionDefinitionVersionResource> getNfdvResponse = await nfdv.GetAsync();
            NetworkFunctionDefinitionVersionResource nfdvResourceRetrieved = getNfdvResponse.Value;
            NetworkFunctionDefinitionVersionData retrievedData = nfdvResourceRetrieved.Data;
            VirtualNetworkFunctionDefinitionVersion properties = (VirtualNetworkFunctionDefinitionVersion)retrievedData.Properties;
            Assert.IsNotNull(nfdvResourceRetrieved);
            Assert.AreEqual(nfdv.Data.Location, retrievedData.Location);
            var deployParams = ReadJsonFile(DeployParametersFileName).ToString(Newtonsoft.Json.Formatting.None);
            Assert.AreEqual(deployParams, properties.DeployParameters);
            var nfTemplate = (AzureCoreNetworkFunctionTemplate)properties.NetworkFunctionTemplate;
            var armAplication = (AzureCoreNetworkFunctionArmTemplateApplication)nfTemplate.NetworkFunctionApplications[0];
            Assert.AreEqual(ArtifactStoreId, armAplication.ArtifactProfile.ArtifactStoreId);
        }

        [TestCase]
        [Order(3)]
        [RecordedTest]
        public async Task CanCreateGetNSDV()
        {
            string nsdvName = "1.0.0";

            // Create NSDV
            var nsdg = Client.GetNetworkServiceDesignGroupResource(NSDGId);
            var cgSchema = Client.GetConfigurationGroupSchemaResource(CGSchemaId);
            var artifactStore = Client.GetArtifactStoreResource(ArtifactStoreId);
            NetworkServiceDesignVersionResource nsdv = await CreateNSDVResource(nsdg, cgSchema, artifactStore, nsdvName, DefaultResourceLocation);
            NSDVId = nsdv.Id;

            // Get NSDV
            Response<NetworkServiceDesignVersionResource> getNsdvResponse = await nsdv.GetAsync();
            NetworkServiceDesignVersionResource nsdvResourceRetrieved = getNsdvResponse.Value;
            NetworkServiceDesignVersionData retrievedData = nsdvResourceRetrieved.Data;
            Assert.IsNotNull(nsdvResourceRetrieved);
            Assert.AreEqual(nsdv.Data.Location, retrievedData.Location);
            Assert.AreEqual(CGSchemaId, retrievedData.Properties.ConfigurationGroupSchemaReferences["vnet_ConfigGroupSchema"].Id);
            var ret = (NetworkFunctionDefinitionResourceElementTemplateDetails)retrievedData.Properties.ResourceElementTemplates[0];
            Assert.AreEqual(ArtifactStoreId, ret.Configuration.ArtifactProfile.ArtifactStoreReferenceId);
        }

        [TestCase]
        [Order(4)]
        [RecordedTest]
        public async Task CanCreateGetConfigGroupValues()
        {
            var cgvName = Recording.GenerateAssetName("cgValues");

            // Create Artifact Manifest
            var cgSchema = Client.GetConfigurationGroupSchemaResource(CGSchemaId);
            ConfigurationGroupValueResource cgValues = await CreateCGVResource(ResourceGroup, cgSchema, cgvName, NFDVId, DefaultResourceLocation);
            CGValueId = cgValues.Id;

            // Get Artifact Manifest
            Response<ConfigurationGroupValueResource> getCgvResponse = await cgValues.GetAsync();
            ConfigurationGroupValueResource cgvResourceRetrieved = getCgvResponse.Value;
            ConfigurationGroupValueData retrievedData = cgvResourceRetrieved.Data;
            ConfigurationValueWithoutSecrets properties = (ConfigurationValueWithoutSecrets)retrievedData.Properties;
            Assert.IsNotNull(cgvResourceRetrieved);
            Assert.AreEqual(cgValues.Data.Location, retrievedData.Location);
            Assert.AreEqual(ConfigurationGroupValueConfigurationType.Open, properties.ConfigurationType);
            var cgSchemaRef = (OpenDeploymentResourceReference)properties.ConfigurationGroupSchemaResourceReference;
            Assert.AreEqual(CGSchemaId, cgSchemaRef.Id);
            var values = ReadJsonFile(DeployValuesFileName);
            values["nfdvId"] = NFDVId.ToString();
            Assert.AreEqual(properties.ConfigurationValue, values.ToString(Newtonsoft.Json.Formatting.None));
        }

        [TestCase]
        [Order(5)]
        [RecordedTest]
        public async Task CanCreateGetSNS()
        {
            string snsName = Recording.GenerateAssetName("sns");

            // Create Site Network Service.
            var site = Client.GetSiteResource(SiteId);
            var nsdv = Client.GetNetworkServiceDesignVersionResource(NSDVId);
            var cgValue = Client.GetConfigurationGroupValueResource(CGValueId);
            SiteNetworkServiceResource sns = await CreateSNSResource(ResourceGroup, site, nsdv, cgValue, snsName, DefaultResourceLocation);

            // Get Network Function
            Response<SiteNetworkServiceResource> getSnsResponse = await sns.GetAsync();
            SiteNetworkServiceResource snsResourceRetrieved = getSnsResponse.Value;
            SiteNetworkServiceData retrievedData = snsResourceRetrieved.Data;
            Assert.IsNotNull(snsResourceRetrieved);
            Assert.AreEqual(sns.Data.Location, retrievedData.Location);
            Assert.AreEqual(SiteId, retrievedData.Properties.SiteReferenceId);
            Assert.AreEqual(CGValueId, retrievedData.Properties.DesiredStateConfigurationGroupValueReferences["vnet_ConfigGroupSchema"].Id);
            var nsdvRef = (OpenDeploymentResourceReference)retrievedData.Properties.NetworkServiceDesignVersionResourceReference;
            Assert.AreEqual(NSDVId, nsdvRef.Id);
        }

        private string DefaultResourceGroupName;
        private ResourceIdentifier PublisherId;
        private ResourceIdentifier SiteId;
        private ResourceIdentifier ArtifactStoreId;
        private ResourceIdentifier CGSchemaId;
        private ResourceIdentifier CGValueId;
        private ResourceIdentifier NFDGId;
        private ResourceIdentifier NFDVId;
        private ResourceIdentifier NSDGId;
        private ResourceIdentifier NSDVId;
        private ResourceIdentifier ResourceGroupId;
        private AzureLocation DefaultResourceLocation;
        private ResourceGroupResource ResourceGroup;
    }
}
