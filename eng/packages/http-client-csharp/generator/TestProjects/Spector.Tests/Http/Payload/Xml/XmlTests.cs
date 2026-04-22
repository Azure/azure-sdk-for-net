// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Payload.Xml;

namespace TestProjects.Spector.Tests.Http.Payload.Xml
{
    public class XmlTests : SpectorTestBase
    {
        [SpectorTest]
        public Task GetSimpleModel() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetSimpleModelValueClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);

            var model = response.Value;
            Assert.NotNull(model);

            Assert.AreEqual("foo", model.Name);
            Assert.AreEqual(123, model.Age);
        });

        [SpectorTest]
        public Task PutSimpleModel() => Test(async (host) =>
        {
            SimpleModel model = new SimpleModel("foo", 123);
            var response = await new XmlClient(host, null).GetSimpleModelValueClient()
                .PutAsync(model);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithSimpleArrays() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithSimpleArraysValueClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);

            var model = response.Value;
            Assert.NotNull(model);
            Assert.AreEqual(3, model.Colors.Count);
            Assert.AreEqual(model.Colors[0], "red");
            Assert.AreEqual(model.Colors[1], "green");
            Assert.AreEqual(model.Colors[2], "blue");

            Assert.AreEqual(2, model.Counts.Count);
            Assert.AreEqual(model.Counts[0], 1);
            Assert.AreEqual(model.Counts[1], 2);
        });

        [SpectorTest]
        public Task PutModelWithSimpleArrays() => Test(async (host) =>
        {
            var model = new ModelWithSimpleArrays(
                new[] { "red", "green", "blue" },
                new[] { 1, 2 });
            var response = await new XmlClient(host, null).GetModelWithSimpleArraysValueClient()
                .PutAsync(model);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithArrayOfModel() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithArrayOfModelValueClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);

            var model = response.Value;
            Assert.NotNull(model);
            Assert.AreEqual(2, model.Items.Count);
            Assert.AreEqual("foo", model.Items[0].Name);
            Assert.AreEqual(123, model.Items[0].Age);
            Assert.AreEqual("bar", model.Items[1].Name);
            Assert.AreEqual(456, model.Items[1].Age);
        });

        [SpectorTest]
        public Task PutModelWithArrayOfModel() => Test(async (host) =>
        {
            var model = new ModelWithArrayOfModel(new[]
            {
                new SimpleModel("foo", 123),
                new SimpleModel("bar", 456)
            });
            var response = await new XmlClient(host, null).GetModelWithArrayOfModelValueClient()
                .PutAsync(model);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithOptionalField() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithOptionalFieldValueClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);

            var model = response.Value;
            Assert.NotNull(model);
            Assert.AreEqual("widget", model.Item);
        });

        [SpectorTest]
        public Task PutModelWithOptionalField() => Test(async (host) =>
        {
            var model = new ModelWithOptionalField("widget");
            var response = await new XmlClient(host, null).GetModelWithOptionalFieldValueClient()
                .PutAsync(model);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithAttributes() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithAttributesValueClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);

            var model = response.Value;
            Assert.NotNull(model);
            Assert.IsTrue(model.Enabled);
            Assert.AreEqual(123, model.Id1);
            Assert.AreEqual("foo", model.Id2);
        });

        [SpectorTest]
        public Task PutModelWithAttributes() => Test(async (host) =>
        {
            var model = new ModelWithAttributes(123, "foo", true);
            var response = await new XmlClient(host, null).GetModelWithAttributesValueClient()
                .PutAsync(model);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithUnwrappedArray() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithUnwrappedArrayValueClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);

            var model = response.Value;
            Assert.NotNull(model);

            var colors = model.Colors;
            Assert.NotNull(colors);
            Assert.AreEqual(3, colors.Count);
            Assert.AreEqual("red", colors[0]);
            Assert.AreEqual("green", colors[1]);
            Assert.AreEqual("blue", colors[2]);

            var counts = model.Counts;
            Assert.NotNull(counts);
            Assert.AreEqual(2, counts.Count);
            Assert.AreEqual(1, counts[0]);
            Assert.AreEqual(2, counts[1]);
        });

        [SpectorTest]
        public Task PutModelWithUnwrappedArray() => Test(async (host) =>
        {
            var model = new ModelWithUnwrappedArray(
                new[] { "red", "green", "blue" },
                new[] { 1, 2 });
            var response = await new XmlClient(host, null).GetModelWithUnwrappedArrayValueClient()
                .PutAsync(model);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithRenamedArrays() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithRenamedArraysValueClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);

            var model = response.Value;
            Assert.NotNull(model);
            Assert.AreEqual(3, model.Colors.Count);
            Assert.AreEqual(model.Colors[0], "red");
            Assert.AreEqual(model.Colors[1], "green");
            Assert.AreEqual(model.Colors[2], "blue");
            Assert.AreEqual(2, model.Counts.Count);
            Assert.AreEqual(model.Counts[0], 1);
            Assert.AreEqual(model.Counts[1], 2);
        });

        [SpectorTest]
        public Task PutModelWithRenamedArrays() => Test(async (host) =>
        {
            var model = new ModelWithRenamedArrays(
                new[] { "red", "green", "blue" },
                new[] { 1, 2 });
            var response = await new XmlClient(host, null).GetModelWithRenamedArraysValueClient()
                .PutAsync(model);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithRenamedFields() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithRenamedFieldsValueClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);

            var model = response.Value;
            Assert.NotNull(model);
            var inputData = model.InputData;
            Assert.NotNull(inputData);
            Assert.AreEqual("foo", inputData.Name);
            Assert.AreEqual(123, inputData.Age);

            var outputData = model.OutputData;
            Assert.NotNull(outputData);
            Assert.AreEqual("bar", outputData.Name);
            Assert.AreEqual(456, outputData.Age);
        });

        [SpectorTest]
        public Task PutModelWithRenamedFields() => Test(async (host) =>
        {
            var model = new ModelWithRenamedFields(
                new SimpleModel("foo", 123),
                new SimpleModel("bar", 456));
            var response = await new XmlClient(host, null).GetModelWithRenamedFieldsValueClient()
                .PutAsync(model);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithEmptyArray() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithEmptyArrayValueClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);

            var model = response.Value;
            Assert.NotNull(model);
            Assert.NotNull(model.Items);
            Assert.AreEqual(0, model.Items.Count);
        });

        [SpectorTest]
        public Task PutModelWithEmptyArray() => Test(async (host) =>
        {
            var model = new ModelWithEmptyArray(new List<SimpleModel>());
            var response = await new XmlClient(host, null).GetModelWithEmptyArrayValueClient()
                .PutAsync(model);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithText() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithTextValueClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);

            var model = response.Value;
            Assert.NotNull(model);
            Assert.AreEqual("foo", model.Language);
            Assert.IsTrue(model.Content.Contains("This is some text."));
        });

        [SpectorTest]
        public Task PutModelWithText() => Test(async (host) =>
        {
            var model = new ModelWithText("foo", "\n  This is some text.\n");
            var response = await new XmlClient(host, null).GetModelWithTextValueClient()
                .PutAsync(model);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithDictionary() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithDictionaryValueClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);

            var model = response.Value;
            Assert.NotNull(model);

            var metadata = model.Metadata;
            Assert.NotNull(metadata);
            Assert.AreEqual(3, metadata.Count);
            Assert.AreEqual("blue", metadata["Color"]);
            Assert.AreEqual("123", metadata["Count"]);
            Assert.AreEqual("false", metadata["Enabled"]);
        });

        [SpectorTest]
        public Task PutModelWithDictionary() => Test(async (host) =>
        {
            var model = new ModelWithDictionary(new Dictionary<string, string>
            {
                { "Color", "blue" },
                { "Count", "123" },
                { "Enabled", "false" }
            });
            var response = await new XmlClient(host, null).GetModelWithDictionaryValueClient()
                .PutAsync(model);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithEncodedNames() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithEncodedNamesValueClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);

            var model = response.Value;
            Assert.NotNull(model);

            var modelData = model.ModelData;
            Assert.NotNull(modelData);
            Assert.AreEqual("foo", modelData.Name);
            Assert.AreEqual(123, modelData.Age);

            var colors = model.Colors;
            Assert.NotNull(colors);
            Assert.AreEqual(3, colors.Count);
            Assert.AreEqual("red", colors[0]);
            Assert.AreEqual("green", colors[1]);
            Assert.AreEqual("blue", colors[2]);
        });

        [SpectorTest]
        public Task PutModelWithEncodedNames() => Test(async (host) =>
        {
            var model = new ModelWithEncodedNames(
                new SimpleModel("foo", 123),
                new[] { "red", "green", "blue" });
            var response = await new XmlClient(host, null).GetModelWithEncodedNamesValueClient()
                .PutAsync(model);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithEnum() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithEnumValueClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);

            var model = response.Value;
            Assert.NotNull(model);
            Assert.AreEqual(Status.Success, model.Status);
        });

        [SpectorTest]
        public Task PutModelWithEnum() => Test(async (host) =>
        {
            var model = new ModelWithEnum(Status.Success);
            var response = await new XmlClient(host, null).GetModelWithEnumValueClient()
                .PutAsync(model);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithDatetime() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithDatetimeValueClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);

            var model = response.Value;
            Assert.NotNull(model);
            Assert.AreEqual(DateTimeOffset.Parse("2022-08-26T18:38:00Z"), model.Rfc3339);
            Assert.AreEqual(DateTimeOffset.Parse("Fri, 26 Aug 2022 14:38:00 GMT"), model.Rfc7231);
        });

        [SpectorTest]
        public Task GetModelWithRenamedProperty() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithRenamedPropertyValueClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.Title);
            Assert.AreEqual("bar", response.Value.Author);
        });

        [SpectorTest]
        public Task PutModelWithRenamedProperty() => Test(async (host) =>
        {
            var model = new ModelWithRenamedProperty("foo", "bar");
            var response = await new XmlClient(host, null).GetModelWithRenamedPropertyValueClient().PutAsync(model);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithNestedModel() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithNestedModelValueClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value.Nested);
            Assert.AreEqual("foo", response.Value.Nested.Name);
            Assert.AreEqual(123, response.Value.Nested.Age);
        });

        [SpectorTest]
        public Task PutModelWithNestedModel() => Test(async (host) =>
        {
            var model = new ModelWithNestedModel(new SimpleModel("foo", 123));
            var response = await new XmlClient(host, null).GetModelWithNestedModelValueClient().PutAsync(model);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithRenamedNestedModel() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithRenamedNestedModelValueClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value.Author);
            Assert.AreEqual("foo", response.Value.Author.Name);
        });

        [SpectorTest]
        public Task PutModelWithRenamedNestedModel() => Test(async (host) =>
        {
            var model = new ModelWithRenamedNestedModel(new Author("foo"));
            var response = await new XmlClient(host, null).GetModelWithRenamedNestedModelValueClient().PutAsync(model);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithWrappedPrimitiveCustomItemNames() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithWrappedPrimitiveCustomItemNamesValueClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(2, response.Value.Tags.Count);
            Assert.AreEqual("fiction", response.Value.Tags[0]);
            Assert.AreEqual("classic", response.Value.Tags[1]);
        });

        [SpectorTest]
        public Task PutModelWithWrappedPrimitiveCustomItemNames() => Test(async (host) =>
        {
            var model = new ModelWithWrappedPrimitiveCustomItemNames(new[] { "fiction", "classic" });
            var response = await new XmlClient(host, null).GetModelWithWrappedPrimitiveCustomItemNamesValueClient().PutAsync(model);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithUnwrappedModelArray() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithUnwrappedModelArrayValueClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(2, response.Value.Items.Count);
            Assert.AreEqual("foo", response.Value.Items[0].Name);
            Assert.AreEqual(123, response.Value.Items[0].Age);
            Assert.AreEqual("bar", response.Value.Items[1].Name);
            Assert.AreEqual(456, response.Value.Items[1].Age);
        });

        [SpectorTest]
        public Task PutModelWithUnwrappedModelArray() => Test(async (host) =>
        {
            var model = new ModelWithUnwrappedModelArray(new[]
            {
                new SimpleModel("foo", 123),
                new SimpleModel("bar", 456)
            });
            var response = await new XmlClient(host, null).GetModelWithUnwrappedModelArrayValueClient().PutAsync(model);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithRenamedWrappedModelArray() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithRenamedWrappedModelArrayValueClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(2, response.Value.Items.Count);
            Assert.AreEqual("foo", response.Value.Items[0].Name);
            Assert.AreEqual(123, response.Value.Items[0].Age);
            Assert.AreEqual("bar", response.Value.Items[1].Name);
            Assert.AreEqual(456, response.Value.Items[1].Age);
        });

        [SpectorTest]
        public Task PutModelWithRenamedWrappedModelArray() => Test(async (host) =>
        {
            var model = new ModelWithRenamedWrappedModelArray(new[]
            {
                new SimpleModel("foo", 123),
                new SimpleModel("bar", 456)
            });
            var response = await new XmlClient(host, null).GetModelWithRenamedWrappedModelArrayValueClient().PutAsync(model);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithRenamedUnwrappedModelArray() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithRenamedUnwrappedModelArrayValueClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(2, response.Value.Items.Count);
            Assert.AreEqual("foo", response.Value.Items[0].Name);
            Assert.AreEqual(123, response.Value.Items[0].Age);
            Assert.AreEqual("bar", response.Value.Items[1].Name);
            Assert.AreEqual(456, response.Value.Items[1].Age);
        });

        [SpectorTest]
        public Task PutModelWithRenamedUnwrappedModelArray() => Test(async (host) =>
        {
            var model = new ModelWithRenamedUnwrappedModelArray(new[]
            {
                new SimpleModel("foo", 123),
                new SimpleModel("bar", 456)
            });
            var response = await new XmlClient(host, null).GetModelWithRenamedUnwrappedModelArrayValueClient().PutAsync(model);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithRenamedWrappedAndItemModelArray() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithRenamedWrappedAndItemModelArrayValueClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(2, response.Value.Books.Count);
            Assert.AreEqual("The Great Gatsby", response.Value.Books[0].Title);
            Assert.AreEqual("Les Miserables", response.Value.Books[1].Title);
        });

        [SpectorTest]
        public Task PutModelWithRenamedWrappedAndItemModelArray() => Test(async (host) =>
        {
            var model = new ModelWithRenamedWrappedAndItemModelArray(new[]
            {
                new Book("The Great Gatsby"),
                new Book("Les Miserables")
            });
            var response = await new XmlClient(host, null).GetModelWithRenamedWrappedAndItemModelArrayValueClient().PutAsync(model);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithRenamedAttribute() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithRenamedAttributeValueClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(123, response.Value.Id);
            Assert.AreEqual("The Great Gatsby", response.Value.Title);
            Assert.AreEqual("F. Scott Fitzgerald", response.Value.Author);
        });

        [SpectorTest]
        public Task PutModelWithRenamedAttribute() => Test(async (host) =>
        {
            var model = new ModelWithRenamedAttribute(123, "The Great Gatsby", "F. Scott Fitzgerald");
            var response = await new XmlClient(host, null).GetModelWithRenamedAttributeValueClient().PutAsync(model);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithNamespace() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithNamespaceValueClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(123, response.Value.Id);
            Assert.AreEqual("The Great Gatsby", response.Value.Title);
        });

        [SpectorTest]
        public Task PutModelWithNamespace() => Test(async (host) =>
        {
            var model = new ModelWithNamespace(123, "The Great Gatsby");
            var response = await new XmlClient(host, null).GetModelWithNamespaceValueClient().PutAsync(model);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetModelWithNamespaceOnProperties() => Test(async (host) =>
        {
            var response = await new XmlClient(host, null).GetModelWithNamespaceOnPropertiesValueClient().GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(123, response.Value.Id);
            Assert.AreEqual("The Great Gatsby", response.Value.Title);
            Assert.AreEqual("F. Scott Fitzgerald", response.Value.Author);
        });

        [SpectorTest]
        public Task PutModelWithNamespaceOnProperties() => Test(async (host) =>
        {
            var model = new ModelWithNamespaceOnProperties(123, "The Great Gatsby", "F. Scott Fitzgerald");
            var response = await new XmlClient(host, null).GetModelWithNamespaceOnPropertiesValueClient().PutAsync(model);
            Assert.AreEqual(204, response.Status);
        });
    }
}
