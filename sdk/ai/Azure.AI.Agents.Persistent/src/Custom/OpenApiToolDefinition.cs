﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    public partial class OpenApiToolDefinition
    {
        public OpenApiToolDefinition(string name, string description, BinaryData spec, OpenApiAuthDetails auth, IList<string> defaultParams = null) :this(
                new OpenApiFunctionDefinition(
                    name: name,
                    description: description,
                    spec: spec,
                    auth: auth,
                    defaultParams: defaultParams ?? [],
                    functions: new ChangeTrackingList<InternalFunctionDefinition>(),
                    serializedAdditionalRawData: null
                    )
            ){}
    }
}
