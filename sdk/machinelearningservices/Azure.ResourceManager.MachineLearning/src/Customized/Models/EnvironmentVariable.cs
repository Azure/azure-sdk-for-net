// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class EnvironmentVariable
    {
        // Customized: restore legacy property name; TypeSpec rename is not applied to this generated property declaration.
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EnvironmentVariableType? VariableType
        {
            get => Type;
            set => Type = value;
        }
    }
}
