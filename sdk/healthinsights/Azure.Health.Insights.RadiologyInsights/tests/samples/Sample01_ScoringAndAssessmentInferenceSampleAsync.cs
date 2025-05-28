// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Health.Insights.RadiologyInsights.Tests.Infrastructure;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.Health.Insights.RadiologyInsights.Tests
{
    internal class Sample01_ScoringAndAssessmentInferenceSampleAsync : SamplesBase<HealthInsightsTestEnvironment>
    {
        #region Snippet:Scoring_And_Assessment_Async_Tests_Samples_Doc_Content
        private const string DOC_CONTENT = "Exam: US THYROID\r\n\r\nClinical History: Thyroid nodules. 76 year old patient." +
            "\r\n\r\nComparison: none." +
            "\r\n\r\nFindings:" +
            "\r\nRight lobe: 4.8 x 1.6 x 1.4 cm" +
            "\r\nLeft Lobe: 4.1 x 1.3 x 1.3 cm" +
            "\r\n\r\nIsthmus: 4 mm" +
            "\r\n\r\nThere are multiple cystic and partly cystic sub-5 mm nodules noted within the right lobe (TIRADS 2)." +
            "\r\nIn the lower pole of the left lobe there is a 9 x 8 x 6 mm predominantly solid isoechoic nodule (TIRADS 3)." +
            "\r\n\r\nImpression:" +
            "\r\nMultiple bilateral small cystic benign thyroid nodules. A low suspicion 9 mm left lobe thyroid nodule (TI-RADS 3) which, given its small size, does not warrant follow-up.";
        #endregion

        [Test]
        public async Task RadiologyInsightsScoringAndAssessmentScenario()
        {
            // Read endpoint
            string endpoint = TestEnvironment.Endpoint;
            #region Snippet:Scoring_And_Assessment_Async_Tests_Samples_TokenCredential
            Uri endpointUri = new Uri(endpoint);
            TokenCredential cred = new DefaultAzureCredential();
            RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);
            #endregion
            #region Snippet:Scoring_And_Assessment_Async_Tests_Samples_Asynccall
            RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
            var jobId = "job" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Operation<RadiologyInsightsInferenceResult> operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, jobId, radiologyInsightsjob);
            #endregion
            #region Snippet:Scoring_And_Assessment_Async_Tests_Samples_ScoringAndAssessment
            RadiologyInsightsInferenceResult responseData = operation.Value;
            IReadOnlyList<RadiologyInsightsInference> inferences = responseData.PatientResults[0].Inferences;

            foreach (RadiologyInsightsInference inference in inferences)
            {
                if (inference is ScoringAndAssessmentInference scoringAndAssessmentInference)
                {
                    Console.WriteLine("Scoring and Assessment Inference found:");
                    Console.WriteLine($"   Category: {scoringAndAssessmentInference.Category}");
                    Console.WriteLine($"   Category Description: {scoringAndAssessmentInference.CategoryDescription}");
                    Console.WriteLine($"   Single Value: {scoringAndAssessmentInference.SingleValue}");

                    if (scoringAndAssessmentInference.RangeValue != null)
                    {
                        Console.WriteLine("   Range Value: ");
                        DisplayValueRange(scoringAndAssessmentInference.RangeValue);
                    }
                }
            }
            #endregion
        }

        private static void DisplayValueRange(AssessmentValueRange range)
        {
            #region Snippet:Scoring_And_Assessment_Async_Tests_Samples_DisplayValueRange
            if (range.Minimum != null)
            {
                Console.WriteLine($"     Min: {range.Minimum}");
            }
            if (range.Maximum != null)
            {
                Console.WriteLine($"     Max: {range.Maximum}");
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
            #region Snippet:Scoring_And_Assessment_Async_Tests_Samples_AddRecordAndConfiguration
            List<PatientRecord> patientRecords = new() { patientRecord };
            RadiologyInsightsData radiologyInsightsData = new(patientRecords);
            radiologyInsightsData.Configuration = CreateConfiguration();
            #endregion
            return radiologyInsightsData;
        }

        private static RadiologyInsightsModelConfiguration CreateConfiguration()
        {
            RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = GetRadiologyInsightsInferenceOptions();
            #region Snippet:Scoring_And_Assessment_Async_Tests_Samples_CreateModelConfiguration
            RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
            {
                Locale = "en-US",
                IncludeEvidence = true,
                InferenceOptions = radiologyInsightsInferenceOptions
            };
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.ScoringAndAssessment);
            #endregion
            return radiologyInsightsModelConfiguration;
        }

        private static RadiologyInsightsInferenceOptions GetRadiologyInsightsInferenceOptions()
        {
            #region Snippet:Scoring_And_Assessment_Async_Tests_Samples_CreateRadiologyInsightsInferenceOptions
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
            #region Snippet:Scoring_And_Assessment_Async_Tests_Samples_CreatePatientRecord
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
            #region Snippet:Scoring_And_Assessment_Async_Tests_Samples_CreateDocumentAdministrativeMetadata
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
