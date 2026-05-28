// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TrafficManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.TrafficManager.Tests
{
    public abstract class ProfileTestBase : TrafficManagerManagementTestBase
    {
        protected internal const string ExpectedKey = "tagKey";
        protected internal const string ExpectedValue = "tagValue";
        protected internal const string EndpointName1 = "endpoint1";
        protected internal const string EndpointName2 = "endpoint2";
        protected internal const string EndpointTypeName = "externalEndpoints";
        protected internal const string EndpointType = "Microsoft.Network/trafficManagerProfiles/" + EndpointTypeName;

        protected internal SubscriptionResource _subscription;
        protected internal TrafficManagerProfileCollection _profileCollection;
        protected internal ResourceGroupResource _resourceGroup;
        protected internal string _profileName;

        protected ProfileTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ProfileTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        /// <summary>
        /// The method creates a traffic manager profile, so it covers the creation use-case.
        /// </summary>
        /// <returns>A task to wait for.</returns>
        [SetUp]
        public async Task Setup()
        {
            _profileName = Recording.GenerateAssetName("profileName");
            _subscription = await Client.GetDefaultSubscriptionAsync();

            _resourceGroup = await CreateResourceGroup(
                _subscription,
                "resourceGroupName",
                AzureLocation.EastUS);

            _profileCollection = _resourceGroup.GetTrafficManagerProfiles();

            TrafficManagerProfileData profileData = new TrafficManagerProfileData
            {
                Name = _profileName,
                Location = "global",
                TrafficRoutingMethod = TrafficRoutingMethod.Weighted,
                DnsConfig = new TrafficManagerDnsConfig { RelativeName = _profileName },
                MonitorConfig = new TrafficManagerMonitorConfig { Port = 80, Protocol = TrafficManagerMonitorProtocol.Http, Path = "/public/health-probe" }
            };

            profileData.Endpoints.Add(
                 new TrafficManagerEndpointData
                 {
                     Name = EndpointName1,
                     Target = "az-int-black.int.microsoftmetrics.com",
                     Weight = 1000,
                     ResourceType = EndpointType
                 });

            profileData.Endpoints.Add(
                 new TrafficManagerEndpointData
                 {
                     Name = EndpointName2,
                     Target = "az-int-red.int.microsoftmetrics.com",
                     Weight = 1,
                     ResourceType = EndpointType
                 });

            await _profileCollection.CreateOrUpdateAsync(WaitUntil.Completed, _profileName, profileData);
        }

        /// <summary>
        /// The method creates a traffic manager profile, so it covers the deletion use-case.
        /// </summary>
        /// <returns>A task to wait for.</returns>
        [TearDown]
        public async Task TearDown()
        {
            TrafficManagerProfileResource profileResource =
                new TrafficManagerProfileResource(
                    Client,
                    TrafficManagerProfileResource.CreateResourceIdentifier(
                        _subscription.Data.SubscriptionId,
                        _resourceGroup.Data.Name,
                        _profileName));

            await profileResource.DeleteAsync(WaitUntil.Completed);

            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        protected internal async Task<TrafficManagerProfileResource> GetDefaultProfile() => await _profileCollection.GetAsync(_profileName);
    }
}
