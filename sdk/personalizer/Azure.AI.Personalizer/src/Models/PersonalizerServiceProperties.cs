// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Personalizer
{
    /// <summary> The configuration of the service. </summary>
    [CodeGenModel("ServiceConfiguration")]
    public partial class PersonalizerServiceProperties
    {
        /// <summary> Azure storage account container SAS URI for log mirroring. </summary>
        public Uri LogMirrorSasUri { get; set; }
    }
}
