// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.DocumentIntelligence.Samples
{
    public partial class DocumentIntelligenceSamples
    {
        [RecordedTest]
        public async Task ComposeModelAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var client = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), TestEnvironment.Credential);

            #region Snippet:DocumentIntelligenceSampleBuildVariousModels
            // For this sample, you can use the training documents found in the `trainingFiles` folder.
            // Upload the documents to your storage container and then generate a container SAS URL.
            // For instructions on setting up documents for training in an Azure Storage Blob Container, see
            // https://aka.ms/azsdk/formrecognizer/buildtrainingset

#if SNIPPET
            string officeSuppliesModelId = "<officeSuppliesModelId>";
            Uri officeSuppliesUri = new Uri("<officeSuppliesUri>");
#else
            string officeSuppliesModelId = Guid.NewGuid().ToString();
            Uri officeSuppliesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            var officeSuppliesContent = new BuildDocumentModelContent(officeSuppliesModelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = new AzureBlobContentSource(officeSuppliesUri),
                Description = "Purchase order - Office supplies"
            };

            Operation<DocumentModelDetails> officeSuppliesOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, officeSuppliesContent);
            DocumentModelDetails officeSuppliesModel = officeSuppliesOperation.Value;

#if SNIPPET
            string officeEquipmentModelId = "<officeEquipmentModelId>";
            Uri officeEquipmentUri = new Uri("<officeEquipmentUri>");
#else
            string officeEquipmentModelId = Guid.NewGuid().ToString();
            Uri officeEquipmentUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            var officeEquipmentContent = new BuildDocumentModelContent(officeEquipmentModelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = new AzureBlobContentSource(officeEquipmentUri),
                Description = "Purchase order - Office Equipment"
            };

            Operation<DocumentModelDetails> officeEquipmentOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, officeEquipmentContent);
            DocumentModelDetails officeEquipmentModel = officeEquipmentOperation.Value;

#if SNIPPET
            string furnitureModelId = "<furnitureModelId>";
            Uri furnitureUri = new Uri("<purchaseOrderFurnitureUri>");
#else
            string furnitureModelId = Guid.NewGuid().ToString();
            Uri furnitureUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            var furnitureContent = new BuildDocumentModelContent(furnitureModelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = new AzureBlobContentSource(furnitureUri),
                Description = "Purchase order - Furniture"
            };

            Operation<DocumentModelDetails> furnitureOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, furnitureContent);
            DocumentModelDetails furnitureModel = furnitureOperation.Value;

#if SNIPPET
            string cleaningSuppliesModelId = "<cleaningSuppliesModelId>";
            Uri cleaningSuppliesUri = new Uri("<cleaningSuppliesUri>");
#else
            string cleaningSuppliesModelId = Guid.NewGuid().ToString();
            Uri cleaningSuppliesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            var cleaningSuppliesContent = new BuildDocumentModelContent(cleaningSuppliesModelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = new AzureBlobContentSource(cleaningSuppliesUri),
                Description = "Purchase order - Cleaning Supplies"
            };

            Operation<DocumentModelDetails> cleaningSuppliesOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, cleaningSuppliesContent);
            DocumentModelDetails cleaningSuppliesModel = cleaningSuppliesOperation.Value;
            #endregion

            #region Snippet:DocumentIntelligenceSampleComposeModel
            // Note that to compose a model you must assign a classifier responsible for detecting the type of
            // document submitted on analysis requests. This piece of information is necessary to determine which
            // of the component models should be the one to analyze the input document.

#if SNIPPET
            string purchaseOrderModelId = "<purchaseOrderModelId>";
            string classifierId = "<classifierId>";
#else
            string purchaseOrderModelId = Guid.NewGuid().ToString();
            string classifierId = Guid.NewGuid().ToString();
#endif
            var docTypes = new Dictionary<string, DocumentTypeDetails>()
            {
                { "officeSupplies", new DocumentTypeDetails() { ModelId = officeSuppliesModelId } },
                { "officeEquipment", new DocumentTypeDetails() { ModelId = officeEquipmentModelId } },
                { "furniture", new DocumentTypeDetails() { ModelId = furnitureModelId } },
                { "cleaningSupplies", new DocumentTypeDetails() { ModelId = cleaningSuppliesModelId } }
            };
            var purchaseOrderContent = new ComposeDocumentModelContent(purchaseOrderModelId, classifierId, docTypes)
            {
                Description = "Composed Purchase order"
            };

#if !SNIPPET
            await BuildClassifierAsync(client, classifierId);
#endif
            Operation<DocumentModelDetails> purchaseOrderOperation = await client.ComposeModelAsync(WaitUntil.Completed, purchaseOrderContent);
            DocumentModelDetails purchaseOrderModel = purchaseOrderOperation.Value;

            Console.WriteLine($"Model ID: {purchaseOrderModel.ModelId}");
            Console.WriteLine($"Model description: {purchaseOrderModel.Description}");
            Console.WriteLine($"Created on: {purchaseOrderModel.CreatedOn}");
            #endregion

            // Delete the models on completion to clean environment.
            await client.DeleteModelAsync(officeSuppliesModelId);
            await client.DeleteModelAsync(officeEquipmentModelId);
            await client.DeleteModelAsync(furnitureModelId);
            await client.DeleteModelAsync(cleaningSuppliesModelId);
            await client.DeleteModelAsync(purchaseOrderModelId);
            await client.DeleteClassifierAsync(classifierId);
        }

        /// <summary>
        /// A helper method used by the sample above. Builds a document classifier.
        /// </summary>
        public async Task BuildClassifierAsync(DocumentIntelligenceAdministrationClient client, string classifierId)
        {
            Uri blobContainerUri = new Uri(TestEnvironment.ClassifierTrainingSasUrl);

            var sourceA = new AzureBlobContentSource(blobContainerUri) { Prefix = "IRS-1040-A/train" };
            var sourceB = new AzureBlobContentSource(blobContainerUri) { Prefix = "IRS-1040-B/train" };
            var docTypeA = new ClassifierDocumentTypeDetails() { AzureBlobSource = sourceA };
            var docTypeB = new ClassifierDocumentTypeDetails() { AzureBlobSource = sourceB };
            var docTypes = new Dictionary<string, ClassifierDocumentTypeDetails>()
            {
                { "IRS-1040-A", docTypeA },
                { "IRS-1040-B", docTypeB }
            };

            var buildContent = new BuildDocumentClassifierContent(classifierId, docTypes);

            await client.BuildClassifierAsync(WaitUntil.Completed, buildContent);
        }
    }
}
