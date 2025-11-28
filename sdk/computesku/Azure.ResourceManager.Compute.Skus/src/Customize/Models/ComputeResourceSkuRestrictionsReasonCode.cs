// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Compute.Skus;

namespace Azure.ResourceManager.Compute.Models
{
    // because enum types do not support partial therefore we can only move everything in the enum here in order to change its namespace
    /// <summary> The reason for restriction. </summary>
    [CodeGenType("ComputeResourceSkuRestrictionsReasonCode")]
    public enum ComputeResourceSkuRestrictionsReasonCode
    {
        /// <summary> QuotaId. </summary>
        QuotaId,
        /// <summary> NotAvailableForSubscription. </summary>
        NotAvailableForSubscription
    }
}
