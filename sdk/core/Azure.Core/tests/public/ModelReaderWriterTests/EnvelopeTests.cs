// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Tests.Public.ModelReaderWriterTests
{
    internal class EnvelopeTests// : ModelJsonTests<Envelope<EnvelopeTests.ModelC>>
    {
        //protected override string JsonPayload => WirePayload;

        //protected override string WirePayload => "{\"readOnlyProperty\":\"read\"," +
        //        "\"modelA\":{\"name\":\"Cat\",\"isHungry\":false,\"weight\":2.5}," +
        //        "\"modelC\":{\"x\":\"hello\",\"y\":\"bye\"}" +
        //        "}";

        //protected override Func<Envelope<ModelC>, RequestContent> ToRequestContent => model => model;

        //protected override Func<Response, Envelope<ModelC>> FromResponse => response => (Envelope<ModelC>)response;

        //protected override Func<Type, ObjectSerializer> GetObjectSerializerFactory(ModelReaderWriterFormat format)
        //{
        //    if (format == ModelReaderWriterFormat.Wire)
        //    {
        //        JsonSerializerSettings settings = new JsonSerializerSettings
        //        {
        //            ContractResolver = new IgnoreReadOnlyPropertiesResolver()
        //        };
        //        return type => type.Equals(typeof(ModelC)) ? new NewtonsoftJsonObjectSerializer(settings) : null;
        //    }
        //    else
        //    {
        //        return type => type.Equals(typeof(ModelC)) ? new NewtonsoftJsonObjectSerializer() : null;
        //    }
        //}

        //protected override void CompareModels(Envelope<ModelC> model, Envelope<ModelC> model2, ModelReaderWriterFormat format)
        //{
        //    if (format == ModelReaderWriterFormat.Json)
        //    {
        //        Assert.AreEqual(model.ReadOnlyProperty, model2.ReadOnlyProperty);
        //        Assert.AreEqual(model.ModelA.LatinName, model2.ModelA.LatinName);
        //        Assert.AreEqual(model.ModelA.HasWhiskers, model2.ModelA.HasWhiskers);
        //    }
        //    Assert.AreEqual(model.ModelA.Name, model2.ModelA.Name);
        //    Assert.AreEqual(model.ModelA.IsHungry, model2.ModelA.IsHungry);
        //    Assert.AreEqual(model.ModelA.Weight, model2.ModelA.Weight);
        //    Assert.AreEqual(model.ModelT.X, model2.ModelT.X);
        //    Assert.AreEqual(model.ModelT.Y, model2.ModelT.Y);
        //}

        //protected override string GetExpectedResult(ModelReaderWriterFormat format)
        //{
        //    StringBuilder expectedSerialized = new StringBuilder("{");
        //    if (format == ModelReaderWriterFormat.Json)
        //    {
        //        expectedSerialized.Append("\"readOnlyProperty\":\"read\",");
        //    }
        //    expectedSerialized.Append("\"modelA\":{");
        //    if (format == ModelReaderWriterFormat.Json)
        //    {
        //        expectedSerialized.Append("\"latinName\":\"Felis catus\",\"hasWhiskers\":false,");
        //    }
        //    expectedSerialized.Append("\"name\":\"Cat\",\"isHungry\":false,\"weight\":2.5},");
        //    expectedSerialized.Append("\"modelC\":{\"X\":\"hello\",\"Y\":\"bye\"}"); //using NewtonSoft Serializer
        //    expectedSerialized.Append("}");
        //    return expectedSerialized.ToString();
        //}

        //protected override void VerifyModel(Envelope<ModelC> model, ModelReaderWriterFormat format)
        //{
        //    Assert.IsNotNull(model.ModelA);
        //    if (format == ModelReaderWriterFormat.Json)
        //    {
        //        Assert.AreEqual("read", model.ReadOnlyProperty);
        //        Assert.AreEqual("Felis catus", model.ModelA.LatinName);
        //        Assert.AreEqual(false, model.ModelA.HasWhiskers);
        //    }
        //    Assert.AreEqual("Cat", model.ModelA.Name);
        //    Assert.AreEqual(false, model.ModelA.IsHungry);
        //    Assert.AreEqual(2.5, model.ModelA.Weight);
        //    Assert.IsNotNull(model.ModelT);
        //    Assert.AreEqual("hello", model.ModelT.X);
        //    Assert.AreEqual("bye", model.ModelT.Y);
        //}

        //// Generate a class that implements the NewtonSoft default contract resolver so that ReadOnly properties are not serialized
        //// This is used to verify that the ReadOnly properties are not serialized when IgnoreReadOnlyProperties is set to true
        //private class IgnoreReadOnlyPropertiesResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
        //{
        //    protected override Newtonsoft.Json.Serialization.JsonProperty CreateProperty(System.Reflection.MemberInfo member, MemberSerialization memberSerialization)
        //    {
        //        Newtonsoft.Json.Serialization.JsonProperty property = base.CreateProperty(member, memberSerialization);

        //        if (!property.Writable)
        //        {
        //            property.ShouldSerialize = obj => false;
        //        }

        //        return property;
        //    }
        //}

        //public class ModelC
        //{
        //    public ModelC(string x1, string y1)
        //    {
        //        X = x1;
        //        Y = y1;
        //    }

        //    public string X { get; set; }
        //    public string Y { get; set; }

        //    public static void VerifyModelC(ModelC c1, ModelC c2)
        //    {
        //        Assert.That(c1.X == c2.X);
        //        Assert.That(c1.Y == c2.Y);
        //    }
        //}
    }
}
