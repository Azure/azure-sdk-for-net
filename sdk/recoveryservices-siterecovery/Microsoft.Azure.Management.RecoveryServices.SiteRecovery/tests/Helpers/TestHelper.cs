// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace RecoveryServices.SiteRecovery.Tests
{
    public class TestHelper : IDisposable
    {
        private const string resourceNamespace = "Microsoft.RecoveryServices";
        private const string resourceGroupName = "Arpita-air";
        private const string vaultName = "h2atest";
        private const string location = "westus";

        public SiteRecoveryManagementClient SiteRecoveryClient { get; private set; }

        public void Initialize(MockContext context)
        {
            this.SiteRecoveryClient = this.GetSiteRecoveryClient(context);
            this.SiteRecoveryClient.ResourceGroupName = resourceGroupName;
            this.SiteRecoveryClient.ResourceName = vaultName;
        }

        public void Initialize(MockContext context, string rgName, string vault)
        {
            this.SiteRecoveryClient = this.GetSiteRecoveryClient(context);
            this.SiteRecoveryClient.ResourceGroupName = rgName;
            this.SiteRecoveryClient.ResourceName = vault;
        }

        public void Dispose()
        {
            SiteRecoveryClient.Dispose();
        }
    }
}