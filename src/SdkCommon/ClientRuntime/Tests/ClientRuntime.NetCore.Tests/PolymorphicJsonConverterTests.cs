// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Xunit;
using Newtonsoft.Json;
using Microsoft.Rest.Serialization;

namespace Microsoft.Rest.ClientRuntime.Tests
{
    public class PolymorphicJsonConverterTests
    {
        // Example hierarchy
        // Naming convention:  nameof(U).StartsWith(nameof(T))  <=>  U : T

        private class Model { }
        private class ModelX : Model { }
        private class ModelXA : ModelX { }
        private class ModelXB : ModelX { }
        private class ModelXAA : ModelXA { }
        private class ModelXAB : ModelXA { }
        private class ModelXABA : ModelXAB { }
        private class ModelXABB : ModelXAB { }

        // JsonConverters

        private static JsonConverter SerializeJsonConverter => new PolymorphicSerializeJsonConverter<ModelX>("type");
        private static JsonConverter DeserializeJsonConverter => new PolymorphicDeserializeJsonConverter<ModelX>("type");

        // helpers

        private static T RoundTrip<T>(Model instance)
        {
            var json = JsonConvert.SerializeObject(instance, SerializeJsonConverter);
            return JsonConvert.DeserializeObject<T>(json, DeserializeJsonConverter);
        }

        private static void AssertRoundTrips<T>(T instance) where T : Model
        {
            var typeStatic = typeof(T);
            var typeDynamicIn = instance.GetType();
            var typeDynamicOut = RoundTrip<T>(instance).GetType();
            Assert.True(typeDynamicIn == typeDynamicOut, $"Round-tripping a '{typeStatic.Name}' unexpectedly failed: '{typeDynamicIn.Name}' -> '{typeDynamicOut.Name}'");
        }

        private static void AssertRoundTripFails<T>(Model instance)
        {
            var typeStatic = typeof(T);
            var typeDynamicIn = instance.GetType();
            var typeDynamicOut = RoundTrip<T>(instance).GetType();
            Assert.True(typeDynamicIn != typeDynamicOut, $"Round-tripping a '{typeStatic.Name}' unexpectedly succeeded: '{typeDynamicIn.Name}' -> '{typeDynamicOut.Name}'");
        }

        [Fact]
        public void RoundTripping()
        {
            // Note: only Model itself succeeds since we put the discriminator on ModelX
            AssertRoundTrips<Model>(new Model());
            AssertRoundTripFails<Model>(new ModelX());
            AssertRoundTripFails<Model>(new ModelXA());
            AssertRoundTripFails<Model>(new ModelXB());
            AssertRoundTripFails<Model>(new ModelXAA());
            AssertRoundTripFails<Model>(new ModelXAB());
            AssertRoundTripFails<Model>(new ModelXABA());
            AssertRoundTripFails<Model>(new ModelXABB());

            AssertRoundTripFails<ModelX>(new Model());
            AssertRoundTrips<ModelX>(new ModelX());
            AssertRoundTrips<ModelX>(new ModelXA());
            AssertRoundTrips<ModelX>(new ModelXB());
            AssertRoundTrips<ModelX>(new ModelXAA());
            AssertRoundTrips<ModelX>(new ModelXAB());
            AssertRoundTrips<ModelX>(new ModelXABA());
            AssertRoundTrips<ModelX>(new ModelXABB());

            AssertRoundTripFails<ModelXA>(new Model());
            AssertRoundTripFails<ModelXA>(new ModelX());
            AssertRoundTrips<ModelXA>(new ModelXA());
            AssertRoundTripFails<ModelXA>(new ModelXB());
            AssertRoundTrips<ModelXA>(new ModelXAA());
            AssertRoundTrips<ModelXA>(new ModelXAB());
            AssertRoundTrips<ModelXA>(new ModelXABA());
            AssertRoundTrips<ModelXA>(new ModelXABB());

            AssertRoundTripFails<ModelXB>(new Model());
            AssertRoundTripFails<ModelXB>(new ModelX());
            AssertRoundTripFails<ModelXB>(new ModelXA());
            AssertRoundTrips<ModelXB>(new ModelXB());
            AssertRoundTripFails<ModelXB>(new ModelXAA());
            AssertRoundTripFails<ModelXB>(new ModelXAB());
            AssertRoundTripFails<ModelXB>(new ModelXABA());
            AssertRoundTripFails<ModelXB>(new ModelXABB());

            AssertRoundTripFails<ModelXAA>(new Model());
            AssertRoundTripFails<ModelXAA>(new ModelX());
            AssertRoundTripFails<ModelXAA>(new ModelXA());
            AssertRoundTripFails<ModelXAA>(new ModelXB());
            AssertRoundTrips<ModelXAA>(new ModelXAA());
            AssertRoundTripFails<ModelXAA>(new ModelXAB());
            AssertRoundTripFails<ModelXAA>(new ModelXABA());
            AssertRoundTripFails<ModelXAA>(new ModelXABB());

            AssertRoundTripFails<ModelXAB>(new Model());
            AssertRoundTripFails<ModelXAB>(new ModelX());
            AssertRoundTripFails<ModelXAB>(new ModelXA());
            AssertRoundTripFails<ModelXAB>(new ModelXB());
            AssertRoundTripFails<ModelXAB>(new ModelXAA());
            AssertRoundTrips<ModelXAB>(new ModelXAB());
            AssertRoundTrips<ModelXAB>(new ModelXABA());
            AssertRoundTrips<ModelXAB>(new ModelXABB());

            AssertRoundTripFails<ModelXABA>(new Model());
            AssertRoundTripFails<ModelXABA>(new ModelX());
            AssertRoundTripFails<ModelXABA>(new ModelXA());
            AssertRoundTripFails<ModelXABA>(new ModelXB());
            AssertRoundTripFails<ModelXABA>(new ModelXAA());
            AssertRoundTripFails<ModelXABA>(new ModelXAB());
            AssertRoundTrips<ModelXABA>(new ModelXABA());
            AssertRoundTripFails<ModelXABA>(new ModelXABB());

            AssertRoundTripFails<ModelXABB>(new Model());
            AssertRoundTripFails<ModelXABB>(new ModelX());
            AssertRoundTripFails<ModelXABB>(new ModelXA());
            AssertRoundTripFails<ModelXABB>(new ModelXB());
            AssertRoundTripFails<ModelXABB>(new ModelXAA());
            AssertRoundTripFails<ModelXABB>(new ModelXAB());
            AssertRoundTripFails<ModelXABB>(new ModelXABA());
            AssertRoundTrips<ModelXABB>(new ModelXABB());
        }
    }
}
