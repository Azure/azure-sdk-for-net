// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // public XML comments
public interface IJsonModel
{
    Dictionary<string, object> AdditionalProperties { get; }
}
#pragma warning restore CS1591 // public XML comments
