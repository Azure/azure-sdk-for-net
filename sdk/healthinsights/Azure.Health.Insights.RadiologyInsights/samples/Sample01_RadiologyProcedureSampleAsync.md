# How to extract the description of a radiology procedure inference using an asynchronous call

In this sample it is shown how you can construct a request, add a configuration, create a client, send an asynchronous request and use the result returned to extract the procedure codes, imaging procedures and ordered procedure from the radiology procedure inference and print their code details.

## Creating a PatientRecord with Details, Encounter, and Document Content
To create a comprehensive patient record, instantiate a `PatientRecord` object with the patient’s details, encounter information, and document content. This record includes the patient’s birth date, sex, encounter class, period, and associated clinical documents, such as radiology reports. The `PatientRecord` object is then populated with these details to ensure all relevant patient information is accurately captured and organized.
```C# Snippet:Radiology_Procedure_Async_Tests_Samples_CreatePatientRecord
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

## Specifying Document Content for Patient Record
To define the document content for a patient record, create a constant string `DOC_CONTENT` that includes detailed clinical history, comparison, technique, findings, and impression sections. This content provides comprehensive information about the patient’s medical history, the techniques used in the examination, and the findings from the radiology report. This structured document content is essential for accurate and thorough patient records.
```C# Snippet:Radiology_Procedure_Async_Tests_Samples_Doc_Content
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

## Creating Ordered Procedures for Patient Record
To add ordered procedures to a patient record, instantiate a `DocumentAdministrativeMetadata` object and create a `FhirR4Coding` object with the relevant procedure details. This includes the display name, code, and system. Then, create a `FhirR4CodeableConcept` object and add the coding to it. Finally, create an `OrderedProcedure` object with a description and code, and add it to the `OrderedProcedures` list of the `DocumentAdministrativeMetadata` object. This process ensures that the ordered procedures are accurately documented and associated with the patient record.
```C# Snippet:Radiology_Procedure_Async_Tests_Samples_CreateDocumentAdministrativeMetadata
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

## Creating and Configuring ModelConfiguration for Radiology Insights
To set up a `RadiologyInsightsModelConfiguration`, instantiate the configuration object and specify the locale, whether to include evidence, and the inference options. Additionally, define the expected response inference types by adding them to the `InferenceTypes` list. This configuration ensures that the radiology insights model is tailored to the specific requirements and expected outcomes of the analysis.
```C# Snippet:Radiology_Procedure_Async_Tests_Samples_CreateModelConfiguration
RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
{
    Locale = "en-US",
    IncludeEvidence = true,
    InferenceOptions = radiologyInsightsInferenceOptions
};
radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.RadiologyProcedure);
```

## Adding Inference Options to ModelConfiguration for Radiology Insights
To configure the inference options for the radiology insights model, create instances of `RadiologyInsightsInferenceOptions`, `FollowupRecommendationOptions`, and `FindingOptions`. Set the desired properties for follow-up recommendations and findings, such as including recommendations with no specified modality, including recommendations in references, and providing focused sentence evidence. Assign these options to the `RadiologyInsightsInferenceOptions` object, ensuring that the model configuration is tailored to provide detailed and relevant insights.
```C# Snippet:Radiology_Procedure_Async_Tests_Samples_CreateRadiologyInsightsInferenceOptions
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

## Adding PatientRecord and ModelConfiguration to RadiologyInsightsData
To integrate the patient record and model configuration into `RadiologyInsightsData`, create a list of `PatientRecord` objects and initialize it with the patient record. Then, instantiate `RadiologyInsightsData` with this list. Finally, set the Configuration property of `RadiologyInsightsData` to the model configuration created using the `CreateConfiguration` method. This ensures that the data object is fully prepared with both patient information and the necessary configuration for radiology insights analysis.
```C# Snippet:Radiology_Procedure_Async_Tests_Samples_AddRecordAndConfiguration
List<PatientRecord> patientRecords = new() { patientRecord };
RadiologyInsightsData radiologyInsightsData = new(patientRecords);
radiologyInsightsData.Configuration = CreateConfiguration();
```

## Initializing RadiologyInsights Client with Default Azure Credentials
Create a `RadiologyInsightsClient` by initializing TokenCredential using the default Azure credentials.
```C# Snippet:Radiology_Procedure_Async_Tests_Samples_CreateClient
Uri endpointUri = new Uri(endpoint);
TokenCredential cred = new DefaultAzureCredential();
RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);
```

## Sending Asynchronous Requests with RadiologyInsights Client 
Send an asynchronous request to the `RadiologyInsightsClient` along with the job id and radiologyInsightsjob.
```C# Snippet:Radiology_Procedure_Async_Tests_Samples_synccall
RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
var jobId = "job" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
Operation<RadiologyInsightsInferenceResult> operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, jobId, radiologyInsightsjob);
```

## Extracting and Displaying Radiology Procedure Codes
Below code we extract the procedure codes from the radiology procedure inference. Procedure codes are specific codes that are used to identify the procedures that have been performed. Each procedure has a unique code associated with it. Imaging procedures refers to the specific imaging procedures that were performed during the radiology procedure. Details about the modality (the method or type of imaging used), the anatomy (the specific part of the body that was imaged), and the laterality (which side of the body was imaged) are included. Ordered Procedures refers to the procedures that were specifically ordered by a healthcare provider. The report includes the code of the ordered procedure and a description of it.
```C# Snippet:Radiology_Procedure_Async_Tests_Samples_RadiologyProcedureInference
Console.WriteLine("Radiology Procedure Inference found");
Console.WriteLine("   Procedure codes:");
IReadOnlyList<FhirR4CodeableConcept> procedureCodes = radiologyProcedureInference.ProcedureCodes;
foreach (FhirR4CodeableConcept procedureCode in procedureCodes)
{
    DisplayCodes(procedureCode, 2);
}

Console.WriteLine("   Imaging procedures:");
IReadOnlyList<ImagingProcedure> imagingProcedures = radiologyProcedureInference.ImagingProcedures;

foreach (ImagingProcedure imagingProcedure in imagingProcedures)
{
    Console.WriteLine("      Modality: ");
    FhirR4CodeableConcept modality = imagingProcedure.Modality;
    DisplayCodes(modality, 3);
    Console.WriteLine("      Anatomy: ");
    FhirR4CodeableConcept anatomy = imagingProcedure.Anatomy;
    DisplayCodes(anatomy, 3);
    Console.WriteLine("      Laterality: ");
    FhirR4CodeableConcept laterality = imagingProcedure.Laterality;
    DisplayCodes(laterality, 3);
}

Console.WriteLine("   Ordered procedures:");
OrderedProcedure orderedProcedure = radiologyProcedureInference.OrderedProcedure;
FhirR4CodeableConcept code = orderedProcedure.Code;
DisplayCodes(code, 2);
Console.WriteLine("   Description: " + orderedProcedure.Description);
```

## Displaying Medical Codes from a CodeableConcept Object
Following code retrieves a list of medical codes from a codeableConcept object. Each of these codes is represented as a FhirR4Coding object, which is a part of the Fast Healthcare Interoperability Resources (FHIR) standard. If this list of codes is not empty, the system then goes through each code in the list. For each code, it prints out the following details:
- **The actual code itself, which is a unique identifier for a specific medical concept.**
- **The display text of the code, which is a human-readable representation of the medical concept that the code represents.**
- **The system that the code belongs to, which indicates the specific coding system that the code is a part of. This could be a widely recognized coding system like LOINC or SNOMED CT.**
```C# Snippet:Radiology_Procedure_Async_Tests_Samples_DisplayCodes
IList<FhirR4Coding> codingList = codeableConcept.Coding;
if (codingList != null)
{
    foreach (FhirR4Coding fhirR4Coding in codingList)
    {
        Console.WriteLine(initialBlank + "Coding: " + fhirR4Coding.Code + ", " + fhirR4Coding.Display + " (" + fhirR4Coding.System + ")");
    }
}
```
