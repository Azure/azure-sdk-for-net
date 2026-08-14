// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Generator.Management.Tests.Common;

namespace TestProjects.Spector.Tests.Infrastructure
{
    public abstract class SpectorModelTests<T> : ModelTests<T> where T : IPersistableModel<T>
    {
        [SpectorTest]
        public void RoundTripWithModelReaderWriterWire()
            => RoundTripWithModelReaderWriterBase("W");
    }
}
