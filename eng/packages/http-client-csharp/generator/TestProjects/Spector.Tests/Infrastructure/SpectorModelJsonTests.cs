// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Generator.Tests.Common;

namespace TestProjects.Spector.Tests.Infrastructure
{
    public abstract class SpectorModelJsonTests<T> : SpectorModelTests<T> where T : IJsonModel<T>
    {
        [SpectorTest]
        public void RoundTripWithJsonInterfaceOfTWire()
            => RoundTripTest("W", new JsonInterfaceStrategy<T>());

        [SpectorTest]
        public void RoundTripWithJsonInterfaceOfTJson()
            => RoundTripTest("J", new JsonInterfaceStrategy<T>());

        [SpectorTest]
        public void RoundTripWithJsonInterfaceNonGenericWire()
            => RoundTripTest("W", new JsonInterfaceAsObjectStrategy<T>());

        [SpectorTest]
        public void RoundTripWithJsonInterfaceNonGenericJson()
            => RoundTripTest("J", new JsonInterfaceAsObjectStrategy<T>());

        [SpectorTest]
        public void RoundTripWithJsonInterfaceUtf8ReaderWire()
            => RoundTripTest("W", new JsonInterfaceUtf8ReaderStrategy<T>());

        [SpectorTest]
        public void RoundTripWithJsonInterfaceUtf8ReaderJson()
            => RoundTripTest("J", new JsonInterfaceUtf8ReaderStrategy<T>());

        [SpectorTest]
        public void RoundTripWithJsonInterfaceUtf8ReaderNonGenericWire()
            => RoundTripTest("W", new JsonInterfaceUtf8ReaderAsObjectStrategy<T>());

        [SpectorTest]
        public void RoundTripWithJsonInterfaceUtf8ReaderNonGenericJson()
            => RoundTripTest("J", new JsonInterfaceUtf8ReaderAsObjectStrategy<T>());
    }
}