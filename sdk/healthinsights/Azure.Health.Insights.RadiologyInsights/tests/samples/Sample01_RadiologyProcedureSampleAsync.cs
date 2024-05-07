﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Health.Insights.RadiologyInsights.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Health.Insights.RadiologyInsights.Tests
{
    internal class Sample01_RadiologyProcedureSampleAsync : SamplesBase<HealthInsightsTestEnvironment>
    {
        #region Snippet:Radiology_Procedure_Async_Tests_Samples_Doc_Content
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
        public async Task RadiologyInsightsRadiologyProcedureScenario()
        {
            // Read endpoint and apiKey
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:Radiology_Procedure_Async_Tests_Samples_CreateClient
            Uri endpointUri = new Uri(endpoint);
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);
            RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, credential);
            #endregion

            RadiologyInsightsData radiologyInsightsData = GetRadiologyInsightsData();

            #region Snippet:Radiology_Procedure_Async_Tests_Samples_synccall
            Operation<RadiologyInsightsInferenceResult> operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, radiologyInsightsData);
            #endregion

            RadiologyInsightsInferenceResult responseData = operation.Value;
            IReadOnlyList<RadiologyInsightsInference> inferences = responseData.PatientResults[0].Inferences;

            foreach (RadiologyInsightsInference inference in inferences)
            {
                if (inference is RadiologyProcedureInference radiologyProcedureInference)
                {
                    #region Snippet:Radiology_Procedure_Async_Tests_Samples_RadiologyProcedureInference
                    Console.Write("Radiology Procedure Inference found");
                    Console.Write("   Procedure codes:");
                    IReadOnlyList<FhirR4CodeableConcept> procedureCodes = radiologyProcedureInference.ProcedureCodes;
                    foreach (FhirR4CodeableConcept procedureCode in procedureCodes)
                    {
                        DisplayCodes(procedureCode, 2);
                    }

                    Console.Write("   Imaging procedures:");
                    IReadOnlyList<ImagingProcedure> imagingProcedures = radiologyProcedureInference.ImagingProcedures;

                    foreach (ImagingProcedure imagingProcedure in imagingProcedures)
                    {
                        Console.Write("      Modality: ");
                        FhirR4CodeableConcept modality = imagingProcedure.Modality;
                        DisplayCodes(modality, 3);
                        Console.Write("      Anatomy: ");
                        FhirR4CodeableConcept anatomy = imagingProcedure.Anatomy;
                        DisplayCodes(anatomy, 3);
                        Console.Write("      Laterality: ");
                        FhirR4CodeableConcept laterality = imagingProcedure.Laterality;
                        DisplayCodes(laterality, 3);
                    }

                    Console.Write("   Ordered procedures:");
                    FhirR4Extendible orderedProcedure = radiologyProcedureInference.OrderedProcedure;
                    FhirR4CodeableConcept code = orderedProcedure.Code;
                    DisplayCodes(code, 2);
                    Console.Write("   Description: " + orderedProcedure.Description);
                    #endregion
                }
            }
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
                #region Snippet:Radiology_Procedure_Async_Tests_Samples_DisplayCodes
                IList<FhirR4Coding> codingList = codeableConcept.Coding;
                if (codingList != null)
                {
                    foreach (FhirR4Coding fhirR4Coding in codingList)
                    {
                        Console.Write(initialBlank + "Coding: " + fhirR4Coding.Code + ", " + fhirR4Coding.Display + " (" + fhirR4Coding.System + ")");
                    }
                }
                #endregion
            }
        }

        private static RadiologyInsightsData GetRadiologyInsightsData()
        {
            PatientRecord patientRecord = CreatePatientRecord();
            #region Snippet:Radiology_Procedure_Async_Tests_Samples_AddRecordAndConfiguration
            List<PatientRecord> patientRecords = new() { patientRecord };
            RadiologyInsightsData radiologyInsightsData = new(patientRecords);
            radiologyInsightsData.Configuration = CreateConfiguration();
            #endregion
            return radiologyInsightsData;
        }

        private static RadiologyInsightsModelConfiguration CreateConfiguration()
        {
            RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = GetRadiologyInsightsInferenceOptions();
            #region Snippet:Radiology_Procedure_Async_Tests_Samples_CreateModelConfiguration
            RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
            {
                Locale = "en-US",
                IncludeEvidence = true,
                InferenceOptions = radiologyInsightsInferenceOptions
            };
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.AgeMismatch);
            #endregion
            return radiologyInsightsModelConfiguration;
        }

        private static RadiologyInsightsInferenceOptions GetRadiologyInsightsInferenceOptions()
        {
            #region Snippet:Radiology_Procedure_Async_Tests_Samples_CreateRadiologyInsightsInferenceOptions
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
            #region Snippet:Radiology_Procedure_Async_Tests_Samples_CreatePatientRecord
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
            List<Encounter> encounterList = new() { encounter };
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
            #endregion
            return patientRecord;
        }

        private static DocumentAdministrativeMetadata CreateDocumentAdministrativeMetadata()
        {
            #region Snippet:Radiology_Procedure_Async_Tests_Samples_CreateDocumentAdministrativeMetadata
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
            #endregion
            return documentAdministrativeMetadata;
        }
    }
}
