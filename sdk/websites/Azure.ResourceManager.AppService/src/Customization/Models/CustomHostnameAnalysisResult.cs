// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.AppService.Models
{
    public partial class CustomHostnameAnalysisResult
    {
        // Remove this customization when this issue is fixed: https://github.com/Azure/autorest.csharp/issues/4798
        /// <summary> Raw failure information if DNS verification fails. </summary>
        [WirePath("properties.customDomainVerificationFailureInfo")]
        public ResponseError CustomDomainVerificationFailureInfo { get; }
    }
}
