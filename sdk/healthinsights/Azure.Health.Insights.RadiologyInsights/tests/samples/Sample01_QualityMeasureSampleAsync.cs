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
using System.Threading.Tasks;

namespace Azure.Health.Insights.RadiologyInsights.Tests
{
    internal class Sample01_QualityMeasureSampleAsync : SamplesBase<HealthInsightsTestEnvironment>
    {
        #region Snippet:Quality_Measure_Async_Tests_Samples_Doc_Content
        private const string DOC_CONTENT = "inline\"," +
            "\r\n  value: `EXAM: CT CHEST WO CONTRAST" +
            "\r\n\r\nINDICATION: abnormal lung findings. History of emphysema." +
            "\r\n\r\nTECHNIQUE: Helical CT images through the chest, without contrast. This exam was performed using one or more of the following dose reduction techniques: Automated exposure control, adjustment of the mA and/or kV according to patient size, and/or use of iterative reconstruction technique. " +
            "\r\n\r\nCOMPARISON: Chest CT dated 6/21/2022." +
            "\r\nNumber of previous CT examinations or cardiac nuclear medicine (myocardial perfusion) examinations performed in the preceding 12-months: 2" +
            "\r\n\r\nFINDINGS:" +
            "\r\nHeart size is normal. No pericardial effusion. Thoracic aorta as well as pulmonary arteries are normal in caliber. There are dense coronary artery calcifications. No enlarged axillary, mediastinal, or hilar lymph nodes by CT size criteria. Central airways are widely patent. No bronchial wall thickening. No pneumothorax, pleural effusion or pulmonary edema. The previously identified posterior right upper lobe nodules are no longer seen. However, there are multiple new small pulmonary nodules. An 8 mm nodule in the right upper lobe, image #15 series 4. New posterior right upper lobe nodule measuring 6 mm, image #28 series 4. New 1.2 cm pulmonary nodule, right upper lobe, image #33 series 4. New 4 mm pulmonary nodule left upper lobe, image #22 series 4. New 8 mm pulmonary nodule in the left upper lobe adjacent to the fissure, image #42 series 4. A few new tiny 2 to 3 mm pulmonary nodules are also noted in the left lower lobe. As before there is a background of severe emphysema. No evidence of pneumonia." +
            "\r\nLimited evaluation of the upper abdomen shows no concerning abnormality." +
            "\r\nReview of bone windows shows no aggressive appearing osseous lesions." +
            "\r\n\r\n\r\nIMPRESSION:" +
            "\r\n\r\n1. Previously identified small pulmonary nodules in the right upper lobe have resolved, but there are multiple new small nodules scattered throughout both lungs. Recommend short-term follow-up with noncontrast chest CT in 3 months as per current  Current guidelines (2017 Fleischner Society)." +
            "\r\n2. Severe emphysema." +
            "\r\n\r\nFindings communicated to Dr. Jane Smith.`,";
        #endregion

        [Test]
        public async Task RadiologyInsightsQualityMeasureScenario()
        {
            // Read endpoint
            string endpoint = TestEnvironment.Endpoint;
            #region Snippet:Quality_Measure_Async_Tests_Samples_TokenCredential
            Uri endpointUri = new Uri(endpoint);
            TokenCredential cred = new DefaultAzureCredential();
            RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);
            #endregion
            #region Snippet:Quality_Measure_Async_Tests_Samples_Asynccall
            RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
            var jobId = "job" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Operation<RadiologyInsightsInferenceResult> operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, jobId, radiologyInsightsjob);
            #endregion
            #region Snippet:Quality_Measure_Async_Tests_Samples_Quality_Measure_Inference
            RadiologyInsightsInferenceResult responseData = operation.Value;
            IReadOnlyList<RadiologyInsightsInference> inferences = responseData.PatientResults[0].Inferences;

            foreach (RadiologyInsightsInference inference in inferences)
            {
                if (inference is QualityMeasureInference qualityMeasureInference)
                {
                    Console.WriteLine("Quality Measure Inference found:");

                    Console.WriteLine($"   Quality Measure Denominator: {qualityMeasureInference.QualityMeasureDenominator}");
                    Console.WriteLine($"   Compliance Type: {qualityMeasureInference.ComplianceType}");

                    IReadOnlyList<string> qualityCriterias = qualityMeasureInference.QualityCriteria;

                    foreach (string qualityCriteria in qualityCriterias)
                    {
                        Console.WriteLine("   Quality Criterium: ", qualityCriteria);
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
            #region Snippet:Quality_Measure_Async_Tests_Samples_AddRecordAndConfiguration
            List<PatientRecord> patientRecords = new() { patientRecord };
            RadiologyInsightsData radiologyInsightsData = new(patientRecords);
            radiologyInsightsData.Configuration = CreateConfiguration();
            #endregion
            return radiologyInsightsData;
        }

        private static RadiologyInsightsModelConfiguration CreateConfiguration()
        {
            RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = GetRadiologyInsightsInferenceOptions();
            #region Snippet:Quality_Measure_Async_Tests_Samples_CreateModelConfiguration
            RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
            {
                Locale = "en-US",
                IncludeEvidence = true,
                InferenceOptions = radiologyInsightsInferenceOptions
            };
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.QualityMeasure);
            #endregion
            return radiologyInsightsModelConfiguration;
        }

        private static RadiologyInsightsInferenceOptions GetRadiologyInsightsInferenceOptions()
        {
            #region Snippet:Quality_Measure_Async_Tests_Samples_CreateRadiologyInsightsInferenceOptions
            RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = new();
            FollowupRecommendationOptions followupRecommendationOptions = new();
            FindingOptions findingOptions = new();
            var measureTypes = new[]
            {
                QualityMeasureType.Mips364,
                QualityMeasureType.Mips360,
                QualityMeasureType.Mips436
            };
            QualityMeasureOptions qualityMeasureOptions = new(measureTypes);
            followupRecommendationOptions.IncludeRecommendationsWithNoSpecifiedModality = true;
            followupRecommendationOptions.IncludeRecommendationsInReferences = true;
            followupRecommendationOptions.ProvideFocusedSentenceEvidence = true;
            findingOptions.ProvideFocusedSentenceEvidence = true;
            radiologyInsightsInferenceOptions.FollowupRecommendationOptions = followupRecommendationOptions;
            radiologyInsightsInferenceOptions.FindingOptions = findingOptions;
            radiologyInsightsInferenceOptions.QualityMeasureOptions = qualityMeasureOptions;
            #endregion
            return radiologyInsightsInferenceOptions;
        }

        private static PatientRecord CreatePatientRecord()
        {
            #region Snippet:Quality_Measure_Async_Tests_Samples_CreatePatientRecord
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
            #region Snippet:Quality_Measure_Async_Tests_Samples_CreateDocumentAdministrativeMetadata
            DocumentAdministrativeMetadata documentAdministrativeMetadata = new DocumentAdministrativeMetadata();

            FhirR4Coding coding = new()
            {
                Display = "CT CHEST WO CONTRAST",
                Code = "CTCHWO",
                System = "http://www.ama-assn.org/go/cpt"
            };

            FhirR4CodeableConcept codeableConcept = new();
            codeableConcept.Coding.Add(coding);

            OrderedProcedure orderedProcedure = new()
            {
                Description = "CT CHEST WO CONTRAST",
                Code = codeableConcept
            };

            documentAdministrativeMetadata.OrderedProcedures.Add(orderedProcedure);
            #endregion
            return documentAdministrativeMetadata;
        }
    }
}
