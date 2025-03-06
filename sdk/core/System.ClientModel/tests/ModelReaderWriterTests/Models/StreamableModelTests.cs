// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal abstract class StreamableModelTests<T> : ModelJsonTests<T> where T : IStreamModel<T>, IJsonModel<T>
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

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithJsonStreamableInterfaceOfT(string format)
            => RoundTripTest(format, new JsonStreamableInterfaceStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithJsonStreamableInterfaceNonGeneric(string format)
              => RoundTripTest(format, new JsonStreamableInterfaceAsObjectStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithJsonStreamableInterfaceUtf8Reader(string format)
            => RoundTripTest(format, new JsonStreamableInterfaceUtf8ReaderStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithJsonStreamableInterfaceUtf8ReaderNonGeneric(string format)
            => RoundTripTest(format, new JsonStreamableInterfaceUtf8ReaderAsObjectStrategy<T>());

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelReaderWriterStreamable_WithContext(string format)
            => RoundTripTest(format, new ModelReaderWriterStreamableStrategy_WithContext<T>(Context));

        [TestCase("J")]
        [TestCase("W")]
        public void RoundTripWithModelReaderWriterStreamableNonGeneric_WithContext(string format)
            => RoundTripTest(format, new ModelReaderWriterStreamableNonGenericStrategy_WithContext<T>(Context));
    }
}
