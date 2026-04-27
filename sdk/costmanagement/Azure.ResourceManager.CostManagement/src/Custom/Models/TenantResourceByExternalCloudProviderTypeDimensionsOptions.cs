// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.CostManagement.Models
{
    // Backward-compat: the baseline use this option-bag type TenantResourceExtensions.ByExternalCloudProviderTypeDimensions(..., TenantResourceByExternalCloudProviderTypeDimensionsOptions options, ...)
    /// <summary> Options bag for the backward-compatible ByExternalCloudProviderTypeDimensions overload. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class TenantResourceByExternalCloudProviderTypeDimensionsOptions
    {
        /// <summary> Initializes a new instance of <see cref="TenantResourceByExternalCloudProviderTypeDimensionsOptions"/>. </summary>
        /// <param name="externalCloudProviderType"> The external cloud provider type. </param>
        /// <param name="externalCloudProviderId"> The external cloud provider ID. </param>
        public TenantResourceByExternalCloudProviderTypeDimensionsOptions(ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId)
        {
            ExternalCloudProviderType = externalCloudProviderType;
            ExternalCloudProviderId = externalCloudProviderId;
        }

        /// <summary> The external cloud provider type. </summary>
        public ExternalCloudProviderType ExternalCloudProviderType { get; }
        /// <summary> The external cloud provider ID. </summary>
        public string ExternalCloudProviderId { get; }
        /// <summary> May be used to filter dimensions by properties/category, properties/usageStart, properties/usageEnd. </summary>
        public string Filter { get; set; }
        /// <summary> May be used to expand the properties/data within a dimension category. </summary>
        public string Expand { get; set; }
        /// <summary> Skiptoken is only used if a previous operation returned a partial result. </summary>
        public string Skiptoken { get; set; }
        /// <summary> May be used to limit the number of results to the most recent N dimension data. </summary>
        public int? Top { get; set; }
    }
}
