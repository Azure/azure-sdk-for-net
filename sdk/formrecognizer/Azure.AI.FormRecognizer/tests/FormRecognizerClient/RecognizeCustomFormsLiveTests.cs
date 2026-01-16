// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the `StartRecognizeCustomForms` methods in the <see cref="FormRecognizerClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [ClientTestFixture(
    FormRecognizerClientOptions.ServiceVersion.V2_0,
    FormRecognizerClientOptions.ServiceVersion.V2_1)]
    public class RecognizeCustomFormsLiveTests : FormRecognizerLiveTestBase
    {
        public RecognizeCustomFormsLiveTests(bool isAsync, FormRecognizerClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomFormsCanAuthenticateWithTokenCredential(bool useTrainingLabels)
        {
            var client = CreateFormRecognizerClient(useTokenCredential: true);
            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels);
            RecognizeCustomFormsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Form1);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream);
            }

            // Sanity check to make sure we got an actual response back from the service.

            RecognizedFormCollection formPage = await operation.WaitForCompletionAsync();

            RecognizedForm form = formPage.Single();
            Assert.That(form, Is.Not.Null);

            if (useTrainingLabels)
            {
                ValidateModelWithLabelsForm(
                                form,
                                trainedModel.ModelId,
                                includeFieldElements: false,
                                expectedFirstPageNumber: 1,
                                expectedLastPageNumber: 1);
            }
            else
            {
                ValidateModelWithNoLabelsForm(
                                form,
                                trainedModel.ModelId,
                                includeFieldElements: false,
                                expectedFirstPageNumber: 1,
                                expectedLastPageNumber: 1);
            }
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and perform analysis based on a custom labeled model.
        /// </summary>
        [RecordedTest]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public async Task StartRecognizeCustomFormsWithLabels(bool useStream, bool includeFieldElements)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions { IncludeFieldElements = includeFieldElements };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Form1);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Form1);
                operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri, options);
            }

            await operation.WaitForCompletionAsync();

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Count, Is.GreaterThanOrEqualTo(1));

            RecognizedForm form = operation.Value.Single();

            ValidateModelWithLabelsForm(
                form,
                trainedModel.ModelId,
                includeFieldElements: includeFieldElements,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            // Testing that we shuffle things around correctly so checking only once per property.

            Assert.That(form.FormType, Is.Not.Empty);
            Assert.That(form.FormTypeConfidence.HasValue, Is.True);
            Assert.That(form.Pages.Count, Is.EqualTo(1));
            Assert.That(form.Pages[0].Height, Is.EqualTo(2200));
            Assert.That(form.Pages[0].PageNumber, Is.EqualTo(1));
            Assert.That(form.Pages[0].Unit, Is.EqualTo(LengthUnit.Pixel));
            Assert.That(form.Pages[0].Width, Is.EqualTo(1700));

            Assert.That(form.Fields, Is.Not.Null);
            var name = "PurchaseOrderNumber";
            Assert.That(form.Fields[name], Is.Not.Null);
            Assert.That(form.Fields[name].Value.ValueType, Is.EqualTo(FieldValueType.String));
            Assert.That(form.Fields[name].ValueData.Text, Is.EqualTo("948284"));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task StartRecognizeCustomFormsWithLabelsAndSelectionMarks(bool includeFieldElements)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions { IncludeFieldElements = includeFieldElements };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true, ContainerType.SelectionMarks);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.FormSelectionMarks);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
            }

            await operation.WaitForCompletionAsync();

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Count, Is.GreaterThanOrEqualTo(1));

            RecognizedForm form = operation.Value.Single();

            ValidateRecognizedForm(form, includeFieldElements: includeFieldElements,
                expectedFirstPageNumber: 1, expectedLastPageNumber: 1);

            // Testing that we shuffle things around correctly so checking only once per property.
            Assert.That(form.FormType, Is.Not.Empty);
            Assert.That(form.Fields, Is.Not.Null);
            var name = "AMEX_SELECTION_MARK";
            Assert.That(form.Fields[name], Is.Not.Null);
            Assert.That(form.Fields[name].Value.ValueType, Is.EqualTo(FieldValueType.SelectionMark));
            Assert.That(form.Fields[name].Value.AsSelectionMarkState(), Is.EqualTo(SelectionMarkState.Selected));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomFormsWithLabelsCanParseMultipageForm(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions() { IncludeFieldElements = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true, ContainerType.MultipageFiles);

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoiceMultipage);
                operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            var recognizedForm = recognizedForms.Single();

            ValidateModelWithLabelsForm(
                recognizedForm,
                trainedModel.ModelId,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 2);

            // Check some values to make sure that fields from both pages are being populated.

            Assert.That(recognizedForm.Fields["Contact"].Value.AsString(), Is.EqualTo("Jamie@southridgevideo.com"));
            Assert.That(recognizedForm.Fields["CompanyName"].Value.AsString(), Is.EqualTo("Southridge Video"));
            Assert.That(recognizedForm.Fields["Gold"].Value.AsString(), Is.EqualTo("$1,500"));
            Assert.That(recognizedForm.Fields["Bronze"].Value.AsString(), Is.EqualTo("$1,000"));

            Assert.That(recognizedForm.Pages.Count, Is.EqualTo(2));

            for (int pageIndex = 0; pageIndex < recognizedForm.Pages.Count; pageIndex++)
            {
                var formPage = recognizedForm.Pages[pageIndex];

                // Basic sanity test to make sure pages are ordered correctly.

                var sampleLine = formPage.Lines[1];
                var expectedText = pageIndex == 0 ? "Vendor Registration" : "Vendor Details:";

                Assert.That(sampleLine.Text, Is.EqualTo(expectedText));
            }
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/28556")]
        public async Task StartRecognizeCustomFormsWithLabelsCanParseBlankPage()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions() { IncludeFieldElements = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            var recognizedForm = recognizedForms.Single();

            ValidateModelWithLabelsForm(
                recognizedForm,
                trainedModel.ModelId,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            var blankPage = recognizedForm.Pages.Single();

            Assert.That(blankPage.Lines.Count, Is.EqualTo(0));
            Assert.That(blankPage.Tables.Count, Is.EqualTo(0));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomFormsWithLabelsCanParseMultipageFormWithBlankPage(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions() { IncludeFieldElements = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoiceMultipageBlank);
                operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            var recognizedForm = recognizedForms.Single();

            ValidateModelWithLabelsForm(
                recognizedForm,
                trainedModel.ModelId,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 3);

            for (int pageIndex = 0; pageIndex < recognizedForm.Pages.Count; pageIndex++)
            {
                if (pageIndex == 0 || pageIndex == 2)
                {
                    var formPage = recognizedForm.Pages[pageIndex];
                    var sampleLine = formPage.Lines[3];
                    var expectedText = pageIndex == 0 ? "Bilbo Baggins" : "Frodo Baggins";

                    Assert.That(sampleLine.Text, Is.EqualTo(expectedText));
                }
            }

            var blankPage = recognizedForm.Pages[1];

            Assert.That(blankPage.Lines.Count, Is.EqualTo(0));
            Assert.That(blankPage.Tables.Count, Is.EqualTo(0));
        }

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task StartRecognizeCustomFormsWithLabelsCanParseDifferentTypeOfForm()
        {
            var client = CreateFormRecognizerClient();
            RecognizeCustomFormsOperation operation;

            // Use Form_<id>.<ext> files for training with labels.

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            // Attempt to recognize a different type of form: Invoice_1.pdf. This form does not contain all the labels
            // the newly trained model expects.

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoicePdf);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream);
            }

            RecognizedFormCollection forms = await operation.WaitForCompletionAsync();
            var fields = forms.Single().Fields;

            // Verify that we got back at least one missing field to make sure we hit the code path we want to test.
            // The missing field is returned with its value set to null.

            Assert.That(fields.Values.Any(field =>
                field.Value.ValueType == FieldValueType.String && field.Value.AsString() == null), Is.True);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and perform analysis based on a custom labeled model.
        /// </summary>
        [RecordedTest]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public async Task StartRecognizeCustomFormsWithoutLabels(bool useStream, bool includeFieldElements)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions { IncludeFieldElements = includeFieldElements };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Form1);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Form1);
                operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri, options);
            }

            await operation.WaitForCompletionAsync();

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Count, Is.GreaterThanOrEqualTo(1));

            RecognizedForm form = operation.Value.Single();

            ValidateModelWithNoLabelsForm(
                form,
                trainedModel.ModelId,
                includeFieldElements: includeFieldElements,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            //testing that we shuffle things around correctly so checking only once per property

            Assert.That(form.FormType, Is.EqualTo("form-0"));
            Assert.That(form.FormTypeConfidence.HasValue, Is.False);
            Assert.That(form.Pages.Count, Is.EqualTo(1));
            Assert.That(form.Pages[0].Height, Is.EqualTo(2200));
            Assert.That(form.Pages[0].PageNumber, Is.EqualTo(1));
            Assert.That(form.Pages[0].Unit, Is.EqualTo(LengthUnit.Pixel));
            Assert.That(form.Pages[0].Width, Is.EqualTo(1700));

            Assert.That(form.Fields, Is.Not.Null);
            var name = "field-0";
            Assert.That(form.Fields[name], Is.Not.Null);
            Assert.That(form.Fields[name].LabelData.Text, Is.Not.Null);
            Assert.That(form.Fields[name].Value.ValueType, Is.EqualTo(FieldValueType.String));

            // Disable this verification for now.
            // Issue https://github.com/Azure/azure-sdk-for-net/issues/15075
            // Assert.AreEqual("Hero Limited", form.Fields[name].LabelData.Text);
        }

        [RecordedTest]
        public async Task StartRecognizeCustomFormsWithoutLabelsCanParseMultipageForm()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions() { IncludeFieldElements = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false, ContainerType.MultipageFiles);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipage);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            Assert.That(recognizedForms.Count, Is.EqualTo(2));

            for (int formIndex = 0; formIndex < recognizedForms.Count; formIndex++)
            {
                var recognizedForm = recognizedForms[formIndex];
                var expectedPageNumber = formIndex + 1;

                ValidateModelWithNoLabelsForm(
                    recognizedForm,
                    trainedModel.ModelId,
                    includeFieldElements: true,
                    expectedFirstPageNumber: expectedPageNumber,
                    expectedLastPageNumber: expectedPageNumber);
            }

            // Basic sanity test to make sure pages are ordered correctly.

            FormPage firstFormPage = recognizedForms[0].Pages.Single();
            FormTable firstFormTable = firstFormPage.Tables.Single();

            Assert.That(firstFormTable.Cells.Any(c => c.Text == "Gold Sponsor"), Is.True);

            FormField secondFormFieldInPage = recognizedForms[1].Fields.Values.Where(field => field.LabelData.Text.Contains("Company Name:")).FirstOrDefault();

            Assert.That(secondFormFieldInPage, Is.Not.Null);
            Assert.That(secondFormFieldInPage.ValueData, Is.Not.Null);
            Assert.That(secondFormFieldInPage.ValueData.Text, Is.EqualTo("Southridge Video"));
        }

        [RecordedTest]
        public async Task StartRecognizeCustomFormsFromUriWithoutLabelsThrowsWithMultipageForm()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions() { IncludeFieldElements = true };

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false, ContainerType.MultipageFiles);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoiceMultipage);
            var operation = await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, uri, options);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync());

            Assert.That(exception.ErrorCode, Is.EqualTo("2002"));
        }

        [RecordedTest]
        public async Task StartRecognizeCustomFormsWithoutLabelsCanParseBlankPage()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions() { IncludeFieldElements = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            var blankForm = recognizedForms.Single();

            ValidateModelWithNoLabelsForm(
                blankForm,
                trainedModel.ModelId,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            Assert.That(blankForm.Fields.Count, Is.EqualTo(0));

            var blankPage = blankForm.Pages.Single();

            Assert.That(blankPage.Lines.Count, Is.EqualTo(0));
            Assert.That(blankPage.Tables.Count, Is.EqualTo(0));
        }

        [RecordedTest]
        public async Task StartRecognizeCustomFormsWithoutLabelsCanParseMultipageFormWithBlankPage()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeCustomFormsOptions() { IncludeFieldElements = true };
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceMultipageBlank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            Assert.That(recognizedForms.Count, Is.EqualTo(3));

            for (int formIndex = 0; formIndex < recognizedForms.Count; formIndex++)
            {
                var recognizedForm = recognizedForms[formIndex];
                var expectedPageNumber = formIndex + 1;

                ValidateModelWithNoLabelsForm(
                    recognizedForm,
                    trainedModel.ModelId,
                    includeFieldElements: true,
                    expectedFirstPageNumber: expectedPageNumber,
                    expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.

                if (formIndex == 0 || formIndex == 2)
                {
                    var expectedValueData = formIndex == 0 ? "300.00" : "3000.00";

                    FormField fieldInPage = recognizedForm.Fields.Values.Where(field => field.LabelData.Text.Contains("Subtotal:")).FirstOrDefault();
                    Assert.That(fieldInPage, Is.Not.Null);
                    Assert.That(fieldInPage.ValueData, Is.Not.Null);
                    Assert.That(fieldInPage.ValueData.Text, Is.EqualTo(expectedValueData));
                }
            }

            var blankForm = recognizedForms[1];

            Assert.That(blankForm.Fields.Count, Is.EqualTo(0));

            var blankPage = blankForm.Pages.Single();

            Assert.That(blankPage.Lines.Count, Is.EqualTo(0));
            Assert.That(blankPage.Tables.Count, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeCustomFormsFromUriThrowsForNonExistingContent(bool useTrainingLabels)
        {
            var client = CreateFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeCustomFormsFromUriAsync(trainedModel.ModelId, invalidUri));

            Assert.That(ex.ErrorCode, Is.EqualTo("2001"));
        }

        private void ValidateModelWithNoLabelsForm(RecognizedForm recognizedForm, string modelId, bool includeFieldElements, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.That(recognizedForm.FormType, Is.Not.Null);
            Assert.That(recognizedForm.FormTypeConfidence.HasValue, Is.False);
            Assert.That(recognizedForm.ModelId, Is.Not.Null);
            Assert.That(recognizedForm.ModelId, Is.EqualTo(modelId));

            ValidateRecognizedForm(recognizedForm, includeFieldElements, expectedFirstPageNumber, expectedLastPageNumber);
        }

        private void ValidateModelWithLabelsForm(RecognizedForm recognizedForm, string modelId, bool includeFieldElements, int expectedFirstPageNumber, int expectedLastPageNumber)
        {
            Assert.That(recognizedForm.FormType, Is.Not.Null);
            Assert.That(recognizedForm.FormTypeConfidence.HasValue, Is.True);
            Assert.That(recognizedForm.ModelId, Is.EqualTo(modelId));

            ValidateRecognizedForm(recognizedForm, includeFieldElements, expectedFirstPageNumber, expectedLastPageNumber);
        }
    }
}
