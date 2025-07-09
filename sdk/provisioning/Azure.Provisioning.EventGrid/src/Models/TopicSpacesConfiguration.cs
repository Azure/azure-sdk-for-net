// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// Properties of the Topic Spaces Configuration.
/// </summary>
public partial class TopicSpacesConfiguration
{
    /// <summary>
    /// Client authentication settings for topic spaces configuration.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ClientAuthenticationSettings ClientAuthentication
    {
        get => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
        set => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
    }
}
