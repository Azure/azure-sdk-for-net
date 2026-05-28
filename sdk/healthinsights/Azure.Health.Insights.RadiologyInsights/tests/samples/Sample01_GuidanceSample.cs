// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Health.Insights.RadiologyInsights.Tests.Infrastructure;
using NUnit.Framework;
using Azure.Identity;
using System.Net;

namespace Azure.Health.Insights.RadiologyInsights.Tests
{
    internal class Sample01_GuidanceSample : SamplesBase<HealthInsightsTestEnvironment>
    {
        #region Snippet:Guidance_Sync_Tests_Samples_Doc_Content
        private const string DOC_CONTENT = "History:" +
            "\r\n    Left renal tumor with thin septations." +
            "\r\n    Findings:" +
            "\r\n    There is a right kidney tumor with nodular calcification.";
        #endregion

        [Test]
        public void RadiologyInsightsGuidanceScenario()
        {
            // Read endpoint
            string endpoint = TestEnvironment.Endpoint;
            #region Snippet:Guidance_Sync_Tests_Samples_TokenCredential
            Uri endpointUri = new Uri(endpoint);
            TokenCredential cred = new DefaultAzureCredential();
            RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);
            #endregion
            #region Snippet:Guidance_Sync_Tests_Samples_synccall
            RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
            var jobId = "job" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Operation<RadiologyInsightsInferenceResult> operation = client.InferRadiologyInsights(WaitUntil.Completed, jobId, radiologyInsightsjob);
            #endregion
            #region Snippet:Guidance_Sync_Tests_Samples_GuidanceInference
            RadiologyInsightsInferenceResult responseData = operation.Value;
            IReadOnlyList<RadiologyInsightsInference> inferences = responseData.PatientResults[0].Inferences;

            foreach (RadiologyInsightsInference inference in inferences)
            {
                if (inference is GuidanceInference guidanceInference)
                {
                    Console.WriteLine("Guidance Inference found: ");

                    FindingInference findingInference = guidanceInference.Finding;
                    FhirR4Observation finding = findingInference.Finding;
                    if (finding.Code != null)
                    {
                        Console.WriteLine("   Finding Code: ");
                        DisplayCodes(finding.Code, 2);
                    }

                    Console.WriteLine("   Identifier: ");
                    DisplayCodes(guidanceInference.Identifier, 2);

                    foreach (var presentInfo in guidanceInference.PresentGuidanceInformation)
                    {
                        Console.WriteLine("   Present Guidance Information: ");
                        DisplayPresentGuidanceInformation(presentInfo);
                    }

                    Console.WriteLine($"   Ranking: {guidanceInference.Ranking}");
                    IReadOnlyList<FollowupRecommendationInference> recommendationProposals = guidanceInference.RecommendationProposals;
                    foreach (FollowupRecommendationInference recommendationProposal in recommendationProposals)
                    {
                        Console.WriteLine($"   Recommendation Proposal: {recommendationProposal.RecommendedProcedure.Kind}");
                    }

                    foreach (var missingInfo in guidanceInference.MissingGuidanceInformation)
                    {
                        Console.WriteLine($"   Missing Guidance Information: {missingInfo}");
                    }
                }
            }
            #endregion
        }

        private static void DisplayCodes(FhirR4CodeableConcept codeableConcept, int indentation)
        {
            string initialBlank = "";
            for (int i = 0; i < indentation; i++)
            {
                initialBlank += "   ";
            }
            if (codeableConcept != null)
            {
                #region Snippet:Guidance_Sync_Sync_Tests_Samples_DisplayCodes
                IList<FhirR4Coding> codingList = codeableConcept.Coding;
                if (codingList != null)
                {
                    foreach (FhirR4Coding fhirR4Coding in codingList)
                    {
                        Console.WriteLine(initialBlank + "Coding: " + fhirR4Coding.Code + ", " + fhirR4Coding.Display + " (" + fhirR4Coding.System + ")");
                    }
                }
                #endregion
            }
        }

        private static void DisplayPresentGuidanceInformation(PresentGuidanceInformation guidanceInfo)
        {
            Console.WriteLine($"     Present Guidance Information Item: {guidanceInfo.PresentGuidanceItem}");
            #region Snippet:Guidance_Sync_Tests_Samples_DisplayPresentGuidanceInformation
            if (guidanceInfo.PresentGuidanceValues != null)
            {
                foreach (var value in guidanceInfo.PresentGuidanceValues)
                {
                    Console.WriteLine($"     Present Guidance Value: {value}");
                }
            }

            if (guidanceInfo.Sizes != null)
            {
                foreach (var size in guidanceInfo.Sizes)
                {
                    if (size.ValueQuantity != null)
                    {
                        Console.WriteLine("     Size ValueQuantity: ");
                        DisplayQuantityOutput(size.ValueQuantity);
                    }
                    if (size.ValueRange != null)
                    {
                        if (size.ValueRange.Low != null)
                        {
                            Console.WriteLine($"     Size ValueRange: min {size.ValueRange.Low}");
                        }
                        if (size.ValueRange.High != null)
                        {
                            Console.WriteLine($"     Size ValueRange: max {size.ValueRange.High}");
                        }
                    }
                }
            }

            if (guidanceInfo.MaximumDiameterAsInText != null)
            {
                Console.WriteLine("     Maximum Diameter As In Text: ");
                DisplayQuantityOutput(guidanceInfo.MaximumDiameterAsInText);
            }

            if (guidanceInfo.Extension != null)
            {
                Console.WriteLine("     Extension: ");
                DisplaySectionInfo(guidanceInfo);
            }
            #endregion
        }

        private static void DisplayQuantityOutput(FhirR4Quantity quantity)
        {
            #region Snippet:Guidance_Sync_Tests_Samples_DisplayQuantityOutput
            if (quantity.Value != null)
            {
                Console.WriteLine($"     Value: {quantity.Value}");
            }
            if (quantity.Unit != null)
            {
                Console.WriteLine($"     Unit: {quantity.Unit}");
            }
            #endregion
        }

        private static void DisplaySectionInfo(PresentGuidanceInformation guidanceInfo)
        {
            #region Snippet:Guidance_Sync_Tests_Samples_DisplaySectionInfo
            if (guidanceInfo.Extension != null)
            {
                foreach (var ext in guidanceInfo.Extension)
                {
                    if (ext.Url == "section")
                    {
                        Console.WriteLine("   Section:");
                        if (ext.Extension != null)
                        {
                            foreach (var subextension in ext.Extension)
                            {
                                if (subextension.Url != null && subextension.ValueString != null)
                                {
                                    Console.WriteLine($"      {subextension.Url}: {subextension.ValueString}");
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }

        private static RadiologyInsightsJob GetRadiologyInsightsJob()
        {
            RadiologyInsightsJob radiologyInsightsJob = new RadiologyInsightsJob();
            radiologyInsightsJob.JobData = GetRadiologyInsightsData();
            return radiologyInsightsJob;
        }

        private static RadiologyInsightsData GetRadiologyInsightsData()
        {
            PatientRecord patientRecord = CreatePatientRecord();
            #region Snippet:Guidance_Sync_Tests_Samples_AddRecordAndConfiguration
            List<PatientRecord> patientRecords = new() { patientRecord };
            RadiologyInsightsData radiologyInsightsData = new(patientRecords);
            radiologyInsightsData.Configuration = CreateConfiguration();
            #endregion
            return radiologyInsightsData;
        }

        private static RadiologyInsightsModelConfiguration CreateConfiguration()
        {
            RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = GetRadiologyInsightsInferenceOptions();
            #region Snippet:Guidance_Sync_Tests_Samples_CreateModelConfiguration
            RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
            {
                Locale = "en-US",
                IncludeEvidence = true,
                InferenceOptions = radiologyInsightsInferenceOptions
            };
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.Guidance);
            #endregion
            return radiologyInsightsModelConfiguration;
        }

        private static RadiologyInsightsInferenceOptions GetRadiologyInsightsInferenceOptions()
        {
            #region Snippet:Guidance_Sync_Tests_Samples_CreateRadiologyInsightsInferenceOptions
            RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = new();
            FollowupRecommendationOptions followupRecommendationOptions = new();
            FindingOptions findingOptions = new();
            followupRecommendationOptions.IncludeRecommendationsWithNoSpecifiedModality = true;
            followupRecommendationOptions.IncludeRecommendationsInReferences = true;
            followupRecommendationOptions.ProvideFocusedSentenceEvidence = true;
            findingOptions.ProvideFocusedSentenceEvidence = true;
            radiologyInsightsInferenceOptions.FollowupRecommendationOptions = followupRecommendationOptions;
            radiologyInsightsInferenceOptions.FindingOptions = findingOptions;
            #endregion
            return radiologyInsightsInferenceOptions;
        }

        private static PatientRecord CreatePatientRecord()
        {
            #region Snippet:Guidance_Sync_Tests_Samples_CreatePatientRecord
            string id = "patient_id2";
            PatientDetails patientInfo = new()
            {
                BirthDate = new System.DateTime(1959, 11, 11),
                Sex = PatientSex.Female,
            };
            PatientEncounter encounter = new("encounterid1")
            {
                Class = EncounterClass.InPatient,
                Period = new TimePeriod
                {
                    Start = new System.DateTime(2021, 08, 28),
                    End = new System.DateTime(2021, 08, 28)
                }
            };
            List<PatientEncounter> encounterList = new() { encounter };
            ClinicalDocumentContent documentContent = new(DocumentContentSourceType.Inline, DOC_CONTENT);
            PatientDocument patientDocument = new(ClinicalDocumentContentType.Note, "doc2", documentContent)
            {
                ClinicalType = ClinicalDocumentType.RadiologyReport,
                CreatedAt = new System.DateTime(2021, 08, 28),
                AdministrativeMetadata = CreateDocumentAdministrativeMetadata()
            };
            PatientRecord patientRecord = new(id);
            patientRecord.Details = patientInfo;
            patientRecord.Encounters.Add(encounter);
            patientRecord.PatientDocuments.Add(patientDocument);
            #endregion
            return patientRecord;
        }

        private static DocumentAdministrativeMetadata CreateDocumentAdministrativeMetadata()
        {
            #region Snippet:Guidance_Sync_Tests_Samples_CreateDocumentAdministrativeMetadata
            DocumentAdministrativeMetadata documentAdministrativeMetadata = new DocumentAdministrativeMetadata();

            FhirR4Coding coding = new()
            {
                Display = "US PELVIS COMPLETE",
                Code = "USPELVIS",
                System = "Http://hl7.org/fhir/ValueSet/cpt-all"
            };

            FhirR4CodeableConcept codeableConcept = new();
            codeableConcept.Coding.Add(coding);

            OrderedProcedure orderedProcedure = new()
            {
                Description = "US PELVIS COMPLETE",
                Code = codeableConcept
            };

            documentAdministrativeMetadata.OrderedProcedures.Add(orderedProcedure);
            #endregion
            return documentAdministrativeMetadata;
        }
    }
}
