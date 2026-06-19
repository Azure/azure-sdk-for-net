// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ApiManagement.Models
{
    public partial class ParameterContract
    {
        // Old SDK name was ParameterContractType; generated name is Type.
        // Not spec-fixable: @@clientName on non-flattened direct properties breaks
        // the generated constructor and serialization code.

        /// <summary> Parameter type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public string ParameterContractType
        {
            get => Type;
            set => Type = value;
        }
    }
}
