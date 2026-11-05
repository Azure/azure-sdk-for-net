// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Azure.Provisioning.AppService;

// Preserve the historical enum emitted by the reflection-based provisioning generator for API compatibility.
/// <summary>
/// The StaticSiteBasicAuthName.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public enum StaticSiteBasicAuthName
{
    /// <summary>
    /// default.
    /// </summary>
    [DataMember(Name = "default")]
    Default,
}
