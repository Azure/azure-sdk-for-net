// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the protected parameterless constructor that the MPG generator
// dropped (issue #59298). Required for back-compat with the AutoRest-based
// API surface in main: subclasses chain via : base(name).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    public abstract partial class PipelineActivity
    {
        /// <summary> Initializes a new instance of <see cref="PipelineActivity"/>. </summary>
        /// <param name="name"> Activity name. </param>
        protected PipelineActivity(string name) : this(name, null)
        {
        }
    }
}
