# How to extract the description of a finding inference using a asynchronous call

In this sample it is shown how you can construct a request, add a configuration, create a client, send a asynchronous request and use the result returned to extract the categories, interpretations and components of the finding inference.

## Create a PatientRecord with patient details, encounter and document content.

```C# Snippet:Finding_Async_Tests_Samples_CreatePatientRecord
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
```C# Snippet:Finding_Async_Tests_Samples_Doc_Content
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
```C# Snippet:Finding_Async_Tests_Samples_CreateDocumentAdministrativeMetadata
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

```C# Snippet:Finding_Async_Tests_Samples_CreateModelConfiguration
RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
{
    Locale = "en-US",
    IncludeEvidence = true,
    InferenceOptions = radiologyInsightsInferenceOptions
};
radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.Finding);
```
## For the model configuration add the following inference options.
```C# Snippet:Finding_Async_Tests_Samples_CreateRadiologyInsightsInferenceOptions
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

```C# Snippet:Finding_Async_Tests_Samples_AddRecordAndConfiguration
List<PatientRecord> patientRecords = new() { patientRecord };
RadiologyInsightsData radiologyInsightsData = new(patientRecords);
radiologyInsightsData.Configuration = CreateConfiguration();
```

## Create a RadiologyInsights client by initializing TokenCredential using the default Azure credentials.

```C# Snippet:Finding_Async_Tests_Samples_CreateClient
Uri endpointUri = new Uri(endpoint);
TokenCredential cred = new DefaultAzureCredential();
RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);
```

## Send an asynchronous request to the RadiologyInsights client along with the job id and radiologyInsightsjob.

```C# Snippet:Finding_Async_Tests_Samples_synccall
RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
var jobId = "job" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
Operation<RadiologyInsightsInferenceResult> operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, jobId, radiologyInsightsjob);
```

## Below code is used to display information about a medical finding. The code retrieves the finding, which is represented as a FhirR4Observation object. This object is part of the Fast Healthcare Interoperability Resources (FHIR) standard and is used to represent observations made about a patient. The code then retrieves a list of categories associated with the finding. Each category is represented as a FhirR4CodeableConcept object, which is also part of the FHIR standard and is used to represent coded or textual clinical information. The code then prints out each category. The code also retrieves the code associated with the finding and prints it out. This code is a unique identifier for the specific type of finding. Next, the code retrieves a list of interpretations associated with the finding. Each interpretation is also represented as a FhirR4CodeableConcept object. If this list is not empty, the code then prints out each interpretation. The code then retrieves a list of components associated with the finding. Each component is represented as a FhirR4ObservationComponent object, which is part of the FHIR standard and is used to represent a component of an observation. For each component, the code prints out the code associated with the component and the value of the component, which is also represented as a FhirR4CodeableConcept object. Finally, the code displays additional information about the finding inference using the displaySectionInfo function.

```C# Snippet:Finding_Async_Tests_Samples_FindingInference
        Console.Write("Finding Inference found");
        FhirR4Observation finding = findingInference.Finding;
        IReadOnlyList<FhirR4CodeableConcept> categoryList = finding.Category;
        foreach (FhirR4CodeableConcept category in categoryList)
        {
            Console.Write("   Category: ");
            DisplayCodes(category, 2);
        }
        Console.Write("   Code: ");
        FhirR4CodeableConcept code = finding.Code;
        DisplayCodes(code, 2);
        Console.Write("   Interpretation: ");
        IReadOnlyList<FhirR4CodeableConcept> interpretationList = finding.Interpretation;
        if (interpretationList != null)
        {
            foreach (FhirR4CodeableConcept interpretation in interpretationList)
            {
                DisplayCodes(interpretation, 2);
            }
        }
        Console.Write("   Component: ");
        IReadOnlyList<FhirR4ObservationComponent> componentList = finding.Component;
        foreach (FhirR4ObservationComponent component in componentList)
        {
            FhirR4CodeableConcept componentCode = component.Code;
            DisplayCodes(componentCode, 2);
            Console.Write("      Value codeable concept: ");
            FhirR4CodeableConcept valueCodeableConcept = component.ValueCodeableConcept;
            DisplayCodes(valueCodeableConcept, 4);
        }
        displaySectionInfo(findingInference);
    }
}
```

## Below code is used to display information about specific sections from a list of extensions. The code first goes through each extension in a list of extensions. Each extension is a FhirR4Extension object, which is a part of the Fast Healthcare Interoperability Resources (FHIR) standard and is used to represent additional information that is not part of the core data elements in a resource. For each extension, the code checks the URL of the extension. If the URL is “section”, the code then retrieves a list of sub-extensions associated with this section. These sub-extensions are also FhirR4Extension objects and represent additional information that is associated with the parent extension. If the list of sub-extensions is not empty, the code then goes through each sub-extension in the list. For each sub-extension, it prints out the URL and the string value of the sub-extension. The URL represents the specific type of information that the sub-extension contains, and the string value is the actual information.

```C# Snippet:Finding_Async_Tests_Samples_DisplaySectionInfo
foreach (FhirR4Extension extension in extensionList)
{
    if (extension.Url != null && extension.Url.Equals("section"))
    {
        Console.Write("   Section:");
        IList<FhirR4Extension> subextensionList = extension.Extension;
        if (subextensionList != null)
        {
            foreach (FhirR4Extension subextension in subextensionList)
            {
                Console.Write("      " + subextension.Url + ": " + subextension.ValueString);
            }
        }
    }
}
```

## Following code retrieves a list of medical codes from a codeableConcept object. Each of these codes is represented as a FhirR4Coding object, which is a part of the Fast Healthcare Interoperability Resources (FHIR) standard. If this list of codes is not empty, the system then goes through each code in the list. For each code, it prints out the following details:
- **The actual code itself, which is a unique identifier for a specific medical concept.**
- **The display text of the code, which is a human-readable representation of the medical concept that the code represents.**
- **The system that the code belongs to, which indicates the specific coding system that the code is a part of. This could be a widely recognized coding system like LOINC or SNOMED CT.**

```C# Snippet:Finding_Async_Tests_Samples_DisplayCodes
IList<FhirR4Coding> codingList = codeableConcept.Coding;
if (codingList != null)
{
    foreach (FhirR4Coding fhirR4Coding in codingList)
    {
        Console.Write(initialBlank + "Coding: " + fhirR4Coding.Code + ", " + fhirR4Coding.Display + " (" + fhirR4Coding.System + ")");
    }
}
```
