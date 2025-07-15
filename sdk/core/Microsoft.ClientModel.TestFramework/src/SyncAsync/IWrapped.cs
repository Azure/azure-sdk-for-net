// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// An interface implemented by instrumented clients and LROs that allows to retrieve the original value.
/// </summary>
internal interface IWrapped
{
    public object Original { get; }
}