// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

/// <summary>
/// .
/// </summary>
public abstract class ClientSettings : ClientSettingsBase
{
    /// <summary>
    /// .
    /// </summary>
    public ClientPipelineOptions ClientOptions { get; set; } = ClientPipelineOptions.Default;
}
