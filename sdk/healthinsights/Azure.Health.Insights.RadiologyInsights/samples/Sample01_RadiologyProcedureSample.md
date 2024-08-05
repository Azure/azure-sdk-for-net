# How to extract the description of a radiology procedure inference using a synchronous call

In this sample it is shown how you can construct a request, add a configuration, create a client, send a synchronous request and use the result returned to extract the procedure codes, imaging procedures and ordered procedure from the radiology procedure inference and print their code details.

## Create a PatientRecord with patient details, encounter and document content.

```C# Snippet:Radiology_Procedure_Sync_Tests_Samples_CreatePatientRecord
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

OrderedProcedure orderedProcedure = new()
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

## Create a RadiologyInsights client by initializing TokenCredential using the default Azure credentials.

```C# Snippet:Radiology_Procedure_Sync_Tests_Samples_CreateClient
Uri endpointUri = new Uri(endpoint);
TokenCredential cred = new DefaultAzureCredential();
RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);
```

## Send a synchronous request to the RadiologyInsights client along with the job id and radiologyInsightsjob.

```C# Snippet:Radiology_Procedure_Sync_Tests_Samples_synccall
RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
var jobId = "job" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
Operation<RadiologyInsightsInferenceResult> operation = client.InferRadiologyInsights(WaitUntil.Completed, jobId, radiologyInsightsjob);
```

## Below code we extract the procedure codes from the radiology procedure inference. Procedure codes are specific codes that are used to identify the procedures that have been performed. Each procedure has a unique code associated with it. Imaging procedures refers to the specific imaging procedures that were performed during the radiology procedure. Details about the modality (the method or type of imaging used), the anatomy (the specific part of the body that was imaged), and the laterality (which side of the body was imaged) are included. Ordered Procedures refers to the procedures that were specifically ordered by a healthcare provider. The report includes the code of the ordered procedure and a description of it.

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
OrderedProcedure orderedProcedure = radiologyProcedureInference.OrderedProcedure;
FhirR4CodeableConcept code = orderedProcedure.Code;
DisplayCodes(code, 2);
Console.Write("   Description: " + orderedProcedure.Description);
```

## Following code retrieves a list of medical codes from a codeableConcept object. Each of these codes is represented as a FhirR4Coding object, which is a part of the Fast Healthcare Interoperability Resources (FHIR) standard. If this list of codes is not empty, the system then goes through each code in the list. For each code, it prints out the following details:
- **The actual code itself, which is a unique identifier for a specific medical concept.**
- **The display text of the code, which is a human-readable representation of the medical concept that the code represents.**
- **The system that the code belongs to, which indicates the specific coding system that the code is a part of. This could be a widely recognized coding system like LOINC or SNOMED CT.**

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