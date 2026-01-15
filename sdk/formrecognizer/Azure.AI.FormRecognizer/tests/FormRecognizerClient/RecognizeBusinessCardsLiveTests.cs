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

            Assert.That(operation.HasValue, Is.True);

            var form = operation.Value.Single();

            Assert.NotNull(form);

            ValidatePrebuiltForm(
                form,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the business card. We are not testing the service here, but the SDK.

            Assert.That(form.FormType, Is.EqualTo("prebuilt:businesscard"));
            Assert.That(form.PageRange.FirstPageNumber, Is.EqualTo(1));
            Assert.That(form.PageRange.LastPageNumber, Is.EqualTo(1));

            Assert.NotNull(form.Fields);

            Assert.That(form.Fields.ContainsKey("ContactNames"), Is.True);
            Assert.That(form.Fields.ContainsKey("JobTitles"), Is.True);
            Assert.That(form.Fields.ContainsKey("Departments"), Is.True);
            Assert.That(form.Fields.ContainsKey("Emails"), Is.True);
            Assert.That(form.Fields.ContainsKey("Websites"), Is.True);
            Assert.That(form.Fields.ContainsKey("MobilePhones"), Is.True);
            Assert.That(form.Fields.ContainsKey("WorkPhones"), Is.True);
            Assert.That(form.Fields.ContainsKey("Faxes"), Is.True);
            Assert.That(form.Fields.ContainsKey("Addresses"), Is.True);
            Assert.That(form.Fields.ContainsKey("CompanyNames"), Is.True);

            var contactNames = form.Fields["ContactNames"].Value.AsList();
            Assert.That(contactNames.Count, Is.EqualTo(1));
            Assert.That(contactNames.FirstOrDefault().ValueData.Text, Is.EqualTo("Dr. Avery Smith"));
            Assert.That(contactNames.FirstOrDefault().ValueData.PageNumber, Is.EqualTo(1));

            var contactNamesDict = contactNames.FirstOrDefault().Value.AsDictionary();

            Assert.That(contactNamesDict.ContainsKey("FirstName"), Is.True);
            Assert.That(contactNamesDict["FirstName"].Value.AsString(), Is.EqualTo("Avery"));

            Assert.That(contactNamesDict.ContainsKey("LastName"), Is.True);
            Assert.That(contactNamesDict["LastName"].Value.AsString(), Is.EqualTo("Smith"));

            var jobTitles = form.Fields["JobTitles"].Value.AsList();
            Assert.That(jobTitles.Count, Is.EqualTo(1));
            Assert.That(jobTitles.FirstOrDefault().Value.AsString(), Is.EqualTo("Senior Researcher"));

            var departments = form.Fields["Departments"].Value.AsList();
            Assert.AreEqual(1, departments.Count);
            Assert.That(departments.FirstOrDefault().Value.AsString(), Is.EqualTo("Cloud & Al Department"));

            var emails = form.Fields["Emails"].Value.AsList();
            Assert.AreEqual(1, emails.Count);
            Assert.That(emails.FirstOrDefault().Value.AsString(), Is.EqualTo("avery.smith@contoso.com"));

            var websites = form.Fields["Websites"].Value.AsList();
            Assert.AreEqual(1, websites.Count);
            Assert.That(websites.FirstOrDefault().Value.AsString(), Is.EqualTo("https://www.contoso.com/"));

            // Update validation when https://github.com/Azure/azure-sdk-for-python/issues/14300 is fixed
            var mobilePhones = form.Fields["MobilePhones"].Value.AsList();
            Assert.AreEqual(1, mobilePhones.Count);
            Assert.That(mobilePhones.FirstOrDefault().Value.ValueType, Is.EqualTo(FieldValueType.PhoneNumber));

            var otherPhones = form.Fields["WorkPhones"].Value.AsList();
            Assert.That(otherPhones.Count, Is.EqualTo(1));
            Assert.That(otherPhones.FirstOrDefault().Value.ValueType, Is.EqualTo(FieldValueType.PhoneNumber));

            var faxes = form.Fields["Faxes"].Value.AsList();
            Assert.That(faxes.Count, Is.EqualTo(1));
            Assert.That(faxes.FirstOrDefault().Value.ValueType, Is.EqualTo(FieldValueType.PhoneNumber));

            var addresses = form.Fields["Addresses"].Value.AsList();
            Assert.That(addresses.Count, Is.EqualTo(1));
            Assert.That(addresses.FirstOrDefault().Value.AsString(), Is.EqualTo("2 Kingdom Street Paddington, London, W2 6BD"));

            var companyNames = form.Fields["CompanyNames"].Value.AsList();
            Assert.AreEqual(1, companyNames.Count);
            Assert.That(companyNames.FirstOrDefault().Value.AsString(), Is.EqualTo("Contoso"));
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

            Assert.That(operation.HasValue, Is.True);

            var form = operation.Value.Single();

            Assert.NotNull(form);

            ValidatePrebuiltForm(
                form,
                includeFieldElements: true,
                expectedFirstPageNumber: 1,
                expectedLastPageNumber: 1);

            // The expected values are based on the values returned by the service, and not the actual
            // values present in the business card. We are not testing the service here, but the SDK.

            Assert.That(form.FormType, Is.EqualTo("prebuilt:businesscard"));
            Assert.That(form.PageRange.FirstPageNumber, Is.EqualTo(1));
            Assert.That(form.PageRange.LastPageNumber, Is.EqualTo(1));

            Assert.NotNull(form.Fields);

            Assert.That(form.Fields.ContainsKey("ContactNames"), Is.True);
            Assert.That(form.Fields.ContainsKey("JobTitles"), Is.True);
            Assert.That(form.Fields.ContainsKey("Departments"), Is.True);
            Assert.That(form.Fields.ContainsKey("Emails"), Is.True);
            Assert.That(form.Fields.ContainsKey("Websites"), Is.True);
            Assert.That(form.Fields.ContainsKey("MobilePhones"), Is.True);
            Assert.That(form.Fields.ContainsKey("WorkPhones"), Is.True);
            Assert.That(form.Fields.ContainsKey("Faxes"), Is.True);
            Assert.That(form.Fields.ContainsKey("Addresses"), Is.True);
            Assert.That(form.Fields.ContainsKey("CompanyNames"), Is.True);

            var contactNames = form.Fields["ContactNames"].Value.AsList();
            Assert.That(contactNames.Count, Is.EqualTo(1));
            Assert.That(contactNames.FirstOrDefault().ValueData.Text, Is.EqualTo("Dr. Avery Smith"));
            Assert.That(contactNames.FirstOrDefault().ValueData.PageNumber, Is.EqualTo(1));

            var contactNamesDict = contactNames.FirstOrDefault().Value.AsDictionary();

            Assert.That(contactNamesDict.ContainsKey("FirstName"), Is.True);
            Assert.That(contactNamesDict["FirstName"].Value.AsString(), Is.EqualTo("Avery"));

            Assert.That(contactNamesDict.ContainsKey("LastName"), Is.True);
            Assert.That(contactNamesDict["LastName"].Value.AsString(), Is.EqualTo("Smith"));

            var jobTitles = form.Fields["JobTitles"].Value.AsList();
            Assert.That(jobTitles.Count, Is.EqualTo(1));
            Assert.That(jobTitles.FirstOrDefault().Value.AsString(), Is.EqualTo("Senior Researcher"));

            var departments = form.Fields["Departments"].Value.AsList();
            Assert.AreEqual(1, departments.Count);
            Assert.That(departments.FirstOrDefault().Value.AsString(), Is.EqualTo("Cloud & Al Department"));

            var emails = form.Fields["Emails"].Value.AsList();
            Assert.AreEqual(1, emails.Count);
            Assert.That(emails.FirstOrDefault().Value.AsString(), Is.EqualTo("avery.smith@contoso.com"));

            var websites = form.Fields["Websites"].Value.AsList();
            Assert.AreEqual(1, websites.Count);
            Assert.That(websites.FirstOrDefault().Value.AsString(), Is.EqualTo("https://www.contoso.com/"));

            // Update validation when https://github.com/Azure/azure-sdk-for-python/issues/14300 is fixed
            var mobilePhones = form.Fields["MobilePhones"].Value.AsList();
            Assert.AreEqual(1, mobilePhones.Count);
            Assert.That(mobilePhones.FirstOrDefault().Value.ValueType, Is.EqualTo(FieldValueType.PhoneNumber));

            var otherPhones = form.Fields["WorkPhones"].Value.AsList();
            Assert.That(otherPhones.Count, Is.EqualTo(1));
            Assert.That(otherPhones.FirstOrDefault().Value.ValueType, Is.EqualTo(FieldValueType.PhoneNumber));

            var faxes = form.Fields["Faxes"].Value.AsList();
            Assert.That(faxes.Count, Is.EqualTo(1));
            Assert.That(faxes.FirstOrDefault().Value.ValueType, Is.EqualTo(FieldValueType.PhoneNumber));

            var addresses = form.Fields["Addresses"].Value.AsList();
            Assert.That(addresses.Count, Is.EqualTo(1));
            Assert.That(addresses.FirstOrDefault().Value.AsString(), Is.EqualTo("2 Kingdom Street Paddington, London, W2 6BD"));

            var companyNames = form.Fields["CompanyNames"].Value.AsList();
            Assert.AreEqual(1, companyNames.Count);
            Assert.That(companyNames.FirstOrDefault().Value.AsString(), Is.EqualTo("Contoso"));
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

            Assert.That(blankForm.Fields.Count, Is.EqualTo(0));

            var blankPage = blankForm.Pages.Single();

            Assert.That(blankPage.Lines.Count, Is.EqualTo(0));
            Assert.That(blankPage.Tables.Count, Is.EqualTo(0));
            Assert.That(blankPage.SelectionMarks.Count, Is.EqualTo(0));
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
            Assert.That(ex.ErrorCode, Is.EqualTo("InvalidImage"));
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

            Assert.That(recognizedForms.Count, Is.EqualTo(2));

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
                Assert.That(recognizedForm.Fields.ContainsKey("Emails"), Is.True);
                FormField sampleFields = recognizedForm.Fields["Emails"];
                Assert.That(sampleFields.Value.ValueType, Is.EqualTo(FieldValueType.List));
                var field = sampleFields.Value.AsList().Single();

                if (formIndex == 0)
                {
                    Assert.That(field.ValueData.Text, Is.EqualTo("johnsinger@contoso.com"));
                }
                else if (formIndex == 1)
                {
                    Assert.That(field.ValueData.Text, Is.EqualTo("avery.smith@contoso.com"));
                }

                // Check for ContactNames.Page value
                Assert.That(recognizedForm.Fields.ContainsKey("ContactNames"), Is.True);
                FormField contactNameField = recognizedForm.Fields["ContactNames"].Value.AsList().Single();
                Assert.That(contactNameField.ValueData.PageNumber, Is.EqualTo(formIndex + 1));
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
            Assert.That(ex.ErrorCode, Is.EqualTo("UnsupportedLocale"));
        }
    }
}
