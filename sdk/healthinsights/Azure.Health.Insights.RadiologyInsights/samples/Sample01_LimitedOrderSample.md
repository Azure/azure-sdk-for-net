# How to extract the description of a limited order inference using a synchronous call

In this sample it is shown how you can construct a request, add a configuration, create a client, send a synchronous request and use the result returned to extract the order type, missing body parts and missing body part measurements of the limited order inference.

## Creating a PatientRecord with Details, Encounter, and Document Content
To create a comprehensive patient record, instantiate a `PatientRecord` object with the patient’s details, encounter information, and document content. This record includes the patient’s birth date, sex, encounter class, period, and associated clinical documents, such as radiology reports. The `PatientRecord` object is then populated with these details to ensure all relevant patient information is accurately captured and organized.
```C# Snippet:Limited_Order_Sync_Tests_Samples_CreatePatientRecord
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
```C# Snippet:Limited_Order_Sync_Tests_Samples_Doc_Content
private const string DOC_CONTENT = "\\nHISTORY: 49-year-old male with a history of tuberous sclerosis presenting with epigastric pain and diffuse tenderness. The patient was found to have pericholecystic haziness on CT; evaluation for acute cholecystitis.\\n\\nTECHNIQUE: Ultrasound evaluation of the abdomen was performed. Comparison is made to the prior abdominal ultrasound (2004) and to the enhanced CT of the abdomen and pelvis (2014).\\n\\nFINDINGS:\\n\\nThe liver is elongated, measuring 19.3 cm craniocaudally, and is homogeneous in echotexture without evidence of focal mass lesion. The liver contour is smooth on high resolution images. There is no appreciable intra- or extrahepatic biliary ductal dilatation, with the visualized extrahepatic bile duct measuring up to 6 mm. There are multiple shadowing gallstones, including within the gallbladder neck, which do not appear particularly mobile. In addition, there is thickening of the gallbladder wall up to approximately 7 mm with probable mild mural edema. There is no pericholecystic fluid. No sonographic Murphy's sign was elicited; however the patient reportedly received pain medications in the emergency department.\\n\\nThe pancreatic head, body and visualized portions of the tail are unremarkable. The spleen is normal in size, measuring 9.9 cm in length.\\n\\nThe kidneys are normal in size. The right kidney measures 11.5 x 5.2 x 4.3 cm and the left kidney measuring 11.8 x 5.3 x 5.1 cm. There are again multiple bilateral echogenic renal masses consistent with angiomyolipomas, in keeping with the patient's history of tuberous sclerosis. The largest echogenic mass on the right is located in the upper pole and measures 1.2 x 1.3 x 1.3 cm. The largest echogenic mass on the left is located within the renal sinus and measures approximately 2.6 x 2.7 x 4.6 cm. Additional indeterminate renal lesions are present bilaterally and are better characterized on CT. There is no hydronephrosis.\\n\\nNo ascites is identified within the upper abdomen.\\n\\nThe visualized portions of the upper abdominal aorta and IVC are normal in caliber.\\n\\nIMPRESSION:\\n\\n1. Numerous gallstones associated with gallbladder wall thickening and probable gallbladder mural edema, highly suspicious for acute cholecystitis in this patient presenting with epigastric pain and pericholecystic hazy density identified on CT. Although no sonographic Murphy sign was elicited, evaluation is limited secondary to reported prior administration of pain medication. Thus, clinical correlation is required. No evidence of biliary ductal dilation.\\n\\n2. There are again multiple bilateral echogenic renal masses consistent with angiomyolipomas, in keeping with the patient's history of tuberous sclerosis. Additional indeterminate renal lesions are present bilaterally and are better characterized on CT and MR.\\n\\nThese findings were discussed with Dr. Doe at 5:05 p.m. on 1/1/15.";
```

## Creating Ordered Procedures for Patient Record
To add ordered procedures to a patient record, instantiate a `DocumentAdministrativeMetadata` object and create a `FhirR4Coding` object with the relevant procedure details. This includes the display name, code, and system. Then, create a `FhirR4CodeableConcept` object and add the coding to it. Finally, create an `OrderedProcedure` object with a description and code, and add it to the `OrderedProcedures` list of the `DocumentAdministrativeMetadata` object. This process ensures that the ordered procedures are accurately documented and associated with the patient record.
```C# Snippet:Limited_Order_Sync_Tests_Samples_CreateDocumentAdministrativeMetadata
DocumentAdministrativeMetadata documentAdministrativeMetadata = new DocumentAdministrativeMetadata();

FhirR4Coding coding = new()
{
    Display = "US ABDOMEN LIMITED",
    Code = "30704-1",
    System = "Http://hl7.org/fhir/ValueSet/cpt-all"
};

FhirR4CodeableConcept codeableConcept = new();
codeableConcept.Coding.Add(coding);

OrderedProcedure orderedProcedure = new()
{
    Description = "US ABDOMEN LIMITED",
    Code = codeableConcept
};

documentAdministrativeMetadata.OrderedProcedures.Add(orderedProcedure);
```

## Creating and Configuring ModelConfiguration for Radiology Insights
To set up a `RadiologyInsightsModelConfiguration`, instantiate the configuration object and specify the locale, whether to include evidence, and the inference options. Additionally, define the expected response inference types by adding them to the `InferenceTypes` list. This configuration ensures that the radiology insights model is tailored to the specific requirements and expected outcomes of the analysis.
```C# Snippet:Limited_Order_Sync_Tests_Samples_CreateModelConfiguration
RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
{
    Locale = "en-US",
    IncludeEvidence = true,
    InferenceOptions = radiologyInsightsInferenceOptions
};

radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.LimitedOrderDiscrepancy);
```

## Adding Inference Options to ModelConfiguration for Radiology Insights
To configure the inference options for the radiology insights model, create instances of `RadiologyInsightsInferenceOptions`, `FollowupRecommendationOptions`, and `FindingOptions`. Set the desired properties for follow-up recommendations and findings, such as including recommendations with no specified modality, including recommendations in references, and providing focused sentence evidence. Assign these options to the `RadiologyInsightsInferenceOptions` object, ensuring that the model configuration is tailored to provide detailed and relevant insights.
```C# Snippet:Limited_Order_Sync_Tests_Samples_CreateRadiologyInsightsInferenceOptions
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
```C# Snippet:Limited_Order_Sync_Tests_Samples_AddRecordAndConfiguration
List<PatientRecord> patientRecords = new() { patientRecord };
RadiologyInsightsData radiologyInsightsData = new(patientRecords);
radiologyInsightsData.Configuration = CreateConfiguration();
```

## Initializing RadiologyInsights Client with Default Azure Credentials
Create a `RadiologyInsightsClient` by initializing TokenCredential using the default Azure credentials.
```C# Snippet:Limited_Order_Sync_Tests_Samples_CreateClient
Uri endpointUri = new Uri(endpoint);
TokenCredential cred = new DefaultAzureCredential();
RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);
```

## Sending Synchronous Requests with RadiologyInsights Client 
Send a synchronous request to the `RadiologyInsightsClient` along with the job id and radiologyInsightsjob.
```C# Snippet:Limited_Order_Sync_Tests_Samples_synccall
RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
var jobId = "job" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
Operation<RadiologyInsightsInferenceResult> operation = client.InferRadiologyInsights(WaitUntil.Completed, jobId, radiologyInsightsjob);
```

## Displaying Medical Discrepancy Details in a Patient’s Order
Following code is used to display information about medical discrepancy found in a patient’s order. The code retrieves the type of order that was placed. This could be a specific type of test or procedure that was ordered by a healthcare provider. The details of this order type, including its unique code and human-readable description, are then printed out. The code then retrieves a list of body parts that were present in the order but were not found or addressed during the procedure. For each of these missing body parts, the code prints out the details, including the unique code and human-readable description. Finally, the code retrieves a list of measurements for the missing body parts that were present in the order but were not taken or addressed during the procedure. For each of these missing measurements, the code prints out the details, including the unique code and human-readable description.

```C# Snippet:Limited_Order_Sync_Tests_Samples_LimitedOrderDiscrepancyInference
Console.WriteLine("Limited Order Discrepancy Inference found: ");
FhirR4CodeableConcept orderType = limitedOrderDiscrepancyInference.OrderType;
DisplayCodes(orderType, 1);
IReadOnlyList<FhirR4CodeableConcept> missingBodyParts = limitedOrderDiscrepancyInference.PresentBodyParts;
Console.WriteLine("   Present body parts:");
foreach (FhirR4CodeableConcept missingBodyPart in missingBodyParts)
{
    DisplayCodes(missingBodyPart, 2);
}
IReadOnlyList<FhirR4CodeableConcept> missingBodyPartMeasurements = limitedOrderDiscrepancyInference.PresentBodyPartMeasurements;
Console.WriteLine("   Present body part measurements:");
foreach (FhirR4CodeableConcept missingBodyPartMeasurement in missingBodyPartMeasurements)
{
    DisplayCodes(missingBodyPartMeasurement, 2);
}
```

## Displaying Medical Codes from a CodeableConcept Object
Following code retrieves a list of medical codes from a codeableConcept object. Each of these codes is represented as a FhirR4Coding object, which is a part of the Fast Healthcare Interoperability Resources (FHIR) standard. If this list of codes is not empty, the system then goes through each code in the list. For each code, it prints out the following details:
- **The actual code itself, which is a unique identifier for a specific medical concept.**
- **The display text of the code, which is a human-readable representation of the medical concept that the code represents.**
- **The system that the code belongs to, which indicates the specific coding system that the code is a part of. This could be a widely recognized coding system like LOINC or SNOMED CT.**

```C# Snippet:Limited_Order_Sync_Tests_Samples_DisplayCodes
IList<FhirR4Coding> codingList = codeableConcept.Coding;
if (codingList != null)
{
    foreach (FhirR4Coding fhirR4Coding in codingList)
    {
        Console.WriteLine(initialBlank + "Coding: " + fhirR4Coding.Code + ", " + fhirR4Coding.Display + " (" + fhirR4Coding.System + ")");
    }
}
```
