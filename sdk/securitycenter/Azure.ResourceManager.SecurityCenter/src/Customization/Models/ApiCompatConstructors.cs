// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591, SA1402

using System;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public abstract partial class CustomAlertRule
    {
        protected CustomAlertRule(bool isEnabled) : this(isEnabled, default) { }
    }

    public partial class OnPremiseSqlResourceDetails
    {
        public OnPremiseSqlResourceDetails(ResourceIdentifier workspaceId, Guid vmuuid, string sourceComputerId, string machineName, string serverName, string databaseName)
            : this(workspaceId, vmuuid.ToString(), sourceComputerId, machineName, serverName, databaseName)
        {
        }
    }

    public partial class SecuritySolutionsReferenceData
    {
        public SecuritySolutionsReferenceData(SecurityFamily securityFamily, string alertVendorName, Uri packageInfoUri, string productName, string publisher, string template, string title)
        {
            throw new NotSupportedException("This constructor is preserved for compatibility with a previous SecurityCenter API surface.");
        }
    }
}
