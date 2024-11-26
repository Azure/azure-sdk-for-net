// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.Core;

namespace Azure.CloudMachine;

/// <summary>
/// Represents the connection options for a client.
/// </summary>
public class ConnectionCollection : KeyedCollection<string, ClientConnection>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionCollection"/> class.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected override string GetKeyForItem(ClientConnection item) => item.Id;

    internal void AddRange(IEnumerable<ClientConnection> connections)
    {
        foreach (ClientConnection connection in connections)
            Add(connection);
    }
}
