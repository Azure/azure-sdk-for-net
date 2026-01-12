// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Generator.Management.Models;

// TODO -- support the case for resource collection where there are ctor parameters. these parameters do not show up in ctors but still are contextual.
internal record ParameterContextMapping(string ParameterName, ContextualParameter? ContextualParameter)
{
    public bool IsContextual => ContextualParameter is not null;
}
