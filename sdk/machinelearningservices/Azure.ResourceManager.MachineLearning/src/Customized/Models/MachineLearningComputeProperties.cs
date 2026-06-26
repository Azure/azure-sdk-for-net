// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore protected constructors for legacy extensible base models that customers may subclass; TypeSpec generation does not emit these non-wire constructors.
    // Also restore the GA provisioning errors property because generation references it from constructors/serialization but does not emit
    // the public declaration. TypeSpec decorators cannot add a property that is not present on the generated model.
    [CodeGenSuppress("ProvisioningErrors")]
    public abstract partial class MachineLearningComputeProperties
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningComputeProperties"/>. </summary>
        protected MachineLearningComputeProperties()
        {
        }

        /// <summary> Errors during provisioning. </summary>
        [WirePath("provisioningErrors")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<MachineLearningError> ProvisioningErrors { get; }
    }
}
