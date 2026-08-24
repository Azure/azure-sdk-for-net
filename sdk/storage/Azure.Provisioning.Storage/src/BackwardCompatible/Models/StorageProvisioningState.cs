// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace Azure.Provisioning.Storage;

// TypeSpec splits this shared enum into resource-specific enums. Preserve the shipped type,
// members, and ordinal order for StorageAccount and StorageTaskAssignmentProperties.
/// <summary>
/// Gets the status of the storage account at the time the operation was called.
/// </summary>
public enum StorageProvisioningState
{
    /// <summary>
    /// Creating.
    /// </summary>
    Creating,

    /// <summary>
    /// ResolvingDNS.
    /// </summary>
    [DataMember(Name = "ResolvingDNS")]
    ResolvingDns,

    /// <summary>
    /// Succeeded.
    /// </summary>
    Succeeded,

    /// <summary>
    /// ValidateSubscriptionQuotaBegin.
    /// </summary>
    ValidateSubscriptionQuotaBegin,

    /// <summary>
    /// ValidateSubscriptionQuotaEnd.
    /// </summary>
    ValidateSubscriptionQuotaEnd,

    /// <summary>
    /// Deleting.
    /// </summary>
    Deleting,

    /// <summary>
    /// Canceled.
    /// </summary>
    Canceled,

    /// <summary>
    /// Failed.
    /// </summary>
    Failed,
}
