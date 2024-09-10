// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Health.Insights.RadiologyInsights.Tests.Infrastructure;
using NUnit.Framework;
using Azure.Identity;

namespace Azure.Health.Insights.RadiologyInsights.Tests
{
    internal class Sample01_LateralityDiscrepancySampleAsync : SamplesBase<HealthInsightsTestEnvironment>
    {
        #region Snippet:Laterality_Discrepancy_Async_Tests_Samples_Doc_Content
        private const string DOC_CONTENT = "Exam:   US LT BREAST TARGETED"
            + "\r\n\r\nTechnique:  Targeted imaging of the  right breast  is performed."
            + "\r\n\r\nFindings:\\r\\n\\r\\nTargeted imaging of the left breast is performed from the 6:00 to the 9:00 position.  "
            + "\r\n\r\nAt the 6:00 position, 5 cm from the nipple, there is a 3 x 2 x 4 mm minimally hypoechoic mass with a peripheral calcification. This may correspond to the mammographic finding. No other cystic or solid masses visualized."
            + "\r\n";
        #endregion

        [Test]
        public async Task RadiologyInsightsLateralityDiscrepancyScenario()
        {
            // Read endpoint
            string endpoint = TestEnvironment.Endpoint;

            #region Snippet:Laterality_Discrepancy_Async_Tests_Samples_CreateClient
            Uri endpointUri = new Uri(endpoint);
            TokenCredential cred = new DefaultAzureCredential();
            RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);
            #endregion
            #region Snippet:Laterality_Discrepancy_Async_Tests_Samples_synccall
            RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
            var jobId = "job" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Operation<RadiologyInsightsInferenceResult> operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, jobId, radiologyInsightsjob);
            #endregion

            RadiologyInsightsInferenceResult responseData = operation.Value;
            IReadOnlyList<RadiologyInsightsInference> inferences = responseData.PatientResults[0].Inferences;

            foreach (RadiologyInsightsInference inference in inferences)
            {
                if (inference is LateralityDiscrepancyInference lateralityDiscrepancyInference)
                {
                    #region Snippet:Laterality_Discrepancy_Async_Tests_Samples_LateralityDiscrepancyInference
                    FhirR4CodeableConcept lateralityIndication = lateralityDiscrepancyInference.LateralityIndication;
                    IList<FhirR4Coding> codingList = lateralityIndication.Coding;
                    Console.WriteLine("Laterality Discrepancy Inference found: ");
                    var discrepancyType = lateralityDiscrepancyInference.DiscrepancyType;
                    foreach (FhirR4Coding fhirR4Coding in codingList)
                    {
                        Console.WriteLine("   Coding: " + fhirR4Coding.Code + ", " + fhirR4Coding.Display + " (" + fhirR4Coding.System + "), type: " + discrepancyType);
                    }
                    #endregion
                }
            }
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
            #region Snippet:Laterality_Discrepancy_Async_Tests_Samples_AddRecordAndConfiguration
            List<PatientRecord> patientRecords = new() { patientRecord };
            RadiologyInsightsData radiologyInsightsData = new(patientRecords);
            radiologyInsightsData.Configuration = CreateConfiguration();
            #endregion
            return radiologyInsightsData;
        }

        private static RadiologyInsightsModelConfiguration CreateConfiguration()
        {
            RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = GetRadiologyInsightsInferenceOptions();

            #region Snippet:Laterality_Discrepancy_Async_Tests_Samples_CreateModelConfiguration
            RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
            {
                Locale = "en-US",
                IncludeEvidence = true,
                InferenceOptions = radiologyInsightsInferenceOptions
            };
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.LateralityDiscrepancy);
            #endregion
            return radiologyInsightsModelConfiguration;
        }

        private static RadiologyInsightsInferenceOptions GetRadiologyInsightsInferenceOptions()
        {
            #region Snippet:Laterality_Discrepancy_Async_Tests_Samples_CreateRadiologyInsightsInferenceOptions
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
            #region Snippet:Laterality_Discrepancy_Async_Tests_Samples_CreatePatientRecord
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
            #region Snippet:Laterality_Discrepancy_Async_Tests_Samples_CreateDocumentAdministrativeMetadata
            DocumentAdministrativeMetadata documentAdministrativeMetadata = new DocumentAdministrativeMetadata();

            FhirR4Coding coding = new()
            {
                Display = "US BREAST - LEFT LIMITED",
                Code = "26688-1",
                System = "Http://hl7.org/fhir/ValueSet/cpt-all"
            };

            FhirR4CodeableConcept codeableConcept = new();
            codeableConcept.Coding.Add(coding);

            OrderedProcedure orderedProcedure = new()
            {
                Description = "US BREAST - LEFT LIMITED",
                Code = codeableConcept
            };

            documentAdministrativeMetadata.OrderedProcedures.Add(orderedProcedure);
            #endregion
            return documentAdministrativeMetadata;
        }
    }
}
