# How to extract the description of a Clinical Guidance using an asynchronous call

In this sample it is shown how you can construct a request, add a configuration, create a client, send an asynchronous request and use the result returned to extract clinical guidance information from radiology reports, display findings codes, present guidance information, and recommendation proposals.

## Creating a PatientRecord with Details, Encounter, and Document Content
To create a comprehensive patient record, instantiate a `PatientRecord` object with the patient’s details, encounter information, and document content. This record includes the patient’s birth date, sex, encounter class, period, and associated clinical documents, such as radiology reports. The `PatientRecord` object is then populated with these details to ensure all relevant patient information is accurately captured and organized.
```C# Snippet:Guidance_Async_Tests_Samples_CreatePatientRecord
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
```C# Snippet:Guidance_Async_Tests_Samples_Doc_Content
private const string DOC_CONTENT = "History:" +
    "\r\n    Left renal tumor with thin septations." +
    "\r\n    Findings:" +
    "\r\n    There is a right kidney tumor with nodular calcification.";
```

## Creating Ordered Procedures for Patient Record
To add ordered procedures to a patient record, instantiate a `DocumentAdministrativeMetadata` object and create a `FhirR4Coding` object with the relevant procedure details. This includes the display name, code, and system. Then, create a `FhirR4CodeableConcept` object and add the coding to it. Finally, create an `OrderedProcedure` object with a description and code, and add it to the `OrderedProcedures` list of the `DocumentAdministrativeMetadata` object. This process ensures that the ordered procedures are accurately documented and associated with the patient record.
```C# Snippet:Guidance_Async_Tests_Samples_CreateDocumentAdministrativeMetadata
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
```C# Snippet:Guidance_Async_Tests_Samples_CreateModelConfiguration
RadiologyInsightsModelConfiguration radiologyInsightsModelConfiguration = new()
{
    Locale = "en-US",
    IncludeEvidence = true,
    InferenceOptions = radiologyInsightsInferenceOptions
};
radiologyInsightsModelConfiguration.InferenceTypes.Add(RadiologyInsightsInferenceType.Guidance);
```

## Adding Inference Options to ModelConfiguration for Radiology Insights
To configure the inference options for the radiology insights model, create instances of `RadiologyInsightsInferenceOptions`, `FollowupRecommendationOptions`, and `FindingOptions`. Set the desired properties for follow-up recommendations and findings, such as including recommendations with no specified modality, including recommendations in references, and providing focused sentence evidence. Assign these options to the `RadiologyInsightsInferenceOptions` object, ensuring that the model configuration is tailored to provide detailed and relevant insights.
```C# Snippet:Guidance_Async_Tests_Samples_CreateRadiologyInsightsInferenceOptions
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
```C# Snippet:Guidance_Async_Tests_Samples_AddRecordAndConfiguration
List<PatientRecord> patientRecords = new() { patientRecord };
RadiologyInsightsData radiologyInsightsData = new(patientRecords);
radiologyInsightsData.Configuration = CreateConfiguration();
```

## Initializing RadiologyInsights Client with Default Azure Credentials
Create a `RadiologyInsightsClient` by initializing TokenCredential using the default Azure credentials.
```C# Snippet:Guidance_Async_Tests_Samples_TokenCredential
Uri endpointUri = new Uri(endpoint);
TokenCredential cred = new DefaultAzureCredential();
RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);
```

## Sending Asynchronous Requests with RadiologyInsights Client 
Send a asynchronous request using the `RadiologyInsightsClient` along with the job id and radiologyInsightsjob.
```C# Snippet:Guidance_Async_Tests_Samples_Asynccall
RadiologyInsightsJob radiologyInsightsjob = GetRadiologyInsightsJob();
var jobId = "job" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
Operation<RadiologyInsightsInferenceResult> operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, jobId, radiologyInsightsjob);
```

## Displaying Guidance Inferences from Radiology Insights
Below code retrieves clinical guidance inferences from radiology report analysis results and displays key information for each guidance inference found. It extracts and displays finding codes, identifiers, present guidance information, rankings, recommendation proposals, and any missing guidance information - providing a comprehensive view of the clinical guidance derived from the radiology report.
```C# Snippet:Guidance_Async_Tests_Samples_GuidanceInference
RadiologyInsightsInferenceResult responseData = operation.Value;
IReadOnlyList<RadiologyInsightsInference> inferences = responseData.PatientResults[0].Inferences;

foreach (RadiologyInsightsInference inference in inferences)
{
    if (inference is GuidanceInference guidanceInference)
    {
        Console.WriteLine("Guidance Inference found: ");

        FindingInference findingInference = guidanceInference.Finding;
        FhirR4Observation finding = findingInference.Finding;
        if (finding.Code != null)
        {
            Console.WriteLine("   Finding Code: ");
            DisplayCodes(finding.Code, 2);
        }

        Console.WriteLine("   Identifier: ");
        DisplayCodes(guidanceInference.Identifier, 2);

        foreach (var presentInfo in guidanceInference.PresentGuidanceInformation)
        {
            Console.WriteLine("   Present Guidance Information: ");
            DisplayPresentGuidanceInformation(presentInfo);
        }

        Console.WriteLine($"   Ranking: {guidanceInference.Ranking}");
        IReadOnlyList<FollowupRecommendationInference> recommendationProposals = guidanceInference.RecommendationProposals;
        foreach (FollowupRecommendationInference recommendationProposal in recommendationProposals)
        {
            Console.WriteLine($"   Recommendation Proposal: {recommendationProposal.RecommendedProcedure.Kind}");
        }

        foreach (var missingInfo in guidanceInference.MissingGuidanceInformation)
        {
            Console.WriteLine($"   Missing Guidance Information: {missingInfo}");
        }
    }
}
```

## Display FHIR R4 Coding Information
Below code iterates through a list of FHIR R4 codings and displays their key components.
```C# Snippet:Guidance_Async_Async_Tests_Samples_DisplayCodes
IList<FhirR4Coding> codingList = codeableConcept.Coding;
if (codingList != null)
{
    foreach (FhirR4Coding fhirR4Coding in codingList)
    {
        Console.WriteLine(initialBlank + "Coding: " + fhirR4Coding.Code + ", " + fhirR4Coding.Display + " (" + fhirR4Coding.System + ")");
    }
}
```

## Display Present Guidance Information and Measurements
Below code displays comprehensive guidance information including present values, size measurements, and dimensional data from radiology findings.
```C# Snippet:Guidance_Async_Tests_Samples_DisplayPresentGuidanceInformation
if (guidanceInfo.PresentGuidanceValues != null)
{
    foreach (var value in guidanceInfo.PresentGuidanceValues)
    {
        Console.WriteLine($"     Present Guidance Value: {value}");
    }
}

if (guidanceInfo.Sizes != null)
{
    foreach (var size in guidanceInfo.Sizes)
    {
        if (size.ValueQuantity != null)
        {
            Console.WriteLine("     Size ValueQuantity: ");
            DisplayQuantityOutput(size.ValueQuantity);
        }
        if (size.ValueRange != null)
        {
            if (size.ValueRange.Low != null)
            {
                Console.WriteLine($"     Size ValueRange: min {size.ValueRange.Low}");
            }
            if (size.ValueRange.High != null)
            {
                Console.WriteLine($"     Size ValueRange: max {size.ValueRange.High}");
            }
        }
    }
}

if (guidanceInfo.MaximumDiameterAsInText != null)
{
    Console.WriteLine("     Maximum Diameter As In Text: ");
    DisplayQuantityOutput(guidanceInfo.MaximumDiameterAsInText);
}

if (guidanceInfo.Extension != null)
{
    Console.WriteLine("     Extension: ");
    DisplaySectionInfo(guidanceInfo);
}
```

## Display Quantity Values and Units
Below code outputs the numeric value and unit of measurement from a quantity object. It checks for both components separately since either could be null.
```C# Snippet:Guidance_Async_Tests_Samples_DisplayQuantityOutput
if (quantity.Value != null)
{
    Console.WriteLine($"     Value: {quantity.Value}");
}
if (quantity.Unit != null)
{
    Console.WriteLine($"     Unit: {quantity.Unit}");
}
```

## Display Section Information from Extensions
Below code processes extension data within guidance information, specifically looking for sections and their associated details.
```C# Snippet:Guidance_Async_Tests_Samples_DisplaySectionInfo
if (guidanceInfo.Extension != null)
{
    foreach (var ext in guidanceInfo.Extension)
    {
        if (ext.Url == "section")
        {
            Console.WriteLine("   Section:");
            if (ext.Extension != null)
            {
                foreach (var subextension in ext.Extension)
                {
                    if (subextension.Url != null && subextension.ValueString != null)
                    {
                        Console.WriteLine($"      {subextension.Url}: {subextension.ValueString}");
                    }
                }
            }
        }
    }
}
```