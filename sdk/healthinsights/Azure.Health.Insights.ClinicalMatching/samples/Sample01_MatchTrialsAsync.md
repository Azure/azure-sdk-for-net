# Get all matching clinical trials for a specific patient
This sample demonstrates how to get all matching clinical trials for a specific patient, together with the associated evidence, based on the given patient's clinical condition and a public clinical trial registry. Trial list should be refined by a certain set of properties, as specified by the user (like trial phase and trial recruitment status).

To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Creating a `ClinicalMatchingClient`

To create a new `ClinicalMatchingClient` to get all matching clinical trials for a specific patient, you need a Cognitive Services or HealthInsights service endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a AzureHealthInsights service API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateClinicalMatchingClientAsync
// Read endpoint and apiKey
string endpoint = TestEnvironment.Endpoint;
string apiKey = TestEnvironment.ApiKey;

var endpointUri = new Uri(endpoint);
var credential = new AzureKeyCredential(apiKey);

// Create ClinicalMatchingClient
ClinicalMatchingClient clinicalMatchingClient = new ClinicalMatchingClient(endpointUri, credential);
```

## Get matching clinical trials for a patient

To get matching clinical trials for a patient, call `MatchTrialsAsync` on an instance of `TrialMatcherData`.  The result is a Long Running operation of type `TrialMatcherResult`.

```C# Snippet:HealthInsightsTrialMatcherCreateTrialMatcherDataAsync
// Create patient
PatientRecord patient1 = new PatientRecord("patient_id")
{
    Info = new PatientInfo
    {
        BirthDate = new System.DateTime(1965, 12, 26),
        Sex = PatientInfoSex.Male
    }
};

// Attach clinical info to the patient
patient1.Info.ClinicalInfo.Add(new ClinicalCodedElement("http://www.nlm.nih.gov/research/umls", "C0006826")
{
    Name = "Malignant Neoplasms",
    Value = "true"
});
patient1.Info.ClinicalInfo.Add(new ClinicalCodedElement("http://www.nlm.nih.gov/research/umls", "C1522449")
{
    Name = "Therapeutic radiology procedure",
    Value = "true"
});
patient1.Info.ClinicalInfo.Add(new ClinicalCodedElement("http://www.nlm.nih.gov/research/umls", "METASTATIC")
{
    Name = "metastatic",
    Value = "true"
});
patient1.Info.ClinicalInfo.Add(new ClinicalCodedElement("http://www.nlm.nih.gov/research/umls", "C1512162")
{
    Name = "Eastern Cooperative Oncology Group",
    Value = "1"
});
patient1.Info.ClinicalInfo.Add(new ClinicalCodedElement("http://www.nlm.nih.gov/research/umls", "C0019693")
{
    Name = "HIV Infections",
    Value = "false"
});
patient1.Info.ClinicalInfo.Add(new ClinicalCodedElement("http://www.nlm.nih.gov/research/umls", "C1300072")
{
    Name = "Tumor stage",
    Value = "2"
});
patient1.Info.ClinicalInfo.Add(new ClinicalCodedElement("http://www.nlm.nih.gov/research/umls", "C0019163")
{
    Name = "Hepatitis B",
    Value = "false"
});
patient1.Info.ClinicalInfo.Add(new ClinicalCodedElement("http://www.nlm.nih.gov/research/umls", "C0018802")
{
    Name = "Congestive heart failure",
    Value = "true"
});
patient1.Info.ClinicalInfo.Add(new ClinicalCodedElement("http://www.nlm.nih.gov/research/umls", "C0019196")
{
    Name = "Hepatitis C",
    Value = "false"
});
patient1.Info.ClinicalInfo.Add(new ClinicalCodedElement("http://www.nlm.nih.gov/research/umls", "C0220650")
{
    Name = "Metastatic malignant neoplasm to brain",
    Value = "true"
});

// Create registry filter
var registryFilters = new ClinicalTrialRegistryFilter();
// Limit the trial to a specific patient condition ("Non-small cell lung cancer")
registryFilters.Conditions.Add("Non-small cell lung cancer");
// Limit the clinical trial to a certain phase, phase 1
registryFilters.Phases.Add(ClinicalTrialPhase.Phase1);
// Specify the clinical trial registry source as ClinicalTrials.Gov
registryFilters.Sources.Add(ClinicalTrialSource.ClinicaltrialsGov);
// Limit the clinical trial to a certain location, in this case California, USA
registryFilters.FacilityLocations.Add(new GeographicLocation("United States") { State = "Arizona", City = "Gilbert" });
// Limit the trial to a specific study type, interventional
registryFilters.StudyTypes.Add(ClinicalTrialStudyType.Interventional);

// Create ClinicalTrial instance and attach the registry filter to it.
var clinicalTrials = new ClinicalTrials();
clinicalTrials.RegistryFilters.Add(registryFilters);

// Create TrialMatcherData with patient and configuration
var Configuration = new TrialMatcherModelConfiguration(clinicalTrials);
var trialMatcherData = new TrialMatcherData(new List<PatientRecord> { patient1 }) { Configuration = Configuration };
```

Call MatchTrialsAsync to submit a trial matching async request and get the matching trials response

```C# Snippet:HealthInsightsClinicalMatchingMatchTrialsAsync
TrialMatcherResults matcherResults = default;
try
{
    // Using ClinicalMatchingClient + MatchTrialsAsync
    Operation<TrialMatcherResults> operation = await clinicalMatchingClient.MatchTrialsAsync(WaitUntil.Completed, trialMatcherData);
    matcherResults = operation.Value;
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    return;
}
```

To view the final results:

```C# Snippet:HealthInsightsTrialMatcherMatchTrialsAsyncViewResults
    // View the match trials (eligible/ineligible)
    foreach (TrialMatcherPatientResult patientResult in matcherResults.Patients)
    {
        Console.WriteLine($"Inferences of Patient {patientResult.Id}");
        foreach (TrialMatcherInference tmInferences in patientResult.Inferences)
        {
            Console.WriteLine($"Trial Id {tmInferences.Id}");
            Console.WriteLine($"Type: {tmInferences.Type.ToString()}  Value: {tmInferences.Value}");
            Console.WriteLine($"Description {tmInferences.Description}");
        }
    }
}
```

<!-- Links -->
[README]:https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/healthinsights/Azure.Health.Insights.ClinicalMatching/README.md
