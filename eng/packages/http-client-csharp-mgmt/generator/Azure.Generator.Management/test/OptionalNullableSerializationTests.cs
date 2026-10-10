// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests;

public class OptionalNullableSerializationTests
{
    [Test]
    public void ManagementModelsPreserveExplicitNullPresence()
    {
        var child = InputFactory.Model("Child");
        var inputModel = InputFactory.Model("SelectionPatch", properties:
        [
            InputFactory.Property("text", new InputNullableType(InputPrimitiveType.String)),
            InputFactory.Property("number", new InputNullableType(InputPrimitiveType.Int32)),
            InputFactory.Property("child", new InputNullableType(child)),
            InputFactory.Property("optionalText", InputPrimitiveType.String)
        ]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel, child]).Object;
        var model = plugin.TypeFactory.CreateModel(inputModel)!;
        var modelCode = new TypeProviderWriter(model).Write().Content;
        var serializationCode = new TypeProviderWriter(model.SerializationProviders.Single()).Write().Content;

        foreach (var name in new[] { "Text", "Number", "Child" })
        {
            var property = model.Properties.Single(p => p.Name == name);
            var presenceField = $"_{char.ToLowerInvariant(name[0])}{name[1..]}IsDefined";
            Assert.Multiple(() =>
            {
                Assert.That(property.BackingField, Is.Not.Null, name);
                Assert.That(modelCode, Does.Contain($"{presenceField} = true"), name);
                Assert.That(serializationCode, Does.Contain($"{presenceField} ||"), name);
                Assert.That(serializationCode, Does.Contain($"{presenceField} ="), name);
            });
        }

        Assert.That(modelCode, Does.Not.Contain("_optionalTextIsDefined"));
        Assert.That(serializationCode, Does.Contain("WriteNull"));
    }
}
