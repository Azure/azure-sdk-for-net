// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    public partial class OpenApiToolDefinition
    {
        /// <summary> Initializes a new instance of the <see cref="OpenApiToolDefinition"/> class. </summary>
        /// <param name="name"> The name of the OpenAPI function. </param>
        /// <param name="description"> A description of the OpenAPI function. </param>
        /// <param name="spec"> The OpenAPI specification as binary data. </param>
        /// <param name="openApiAuthentication"> The authentication details for the OpenAPI endpoint. </param>
        /// <param name="defaultParams"> Optional default parameters to pass to the function. </param>
        public OpenApiToolDefinition(string name, string description, BinaryData spec, OpenApiAuthDetails openApiAuthentication, IList<string> defaultParams = null) : this(
                new OpenApiFunctionDefinition(
                    name: name,
                    description: description,
                    spec: spec,
                    openApiAuthentication: openApiAuthentication,
                    defaultParams: defaultParams ?? [],
                    functions: new ChangeTrackingList<InternalFunctionDefinition>(),
                    additionalBinaryDataProperties: null
                    )
            )
        { }
    }
}
