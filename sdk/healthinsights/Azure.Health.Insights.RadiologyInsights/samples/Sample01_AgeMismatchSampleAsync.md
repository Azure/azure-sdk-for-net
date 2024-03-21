# How to extract the description of a Age Mismatch Inference using a asynchronous call

In this sample it is shown how you can construct a request, add a configuration, create a client, send a asynchronous request and use the result returned to extract the tokens and display the document content evidence that triggered the age mismatch inference.

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

## Send a asynchronous request to the RadiologyInsights client

```C#
Operation<RadiologyInsightsInferenceResult> operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, radiologyInsightsData);
```

## From the result loop over the inferences and call the ExtractEvidence method with  extensions of each age mismatch found. The ExtractEvidence method returns the evidence which triggered the age mismatch inference.

```C#
RadiologyInsightsInferenceResult responseData = operation.Value;
IReadOnlyList<RadiologyInsightsInference> inferences = responseData.PatientResults[0].Inferences;

foreach (RadiologyInsightsInference inference in inferences)
{
    if (inference is AgeMismatchInference ageMismatchInference)
    {
        Console.Write("Age Mismatch Inference found: ");
        IReadOnlyList<FhirR4Extension> extensions = ageMismatchInference.Extension;
        Console.Write("   Evidence: " + ExtractEvidence(extensions));
    }
}
```

## In the ExtractEvidence method iterate over each of the extensions and get the subExtensions. With these subExtensions call the ExtractEvidenceToken method to get the evidence which is returned back.

```C#
foreach (FhirR4Extension extension in extensions)
{
    IReadOnlyList<FhirR4Extension> subExtensions = extension.Extension;
    if (subExtensions != null)
    {
        evidence += ExtractEvidenceToken(subExtensions) + " ";
    }
}
```

## In the ExtractEvidence method iterate over each of the extensions and get the subExtensions. With these subExtensions call the ExtractEvidenceToken method to get the evidence which is returned back.

```C#
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


