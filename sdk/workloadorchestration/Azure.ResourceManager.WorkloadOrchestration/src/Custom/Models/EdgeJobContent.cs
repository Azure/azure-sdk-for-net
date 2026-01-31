// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.WorkloadOrchestration.Models
{
    /// <summary>
    /// Base Job Parameter
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="DeployJobContent"/>.
    /// </summary>
    public abstract partial class EdgeJobContent
    {
        /// <summary> Initializes a new instance of <see cref="EdgeJobContent"/> for deserialization. </summary>
        protected EdgeJobContent()      // The new MPG made this constructor private; change it back to protected to preserve backward compatibility.
        {
        }
    }
}
