// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmResourceMoverModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.MoverResourceDependency"/>. </summary>
        /// <param name="id"> Gets the source ARM ID of the dependent resource. </param>
        /// <param name="resolutionStatus"> Gets the dependency resolution status. </param>
        /// <param name="resolutionType"> Defines the resolution type. </param>
        /// <param name="dependencyType"> Defines the dependency type. </param>
        /// <param name="manualResolutionTargetId"> Defines the properties for manual resolution. </param>
        /// <param name="automaticResolutionResourceId"> Defines the properties for automatic resolution. </param>
        /// <param name="isOptional"> Gets or sets a value indicating whether the dependency is optional. </param>
        /// <returns> A new <see cref="Models.MoverResourceDependency"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MoverResourceDependency MoverResourceDependency(ResourceIdentifier id, string resolutionStatus, MoverResourceResolutionType? resolutionType, MoverDependencyType? dependencyType, ResourceIdentifier manualResolutionTargetId, ResourceIdentifier automaticResolutionResourceId, bool? isOptional)
            => MoverResourceDependency(id, resolutionStatus, resolutionType, dependencyType, manualResolutionTargetId, automaticResolutionResourceId, isDependencyOptional : null);
    }
}
