// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance
{
    // Backward-compat alias: ContainerGroupProfileCollection was renamed to CGProfileCollection in TypeSpec migration.
    /// <summary> A class representing the ContainerGroupProfile collection and its operations. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerGroupProfileCollection : CGProfileCollection
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupProfileCollection"/>. </summary>
        protected ContainerGroupProfileCollection()
        {
        }
    }
}
