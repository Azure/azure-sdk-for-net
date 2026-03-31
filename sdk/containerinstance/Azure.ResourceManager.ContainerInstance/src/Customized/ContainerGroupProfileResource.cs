// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance
{
    // Backward-compat alias: ContainerGroupProfileResource was renamed to CGProfileResource in TypeSpec migration.
    /// <summary> A class representing the ContainerGroupProfile resource along with operations. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerGroupProfileResource : CGProfileResource
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupProfileResource"/>. </summary>
        protected ContainerGroupProfileResource()
        {
        }
    }
}
