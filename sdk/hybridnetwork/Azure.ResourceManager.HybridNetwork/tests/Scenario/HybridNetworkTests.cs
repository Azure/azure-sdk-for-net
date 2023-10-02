// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HybridNetwork.Models;
using Azure.ResourceManager.Resources;
using Microsoft.SqlServer.Server;
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
            DefaultResourceGroupName = SessionRecording.GenerateAssetName("PublisherUTRG");
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
            PublisherName = Recording.GenerateAssetName("publisher");

            // Create Publisher
            PublisherResource publisher = await CreatePublisherResource(ResourceGroup, PublisherName, DefaultResourceLocation);

            // Get Publisher
            Response<PublisherResource> getPublisherResponse = await publisher.GetAsync();
            PublisherResource publisherResourceRetrieved = getPublisherResponse.Value;
            Assert.IsNotNull(publisherResourceRetrieved);
            Assert.AreEqual(publisher.Data.Location, publisherResourceRetrieved.Data.Location);
            Assert.AreEqual(PublisherScope.Private, publisherResourceRetrieved.Data.Properties.Scope);
        }

        [TestCase]
        [Order(1)]
        [RecordedTest]
        [Ignore("Test not written yet")]
        public async Task CanCreateGetConfigGroupSchema()
        {
            CGSchemaName = Recording.GenerateAssetName("cgSchema");

            // Create Artifact Store
            PublisherResource publisher = await ResourceGroup.GetPublishers().GetAsync(PublisherName);
            ConfigurationGroupSchemaResource cgSchema = await CreateConfigGroupSchemaResource(publisher, CGSchemaName, DefaultResourceLocation);

            // Get Artifact Store
            Response<ConfigurationGroupSchemaResource> getArtifactStoreResponse = await cgSchema.GetAsync();
            ConfigurationGroupSchemaResource cgSchemaResourceRetrieved = getArtifactStoreResponse.Value;
            ConfigurationGroupSchemaData retrievedData = cgSchemaResourceRetrieved.Data;
            Assert.IsNotNull(cgSchemaResourceRetrieved);
            var schema = ReadJsonFile("CGSchema.json").ToString();
            Assert.AreEqual(cgSchema.Data.Location, retrievedData.Location);
            Assert.AreEqual(schema, retrievedData.Properties.SchemaDefinition);
        }

        [TestCase]
        [Order(1)]
        [RecordedTest]
        public async Task CanCreateGetArtifactStore()
        {
            ArtifactStoreName = Recording.GenerateAssetName("artifactStore");

            // Create Artifact Store
            PublisherResource publisher = await ResourceGroup.GetPublishers().GetAsync(PublisherName);
            ArtifactStoreResource artifactStore = await CreateArtifactStoreResource(publisher, ArtifactStoreName, DefaultResourceLocation);

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
            NFDGName = Recording.GenerateAssetName("nfdg");

            // Create NFDG
            PublisherResource publisher = await ResourceGroup.GetPublishers().GetAsync(PublisherName);
            NetworkFunctionDefinitionGroupResource nfdg = await CreateNFDGResource(publisher, NFDGName, DefaultResourceLocation);

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
            NSDGName = Recording.GenerateAssetName("nsdg");

            // Create NSDG
            PublisherResource publisher = await ResourceGroup.GetPublishers().GetAsync(PublisherName);
            NetworkServiceDesignGroupResource nsdg = await CreateNSDGResource(publisher, NSDGName, DefaultResourceLocation);

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
            ArtifactStoreResource artifactStore = await ResourceGroup.GetPublisherAsync(PublisherName).Result.Value.GetArtifactStoreAsync(ArtifactStoreName);
            ArtifactManifestResource artifactManifest = await CreateArtifactManifestResource(artifactStore, artifactManifestName, DefaultResourceLocation);

            // Get credential and upload artifact if we are recording.
            if (Mode == RecordedTestMode.Record)
            {
                AzureContainerRegistryScopedTokenCredential creds = (AzureContainerRegistryScopedTokenCredential)await artifactManifest.GetCredentialAsync();
                UploadArmTemplate("VnetArmTemplate.json", "vnet-arm-template", "1.0.0", creds);
                UploadArmTemplate("NfArmTemplate.json", "nf-arm-template", "1.0.0", creds);
            }

            // Get Artifact Manifest
            Response<ArtifactManifestResource> getArtifactManifestResponse = await artifactManifest.GetAsync();
            ArtifactManifestResource artifactManifestResourceRetrieved = getArtifactManifestResponse.Value;
            ArtifactManifestData retrievedData = artifactManifestResourceRetrieved.Data;
            Assert.IsNotNull(artifactManifestResourceRetrieved);
            Assert.AreEqual(artifactManifest.Data.Location, retrievedData.Location);
            Assert.AreEqual("vnet-arm-template", retrievedData.Properties.Artifacts[0].ArtifactName);
            Assert.AreEqual(ArtifactType.OCIArtifact, retrievedData.Properties.Artifacts[0].ArtifactType);
            Assert.AreEqual("1.0.0", retrievedData.Properties.Artifacts[0].ArtifactVersion);
        }

        [TestCase]
        [Order(3)]
        [RecordedTest]
        public async Task CanCreateGetNFDV()
        {
            string nfdvName = "1.0.0";

            // Create NFDV
            NetworkFunctionDefinitionGroupResource nfdg = await ResourceGroup.GetPublisherAsync(PublisherName).Result.Value.GetNetworkFunctionDefinitionGroupAsync(NFDGName);
            ArtifactStoreResource artifactStore = await ResourceGroup.GetPublisherAsync(PublisherName).Result.Value.GetArtifactStoreAsync(ArtifactStoreName);
            NetworkFunctionDefinitionVersionResource nfdv = await CreateNFDVResource(nfdg, artifactStore, nfdvName, DefaultResourceLocation);

            // Get NFDV
            Response<NetworkFunctionDefinitionVersionResource> getNfdvResponse = await nfdv.GetAsync();
            NetworkFunctionDefinitionVersionResource nfdvResourceRetrieved = getNfdvResponse.Value;
            NetworkFunctionDefinitionVersionData retrievedData = nfdvResourceRetrieved.Data;
        }

        [TestCase]
        [Order(4)]
        [RecordedTest]
        public async Task CanCreateGetNetworkFunction()
        {
            string networkFunctionName = Recording.GenerateAssetName("networkFunction");

            // Create Network Function
            var subscriptionResource = await Client.GetDefaultSubscriptionAsync();
            var nfdvId = NetworkFunctionDefinitionVersionResource.CreateResourceIdentifier(subscriptionResource.Id.SubscriptionId, ResourceGroup.Data.Name, PublisherName, NFDGName, "1.0.0");
            var nfdv = Client.GetNetworkFunctionDefinitionVersionResource(nfdvId);
            NetworkFunctionResource networkFunction = await CreateNetworkFunctionResource(ResourceGroup, nfdv, networkFunctionName, DefaultResourceLocation);

            // Get Network Function
            Response<NetworkFunctionResource> getNfdvResponse = await networkFunction.GetAsync();
            NetworkFunctionResource nfdvResourceRetrieved = getNfdvResponse.Value;
            NetworkFunctionData retrievedData = nfdvResourceRetrieved.Data;
        }

        [TestCase]
        [Order(4)]
        [RecordedTest]
        public async Task CanCreateGetNSDV()
        {
            string nsdvName = "1.0.0";

            // Create NSDV
            NetworkServiceDesignGroupResource nsdg = await ResourceGroup.GetPublisherAsync(PublisherName).Result.Value.GetNetworkServiceDesignGroupAsync(NFDGName);
            ArtifactStoreResource artifactStore = await ResourceGroup.GetPublisherAsync(PublisherName).Result.Value.GetArtifactStoreAsync(ArtifactStoreName);
            ConfigurationGroupSchemaResource cgs = await ResourceGroup.GetPublisherAsync(PublisherName).Result.Value.GetConfigurationGroupSchemaAsync(CGSchemaName);
            NetworkServiceDesignVersionResource nsdv = await CreateNSDVResource(nsdg, cgs, artifactStore, nsdvName, DefaultResourceLocation);

            // Get NSDV
            Response<NetworkServiceDesignVersionResource> getNsdvResponse = await nsdv.GetAsync();
            NetworkServiceDesignVersionResource nsdvResourceRetrieved = getNsdvResponse.Value;
            NetworkServiceDesignVersionData retrievedData = nsdvResourceRetrieved.Data;
        }

        private string DefaultResourceGroupName;
        private string PublisherName;
        private string ArtifactStoreName;
        private string CGSchemaName;
        private string NFDGName;
        private string NSDGName;
        private ResourceIdentifier ResourceGroupId;
        private AzureLocation DefaultResourceLocation;
        private ResourceGroupResource ResourceGroup;
    }
}
