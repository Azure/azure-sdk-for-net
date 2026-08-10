// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.Extensions.OpenAI;

namespace Azure.AI.Projects.Agents
{
    public partial class OpenAPIManagedAuthenticationDetails
    {
        /// <summary> Initializes a new instance of <see cref="OpenAPIManagedAuthenticationDetails"/> for deserialization. </summary>
        internal OpenAPIManagedAuthenticationDetails() : base(OpenApiAuthenticationKind.ManagedIdentity)
        {
        }
    }
}
