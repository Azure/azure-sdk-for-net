// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class ClientPage<T> : ResultCollection<T>
{
    public string? ContinuationToken;
}
#pragma warning restore CS1591 // public XML comments
