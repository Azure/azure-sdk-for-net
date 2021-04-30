// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

/// <summary>
/// The suite of tests for the `StartRecognizeIdDocuments` methods in the <see cref="FormRecognizerClient"/> class.
/// </summary>
/// <remarks>
/// These tests have a dependency on live Azure services and may incur costs for the associated
/// Azure subscription.
/// </remarks>
namespace Azure.AI.FormRecognizer.Tests
{
    [ClientTestFixture(FormRecognizerClientOptions.ServiceVersion.V2_1_Preview_3)]
    public class RecognizeIdDocumentsLiveTests : FormRecognizerLiveTestBase
    {
        public RecognizeIdDocumentsLiveTests(bool isAsync, FormRecognizerClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        public async Task StartRecognizeIdDocumentsCanAuthenticateWithTokenCredential()
        {
            var client = CreateFormRecognizerClient(useTokenCredential: true);
            RecognizeIdDocumentsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.DriverLicenseJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeIdDocumentsAsync(stream);
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
        public async Task StartRecognizeIdDocumentsPopulatesExtractedIdDocumentJpg(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeIdDocumentsOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.DriverLicenseJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeIdDocumentsAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.DriverLicenseJpg);
                operation = await client.StartRecognizeIdDocumentsFromUriAsync(uri);
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
            Assert.True(form.Fields.ContainsKey("Country"));
            Assert.True(form.Fields.ContainsKey("DateOfBirth"));
            Assert.True(form.Fields.ContainsKey("DateOfExpiration"));
            Assert.True(form.Fields.ContainsKey("DocumentNumber"));
            Assert.True(form.Fields.ContainsKey("FirstName"));
            Assert.True(form.Fields.ContainsKey("LastName"));
            Assert.True(form.Fields.ContainsKey("Region"));
            Assert.True(form.Fields.ContainsKey("Sex"));

            Assert.AreEqual("123 STREET ADDRESS YOUR CITY WA 99999-1234", form.Fields["Address"].Value.AsString());
            Assert.AreEqual("LICWDLACD5DG", form.Fields["DocumentNumber"].Value.AsString());
            Assert.AreEqual("LIAM R.", form.Fields["FirstName"].Value.AsString());
            Assert.AreEqual("TALBOT", form.Fields["LastName"].Value.AsString());
            Assert.AreEqual("Washington", form.Fields["Region"].Value.AsString());

            Assert.That(form.Fields["Country"].Value.AsCountryCode(), Is.EqualTo("USA"));
            Assert.That(form.Fields["Sex"].Value.AsGender(), Is.EqualTo(FieldValueGender.M));

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
        public async Task StartRecognizeIdDocumentsIncludeFieldElements()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeIdDocumentsOptions() { IncludeFieldElements = true };
            RecognizeIdDocumentsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.DriverLicenseJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeIdDocumentsAsync(stream, options);
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
        public async Task StartRecognizeIdDocumentsCanParseBlankPage()
        {
            var client = CreateFormRecognizerClient();
            RecognizeIdDocumentsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeIdDocumentsAsync(stream);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            Assert.IsEmpty(recognizedForms);
        }

        [RecordedTest]
        public void StartRecognizeIdDocumentsThrowsForDamagedFile()
        {
            var client = CreateFormRecognizerClient();

            // First 4 bytes are PDF signature, but fill the rest of the "file" with garbage.

            var damagedFile = new byte[] { 0x25, 0x50, 0x44, 0x46, 0x55, 0x55, 0x55 };
            using var stream = new MemoryStream(damagedFile);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeIdDocumentsAsync(stream));
            Assert.AreEqual("BadArgument", ex.ErrorCode);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [RecordedTest]
        public void StartRecognizeIdDocumentsFromUriThrowsForNonExistingContent()
        {
            var client = CreateFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeIdDocumentsFromUriAsync(invalidUri));
            Assert.AreEqual("FailedToDownloadImage", ex.ErrorCode);
        }
    }
}
