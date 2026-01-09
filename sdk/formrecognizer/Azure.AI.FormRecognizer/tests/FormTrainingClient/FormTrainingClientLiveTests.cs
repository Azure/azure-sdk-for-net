// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="FormTrainingClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class FormTrainingClientLiveTests : FormRecognizerLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FormTrainingClientLiveTests(bool isAsync, FormRecognizerClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        public void FormTrainingClientCannotAuthenticateWithFakeApiKey()
        {
            var client = CreateFormTrainingClient(apiKey: "fakeKey");
            Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetAccountPropertiesAsync());
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/47689")]
        public async Task StartTrainingCanAuthenticateWithTokenCredential()
        {
            var client = CreateFormTrainingClient(useTokenCredential: true);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            TrainingOperation operation = await client.StartTrainingAsync(trainingFilesUri, useTrainingLabels: false);
            CustomFormModel model = null;

            try
            {
                model = await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (model != null)
                {
                    await client.DeleteModelAsync(model.ModelId);
                }
            }

            Assert.Multiple(() =>
            {
                // Sanity check to make sure we got an actual response back from the service.
                Assert.That(model.ModelId, Is.Not.Null);
                Assert.That(model.Status, Is.EqualTo(CustomFormModelStatus.Ready));
                Assert.That(model.Errors, Is.Not.Null);
            });
            Assert.That(model.Errors.Count, Is.EqualTo(0));
        }

        #region StartTraining

        [RecordedTest]
        [TestCase(true, true)]
        [TestCase(true, false, Ignore = "https://github.com/Azure/azure-sdk-for-net/issues/47689")]
        [TestCase(false, true)]
        [TestCase(false, false, Ignore = "https://github.com/Azure/azure-sdk-for-net/issues/47689")]
        public async Task StartTraining(bool singlePage, bool labeled)
        {
            var client = CreateFormTrainingClient();
            var trainingFilesUri = new Uri(singlePage ? TestEnvironment.BlobContainerSasUrl : TestEnvironment.MultipageBlobContainerSasUrl);

            TrainingOperation operation = await client.StartTrainingAsync(trainingFilesUri, labeled);
            CustomFormModel model = null;

            try
            {
                await operation.WaitForCompletionAsync();

                Assert.That(operation.HasValue, Is.True);

                model = operation.Value;
            }
            finally
            {
                if (model != null)
                {
                    await client.DeleteModelAsync(model.ModelId);
                }
            }

            Assert.Multiple(() =>
            {
                Assert.That(model.ModelId, Is.Not.Null);
                Assert.That(model.ModelName, Is.Null);
                Assert.That(model.Properties, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(model.Properties.IsComposedModel, Is.False);
                Assert.That(model.TrainingStartedOn, Is.Not.Null);
                Assert.That(model.TrainingCompletedOn, Is.Not.Null);
                Assert.That(model.Status, Is.EqualTo(CustomFormModelStatus.Ready));
                Assert.That(model.Errors, Is.Not.Null);
            });
            Assert.That(model.Errors.Count, Is.EqualTo(0));

            foreach (TrainingDocumentInfo doc in model.TrainingDocuments)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(doc.Name, Is.Not.Null);
                    Assert.That(doc.ModelId, Is.Not.Null);
                    Assert.That(doc.PageCount, Is.Not.Null);
                    Assert.That(doc.Status, Is.EqualTo(TrainingStatus.Succeeded));
                    Assert.That(doc.Errors, Is.Not.Null);
                });
                Assert.That(doc.Errors.Count, Is.EqualTo(0));
            }

            foreach (var submodel in model.Submodels)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(submodel.FormType, Is.Not.Null);
                    Assert.That(submodel.ModelId, Is.Not.Null);
                });
                foreach (var fields in submodel.Fields)
                {
                    Assert.That(fields.Value.Name, Is.Not.Null);
                    if (labeled)
                        Assert.That(fields.Value.Accuracy, Is.Not.Null);
                    else
                        Assert.That(fields.Value.Label, Is.Not.Null);
                }
            }
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/47689")]
        public async Task StartTrainingSucceedsWithValidPrefix()
        {
            var client = CreateFormTrainingClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            var filter = new TrainingFileFilter { IncludeSubfolders = true, Prefix = "subfolder" };
            TrainingOperation operation = await client.StartTrainingAsync(trainingFilesUri, useTrainingLabels: false, new TrainingOptions() { TrainingFileFilter = filter });

            try
            {
                await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (operation != null && operation.HasValue)
                {
                    await client.DeleteModelAsync(operation.Value.ModelId);
                }
            }

            Assert.Multiple(() =>
            {
                Assert.That(operation.HasValue, Is.True);
                Assert.That(operation.Value.Status, Is.EqualTo(CustomFormModelStatus.Ready));
            });
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/47689")]
        public async Task StartTrainingFailsWithInvalidPrefix()
        {
            var client = CreateFormTrainingClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            var filter = new TrainingFileFilter { IncludeSubfolders = true, Prefix = "invalidPrefix" };
            TrainingOperation operation = await client.StartTrainingAsync(trainingFilesUri, useTrainingLabels: false, new TrainingOptions() { TrainingFileFilter = filter });

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync());
            Assert.That(ex.ErrorCode, Is.EqualTo("2014"));
        }

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task StartTrainingWithLabelsModelName()
        {
            var client = CreateFormTrainingClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelName = "My training";

            TrainingOperation operation = await client.StartTrainingAsync(trainingFilesUri, useTrainingLabels: true, modelName);

            try
            {
                await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (operation != null && operation.HasValue)
                {
                    await client.DeleteModelAsync(operation.Value.ModelId);
                }
            }

            Assert.Multiple(() =>
            {
                Assert.That(operation.HasValue, Is.True);
                Assert.That(operation.Value.ModelName, Is.EqualTo(modelName));
            });
        }

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/47689")]
        public async Task StartTrainingWithNoLabelsModelName()
        {
            var client = CreateFormTrainingClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelName = "My training";

            TrainingOperation operation = await client.StartTrainingAsync(trainingFilesUri, useTrainingLabels: false, modelName);

            try
            {
                await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (operation != null && operation.HasValue)
                {
                    await client.DeleteModelAsync(operation.Value.ModelId);
                }
            }

            Assert.Multiple(() =>
            {
                Assert.That(operation.HasValue, Is.True);
                Assert.That(operation.Value.ModelName, Is.EqualTo(modelName));
            });
        }

        [RecordedTest]
        public void StartTrainingError()
        {
            var client = CreateFormTrainingClient();

            var containerUrl = new Uri("https://someUrl");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartTrainingAsync(containerUrl, useTrainingLabels: false));
            Assert.That(ex.ErrorCode, Is.EqualTo("2011"));
        }

        #endregion StartTraining

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false, Ignore = "https://github.com/Azure/azure-sdk-for-net/issues/47689")]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task CheckFormTypeinSubmodelAndRecognizedForm(bool labeled)
        {
            var client = CreateFormTrainingClient();
            var formClient = client.GetFormRecognizerClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            TrainingOperation trainingOperation = await client.StartTrainingAsync(trainingFilesUri, labeled);
            RecognizeCustomFormsOperation recognizeOperation;
            CustomFormModel model = null;

            try
            {
                await trainingOperation.WaitForCompletionAsync();
                Assert.That(trainingOperation.HasValue, Is.True);

                model = trainingOperation.Value;
                Assert.That(model.Submodels.FirstOrDefault().FormType, Is.Not.Null);

                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Form1);

                recognizeOperation = await formClient.StartRecognizeCustomFormsFromUriAsync(model.ModelId, uri);
                await recognizeOperation.WaitForCompletionAsync();
            }
            finally
            {
                if (model != null)
                {
                    await client.DeleteModelAsync(model.ModelId);
                }
            }

            Assert.That(recognizeOperation.HasValue, Is.True);

            RecognizedForm form = recognizeOperation.Value.Single();
            Assert.Multiple(() =>
            {
                Assert.That(form.FormType, Is.Not.Null);
                Assert.That(model.Submodels.FirstOrDefault().FormType, Is.EqualTo(form.FormType));
            });
        }

        [RecordedTest]
        [ServiceVersion(Max = FormRecognizerClientOptions.ServiceVersion.V2_0)]
        public async Task StartCreateComposedModelWithV2()
        {
            var client = CreateFormTrainingClient();

            await using var trainedModelA = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);
            await using var trainedModelB = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            var modelIds = new List<string> { trainedModelA.ModelId, trainedModelB.ModelId };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartCreateComposedModelAsync(modelIds));
            Assert.That(ex.ErrorCode, Is.EqualTo("404"));
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task StartCreateComposedModel(bool useTokenCredential)
        {
            var client = CreateFormTrainingClient(useTokenCredential);

            // Make the models slightly different to make sure the cache won't return copies of the same model.
            await using var trainedModelA = await CreateDisposableTrainedModelAsync(useTrainingLabels: true, ContainerType.Singleforms);
            await using var trainedModelB = await CreateDisposableTrainedModelAsync(useTrainingLabels: true, ContainerType.MultipageFiles);

            var modelIds = new List<string> { trainedModelA.ModelId, trainedModelB.ModelId };

            CreateComposedModelOperation operation = await client.StartCreateComposedModelAsync(modelIds, "My composed model");
            CustomFormModel composedModel = null;

            try
            {
                await operation.WaitForCompletionAsync();

                Assert.That(operation.HasValue, Is.True);

                composedModel = operation.Value;
            }
            finally
            {
                if (composedModel != null)
                {
                    await client.DeleteModelAsync(composedModel.ModelId);
                }
            }

            Assert.Multiple(() =>
            {
                Assert.That(composedModel.ModelId, Is.Not.Null);
                Assert.That(composedModel.Properties, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(composedModel.Properties.IsComposedModel, Is.True);
                Assert.That(composedModel.TrainingStartedOn, Is.Not.Null);
                Assert.That(composedModel.TrainingCompletedOn, Is.Not.Null);
                Assert.That(composedModel.Status, Is.EqualTo(CustomFormModelStatus.Ready));
                Assert.That(composedModel.Errors, Is.Not.Null);
            });
            Assert.That(composedModel.Errors.Count, Is.EqualTo(0));

            Dictionary<string, List<TrainingDocumentInfo>> trainingDocsPerModel = composedModel.TrainingDocuments.GroupBy(doc => doc.ModelId).ToDictionary(g => g.Key, g => g.ToList());

            Assert.That(trainingDocsPerModel, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(trainingDocsPerModel.ContainsKey(trainedModelA.ModelId), Is.True);
                Assert.That(trainingDocsPerModel.ContainsKey(trainedModelB.ModelId), Is.True);
            });

            //Check training documents in modelA
            foreach (TrainingDocumentInfo doc in trainingDocsPerModel[trainedModelA.ModelId])
            {
                Assert.Multiple(() =>
                {
                    Assert.That(doc.Name, Is.Not.Null);
                    Assert.That(doc.ModelId, Is.EqualTo(trainedModelA.ModelId));
                    Assert.That(doc.PageCount, Is.Not.Null);
                    Assert.That(doc.Status, Is.EqualTo(TrainingStatus.Succeeded));
                    Assert.That(doc.Errors, Is.Not.Null);
                });
                Assert.That(doc.Errors.Count, Is.EqualTo(0));
            }

            //Check training documents in modelB
            foreach (TrainingDocumentInfo doc in trainingDocsPerModel[trainedModelB.ModelId])
            {
                Assert.Multiple(() =>
                {
                    Assert.That(doc.Name, Is.Not.Null);
                    Assert.That(doc.ModelId, Is.EqualTo(trainedModelB.ModelId));
                    Assert.That(doc.PageCount, Is.Not.Null);
                    Assert.That(doc.Status, Is.EqualTo(TrainingStatus.Succeeded));
                    Assert.That(doc.Errors, Is.Not.Null);
                });
                Assert.That(doc.Errors.Count, Is.EqualTo(0));
            }

            Assert.That(composedModel.Submodels, Has.Count.EqualTo(2));
            foreach (var submodel in composedModel.Submodels)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(submodel.FormType, Is.Not.Null);
                    Assert.That(submodel.ModelId, Is.Not.Null);
                    Assert.That(modelIds, Does.Contain(submodel.ModelId));
                });
                foreach (var fields in submodel.Fields)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(fields.Value.Name, Is.Not.Null);
                        Assert.That(fields.Value.Accuracy, Is.Not.Null);
                    });
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task StartCreateComposedModelFailsWithInvalidId()
        {
            var client = CreateFormTrainingClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            await using var trainedModelA = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            var modelIds = new List<string> { trainedModelA.ModelId, "00000000-0000-0000-0000-000000000000" };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartCreateComposedModelAsync(modelIds, "My composed model"));
            Assert.That(ex.ErrorCode, Is.EqualTo("1001"));
        }

        #region administration ops

        [RecordedTest]
        [TestCase(true, true)]
        [TestCase(false, true, Ignore = "https://github.com/Azure/azure-sdk-for-net/issues/47689")]
        [TestCase(true, false)]
        [TestCase(false, false, Ignore = "https://github.com/Azure/azure-sdk-for-net/issues/47689")]
        public async Task TrainingOps(bool labeled, bool useTokenCredential)
        {
            var client = CreateFormTrainingClient(useTokenCredential);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            TrainingOperation operation = await client.StartTrainingAsync(trainingFilesUri, labeled);
            CustomFormModel trainedModel = null;

            try
            {
                await operation.WaitForCompletionAsync();

                Assert.That(operation.HasValue, Is.True);

                trainedModel = operation.Value;

                CustomFormModel resultModel = await client.GetCustomModelAsync(trainedModel.ModelId);

                Assert.Multiple(() =>
                {
                    Assert.That(resultModel.ModelId, Is.EqualTo(trainedModel.ModelId));
                    Assert.That(resultModel.Properties.IsComposedModel, Is.EqualTo(trainedModel.Properties.IsComposedModel));
                    Assert.That(resultModel.TrainingStartedOn, Is.EqualTo(trainedModel.TrainingStartedOn));
                    Assert.That(resultModel.TrainingCompletedOn, Is.EqualTo(trainedModel.TrainingCompletedOn));
                    Assert.That(resultModel.Status, Is.EqualTo(CustomFormModelStatus.Ready));
                });
                Assert.Multiple(() =>
                {
                    Assert.That(resultModel.Status, Is.EqualTo(trainedModel.Status));
                    Assert.That(resultModel.Errors, Has.Count.EqualTo(trainedModel.Errors.Count));
                });

                for (int i = 0; i < resultModel.TrainingDocuments.Count; i++)
                {
                    var tm = trainedModel.TrainingDocuments[i];
                    var rm = resultModel.TrainingDocuments[i];

                    Assert.Multiple(() =>
                    {
                        Assert.That(rm.Name, Is.EqualTo(tm.Name));
                        Assert.That(rm.ModelId, Is.EqualTo(tm.ModelId));
                        Assert.That(rm.PageCount, Is.EqualTo(tm.PageCount));
                        Assert.That(rm.Status, Is.EqualTo(TrainingStatus.Succeeded));
                    });
                    Assert.Multiple(() =>
                    {
                        Assert.That(rm.Status, Is.EqualTo(tm.Status));
                        Assert.That(rm.Errors, Has.Count.EqualTo(tm.Errors.Count));
                    });
                }

                for (int i = 0; i < resultModel.Submodels.Count; i++)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(resultModel.Submodels[i].FormType, Is.EqualTo(trainedModel.Submodels[i].FormType));
                        Assert.That(resultModel.Submodels[i].ModelId, Is.EqualTo(trainedModel.Submodels[i].ModelId));
                    });
                    foreach (var fields in resultModel.Submodels[i].Fields)
                    {
                        Assert.That(fields.Value.Name, Is.EqualTo(trainedModel.Submodels[i].Fields[fields.Key].Name));
                        if (labeled)
                            Assert.That(fields.Value.Accuracy, Is.EqualTo(trainedModel.Submodels[i].Fields[fields.Key].Accuracy));
                        else
                            Assert.That(fields.Value.Label, Is.EqualTo(trainedModel.Submodels[i].Fields[fields.Key].Label));
                    }
                }

                CustomFormModelInfo modelInfo = client.GetCustomModelsAsync().ToEnumerableAsync().Result.FirstOrDefault();

                Assert.Multiple(() =>
                {
                    Assert.That(modelInfo.ModelId, Is.Not.Null);
                    Assert.That(modelInfo.TrainingStartedOn, Is.Not.Null);
                    Assert.That(modelInfo.TrainingCompletedOn, Is.Not.Null);
                    Assert.That(modelInfo.Status, Is.Not.Null);
                    Assert.That(modelInfo.Properties, Is.Not.Null);
                });

                AccountProperties accountP = await client.GetAccountPropertiesAsync();

                Assert.Multiple(() =>
                {
                    Assert.That(accountP.CustomModelCount, Is.Not.Null);
                    Assert.That(accountP.CustomModelLimit, Is.Not.Null);
                });
            }
            finally
            {
                if (trainedModel != null)
                {
                    await client.DeleteModelAsync(trainedModel.ModelId);
                }
            }

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(() => client.GetCustomModelAsync(trainedModel.ModelId));
            Assert.That(ex.ErrorCode, Is.EqualTo("1022"));
        }

        [RecordedTest]
        public void DeleteModelFailsWhenModelDoesNotExist()
        {
            var client = CreateFormTrainingClient();
            var fakeModelId = "00000000-0000-0000-0000-000000000000";

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.DeleteModelAsync(fakeModelId));
            Assert.That(ex.ErrorCode, Is.EqualTo("1022"));
        }

        #endregion administration ops

        #region Copy

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CopyModel(bool useTokenCredential)
        {
            var sourceClient = CreateFormTrainingClient(useTokenCredential);
            var targetClient = CreateFormTrainingClient(useTokenCredential);
            var resourceId = TestEnvironment.ResourceId;
            var region = TestEnvironment.ResourceRegion;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, region);

            CopyModelOperation operation = await sourceClient.StartCopyModelAsync(trainedModel.ModelId, targetAuth);
            CustomFormModelInfo modelCopied = null;

            try
            {
                await operation.WaitForCompletionAsync();

                Assert.That(operation.HasValue, Is.True);

                modelCopied = operation.Value;
            }
            finally
            {
                if (modelCopied != null)
                {
                    await targetClient.DeleteModelAsync(modelCopied.ModelId);
                }
            }

            Assert.Multiple(() =>
            {
                Assert.That(modelCopied.TrainingCompletedOn, Is.Not.Null);
                Assert.That(modelCopied.TrainingStartedOn, Is.Not.Null);
                Assert.That(modelCopied.ModelId, Is.EqualTo(targetAuth.ModelId));
            });
            Assert.That(modelCopied.ModelId, Is.Not.EqualTo(trainedModel.ModelId));
        }

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task CopyModelWithLabelsAndModelName()
        {
            var sourceClient = CreateFormTrainingClient();
            var targetClient = CreateFormTrainingClient();
            var resourceId = TestEnvironment.ResourceId;
            var region = TestEnvironment.ResourceRegion;

            string modelName = "My model to copy";

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true, modelName: modelName);

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, region);

            CopyModelOperation operation = await sourceClient.StartCopyModelAsync(trainedModel.ModelId, targetAuth);
            CustomFormModelInfo modelCopied = null;

            try
            {
                await operation.WaitForCompletionAsync();

                Assert.That(operation.HasValue, Is.True);

                modelCopied = operation.Value;

                Assert.That(modelCopied.ModelId, Is.EqualTo(targetAuth.ModelId));
                Assert.That(modelCopied.ModelId, Is.Not.EqualTo(trainedModel.ModelId));

                CustomFormModel modelCopiedFullInfo = await sourceClient.GetCustomModelAsync(modelCopied.ModelId);
                Assert.That(modelCopiedFullInfo.ModelName, Is.EqualTo(modelName));
            }
            finally
            {
                if (modelCopied != null)
                {
                    await targetClient.DeleteModelAsync(modelCopied.ModelId);
                }
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task CopyComposedModel(bool useTokenCredential)
        {
            var sourceClient = CreateFormTrainingClient(useTokenCredential);
            var targetClient = CreateFormTrainingClient(useTokenCredential);
            var resourceId = TestEnvironment.ResourceId;
            var region = TestEnvironment.ResourceRegion;

            // Make the models slightly different to make sure the cache won't return copies of the same model.
            await using var trainedModelA = await CreateDisposableTrainedModelAsync(useTrainingLabels: true, ContainerType.Singleforms);
            await using var trainedModelB = await CreateDisposableTrainedModelAsync(useTrainingLabels: true, ContainerType.MultipageFiles);

            var modelIds = new List<string> { trainedModelA.ModelId, trainedModelB.ModelId };

            string modelName = "My composed model";
            CreateComposedModelOperation operation = await sourceClient.StartCreateComposedModelAsync(modelIds, modelName);
            CustomFormModel composedModel = null;
            CustomFormModelInfo modelCopied = null;

            try
            {
                await operation.WaitForCompletionAsync();
                Assert.That(operation.HasValue, Is.True);
                composedModel = operation.Value;

                CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, region);

                CopyModelOperation copyOperation = await sourceClient.StartCopyModelAsync(composedModel.ModelId, targetAuth);
                await copyOperation.WaitForCompletionAsync();
                Assert.That(copyOperation.HasValue, Is.True);
                modelCopied = copyOperation.Value;

                Assert.That(modelCopied.ModelId, Is.EqualTo(targetAuth.ModelId));
                Assert.That(modelCopied.ModelId, Is.Not.EqualTo(composedModel.ModelId));

                CustomFormModel modelCopiedFullInfo = await sourceClient.GetCustomModelAsync(modelCopied.ModelId);
                Assert.That(modelCopiedFullInfo.ModelName, Is.EqualTo(modelName));
                foreach (var submodel in modelCopiedFullInfo.Submodels)
                {
                    Assert.That(modelIds, Does.Contain(submodel.ModelId));
                }
            }
            finally
            {
                if (composedModel != null)
                {
                    await targetClient.DeleteModelAsync(composedModel.ModelId);
                }

                if (modelCopied != null)
                {
                    await targetClient.DeleteModelAsync(modelCopied.ModelId);
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task CopyModelWithoutLabelsAndModelName()
        {
            var sourceClient = CreateFormTrainingClient();
            var targetClient = CreateFormTrainingClient();
            var resourceId = TestEnvironment.ResourceId;
            var region = TestEnvironment.ResourceRegion;

            string modelName = "My model to copy";

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false, modelName: modelName);

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, region);

            CopyModelOperation operation = await sourceClient.StartCopyModelAsync(trainedModel.ModelId, targetAuth);
            CustomFormModelInfo modelCopied = null;

            try
            {
                await operation.WaitForCompletionAsync();

                Assert.That(operation.HasValue, Is.True);

                modelCopied = operation.Value;

                Assert.That(modelCopied.ModelId, Is.EqualTo(targetAuth.ModelId));
                Assert.That(modelCopied.ModelId, Is.Not.EqualTo(trainedModel.ModelId));

                CustomFormModel modelCopiedFullInfo = await sourceClient.GetCustomModelAsync(modelCopied.ModelId);
                Assert.That(modelCopiedFullInfo.ModelName, Is.EqualTo(modelName));
            }
            finally
            {
                if (modelCopied != null)
                {
                    await targetClient.DeleteModelAsync(modelCopied.ModelId);
                }
            }
        }

        [RecordedTest]
        public void CopyModelError()
        {
            var sourceClient = CreateFormTrainingClient();
            var targetClient = CreateFormTrainingClient();
            var resourceId = TestEnvironment.ResourceId;
            var region = TestEnvironment.ResourceRegion;

            CopyAuthorization targetAuth = CopyAuthorization.FromJson("{\"modelId\":\"328c3b7d - a563 - 4ba2 - 8c2f - 2f26d664486a\",\"accessToken\":\"5b5685e4 - 2f24 - 4423 - ab18 - 000000000000\",\"expirationDateTimeTicks\":1591932653,\"resourceId\":\"resourceId\",\"resourceRegion\":\"westcentralus\"}");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await sourceClient.StartCopyModelAsync("00000000-0000-0000-0000-000000000000", targetAuth));

            Assert.Multiple(() =>
            {
                Assert.That(ex.Status, Is.EqualTo(400));
                Assert.That(ex.ErrorCode, Is.EqualTo("1002"));
            });
        }

        [RecordedTest]
        public async Task StartCopyModelFailsWithWrongRegion()
        {
            var sourceClient = CreateFormTrainingClient();
            var targetClient = CreateFormTrainingClient();
            var resourceId = TestEnvironment.ResourceId;
            var regionA = "regionA";
            var regionB = "regionB";
            switch (TestEnvironment.AuthorityHostUrl)
            {
                case "https://login.microsoftonline.com/":
                    regionA = "westcentralus";
                    regionB = "eastus2";
                    break;
                case "https://login.microsoftonline.us/":
                    regionA = "usgovarizona";
                    regionB = "usgovvirginia";
                    break;
                default:
                    regionA = "westcentralus";
                    regionB = "eastus2";
                    break;
            }
            var wrongRegion = TestEnvironment.ResourceRegion == regionA ? regionB : regionA;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);
            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, wrongRegion);

            var operation = await sourceClient.StartCopyModelAsync(trainedModel.ModelId, targetAuth);

            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync());
        }

        [RecordedTest]
        public async Task GetCopyAuthorization()
        {
            var targetClient = CreateFormTrainingClient();
            var resourceId = TestEnvironment.ResourceId;
            var region = TestEnvironment.ResourceRegion;

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, region);

            Assert.Multiple(() =>
            {
                Assert.That(targetAuth.ModelId, Is.Not.Null);
                Assert.That(targetAuth.AccessToken, Is.Not.Null);
                Assert.That(targetAuth.ExpiresOn, Is.Not.Null);
                Assert.That(targetAuth.ResourceId, Is.EqualTo(resourceId));
                Assert.That(targetAuth.Region, Is.EqualTo(region));
            });
        }

        [RecordedTest]
        public async Task SerializeDeserializeCopyAuthorization()
        {
            var targetClient = CreateFormTrainingClient();
            var resourceId = TestEnvironment.ResourceId;
            var region = TestEnvironment.ResourceRegion;

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, region);

            string jsonTargetAuth = targetAuth.ToJson();

            CopyAuthorization targetAuthFromJson = CopyAuthorization.FromJson(jsonTargetAuth);

            Assert.Multiple(() =>
            {
                Assert.That(targetAuthFromJson.ModelId, Is.EqualTo(targetAuth.ModelId));
                Assert.That(targetAuthFromJson.ExpiresOn, Is.EqualTo(targetAuth.ExpiresOn));
                Assert.That(targetAuthFromJson.AccessToken, Is.EqualTo(targetAuth.AccessToken));
                Assert.That(targetAuthFromJson.ResourceId, Is.EqualTo(targetAuth.ResourceId));
                Assert.That(targetAuthFromJson.Region, Is.EqualTo(targetAuth.Region));
            });
        }

        #endregion Copy
    }
}
