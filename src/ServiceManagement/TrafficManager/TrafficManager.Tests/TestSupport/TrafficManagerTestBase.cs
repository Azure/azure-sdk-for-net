//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.TrafficManager.Models;
using Microsoft.WindowsAzure.Management.WebSites;
using Microsoft.WindowsAzure.Management.WebSites.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Testing;

namespace Microsoft.WindowsAzure.Management.TrafficManager.Testing
{
    public class TrafficManagerTestBase : TestBase, IDisposable
    {
        private const string TrafficManagerNamingExtension = ".trafficmanager.net";
        private const string WebsiteNamingExtension = ".azurewebsites.net";
        private const string CloudServiceNamingExtension = ".cloudapp.net";

        private const string WebsiteGeoRegion = "East US";
        private const string WebsiteServerFarmName = "DefaultServerFarm";
        private const string WebsitePlanName = "VirtualDedicatedPlan";
        private const string WebSpaceName = "eastuswebspace";

        //needed for test artifacts cleaning up
        private const string TestArtifactsNamePrefix = "ATMTest";
        private object _syncObject = new object();
        private StringCollection _profilesToCleanup = new StringCollection();
        private StringCollection _servicesToCleanup = new StringCollection();
        private StringCollection _websitesToCleanup = new StringCollection();

        public TrafficManagerTestBase()
        {
            TrafficManagerClient = GetServiceClient<TrafficManagerManagementClient>();
            ComputeManagementClient = GetServiceClient<ComputeManagementClient>();
            WebsiteManagementClient = GetServiceClient<WebSiteManagementClient>();
            ManagementClient = GetServiceClient<ManagementClient>();
        }

        public TrafficManagerManagementClient TrafficManagerClient { get; private set; }
        public ComputeManagementClient ComputeManagementClient { get; private set; }
        public WebSiteManagementClient WebsiteManagementClient { get; private set; }
        public ManagementClient ManagementClient { get; private set; }

        public string CreateTestProfile()
        {
            string testDomainName = GenerateRandomName(TestArtifactType.TrafficManagerDomain);
            return CreateTestProfile(testDomainName);
        }

        public string CreateTestProfile(string domainName)
        {
            string testProfileName = GenerateRandomName(TestArtifactType.Profile);

            TrafficManagerClient.Profiles.Create(testProfileName, domainName);
            RegisterToCleanup(testProfileName, _profilesToCleanup);
            return testProfileName;
        }

        public string CreateTestCloudService()
        {
            bool validServiceNameFound = false;
            string serviceName;
            do
            {
                serviceName = GenerateRandomName(TestArtifactType.CloudService);
                HostedServiceCheckNameAvailabilityResponse nameCheckResponse = ComputeManagementClient.HostedServices.CheckNameAvailability(serviceName);
                validServiceNameFound = nameCheckResponse.IsAvailable;
            }
            while (!validServiceNameFound);

            Compute.Models.HostedServiceCreateParameters parameter = new Compute.Models.HostedServiceCreateParameters();
            parameter.ServiceName = serviceName;
            parameter.Location = ManagementTestUtilities.GetDefaultLocation(ManagementClient, "Compute");
            parameter.Label = serviceName;
            parameter.Description = serviceName;
            AzureOperationResponse response = ComputeManagementClient.HostedServices.Create(parameter);
            RegisterToCleanup(serviceName, _servicesToCleanup);

            return serviceName + CloudServiceNamingExtension;
        }

        public string CreateTestWebsite()
        {
            CreateTestServerFarmIfNeeded();
            string websiteName = CreateWebsite();
            SetWebsiteToStandard(websiteName);
            return websiteName + WebsiteNamingExtension;
        }

        private void CreateTestServerFarmIfNeeded()
        {
            WebHostingPlanCreateParameters parameter = new WebHostingPlanCreateParameters();
            parameter.Name = WebsiteServerFarmName;
            parameter.NumberOfWorkers = 2;
            parameter.WorkerSize = WorkerSizeOptions.Medium;

            try
            {
                WebsiteManagementClient.WebHostingPlans.Create(WebSpaceName, parameter);
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    Console.WriteLine("A server farm already exists. Continuing.");
                }
                else
                {
                    throw;
                }
            }
        }

        private string CreateWebsite()
        {
            bool validWebsiteNameFound = false;
            string websiteName;
            do
            {
                websiteName = GenerateRandomName(TestArtifactType.Website);
                WebSiteIsHostnameAvailableResponse nameCheckResponse = WebsiteManagementClient.WebSites.IsHostnameAvailable(websiteName);
                validWebsiteNameFound = nameCheckResponse.IsAvailable;
            }
            while (!validWebsiteNameFound);

            WebSiteCreateParameters parameter = new WebSiteCreateParameters();
            parameter.Name = websiteName;
            parameter.ServerFarm = WebsiteServerFarmName;
            parameter.WebSpace = new WebSiteCreateParameters.WebSpaceDetails()
            {
                GeoRegion = WebsiteGeoRegion,
                Name = WebSpaceName,
                Plan = WebsitePlanName
            };

            this.WebsiteManagementClient.WebSites.Create(WebSpaceName, parameter);

            RegisterToCleanup(websiteName, _websitesToCleanup);
            return websiteName;
        }

        private void SetWebsiteToStandard(string websiteName)
        {
            WebSiteUpdateParameters updateParameters = new WebSiteUpdateParameters();
            updateParameters.ServerFarm = WebsiteServerFarmName;
            updateParameters.HostNames = this.GetWebsiteHostNames(websiteName);
            WebsiteManagementClient.WebSites.Update(WebSpaceName, websiteName, updateParameters);
        }

        private IList<String> GetWebsiteHostNames(string websiteName)
        {
            WebSiteGetResponse response = WebsiteManagementClient.WebSites.Get(WebSpaceName, websiteName, new WebSiteGetParameters
            {
                PropertiesToInclude = { "HostNames" }
            });
            return response.WebSite.HostNames;
        }

        private void RegisterToCleanup(string artifactName, StringCollection cleanupList)
        {
            lock (_syncObject)
            {
                cleanupList.Add(artifactName);
            }
        }

        public void CreateADefinitionAndEnableTheProfile(
            string profileName,
            string domain,
            EndpointType endpointType,
            LoadBalancingMethod testMethod = LoadBalancingMethod.Performance)
        {
            DefinitionEndpointCreateParameters endpointParameter = new DefinitionEndpointCreateParameters();
            endpointParameter.DomainName = domain;
            endpointParameter.Status = EndpointStatus.Enabled;
            endpointParameter.Type = endpointType;

            CreateADefinitionAndEnableTheProfile(profileName, LoadBalancingMethod.Performance, endpointParameter);
        }

        public void CreateADefinitionAndEnableTheProfile(
            string profileName,
            LoadBalancingMethod loadBalancingMethod,
            DefinitionEndpointCreateParameters endpointParameter)
        {
            CreateADefinitionAndEnableTheProfile(
                profileName,
                loadBalancingMethod,
                new List<DefinitionEndpointCreateParameters>() { endpointParameter });
        }

        public void CreateADefinitionAndEnableTheProfile(
            string profileName,
            LoadBalancingMethod loadBalancingMethod,
            IList<DefinitionEndpointCreateParameters> endpoints)
        {
            DefinitionCreateParameters definitionParameter = new DefinitionCreateParameters();
            DefinitionMonitor monitor = new DefinitionMonitor();
            DefinitionDnsOptions dnsOption = new DefinitionDnsOptions();
            DefinitionPolicyCreateParameters policyParameter = new DefinitionPolicyCreateParameters();
            DefinitionMonitorHTTPOptions monitorHttpOption = new DefinitionMonitorHTTPOptions();

            definitionParameter.DnsOptions = dnsOption;
            definitionParameter.Policy = policyParameter;
            definitionParameter.Monitors.Add(monitor);
            monitor.HttpOptions = monitorHttpOption;

            dnsOption.TimeToLiveInSeconds = 30;

            monitorHttpOption.RelativePath = "/randomFile.aspx";
            monitorHttpOption.Verb = "GET";
            monitorHttpOption.ExpectedStatusCode = (int)HttpStatusCode.OK;

            monitor.Protocol = DefinitionMonitorProtocol.Http;
            //Set fixed values required by services   
            monitor.IntervalInSeconds = 30;
            monitor.TimeoutInSeconds = 10;
            monitor.ToleratedNumberOfFailures = 3;
            monitor.Port = 80;

            policyParameter.LoadBalancingMethod = loadBalancingMethod;
            policyParameter.Endpoints = endpoints;

            TrafficManagerClient.Definitions.Create(profileName, definitionParameter);
        }

        public string GenerateRandomDomainName()
        {
            return GenerateRandomName(TestArtifactType.TrafficManagerDomain);
        }

        private string GenerateRandomName(TestArtifactType artifact)
        {
            string name = HttpMockServer.GetAssetName(TestUtilities.GetCurrentMethodName(3), TestArtifactsNamePrefix);
            if (artifact == TestArtifactType.TrafficManagerDomain)
            {
                name = name + TrafficManagerNamingExtension;
            }

            return name;
        }

        public void Dispose()
        {
            Cleanup();
        }

        private void Cleanup()
        {
            foreach (string profile in _profilesToCleanup)
            {
                try
                {
                    TrafficManagerClient.Profiles.Delete(profile);
                }
                catch { }
            }

            foreach (string service in _servicesToCleanup)
            {
                try
                {
                    ComputeManagementClient.HostedServices.Delete(service);
                }
                catch { }
            }

            foreach (string website in _websitesToCleanup)
            {
                try
                {
                    WebSiteDeleteParameters deleteParams = new WebSiteDeleteParameters();
                    deleteParams.DeleteEmptyServerFarm = true;
                    deleteParams.DeleteMetrics = true;
                    deleteParams.DeleteAllSlots = true;
                    WebsiteManagementClient.WebSites.Delete(WebSpaceName, website, deleteParams);
                }
                catch { }
            }

            TrafficManagerClient.Dispose();
            ComputeManagementClient.Dispose();
            ManagementClient.Dispose();
        }

        private enum TestArtifactType
        {
            Profile,
            Definition,
            TrafficManagerDomain,
            CloudService,
            Website
        }
    }
}
