// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ApiManagement.Models
{
    public partial class ConnectivityHop
    {
        // Old SDK name was ConnectivityHopType; generated name is Type.
        // Not spec-fixable: @@clientName on non-flattened direct properties breaks
        // the generated constructor and serialization code.

        /// <summary> The type of the hop. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public string ConnectivityHopType => Type;
    }
}
