// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    // Customization to restore property dropped by MPG generator due to flatten/access decisions on Cat A types (issue #59298).
    public partial class ExecuteWranglingDataflowActivity
    {
        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFlowStagingInfo Staging { get; set; }
    }
}
