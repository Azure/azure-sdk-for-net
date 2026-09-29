// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Azure.Provisioning.Storage;

// TypeSpec splits this shipped enum into account- and task-assignment-specific enums; retain the combined type for compatibility.
/// <summary> Gets the status of the storage account at the time the operation was called. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is obsoleted and will be removed in a future version. Please use StorageAccountProvisioningState or StorageTaskAssignmentProvisioningState instead.")]
public enum StorageProvisioningState
{
    /// <summary>
    /// Creating.
    /// </summary>
    Creating = 0,

    /// <summary>
    /// ResolvingDNS.
    /// </summary>
    [DataMember(Name = "ResolvingDNS")]
    ResolvingDns = 1,

    /// <summary>
    /// Succeeded.
    /// </summary>
    Succeeded = 2,

    /// <summary>
    /// ValidateSubscriptionQuotaBegin.
    /// </summary>
    ValidateSubscriptionQuotaBegin = 3,

    /// <summary>
    /// ValidateSubscriptionQuotaEnd.
    /// </summary>
    ValidateSubscriptionQuotaEnd = 4,

    /// <summary>
    /// Deleting.
    /// </summary>
    Deleting = 5,

    /// <summary>
    /// Canceled.
    /// </summary>
    Canceled = 6,

    /// <summary>
    /// Failed.
    /// </summary>
    Failed = 7,
}
