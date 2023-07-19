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
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class IncidentsTests : TestBase
    {
        #region Test setup

        #endregion

        #region Incidents

        [Fact]
        public void Incidents_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);

                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentBody);
                
                var Incidents = SecurityInsightsClient.Incidents.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateIncidents(Incidents);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
            }
        }

        [Fact]
        public void Incidents_CreateorUpdate()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                var Incident = SecurityInsightsClient.Incidents.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentBody);
                ValidateIncident(Incident);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
            }
        }

        [Fact]
        public void Incidents_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentBody);
                var Incident = SecurityInsightsClient.Incidents.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
                ValidateIncident(Incident);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);

            }
        }

        [Fact]
        public void Incidents_Delete()
        { 
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentBody);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
            }
        }

        [Fact]
        public void IncidentAlerts_ListAlerts()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentBody);
                var IncidentAlerts = SecurityInsightsClient.Incidents.ListAlerts(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
                ValidateIncidentAlerts(IncidentAlerts);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);

            }
        }

        [Fact]
        public void IncidentBookmarks_ListAlerts()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentBody);
                var IncidentBookmarks = SecurityInsightsClient.Incidents.ListBookmarks(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
                ValidateIncidentBookmarks(IncidentBookmarks);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);

            }
        }

        [Fact]
        public void IncidentEntities_ListAlerts()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentBody);
                var IncidentEntities = SecurityInsightsClient.Incidents.ListEntities(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
                ValidateIncidentEntities(IncidentEntities);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);

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

        private void ValidateIncidentTeam(TeamInformation TeamInformation)
        {
            Assert.NotNull(TeamInformation);
        }

        private void ValidateIncidentAlerts(IncidentAlertList incidentAlertList)
        {
            Assert.NotNull(incidentAlertList);
        }

        private void ValidateIncidentBookmarks(IncidentBookmarkList IncidentBookmarkList)
        {
            Assert.NotNull(IncidentBookmarkList);
        }

        private void ValidateIncidentEntities(IncidentEntitiesResponse IncidentEntitiesResponse)
        {
            Assert.NotNull(IncidentEntitiesResponse);
        }

        #endregion
    }
}
