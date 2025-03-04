// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Projects;

public class TspEndpoints
{
    internal List<Type> Endpoints { get; } = [];
    public void AddEndpoints<T>()
    {
        Type endpointsType = typeof(T);
        if (!endpointsType.IsInterface)
            throw new InvalidOperationException("Endpoints type must be an interface.");
        Endpoints.Add(endpointsType);
    }
}
