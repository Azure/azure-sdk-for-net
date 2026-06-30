// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation
{
    // Generated HybridRunbookWorkerData materializes through internal constructors for the wire model.
    // Keep the GA public ResourceData constructor used by callers and tests to create instances.
    public partial class HybridRunbookWorkerData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="HybridRunbookWorkerData"/>. </summary>
        public HybridRunbookWorkerData() : base()
        {
        }
    }
}
