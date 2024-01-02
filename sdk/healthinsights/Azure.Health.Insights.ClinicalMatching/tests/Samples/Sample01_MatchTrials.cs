// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Health.Insights.ClinicalMatching;
using Azure.Health.Insights.ClinicalMatching.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Extensions.ObjectPool;
using NUnit.Framework;

namespace Azure.Health.Insights.ClinicalMatching.Tests.Samples
{
    public partial class HealthInsightsSamples : SamplesBase<HealthInsightsTestEnvironment>
    {
        [Test]
        public void MatchTrials()
        {
            #region Snippet:CreateClinicalMatchingClient

            // Read endpoint and apiKey
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var endpointUri = new Uri(endpoint);
            var credential = new AzureKeyCredential(apiKey);

            // Create ClinicalMatchingClient
            ClinicalMatchingClient clinicalMatchingClient = new ClinicalMatchingClient(endpointUri, credential);

            #endregion

            #region Snippet:HealthInsightsTrialMatcherCreateTrialMatcherData
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
            #endregion

            #region Snippet:HealthInsightsClinicalMatchingMatchTrials
            TrialMatcherResults matcherResults = default;
            try
            {
                // Using ClinicalMatchingClient + MatchTrials
                Operation<TrialMatcherResults> operation = clinicalMatchingClient.MatchTrials(WaitUntil.Completed, trialMatcherData);
                matcherResults = operation.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            #endregion

            #region Snippet:HealthInsightsTrialMatcherMatchTrialsViewResults
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

        #endregion
    }
}
