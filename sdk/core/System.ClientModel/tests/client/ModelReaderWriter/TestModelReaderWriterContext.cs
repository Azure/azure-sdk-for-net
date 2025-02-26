// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class TestModelReaderWriterContext : ModelReaderWriterContext
    {
        public override Func<object>? GetActivator(Type type)
        {
            return type switch
            {
                Type t when t == typeof(List<AvailabilitySetData>) => () => new List<AvailabilitySetData>(),
                Type t when t == typeof(AvailabilitySetData) => () => new AvailabilitySetData(),
                _ => null
            };
        }
    }
}
