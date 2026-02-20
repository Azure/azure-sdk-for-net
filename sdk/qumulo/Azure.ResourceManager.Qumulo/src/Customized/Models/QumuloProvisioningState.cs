// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Qumulo.Models
{
    /// <summary> The QumuloProvisioningState. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum QumuloProvisioningState
    {
        /// <summary> NotSpecified. </summary>
        NotSpecified,
        /// <summary> Accepted. </summary>
        Accepted,
        /// <summary> Creating. </summary>
        Creating,
        /// <summary> Updating. </summary>
        Updating,
        /// <summary> Deleting. </summary>
        Deleting,
        /// <summary> Succeeded. </summary>
        Succeeded,
        /// <summary> Failed. </summary>
        Failed,
        /// <summary> Canceled. </summary>
        Canceled,
        /// <summary> Deleted. </summary>
        Deleted
    }
}
