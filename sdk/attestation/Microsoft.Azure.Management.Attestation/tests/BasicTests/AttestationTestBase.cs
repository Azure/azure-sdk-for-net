// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using System.Linq;
using Microsoft.Azure.Management.Attestation;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Attestation.Models;
using System.Collections.Generic;
using Microsoft.Azure.Management.ResourceManager.Models;
using Xunit;

namespace Attestation.Management.ScenarioTests
{
    public class AttestationTestBase : TestBase
    {
        private const string TenantIdKey = "TenantId";
        private const string LocationKey = "location";
        private const string SubIdKey = "SubId";

        public string tenantId { get; set; }

        public string location { get; set; }
        public string subscriptionId { get; set; }
        public AttestationManagementClient client { get; set; }
        public ResourceManagementClient resourcesClient { get; set; }

        public string objectIdGuid { get; internal set; }
        public string rgName { get; internal set; }
        public string apiVersion { get; internal set; }

        public Guid tenantIdGuid { get; internal set; }

        public string attestationName { get; internal set; }

        public string attestationPolicy { get; internal set; }

        public AttestationTestBase(MockContext context)
        {
            var testEnv = TestEnvironmentFactory.GetTestEnvironment();

            this.resourcesClient = context.GetServiceClient<ResourceManagementClient>();
            this.client = context.GetServiceClient<AttestationManagementClient>();
            

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                this.tenantId = testEnv.Tenant;
                this.subscriptionId = testEnv.SubscriptionId;
                HttpMockServer.Variables[TenantIdKey] = tenantId;             
                HttpMockServer.Variables[SubIdKey] = subscriptionId;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                tenantId = HttpMockServer.Variables[TenantIdKey];
                subscriptionId = HttpMockServer.Variables[SubIdKey];
            }

            var provider = resourcesClient.Providers.Get("Microsoft.Attestation");
            this.location = provider.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.ResourceType == "attestationProviders")
                    {
                        return true;
                    }
                    return false;
                }
            ).First().Locations.FirstOrDefault();


            Initialize();
        }

        private void Initialize()
        {
            apiVersion = "2018-09-01-preview";
            rgName = TestUtilities.GenerateName("testattestationrg");
            resourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = this.location });

            attestationName = TestUtilities.GenerateName("testattestation");
            attestationPolicy = TestUtilities.GenerateName("attestationpolicynametest");
            tenantIdGuid = Guid.Parse(tenantId);

        }
    }
}