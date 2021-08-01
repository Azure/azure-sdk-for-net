// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Translation.Document.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Samples
{
    [LiveOnly]
    public partial class DocumentTranslationSamples : SamplesBase<DocumentTranslationTestEnvironment>
    {
        [Test]
        public async Task MultipleInputsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:MultipleInputsAsync
#if SNIPPET
            Uri source1SasUri = new Uri("<source1 SAS URI>");
            Uri source2SasUri = new Uri("<source2 SAS URI>");
            Uri frenchTargetSasUri = new Uri("<french target SAS URI>");
            Uri arabicTargetSasUri = new Uri("<arabic target SAS URI>");
            Uri spanishTargetSasUri = new Uri("<spanish target SAS URI>");
            Uri frenchGlossarySasUri = new Uri("<french glossary SAS URI>");
#else
            DocumentTranslationSampleHelper.TestEnvironment = TestEnvironment;
            Uri source1SasUri = await DocumentTranslationSampleHelper.CreateSourceContainerAsync(DocumentTranslationSampleHelper.oneTestDocuments);
            Uri source2SasUri = await DocumentTranslationSampleHelper.CreateSourceContainerAsync(new List<TestDocument> { new TestDocument("Document2.txt", "Second english test document") });
            Uri frenchTargetSasUri = await DocumentTranslationSampleHelper.CreateTargetContainerAsync();
            Uri arabicTargetSasUri = await DocumentTranslationSampleHelper.CreateTargetContainerAsync();
            Uri spanishTargetSasUri = await DocumentTranslationSampleHelper.CreateTargetContainerAsync();
            var glossaryName = "glossary.tsv";
            var glossaries = new List<TestDocument> { new TestDocument(glossaryName, "test\tglossarytest") };
            Uri frenchGlossaryContainerSasUri = await DocumentTranslationSampleHelper.CreateGlossaryContainerAsync(glossaries);
            Uri frenchGlossarySasUri = new Uri(String.Format("{0}{1}{2}{3}/{4}{5}", frenchGlossaryContainerSasUri.Scheme, Uri.SchemeDelimiter, frenchGlossaryContainerSasUri.Authority, frenchGlossaryContainerSasUri.AbsolutePath, glossaryName, frenchGlossaryContainerSasUri.Query));
#endif

            var glossaryFormat = "TSV";

            var input1 = new DocumentTranslationInput(source1SasUri, frenchTargetSasUri, "fr", new TranslationGlossary(frenchGlossarySasUri, glossaryFormat));
            input1.AddTarget(spanishTargetSasUri, "es");

            var input2 = new DocumentTranslationInput(source2SasUri, arabicTargetSasUri, "ar");
            input2.AddTarget(frenchTargetSasUri, "fr", new TranslationGlossary(frenchGlossarySasUri, glossaryFormat));

            var inputs = new List<DocumentTranslationInput>()
                {
                    input1,
                    input2
                };

            DocumentTranslationOperation operation = await client.StartTranslationAsync(inputs);

            await operation.WaitForCompletionAsync();

            await foreach (DocumentStatus document in operation.GetValuesAsync())
            {
                Console.WriteLine($"Document with Id: {document.Id}");
                Console.WriteLine($"  Status:{document.Status}");
                if (document.Status == DocumentTranslationStatus.Succeeded)
                {
                    Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
                    Console.WriteLine($"  Translated to language: {document.TranslatedTo}.");
                    Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
                }
                else
                {
                    Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
                    Console.WriteLine($"  Error Code: {document.Error.ErrorCode}");
                    Console.WriteLine($"  Message: {document.Error.Message}");
                }
            }

            #endregion
        }
    }
}
