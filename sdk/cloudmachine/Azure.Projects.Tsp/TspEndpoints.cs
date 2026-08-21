// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Projects;

/// <summary>
/// This class is used to register TSP endpoints.
/// </summary>
public class TspEndpoints
{
    internal List<Type> Endpoints { get; } = [];

    /// <summary>
    /// Adds a TSP endpoint to the list of endpoints.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="InvalidOperationException"></exception>
    public void AddEndpoints<T>()
    {
        Type endpointsType = typeof(T);
        if (!endpointsType.IsInterface)
            throw new InvalidOperationException("Endpoints type must be an interface.");
        Endpoints.Add(endpointsType);
    }
}
