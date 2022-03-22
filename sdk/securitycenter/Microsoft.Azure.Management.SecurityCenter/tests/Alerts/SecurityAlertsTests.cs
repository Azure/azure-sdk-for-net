// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using Xunit;

namespace SecurityCenter.Tests
{
    public class SecurityAlertsTests : TestBase
    {
        #region Test setup

        private const string _ascLocation = "westeurope";

        private static string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";

        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityCenterClient GetSecurityCenterClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
                TestEnvironment.SubscriptionId = SubscriptionId;
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var securityCenterClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityCenterClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityCenterClient>(handlers: handler);

            return securityCenterClient;
        }

        #endregion

        #region Alerts

        [Fact]
        public void SecurityAlerts_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var alerts = securityCenterClient.Alerts.List();
                ValidateAlerts(alerts);
            }
        }

        [Fact]
        public async Task SecurityAlerts_GetResourceGroupLevelAlerts()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);

                var alerts = await securityCenterClient.Alerts.ListAsync();
                ValidateAlerts(alerts);
                
                var firstAlert = alerts.First();
				var alertLocation = GetAlertLocation(firstAlert.Id);
                var alertName = firstAlert.Name;
                var resourceGroupName = Regex.Match(firstAlert.Id, @"(?<=resourceGroups/)[^/]+?(?=/)").Value;

                //var foundAlert = await clientWithLocation.Alerts.GetResourceGroupLevelAlertsAsync(alertName, resourceGroupName);
                var foundAlert = await securityCenterClient.Alerts.GetResourceGroupLevelAsync(alertLocation, alertName, resourceGroupName);
                ValidateAlert(foundAlert);
            }
        }

        [Fact]
        public async Task SecurityAlerts_GetSubscriptionLevelAlert()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);

                var alerts = await securityCenterClient.Alerts.ListAsync();
                ValidateAlerts(alerts);

                var firstAlert = alerts.First();
                var alertLocation = GetAlertLocation(firstAlert.Id);
                
                var alert = securityCenterClient.Alerts.GetSubscriptionLevel(alertLocation, firstAlert.Name);

                ValidateAlert(alert);
            }
        }

        private string GetAlertLocation(string id)
        {
            return Regex.Match(id, @"(?<=locations/)[^/]+?(?=/)").Value;
        }

        [Fact]
        public async Task SecurityAlerts_ListByResourceGroup()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var alerts = await securityCenterClient.Alerts.ListAsync();
                ValidateAlerts(alerts);

                var rgAlerts = securityCenterClient.Alerts.ListByResourceGroup(Regex.Match(alerts.First().Id, @"(?<=resourceGroups/)[^/]+?(?=/)").Value);
                ValidateAlerts(rgAlerts);
            }
        }

        [Fact]
        public async Task SecurityAlerts_ListResourceGroupLevelAlertsByRegion()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var alerts = await securityCenterClient.Alerts.ListAsync();
                var enumerator = alerts.GetEnumerator();
                enumerator.MoveNext();

                while (!enumerator.Current.Id.Contains("resourceGroups") && enumerator.MoveNext()) ;

                var location = Regex.Match(enumerator.Current.Id, @"(?<=locations/)[^/]+?(?=/)").Value;
                //var rgAlerts = securityCenterClient.Alerts.ListResourceGroupLevelAlertsByRegion(Regex.Match(enumerator.Current.Id, @"(?<=resourceGroups/)[^/]+?(?=/)").Value);
                var rgAlerts = securityCenterClient.Alerts.ListResourceGroupLevelByRegion(location, Regex.Match(enumerator.Current.Id, @"(?<=resourceGroups/)[^/]+?(?=/)").Value);
                ValidateAlerts(rgAlerts);
            }
        }

        [Fact]
        public async Task SecurityAlerts_ListSubscriptionLevelAlertsByRegion()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var alerts = await securityCenterClient.Alerts.ListAsync();
                ValidateAlerts(alerts);

                var location = Regex.Match(alerts.First().Id, @"(?<=locations/)[^/]+?(?=/)").Value;

                //var regionAlerts = securityCenterClient.Alerts.ListSubscriptionLevelAlertsByRegion();
                var regionAlerts = securityCenterClient.Alerts.ListSubscriptionLevelByRegion(location);
                ValidateAlerts(regionAlerts);
            }
        }

        [Fact]
        public async Task SecurityAlerts_UpdateResourceGroupLevelAlertState()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var alerts = await securityCenterClient.Alerts.ListAsync();
                ValidateAlerts(alerts);

                var location = Regex.Match(alerts.First().Id, @"(?<=locations/)[^/]+?(?=/)").Value;

                //securityCenterClient.Alerts.UpdateResourceGroupLevelAlertStateToDismiss(alerts.First().Name, Regex.Match(alerts.First().Id, @"(?<=resourceGroups/)[^/]+?(?=/)").Value);
                securityCenterClient.Alerts.UpdateResourceGroupLevelStateToDismiss(location, alerts.First().Name, Regex.Match(alerts.First().Id, @"(?<=resourceGroups/)[^/]+?(?=/)").Value);
            }
        }

        [Fact]
        public async Task SecurityAlerts_UpdateSubscriptionLevelAlertState()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var alerts = await securityCenterClient.Alerts.ListAsync();
                ValidateAlerts(alerts);

                var location = Regex.Match(alerts.First().Id, @"(?<=locations/)[^/]+?(?=/)").Value;

                //securityCenterClient.Alerts.UpdateSubscriptionLevelAlertStateToDismiss(alerts.First().Name);
                securityCenterClient.Alerts.UpdateSubscriptionLevelStateToDismiss(location, alerts.First().Name);
            }
        }

        [Fact]
        public async Task SecurityAlerts_SimulateAlert()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                await securityCenterClient.Alerts.SimulateAsync(
                    "centralus", 
                    new AlertSimulatorRequestProperties(
                        new Dictionary<string, object>{
                            { "kind", "Bundles"},
                            { "bundles", new List<string> { "StorageAccounts" } }
                        }));

                // Assert
                // No exception
            }
        }

        #endregion

        #region Validations

        private void ValidateAlerts(IPage<Alert> alertPage)
        {
            Assert.True(alertPage.IsAny());

            alertPage.ForEach(ValidateAlert);
        }

        private void ValidateAlert(Alert alert)
        {
            Assert.NotNull(alert);
        }

        #endregion
    }
}
