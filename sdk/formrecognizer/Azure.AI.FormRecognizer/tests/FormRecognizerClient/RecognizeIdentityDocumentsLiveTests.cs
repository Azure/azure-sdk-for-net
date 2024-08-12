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
    /// The suite of tests for the `StartRecognizeIdentityDocuments` methods in the <see cref="FormRecognizerClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [ClientTestFixture(FormRecognizerClientOptions.ServiceVersion.V2_1)]
    public class RecognizeIdentityDocumentsLiveTests : FormRecognizerLiveTestBase
    {
        public RecognizeIdentityDocumentsLiveTests(bool isAsync, FormRecognizerClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        public async Task StartRecognizeIdentityDocumentsCanAuthenticateWithTokenCredential()
        {
            var client = CreateFormRecognizerClient(useTokenCredential: true);
            RecognizeIdentityDocumentsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.DriverLicenseJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeIdentityDocumentsAsync(stream);
            }

            // Sanity check to make sure we got an actual response back from the service.

            RecognizedFormCollection formCollection = await operation.WaitForCompletionAsync();

            RecognizedForm form = formCollection.Single();
            Assert.NotNull(form);

            ValidatePrebuiltForm(
                form,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeIdentityDocumentsPopulatesExtractedIdDocumentJpg(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeIdentityDocumentsOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.DriverLicenseJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeIdentityDocumentsAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.DriverLicenseJpg);
                operation = await client.StartRecognizeIdentityDocumentsFromUriAsync(uri);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            var form = operation.Value.Single();

            Assert.NotNull(form);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the ID document. We are not testing the service here, but the SDK.

            Assert.AreEqual("prebuilt:idDocument:driverLicense", form.FormType);
            Assert.AreEqual(1, form.PageRange.FirstPageNumber);
            Assert.AreEqual(1, form.PageRange.LastPageNumber);

            Assert.NotNull(form.Fields);

            Assert.True(form.Fields.ContainsKey("Address"));
            Assert.True(form.Fields.ContainsKey("CountryRegion"));
            Assert.True(form.Fields.ContainsKey("DateOfBirth"));
            Assert.True(form.Fields.ContainsKey("DateOfExpiration"));
            Assert.True(form.Fields.ContainsKey("DocumentNumber"));
            Assert.True(form.Fields.ContainsKey("FirstName"));
            Assert.True(form.Fields.ContainsKey("LastName"));
            Assert.True(form.Fields.ContainsKey("Region"));
            Assert.True(form.Fields.ContainsKey("Sex"));

            Assert.AreEqual("123 STREET ADDRESS YOUR CITY WA 99999-1234", form.Fields["Address"].Value.AsString());
            Assert.AreEqual("WDLABCD456DG", form.Fields["DocumentNumber"].Value.AsString());
            Assert.AreEqual("LIAM R.", form.Fields["FirstName"].Value.AsString());
            Assert.AreEqual("TALBOT", form.Fields["LastName"].Value.AsString());
            Assert.AreEqual("Washington", form.Fields["Region"].Value.AsString());
            Assert.AreEqual("M", form.Fields["Sex"].Value.AsString());

            Assert.That(form.Fields["CountryRegion"].Value.AsCountryRegion(), Is.EqualTo("USA"));

            var dateOfBirth = form.Fields["DateOfBirth"].Value.AsDate();
            Assert.AreEqual(6, dateOfBirth.Day);
            Assert.AreEqual(1, dateOfBirth.Month);
            Assert.AreEqual(1958, dateOfBirth.Year);

            var dateOfExpiration = form.Fields["DateOfExpiration"].Value.AsDate();
            Assert.AreEqual(12, dateOfExpiration.Day);
            Assert.AreEqual(8, dateOfExpiration.Month);
            Assert.AreEqual(2020, dateOfExpiration.Year);
        }

        [RecordedTest]
        public async Task StartRecognizeIdentityDocumentsIncludeFieldElements()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeIdentityDocumentsOptions() { IncludeFieldElements = true };
            RecognizeIdentityDocumentsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.DriverLicenseJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeIdentityDocumentsAsync(stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            var form = recognizedForms.Single();

            ValidatePrebuiltForm(
                form,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);
        }

        [RecordedTest]
        public async Task StartRecognizeIdentityDocumentsCanParseBlankPage()
        {
            var client = CreateFormRecognizerClient();
            RecognizeIdentityDocumentsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeIdentityDocumentsAsync(stream);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            Assert.IsEmpty(recognizedForms);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [RecordedTest]
        public void StartRecognizeIdentityDocumentsFromUriThrowsForNonExistingContent()
        {
            var client = CreateFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeIdentityDocumentsFromUriAsync(invalidUri));
            Assert.AreEqual("InvalidImage", ex.ErrorCode);
        }
    }
}
