// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System;

namespace Azure.Generator.Management.Providers
{
    internal class InheritableSystemObjectModelProvider : SystemObjectModelProvider
    {
        public InheritableSystemObjectModelProvider(Type type, InputModelType inputModel) : base(type, inputModel)
        {
        }
    }
}
