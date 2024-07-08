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

## Create a RadiologyInsights client by initializing TokenCredential using the default Azure credentials.

```C# Snippet:Followup_Recommendation_Async_Tests_Samples_CreateClient
Uri endpointUri = new Uri(endpoint);
TokenCredential cred = new DefaultAzureCredential();
RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);
```

## Send an asynchronous request to the RadiologyInsights client along with the job id and radiologyInsightsjob.

```C# Snippet:Followup_Recommendation_Async_Tests_Samples_synccall
RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
var jobId = "job" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
Operation<RadiologyInsightsInferenceResult> operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, jobId, radiologyInsightsjob);
```

## Below code is used to display information about a follow-up recommendation for a patient. The code retrieves a list of evidence supporting the recommendation. This could include various pieces of data or observations that led to the recommendation. Next, the code prints out several characteristics of the recommendation:

- **Whether the recommendation is conditional, meaning it depends on certain conditions or circumstances.**
- **Whether the recommendation is based on a guideline, meaning it follows a standard or protocol.**
- **Whether the recommendation is hedging, meaning it is cautious or non-committal.**
- **Whether the recommendation is an option, meaning it is one of several possible actions that could be taken.**

## The code then identifies the specific procedure that is being recommended. This could be a generic procedure or an imaging procedure. If it's a generic procedure, the code prints out the unique code associated with the procedure. If it's an imaging procedure, the code prints out the unique codes associated with the procedure, as well as details about the imaging procedures that are being recommended. This includes the modality (the method or type of imaging used), the anatomy (the specific part of the body that is to be imaged), and the evidence supporting the use of each modality and anatomy. In summary, this code is used to print out a detailed report on a follow-up recommendation for a patient, including the evidence supporting the recommendation, the characteristics of the recommendation, and the details of the recommended procedure. This can be useful in a healthcare setting for communicating complex medical recommendations. The code uses the Fast Healthcare Interoperability Resources (FHIR) standard to represent and exchange this information. The `FhirR4CodeableConcept` and `FhirR4Extension` objects in the code are part of the FHIR standard and are used to represent coded or textual clinical information.

```C# Snippet:Followup_Recommendation_Async_Tests_Samples_FollowupRecommendationInference
Console.Write("Follow Up Recommendation Inference found");
IList<FhirR4Extension> extensions = followupRecommendationInference.Extension;
Console.Write("   Evidence: " + ExtractEvidence((IList<FhirR4Extension>)extensions));
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

## Following code retrieves a list of medical codes from a codeableConcept object. Each of these codes is represented as a FhirR4Coding object, which is a part of the Fast Healthcare Interoperability Resources (FHIR) standard. If this list of codes is not empty, the system then goes through each code in the list. For each code, it prints out the following details:
- **The actual code itself, which is a unique identifier for a specific medical concept.**
- **The display text of the code, which is a human-readable representation of the medical concept that the code represents.**
- **The system that the code belongs to, which indicates the specific coding system that the code is a part of. This could be a widely recognized coding system like LOINC or SNOMED CT.**

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

## The code first goes through each extension in a list of extensions. Each extension is a FhirR4Extension object, which is a part of the Fast Healthcare Interoperability Resources (FHIR) standard and is used to represent additional information that is not part of the core data elements in a resource. For each extension, the code retrieves a list of sub-extensions. These sub-extensions are also FhirR4Extension objects and represent additional information that is associated with the parent extension. If the list of sub-extensions is not empty, the code then extracts evidence from these sub-extensions. The extractEvidenceToken function is used to extract this evidence, although the specifics of how this function works are not provided in the given code. The extracted evidence is then added to a string of evidence, with each piece of evidence separated by a space.

```C# Snippet:Followup_Recommendation_Async_Tests_Samples_ExtractEvidence
foreach (FhirR4Extension extension in extensions)
{
    IList<FhirR4Extension> subExtensions = extension.Extension;
    if (subExtensions != null)
    {
        evidence += extractEvidenceToken(subExtensions) + " ";
    }
}
```

## The below code is used to extract a specific substring from a document based on the information contained in a list of extensions. The code first goes through each extension in a list of sub-extensions. Each extension is a FhirR4Extension object, which is a part of the Fast Healthcare Interoperability Resources (FHIR) standard and is used to represent additional information that is not part of the core data elements in a resource. For each extension, the code checks the URL of the extension. If the URL is “offset”, the code retrieves the integer value of the extension and stores it in the offset variable. This represents the starting position of the substring in the document. Similarly, if the URL of the extension is “length”, the code retrieves the integer value of the extension and stores it in the length variable. This represents the length of the substring to be extracted from the document. Once the code has retrieved the offset and length values, it checks if both values are greater than zero. If they are, the code extracts the substring from the document starting at the offset position and with the specified length. The extracted substring is then stored in the evidence variable.

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
