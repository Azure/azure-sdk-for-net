// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.Projects
{
    public partial class OpenApiToolDefinition
    {
        public OpenApiToolDefinition(string name, string description, BinaryData spec, OpenApiAuthDetails auth):this(
                new OpenApiFunctionDefinition(
                    name: name,
                    description: description,
                    spec: spec,
                    auth: auth,
                    serializedAdditionalRawData: null
                    )
            ){}
    }
}
