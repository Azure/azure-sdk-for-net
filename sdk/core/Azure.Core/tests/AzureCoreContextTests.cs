// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core.GeoJson;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture("J")]
    [TestFixture("W")]
    public class AzureCoreContextTests
    {
        private const string PointJson = """{"type":"Point","coordinates":[-122.091954,47.607148],"bbox":[-180,-90,180,90],"name":"Test Point","value":42}""";
        private const string PointWithAltitudeJson = """{"type":"Point","coordinates":[-122.091954,47.607148,15],"bbox":[-180,-90,180,90],"name":"Test Point","value":42}""";
        private readonly ModelReaderWriterOptions _options;

        public AzureCoreContextTests(string format)
        {
            _options = new ModelReaderWriterOptions(format);
        }

        public static IEnumerable<Type> PersistableModelTypes =>
            typeof(AzureCoreContext).Assembly.GetTypes()
                .Where(type => !type.ContainsGenericParameters && type.GetInterfaces()
                    .Any(@interface => @interface.IsGenericType &&
                        @interface.GetGenericTypeDefinition() == typeof(IPersistableModel<>)));

        [TestCaseSource(nameof(PersistableModelTypes))]
        public void RegistersEveryPersistableModel(Type modelType)
        {
            Assert.IsNotNull(AzureCoreContext.Default.GetTypeBuilder(modelType));
        }

        [Test]
        public void ConsumerContextUsesOwningContextBuilder()
        {
            Assert.AreSame(
                AzureCoreContext.Default.GetTypeBuilder(typeof(GeoPoint)),
                AzureCoreConsumerContext.Default.GetTypeBuilder(typeof(GeoPoint)));
        }

        [Test]
        public void CanRoundTripGeoPoint(
            [Values] bool useConsumerContext,
            [Values] bool useGenericOverload,
            [Values] bool includeAltitude)
        {
            ModelReaderWriterContext context = useConsumerContext
                ? AzureCoreConsumerContext.Default
                : AzureCoreContext.Default;
            var data = BinaryData.FromString(includeAltitude ? PointWithAltitudeJson : PointJson);
            var point = useGenericOverload
                ? ModelReaderWriter.Read<GeoPoint>(data, _options, context)
                : (GeoPoint)ModelReaderWriter.Read(data, typeof(GeoPoint), _options, context);

            AssertPoint(point, includeAltitude);

            var written = useGenericOverload
                ? ModelReaderWriter.Write<GeoPoint>(point, _options, context)
                : ModelReaderWriter.Write((object)point, _options, context);
            using var document = JsonDocument.Parse(written);
            var root = document.RootElement;
            Assert.AreEqual("Point", root.GetProperty("type").GetString());
            Assert.AreEqual(includeAltitude ? 3 : 2, root.GetProperty("coordinates").GetArrayLength());
            Assert.AreEqual(-122.091954, root.GetProperty("coordinates")[0].GetDouble());
            Assert.AreEqual(47.607148, root.GetProperty("coordinates")[1].GetDouble());
            if (includeAltitude)
            {
                Assert.AreEqual(15, root.GetProperty("coordinates")[2].GetDouble());
            }
            CollectionAssert.AreEqual(new[] { -180, -90, 180, 90 },
                root.GetProperty("bbox").EnumerateArray().Select(value => value.GetInt32()));
            Assert.AreEqual("Test Point", root.GetProperty("name").GetString());
            Assert.AreEqual(42, root.GetProperty("value").GetInt32());
            AssertPoint(ModelReaderWriter.Read<GeoPoint>(written, _options, context), includeAltitude);
        }

        [Test]
        public void CanRoundTripGeoPointArray()
        {
            var data = BinaryData.FromString($"[{PointJson},null,{PointWithAltitudeJson}]");
            var points = ModelReaderWriter.Read<GeoPoint[]>(data, _options, AzureCoreConsumerContext.Default);
            Assert.AreEqual(3, points.Length);
            AssertPoint(points[0], false);
            Assert.IsNull(points[1]);
            AssertPoint(points[2], true);

            var written = ModelReaderWriter.Write(points, _options, AzureCoreConsumerContext.Default);
            var roundTrip = ModelReaderWriter.Read<GeoPoint[]>(written, _options, AzureCoreConsumerContext.Default);
            Assert.AreEqual(3, roundTrip.Length);
            AssertPoint(roundTrip[0], false);
            Assert.IsNull(roundTrip[1]);
            AssertPoint(roundTrip[2], true);
        }

        [Test]
        public void CanRoundTripGeoPointList()
        {
            var data = BinaryData.FromString($"[{PointJson},{PointWithAltitudeJson}]");
            var points = ModelReaderWriter.Read<List<GeoPoint>>(data, _options, AzureCoreConsumerContext.Default);
            Assert.AreEqual(2, points.Count);
            AssertPoint(points[0], false);
            AssertPoint(points[1], true);

            var written = ModelReaderWriter.Write(points, _options, AzureCoreConsumerContext.Default);
            var roundTrip = ModelReaderWriter.Read<List<GeoPoint>>(written, _options, AzureCoreConsumerContext.Default);
            Assert.AreEqual(2, roundTrip.Count);
            AssertPoint(roundTrip[0], false);
            AssertPoint(roundTrip[1], true);
        }

        [Test]
        public void CanRoundTripGeoPointDictionary()
        {
            var data = BinaryData.FromString($"{{\"point\":{PointJson},\"elevated\":{PointWithAltitudeJson}}}");
            var points = ModelReaderWriter.Read<Dictionary<string, GeoPoint>>(data, _options, AzureCoreConsumerContext.Default);
            Assert.AreEqual(2, points.Count);
            AssertPoint(points["point"], false);
            AssertPoint(points["elevated"], true);

            var written = ModelReaderWriter.Write(points, _options, AzureCoreConsumerContext.Default);
            var roundTrip = ModelReaderWriter.Read<Dictionary<string, GeoPoint>>(written, _options, AzureCoreConsumerContext.Default);
            Assert.AreEqual(2, roundTrip.Count);
            AssertPoint(roundTrip["point"], false);
            AssertPoint(roundTrip["elevated"], true);
        }

        [Test]
        public void CanRoundTripResponseError()
        {
            var data = BinaryData.FromString(
                """{"code":"BadRequest","message":"Invalid request","target":"location","details":[{"code":"InvalidPoint","message":"Invalid coordinates"}],"innererror":{"code":"Inner","innererror":{"code":"Nested"}}}""");
            var error = ModelReaderWriter.Read<ResponseError>(data, _options, AzureCoreContext.Default);
            AssertResponseError(error);

            var written = ModelReaderWriter.Write(error, _options, AzureCoreContext.Default);
            AssertResponseError(ModelReaderWriter.Read<ResponseError>(written, _options, AzureCoreContext.Default));
        }

        [Test]
        public void CanRoundTripResponseInnerError()
        {
            var data = BinaryData.FromString("""{"code":"Inner","innererror":{"code":"Nested"}}""");
            var error = ModelReaderWriter.Read<ResponseInnerError>(data, _options, AzureCoreContext.Default);
            Assert.AreEqual("Inner", error.Code);
            Assert.AreEqual("Nested", error.InnerError.Code);

            var written = ModelReaderWriter.Write(error, _options, AzureCoreContext.Default);
            var roundTrip = ModelReaderWriter.Read<ResponseInnerError>(written, _options, AzureCoreContext.Default);
            Assert.AreEqual("Inner", roundTrip.Code);
            Assert.AreEqual("Nested", roundTrip.InnerError.Code);
        }

        [Test]
        public void CanRoundTripRehydrationToken([Values] bool useGenericOverload)
        {
            var token = new RehydrationToken("operation-id", "1", "Location",
                "https://example.com/status", "https://example.com/start", RequestMethod.Post,
                "https://example.com/result", OperationFinalStateVia.Location.ToString());
            var written = useGenericOverload
                ? ModelReaderWriter.Write<RehydrationToken>(token, _options, AzureCoreContext.Default)
                : ModelReaderWriter.Write((object)token, _options, AzureCoreContext.Default);
            var roundTrip = useGenericOverload
                ? ModelReaderWriter.Read<RehydrationToken>(written, _options, AzureCoreContext.Default)
                : (RehydrationToken)ModelReaderWriter.Read(written, typeof(RehydrationToken), _options, AzureCoreContext.Default);
            Assert.AreEqual(token, roundTrip);
        }

        [Test]
        public void GeoPointRejectsUnsupportedFormat()
        {
            var options = new ModelReaderWriterOptions("X");
            Assert.Throws<FormatException>(() => ModelReaderWriter.Read<GeoPoint>(
                BinaryData.FromString(PointJson), options, AzureCoreContext.Default));
            Assert.Throws<FormatException>(() => ModelReaderWriter.Write(
                new GeoPoint(1, 2), options, AzureCoreContext.Default));
        }

        private static void AssertPoint(GeoPoint point, bool includeAltitude)
        {
            Assert.IsNotNull(point);
            Assert.AreEqual(GeoObjectType.Point, point.Type);
            Assert.AreEqual(-122.091954, point.Coordinates.Longitude);
            Assert.AreEqual(47.607148, point.Coordinates.Latitude);
            Assert.AreEqual(includeAltitude ? 15d : (double?)null, point.Coordinates.Altitude);
            Assert.IsNotNull(point.BoundingBox);
            Assert.AreEqual(-180, point.BoundingBox.West);
            Assert.AreEqual(-90, point.BoundingBox.South);
            Assert.AreEqual(180, point.BoundingBox.East);
            Assert.AreEqual(90, point.BoundingBox.North);
            Assert.IsTrue(point.TryGetCustomProperty("name", out var name));
            Assert.AreEqual("Test Point", name);
            Assert.IsTrue(point.TryGetCustomProperty("value", out var value));
            Assert.AreEqual(42, value);
        }

        private static void AssertResponseError(ResponseError error)
        {
            Assert.AreEqual("BadRequest", error.Code);
            Assert.AreEqual("Invalid request", error.Message);
            Assert.AreEqual("location", error.Target);
            Assert.AreEqual(1, error.Details.Count);
            Assert.AreEqual("InvalidPoint", error.Details[0].Code);
            Assert.AreEqual("Invalid coordinates", error.Details[0].Message);
            Assert.AreEqual("Inner", error.InnerError.Code);
            Assert.AreEqual("Nested", error.InnerError.InnerError.Code);
        }
    }
}
