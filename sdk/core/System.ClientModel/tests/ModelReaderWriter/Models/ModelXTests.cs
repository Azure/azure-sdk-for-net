// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.IO;
using System.ClientModel.Tests.Client;
using System.Text;
using System.Linq;
using System.ClientModel.Clients.Models;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal class ModelXTests : ModelJsonTests<ModelX>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("ModelX/ModelXWireFormat.json")).TrimEnd();

        protected override void CompareModels(ModelX model, ModelX model2, string format)
        {
            Assert.AreEqual(model.Name, model2.Name);
            Assert.AreEqual(model.Kind, model2.Kind);

            Assert.AreEqual(model.Fields, model2.Fields);
            Assert.AreEqual(model.KeyValuePairs, model2.KeyValuePairs);
            Assert.AreEqual(model.NullProperty, model2.NullProperty);

            if (format == "J")
            {
                Assert.AreEqual(model.XProperty, model2.XProperty);
                var rawData = GetRawData(model);
                var rawData2 = GetRawData(model2);
                Assert.IsNotNull(rawData);
                Assert.IsNotNull(rawData2);
                Assert.AreEqual(rawData.Count, rawData2.Count);
                Assert.AreEqual(rawData["extra"].ToObjectFromJson<string>(), rawData2["extra"].ToObjectFromJson<string>());
            }
        }

        protected override string GetExpectedResult(string format)
        {
            var builder = new StringBuilder();
            builder.Append("{\"fields\":[\"testField\"]")
                .Append(",\"keyValuePairs\":{\"color\":\"red\"}");
            if (format == "J")
            {
                builder.Append(",\"xProperty\":100");
            }
            builder.Append(",\"kind\":\"X\",\"name\":\"xmodel\"");
            if (format == "J")
            {
                builder.Append(",\"extra\":\"stuff\"");
            }
            builder.Append("}");
            return builder.ToString();
        }

        protected override void VerifyModel(ModelX model, string format)
        {
            Assert.AreEqual("X", model.Kind);
            Assert.AreEqual("xmodel", model.Name);

            Assert.AreEqual(1, model.Fields.Count);
            Assert.AreEqual("testField", model.Fields[0]);
            Assert.AreEqual(1, model.KeyValuePairs.Count);
            Assert.AreEqual("red", model.KeyValuePairs["color"]);
            Assert.IsNull(model.NullProperty);

            var rawData = GetRawData(model);
            Assert.IsNotNull(rawData);
            if (format == "J")
            {
                Assert.AreEqual(100, model.XProperty);
                Assert.AreEqual("stuff", rawData["extra"].ToObjectFromJson<string>());
            }
        }
    }
}
