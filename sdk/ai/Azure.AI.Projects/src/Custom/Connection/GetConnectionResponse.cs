// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Projects
{
    /// <summary> Response from the listSecrets operation. </summary>
    public partial class GetConnectionResponse
    {
        /// <summary>
        /// The properties of the resource
        /// Please note <see cref="InternalConnectionProperties"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="InternalConnectionPropertiesAADAuth"/>, <see cref="InternalConnectionPropertiesApiKeyAuth"/> and <see cref="InternalConnectionPropertiesSASAuth"/>.
        /// </summary>
        internal InternalConnectionProperties Properties { get; }
    }
}
