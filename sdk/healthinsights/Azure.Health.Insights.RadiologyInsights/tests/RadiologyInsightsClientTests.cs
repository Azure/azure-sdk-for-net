// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Health.Insights.RadiologyInsights.Tests.Infrastructure;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Health.Insights.RadiologyInsights.Tests
{
    internal class RadiologyInsightsClientTests : SamplesBase<HealthInsightsTestEnvironment>
    {
        [Test]
        public void RadiologyInsightsHeroScenario()
        {
            // Read endpoint and apiKey
            string endpoint = TestEnvironment.Endpoint;

            Uri endpointUri = new Uri(endpoint);
            TokenCredential cred = new DefaultAzureCredential();
            RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);

            PatientRecord patientRecord = RadiologyInsightsClientTests.CreatePatientRecord();
            patientRecord.PatientDocuments[0].AdministrativeMetadata = CreateDocumentAdministrativeMetadata();
            List<PatientRecord> patientRecords = new List<PatientRecord> { patientRecord };
            RadiologyInsightsData radiologyInsightsData = new RadiologyInsightsData(patientRecords);
            RadiologyInsightsJob radiologyInsightsJob = new RadiologyInsightsJob();
            radiologyInsightsJob.JobData = radiologyInsightsData;
            radiologyInsightsData.Configuration = CreateConfiguration();
            var jobId = "job1714464011094";
            Operation<RadiologyInsightsInferenceResult> operation = client.InferRadiologyInsights(WaitUntil.Completed, jobId, radiologyInsightsJob);
            RadiologyInsightsInferenceResult responseData = operation.Value;
            var inferences = responseData.PatientResults.First().Inferences;

            foreach (var inference in inferences)
            {
                if (inference is CriticalResultInference)
                {
                    CriticalResultInference criticalResultInference = (CriticalResultInference)inference;
                    Console.Write("Critical Result Inference found: " + criticalResultInference.Result.Description);
                }
            }
        }

        private RadiologyInsightsModelConfiguration CreateConfiguration()
        {
            RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = GetRadiologyInsightsInferenceOptions();

            RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new RadiologyInsightsModelConfiguration();
            radiologyInsightsModelConfiguration.Locale = "en-US";
            radiologyInsightsModelConfiguration.IncludeEvidence = true;
            radiologyInsightsModelConfiguration.InferenceOptions = radiologyInsightsInferenceOptions;
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.Finding);
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.AgeMismatch);
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.LateralityDiscrepancy);
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.SexMismatch);
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.CompleteOrderDiscrepancy);
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.LimitedOrderDiscrepancy);
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.CriticalResult);
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.FollowupCommunication);
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.FollowupRecommendation);
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.RadiologyProcedure);
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.QualityMeasure);
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.ScoringAndAssessment);

            return radiologyInsightsModelConfiguration;
        }

        private RadiologyInsightsInferenceOptions GetRadiologyInsightsInferenceOptions()
        {
            RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = new RadiologyInsightsInferenceOptions();
            FollowupRecommendationOptions followupRecommendationOptions = new FollowupRecommendationOptions();
            FindingOptions findingOptions = new FindingOptions();
            followupRecommendationOptions.IncludeRecommendationsWithNoSpecifiedModality = true;
            followupRecommendationOptions.IncludeRecommendationsInReferences = true;
            followupRecommendationOptions.ProvideFocusedSentenceEvidence = true;
            findingOptions.ProvideFocusedSentenceEvidence = true;
            radiologyInsightsInferenceOptions.FollowupRecommendationOptions = followupRecommendationOptions;
            radiologyInsightsInferenceOptions.FindingOptions = findingOptions;
            return radiologyInsightsInferenceOptions;
        }
        private static PatientRecord CreatePatientRecord()
        {
            string id = "patient_id2";
            PatientDetails patientInfo = new PatientDetails
            {
                BirthDate = new System.DateTime(1959, 11, 11),
                Sex = PatientSex.Female,
            };
            PatientEncounter encounter = new PatientEncounter("encounterid1")
            {
                Class = EncounterClass.InPatient,
                Period = new TimePeriod
                {
                    Start = new System.DateTime(2021, 08, 28),
                    End = new System.DateTime(2021, 08, 28)
                }
            };
            ClinicalDocumentContent documentContent = new ClinicalDocumentContent(DocumentContentSourceType.Inline, "CLINICAL HISTORY:   \n        20-year-old female presenting with abdominal pain. Surgical history significant for appendectomy.\n        COMPARISON:   \n        Right upper quadrant sonographic performed 1 day prior.\n        TECHNIQUE:   \n        Transabdominal grayscale pelvic sonography with duplex color Doppler and spectral waveform analysis of the ovaries.\n        FINDINGS:   \n        The uterus is unremarkable given the transabdominal technique with endometrial echo complex within physiologic normal limits. The ovaries are symmetric in size, measuring 2.5 x 1.2 x 3.0 cm and the left measuring 2.8 x 1.5 x 1.9 cm.\n On duplex imaging, Doppler signal is symmetric.\n        IMPRESSION:   \n        1. Normal pelvic sonography. Findings of testicular torsion.\n        A new US pelvis within the next 6 months is recommended.\n        These results have been discussed with Dr. Jones at 3 PM on November 5 2020.");
            PatientDocument patientDocument = new PatientDocument(ClinicalDocumentContentType.Note, "doc2", documentContent)
            {
                ClinicalType = ClinicalDocumentType.RadiologyReport,
                CreatedAt = new System.DateTime(2021, 08, 28)
            };
            PatientRecord patientRecord = new PatientRecord(id);
            patientRecord.Details = patientInfo;
            patientRecord.Encounters.Add(encounter);
            patientRecord.PatientDocuments.Add(patientDocument);
            return patientRecord;
        }

        private DocumentAdministrativeMetadata CreateDocumentAdministrativeMetadata()
        {
            DocumentAdministrativeMetadata documentAdministrativeMetadata = new DocumentAdministrativeMetadata();

            FhirR4Coding coding = new FhirR4Coding()
            {
                Display = "US PELVIS COMPLETE",
                Code = "USPELVIS",
                System = "Http://hl7.org/fhir/ValueSet/cpt-all"
            };

            FhirR4CodeableConcept codeableConcept = new FhirR4CodeableConcept();
            codeableConcept.Coding.Add(coding);

            OrderedProcedure orderedProcedure = new OrderedProcedure()
            {
                Description = "US PELVIS COMPLETE",
                Code = codeableConcept
            };

            documentAdministrativeMetadata.OrderedProcedures.Add(orderedProcedure);

            return documentAdministrativeMetadata;
        }
    }
}
