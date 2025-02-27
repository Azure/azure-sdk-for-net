// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

internal interface IActivatorFactory
{
    ModelInfo GetModelInfo(Type type);
}
