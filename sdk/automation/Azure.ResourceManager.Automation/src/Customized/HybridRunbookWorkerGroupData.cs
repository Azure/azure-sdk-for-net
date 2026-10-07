// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation
{
    // Generated HybridRunbookWorkerGroupData materializes through internal constructors for the wire model.
    // Keep the GA public ResourceData constructor used by callers and tests to create instances.
    public partial class HybridRunbookWorkerGroupData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="HybridRunbookWorkerGroupData"/>. </summary>
        public HybridRunbookWorkerGroupData() : base()
        {
        }
    }
}
