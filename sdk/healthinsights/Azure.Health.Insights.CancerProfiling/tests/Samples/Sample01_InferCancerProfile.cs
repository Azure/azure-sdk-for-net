// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Health.Insights.CancerProfiling.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Health.Insights.CancerProfiling.Tests.Samples
{
    public partial class HealthInsightsSamples : SamplesBase<HealthInsightsTestEnvironment>
    {
        [Test]
        public void InferCancerProfile()
        {
            #region Snippet:CreateCancerProfilingClient

            // Read endpoint and apiKey
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var endpointUri = new Uri(endpoint);
            var credential = new AzureKeyCredential(apiKey);

            // Create CancerProfilingClient
            CancerProfilingClient client = new CancerProfilingClient(endpointUri, credential);

            #endregion

            #region Snippet:HealthInsightsOncoPhenotypeData
            // Create Patient
            PatientRecord patient1 = new PatientRecord("patient_id");

            // Add imaging document
            string docContent1 = @"
                   15.8.2021
                Jane Doe 091175-8967
                42 year old female, married with 3 children, works as a nurse.
                Healthy, no medications taken on a regular basis.
                PMHx is significant for migraines with aura, uses Mirena for contraception.
                Smoking history of 10 pack years (has stopped and relapsed several times).
                She is in c/o 2 weeks of productive cough and shortness of breath.
                She has a fever of 37.8 and general weakness.
                Denies night sweats and rash. She denies symptoms of rhinosinusitis, asthma, and heartburn.
                On PE:
                GENERAL: mild pallor, no cyanosis. Regular breathing rate.
                LUNGS: decreased breath sounds on the base of the right lung. Vesicular breathing.
                 No crackles, rales, and wheezes. Resonant percussion.
                PLAN:
                Will be referred for a chest x-ray.
                ======================================
                CXR showed mild nonspecific opacities in right lung base.
                PLAN:
                Findings are suggestive of a working diagnosis of pneumonia. The patient is referred to a follow-up CXR in 2 weeks.";

            PatientDocument patientDocument1 = new PatientDocument(DocumentType.Note,
                                                                    "doc1",
                                                                    new DocumentContent(DocumentContentSourceType.Inline, docContent1))
            {
                ClinicalType = ClinicalDocumentType.Imaging,
                Language = "en",
                CreatedDateTime = DateTimeOffset.Parse("2021-08-15T00:00:00")
            };
            patient1.Data.Add(patientDocument1);

            // Add Pathology documents
            string docContent2 = @"
                  Oncology Clinic
                20.10.2021
                Jane Doe 091175-8967
                42-year-old healthy female who works as a nurse in the ER of this hospital.
                First menstruation at 11 years old. First delivery- 27 years old. She has 3 children.
                Didn’t breastfeed.
                Contraception- Mirena.
                Smoking- 10 pack years.
                Mother- Belarusian. Father- Georgian.
                About 3 months prior to admission, she stated she had SOB and was febrile.
                She did a CXR as an outpatient which showed a finding in the base of the right lung- possibly an infiltrate.
                She was treated with antibiotics with partial response.
                6 weeks later a repeat CXR was performed- a few solid dense findings in the right lung.
                Therefore, she was referred for a PET-CT which demonstrated increased uptake in the right breast, lymph nodes on the right a few areas in the lungs and liver.
                On biopsy from the lesion in the right breast- triple negative adenocarcinoma. Genetic testing has not been done thus far.
                Genetic counseling- the patient denies a family history of breast, ovary, uterus, and prostate cancer. Her mother has chronic lymphocytic leukemia (CLL).
                She is planned to undergo genetic tests because the aggressive course of the disease, and her young age.
                Impression:
                Stage 4 triple negative breast adenocarcinoma.
                Could benefit from biological therapy.
                Different treatment options were explained- the patient wants to get a second opinion.";
            PatientDocument patientDocument2 = new PatientDocument(DocumentType.Note,
                                                                    "doc2",
                                                                    new DocumentContent(DocumentContentSourceType.Inline, docContent2))
            {
                ClinicalType = ClinicalDocumentType.Pathology,
                Language = "en",
                CreatedDateTime = DateTimeOffset.Parse("2021-10-20T22:00:00.00")
            };

            patient1.Data.Add(patientDocument2);

            string docContent3 = @"
                   PATHOLOGY REPORT
                                        Clinical Information
               Ultrasound-guided biopsy; A. 18 mm mass; most likely diagnosis based on imaging:  IDC
                                             Diagnosis
               A.  BREAST, LEFT AT 2:00 4 CM FN; ULTRASOUND-GUIDED NEEDLE CORE BIOPSIES:
               - Invasive carcinoma of no special type (invasive ductal carcinoma), grade 1
               Nottingham histologic grade:  1/3 (tubules 2; nuclear grade 2; mitotic rate 1; total score;  5/9)
               Fragments involved by invasive carcinoma:  2
               Largest measurement of invasive carcinoma on a single fragment:  7 mm
               Ductal carcinoma in situ (DCIS):  Present
               Architectural pattern:  Cribriform
               Nuclear grade:  2-
                                -intermediate
               Necrosis:  Not identified
               Fragments involved by DCIS:  1
               Largest measurement of DCIS on a single fragment:  Span 2 mm
               Microcalcifications:  Present in benign breast tissue and invasive carcinoma
               Blocks with invasive carcinoma:  A1
               Special studies: Pending";

            PatientDocument patientDocument3 = new PatientDocument(DocumentType.Note,
                                                                    "doc3",
                                                                    new DocumentContent(DocumentContentSourceType.Inline, docContent3))
            {
                ClinicalType = ClinicalDocumentType.Pathology,
                Language = "en",
                CreatedDateTime = DateTimeOffset.Parse("2022-01-01T00:00:00")
            };
            patient1.Data.Add(patientDocument3);

            // Set configuration to include evidence for the cancer staging inferences and to check for whether a cancer case exists in the text
            var configuration = new OncoPhenotypeModelConfiguration() { IncludeEvidence = true, CheckForCancerCase = true };

            // Create OncoPhenotypeData with patient and configration
            var oncoPhenotypeData = new OncoPhenotypeData(new List<PatientRecord> { patient1 }) { Configuration = configuration };
            #endregion
            #region Snippet:HealthInsightsCancerProfilingClientInferCancerProfile
            OncoPhenotypeResults oncoResults = default;
            try
            {
                Operation<OncoPhenotypeResults> operation = client.InferCancerProfile(WaitUntil.Completed, oncoPhenotypeData);
                oncoResults = operation.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            #endregion

            #region Snippet:HealthInsightsCancerProfilingInferCancerProfileViewResults
            // View operation results
            foreach (OncoPhenotypePatientResult patientResult in oncoResults.Patients)
            {
                Console.WriteLine($"\n==== Inferences of Patient {patientResult.Id} ====");
                foreach (OncoPhenotypeInference oncoInference in patientResult.Inferences)
                {
                    Console.WriteLine($"\n=== Clinical Type: {oncoInference.Type.ToString()}  Value: {oncoInference.Value}   ConfidenceScore: {oncoInference.ConfidenceScore} ===");
                    foreach (InferenceEvidence evidence in oncoInference.Evidence)
                    {
                        if (evidence.PatientDataEvidence != null)
                        {
                            var dataEvidence = evidence.PatientDataEvidence;
                            Console.WriteLine($"Evidence {dataEvidence.Id} {dataEvidence.Offset} {dataEvidence.Length} {dataEvidence.Text}");
                        }
                        if (evidence.PatientInfoEvidence != null)
                        {
                            var infoEvidence = evidence.PatientInfoEvidence;
                            Console.WriteLine($"Evidence {infoEvidence.System} {infoEvidence.Code} {infoEvidence.Name} {infoEvidence.Value}");
                        }
                    }
                }
            }

            #endregion
        }
    }
}
