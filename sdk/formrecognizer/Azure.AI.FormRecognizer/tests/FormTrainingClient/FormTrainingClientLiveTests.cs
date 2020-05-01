// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
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
        public FormTrainingClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartTraining(bool labeled)
        {
            var client = CreateInstrumentedFormTrainingClient();
            var trainingFiles = new Uri(TestEnvironment.BlobContainerSasUrl);
            TrainingOperation operation;

            // TODO: sanitize body and enable body recording here.
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartTrainingAsync(trainingFiles, labeled);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            CustomFormModel model = operation.Value;

            Assert.IsNotNull(model.ModelId);
            Assert.IsNotNull(model.CreatedOn);
            Assert.IsNotNull(model.LastModified);
            Assert.IsNotNull(model.Status);
            Assert.AreEqual(CustomFormModelStatus.Ready, model.Status);
            Assert.IsNotNull(model.Errors);
            Assert.AreEqual(0, model.Errors.Count);

            foreach (TrainingDocumentInfo doc in model.TrainingDocuments)
            {
                Assert.IsNotNull(doc.DocumentName);
                Assert.IsNotNull(doc.PageCount);
                Assert.AreEqual(TrainingStatus.Succeeded, doc.Status);
                Assert.IsNotNull(doc.Errors);
                Assert.AreEqual(0, doc.Errors.Count);
            }

            foreach (var subModel in model.Models)
            {
                Assert.IsNotNull(subModel.FormType);
                foreach (var fields in subModel.Fields)
                {
                    Assert.IsNotNull(fields.Value.Name);
                    if (labeled)
                        Assert.IsNotNull(fields.Value.Accuracy);
                    else
                        Assert.IsNotNull(fields.Value.Label);
                }
            }
        }

        [Test]
        public async Task StartTrainingError()
        {
            var client = CreateInstrumentedFormTrainingClient();

            var containerUrl = new Uri("https://someUrl");

            TrainingOperation operation = await client.StartTrainingAsync(containerUrl);

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            CustomFormModel model = operation.Value;

            Assert.IsNotNull(model.ModelId);
            Assert.IsNotNull(model.CreatedOn);
            Assert.IsNotNull(model.LastModified);
            Assert.IsNotNull(model.Status);
            Assert.AreEqual(CustomFormModelStatus.Invalid, model.Status);
            Assert.IsNotNull(model.Errors);
            Assert.AreEqual(1, model.Errors.Count);
            Assert.IsNotNull(model.Errors.FirstOrDefault().Code);
            Assert.IsNotNull(model.Errors.FirstOrDefault().Message);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task TrainingOps(bool labeled)
        {
            var client = CreateInstrumentedFormTrainingClient();
            var trainingFiles = new Uri(TestEnvironment.BlobContainerSasUrl);
            TrainingOperation operation;

            // TODO: sanitize body and enable body recording here.
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartTrainingAsync(trainingFiles, labeled);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            CustomFormModel trainedModel = operation.Value;

            CustomFormModel resultModel = await client.GetCustomModelAsync(trainedModel.ModelId);

            Assert.AreEqual(trainedModel.ModelId, resultModel.ModelId);
            Assert.AreEqual(trainedModel.CreatedOn, resultModel.CreatedOn);
            Assert.AreEqual(trainedModel.LastModified, resultModel.LastModified);
            Assert.AreEqual(CustomFormModelStatus.Ready, resultModel.Status);
            Assert.AreEqual(trainedModel.Status, resultModel.Status);
            Assert.AreEqual(trainedModel.Errors.Count, resultModel.Errors.Count);

            for (int i=0; i< resultModel.TrainingDocuments.Count; i++)
            {
                var tm = trainedModel.TrainingDocuments[i];
                var rm = resultModel.TrainingDocuments[i];

                Assert.AreEqual(tm.DocumentName, rm.DocumentName);
                Assert.AreEqual(tm.PageCount, rm.PageCount);
                Assert.AreEqual(TrainingStatus.Succeeded, rm.Status);
                Assert.AreEqual(tm.Status, rm.Status);
                Assert.AreEqual(tm.Errors.Count, rm.Errors.Count);
            }

            for (int i = 0; i < resultModel.Models.Count; i++)
            {
                Assert.AreEqual(trainedModel.Models[i].FormType, resultModel.Models[i].FormType);

                foreach (var fields in resultModel.Models[i].Fields)
                {
                    Assert.AreEqual(trainedModel.Models[i].Fields[fields.Key].Name, fields.Value.Name);
                    if (labeled)
                        Assert.AreEqual(trainedModel.Models[i].Fields[fields.Key].Accuracy, fields.Value.Accuracy);
                    else
                        Assert.AreEqual(trainedModel.Models[i].Fields[fields.Key].Label, fields.Value.Label);
                }
            }

            CustomFormModelInfo modelInfo = client.GetModelInfosAsync().ToEnumerableAsync().Result.FirstOrDefault();

            Assert.IsNotNull(modelInfo.ModelId);
            Assert.IsNotNull(modelInfo.CreatedOn);
            Assert.IsNotNull(modelInfo.LastModified);
            Assert.IsNotNull(modelInfo.Status);

            AccountProperties accountP = await client.GetAccountPropertiesAsync();

            Assert.IsNotNull(accountP.CustomModelCount);
            Assert.IsNotNull(accountP.CustomModelLimit);

            await client.DeleteModelAsync(trainedModel.ModelId);

            Assert.ThrowsAsync<RequestFailedException>(() => client.GetCustomModelAsync(trainedModel.ModelId));
        }
    }
}
