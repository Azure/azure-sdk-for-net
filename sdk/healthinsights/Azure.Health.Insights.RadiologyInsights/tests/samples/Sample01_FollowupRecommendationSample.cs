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

namespace Azure.Health.Insights.RadiologyInsights.Tests
{
    internal class Sample01_FollowupRecommendationSample : SamplesBase<HealthInsightsTestEnvironment>
    {
        #region Snippet:Followup_Recommendation_Sync_Tests_Samples_Doc_Content
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
        public void RadiologyInsightsFollowupRecommendationScenario()
        {
            // Read endpoint
            string endpoint = TestEnvironment.Endpoint;

            #region Snippet:Followup_Recommendation_Sync_Tests_Samples_CreateClient
            Uri endpointUri = new Uri(endpoint);
            TokenCredential cred = new DefaultAzureCredential();
            RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);
            #endregion
            #region Snippet:Followup_Recommendation_Sync_Tests_Samples_synccall
            RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
            var jobId = "job" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Operation<RadiologyInsightsInferenceResult> operation = client.InferRadiologyInsights(WaitUntil.Completed, jobId, radiologyInsightsjob);
            #endregion

            RadiologyInsightsInferenceResult responseData = operation.Value;
            IReadOnlyList<RadiologyInsightsInference> inferences = responseData.PatientResults[0].Inferences;

            foreach (RadiologyInsightsInference inference in inferences)
            {
                if (inference is FollowupRecommendationInference followupRecommendationInference)
                {
                    #region Snippet:Followup_Recommendation_Sync_Tests_Samples_FollowupRecommendationInference
                    Console.WriteLine("Follow Up Recommendation Inference found");
                    IReadOnlyList<FhirR4Extension> extensions = followupRecommendationInference.Extension;
                    Console.WriteLine("   Evidence: " + ExtractEvidence((IList<FhirR4Extension>)extensions));
                    Console.WriteLine("   Is conditional: " + followupRecommendationInference.IsConditional);
                    Console.WriteLine("   Is guideline: " + followupRecommendationInference.IsGuideline);
                    Console.WriteLine("   Is hedging: " + followupRecommendationInference.IsHedging);
                    Console.WriteLine("   Is option: " + followupRecommendationInference.IsOption);

                    ProcedureRecommendation recommendedProcedure = followupRecommendationInference.RecommendedProcedure;
                    if (recommendedProcedure is GenericProcedureRecommendation)
                    {
                        Console.WriteLine("   Generic procedure recommendation:");
                        GenericProcedureRecommendation genericProcedureRecommendation = (GenericProcedureRecommendation)recommendedProcedure;
                        Console.WriteLine("      Procedure codes: ");
                        FhirR4CodeableConcept code = genericProcedureRecommendation.Code;
                        DisplayCodes(code, 3);
                    }
                    if (recommendedProcedure is ImagingProcedureRecommendation)
                    {
                        Console.WriteLine("   Imaging procedure recommendation: ");
                        ImagingProcedureRecommendation imagingProcedureRecommendation = (ImagingProcedureRecommendation)recommendedProcedure;
                        Console.WriteLine("      Procedure codes: ");
                        IReadOnlyList<FhirR4CodeableConcept> procedureCodes = imagingProcedureRecommendation.ProcedureCodes;
                        if (procedureCodes != null)
                        {
                            foreach (FhirR4CodeableConcept codeableConcept in procedureCodes)
                            {
                                DisplayCodes(codeableConcept, 3);
                            }
                        }

                        Console.WriteLine("      Imaging procedure: ");
                        IReadOnlyList<ImagingProcedure> imagingProcedures = imagingProcedureRecommendation.ImagingProcedures;
                        foreach (ImagingProcedure imagingProcedure in imagingProcedures)
                        {
                            Console.WriteLine("         Modality");
                            FhirR4CodeableConcept modality = imagingProcedure.Modality;
                            DisplayCodes(modality, 4);
                            Console.WriteLine("            Evidence: " + ExtractEvidence(modality.Extension));

                            Console.WriteLine("         Anatomy");
                            FhirR4CodeableConcept anatomy = imagingProcedure.Anatomy;
                            DisplayCodes(anatomy, 4);
                            Console.WriteLine("            Evidence: " + ExtractEvidence(anatomy.Extension));
                        }
                        #endregion
                    }
                }
            }
        }

        private static RadiologyInsightsJob GetRadiologyInsightsJob()
        {
            RadiologyInsightsJob radiologyInsightsJob = new RadiologyInsightsJob();
            radiologyInsightsJob.JobData = GetRadiologyInsightsData();
            return radiologyInsightsJob;
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
                #region Snippet:Followup_Recommendation_Sync_Tests_Samples_DisplayCodes
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

        private static String ExtractEvidence(IList<FhirR4Extension> extensions)
        {
            String evidence = "";
            #region Snippet:Followup_Recommendation_Sync_Tests_Samples_ExtractEvidence
            foreach (FhirR4Extension extension in extensions)
            {
                IList<FhirR4Extension> subExtensions = extension.Extension;
                if (subExtensions != null)
                {
                    evidence += extractEvidenceToken(subExtensions) + " ";
                }
            }
            #endregion
            return evidence;
        }

        private static String extractEvidenceToken(IList<FhirR4Extension> subExtensions)
        {
            String evidence = "";
            int offset = -1;
            int length = -1;
            #region Snippet:Followup_Recommendation_Sync_Tests_Samples_ExtractEvidenceToken
            foreach (FhirR4Extension iExtension in subExtensions)
            {
                if (iExtension.Url.Equals("offset"))
                {
                    offset = (int)iExtension.ValueInteger;
                }
                if (iExtension.Url.Equals("length"))
                {
                    length = (int)iExtension.ValueInteger;
                }
            }
            if (offset > 0 && length > 0)
            {
                evidence = DOC_CONTENT.Substring(offset, Math.Min(length, DOC_CONTENT.Length - offset));
            }
            #endregion
            return evidence;
        }

        private static RadiologyInsightsData GetRadiologyInsightsData()
        {
            PatientRecord patientRecord = CreatePatientRecord();
            #region Snippet:Followup_Recommendation_Sync_Tests_Samples_AddRecordAndConfiguration
            List<PatientRecord> patientRecords = new() { patientRecord };
            RadiologyInsightsData radiologyInsightsData = new(patientRecords);
            radiologyInsightsData.Configuration = CreateConfiguration();
            #endregion
            return radiologyInsightsData;
        }

        private static RadiologyInsightsModelConfiguration CreateConfiguration()
        {
            RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = GetRadiologyInsightsInferenceOptions();
            #region Snippet:Followup_Recommendation_Sync_Tests_Samples_CreateModelConfiguration
            RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
            {
                Locale = "en-US",
                IncludeEvidence = true,
                InferenceOptions = radiologyInsightsInferenceOptions
            };
            radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.FollowupRecommendation);
            #endregion
            return radiologyInsightsModelConfiguration;
        }

        private static RadiologyInsightsInferenceOptions GetRadiologyInsightsInferenceOptions()
        {
            #region Snippet:Followup_Recommendation_Sync_Tests_Samples_CreateRadiologyInsightsInferenceOptions
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
            #region Snippet:Followup_Recommendation_Sync_Tests_Samples_CreatePatientRecord
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
            #region Snippet:Followup_Recommendation_Sync_Tests_Samples_CreateDocumentAdministrativeMetadata
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
