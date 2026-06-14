// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation
{
    // Compatibility shim preserving the GA ResourceData base type; the wire model is tracked in the new API version.
    [CodeGenSuppress("HybridRunbookWorkerGroupData")]
    public partial class HybridRunbookWorkerGroupData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="HybridRunbookWorkerGroupData"/>. </summary>
        public HybridRunbookWorkerGroupData() : base()
        {
        }
    }
}
