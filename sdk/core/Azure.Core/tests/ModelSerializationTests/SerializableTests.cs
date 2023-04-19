// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure;
using Azure.Core.Tests.ModelSerializationTests;
using NUnit.Framework;

public class SerializableTests
{
    private readonly SerializableOptions _wireOptions = new SerializableOptions { SerializeReadonlyProperties = false };
    private readonly SerializableOptions _objectOptions = new SerializableOptions();

    [TestCase(true, true)]
    [TestCase(true, false)]
    [TestCase(false, true)]
    [TestCase(false, false)]
    public void CanRoundTripFutureVersionWithoutLoss(bool includeReadonly, bool handleUnknown)
    {
        Stream stream = new MemoryStream();
        var serviceResponse = "{\"LatinName\":\"Canis lupus familiaris\",\"Weight\":5.5,\"Name\":\"Mr. Fluffy\"}";

        StringBuilder expectedSerialized = new StringBuilder("{");
        if (includeReadonly)
        {
            expectedSerialized.Append("\"LatinName\":\"Canis lupus familiaris\",");
        }
        expectedSerialized.Append("\"Weight\":5.5");
        if (handleUnknown)
        {
            expectedSerialized.Append(",\"Number of Legs\":4");
        }
        expectedSerialized.Append("}");
        var expectedSerializedString = expectedSerialized.ToString();

        SerializableOptions options = new SerializableOptions() { SerializeReadonlyProperties = includeReadonly, HandleUnknownElements = handleUnknown };

        var model = new Animal();
        model.TryDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), out long bytesConsumed, options: options);

        Assert.That(model.LatinName, Is.EqualTo("Canis lupus familiaris"));
        Assert.That(model.Weight, Is.EqualTo(5.5));
        Assert.That(model.Name, Is.EqualTo("Mr. Fluffy"));
        Assert.That(serviceResponse.Length, Is.EqualTo(bytesConsumed));

        model.TrySerialize(stream, out var bytesWritten, options: options);
        string roundTrip = new StreamReader(stream).ReadToEnd();
       // var roundTrip = Encoding.UTF8.GetString(buffer.Span.Slice(0, bytesWritten));
        Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));
        Assert.That(expectedSerialized.Length, Is.EqualTo(bytesWritten));

        var model2 = new Animal();
        model2.TryDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)), out bytesConsumed, options: options);

        if (includeReadonly)
            Assert.That(model.LatinName, Is.EqualTo(model2.LatinName));
        Assert.That(model.Name, Is.EqualTo(model2.Name));
        Assert.That(model.Weight, Is.EqualTo(model2.Weight));
        Assert.That(roundTrip.Length, Is.EqualTo(bytesConsumed));
    }

    [Test]
    public void PrettyPrint()
    {
        CatReadOnlyProperty model = new CatReadOnlyProperty(3.2, "Felis catus", "Catto", true, false);

        Stream stream = new MemoryStream();
        model.TrySerialize(stream, out long bytesWritten, options: new SerializableOptions() { PrettyPrint = true });
        var actualJson = new StreamReader(stream);

        var expectedJson = """
                {
                  "Weight": 1,
                  "LatinName": "Felis catus",
                  "Name": "Catto",
                  "IsHungry": true,
                  "HasWhiskers": false
                }
                """;

        Assert.That(expectedJson, Is.EqualTo(actualJson));
    }
}
