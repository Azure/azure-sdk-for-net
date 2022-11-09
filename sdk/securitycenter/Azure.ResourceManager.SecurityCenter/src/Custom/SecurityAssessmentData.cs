// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary> A class representing the SecurityAssessment data model. </summary>
    [CodeGenSuppress("LinksAzurePortalUri")]
    public partial class SecurityAssessmentData : ResourceData
    {
        /// <summary> Link to assessment in Azure Portal. </summary>
        public Uri AzurePortalUri
        {
            get => Links?.AzurePortalUri;
        }
    }
}
