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
    public partial class OpenApiProjectConnectionAuthenticationDetails
    {
        /// <summary> Initializes a new instance of <see cref="OpenApiProjectConnectionAuthenticationDetails"/> for deserialization. </summary>
        internal OpenApiProjectConnectionAuthenticationDetails(): base(OpenApiAuthenticationKind.ProjectConnection)
        {
        }
    }
}
