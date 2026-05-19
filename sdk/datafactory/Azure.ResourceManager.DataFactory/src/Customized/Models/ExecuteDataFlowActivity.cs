// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customization to restore property dropped by MPG generator due to flatten/access decisions on Cat A types (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    public partial class ExecuteDataFlowActivity
    {
        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFlowStagingInfo Staging { get; set; }
    }
}
