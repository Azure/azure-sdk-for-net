# How to extract the description of a radiology procedure inference using a synchronous call

In this sample it is shown how you can construct a request, add a configuration, create a client, send a synchronous request and use the result returned to extract the procedure codes, imaging procedures and ordered procedure from the radiology procedure inference and print their code details.

## Create a PatientRecord

```C# Snippet:Radiology_Procedure_Sync_Tests_Samples_CreatePatientRecord
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
```

## For the patient record document specify the following document content.
```C# Snippet:Radiology_Procedure_Sync_Tests_Samples_Doc_Content
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
```C# Snippet:Radiology_Procedure_Sync_Tests_Samples_CreateDocumentAdministrativeMetadata
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
```

## Create a ModelConfiguration

```C# Snippet:Radiology_Procedure_Sync_Tests_Samples_CreateModelConfiguration
RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
{
    Locale = "en-US",
    IncludeEvidence = true,
    InferenceOptions = radiologyInsightsInferenceOptions
};
radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.AgeMismatch);
```

## For the model configuration add the following inference options.
```C# Snippet:Radiology_Procedure_Sync_Tests_Samples_CreateRadiologyInsightsInferenceOptions
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

```C# Snippet:Radiology_Procedure_Sync_Tests_Samples_AddRecordAndConfiguration
List<PatientRecord> patientRecords = new() { patientRecord };
RadiologyInsightsData radiologyInsightsData = new(patientRecords);
radiologyInsightsData.Configuration = CreateConfiguration();
```

## Create a RadiologyInsights client

```C# Snippet:Radiology_Procedure_Sync_Tests_Samples_CreateClient
Uri endpointUri = new Uri(endpoint);
AzureKeyCredential credential = new AzureKeyCredential(apiKey);
RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, credential);
```

## Send a synchronous request to the RadiologyInsights client

```C# Snippet:Radiology_Procedure_Sync_Tests_Samples_synccall
Operation<RadiologyInsightsInferenceResult> operation = client.InferRadiologyInsights(WaitUntil.Completed, radiologyInsightsData);
```

## From the result loop over the inferences, extract the procedure codes, imaging procedures and ordered procedure from the laterality discrepancy and print their code details.

```C# Snippet:Radiology_Procedure_Sync_Tests_Samples_RadiologyProcedureInference
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
```

## Print the code, display and system properties of the order type, missing body parts and missing body part measurements.

```C# Snippet:Radiology_Procedure_Sync_Tests_Samples_DisplayCodes
IList<FhirR4Coding> codingList = codeableConcept.Coding;
if (codingList != null)
{
    foreach (FhirR4Coding fhirR4Coding in codingList)
    {
        Console.Write(initialBlank + "Coding: " + fhirR4Coding.Code + ", " + fhirR4Coding.Display + " (" + fhirR4Coding.System + ")");
    }
}
```