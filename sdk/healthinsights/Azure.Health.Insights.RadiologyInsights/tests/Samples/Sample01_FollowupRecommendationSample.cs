// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Azure.Health.Insights.RadiologyInsights.Tests
{
    internal class Sample01_FollowupRecommendationSample
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
        public void RadiologyInsightsFollowupRecommendationScenario()
        {
            Uri endpoint = new Uri("AZURE_HEALTH_INSIGHTS_ENDPOINT");
            AzureKeyCredential credential = new AzureKeyCredential("AZURE_HEALTH_INSIGHTS_KEY");
            RadiologyInsightsClient client = new RadiologyInsightsClient(endpoint, credential);

            RadiologyInsightsData radiologyInsightsData = GetRadiologyInsightsData();

            Operation<RadiologyInsightsInferenceResult> operation = client.InferRadiologyInsights(WaitUntil.Completed, radiologyInsightsData);
            RadiologyInsightsInferenceResult responseData = operation.Value;
            IReadOnlyList<RadiologyInsightsInference> inferences = responseData.PatientResults[0].Inferences;

            foreach (RadiologyInsightsInference inference in inferences)
            {
                if (inference is FollowupRecommendationInference followupRecommendationInference)
                {
                    Console.Write("Follow Up Recommendation Inference found");
                    IReadOnlyList<Extension> extensions = followupRecommendationInference.Extension;
                    Console.Write("   Evidence: " + ExtractEvidence(extensions));
                    Console.Write("   Is conditional: " + followupRecommendationInference.IsConditional);
                    Console.Write("   Is guideline: " + followupRecommendationInference.IsGuideline);
                    Console.Write("   Is hedging: " + followupRecommendationInference.IsHedging);
                    Console.Write("   Is option: " + followupRecommendationInference.IsOption);
                    ProcedureRecommendation recommendedProcedure = followupRecommendationInference.RecommendedProcedure;
                    Console.Write(" Recommended procedure: " + recommendedProcedure);
                }
            }
        }

        private static String ExtractEvidence(IReadOnlyList<Extension> extensions)
        {
            String evidence = "";
            foreach (Extension extension in extensions)
            {
                IReadOnlyList<Extension> subExtensions = extension.Extension;
                if (subExtensions != null)
                {
                    evidence += extractEvidenceToken(subExtensions) + " ";
                }
            }
            return evidence;
        }

        private static String extractEvidenceToken(IReadOnlyList<Extension> subExtensions)
        {
            String evidence = "";
            int offset = -1;
            int length = -1;
            foreach (Extension iExtension in subExtensions)
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
                Console.Write(Math.Min(offset + length, DOC_CONTENT.Length));
                //System.out.println("Offset: " + offset + ", length: " + length);
                evidence = DOC_CONTENT.Substring(offset, Math.Min(offset + length, DOC_CONTENT.Length - offset));
            }
            offset = -1;
            length = -1;
            return evidence;
        }

        private static RadiologyInsightsData GetRadiologyInsightsData()
        {
            PatientRecord patientRecord = CreatePatientRecord();
            RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = CreateConfiguration();
            List<PatientRecord> patientRecords = new() { patientRecord };
            RadiologyInsightsData radiologyInsightsData = new(patientRecords, radiologyInsightsModelConfiguration);
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
            radiologyInsightsInferenceOptions.FollowupRecommendation = followupRecommendationOptions;
            radiologyInsightsInferenceOptions.Finding = findingOptions;
            return radiologyInsightsInferenceOptions;
        }

        private static PatientRecord CreatePatientRecord()
        {
            string id = "patient_id2";
            PatientInfo patientInfo = new()
            {
                BirthDate = new System.DateTime(1959, 11, 11),
                Sex = PatientInfoSex.Female,
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
            List<PatientDocument> patientDocuments = new() { patientDocument };
            PatientRecord patientRecord = new(id, patientInfo, encounterList, patientDocuments);
            return patientRecord;
        }

        private static DocumentAdministrativeMetadata CreateDocumentAdministrativeMetadata()
        {
            DocumentAdministrativeMetadata documentAdministrativeMetadata = new DocumentAdministrativeMetadata();

            Coding coding = new()
            {
                Display = "US PELVIS COMPLETE",
                Code = "USPELVIS",
                System = "Http://hl7.org/fhir/ValueSet/cpt-all"
            };

            CodeableConcept codeableConcept = new();
            codeableConcept.Coding.Add(coding);

            OrderedProcedure orderedProcedure = new()
            {
                Description = "US PELVIS COMPLETE",
                Code = codeableConcept
            };

            documentAdministrativeMetadata.OrderedProcedures.Add(orderedProcedure);

            return documentAdministrativeMetadata;
        }
    }
}
