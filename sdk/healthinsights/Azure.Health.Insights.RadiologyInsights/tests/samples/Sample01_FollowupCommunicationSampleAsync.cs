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
    internal class Sample01_FollowupCommunicationSampleAsync : SamplesBase<HealthInsightsTestEnvironment>
    {
        #region Snippet:Followup_Communication_Async_Tests_Samples_Doc_Content
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
        #endregion

        [Test]
        public async Task RadiologyInsightsFollowupRecommendationScenario()
        {
            // Read endpoint
            string endpoint = TestEnvironment.Endpoint;

            #region Snippet:Followup_Communication_Async_Tests_Samples_CreateClient
            Uri endpointUri = new Uri(endpoint);
            TokenCredential cred = new DefaultAzureCredential();
            RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);
            #endregion
            #region Snippet:Followup_Communication_Async_Tests_Samples_synccall
            RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
            var jobId = "job" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Operation<RadiologyInsightsInferenceResult> operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, jobId, radiologyInsightsjob);
            #endregion

            RadiologyInsightsInferenceResult responseData = operation.Value;
            IReadOnlyList<RadiologyInsightsInference> inferences = responseData.PatientResults[0].Inferences;

            foreach (RadiologyInsightsInference inference in inferences)
            {
                if (inference is FollowupCommunicationInference followupCommunicationInference)
                {
                    #region Snippet:Followup_Communication_Async_Tests_Samples_FollowupCommunicationInference
                    Console.WriteLine("Followup Communication Inference found");
                    Console.WriteLine("   Date/time: ");
                    IReadOnlyList<DateTimeOffset> dateTimeList = followupCommunicationInference.CommunicatedAt;
                    foreach (DateTimeOffset dateTime in dateTimeList)
                    {
                        Console.WriteLine("      " + dateTime);
                    }
                    Console.WriteLine("   Recipient: ");
                    IReadOnlyList<MedicalProfessionalType> recipientList = followupCommunicationInference.Recipient;
                    foreach (MedicalProfessionalType recipient in recipientList)
                    {
                        Console.WriteLine("      " + recipient);
                    }
                    Console.WriteLine("   Acknowledged: " + followupCommunicationInference.WasAcknowledged);
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
            #region Snippet:Followup_Communication_Async_Tests_Samples_AddRecordAndConfiguration
            List<PatientRecord> patientRecords = new() { patientRecord };
            RadiologyInsightsData radiologyInsightsData = new(patientRecords);
            radiologyInsightsData.Configuration = CreateConfiguration();
            #endregion
            return radiologyInsightsData;
        }

        private static RadiologyInsightsModelConfiguration CreateConfiguration()
        {
            RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = GetRadiologyInsightsInferenceOptions();
            #region Snippet:Followup_Communication_Async_Tests_Samples_CreateModelConfiguration
            RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
            {
                Locale = "en-US",
                IncludeEvidence = true,
                InferenceOptions = radiologyInsightsInferenceOptions
            };
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.FollowupCommunication);
            #endregion
            return radiologyInsightsModelConfiguration;
        }

        private static RadiologyInsightsInferenceOptions GetRadiologyInsightsInferenceOptions()
        {
            #region Snippet:Followup_Communication_Async_Tests_Samples_CreateRadiologyInsightsInferenceOptions
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
            #region Snippet:Followup_Communication_Async_Tests_Samples_CreatePatientRecord
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
            #region Snippet:Followup_Communication_Async_Tests_Samples_CreateDocumentAdministrativeMetadata
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
