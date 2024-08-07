# How to extract the description of a Critical Result Inference using a synchronous call

In this sample it is shown how you can construct a request, add a configuration, create a client, send a synchronous request and use the result returned to extract the description of a critical result.

## Create a PatientRecord

```C#
PatientRecord patientRecord = new(id, patientInfo, encounterList, patientDocuments);
string id = "patient_id2";
PatientInfo patientInfo = new()
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
List<Encounter> encounterList = new() { encounter };
DocumentContent documentContent = new(DocumentContentSourceType.Inline, DOC_CONTENT);
string documentContent = "CLINICAL HISTORY:   "
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

    Coding coding = new()
    {
        Display = "US PELVIS COMPLETE",
        Code = "USPELVIS",
        System = "Http://hl7.org/fhir/ValueSet/cpt-all"
    };

    CodeableConcept codeableConcept = new();
    codeableConcept.Coding.Add(coding);

    OrderedProcedure orderedProcedure = new()
    {
        Description = "US PELVIS COMPLETE",
        Code = codeableConcept
    };

    documentAdministrativeMetadata.OrderedProcedures.Add(orderedProcedure);
};
List<PatientDocument> patientDocuments = new() { patientDocument };
List<PatientRecord> patientRecords = new() { patientRecord };
```

## Create a ModelConfiguration

```C#
FindingOptions findingOptions = new();
findingOptions.ProvideFocusedSentenceEvidence = true;
FollowupRecommendationOptions followupRecommendationOptions = new();
followupRecommendationOptions.IncludeRecommendationsWithNoSpecifiedModality = true;
followupRecommendationOptions.IncludeRecommendationsInReferences = true;
followupRecommendationOptions.ProvideFocusedSentenceEvidence = true;

RadiologyInsightsInferenceOptions radiologyInsightsInferenceOptions = new();
radiologyInsightsInferenceOptions.FollowupRecommendation = followupRecommendationOptions;
radiologyInsightsInferenceOptions.Finding = findingOptions;

RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
{
    Locale = "en-US",
    IncludeEvidence = true,
    InferenceOptions = radiologyInsightsInferenceOptions
};
radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.CriticalResult);
```

## Add the PatientRecord and the ModelConfiguration inside RadiologyInsightsData

```C#
RadiologyInsightsData radiologyInsightsData = new(patientRecords, radiologyInsightsModelConfiguration);
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

## From the result loop over the inferences and print the description of each critical result found

```C#
RadiologyInsightsInferenceResult responseData = operation.Value;
IReadOnlyList<RadiologyInsightsInference> inferences = responseData.PatientResults[0].Inferences;
foreach (RadiologyInsightsInference inference in inferences)
{
    if (inference is CriticalResultInference criticalResultInference)
    {
        Console.Write("Critical Result Inference found: " + criticalResultInference.Result.Description);
    }
}
```
