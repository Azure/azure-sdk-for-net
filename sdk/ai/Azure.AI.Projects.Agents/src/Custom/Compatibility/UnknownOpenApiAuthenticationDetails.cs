// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Projects.Agents
{
    internal partial class UnknownOpenApiAuthenticationDetails : OpenApiAuthenticationDetails
    {
        /// <summary> Initializes a new instance of <see cref="UnknownOpenApiAuthenticationDetails"/>. </summary>
        /// <param name="type"> The type of authentication, must be anonymous/project_connection/managed_identity. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal UnknownOpenApiAuthenticationDetails(OpenApiAuthType @type, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(@type != default ? @type : "unknown", additionalBinaryDataProperties)
        {
        }
    }
}
