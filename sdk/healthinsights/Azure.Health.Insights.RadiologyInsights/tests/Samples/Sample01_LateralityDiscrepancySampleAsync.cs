// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Health.Insights.RadiologyInsights.Tests
{
    internal class Sample01_LateralityDiscrepancySampleAsync
    {
        private const string DOC_CONTENT = "Exam:   US LT BREAST TARGETED"
    		+ "\r\n\r\nTechnique:  Targeted imaging of the  right breast  is performed."
    		+ "\r\n\r\nFindings:\\r\\n\\r\\nTargeted imaging of the left breast is performed from the 6:00 to the 9:00 position.  "
    		+ "\r\n\r\nAt the 6:00 position, 5 cm from the nipple, there is a 3 x 2 x 4 mm minimally hypoechoic mass with a peripheral calcification. This may correspond to the mammographic finding. No other cystic or solid masses visualized."
    		+ "\r\n";

        [Test]
        public async Task RadiologyInsightsLateralityDiscrepancyScenario()
        {
            Uri endpoint = new Uri("AZURE_HEALTH_INSIGHTS_ENDPOINT");
            AzureKeyCredential credential = new AzureKeyCredential("AZURE_HEALTH_INSIGHTS_KEY");
            RadiologyInsightsClient client = new RadiologyInsightsClient(endpoint, credential);

            RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
            Guid jobId = Guid.NewGuid();

            Operation<RadiologyInsightsInferenceResult> operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, jobId.ToString(), radiologyInsightsjob);
            RadiologyInsightsInferenceResult responseData = operation.Value;
            IList<RadiologyInsightsInference> inferences = responseData.PatientResults[0].Inferences;

            foreach (RadiologyInsightsInference inference in inferences)
            {
                if (inference is LateralityDiscrepancyInference lateralityDiscrepancyInference)
                {
                    FhirR4CodeableConcept lateralityIndication = lateralityDiscrepancyInference.LateralityIndication;
                    IList<FhirR4Coding> codingList = lateralityIndication.Coding;
                    Console.Write("Laterality Discrepancy Inference found: ");
                    var discrepancyType = lateralityDiscrepancyInference.DiscrepancyType;
                    foreach (FhirR4Coding fhirR4Coding in codingList)
                    {
                        Console.Write("   FhirR4Coding: " + fhirR4Coding.Code + ", " + fhirR4Coding.Display + " (" + fhirR4Coding.System + "), type: " + discrepancyType);
                    }
                }
            }
        }

        private static RadiologyInsightsJob GetRadiologyInsightsJob()
        {
            PatientRecord patientRecord = CreatePatientRecord();
            RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = CreateConfiguration();
            List<PatientRecord> patientRecords = new() { patientRecord };
            RadiologyInsightsData radiologyInsightsData = new RadiologyInsightsData(patientRecords, radiologyInsightsModelConfiguration, null);
            return new RadiologyInsightsJob() { JobData = radiologyInsightsData };
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
            PatientDetails patientDetails = new()
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
            DocumentContent documentContent = new(DocumentContentSourceType.Inline, DOC_CONTENT);
            PatientDocument patientDocument = new(DocumentType.Note, "doc2", documentContent)
            {
                ClinicalType = ClinicalDocumentType.RadiologyReport,
                CreatedAt = new System.DateTime(2021, 08, 28),
                AdministrativeMetadata = CreateDocumentAdministrativeMetadata()
            };
            List<PatientDocument> patientDocuments = new() { patientDocument };
            PatientRecord patientRecord = new PatientRecord(id, patientDetails, encounterList, patientDocuments, null);
            return patientRecord;
        }

        private static DocumentAdministrativeMetadata CreateDocumentAdministrativeMetadata()
        {
            DocumentAdministrativeMetadata documentAdministrativeMetadata = new DocumentAdministrativeMetadata();

            FhirR4Coding coding = new()
            {
                Display = "US BREAST - LEFT LIMITED",
                Code = "26688-1",
                System = "Http://hl7.org/fhir/ValueSet/cpt-all"
            };

            FhirR4CodeableConcept codeableConcept = new();
            codeableConcept.Coding.Add(coding);

            OrderedProcedure orderedProcedure = new OrderedProcedure()
            {
                Description = "US BREAST - LEFT LIMITED",
                Code = codeableConcept
            };

            documentAdministrativeMetadata.OrderedProcedures.Add(orderedProcedure);

            return documentAdministrativeMetadata;
        }
    }
}
