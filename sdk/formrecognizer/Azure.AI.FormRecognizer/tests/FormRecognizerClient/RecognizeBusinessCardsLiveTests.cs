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
    /// The suite of tests for the `StartRecognizeBusinessCards` methods in the <see cref="FormRecognizerClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [ClientTestFixture(FormRecognizerClientOptions.ServiceVersion.V2_1)]
    public class RecognizeBusinessCardsLiveTests : FormRecognizerLiveTestBase
    {
        public RecognizeBusinessCardsLiveTests(bool isAsync, FormRecognizerClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        public async Task StartRecognizeBusinessCardsCanAuthenticateWithTokenCredential()
        {
            var client = CreateFormRecognizerClient(useTokenCredential: true);
            RecognizeBusinessCardsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.BusinessCardJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeBusinessCardsAsync(stream);
            }

            // Sanity check to make sure we got an actual response back from the service.

            RecognizedFormCollection formPage = await operation.WaitForCompletionAsync();

            RecognizedForm form = formPage.Single();
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
        public async Task StartRecognizeBusinessCardsPopulatesExtractedJpg(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeBusinessCardsOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.BusinessCardJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeBusinessCardsAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.BusinessCardJpg);
                operation = await client.StartRecognizeBusinessCardsFromUriAsync(uri);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            var form = operation.Value.Single();

            Assert.NotNull(form);

            ValidatePrebuiltForm(
                form,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the business card. We are not testing the service here, but the SDK.

            Assert.AreEqual("prebuilt:businesscard", form.FormType);
            Assert.AreEqual(1, form.PageRange.FirstPageNumber);
            Assert.AreEqual(1, form.PageRange.LastPageNumber);

            Assert.NotNull(form.Fields);

            Assert.True(form.Fields.ContainsKey("ContactNames"));
            Assert.True(form.Fields.ContainsKey("JobTitles"));
            Assert.True(form.Fields.ContainsKey("Departments"));
            Assert.True(form.Fields.ContainsKey("Emails"));
            Assert.True(form.Fields.ContainsKey("Websites"));
            Assert.True(form.Fields.ContainsKey("MobilePhones"));
            Assert.True(form.Fields.ContainsKey("WorkPhones"));
            Assert.True(form.Fields.ContainsKey("Faxes"));
            Assert.True(form.Fields.ContainsKey("Addresses"));
            Assert.True(form.Fields.ContainsKey("CompanyNames"));

            var contactNames = form.Fields["ContactNames"].Value.AsList();
            Assert.AreEqual(1, contactNames.Count);
            Assert.AreEqual("Dr. Avery Smith", contactNames.FirstOrDefault().ValueData.Text);
            Assert.AreEqual(1, contactNames.FirstOrDefault().ValueData.PageNumber);

            var contactNamesDict = contactNames.FirstOrDefault().Value.AsDictionary();

            Assert.True(contactNamesDict.ContainsKey("FirstName"));
            Assert.AreEqual("Avery", contactNamesDict["FirstName"].Value.AsString());

            Assert.True(contactNamesDict.ContainsKey("LastName"));
            Assert.AreEqual("Smith", contactNamesDict["LastName"].Value.AsString());

            var jobTitles = form.Fields["JobTitles"].Value.AsList();
            Assert.AreEqual(1, jobTitles.Count);
            Assert.AreEqual("Senior Researcher", jobTitles.FirstOrDefault().Value.AsString());

            var departments = form.Fields["Departments"].Value.AsList();
            Assert.AreEqual(1, departments.Count);
            Assert.AreEqual("Cloud & Al Department", departments.FirstOrDefault().Value.AsString());

            var emails = form.Fields["Emails"].Value.AsList();
            Assert.AreEqual(1, emails.Count);
            Assert.AreEqual("avery.smith@contoso.com", emails.FirstOrDefault().Value.AsString());

            var websites = form.Fields["Websites"].Value.AsList();
            Assert.AreEqual(1, websites.Count);
            Assert.AreEqual("https://www.contoso.com/", websites.FirstOrDefault().Value.AsString());

            // Update validation when https://github.com/Azure/azure-sdk-for-python/issues/14300 is fixed
            var mobilePhones = form.Fields["MobilePhones"].Value.AsList();
            Assert.AreEqual(1, mobilePhones.Count);
            Assert.AreEqual(FieldValueType.PhoneNumber, mobilePhones.FirstOrDefault().Value.ValueType);

            var otherPhones = form.Fields["WorkPhones"].Value.AsList();
            Assert.AreEqual(1, otherPhones.Count);
            Assert.AreEqual(FieldValueType.PhoneNumber, otherPhones.FirstOrDefault().Value.ValueType);

            var faxes = form.Fields["Faxes"].Value.AsList();
            Assert.AreEqual(1, faxes.Count);
            Assert.AreEqual(FieldValueType.PhoneNumber, faxes.FirstOrDefault().Value.ValueType);

            var addresses = form.Fields["Addresses"].Value.AsList();
            Assert.AreEqual(1, addresses.Count);
            Assert.AreEqual("2 Kingdom Street Paddington, London, W2 6BD", addresses.FirstOrDefault().Value.AsString());

            var companyNames = form.Fields["CompanyNames"].Value.AsList();
            Assert.AreEqual(1, companyNames.Count);
            Assert.AreEqual("Contoso", companyNames.FirstOrDefault().Value.AsString());
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeBusinessCardsPopulatesExtractedPng(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            RecognizeBusinessCardsOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.BusinessCardJpg);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeBusinessCardsAsync(stream);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.BusinessCardtPng);
                operation = await client.StartRecognizeBusinessCardsFromUriAsync(uri);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            var form = operation.Value.Single();

            Assert.NotNull(form);

            ValidatePrebuiltForm(
                form,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the business card. We are not testing the service here, but the SDK.

            Assert.AreEqual("prebuilt:businesscard", form.FormType);
            Assert.AreEqual(1, form.PageRange.FirstPageNumber);
            Assert.AreEqual(1, form.PageRange.LastPageNumber);

            Assert.NotNull(form.Fields);

            Assert.True(form.Fields.ContainsKey("ContactNames"));
            Assert.True(form.Fields.ContainsKey("JobTitles"));
            Assert.True(form.Fields.ContainsKey("Departments"));
            Assert.True(form.Fields.ContainsKey("Emails"));
            Assert.True(form.Fields.ContainsKey("Websites"));
            Assert.True(form.Fields.ContainsKey("MobilePhones"));
            Assert.True(form.Fields.ContainsKey("WorkPhones"));
            Assert.True(form.Fields.ContainsKey("Faxes"));
            Assert.True(form.Fields.ContainsKey("Addresses"));
            Assert.True(form.Fields.ContainsKey("CompanyNames"));

            var contactNames = form.Fields["ContactNames"].Value.AsList();
            Assert.AreEqual(1, contactNames.Count);
            Assert.AreEqual("Dr. Avery Smith", contactNames.FirstOrDefault().ValueData.Text);
            Assert.AreEqual(1, contactNames.FirstOrDefault().ValueData.PageNumber);

            var contactNamesDict = contactNames.FirstOrDefault().Value.AsDictionary();

            Assert.True(contactNamesDict.ContainsKey("FirstName"));
            Assert.AreEqual("Avery", contactNamesDict["FirstName"].Value.AsString());

            Assert.True(contactNamesDict.ContainsKey("LastName"));
            Assert.AreEqual("Smith", contactNamesDict["LastName"].Value.AsString());

            var jobTitles = form.Fields["JobTitles"].Value.AsList();
            Assert.AreEqual(1, jobTitles.Count);
            Assert.AreEqual("Senior Researcher", jobTitles.FirstOrDefault().Value.AsString());

            var departments = form.Fields["Departments"].Value.AsList();
            Assert.AreEqual(1, departments.Count);
            Assert.AreEqual("Cloud & Al Department", departments.FirstOrDefault().Value.AsString());

            var emails = form.Fields["Emails"].Value.AsList();
            Assert.AreEqual(1, emails.Count);
            Assert.AreEqual("avery.smith@contoso.com", emails.FirstOrDefault().Value.AsString());

            var websites = form.Fields["Websites"].Value.AsList();
            Assert.AreEqual(1, websites.Count);
            Assert.AreEqual("https://www.contoso.com/", websites.FirstOrDefault().Value.AsString());

            // Update validation when https://github.com/Azure/azure-sdk-for-python/issues/14300 is fixed
            var mobilePhones = form.Fields["MobilePhones"].Value.AsList();
            Assert.AreEqual(1, mobilePhones.Count);
            Assert.AreEqual(FieldValueType.PhoneNumber, mobilePhones.FirstOrDefault().Value.ValueType);

            var otherPhones = form.Fields["WorkPhones"].Value.AsList();
            Assert.AreEqual(1, otherPhones.Count);
            Assert.AreEqual(FieldValueType.PhoneNumber, otherPhones.FirstOrDefault().Value.ValueType);

            var faxes = form.Fields["Faxes"].Value.AsList();
            Assert.AreEqual(1, faxes.Count);
            Assert.AreEqual(FieldValueType.PhoneNumber, faxes.FirstOrDefault().Value.ValueType);

            var addresses = form.Fields["Addresses"].Value.AsList();
            Assert.AreEqual(1, addresses.Count);
            Assert.AreEqual("2 Kingdom Street Paddington, London, W2 6BD", addresses.FirstOrDefault().Value.AsString());

            var companyNames = form.Fields["CompanyNames"].Value.AsList();
            Assert.AreEqual(1, companyNames.Count);
            Assert.AreEqual("Contoso", companyNames.FirstOrDefault().Value.AsString());
        }

        [RecordedTest]
        public async Task StartRecognizeBusinessCardsIncludeFieldElements()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeBusinessCardsOptions() { IncludeFieldElements = true };
            RecognizeBusinessCardsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.BusinessCardJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeBusinessCardsAsync(stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            var businessCardsForm = recognizedForms.Single();

            ValidatePrebuiltForm(
                businessCardsForm,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);
        }

        [RecordedTest]
        public async Task StartRecognizeBusinessCardsCanParseBlankPage()
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeBusinessCardsOptions() { IncludeFieldElements = true };
            RecognizeBusinessCardsOperation operation;

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeBusinessCardsAsync(stream, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            var blankForm = recognizedForms.Single();

            ValidatePrebuiltForm(
                blankForm,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            Assert.AreEqual(0, blankForm.Fields.Count);

            var blankPage = blankForm.Pages.Single();

            Assert.AreEqual(0, blankPage.Lines.Count);
            Assert.AreEqual(0, blankPage.Tables.Count);
            Assert.AreEqual(0, blankPage.SelectionMarks.Count);
        }

        /// <summary>
        /// Verifies that the <see cref="FormRecognizerClient" /> is able to connect to the Form
        /// Recognizer cognitive service and handle returned errors.
        /// </summary>
        [RecordedTest]
        public void StartRecognizeBusinessCardsFromUriThrowsForNonExistingContent()
        {
            var client = CreateFormRecognizerClient();
            var invalidUri = new Uri("https://idont.ex.ist");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeBusinessCardsFromUriAsync(invalidUri));
            Assert.AreEqual("InvalidImage", ex.ErrorCode);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartRecognizeBusinessCardsCanParseMultipageForm(bool useStream)
        {
            var client = CreateFormRecognizerClient();
            var options = new RecognizeBusinessCardsOptions() { IncludeFieldElements = true };
            RecognizeBusinessCardsOperation operation;

            if (useStream)
            {
                using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.BusinessMultipage);
                using (Recording.DisableRequestBodyRecording())
                {
                    operation = await client.StartRecognizeBusinessCardsAsync(stream, options);
                }
            }
            else
            {
                var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.BusinessMultipage);
                operation = await client.StartRecognizeBusinessCardsFromUriAsync(uri, options);
            }

            RecognizedFormCollection recognizedForms = await operation.WaitForCompletionAsync();

            Assert.AreEqual(2, recognizedForms.Count);

            for (int formIndex = 0; formIndex < recognizedForms.Count; formIndex++)
            {
                var recognizedForm = recognizedForms[formIndex];
                var expectedPageNumber = formIndex + 1;

                Assert.NotNull(recognizedForm);

                ValidatePrebuiltForm(
                    recognizedForm,
                    includeFieldElements: true,
                    expectedFirstPageNumber: expectedPageNumber,
                    expectedLastPageNumber: expectedPageNumber);

                // Basic sanity test to make sure pages are ordered correctly.
                Assert.IsTrue(recognizedForm.Fields.ContainsKey("Emails"));
                FormField sampleFields = recognizedForm.Fields["Emails"];
                Assert.AreEqual(FieldValueType.List, sampleFields.Value.ValueType);
                var field = sampleFields.Value.AsList().Single();

                if (formIndex == 0)
                {
                    Assert.AreEqual("johnsinger@contoso.com", field.ValueData.Text);
                }
                else if (formIndex == 1)
                {
                    Assert.AreEqual("avery.smith@contoso.com", field.ValueData.Text);
                }

                // Check for ContactNames.Page value
                Assert.IsTrue(recognizedForm.Fields.ContainsKey("ContactNames"));
                FormField contactNameField = recognizedForm.Fields["ContactNames"].Value.AsList().Single();
                Assert.AreEqual(formIndex + 1, contactNameField.ValueData.PageNumber);
            }
        }

        [RecordedTest]
        public void StartRecognizeBusinessCardsWithWrongLocale()
        {
            var client = CreateFormRecognizerClient();

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.BusinessCardJpg);
            RequestFailedException ex;

            using (Recording.DisableRequestBodyRecording())
            {
                ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeBusinessCardsAsync(stream, new RecognizeBusinessCardsOptions() { Locale = "not-locale" }));
            }
            Assert.AreEqual("UnsupportedLocale", ex.ErrorCode);
        }
    }
}
