// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Batch.Models
{
    /// <summary> Which user accounts on the compute node should have access to the private data of the certificate. </summary>
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum BatchCertificateVisibility
    {
        /// <summary> The certificate should be visible to the user account under which the start task is run. </summary>
        StartTask = 0,
        /// <summary> The certificate should be visible to the user accounts under which job tasks are run. </summary>
        Task = 1,
        /// <summary> The certificate should be visible to the user accounts under which users remotely access the node. </summary>
        RemoteUser = 2,
    }
}
