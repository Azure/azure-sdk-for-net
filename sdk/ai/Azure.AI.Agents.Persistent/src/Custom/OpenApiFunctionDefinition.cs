// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent;

public partial class OpenApiFunctionDefinition
{
    internal IList<InternalFunctionDefinition> Functions { get; }
}
