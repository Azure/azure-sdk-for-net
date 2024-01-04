# Get the inferred cancer staging for an oncology patient
This sample demonstrates how to get the inferred cancer staging, such as pTNM staging and histology codes, for an oncology patient, based on his/her clinical documents (medical records), and to review the clinical evidence for each inference, extracted from these documents.

To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Creating a `CancerProfilingClient`

To create a new `CancerProfilingClient` to get the inferred cancer staging, you need a Cognitive Services endpoint and credentials. You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a AzureHealthInsights service API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateCancerProfilingClientAsync
// Read endpoint and apiKey
string endpoint = TestEnvironment.Endpoint;
string apiKey = TestEnvironment.ApiKey;

var endpointUri = new Uri(endpoint);
var credential = new AzureKeyCredential(apiKey);

// Create CancerProfilingClient
CancerProfilingClient client = new CancerProfilingClient(endpointUri, credential);
```

## Get the inferred pTNM staging and histology codes for an oncology patient

To get the inferred pTNM staging and histology codes for an oncology patient, call `InferCancerProfileAsync` on an instance of `OncoPhenotypeData`.  The result is a Long Running operation of type `OncoPhenotypeResult`.

```C# Snippet:HealthInsightsOncoPhenotypeDataAsync
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
```

Call InferCancerProfileAsync to submit an Oncology async request and get the Onco-Phenotype result


```C# Snippet:HealthInsightsCancerProfilingClientInferCancerProfileAsync
OncoPhenotypeResults oncoResults = default;
try
{
    Operation<OncoPhenotypeResults> operation = await client.InferCancerProfileAsync(WaitUntil.Completed, oncoPhenotypeData);
    oncoResults = operation.Value;
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    return;
}
```

To view the oncology inferences:

```C# Snippet:HealthInsightsCancerProfilingInferCancerProfileAsyncViewResults
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
```


<!-- Links -->
[README]:https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/healthinsights/Azure.Health.Insights.CancerProfiling/README.md
