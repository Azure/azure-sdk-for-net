// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityInsights.Tests.Helpers;
using Xunit;

namespace SecurityInsights.Tests
{
    public class IncidentsTests : TestBase
    {
        #region Test setup

        private static string ResourceGroup = "ndicola-pfsense";
        private static string WorkspaceName = "ndicola-pfsense";

        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityInsightsClient GetSecurityInsightsClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var SecurityInsightsClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityInsightsClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityInsightsClient>(handlers: handler);

            return SecurityInsightsClient;
        }

        #endregion

        #region Incidents

        [Fact]
        public void Incidents_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);

                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(ResourceGroup, WorkspaceName, IncidentId, IncidentBody);
                
                var Incidents = SecurityInsightsClient.Incidents.List(ResourceGroup, WorkspaceName);
                ValidateIncidents(Incidents);
                SecurityInsightsClient.Incidents.Delete(ResourceGroup, WorkspaceName, IncidentId);
            }
        }

        [Fact]
        public void Incidents_CreateorUpdate()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                var Incident = SecurityInsightsClient.Incidents.CreateOrUpdate(ResourceGroup, WorkspaceName, IncidentId, IncidentBody);
                ValidateIncident(Incident);
                SecurityInsightsClient.Incidents.Delete(ResourceGroup, WorkspaceName, IncidentId);
            }
        }

        [Fact]
        public void Incidents_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(ResourceGroup, WorkspaceName, IncidentId, IncidentBody);
                var Incident = SecurityInsightsClient.Incidents.Get(ResourceGroup, WorkspaceName, IncidentId);
                ValidateIncident(Incident);
                SecurityInsightsClient.Incidents.Delete(ResourceGroup, WorkspaceName, IncidentId);

            }
        }

        [Fact]
        public void Incidents_Delete()
        {
            Thread.Sleep(5000);
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(ResourceGroup, WorkspaceName, IncidentId, IncidentBody);
                SecurityInsightsClient.Incidents.Delete(ResourceGroup, WorkspaceName, IncidentId);
            }
        }

        #endregion

        #region Validations

        private void ValidateIncidents(IPage<Incident> Incidentpage)
        {
            Assert.True(Incidentpage.IsAny());

            Incidentpage.ForEach(ValidateIncident);
        }

        private void ValidateIncident(Incident Incident)
        {
            Assert.NotNull(Incident);
        }

        #endregion
    }
}
