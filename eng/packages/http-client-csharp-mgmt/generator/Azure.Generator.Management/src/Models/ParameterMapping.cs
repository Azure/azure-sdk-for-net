// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Generator.Management.Models;

internal record ParameterMapping(string ParameterName, ContextualParameter? ContextualParameter)
{
    public bool IsContextual => ContextualParameter is not null;
}
