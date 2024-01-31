// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
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

            return securityCenterClient;
        }

        #endregion

        #region Security Contacts Tests

        [Fact]
        public void SecurityContacts_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var securityContacts = securityCenterClient.SecurityContacts.List();
                ValidateSecurityContacts(securityContacts);
            }
        }

        [Fact]
        public void SecurityContacts_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var securityContact = securityCenterClient.SecurityContacts.Get("default");
                ValidateSecurityContact(securityContact);
            }
        }

        [Fact]
        public void SecurityContacts_Create()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);

                var contact = new SecurityContact("Off", "", "", "barbra@contoso.com", "", new SecurityContactPropertiesAlertNotifications(), new SecurityContactPropertiesNotificationsByRole());

                var securityContact = securityCenterClient.SecurityContacts.Create("default", contact);
                ValidateSecurityContact(securityContact);
            }
        }

        [Fact]
        public void SecurityContacts_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                securityCenterClient.SecurityContacts.Delete("default");
            }
        }

        #endregion

        #region Validations

        private void ValidateSecurityContacts(IList<SecurityContact> securityContactPage)
        {
            Assert.True(securityContactPage.IsAny());

            securityContactPage.ForEach(ValidateSecurityContact);
        }

        private void ValidateSecurityContact(SecurityContact securityContact)
        {
            Assert.NotNull(securityContact);
        }

        #endregion
    }
}
