// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;

namespace Azure.AI.Assistants
{
    public partial class OpenApiToolDefinition
    {
        public OpenApiToolDefinition(string name, string description, BinaryData spec, OpenApiAuthDetails auth):this(
                new OpenApiFunctionDefinition(
                    name: name,
                    description: description,
                    spec: spec,
                    auth: auth,
                    defaultParams: [],
                    serializedAdditionalRawData: null
                    )
            ){}
    }
}
