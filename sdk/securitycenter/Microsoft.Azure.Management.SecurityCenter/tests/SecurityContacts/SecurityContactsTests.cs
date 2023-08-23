// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
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
    public class SecurityContactsTests : TestBase
    {
        #region Test setup

        private static string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";
        private const string SecurityContactName = "default"; // The only valid name

        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityCenterClient GetSecurityCenterClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var securityCenterClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityCenterClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityCenterClient>(handlers: handler);

            securityCenterClient.AscLocation = "centralus";
            securityCenterClient.SubscriptionId = SubscriptionId;

            return securityCenterClient;
        }

        #endregion

        #region Security Contacts Tests

        [Fact]
        public async Task SecurityContacts_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var securityContact = await securityCenterClient.SecurityContacts.GetAsync(SecurityContactName);
                ValidateSecurityContact(securityContact);
            }
        }

        [Fact]
        public async Task SecurityContacts_Create()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var contact = new SecurityContact(name: SecurityContactName)
                {
                    Phone = "+214-2754038",
                    Emails = "john@contoso.com;jane@contoso.com",
                    AlertNotifications = new SecurityContactPropertiesAlertNotifications()
                    {
                        State = "On",
                        MinimalSeverity = "Low",
                    },
                    NotificationsByRole = new SecurityContactPropertiesNotificationsByRole()
                    {
                        Roles = new List<string>()
                        {
                            "AccountAdmin",
                            "ServiceAdmin",
                            "Owner",
                            "Contributor",
                        },
                        State =  "Off"
                    }
                };

                var securityContact = await securityCenterClient.SecurityContacts.CreateAsync(SecurityContactName, contact);
                ValidateSecurityContact(securityContact);
            }
        }

        [Fact]
        public void SecurityContacts_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                securityCenterClient.SecurityContacts.Delete(SecurityContactName);
            }
        }

        #endregion

        #region Validations

        private void ValidateSecurityContact(SecurityContact securityContact)
        {
            Assert.NotNull(securityContact);
        }

        #endregion
    }
}
