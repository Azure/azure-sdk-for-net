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
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Test;
using Microsoft.Azure.Management.SiteRecovery;
using System.Net;
using System.Web;
using Xunit;
using Microsoft.Azure.Management.SiteRecovery.Models;


namespace SiteRecovery.Tests
{
    public class AlertsTests : SiteRecoveryTestsBase
    {
        private const string RecoveryservicePrefix = "RecoveryServices";

        public void ConfigureAlertSettingsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var getAlertsResponse = client.AlertSettings.List(RequestHeaders);
                Assert.NotNull(getAlertsResponse);
                Assert.NotEmpty(getAlertsResponse.Alerts);

                var emailAddresses = new List<string>();
                emailAddresses.Add("employee@contoso.com");
                var configureResponse = client.AlertSettings.Configure(
                    getAlertsResponse.Alerts[0].Name,
                    new ConfigureAlertSettingsRequest
                    {
                        Properties = new ConfigureAlertSettingsRequestProperties
                        {
                            CustomEmailAddresses = emailAddresses,
                            Locale = "en-us",
                            SendToOwners = "Send"
                        }
                    },
                    RequestHeaders);
                Assert.NotNull(configureResponse);
                Assert.NotNull(configureResponse.Alert);
                Assert.Equal(HttpStatusCode.OK, configureResponse.StatusCode);
                Assert.Equal("Send", configureResponse.Alert.Properties.SendToOwners);
                Assert.Equal("en-us", configureResponse.Alert.Properties.Locale);
                Assert.NotEmpty(configureResponse.Alert.Properties.CustomEmailAddresses);
            }
        }

        public void UnconfigureAlertSettingsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var getAlertsResponse = client.AlertSettings.List(RequestHeaders);
                Assert.NotNull(getAlertsResponse);
                Assert.NotEmpty(getAlertsResponse.Alerts);

                var configureResponse = client.AlertSettings.Configure(
                    getAlertsResponse.Alerts[0].Name,
                    new ConfigureAlertSettingsRequest
                    {
                        Properties = new ConfigureAlertSettingsRequestProperties
                        {
                            CustomEmailAddresses = new List<string>(),
                            Locale = string.Empty,
                            SendToOwners = "DoNotSend"
                        }
                    },
                    RequestHeaders);
                Assert.NotNull(configureResponse);
                Assert.NotNull(configureResponse.Alert);
                Assert.Equal(HttpStatusCode.OK, configureResponse.StatusCode);
                Assert.Equal("DoNotSend", configureResponse.Alert.Properties.SendToOwners);
                Assert.Equal(string.Empty, configureResponse.Alert.Properties.Locale);
                Assert.Empty(configureResponse.Alert.Properties.CustomEmailAddresses);
            }
        }
    }
}
