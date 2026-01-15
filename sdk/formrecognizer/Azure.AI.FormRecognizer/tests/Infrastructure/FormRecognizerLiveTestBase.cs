// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    [ClientTestFixture(
    FormRecognizerClientOptions.ServiceVersion.V2_0,
    FormRecognizerClientOptions.ServiceVersion.V2_1)]
    public class FormRecognizerLiveTestBase : RecordedTestBase<FormRecognizerTestEnvironment>
    {
        /// <summary>
        /// The version of the REST API to test against. This will be passed
        /// to the .ctor via ClientTestFixture's values.
        /// </summary>
        private readonly FormRecognizerClientOptions.ServiceVersion _serviceVersion;

        public FormRecognizerLiveTestBase(bool isAsync, FormRecognizerClientOptions.ServiceVersion serviceVersion)
            : base(isAsync)
        {
            _serviceVersion = serviceVersion;

            JsonPathSanitizers.Add("$..accessToken");
            JsonPathSanitizers.Add("$..source");
            SanitizedHeaders.Add(Constants.AuthorizationHeader);
        }

        /// <summary>
        /// Creates a <see cref="FormRecognizerClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="FormRecognizerTestEnvironment.ApiKey"/>.</param>
        /// <returns>The instrumented <see cref="FormRecognizerClient" />.</returns>
        protected FormRecognizerClient CreateFormRecognizerClient(bool useTokenCredential = false, string apiKey = default) => CreateFormRecognizerClient(out _, useTokenCredential, apiKey);

        /// <summary>
        /// Creates a <see cref="FormRecognizerClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="nonInstrumentedClient">The non-instrumented version of the client to be used to resume LROs.</param>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="FormRecognizerTestEnvironment.ApiKey"/>.</param>
        /// <returns>The instrumented <see cref="FormRecognizerClient" />.</returns>
        protected FormRecognizerClient CreateFormRecognizerClient(out FormRecognizerClient nonInstrumentedClient, bool useTokenCredential = false, string apiKey = default)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var options = InstrumentClientOptions(new FormRecognizerClientOptions(_serviceVersion));

            if (useTokenCredential)
            {
                nonInstrumentedClient = new FormRecognizerClient(endpoint, TestEnvironment.Credential, options);
            }
            else
            {
                var credential = new AzureKeyCredential(apiKey ?? TestEnvironment.ApiKey);
                nonInstrumentedClient = new FormRecognizerClient(endpoint, credential, options);
            }

            return InstrumentClient(nonInstrumentedClient);
        }

        /// <summary>
        /// Creates a <see cref="FormTrainingClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="FormRecognizerTestEnvironment.ApiKey"/>.</param>
        /// <returns>The instrumented <see cref="FormTrainingClient" />.</returns>
        protected FormTrainingClient CreateFormTrainingClient(bool useTokenCredential = false, string apiKey = default) => CreateFormTrainingClient(out _, useTokenCredential, apiKey);

        /// <summary>
        /// Creates a <see cref="FormTrainingClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="nonInstrumentedClient">The non-instrumented version of the client to be used to resume LROs.</param>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="FormRecognizerTestEnvironment.ApiKey"/>.</param>
        /// <returns>The instrumented <see cref="FormTrainingClient" />.</returns>
        protected FormTrainingClient CreateFormTrainingClient(out FormTrainingClient nonInstrumentedClient, bool useTokenCredential = false, string apiKey = default)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var options = InstrumentClientOptions(new FormRecognizerClientOptions(_serviceVersion));

            if (useTokenCredential)
            {
                nonInstrumentedClient = new FormTrainingClient(endpoint, TestEnvironment.Credential, options);
            }
            else
            {
                var credential = new AzureKeyCredential(apiKey ?? TestEnvironment.ApiKey);
                nonInstrumentedClient = new FormTrainingClient(endpoint, credential, options);
            }

            return InstrumentClient(nonInstrumentedClient);
        }

        /// <summary>
        /// Trains a model and returns the associated <see cref="DisposableTrainedModel"/> instance, from which
        /// the model ID can be obtained. A cached model may be returned instead when running in live mode.
        /// </summary>
        /// <param name="useTrainingLabels">If <c>true</c>, use a label file created in the &lt;link-to-label-tool-doc&gt; to provide training-time labels for training a model. If <c>false</c>, the model will be trained from forms only.</param>
        /// <param name="containerType">Type of container to use to execute training.</param>
        /// <param name="modelName">Optional model name.</param>
        /// <returns>A <see cref="DisposableTrainedModel"/> instance from which the trained model ID can be obtained.</returns>
        protected async ValueTask<DisposableTrainedModel> CreateDisposableTrainedModelAsync(bool useTrainingLabels, ContainerType containerType = default, string modelName = default)
        {
            if (!useTrainingLabels)
            {
                Assert.Ignore("https://github.com/Azure/azure-sdk-for-net/issues/47689");
            }

            var client = CreateFormTrainingClient();
            string trainingFiles = containerType switch
            {
                ContainerType.Singleforms => TestEnvironment.BlobContainerSasUrl,
                ContainerType.MultipageFiles => TestEnvironment.MultipageBlobContainerSasUrl,
                ContainerType.SelectionMarks => TestEnvironment.SelectionMarkBlobContainerSasUrl,
                _ => TestEnvironment.BlobContainerSasUrl,
            };
            var trainingFilesUri = new Uri(trainingFiles);

            // Skip caching on record and playback modes.
            if (Recording.Mode == RecordedTestMode.Record || Recording.Mode == RecordedTestMode.Playback)
            {
                return await DisposableTrainedModel.TrainModelAsync(client, trainingFilesUri, useTrainingLabels, modelName);
            }

            var modelKey = new TrainedModelCache.ModelKey(_serviceVersion, containerType.ToString(), useTrainingLabels, modelName);

            if (!TrainedModelCache.Models.TryGetValue(modelKey, out DisposableTrainedModel model))
            {
                model = await DisposableTrainedModel.TrainModelAsync(client, trainingFilesUri, useTrainingLabels, modelName, deleteOnDisposal: false);
                TrainedModelCache.Models.Add(modelKey, model);
            }

            return model;
        }

        protected void ValidatePrebuiltForm(RecognizedForm recognizedForm, bool includeFieldElements, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.NotNull(recognizedForm.FormType);
            Assert.That(recognizedForm.FormTypeConfidence.HasValue, Is.True);
            Assert.That(recognizedForm.FormTypeConfidence.Value, Is.LessThanOrEqualTo(1.0).Within(0.005));
            Assert.IsNull(recognizedForm.ModelId);

            ValidateRecognizedForm(recognizedForm, includeFieldElements, expectedFirstPageNumber, expectedLastPageNumber);
        }

        protected void ValidateRecognizedForm(RecognizedForm recognizedForm, bool includeFieldElements, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.That(recognizedForm.PageRange.FirstPageNumber, Is.EqualTo(expectedFirstPageNumber));
            Assert.That(recognizedForm.PageRange.LastPageNumber, Is.EqualTo(expectedLastPageNumber));

            Assert.NotNull(recognizedForm.Pages);
            Assert.That(recognizedForm.Pages.Count, Is.EqualTo(expectedLastPageNumber - expectedFirstPageNumber + 1));

            int expectedPageNumber = expectedFirstPageNumber;

            for (int pageIndex = 0; pageIndex < recognizedForm.Pages.Count; pageIndex++)
            {
                var formPage = recognizedForm.Pages[pageIndex];
                ValidateFormPage(formPage, includeFieldElements, expectedPageNumber);

                expectedPageNumber++;
            }

            Assert.NotNull(recognizedForm.Fields);

            foreach (var field in recognizedForm.Fields.Values)
            {
                if (field == null)
                {
                    continue;
                }

                Assert.NotNull(field.Name);

                Assert.That(field.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                Assert.That(field.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));

                ValidateFieldData(field.LabelData, includeFieldElements);

                if (field.Value.ValueType == FieldValueType.SelectionMark)
                {
                    ValidateFieldData(field.ValueData, includeFieldElements, true);
                }
                else
                {
                    ValidateFieldData(field.ValueData, includeFieldElements);
                }
            }
        }

        private void ValidateFieldData(FieldData fieldData, bool includeFieldElements, bool selectionMarks = false)
        {
            if (fieldData == null)
            {
                return;
            }

            Assert.Greater(fieldData.PageNumber, 0);

            Assert.NotNull(fieldData.BoundingBox.Points);

            if (fieldData.BoundingBox.Points.Length != 0)
            {
                Assert.That(fieldData.BoundingBox.Points.Length, Is.EqualTo(4));
            }

            if (selectionMarks)
            {
                Assert.IsNull(fieldData.Text);
            }
            else
            {
                Assert.NotNull(fieldData.Text);
            }

            Assert.NotNull(fieldData.FieldElements);

            if (!includeFieldElements)
            {
                Assert.That(fieldData.FieldElements.Count, Is.EqualTo(0));
            }
        }

        protected void ValidateFormPage(FormPage formPage, bool includeFieldElements, int expectedPageNumber)
        {
            Assert.That(formPage.PageNumber, Is.EqualTo(expectedPageNumber));

            Assert.Greater(formPage.Width, 0.0);
            Assert.Greater(formPage.Height, 0.0);

            Assert.That(formPage.TextAngle, Is.GreaterThan(-180.0).Within(0.01));
            Assert.That(formPage.TextAngle, Is.LessThanOrEqualTo(180.0).Within(0.01));

            Assert.NotNull(formPage.Lines);

            if (!includeFieldElements)
            {
                Assert.That(formPage.Lines.Count, Is.EqualTo(0));
            }

            foreach (var line in formPage.Lines)
            {
                Assert.That(line.PageNumber, Is.EqualTo(expectedPageNumber));
                Assert.NotNull(line.BoundingBox.Points);
                Assert.That(line.BoundingBox.Points.Length, Is.EqualTo(4));
                Assert.NotNull(line.Text);

                if (line.Appearance != null)
                {
                    Assert.IsNotNull(line.Appearance.Style);
                    Assert.That(line.Appearance.Style.Name == TextStyleName.Handwriting || line.Appearance.Style.Name == TextStyleName.Other, Is.True);
                    Assert.Greater(line.Appearance.Style.Confidence, 0f);
                }

                Assert.NotNull(line.Words);
                Assert.Greater(line.Words.Count, 0);

                foreach (var word in line.Words)
                {
                    Assert.That(word.PageNumber, Is.EqualTo(expectedPageNumber));
                    Assert.NotNull(word.BoundingBox.Points);
                    Assert.That(word.BoundingBox.Points.Length, Is.EqualTo(4));
                    Assert.NotNull(word.Text);

                    Assert.That(word.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                    Assert.That(word.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));
                }
            }

            Assert.NotNull(formPage.Tables);

            foreach (var table in formPage.Tables)
            {
                Assert.That(table.PageNumber, Is.EqualTo(expectedPageNumber));
                Assert.Greater(table.ColumnCount, 0);
                Assert.Greater(table.RowCount, 0);
                if (_serviceVersion != FormRecognizerClientOptions.ServiceVersion.V2_0)
                {
                    Assert.That(table.BoundingBox.Points.Count(), Is.EqualTo(4));
                }

                Assert.NotNull(table.Cells);

                foreach (var cell in table.Cells)
                {
                    Assert.That(cell.PageNumber, Is.EqualTo(expectedPageNumber));
                    Assert.NotNull(cell.BoundingBox.Points);
                    Assert.That(cell.BoundingBox.Points.Length, Is.EqualTo(4));

                    Assert.GreaterOrEqual(cell.ColumnIndex, 0);
                    Assert.GreaterOrEqual(cell.RowIndex, 0);
                    Assert.GreaterOrEqual(cell.ColumnSpan, 1);
                    Assert.GreaterOrEqual(cell.RowSpan, 1);

                    Assert.That(cell.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                    Assert.That(cell.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));

                    Assert.NotNull(cell.Text);
                    Assert.NotNull(cell.FieldElements);

                    if (!includeFieldElements)
                    {
                        Assert.That(cell.FieldElements.Count, Is.EqualTo(0));
                    }

                    foreach (var element in cell.FieldElements)
                    {
                        Assert.That(element.PageNumber, Is.EqualTo(expectedPageNumber));
                        Assert.NotNull(element.BoundingBox.Points);
                        Assert.That(element.BoundingBox.Points.Length, Is.EqualTo(4));

                        Assert.That(element is FormWord || element is FormLine || element is FormSelectionMark, Is.True);

                        if (element is FormWord || element is FormLine)
                        {
                            Assert.NotNull(element.Text);
                        }
                        else if (element is FormSelectionMark)
                        {
                            Assert.IsNull(element.Text);
                        }
                    }
                }
            }

            Assert.NotNull(formPage.SelectionMarks);

            foreach (var selectionMark in formPage.SelectionMarks)
            {
                Assert.That(selectionMark.PageNumber, Is.EqualTo(expectedPageNumber));
                Assert.NotNull(selectionMark.BoundingBox.Points);
                Assert.That(selectionMark.BoundingBox.Points.Length, Is.EqualTo(4));
                Assert.IsNull(selectionMark.Text);
                Assert.NotNull(selectionMark.State);
                Assert.That(selectionMark.Confidence, Is.GreaterThanOrEqualTo(0.0).Within(0.01));
                Assert.That(selectionMark.Confidence, Is.LessThanOrEqualTo(1.0).Within(0.01));
            }
        }

        protected enum ContainerType
        {
            Singleforms,
            MultipageFiles,
            SelectionMarks
        }
    }
}
