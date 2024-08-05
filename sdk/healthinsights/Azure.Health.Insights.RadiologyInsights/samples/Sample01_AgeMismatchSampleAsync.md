# How to extract the description of a Age Mismatch Inference using a asynchronous call

In this sample it is shown how you can construct a request, add a configuration, create a client, send a asynchronous request and use the result returned to extract the tokens and display the document content evidence that triggered the age mismatch inference.

## Create a PatientRecord with patient details, encounter and document content.

```C# Snippet:Age_Mismatch_Async_Tests_Samples_CreatePatientRecord
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
```
## For the patient record document specify the following document content.
```C# Snippet:Age_Mismatch_Async_Tests_Samples_Doc_Content
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
```
## For the patient record create ordered procedures.
```C# Snippet:Age_Mismatch_Async_Tests_Samples_CreateDocumentAdministrativeMetadata
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
```
## Create a ModelConfiguration. Also specify the expected response inference type.

```C# Snippet:Age_Mismatch_Async_Tests_Samples_CreateModelConfiguration
RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
{
    Locale = "en-US",
    IncludeEvidence = true,
    InferenceOptions = radiologyInsightsInferenceOptions
};
radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.AgeMismatch);
```
## For the model configuration add the following inference options.
```C# Snippet:Age_Mismatch_Async_Tests_Samples_CreateRadiologyInsightsInferenceOptions
RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = new();
FollowupRecommendationOptions followupRecommendationOptions = new();
FindingOptions findingOptions = new();
followupRecommendationOptions.IncludeRecommendationsWithNoSpecifiedModality = true;
followupRecommendationOptions.IncludeRecommendationsInReferences = true;
followupRecommendationOptions.ProvideFocusedSentenceEvidence = true;
findingOptions.ProvideFocusedSentenceEvidence = true;
radiologyInsightsInferenceOptions.FollowupRecommendationOptions = followupRecommendationOptions;
radiologyInsightsInferenceOptions.FindingOptions = findingOptions;
```

## Add the PatientRecord and the ModelConfiguration inside RadiologyInsightsData.

```C# Snippet:Age_Mismatch_Async_Tests_Samples_AddRecordAndConfiguration
List<PatientRecord> patientRecords = new() { patientRecord };
RadiologyInsightsData radiologyInsightsData = new(patientRecords);
radiologyInsightsData.Configuration = CreateConfiguration();
```

## Create a RadiologyInsights client by initializing TokenCredential using the default Azure credentials.

```C# Snippet:Age_Mismatch_Async_Tests_Samples_CreateClient
Uri endpointUri = new Uri(endpoint);
TokenCredential cred = new DefaultAzureCredential();
RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);
```

## Send a asynchronous request to the RadiologyInsights client along with the job id and radiologyInsightsjob.

```C# Snippet:Age_Mismatch_Async_Tests_Samples_synccall
RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
var jobId = "job" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
Operation<RadiologyInsightsInferenceResult> operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, jobId, radiologyInsightsjob);
```

## Below code is used to display information about age mismatches inferred from radiology insights. The code retrieves a list of extensions associated with this inference. These extensions, represented as FhirR4Extension objects, contain additional information about the age mismatch. Finally, the system extracts evidence from these extensions using the ExtractEvidence function and prints out this evidence.

```C# Snippet:Age_Mismatch_Async_Tests_Samples_AgeMismatchInference
RadiologyInsightsInferenceResult responseData = operation.Value;
IReadOnlyList<RadiologyInsightsInference> inferences = responseData.PatientResults[0].Inferences;

foreach (RadiologyInsightsInference inference in inferences)
{
    if (inference is AgeMismatchInference ageMismatchInference)
    {
        Console.Write("Age Mismatch Inference found: ");
        IReadOnlyList<FhirR4Extension> extensions = ageMismatchInference.Extension;
        Console.Write("   Evidence: " + ExtractEvidence(extensions));
    }
}
```

## The code first goes through each extension in a list of extensions. Each extension is a FhirR4Extension object, which is a part of the Fast Healthcare Interoperability Resources (FHIR) standard and is used to represent additional information that is not part of the core data elements in a resource. For each extension, the code retrieves a list of sub-extensions. These sub-extensions are also FhirR4Extension objects and represent additional information that is associated with the parent extension. If the list of sub-extensions is not empty, the code then extracts evidence from these sub-extensions. The extractEvidenceToken function is used to extract this evidence, although the specifics of how this function works are not provided in the given code. The extracted evidence is then added to a string of evidence, with each piece of evidence separated by a space.

```C# Snippet:Age_Mismatch_Async_Tests_Samples_ExtractEvidence
foreach (FhirR4Extension extension in extensions)
{
    IList<FhirR4Extension> subExtensions = extension.Extension;
    if (subExtensions != null)
    {
        evidence += ExtractEvidenceToken(subExtensions) + " ";
    }
}
```

## Below code is used to extract a specific portion of a document based on the information contained in a list of extensions. The code first goes through each extension in a list of sub-extensions. Each extension is a FhirR4Extension object, which is a part of the Fast Healthcare Interoperability Resources (FHIR) standard and is used to represent additional information that is not part of the core data elements in a resource.For each extension, the code checks the URL of the extension. If the URL is “offset”, the code retrieves the integer value of the extension and stores it in the offset variable. This represents the starting position of the substring in the document. Similarly, if the URL of the extension is “length”, the code retrieves the integer value of the extension and stores it in the length variable. This represents the length of the substring to be extracted from the document. Once the code has retrieved the offset and length values, it checks if both values are greater than zero. If they are, the code extracts the substring from the document starting at the offset position and with the specified length. The extracted substring is then stored in the evidence variable.

```C# Snippet:Age_Mismatch_Async_Tests_Samples_EvidenceToken
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
    evidence = DOC_CONTENT.Substring(offset, Math.Min(offset + length, DOC_CONTENT.Length - offset));
}
```


