# How to extract the description of a followup recommendation inference using an asynchronous call

In this sample it is shown how you can construct a request, add a configuration, create a client, send a asynchronous request and use the result returned to extract the generic procedure recommendation, imaging procedure recommendation of the followup recommendation inference.

## Create a PatientRecord with patient details, encounter and document content.

```C# Snippet:Followup_Recommendation_Async_Tests_Samples_CreatePatientRecord
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
DocumentContent documentContent = new(DocumentContentSourceType.Inline, DOC_CONTENT);
PatientDocument patientDocument = new(DocumentType.Note, "doc2", documentContent)
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
```C# Snippet:Followup_Recommendation_Async_Tests_Samples_Doc_Content
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
```C# Snippet:Followup_Recommendation_Async_Tests_Samples_CreateDocumentAdministrativeMetadata
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

## Create a ModelConfiguration
```C# Snippet:Followup_Recommendation_Async_Tests_Samples_CreateModelConfiguration
RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
{
    Locale = "en-US",
    IncludeEvidence = true,
    InferenceOptions = radiologyInsightsInferenceOptions
};
radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.FollowupRecommendation);
```

## For the model configuration add the following inference options.
```C# Snippet:Followup_Recommendation_Async_Tests_Samples_CreateRadiologyInsightsInferenceOptions
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

## Add the PatientRecord and the ModelConfiguration inside RadiologyInsightsData

```C# Snippet:Followup_Recommendation_Async_Tests_Samples_AddRecordAndConfiguration
List<PatientRecord> patientRecords = new() { patientRecord };
RadiologyInsightsData radiologyInsightsData = new(patientRecords);
radiologyInsightsData.Configuration = CreateConfiguration();
```

## Create a RadiologyInsights client

```C# Snippet:Followup_Recommendation_Async_Tests_Samples_CreateClient
Uri endpointUri = new Uri(endpoint);
AzureKeyCredential credential = new AzureKeyCredential(apiKey);
RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, credential);
```

## Send an asynchronous request to the RadiologyInsights client

```C# Snippet:Followup_Recommendation_Async_Tests_Samples_synccall
RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
var jobId = "job" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
Operation<RadiologyInsightsInferenceResult> operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, jobId, radiologyInsightsjob);
```

## From the result loop over the inferences and display the generic procedure recommendation and the imaging procedure recommendation of the followup recommendation inferences. 

```C# Snippet:Followup_Recommendation_Async_Tests_Samples_FollowupRecommendationInference
Console.Write("Follow Up Recommendation Inference found");
IList<FhirR4Extension> extensions = followupRecommendationInference.Extension;
Console.Write("   Evidence: " + ExtractEvidence((IReadOnlyList<FhirR4Extension>)extensions));
Console.Write("   Is conditional: " + followupRecommendationInference.IsConditional);
Console.Write("   Is guideline: " + followupRecommendationInference.IsGuideline);
Console.Write("   Is hedging: " + followupRecommendationInference.IsHedging);
Console.Write("   Is option: " + followupRecommendationInference.IsOption);
ProcedureRecommendation recommendedProcedure = followupRecommendationInference.RecommendedProcedure;
if (recommendedProcedure is GenericProcedureRecommendation)
{
    Console.Write("   Generic procedure recommendation:");
    GenericProcedureRecommendation genericProcedureRecommendation = (GenericProcedureRecommendation)recommendedProcedure;
    Console.Write("      Procedure codes: ");
    FhirR4CodeableConcept code = genericProcedureRecommendation.Code;
    DisplayCodes(code, 3);
}
if (recommendedProcedure is ImagingProcedureRecommendation)
{
    Console.Write("   Imaging procedure recommendation: ");
    ImagingProcedureRecommendation imagingProcedureRecommendation = (ImagingProcedureRecommendation)recommendedProcedure;
    Console.Write("      Procedure codes: ");
    IList<FhirR4CodeableConcept> procedureCodes = imagingProcedureRecommendation.ProcedureCodes;
    if (procedureCodes != null)
    {
        foreach (FhirR4CodeableConcept codeableConcept in procedureCodes)
        {
            DisplayCodes(codeableConcept, 3);
        }
    }

    Console.Write("      Imaging procedure: ");
    IList<ImagingProcedure> imagingProcedures = imagingProcedureRecommendation.ImagingProcedures;
    foreach (ImagingProcedure imagingProcedure in imagingProcedures)
    {
        Console.Write("         Modality");
        FhirR4CodeableConcept modality = imagingProcedure.Modality;
        DisplayCodes(modality, 4);
        Console.Write("            Evidence: " + ExtractEvidence(modality.Extension));

        Console.Write("         Anatomy");
        FhirR4CodeableConcept anatomy = imagingProcedure.Anatomy;
        DisplayCodes(anatomy, 4);
        Console.Write("            Evidence: " + ExtractEvidence(anatomy.Extension));
    }
    Console.Write(" Recommended procedure: " + recommendedProcedure);
```

## Print the code, display and system properties of the imaging procedure recommendations.

```C# Snippet:Followup_Recommendation_Async_Tests_Samples_DisplayCodes
IList<FhirR4Coding> codingList = codeableConcept.Coding;
if (codingList != null)
{
    foreach (FhirR4Coding fhirR4Coding in codingList)
    {
        Console.Write(initialBlank + "Coding: " + fhirR4Coding.Code + ", " + fhirR4Coding.Display + " (" + fhirR4Coding.System + ")");
    }
}
```

## In the ExtractEvidence method iterate over each of the extensions and get the subExtensions. With these subExtensions call the ExtractEvidenceToken method.

```C# Snippet:Followup_Recommendation_Async_Tests_Samples_ExtractEvidence
foreach (FhirR4Extension extension in extensions)
{
    IReadOnlyList<FhirR4Extension> subExtensions = extension.Extension;
    if (subExtensions != null)
    {
        evidence += extractEvidenceToken(subExtensions) + " ";
    }
}
```

## In the ExtractEvidenceToken method get the tokens from the subExtensions. Then using these tokens extract the evidence from the document content and written back the evidence.

```C# Snippet:Followup_Recommendation_Async_Tests_Samples_ExtractEvidenceToken
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
