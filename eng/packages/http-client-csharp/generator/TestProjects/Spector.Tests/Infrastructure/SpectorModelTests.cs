// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Generator.Tests.Common;

namespace TestProjects.Spector.Tests.Infrastructure
{
    public abstract class SpectorModelTests<T> : ModelTests<T> where T : IPersistableModel<T>
    {
        [SpectorTest]
        public void RoundTripWithModelReaderWriterWire()
            => RoundTripWithModelReaderWriterBase("W");

        [SpectorTest]
        public void RoundTripWithModelReaderWriterJson()
            => RoundTripWithModelReaderWriterBase("J");

        [SpectorTest]
        public void RoundTripWithModelReaderWriterNonGenericWire()
            => RoundTripWithModelReaderWriterNonGenericBase("W");

        [SpectorTest]
        public void RoundTripWithModelReaderWriterNonGenericJson()
            => RoundTripWithModelReaderWriterNonGenericBase("J");

        [SpectorTest]
        public void RoundTripWithModelInterfaceWire()
            => RoundTripWithModelInterfaceBase("W");

        [SpectorTest]
        public void RoundTripWithModelInterfaceJson()
            => RoundTripWithModelInterfaceBase("J");

        [SpectorTest]
        public void RoundTripWithModelInterfaceNonGenericWire()
            => RoundTripWithModelInterfaceNonGenericBase("W");

        [SpectorTest]
        public void RoundTripWithModelInterfaceNonGenericJson()
            => RoundTripWithModelInterfaceNonGenericBase("J");

        [SpectorTest]
        public void RoundTripWithModelCast()
            => RoundTripWithModelCastBase("W");

        [SpectorTest]
        public void ThrowsIfUnknownFormat()
            => ThrowsIfUnknownFormatBase();

        [SpectorTest]
        public void ThrowsIfWireIsNotJson()
            => ThrowsIfWireIsNotJsonBase();

    }
}