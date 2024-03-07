// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Health.Insights.RadiologyInsights.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Health.Insights.RadiologyInsights.Tests
{
    internal class Sample01_CriticalResultSampleAsync : SamplesBase<HealthInsightsTestEnvironment>
    {
        private const string DOC_CONTENT = "CLINICAL HISTORY:   "
            + "\r\n20-year-old female presenting with abdominal pain. Surgical history significant for appendectomy."
            + "\r\n "
            + "\r\nCOMPARISON:   "
            + "\r\nRight upper quadrant sonographic performed 1 day prior."
            + "\r\n "
            + "\r\nTECHNIQUE:   "
            + "\r\nTransabdominal grayscale pelvic sonography with duplex color Doppler "
            + "\r\nand spectral waveform analysis of the ovaries."
            + "\r\n "
            + "\r\nFINDINGS:   "
            + "\r\nThe uterus is unremarkable given the transabdominal technique with "
            + "\r\nendometrial echo complex within physiologic normal limits. The "
            + "\r\novaries are symmetric in size, measuring 2.5 x 1.2 x 3.0 cm and the "
            + "\r\nleft measuring 2.8 x 1.5 x 1.9 cm.\n \r\nOn duplex imaging, Doppler signal is symmetric."
            + "\r\n "
            + "\r\nIMPRESSION:   "
            + "\r\n1. Normal pelvic sonography. Findings of testicular torsion."
            + "\r\n\nA new US pelvis within the next 6 months is recommended."
            + "\n\nThese results have been discussed with Dr. Jones at 3 PM on November 5 2020.\n "
            + "\r\n";

        [Test]
        public async Task RadiologyInsightsCriticalResultScenario()
        {
            // Read endpoint and apiKey
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            Uri endpointUri = new Uri(endpoint);
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);
            RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, credential);

            RadiologyInsightsData radiologyInsightsData = GetRadiologyInsightsData();

            Operation<RadiologyInsightsInferenceResult> operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, radiologyInsightsData);

            RadiologyInsightsInferenceResult responseData = operation.Value;
            IReadOnlyList<RadiologyInsightsInference> inferences = responseData.PatientResults[0].Inferences;

            foreach (RadiologyInsightsInference inference in inferences)
            {
                if (inference is CriticalResultInference criticalResultInference)
                {
                    Console.Write("Critical Result Inference found: " + criticalResultInference.Result.Description);
                }
            }
        }

        private static RadiologyInsightsData GetRadiologyInsightsData()
        {
            PatientRecord patientRecord = CreatePatientRecord();
            List<PatientRecord> patientRecords = new() { patientRecord };
            RadiologyInsightsData radiologyInsightsData = new(patientRecords);
            radiologyInsightsData.Configuration = CreateConfiguration();
            return radiologyInsightsData;
        }

        private static RadiologyInsightsModelConfiguration CreateConfiguration()
        {
            RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = GetRadiologyInsightsInferenceOptions();

            RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
            {
                Locale = "en-US",
                IncludeEvidence = true,
                InferenceOptions = radiologyInsightsInferenceOptions
            };
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

            return radiologyInsightsModelConfiguration;
        }

        private static RadiologyInsightsInferenceOptions GetRadiologyInsightsInferenceOptions()
        {
            RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = new();
            FollowupRecommendationOptions followupRecommendationOptions = new();
            FindingOptions findingOptions = new();
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
            PatientDetails patientInfo = new()
            {
                BirthDate = new System.DateTime(1959, 11, 11),
                Sex = PatientSex.Female,
            };
            Encounter encounter = new("encounterid1")
            {
                Class = EncounterClass.InPatient,
                Period = new TimePeriod
                {
                    Start = new System.DateTime(2021, 08, 28),
                    End = new System.DateTime(2021, 08, 28)
                }
            };
            DocumentContent documentContent = new(DocumentContentSourceType.Inline, DOC_CONTENT);
            PatientDocument patientDocument = new(DocumentType.Note, "doc2", documentContent)
            {
                ClinicalType = ClinicalDocumentType.RadiologyReport,
                CreatedDateTime = new System.DateTime(2021, 08, 28),
                AdministrativeMetadata = CreateDocumentAdministrativeMetadata()
            };
            PatientRecord patientRecord = new(id);
            patientRecord.Info = patientInfo;
            patientRecord.Encounters.Add(encounter);
            patientRecord.PatientDocuments.Add(patientDocument);
            return patientRecord;
        }

        private static DocumentAdministrativeMetadata CreateDocumentAdministrativeMetadata()
        {
            DocumentAdministrativeMetadata documentAdministrativeMetadata = new DocumentAdministrativeMetadata();

            FhirR4Coding coding = new()
            {
                Display = "US PELVIS COMPLETE",
                Code = "USPELVIS",
                System = "Http://hl7.org/fhir/ValueSet/cpt-all"
            };

            FhirR4CodeableConcept codeableConcept = new();
            codeableConcept.Coding.Add(coding);

            FhirR4Extendible orderedProcedure = new()
            {
                Description = "US PELVIS COMPLETE",
                Code = codeableConcept
            };

            documentAdministrativeMetadata.OrderedProcedures.Add(orderedProcedure);

            return documentAdministrativeMetadata;
        }
    }
}
