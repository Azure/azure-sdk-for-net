# How to extract the description of a limited order inference using a synchronous call

In this sample it is shown how you can construct a request, add a configuration, create a client, send a synchronous request and use the result returned to extract the order type, missing body parts and missing body part measurements of the limited order inference.

## Create a PatientRecord

```C# Snippet:Limited_Order_Sync_Tests_Samples_CreatePatientRecord
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
```C# Snippet:Limited_Order_Sync_Tests_Samples_Doc_Content
private const string DOC_CONTENT = "\\nHISTORY: 49-year-old male with a history of tuberous sclerosis presenting with epigastric pain and diffuse tenderness. The patient was found to have pericholecystic haziness on CT; evaluation for acute cholecystitis.\\n\\nTECHNIQUE: Ultrasound evaluation of the abdomen was performed. Comparison is made to the prior abdominal ultrasound (2004) and to the enhanced CT of the abdomen and pelvis (2014).\\n\\nFINDINGS:\\n\\nThe liver is elongated, measuring 19.3 cm craniocaudally, and is homogeneous in echotexture without evidence of focal mass lesion. The liver contour is smooth on high resolution images. There is no appreciable intra- or extrahepatic biliary ductal dilatation, with the visualized extrahepatic bile duct measuring up to 6 mm. There are multiple shadowing gallstones, including within the gallbladder neck, which do not appear particularly mobile. In addition, there is thickening of the gallbladder wall up to approximately 7 mm with probable mild mural edema. There is no pericholecystic fluid. No sonographic Murphy's sign was elicited; however the patient reportedly received pain medications in the emergency department.\\n\\nThe pancreatic head, body and visualized portions of the tail are unremarkable. The spleen is normal in size, measuring 9.9 cm in length.\\n\\nThe kidneys are normal in size. The right kidney measures 11.5 x 5.2 x 4.3 cm and the left kidney measuring 11.8 x 5.3 x 5.1 cm. There are again multiple bilateral echogenic renal masses consistent with angiomyolipomas, in keeping with the patient's history of tuberous sclerosis. The largest echogenic mass on the right is located in the upper pole and measures 1.2 x 1.3 x 1.3 cm. The largest echogenic mass on the left is located within the renal sinus and measures approximately 2.6 x 2.7 x 4.6 cm. Additional indeterminate renal lesions are present bilaterally and are better characterized on CT. There is no hydronephrosis.\\n\\nNo ascites is identified within the upper abdomen.\\n\\nThe visualized portions of the upper abdominal aorta and IVC are normal in caliber.\\n\\nIMPRESSION:\\n\\n1. Numerous gallstones associated with gallbladder wall thickening and probable gallbladder mural edema, highly suspicious for acute cholecystitis in this patient presenting with epigastric pain and pericholecystic hazy density identified on CT. Although no sonographic Murphy sign was elicited, evaluation is limited secondary to reported prior administration of pain medication. Thus, clinical correlation is required. No evidence of biliary ductal dilation.\\n\\n2. There are again multiple bilateral echogenic renal masses consistent with angiomyolipomas, in keeping with the patient's history of tuberous sclerosis. Additional indeterminate renal lesions are present bilaterally and are better characterized on CT and MR.\\n\\nThese findings were discussed with Dr. Doe at 5:05 p.m. on 1/1/15.";
```

## For the patient record create ordered procedures.
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

FhirR4Extendible orderedProcedure = new()
{
    Description = "US ABDOMEN LIMITED",
    Code = codeableConcept
};

documentAdministrativeMetadata.OrderedProcedures.Add(orderedProcedure);
```

## Create a ModelConfiguration

```C# Snippet:Limited_Order_Sync_Tests_Samples_CreateModelConfiguration
RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
{
    Locale = "en-US",
    IncludeEvidence = true,
    InferenceOptions = radiologyInsightsInferenceOptions
};

radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.LimitedOrderDiscrepancy);
```

## For the model configuration add the following inference options.
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

## Add the PatientRecord and the ModelConfiguration inside RadiologyInsightsData

```C# Snippet:Limited_Order_Sync_Tests_Samples_AddRecordAndConfiguration
List<PatientRecord> patientRecords = new() { patientRecord };
RadiologyInsightsData radiologyInsightsData = new(patientRecords);
radiologyInsightsData.Configuration = CreateConfiguration();
```

## Create a RadiologyInsights client

```C# Snippet:Limited_Order_Sync_Tests_Samples_CreateClient
Uri endpointUri = new Uri(endpoint);
AzureKeyCredential credential = new AzureKeyCredential(apiKey);
RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, credential);
```

## Send a synchronous request to the RadiologyInsights client

```C# Snippet:Limited_Order_Sync_Tests_Samples_synccall
Operation<RadiologyInsightsInferenceResult> operation = client.InferRadiologyInsights(WaitUntil.Completed, radiologyInsightsData);
```

## From the result loop over the inferences, extract the order type, missing body parts and missing body part measurements of the limited order inference.

```C# Snippet:Limited_Order_Sync_Tests_Samples_LimitedOrderDiscrepancyInference
Console.Write("Limited Order Discrepancy Inference found: ");
FhirR4CodeableConcept orderType = limitedOrderDiscrepancyInference.OrderType;
DisplayCodes(orderType, 1);
IReadOnlyList<FhirR4CodeableConcept> missingBodyParts = limitedOrderDiscrepancyInference.PresentBodyParts;
Console.Write("   Present body parts:");
foreach (FhirR4CodeableConcept missingBodyPart in missingBodyParts)
{
    DisplayCodes(missingBodyPart, 2);
}
IReadOnlyList<FhirR4CodeableConcept> missingBodyPartMeasurements = limitedOrderDiscrepancyInference.PresentBodyPartMeasurements;
Console.Write("   Present body part measurements:");
foreach (FhirR4CodeableConcept missingBodyPartMeasurement in missingBodyPartMeasurements)
{
    DisplayCodes(missingBodyPartMeasurement, 2);
}
```

## Print the code, display and system properties of the order type, missing body parts and missing body part measurements.

```C# Snippet:Limited_Order_Sync_Tests_Samples_DisplayCodes
IList<FhirR4Coding> codingList = codeableConcept.Coding;
if (codingList != null)
{
    foreach (FhirR4Coding fhirR4Coding in codingList)
    {
        Console.Write(initialBlank + "Coding: " + fhirR4Coding.Code + ", " + fhirR4Coding.Display + " (" + fhirR4Coding.System + ")");
    }
}
```