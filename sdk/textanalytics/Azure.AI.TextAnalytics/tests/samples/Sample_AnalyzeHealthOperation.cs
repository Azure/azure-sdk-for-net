// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async System.Threading.Tasks.Task AnalyzeHealthAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:TextAnalyticsSample2CreateClient
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion

            #region Snippet:AnalyzeHealth

            IEnumerable<TextDocumentInput> documents = new List<TextDocumentInput>()
            {
                new TextDocumentInput("1", "RECORD #333582770390100 | MH | 85986313 | | 054351 | 2/14/2001 12:00:00 AM | CORONARY ARTERY DISEASE | Signed | DIS | Admission Date: 5/22/2001 Report Status: Signed Discharge Date: 4/24/2001 ADMISSION DIAGNOSIS: CORONARY ARTERY DISEASE. HISTORY OF PRESENT ILLNESS: The patient is a 54-year-old gentleman with a history of progressive angina over the past several months. The patient had a cardiac catheterization in July of this year revealing total occlusion of the RCA and 50% left main disease , with a strong family history of coronary artery disease with a brother dying at the age of 52 from a myocardial infarction and another brother who is status post coronary artery bypass grafting. The patient had a stress echocardiogram done on July , 2001 , which showed no wall motion abnormalities , but this was a difficult study due to body habitus. The patient went for six minutes with minimal ST depressions in the anterior lateral leads , thought due to fatigue and wrist pain , his anginal equivalent. Due to the patient's increased symptoms and family history and history left main disease with total occasional of his RCA was referred for revascularization with open heart surgery.")
            };

            AnalyzeHealthOperation operation = await client.StartAnalyzeHealthAsync(documents, new TextAnalyticsRequestOptions() { ModelVersion = "latest" });

            Response<AnalyzeHealthResultCollection> response = await operation.WaitForCompletionAsync();

            GetDiagnosis(response);
            GetRelations(response);

            GetReport(response);

            #endregion
        }

        private void GetReport(Response<AnalyzeHealthResultCollection> response)
        {
            IList<HealthcareResult> results = response.Value.Documents;
            Console.WriteLine("Health Report -");
            foreach (HealthcareResult result in results)
            {
                foreach (HealthcareEntity entity in result.Documents[0].Entities)
                {
                    Console.WriteLine($"Text {entity.Text}");
                    Console.WriteLine($"Category {entity.Category}");
                    Console.WriteLine($"ConfidenceScore {entity.ConfidenceScore}");
                    Console.WriteLine($"Offset {entity.Offset}");
                }

                foreach (HealthcareRelation relation in result.Documents[0].Relations)
                {
                    Console.WriteLine($"Relation Type {relation.RelationType} with bidirectional as {relation.Bidirectional}.");
                    Console.WriteLine($"Source Entity Text {relation.SourceEntity.Text}.");
                    Console.WriteLine($"Source Entity Category {relation.SourceEntity.Category}.");
                    Console.WriteLine($"Source Entity Length {relation.SourceEntity.Length}.");
                    Console.WriteLine($"Target Entity {relation.TargetEntity.Text}.");
                    Console.WriteLine($"Target Entity Category {relation.TargetEntity.Category}.");
                    Console.WriteLine($"Target Entity Length {relation.TargetEntity.Length}.");
                }
            }
        }

        private void GetDiagnosis(Response<AnalyzeHealthResultCollection> response)
        {
            IList<HealthcareResult> results = response.Value.Documents;
            Console.WriteLine("Diagnosis for the resport -");
            foreach (HealthcareResult result in results)
            {
                foreach (HealthcareEntity entities in result.Documents[0].Entities)
                {
                    if (entities.Category == "Diagnosis")
                    {
                        Console.WriteLine(entities.Text);
                    }
                }
            }
        }

        private void GetRelations(Response<AnalyzeHealthResultCollection> response)
        {
            IList<HealthcareResult> results = response.Value.Documents;

            foreach (HealthcareResult result in results)
            {
                foreach (HealthcareRelation relation in result.Documents[0].Relations)
                {
                    Console.WriteLine($"Relation Type {relation.RelationType} with bidirectional as {relation.Bidirectional}.");

                    Console.WriteLine($"Source Entity: {relation.SourceEntity.Text} is related to Target Entity: {relation.TargetEntity.Text}.");
                }
            }
        }
    }
}
