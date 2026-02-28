// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Batch.Models;

namespace Azure.ResourceManager.Batch
{
    public partial class BatchAccountPoolData
    {
        /// <summary> Determines how a pool communicates with the Batch service. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. NodeCommunicationMode has been removed from the Batch service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NodeCommunicationMode? CurrentNodeCommunicationMode { get; }

        /// <summary> If omitted, the default value is Default. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. NodeCommunicationMode has been removed from the Batch service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NodeCommunicationMode? TargetNodeCommunicationMode { get; set; }

        /// <summary>
        /// The list of application licenses must be a subset of available Batch service application licenses.
        /// </summary>
        [Obsolete("This property is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> ApplicationLicenses { get; }

        /// <summary>
        /// For Windows compute nodes, the Batch service installs the certificates to the specified certificate store and location.
        /// Warning: This property is deprecated and will be removed after February, 2024. Please use the Azure KeyVault Extension instead.
        /// </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Please use the Azure KeyVault Extension instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<BatchCertificateReference> Certificates { get; }

        /// <summary> The tags of the resource. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, string> ResourceTags { get; }

        /// <summary> If not specified, the default is spread. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Use TaskSchedulingPolicy instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BatchNodeFillType? TaskSchedulingNodeFillType { get; set; }
    }
}
