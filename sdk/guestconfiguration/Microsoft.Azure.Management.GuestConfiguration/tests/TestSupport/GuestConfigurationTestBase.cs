// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GuestConfiguration.Tests.Helpers;
using Microsoft.Azure.Management.GuestConfiguration;
using Microsoft.Azure.Management.GuestConfiguration.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using HttpStatusCode = System.Net.HttpStatusCode;

namespace GuestConfiguration.Tests.TestSupport
{
    public class GuestConfigurationTestBase : TestBase, IDisposable
    {
        private const string ResourceGroupName = "GuestConfigSDKTestsForCreateOrUpdate";
        private const string VMName = "automation-sdk-test-account";
        private const string Location = "West Central US";
        private const string GuestConfigurationAssignmentName = "AuditSecureProtocol";

        public GuestConfigurationTestBase(MockContext context)
        {
            var handler = new RecordedDelegatingHandler();
            GuestConfigurationClient = ResourceGroupHelper.GetGuestConfigurationClient(context, handler);
        }

        public GuestConfigurationClient GuestConfigurationClient { get; private set; }

        #region Common Methods

        public void Dispose()
        {
            GuestConfigurationClient.Dispose();
        }

        #endregion
    }
}