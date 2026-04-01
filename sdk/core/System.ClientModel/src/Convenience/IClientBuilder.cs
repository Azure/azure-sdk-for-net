// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides a builder interface for configuring client applications.
/// </summary>
[Experimental("SCME0002")]
public interface IClientBuilder
{
    /// <summary>
    /// Adds a configuration action to be executed after the initial configuration of <see cref="ClientSettings"/>.
    /// </summary>
    /// <param name="configure">Factory method to modify the <see cref="ClientSettings"/>.</param>
    IClientBuilder PostConfigure(Action<ClientSettings> configure);
}
