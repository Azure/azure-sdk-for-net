// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.CognitiveServices.Models
{
    /// <summary> Properties of Cognitive Services account. </summary>
    public partial class CognitiveServicesAccountProperties
    {
        /// <summary> (Deprecated) The network injections for the Cognitive Services account. </summary>
        [WirePath("networkInjections")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Please use `AIFoundryNetworkInjections` instead.")]
        public AIFoundryNetworkInjection NetworkInjections
        {
            get
            {
                 throw new InvalidOperationException("Deprecated.  Use AIFoundryNetworkInjections array instead");
            }
            set
            {
                throw new InvalidOperationException("Deprecated. Use AIFoundryNetworkInjections array instead");
            }
        }
    }
}
