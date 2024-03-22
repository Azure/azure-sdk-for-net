# How to extract the description of a Age Mismatch Inference using a synchronous call

In this sample it is shown how you can construct a request, add a configuration, create a client, send a synchronous request and use the result returned to extract the order type, missing body parts and missing body part measurements of the complete order discrepancy inference.

## Create a PatientRecord

```C#
PatientRecord patientRecord = new(id);
patientRecord.Info = patientInfo;
patientRecord.Encounters.Add(encounter);
patientRecord.PatientDocuments.Add(patientDocument);
string id = "patient_id2";
PatientDetails patientInfo = new()
{
    BirthDate = new System.DateTime(1959, 11, 11),
    Sex = PatientInfoSex.Female,
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
DocumentContent documentContent = new(DocumentContentSourceType.Inline, DOC_CONTENT);
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
PatientDocument patientDocument = new(DocumentType.Note, "doc2", documentContent)
{
    ClinicalType = ClinicalDocumentType.RadiologyReport,
    CreatedDateTime = new System.DateTime(2021, 08, 28),
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
};
List<PatientRecord> patientRecords = new() { patientRecord };
```

## Create a ModelConfiguration

```C#
RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = new();
FollowupRecommendationOptions followupRecommendationOptions = new();
FindingOptions findingOptions = new();
followupRecommendationOptions.IncludeRecommendationsWithNoSpecifiedModality = true;
followupRecommendationOptions.IncludeRecommendationsInReferences = true;
followupRecommendationOptions.ProvideFocusedSentenceEvidence = true;
findingOptions.ProvideFocusedSentenceEvidence = true;
radiologyInsightsInferenceOptions.FollowupRecommendationOptions = followupRecommendationOptions;
radiologyInsightsInferenceOptions.FindingOptions = findingOptions;

RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
{
    Locale = "en-US",
    IncludeEvidence = true,
    InferenceOptions = radiologyInsightsInferenceOptions
};
radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.AgeMismatch);
```

## Add the PatientRecord and the ModelConfiguration inside RadiologyInsightsData

```C#
List<PatientRecord> patientRecords = new() { patientRecord };
RadiologyInsightsData radiologyInsightsData = new(patientRecords);
radiologyInsightsData.Configuration = CreateConfiguration();
```

## Create a RadiologyInsights client

```C#
Uri endpoint = new Uri("AZURE_HEALTH_INSIGHTS_ENDPOINT");
AzureKeyCredential credential = new AzureKeyCredential("AZURE_HEALTH_INSIGHTS_KEY");
RadiologyInsightsClient client = new RadiologyInsightsClient(endpoint, credential);
```

## Send a synchronous request to the RadiologyInsights client

```C#
Operation<RadiologyInsightsInferenceResult> operation = client.InferRadiologyInsights(WaitUntil.Completed, radiologyInsightsData);
```

## From the result loop over the inferences and display the order type, missing body parts and missing body part measurements of the complete order discrepancy inferences.

```C#
Console.Write("Complete Order Discrepancy Inference found: ");
FhirR4CodeableConcept orderType = completeOrderDiscrepancyInference.OrderType;
DisplayCodes(orderType, 1);
IReadOnlyList<FhirR4CodeableConcept> missingBodyParts = completeOrderDiscrepancyInference.MissingBodyParts;
Console.Write("   Missing body parts:");
foreach (FhirR4CodeableConcept missingBodyPart in missingBodyParts)
{
    DisplayCodes(missingBodyPart, 2);
}
IReadOnlyList<FhirR4CodeableConcept> missingBodyPartMeasurements = completeOrderDiscrepancyInference.MissingBodyPartMeasurements;
Console.Write("   Missing body part measurements:");
foreach (FhirR4CodeableConcept missingBodyPartMeasurement in missingBodyPartMeasurements)
{
    DisplayCodes(missingBodyPartMeasurement, 2);
}
```

## Print the code, display and system properties of the order type, missing body parts and missing body part measurements.

```C#
for (int i = 0; i < indentation; i++)
{
    initialBlank += "   ";
}
if (codeableConcept != null)
{
    IList<FhirR4Coding> codingList = codeableConcept.Coding;
    if (codingList != null)
    {
        foreach (FhirR4Coding fhirR4Coding in codingList)
        {
            Console.Write(initialBlank + "Coding: " + fhirR4Coding.Code + ", " + fhirR4Coding.Display + " (" + fhirR4Coding.System + ")");
        }
    }
}
```