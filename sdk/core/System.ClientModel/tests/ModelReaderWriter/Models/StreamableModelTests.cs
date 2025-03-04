// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal abstract class StreamableModelTests<T> : ModelTests<T> where T : IStreamModel<T>
    {
        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithStreamableModelReaderWriter(string format)
          => RoundTripTest(format, new ModelReaderWriterStreamableStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithStreamableModelReaderWriterNonGeneric(string format)
            => RoundTripTest(format, new ModelReaderWriterStreamableNonGenericStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithStreamableModelInterface(string format)
            => RoundTripTest(format, new ModelInterfaceStreamableStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithStreamableModelInterfaceNonGeneric(string format)
            => RoundTripTest(format, new ModelInterfaceAsObjectStreamableStrategy<T>());
    }
}
