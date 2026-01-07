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
            Assert.That(form, Is.Not.Null);

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

            Assert.That(operation.HasValue, Is.True);

            var form = operation.Value.Single();

            Assert.That(form, Is.Not.Null);

            Assert.Multiple(() =>
            {
                // The expected values are based on the values returned by the service, and not the actual
                // values present in the ID document. We are not testing the service here, but the SDK.

                Assert.That(form.FormType, Is.EqualTo("prebuilt:idDocument:driverLicense"));
                Assert.That(form.PageRange.FirstPageNumber, Is.EqualTo(1));
                Assert.That(form.PageRange.LastPageNumber, Is.EqualTo(1));

                Assert.That(form.Fields, Is.Not.Null);
            });

            Assert.Multiple(() =>
            {
                Assert.That(form.Fields.ContainsKey("Address"), Is.True);
                Assert.That(form.Fields.ContainsKey("CountryRegion"), Is.True);
                Assert.That(form.Fields.ContainsKey("DateOfBirth"), Is.True);
                Assert.That(form.Fields.ContainsKey("DateOfExpiration"), Is.True);
                Assert.That(form.Fields.ContainsKey("DocumentNumber"), Is.True);
                Assert.That(form.Fields.ContainsKey("FirstName"), Is.True);
                Assert.That(form.Fields.ContainsKey("LastName"), Is.True);
                Assert.That(form.Fields.ContainsKey("Region"), Is.True);
                Assert.That(form.Fields.ContainsKey("Sex"), Is.True);

                Assert.That(form.Fields["Address"].Value.AsString(), Is.EqualTo("123 STREET ADDRESS YOUR CITY WA 99999-1234"));
                Assert.That(form.Fields["DocumentNumber"].Value.AsString(), Is.EqualTo("WDLABCD456DG"));
                Assert.That(form.Fields["FirstName"].Value.AsString(), Is.EqualTo("LIAM R."));
                Assert.That(form.Fields["LastName"].Value.AsString(), Is.EqualTo("TALBOT"));
                Assert.That(form.Fields["Region"].Value.AsString(), Is.EqualTo("Washington"));
                Assert.That(form.Fields["Sex"].Value.AsString(), Is.EqualTo("M"));

                Assert.That(form.Fields["CountryRegion"].Value.AsCountryRegion(), Is.EqualTo("USA"));
            });

            var dateOfBirth = form.Fields["DateOfBirth"].Value.AsDate();
            Assert.Multiple(() =>
            {
                Assert.That(dateOfBirth.Day, Is.EqualTo(6));
                Assert.That(dateOfBirth.Month, Is.EqualTo(1));
                Assert.That(dateOfBirth.Year, Is.EqualTo(1958));
            });

            var dateOfExpiration = form.Fields["DateOfExpiration"].Value.AsDate();
            Assert.Multiple(() =>
            {
                Assert.That(dateOfExpiration.Day, Is.EqualTo(12));
                Assert.That(dateOfExpiration.Month, Is.EqualTo(8));
                Assert.That(dateOfExpiration.Year, Is.EqualTo(2020));
            });
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

            Assert.That(recognizedForms, Is.Empty);
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
            Assert.That(ex.ErrorCode, Is.EqualTo("InvalidImage"));
        }
    }
}
