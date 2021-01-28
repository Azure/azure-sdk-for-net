// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Models;
using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples: SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public async Task Healthcare()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:RecognizeHealthcareEntities
            string document = @"RECORD #333582770390100 | MH | 85986313 | | 054351 | 2/14/2001 12:00:00 AM | CORONARY ARTERY DISEASE | Signed | DIS | \
                                Admission Date: 5/22/2001 Report Status: Signed Discharge Date: 4/24/2001 ADMISSION DIAGNOSIS: CORONARY ARTERY DISEASE. \
                                HISTORY OF PRESENT ILLNESS: The patient is a 54-year-old gentleman with a history of progressive angina over the past several months. \
                                The patient had a cardiac catheterization in July of this year revealing total occlusion of the RCA and 50% left main disease ,\
                                with a strong family history of coronary artery disease with a brother dying at the age of 52 from a myocardial infarction and \
                                another brother who is status post coronary artery bypass grafting. The patient had a stress echocardiogram done on July , 2001 , \
                                which showed no wall motion abnormalities , but this was a difficult study due to body habitus. The patient went for six minutes with \
                                minimal ST depressions in the anterior lateral leads , thought due to fatigue and wrist pain , his anginal equivalent. Due to the patient's \
                                increased symptoms and family history and history left main disease with total occasional of his RCA was referred for revascularization with open heart surgery.";

            HealthcareOperation healthOperation = client.StartHealthcare(document);

            await healthOperation.WaitForCompletionAsync();

            RecognizeHealthcareEntitiesResultCollection results = healthOperation.Value;

            Console.WriteLine($"Results of Azure Text Analytics \"Healthcare\" Model, version: \"{results.ModelVersion}\"");
            Console.WriteLine("");

            foreach (DocumentHealthcareResult result in results)
            {
                   Console.WriteLine($"    Recognized the following {result.Entities.Count} healthcare entities:");

                    foreach (HealthcareEntity entity in result.Entities)
                    {
                        Console.WriteLine($"    Entity: {entity.Text}");
                        Console.WriteLine($"    Category: {entity.Category}");
                        Console.WriteLine($"    Offset: {entity.Offset}");
                        Console.WriteLine($"    Length: {entity.Length}");
                        Console.WriteLine($"    IsNegated: {entity.IsNegated}");
                        Console.WriteLine($"    Links:");

                        foreach (HealthcareEntityLink healthcareEntityLink in entity.Links)
                        {
                            Console.WriteLine($"        ID: {healthcareEntityLink.Id}");
                            Console.WriteLine($"        DataSource: {healthcareEntityLink.DataSource}");
                        }
                    }
                    Console.WriteLine("");
            }
        }

        #endregion
    }
}
