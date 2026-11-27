// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Utilities;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Azure.Core;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.EmitterRpc;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.SourceInput;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Text.Json;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Mgmt.Tests
{
    internal class FlattenedCompatibilityTests
    {
        [Test]
        public void FlattenedAcronymNamePreservesContractAndWireBehavior()
        {
            var properties = InputFactory.Model("SqlVirtualMachineProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, properties],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class SqlVmData { public string OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);

            var type = Compile(plugin.Object).GetType("Samples.Models.SqlVmData")!;
            var property = type.GetProperty("OsType");
            Assert.That(property, Is.Not.Null);
            Assert.That(type.GetProperty("OSType"), Is.Null);
            Assert.That(property!.SetMethod, Is.Not.Null);
            var instance = Activator.CreateInstance(type)!;
            property.SetValue(instance, "Linux");
            Assert.That(property.GetValue(instance), Is.EqualTo("Linux"));

            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("osType").GetString(), Is.EqualTo("Linux"));
            var roundTrip = ModelReaderWriter.Read(
                BinaryData.FromString("""{"properties":{"osType":"Windows"}}"""), type, new ModelReaderWriterOptions("J"));
            Assert.That(property.GetValue(roundTrip), Is.EqualTo("Windows"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FlattenedAcronymCollectionPreservesContractSetterAndWireBehavior(bool wrapperRequired)
        {
            var usage = wrapperRequired ? InputModelTypeUsage.Input | InputModelTypeUsage.Json
                : InputModelTypeUsage.Input | InputModelTypeUsage.Output | InputModelTypeUsage.Json;
            var properties = InputFactory.Model("SqlVirtualMachineProperties", usage: usage, properties:
                [InputFactory.Property("osType", InputFactory.Array(InputPrimitiveType.String), serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, isRequired: wrapperRequired, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", usage: usage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class SqlVmData { public System.Collections.Generic.IList<string> OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            if (wrapperRequired)
            {
                Assert.That(model.Properties.Single(p => p.Name == "Properties").Body.HasSetter, Is.False,
                    "The required input-only wrapper starts without a setter.");
            }
            Visit(model);

            var assembly = Compile(plugin.Object);
            var type = assembly.GetType("Samples.Models.SqlVmData")!;
            var property = type.GetProperty("OsType");
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod, Is.Not.Null);
            var instance = Activator.CreateInstance(type)!;
            property.SetValue(instance, new List<string> { "Linux" });
            Assert.That(((IList<string>)property.GetValue(instance)!).Single(), Is.EqualTo("Linux"));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("osType")[0].GetString(), Is.EqualTo("Linux"));

            var innerType = assembly.GetType("Samples.Models.SqlVirtualMachineProperties")!;
            Assert.That(innerType.GetProperty("OSType")!.SetMethod?.IsPublic, Is.Not.True,
                "The delegation setter on the wire model must not expand its public API.");
        }

        [TestCase(true)]
        [TestCase(false)]
        public void GetterOnlyWrapperPreservesHistoricalCollectionSetter(bool safeFlatten)
        {
            var usage = safeFlatten ? InputModelTypeUsage.Input | InputModelTypeUsage.Json
                : InputModelTypeUsage.Input | InputModelTypeUsage.Output | InputModelTypeUsage.Json;
            var properties = InputFactory.Model("ConfigProperties", usage: usage, properties:
                [InputFactory.Property("osType", InputFactory.Array(InputPrimitiveType.String), serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, isRequired: safeFlatten,
                isReadOnly: !safeFlatten, serializedName: "config");
            if (!safeFlatten)
            {
                Flatten(wrapper);
            }
            var input = InputFactory.Model("ConfigData", usage: usage, properties: [wrapper]);
            var previousName = safeFlatten ? "ConfigOsType" : "OsType";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $"namespace Samples.Models {{ public class ConfigData {{ public System.Collections.Generic.IList<string> {previousName} {{ get; set; }} }} }}")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Assert.That(model.Properties.Single(p => p.Name == "Config").Body.HasSetter, Is.False);
            Visit(model);
            var type = Compile(plugin.Object).GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty(previousName);
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod, Is.Not.Null);
            var instance = Activator.CreateInstance(type)!;
            property.SetValue(instance, new List<string> { "Linux" });
            Assert.That(((IList<string>)property.GetValue(instance)!).Single(), Is.EqualTo("Linux"));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("J")));
            Assert.That(json.RootElement.GetProperty("config").GetProperty("osType")[0].GetString(), Is.EqualTo("Linux"));
        }

        [Test]
        public void OutputOnlySafeFlattenUsesCustomizedParameterlessConstructor()
        {
            const string customization = "namespace Samples.Models { public partial class ConfigProperties { public ConfigProperties() { } } }";
            var properties = InputFactory.Model("ConfigProperties", usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json, properties:
                [InputFactory.Property("osType", InputFactory.Array(InputPrimitiveType.String), serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, serializedName: "config");
            var input = InputFactory.Model("ConfigData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class ConfigData { public System.Collections.Generic.IList<string> ConfigOsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            var inner = plugin.Object.TypeFactory.CreateModel(properties)!;
            Assert.That(inner.CanonicalView.Constructors.Any(c => c.Signature.Parameters.Count == 0 &&
                c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)), Is.True);
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty("ConfigOsType");
            Assert.That(property?.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property!.SetValue(instance, new List<string> { "Linux" });
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("J")));
            Assert.That(json.RootElement.GetProperty("config").GetProperty("osType")[0].GetString(), Is.EqualTo("Linux"));
        }

        [Test]
        public void OutputOnlySafeFlattenRestoresHistoricalCollectionSetter()
        {
            var properties = InputFactory.Model("ConfigProperties", usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json, properties:
                [InputFactory.Property("osType", InputFactory.Array(InputPrimitiveType.String), serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, serializedName: "config");
            var input = InputFactory.Model("ConfigData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class ConfigData { public System.Collections.Generic.IList<string> ConfigOsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            var inner = plugin.Object.TypeFactory.CreateModel(properties)!;
            Visit(model);
            Assert.That(inner.Constructors.Select(c => c.Signature.Parameters.Count), Does.Contain(0),
                "The output-only model must have an accessible initialization constructor.");
            var type = Compile(plugin.Object).GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty("ConfigOsType");
            Assert.That(property?.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property!.SetValue(instance, new List<string> { "Linux" });
            Assert.That(((IList<string>)property.GetValue(instance)!).Single(), Is.EqualTo("Linux"));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("J")));
            Assert.That(json.RootElement.GetProperty("config").GetProperty("osType")[0].GetString(), Is.EqualTo("Linux"));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void GetterOnlyWrapperPreservesHistoricalScalarSetter(bool safeFlatten)
        {
            var usage = safeFlatten ? InputModelTypeUsage.Input | InputModelTypeUsage.Json
                : InputModelTypeUsage.Input | InputModelTypeUsage.Output | InputModelTypeUsage.Json;
            var properties = InputFactory.Model("ConfigProperties", usage: usage, properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, isRequired: safeFlatten,
                isReadOnly: !safeFlatten, serializedName: "config");
            if (!safeFlatten)
            {
                Flatten(wrapper);
            }
            var input = InputFactory.Model("ConfigData", usage: usage, properties: [wrapper]);
            var previousName = safeFlatten ? "ConfigOsType" : "OsType";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $"namespace Samples.Models {{ public class ConfigData {{ public string {previousName} {{ get; set; }} }} }}")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Assert.That(model.Properties.Single(p => p.Name == "Config").Body.HasSetter, Is.False);
            Visit(model);
            var type = Compile(plugin.Object).GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty(previousName);
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod, Is.Not.Null);
            var instance = Activator.CreateInstance(type)!;
            property.SetValue(instance, "Linux");
            Assert.That(property.GetValue(instance), Is.EqualTo("Linux"));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("J")));
            Assert.That(json.RootElement.GetProperty("config").GetProperty("osType").GetString(), Is.EqualTo("Linux"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SharedFlattenedCollectionRetainsContractSetter(bool contractOwnerFirst)
        {
            var properties = InputFactory.Model("SharedProperties", properties:
                [InputFactory.Property("osType", InputFactory.Array(InputPrimitiveType.String), serializedName: "osType")]);
            var firstWrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            var secondWrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(firstWrapper);
            Flatten(secondWrapper);
            var first = InputFactory.Model("FirstData", properties: [firstWrapper]);
            var second = InputFactory.Model("SecondData", properties: [secondWrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [first, second, properties],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class FirstData { public System.Collections.Generic.IList<string> OsType { get; set; } } }")
                ]));
            var firstProvider = plugin.Object.TypeFactory.CreateModel(first)!;
            var secondProvider = plugin.Object.TypeFactory.CreateModel(second)!;
            var sharedProvider = plugin.Object.TypeFactory.CreateModel(properties)!;
            Visit(contractOwnerFirst ? firstProvider : secondProvider);
            Visit(contractOwnerFirst ? secondProvider : firstProvider);

            Assert.That(firstProvider.Properties.Single(p => p.Name == "OsType").Body.HasSetter, Is.True);
            Assert.That(sharedProvider.Properties.Single(p => p.Name == "OSType").Body.HasSetter, Is.True);
            var assembly = Compile(plugin.Object);
            var type = assembly.GetType("Samples.Models.FirstData")!;
            var instance = Activator.CreateInstance(type)!;
            type.GetProperty("OsType")!.SetValue(instance, new List<string> { "Linux" });
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("osType")[0].GetString(), Is.EqualTo("Linux"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SharedFlattenedScalarDoesNotGainSetterOnNewOwner(bool contractOwnerFirst)
        {
            var properties = InputFactory.Model("SharedProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, isReadOnly: true, serializedName: "osType")]);
            var firstWrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            var secondWrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(firstWrapper);
            Flatten(secondWrapper);
            var first = InputFactory.Model("FirstData", properties: [firstWrapper]);
            var second = InputFactory.Model("SecondData", properties: [secondWrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [first, second, properties],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class FirstData { public string OsType { get; set; } } }")
                ]));
            var firstProvider = plugin.Object.TypeFactory.CreateModel(first)!;
            var secondProvider = plugin.Object.TypeFactory.CreateModel(second)!;
            Visit(contractOwnerFirst ? firstProvider : secondProvider);
            Visit(contractOwnerFirst ? secondProvider : firstProvider);
            Assert.That(secondProvider.Properties.Single(p => p.Name == "OSType").Body.HasSetter, Is.False);
            Assert.That(firstProvider.Properties.Single(p => p.Name == "OsType").Body.HasSetter, Is.True);
            var assembly = Compile(plugin.Object);
            Assert.That(assembly.GetType("Samples.Models.SecondData")!.GetProperty("OSType")!.SetMethod, Is.Null);
        }

        [Test]
        public void ChainedFlattenedAcronymNamePreservesContractAndWireBehavior()
        {
            // A scalar leaf isolates wire-name propagation from an existing chained collection-constructor issue.
            var nextHop = InputFactory.Model("RouteNextHopEcmp", properties:
                [InputFactory.Property("nextHopIpAddresses", InputPrimitiveType.String, serializedName: "nextHopIpAddresses")]);
            var nextHopProperty = InputFactory.Property("nextHop", nextHop, serializedName: "nextHop");
            Flatten(nextHopProperty);
            var properties = InputFactory.Model("RoutePropertiesFormat", properties: [nextHopProperty]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("RouteData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, properties, nextHop],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute
                        {
                            public WirePathAttribute(string path) { }
                        }
                        public class RouteData
                        {
                            [WirePath("properties.nextHop.nextHopIpAddresses")]
                            public string NextHopIpAddresses { get; set; }
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);

            var type = Compile(plugin.Object).GetType("Samples.Models.RouteData")!;
            var property = type.GetProperty("NextHopIpAddresses");
            Assert.That(property, Is.Not.Null);
            Assert.That(type.GetProperty("NextHopIPAddresses"), Is.Null);
            Assert.That(property!.SetMethod, Is.Not.Null);
            var instance = Activator.CreateInstance(type)!;
            property.SetValue(instance, "192.0.2.1");
            Assert.That(property.GetValue(instance), Is.EqualTo("192.0.2.1"));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
            var serialized = json.RootElement.GetProperty("properties").GetProperty("nextHop").GetProperty("nextHopIpAddresses");
            Assert.That(serialized.GetString(), Is.EqualTo("192.0.2.1"));
        }

        [TestCase("properties.osType", "OsType")]
        [TestCase("other.osType", "OSType")]
        public void FlattenedAcronymNameUsesMatchingContractWirePath(string previousPath, string expectedName)
        {
            var properties = InputFactory.Model("SqlVirtualMachineProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, properties],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute
                        {
                            public WirePathAttribute(string path) { }
                        }
                        public class SqlVmData
                        {
                            [WirePath("{{previousPath}}")] public string OsType { get; set; }
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain(expectedName));
        }

        [Test]
        public void FlattenedAcronymNamePrefersExistingCanonicalContractMember()
        {
            var properties = InputFactory.Model("SqlVirtualMachineProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, properties],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class SqlVmData { public string OsType { get; set; } public string OSType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OSType"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Not.Contain("OsType"));
        }

        [TestCase("public string OsType { get; set; }", false, "OsType")]
        [TestCase("private string OsType { get; set; }", false, "OSType")]
        [TestCase("public int OsType { get; set; }", false, "OSType")]
        [TestCase("public string OsType { get; set; }", true, "OSType")]
        public void FlattenedAcronymNameRejectsIneligibleContractMembers(string declaration, bool acceptedRemoval, string expectedName)
        {
            var properties = InputFactory.Model("SqlVirtualMachineProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, properties],
                apiCompatBaseline: acceptedRemoval
                    ? ApiCompatBaseline.Parse(["MembersMustExist : Member 'Samples.Models.SqlVmData.OsType.get()' does not exist in the implementation but it does exist in the contract."])
                    : null,
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $"namespace Samples.Models {{ public class SqlVmData {{ {declaration} }} }}")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain(expectedName));
        }

        [Test]
        public void FlattenedAcronymNameKeepsExplicitCustomization()
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute
                    {
                        public CodeGenMemberAttribute(string name) { }
                    }
                }
                namespace Samples.Models
                {
                    public partial class SqlVmData
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public string OsType { get; set; }
                    }
                }
                """;
            var properties = InputFactory.Model("SqlVirtualMachineProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class SqlVmData { public string OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.CustomCodeView!.Properties.Select(p => p.Name), Does.Contain("OsType"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Not.Contain("OsType"));
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.SqlVmData")!;
            Assert.That(type.GetProperty("OsType"), Is.Not.Null);
        }

        [Test]
        public void PrivateCustomizedSiblingDoesNotClaimFlattenedHistoricalName()
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class SqlVirtualMachineProperties
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OsType")]
                        private string OsType { get; set; }
                    }
                }
                """;
            const InputModelTypeUsage output = InputModelTypeUsage.Output | InputModelTypeUsage.Json;
            var normal = InputFactory.Property("osType", InputPrimitiveType.String, isReadOnly: true, serializedName: "osType");
            var exact = InputFactory.Property("OsType", InputPrimitiveType.String, isReadOnly: true, serializedName: "otherOsType");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(exact, true);
            var properties = InputFactory.Model("SqlVirtualMachineProperties", usage: output, properties: [exact, normal]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class SqlVmData { [WirePath("properties.osType")] public string OsType { get; } }
                    }
                    """)
                ]));
            var inner = plugin.Object.TypeFactory.CreateModel(properties)!;
            _ = inner.CanonicalView.Properties;
            var custom = inner.CustomCodeView!.Properties.Single();
            Assert.That(custom.WireInfo!.SerializedName, Is.EqualTo("otherOsType"));
            Assert.That(custom.Modifiers.HasFlag(MethodSignatureModifiers.Private), Is.True);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OsType"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Not.Contain("OSType"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FlattenedAcronymNameDoesNotClaimExactSibling(bool exactFirst)
        {
            var normal = InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType");
            var exact = InputFactory.Property("OsType", InputPrimitiveType.String, serializedName: "otherOsType");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(exact, true);
            var properties = InputFactory.Model("SqlVirtualMachineProperties", properties:
                exactFirst ? [exact, normal] : [normal, exact]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class SqlVmData { public string OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OSType"));
            Assert.That(model.Properties.Count(p => p.Name == "OsType"), Is.EqualTo(1));
            // Compiling this pair also hits a pre-existing duplicate-parameter bug on the base generator.
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FlattenedAcronymNameDoesNotClaimLaterWrapperMember(bool exactFirst)
        {
            var normal = InputFactory.Model("NormalProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var exactLeaf = InputFactory.Property("OsType", InputPrimitiveType.String, serializedName: "otherOsType");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(exactLeaf, true);
            var exact = InputFactory.Model("ExactProperties", properties: [exactLeaf]);
            var normalWrapper = InputFactory.Property("normal", normal, serializedName: "normal");
            var exactWrapper = InputFactory.Property("exact", exact, serializedName: "exact");
            Flatten(normalWrapper);
            Flatten(exactWrapper);
            var input = InputFactory.Model("SqlVmData", properties:
                exactFirst ? [exactWrapper, normalWrapper] : [normalWrapper, exactWrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, normal, exact],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class SqlVmData { public string OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OSType"));
            Assert.That(model.Properties.Count(p => p.Name == "OsType"), Is.EqualTo(1));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FlattenedAcronymNameDoesNotClaimCustomWrapperMember(bool customFirst)
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class ExactProperties { }
                    public partial class SqlVmData
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("Exact")]
                        internal ExactProperties Exact { get; set; }
                    }
                }
                """;
            const InputModelTypeUsage output = InputModelTypeUsage.Output | InputModelTypeUsage.Json;
            var normal = InputFactory.Model("NormalProperties", usage: output, properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, isReadOnly: true, serializedName: "osType")]);
            var exactLeaf = InputFactory.Property("OsType", InputPrimitiveType.String, isReadOnly: true, serializedName: "otherOsType");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(exactLeaf, true);
            var exact = InputFactory.Model("ExactProperties", usage: output, properties: [exactLeaf]);
            var normalWrapper = InputFactory.Property("normal", normal, serializedName: "normal");
            var exactWrapper = InputFactory.Property("exact", exact, serializedName: "exact");
            Flatten(normalWrapper);
            Flatten(exactWrapper);
            var input = InputFactory.Model("SqlVmData", properties:
                customFirst ? [exactWrapper, normalWrapper] : [normalWrapper, exactWrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, normal, exact],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class SqlVmData { [WirePath("normal.osType")] public string OsType { get; } }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            _ = model.CanonicalView.Properties;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OSType"));
            Assert.That(model.Properties.Count(p => p.Name == "OsType"), Is.EqualTo(1));
            Assert.That(Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.SqlVmData"), Is.Not.Null);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FlattenedAcronymNameDoesNotClaimSafeFlattenedSibling(bool safeFirst)
        {
            var normal = InputFactory.Model("NormalProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var suffix = InputFactory.Model("SuffixProperties", properties:
                [InputFactory.Property("type", InputPrimitiveType.String, serializedName: "type")]);
            var normalWrapper = InputFactory.Property("normal", normal, serializedName: "normal");
            Flatten(normalWrapper);
            var safeWrapper = InputFactory.Property("Os", suffix, serializedName: "other");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(safeWrapper, true);
            var input = InputFactory.Model("SqlVmData", properties:
                safeFirst ? [safeWrapper, normalWrapper] : [normalWrapper, safeWrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, normal, suffix],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class SqlVmData { public string OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OSType"));
            Assert.That(model.Properties.Count(p => p.Name == "OsType"), Is.EqualTo(1));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ChainedFlattenedAcronymNameDoesNotClaimNestedSibling(bool exactFirst)
        {
            var normal = InputFactory.Model("NormalProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var exactLeaf = InputFactory.Property("OsType", InputPrimitiveType.String, serializedName: "otherOsType");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(exactLeaf, true);
            var exact = InputFactory.Model("ExactProperties", properties: [exactLeaf]);
            var normalWrapper = InputFactory.Property("normal", normal, serializedName: "normal");
            var exactWrapper = InputFactory.Property("exact", exact, serializedName: "exact");
            Flatten(normalWrapper);
            Flatten(exactWrapper);
            var properties = InputFactory.Model("ContainerProperties", properties:
                exactFirst ? [exactWrapper, normalWrapper] : [normalWrapper, exactWrapper]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties, normal, exact],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class SqlVmData { [WirePath("properties.normal.osType")] public string OsType { get; set; } }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OSType"));
            Assert.That(model.Properties.Count(p => p.Name == "OsType"), Is.EqualTo(1));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void DirectFlattenedSuffixDoesNotClaimHistoricalName(bool hasWirePath)
        {
            var properties = InputFactory.Model("SqlVirtualMachineProperties", properties:
            [
                InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType"),
                InputFactory.Property("type", InputPrimitiveType.String, serializedName: "type")
            ]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var attribute = hasWirePath ? "[WirePath(\"properties.osType\")]" : "";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class SqlVmData { {{attribute}} public string OsType { get; set; } }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OsType"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("Type"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void NonFlattenedSiblingDoesNotClaimHistoricalName(bool hasWirePath)
        {
            var properties = InputFactory.Model("SqlVirtualMachineProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var settings = InputFactory.Model("OtherSettings", properties:
            [
                InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType"),
                InputFactory.Property("displayName", InputPrimitiveType.String, serializedName: "displayName")
            ]);
            var settingsProperty = InputFactory.Property("settings", settings, serializedName: "settings");
            var input = InputFactory.Model("SqlVmData", properties: [wrapper, settingsProperty]);
            var attribute = hasWirePath ? "[WirePath(\"properties.osType\")]" : "";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties, settings],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class SqlVmData { {{attribute}} public string OsType { get; set; } }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OsType"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("Settings"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void NonFlattenedNestedSiblingDoesNotClaimHistoricalName(bool settingsFirst)
        {
            var properties = InputFactory.Model("SqlVirtualMachineProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var nested = InputFactory.Model("NestedSettings", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var settings = InputFactory.Model("OtherSettings", properties:
            [
                InputFactory.Property("displayName", InputPrimitiveType.String, serializedName: "displayName"),
                InputFactory.Property("nested", nested, serializedName: "nested")
            ]);
            var settingsProperty = InputFactory.Property("settings", settings, serializedName: "settings");
            var input = InputFactory.Model("SqlVmData", properties:
                settingsFirst ? [settingsProperty, wrapper] : [wrapper, settingsProperty]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties, settings, nested],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class SqlVmData { [WirePath("properties.osType")] public string OsType { get; set; } }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OsType"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("Settings"));
        }

        [Test]
        public void NonProjectedDescendantDoesNotClaimHistoricalName()
        {
            var first = InputFactory.Model("FirstProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var firstWrapper = InputFactory.Property("first", first, serializedName: "first");
            Flatten(firstWrapper);
            var settings = InputFactory.Model("Settings", properties:
            [
                InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType"),
                InputFactory.Property("displayName", InputPrimitiveType.String, serializedName: "displayName")
            ]);
            var second = InputFactory.Model("SecondProperties", properties:
            [
                InputFactory.Property("settings", settings, serializedName: "settings"),
                InputFactory.Property("mode", InputPrimitiveType.String, serializedName: "mode")
            ]);
            var secondWrapper = InputFactory.Property("second", second, serializedName: "second");
            Flatten(secondWrapper);
            var input = InputFactory.Model("TestData", properties: [firstWrapper, secondWrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, first, second, settings],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class TestData { [WirePath("first.osType")] public string OsType { get; set; } }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OsType"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("Settings"));
        }

        [TestCase("OSType", "other.osType", "", "OSType", false)]
        [TestCase("OsType", "properties.osType", "private", "OsType", false)]
        [TestCase("OsType", "properties.osType", "", "OsType", true)]
        public void FlattenedCollectionSetterRequiresMatchingPublicContract(
            string previousName, string previousPath, string setterAccess, string expectedName, bool expectedSetter)
        {
            var properties = InputFactory.Model("SqlVirtualMachineProperties", properties:
                [InputFactory.Property("osType", InputFactory.Array(InputPrimitiveType.String), serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class SqlVmData
                        {
                            [WirePath("{{previousPath}}")] public System.Collections.Generic.IList<string> {{previousName}} { get; {{setterAccess}} set; }
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var property = model.Properties.Single(p => p.Name == expectedName);
            Assert.That(property.Body.HasSetter, Is.EqualTo(expectedSetter));
        }

        [Test]
        public void FlattenedAcronymNameDoesNotCollideWithCustomNestedType()
        {
            const string customization = "namespace Samples.Models { public partial class SqlVmData { public class OsType { } } }";
            var properties = InputFactory.Model("SqlVirtualMachineProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class SqlVmData { public string OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OSType"));
            Assert.That(Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.SqlVmData"), Is.Not.Null);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void DiscardedExactBooleanWrapperDoesNotBlockHistoricalLeafName(bool chained)
        {
            var inner = InputFactory.Model("OptionsProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.Boolean, isRequired: true, serializedName: "osType")]);
            var exactWrapper = InputFactory.Property("Options", inner, serializedName: "options");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(exactWrapper, true);
            var details = InputFactory.Model("DetailContainer", properties: [exactWrapper]);
            var outerWrapper = InputFactory.Property("details", details, serializedName: "details");
            Flatten(outerWrapper);
            var input = chained ? InputFactory.Model("ConfigData", properties: [outerWrapper]) :
                InputFactory.Model("ConfigData", properties: [exactWrapper]);
            var path = chained ? "details.options.osType" : "options.osType";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => chained ? [input, details, inner] : [input, inner],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class ConfigData { [WirePath("{{path}}")] public bool OsType { get; set; } }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OsType"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Not.Contain("OSType"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void UnusedExactModelNameDoesNotBlockHistoricalLeafName(bool chained)
        {
            var inner = InputFactory.Model("ConfigProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            typeof(InputType).GetProperty(nameof(InputType.IsExactName))!.SetValue(inner, true);
            var wrapper = InputFactory.Property("options", inner, serializedName: "options");
            var details = InputFactory.Model("DetailContainer", properties: [wrapper]);
            var outerWrapper = InputFactory.Property("details", details, serializedName: "details");
            Flatten(outerWrapper);
            var input = chained ? InputFactory.Model("ConfigData", properties: [outerWrapper]) :
                InputFactory.Model("ConfigData", properties: [wrapper]);
            var path = chained ? "details.options.osType" : "options.osType";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => chained ? [input, details, inner] : [input, inner],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class ConfigData { [WirePath("{{path}}")] public string OptionsOsType { get; set; } }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OptionsOsType"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Not.Contain("OptionsOSType"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ExactPropertiesWrapperDoesNotBlockHistoricalLeafName(bool chained)
        {
            var inner = InputFactory.Model("ConfigProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var exactWrapper = InputFactory.Property("Properties", inner, serializedName: "properties");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(exactWrapper, true);
            var details = InputFactory.Model("DetailContainer", properties: [exactWrapper]);
            var outerWrapper = InputFactory.Property("details", details, serializedName: "details");
            Flatten(outerWrapper);
            var input = chained ? InputFactory.Model("ConfigData", properties: [outerWrapper]) :
                InputFactory.Model("ConfigData", properties: [exactWrapper]);
            var path = chained ? "details.properties.osType" : "properties.osType";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => chained ? [input, details, inner] : [input, inner],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class ConfigData { [WirePath("{{path}}")] public string ConfigOsType { get; set; } }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("ConfigOsType"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Not.Contain("ConfigOSType"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ExplicitExactWrapperDoesNotBlockHistoricalLeafName(bool chained)
        {
            var inner = InputFactory.Model("InnerProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var exactWrapper = InputFactory.Property("Details", inner, serializedName: "details");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(exactWrapper, true);
            Flatten(exactWrapper);
            var intermediate = InputFactory.Model("Intermediate", properties: [exactWrapper]);
            var outerWrapper = InputFactory.Property("container", intermediate, serializedName: "container");
            Flatten(outerWrapper);
            var input = chained ? InputFactory.Model("OuterData", properties: [outerWrapper]) :
                InputFactory.Model("OuterData", properties: [exactWrapper]);
            var path = chained ? "container.details.osType" : "details.osType";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => chained ? [input, intermediate, inner] : [input, inner],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class OuterData { [WirePath("{{path}}")] public string OsType { get; set; } }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OsType"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Not.Contain("OSType"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void CustomizedExactWrapperRetainsStrippedAcronym(bool chained)
        {
            var ownerName = chained ? "DetailContainer" : "EndpointData";
            var customization = $$"""
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class EndpointProperties { }
                    public partial class {{ownerName}}
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSSettings")]
                        internal EndpointProperties OSSettings { get; set; }
                    }
                }
                """;
            var inner = InputFactory.Model("EndpointProperties", properties:
                [InputFactory.Property("type", InputPrimitiveType.String, serializedName: "type")]);
            var exactWrapper = InputFactory.Property("OSSettings", inner, serializedName: "osSettings");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(exactWrapper, true);
            var details = InputFactory.Model("DetailContainer", properties: [exactWrapper]);
            var outerWrapper = InputFactory.Property("properties", details, serializedName: "properties");
            Flatten(outerWrapper);
            var input = chained ? InputFactory.Model("EndpointData", properties: [outerWrapper]) :
                InputFactory.Model("EndpointData", properties: [exactWrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => chained ? [input, details, inner] : [input, inner],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class EndpointData { public string OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            var customOwner = chained ? plugin.Object.TypeFactory.CreateModel(details)! : model;
            _ = customOwner.CanonicalView.Properties;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OSType"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Not.Contain("OsType"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SafeFlattenedExactWrapperRetainsStrippedAcronym(bool chained)
        {
            var inner = InputFactory.Model("EndpointProperties", properties:
                [InputFactory.Property("type", InputPrimitiveType.String, serializedName: "type")]);
            var exactWrapper = InputFactory.Property("OSSettings", inner, serializedName: "osSettings");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(exactWrapper, true);
            var details = InputFactory.Model("DetailContainer", properties: [exactWrapper]);
            var outerWrapper = InputFactory.Property("properties", details, serializedName: "properties");
            Flatten(outerWrapper);
            var input = chained ? InputFactory.Model("EndpointData", properties: [outerWrapper]) :
                InputFactory.Model("EndpointData", properties: [exactWrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => chained ? [input, details, inner] : [input, inner],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class EndpointData { public string OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OSType"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Not.Contain("OsType"));
        }

        [Test]
        public void FlattenedAcronymNameRespectsRepeatedExactContributor()
        {
            var leaf = InputFactory.Property("IP", InputPrimitiveType.String, serializedName: "ip");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(leaf, true);
            var inner = InputFactory.Model("EndpointProperties", properties: [leaf]);
            var wrapper = InputFactory.Property("VIPGateway", inner, serializedName: "gateway");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(wrapper, true);
            var input = InputFactory.Model("EndpointData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class EndpointData { public string VIPGatewayIp { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("VIPGatewayIP"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Not.Contain("VIPGatewayIp"));
        }

        [TestCase("protected", false)]
        [TestCase("", true)]
        public void FlattenedCollectionSetterHonorsVisibilityAndFailsClosedForInit(string setterAccess, bool initOnly)
        {
            var properties = InputFactory.Model("SqlVirtualMachineProperties", properties:
                [InputFactory.Property("osType", InputFactory.Array(InputPrimitiveType.String), serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var accessor = initOnly ? "init" : "set";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        public class SqlVmData
                        {
                            public System.Collections.Generic.IList<string> OsType { get; {{setterAccess}} {{accessor}}; }
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object).GetType("Samples.Models.SqlVmData")!;
            var property = type.GetProperty("OsType");
            Assert.That(property, Is.Not.Null);
            if (initOnly)
            {
                Assert.That(property!.SetMethod, Is.Null,
                    "MTG cannot emit an init accessor here; it must not replace it with a public setter.");
            }
            else
            {
                Assert.That(property!.SetMethod!.IsFamily, Is.True);
            }
        }

        [TestCase("private", false)]
        [TestCase("", true)]
        public void FlattenedScalarSetterDoesNotPromoteNonPublicOrInitContract(string setterAccess, bool initOnly)
        {
            var properties = InputFactory.Model("SqlVirtualMachineProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var accessor = initOnly ? "init" : "set";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $"namespace Samples.Models {{ public class SqlVmData {{ public string OsType {{ get; {setterAccess} {accessor}; }} }} }}")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object).GetType("Samples.Models.SqlVmData")!;
            var property = type.GetProperty("OsType");
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod?.IsPublic, Is.Not.True);
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public void SeparatedDateTimeAcronymPreservesHistoricalSetter(bool chained, bool mismatchedPath)
        {
            var dateTimeType = new InputDateTimeType(
                DateTimeKnownEncoding.Rfc3339, "utcDateTime", "TypeSpec.utcDateTime", InputPrimitiveType.String);
            var inner = InputFactory.Model("TimeProperties", properties:
                [InputFactory.Property("ip_start_time", dateTimeType, isReadOnly: true, wireName: "ip_start_time", serializedName: "ip_start_time")]);
            var innerWrapper = InputFactory.Property("inner", inner, serializedName: "inner");
            Flatten(innerWrapper);
            var details = InputFactory.Model("DetailContainer", properties: [innerWrapper]);
            var outerWrapper = InputFactory.Property("details", chained ? details : inner, serializedName: "details");
            Flatten(outerWrapper);
            var input = InputFactory.Model("TimeData", properties: [outerWrapper]);
            var path = mismatchedPath ? "other.ip_start_time" :
                chained ? "details.inner.ip_start_time" : "details.ip_start_time";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => chained ? [input, details, inner] : [input, inner],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class TimeData { [WirePath("{{path}}")] public System.DateTimeOffset? IpStartOn { get; set; } }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var expectedName = mismatchedPath ? "IPStartsOn" : "IpStartOn";
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain(expectedName));
            var property = model.Properties.Single(p => p.Name == expectedName);
            Assert.That(property.Body.HasSetter, Is.EqualTo(!mismatchedPath));
            if (mismatchedPath)
            {
                return;
            }
            var type = Compile(plugin.Object).GetType("Samples.Models.TimeData")!;
            var instance = Activator.CreateInstance(type)!;
            var expected = new DateTimeOffset(2026, 1, 2, 3, 4, 5, TimeSpan.Zero);
            type.GetProperty(expectedName)!.SetValue(instance, expected);
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("J")));
            var detailsJson = json.RootElement.GetProperty("details");
            if (chained)
            {
                detailsJson = detailsJson.GetProperty("inner");
            }
            Assert.That(detailsJson.GetProperty("ip_start_time").GetDateTimeOffset(), Is.EqualTo(expected));
        }

        [Test]
        public void SeparatedDateTimeAcronymDoesNotCollideWithCustomMethod()
        {
            const string customization = "namespace Samples.Models { public partial class TimeData { public void IpStartOn() { } } }";
            var dateTimeType = new InputDateTimeType(
                DateTimeKnownEncoding.Rfc3339, "utcDateTime", "TypeSpec.utcDateTime", InputPrimitiveType.String);
            var inner = InputFactory.Model("TimeProperties", properties:
                [InputFactory.Property("ip_start_time", dateTimeType, wireName: "ip_start_time", serializedName: "ip_start_time")]);
            var wrapper = InputFactory.Property("details", inner, serializedName: "details");
            Flatten(wrapper);
            var input = InputFactory.Model("TimeData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class TimeData { public System.DateTimeOffset? IpStartOn { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("IPStartsOn"));
            Assert.That(Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.TimeData"), Is.Not.Null);
        }

        [TestCase(null, true)]
        [TestCase("details.properties.startTime", true)]
        [TestCase("other.properties.startTime", false)]
        public void ChainedDateTimeAcronymPreservesHistoricalSetter(string? previousPath, bool shouldPreserve)
        {
            var dateTimeType = new InputDateTimeType(
                DateTimeKnownEncoding.Rfc3339, "utcDateTime", "TypeSpec.utcDateTime", InputPrimitiveType.String);
            var inner = InputFactory.Model("DbSystemUpdateProperties", properties:
                [InputFactory.Property("startTime", dateTimeType, isReadOnly: true, serializedName: "startTime")]);
            var innerWrapper = InputFactory.Property("properties", inner, serializedName: "properties");
            var details = InputFactory.Model("DetailContainer", properties: [innerWrapper]);
            var wrapper = InputFactory.Property("details", details, serializedName: "details");
            Flatten(wrapper);
            var input = InputFactory.Model("PatchData", properties: [wrapper]);
            var attribute = previousPath is null ? "" : $"[WirePath(\"{previousPath}\")]";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, details, inner],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class PatchData { {{attribute}} public System.DateTimeOffset? DbSystemUpdateStartOn { get; set; } }
                    }
                    """)
                ]));
            var parent = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(parent);
            var name = shouldPreserve ? "DbSystemUpdateStartOn" : "DBSystemUpdateStartsOn";
            var property = parent.Properties.Single(p => p.Name == name);
            Assert.That(property.Body.HasSetter, Is.EqualTo(shouldPreserve));
            if (!shouldPreserve)
            {
                return;
            }
            var type = Compile(plugin.Object).GetType("Samples.Models.PatchData")!;
            var instance = Activator.CreateInstance(type)!;
            var expected = new DateTimeOffset(2026, 1, 2, 3, 4, 5, TimeSpan.Zero);
            type.GetProperty(name)!.SetValue(instance, expected);
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("J")));
            Assert.That(json.RootElement.GetProperty("details").GetProperty("properties").GetProperty("startTime").GetDateTimeOffset(), Is.EqualTo(expected));
        }

        [Test]
        public void FlattenedSetterDoesNotCallMissingDefaultConstructor()
        {
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input;
            var inner = InputFactory.Model("RequiredProperties", usage: inputUsage, properties:
            [
                InputFactory.Property("name", InputPrimitiveType.String, isRequired: true, serializedName: "name"),
                InputFactory.Property("osType", InputPrimitiveType.String, isReadOnly: true, serializedName: "osType")
            ]);
            var wrapper = InputFactory.Property("details", inner, isReadOnly: true, serializedName: "details");
            Flatten(wrapper);
            var input = InputFactory.Model("OuterData", usage: inputUsage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class OuterData { public string OsType { get; set; } } }")
                ]));
            var innerProvider = plugin.Object.TypeFactory.CreateModel(inner)!;
            Assert.That(innerProvider.CanonicalView.Constructors.Any(c => c.Signature.Parameters.Count == 0), Is.False);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object).GetType("Samples.Models.OuterData")!;
            Assert.That(type.GetProperty("OsType")?.SetMethod?.IsPublic, Is.Not.True,
                "A missing initialization constructor cannot support lazy wrapper reconstruction.");
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FlattenedSetterRequiresSatisfiedRequiredMembers(bool setsRequiredMembers)
        {
            var attribute = setsRequiredMembers ? "[System.Diagnostics.CodeAnalysis.SetsRequiredMembers]" : "";
            var customization = "namespace Samples.Models { public partial class RequiredProperties { " +
                "public required string Marker { get; set; } " + attribute +
                " public RequiredProperties() { Marker = \"done\"; } } }";
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input;
            var inner = InputFactory.Model("RequiredProperties", usage: inputUsage, properties:
            [
                InputFactory.Property("name", InputPrimitiveType.String, isRequired: true, serializedName: "name"),
                InputFactory.Property("osType", InputPrimitiveType.String, isReadOnly: true, serializedName: "osType")
            ]);
            var wrapper = InputFactory.Property("details", inner, isReadOnly: true, serializedName: "details");
            Flatten(wrapper);
            var input = InputFactory.Model("OuterData", usage: inputUsage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class OuterData { public string OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.OuterData")!;
            var property = type.GetProperty("OsType");
            Assert.That(property?.SetMethod?.IsPublic == true, Is.EqualTo(setsRequiredMembers));
            if (setsRequiredMembers)
            {
                var instance = Activator.CreateInstance(type)!;
                property!.SetValue(instance, "Linux");
                Assert.That(property.GetValue(instance), Is.EqualTo("Linux"));
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FlattenedSetterDoesNotConstructAbstractWrapper(bool discriminated)
        {
            var customization = discriminated
                ? "namespace Samples.Models { public partial class AbstractProperties { public AbstractProperties() { } } }"
                : "namespace Samples.Models { public abstract partial class AbstractProperties { public AbstractProperties() { } } }";
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input;
            var properties = new List<InputModelProperty>
            {
                InputFactory.Property("osType", InputPrimitiveType.String, isReadOnly: true, serializedName: "osType")
            };
            if (discriminated)
            {
                properties.Add(InputFactory.Property("kind", InputPrimitiveType.String, isDiscriminator: true, serializedName: "kind"));
            }
            var inner = InputFactory.Model("AbstractProperties", usage: discriminated
                ? InputModelTypeUsage.Input | InputModelTypeUsage.Output | InputModelTypeUsage.Json : inputUsage, properties: properties);
            var wrapper = InputFactory.Property("details", inner, isReadOnly: true, serializedName: "details");
            Flatten(wrapper);
            var input = InputFactory.Model("OuterData", usage: inputUsage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class OuterData { public string OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var assembly = Compile(plugin.Object, customizationSource: customization);
            Assert.That(assembly.GetType("Samples.Models.AbstractProperties")!.IsAbstract, Is.True);
            Assert.That(assembly.GetType("Samples.Models.OuterData")!.GetProperty("OsType")?.SetMethod?.IsPublic, Is.Not.True);
        }

        [TestCase("public RequiredProperties(string name = null) { }", true)]
        [TestCase("public RequiredProperties(string name = null) { } public RequiredProperties(int version = 0) { }", false)]
        [TestCase("private RequiredProperties() { } public RequiredProperties(string name = null) { }", false)]
        public void FlattenedSetterRequiresAnUnambiguousAccessibleConstructor(string constructors, bool canConstruct)
        {
            var customization = "namespace Samples.Models { public partial class RequiredProperties { " + constructors + " } }";
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input;
            var inner = InputFactory.Model("RequiredProperties", usage: inputUsage, properties:
            [
                InputFactory.Property("name", InputPrimitiveType.String, isRequired: true, serializedName: "name"),
                InputFactory.Property("osType", InputPrimitiveType.String, isReadOnly: true, serializedName: "osType")
            ]);
            var wrapper = InputFactory.Property("details", inner, isReadOnly: true, serializedName: "details");
            Flatten(wrapper);
            var input = InputFactory.Model("OuterData", usage: inputUsage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class OuterData { public string OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.OuterData")!;
            var property = type.GetProperty("OsType");
            Assert.That(property?.SetMethod?.IsPublic == true, Is.EqualTo(canConstruct));
            if (canConstruct)
            {
                var instance = Activator.CreateInstance(type)!;
                property!.SetValue(instance, "Linux");
                Assert.That(property.GetValue(instance), Is.EqualTo("Linux"));
            }
        }

        [Test]
        public void FlattenedScalarDoesNotCallInaccessibleGeneratedLeafSetter()
        {
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input | InputModelTypeUsage.Json;
            var readOnly = InputFactory.Property("osType", InputPrimitiveType.String, isRequired: true, isReadOnly: true, serializedName: "osType");
            var baseModel = InputFactory.Model("BaseModel", usage: inputUsage, properties: [readOnly]);
            var relaxed = InputFactory.Property("osType", InputPrimitiveType.String, isRequired: true, serializedName: "osType");
            relaxed.Update(isRequiredInConstructor: false);
            var leaf = InputFactory.Model("LeafModel", usage: inputUsage, properties: [relaxed], baseModel: baseModel);
            var addDerived = typeof(InputModelType).GetMethod("AddDerivedModel", BindingFlags.NonPublic | BindingFlags.Instance)!;
            addDerived.Invoke(baseModel, [leaf]);
            var wrapper = InputFactory.Property("details", baseModel, isReadOnly: true, serializedName: "details");
            Flatten(wrapper);
            var input = InputFactory.Model("OuterData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [baseModel, leaf, input],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class OuterData { public string OsType { get; set; } } }")
                ]));
            var baseProvider = plugin.Object.TypeFactory.CreateModel(baseModel)!;
            var baseProperty = baseProvider.Properties.Single();
            Assert.That(baseProperty.Body, Is.InstanceOf<AutoPropertyBody>());
            var setterModifiers = ((AutoPropertyBody)baseProperty.Body).SetterModifiers;
            Assert.That(setterModifiers.HasFlag(MethodSignatureModifiers.Private | MethodSignatureModifiers.Protected), Is.True);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(Compile(plugin.Object).GetType("Samples.Models.OuterData"), Is.Not.Null);
        }

        [Test]
        public void ChainedScalarCanDelegateThroughPrivateHistoricalSetter()
        {
            var strategy = InputFactory.Model("TestUpdateRunStrategy", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var strategyProperty = InputFactory.Property("strategy", strategy, serializedName: "strategy");
            var properties = InputFactory.Model("TestUpdateRunProperties", properties: [strategyProperty]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("TestUpdateRunData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties, strategy],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    namespace Samples.Models
                    {
                        public class TestUpdateRunProperties { public string StrategyOsType { get; private set; } }
                        public class TestUpdateRunData { public string StrategyOsType { get; set; } }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var assembly = Compile(plugin.Object);
            var intermediate = assembly.GetType("Samples.Models.TestUpdateRunProperties")!;
            Assert.That(intermediate.GetProperty("StrategyOsType")!.SetMethod?.IsPublic, Is.Not.True);
            var type = assembly.GetType("Samples.Models.TestUpdateRunData")!;
            var property = type.GetProperty("StrategyOsType");
            Assert.That(property?.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property!.SetValue(instance, "Linux");
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("strategy").GetProperty("osType").GetString(), Is.EqualTo("Linux"));
        }

        [TestCase("get;", false)]
        [TestCase("get; private set;", false)]
        [TestCase("get; init;", false)]
        [TestCase("get; set;", true)]
        public void CustomCollectionLeafWithoutAccessibleSetterDoesNotGenerateInvalidForwarder(string accessor, bool expectedSetter)
        {
            var customization = $$"""
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public System.Collections.Generic.IList<string> OSType { {{accessor}} } = new System.Collections.Generic.List<string>();
                    }
                }
                """;
            var properties = InputFactory.Model("CustomProperties", properties:
                [InputFactory.Property("osType", InputFactory.Array(InputPrimitiveType.String), serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("CustomData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class CustomData { public System.Collections.Generic.IList<string> OSType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.CustomData")!;
            var property = type.GetProperty("OSType");
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod?.IsPublic == true, Is.EqualTo(expectedSetter),
                "Only a handwritten leaf with an accessible non-init setter can support a forwarding setter.");
        }

        [Test]
        public void WritableCustomLeafPreservesFlattenedAcronymContract()
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public string OSType { get; set; }
                    }
                }
                """;
            var properties = InputFactory.Model("CustomProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("CustomData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class CustomData { public string OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OsType"));
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.CustomData")!;
            var instance = Activator.CreateInstance(type)!;
            type.GetProperty("OsType")!.SetValue(instance, "Linux");
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("osType").GetString(), Is.EqualTo("Linux"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void CustomSourceMappingPrefersExactInputName(bool exactFirst)
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public string OSType { get; set; }
                    }
                }
                """;
            var normal = InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "normal");
            var exact = InputFactory.Property("OSType", InputPrimitiveType.String, serializedName: "exact");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(exact, true);
            var input = InputFactory.Model("CustomProperties", properties: exactFirst ? [exact, normal] : [normal, exact]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input], customizationSources: [customization]);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            _ = model.CanonicalView.Properties;
            var custom = model.CustomCodeView!.Properties.Single();
            plugin.Object.DateTimePropertyMatcher.RegisterCanonicalProperty(custom, model);
            Assert.That(plugin.Object.DateTimePropertyMatcher.GetSourceProperty(custom), Is.SameAs(exact));
        }

        [Test]
        public void CustomizedNormalizedAliasUsesCanonicalInputWhenInnerContractPreservesOldName()
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public string OSType { get; set; }
                    }
                }
                """;
            var source = InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType");
            var properties = InputFactory.Model("CustomProperties", properties: [source]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("CustomData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class CustomProperties { public string OsType { get; set; } } public class CustomData { public string OsType { get; set; } } }")
                ]));
            var inner = plugin.Object.TypeFactory.CreateModel(properties)!;
            _ = inner.CanonicalView.Properties;
            var custom = inner.CustomCodeView!.Properties.Single();
            var inputProperty = typeof(PropertyProvider).GetProperty("InputProperty", BindingFlags.NonPublic | BindingFlags.Instance)!;
            Assert.That(inputProperty.GetValue(custom), Is.SameAs(source), "MTG must bind the normalized alias to this input.");
            Assert.That(custom.WireInfo!.SerializedName, Is.EqualTo("osType"));
            plugin.Object.DateTimePropertyMatcher.RegisterCanonicalProperty(custom, inner);
            Assert.That(plugin.Object.DateTimePropertyMatcher.GetSourceProperty(custom), Is.SameAs(source));
            var parent = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(parent);
            Assert.That(parent.Properties.Select(p => p.Name), Does.Contain("OsType"));
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public void CustomSourceMappingAgreesWithCanonicalIdentifierCollision(bool exactFirst, bool ambiguousWireName)
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OsType")]
                        public string Other { get; set; }
                    }
                }
                """;
            var normal = InputFactory.Property("osType", InputPrimitiveType.String, serializedName: ambiguousWireName ? "same" : "normal");
            var exact = InputFactory.Property("OsType", InputPrimitiveType.String, serializedName: ambiguousWireName ? "same" : "exact");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(exact, true);
            var input = InputFactory.Model("CustomProperties", properties: exactFirst ? [exact, normal] : [normal, exact]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input], customizationSources: [customization]);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            _ = model.CanonicalView.Properties;
            var custom = model.CustomCodeView!.Properties.Single();
            var expected = exactFirst ? exact : normal;
            Assert.That(custom.WireInfo!.SerializedName, Is.EqualTo(expected.SerializedName));
            plugin.Object.DateTimePropertyMatcher.RegisterCanonicalProperty(custom, model);
            if (ambiguousWireName)
            {
                Assert.That(plugin.Object.DateTimePropertyMatcher.GetSourceProperty(custom), Is.Null);
            }
            else
            {
                Assert.That(plugin.Object.DateTimePropertyMatcher.GetSourceProperty(custom), Is.SameAs(expected));
            }
        }

        [TestCase("System.IO.DirectoryInfo", "exists", "Exists", false)]
        [TestCase("System.Version", "major", "Major", true)]
        public void FlattenedExternalGetterOnlyPropertyDoesNotGainSetter(string externalType, string inputName, string propertyName, bool integer)
        {
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input;
            var inner = InputFactory.Model("ExternalProperties", usage: inputUsage, properties:
                [InputFactory.Property(inputName, integer ? InputPrimitiveType.Int32 : InputPrimitiveType.Boolean, isReadOnly: true, serializedName: inputName)]);
            typeof(InputType).GetProperty(nameof(InputType.External))!.SetValue(inner, new InputExternalTypeMetadata(externalType, null, null));
            var wrapper = InputFactory.Property("details", inner, isReadOnly: true, serializedName: "details");
            Flatten(wrapper);
            var input = InputFactory.Model("OuterData", usage: inputUsage, properties: [wrapper]);
            var memberType = integer ? "int" : "bool";
            const string customization = "namespace Samples.Models { public partial class OuterData { } }";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $"namespace Samples.Models {{ public class OuterData {{ public {memberType} {propertyName} {{ get; set; }} }} }}")
                ]));
            Assert.That(plugin.Object.TypeFactory.CreateModel(inner), Is.InstanceOf<SystemObjectModelProvider>());
            Assert.That(plugin.Object.SourceInputModel.Customization?.GetTypeByMetadataName(externalType), Is.Not.Null);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.OuterData")!;
            var property = type.GetProperty(propertyName);
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod?.IsPublic, Is.Not.True);
        }

        [Test]
        public void FlattenedExternalSetterRejectsMismatchedInputType()
        {
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input;
            const string customization = "namespace Samples.Models { public partial class OuterData { } }";
            var inner = InputFactory.Model("ExternalProperties", usage: inputUsage, properties:
                [InputFactory.Property("capacity", InputPrimitiveType.Int64, isRequired: true, isReadOnly: true, serializedName: "capacity")]);
            typeof(InputType).GetProperty(nameof(InputType.External))!.SetValue(inner, new InputExternalTypeMetadata("System.Text.StringBuilder", null, null));
            var wrapper = InputFactory.Property("details", inner, isReadOnly: true, serializedName: "details");
            Flatten(wrapper);
            var input = InputFactory.Model("OuterData", usage: inputUsage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class OuterData { public long Capacity { get; set; } } }")
                ]));
            Assert.That(plugin.Object.TypeFactory.CreateModel(inner), Is.InstanceOf<SystemObjectModelProvider>());
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.OuterData")!;
            var property = type.GetProperty("Capacity");
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod?.IsPublic, Is.Not.True);
        }

        [Test]
        public void ExternalTypeMatchDistinguishesRankAndDeclaringType()
        {
            _ = ManagementMockHelpers.LoadMockPlugin();
            var compilation = Helpers.BuildCompilation(
            [
                ("Types.cs", """
                    namespace Azure.Generator.Mgmt.Tests
                    {
                        internal class FlattenedCompatibilityTests
                        {
                            public class ExternalOwnerA { public class Value { } }
                            public class ExternalOwnerB { public class Value { } }
                            public class Signature { public void M(int[,] value) { } }
                        }
                    }
                    """)
            ]);
            var signature = compilation.GetTypeByMetadataName("Azure.Generator.Mgmt.Tests.FlattenedCompatibilityTests+Signature")!;
            var array = ((IMethodSymbol)signature.GetMembers("M").Single()).Parameters[0].Type;
            var nested = compilation.GetTypeByMetadataName("Azure.Generator.Mgmt.Tests.FlattenedCompatibilityTests+ExternalOwnerA+Value")!;
            var method = typeof(PropertyHelpers).GetMethod("ExternalTypeMatches", BindingFlags.NonPublic | BindingFlags.Static)!;
            bool Matches(ITypeSymbol symbol, CSharpType type) => (bool)method.Invoke(null, [symbol, type])!;
            Assert.That(Matches(nested, new CSharpType(typeof(ExternalOwnerB.Value))), Is.False);
            Assert.That(Matches(nested, new CSharpType(typeof(ExternalOwnerA.Value))), Is.True);
            Assert.That(Matches(array, new CSharpType(typeof(int[]))), Is.False);
            Assert.That(Matches(array, new CSharpType(typeof(int[,]))), Is.True);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FlattenedExternalPublicSetterCanBeUsed(bool hasCustomization)
        {
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input;
            const string customization = "namespace Samples.Models { public partial class OuterData { } }";
            var inner = InputFactory.Model("ExternalProperties", usage: inputUsage, properties:
                [InputFactory.Property("capacity", InputPrimitiveType.Int32, isReadOnly: true, serializedName: "capacity")]);
            typeof(InputType).GetProperty(nameof(InputType.External))!.SetValue(inner, new InputExternalTypeMetadata("System.Text.StringBuilder", null, null));
            var wrapper = InputFactory.Property("details", inner, isReadOnly: true, serializedName: "details");
            Flatten(wrapper);
            var input = InputFactory.Model("OuterData", usage: inputUsage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner],
                customizationSources: hasCustomization ? [customization] : null,
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class OuterData { public int Capacity { get; set; } } }")
                ]));
            if (hasCustomization)
            {
                Assert.That(plugin.Object.SourceInputModel.Customization?.GetTypeByMetadataName("System.Text.StringBuilder"), Is.Not.Null);
            }
            Assert.That(plugin.Object.TypeFactory.CreateModel(inner), Is.InstanceOf<SystemObjectModelProvider>());
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: hasCustomization ? customization : null).GetType("Samples.Models.OuterData")!;
            var property = type.GetProperty("Capacity");
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property!.SetValue(instance, 42);
            Assert.That(property.GetValue(instance), Is.EqualTo(42));
        }

        [Test]
        public void SafeFlattenedExternalValueConstructorRetainsExistingSetter()
        {
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input;
            var inner = InputFactory.Model("ExternalProperties", usage: inputUsage, properties:
                [InputFactory.Property("originalString", InputPrimitiveType.String, isRequired: true, serializedName: "originalString")]);
            typeof(InputType).GetProperty(nameof(InputType.External))!.SetValue(inner, new InputExternalTypeMetadata("System.Uri", null, null));
            var wrapper = InputFactory.Property("config", inner, serializedName: "config");
            var input = InputFactory.Model("OuterData", usage: inputUsage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner]);
            Assert.That(plugin.Object.TypeFactory.CreateModel(inner), Is.InstanceOf<SystemObjectModelProvider>());
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object).GetType("Samples.Models.OuterData")!;
            var property = type.GetProperty("ConfigOriginalString");
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property!.SetValue(instance, "https://example.com");
            Assert.That(property.GetValue(instance), Is.EqualTo("https://example.com"));
        }

        [Test]
        public void CustomSourceMappingTracksExternalBaseProperty()
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class Derived
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public string Other { get; set; }
                    }
                }
                """;
            var source = InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "os_type");
            var external = InputFactory.Model("ExternalBase", properties: [source]);
            typeof(InputType).GetProperty(nameof(InputType.External))!.SetValue(
                external, new InputExternalTypeMetadata("System.Exception", null, null));
            var input = InputFactory.Model("Derived", properties: [], baseModel: external);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [external, input], customizationSources: [customization]);
            var baseProvider = plugin.Object.TypeFactory.CreateModel(external)!;
            Assert.That(baseProvider, Is.InstanceOf<SystemObjectModelProvider>());
            var baseProperty = baseProvider.Properties.Single(p => p.WireInfo?.SerializedName == "os_type");
            Assert.That(plugin.Object.DateTimePropertyMatcher.GetSourceProperty(baseProperty), Is.SameAs(source));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Assert.That(model.BaseModelProvider, Is.SameAs(baseProvider));
            var custom = model.CanonicalView.Properties.Single(p => p.Name == "Other");
            var inputProperty = typeof(PropertyProvider).GetProperty("InputProperty", BindingFlags.NonPublic | BindingFlags.Instance)!;
            Assert.That(inputProperty.GetValue(custom), Is.SameAs(source));
            Assert.That(custom.WireInfo!.SerializedName, Is.EqualTo("os_type"));
            plugin.Object.DateTimePropertyMatcher.RegisterCanonicalProperty(custom, model);
            Assert.That(plugin.Object.DateTimePropertyMatcher.GetSourceProperty(custom), Is.SameAs(source));
        }

        [Test]
        public void CustomSourceMappingDoesNotGuessOverriddenWireIdentity()
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                    [System.AttributeUsage(System.AttributeTargets.Class)]
                    internal sealed class CodeGenSerializationAttribute : System.Attribute
                    {
                        public CodeGenSerializationAttribute(string name, string wireName) { }
                    }
                }
                namespace Samples.Models
                {
                    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization("Other", "exact")]
                    public partial class CustomProperties
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OsType")]
                        public string Other { get; set; }
                    }
                }
                """;
            var normal = InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "normal");
            var exact = InputFactory.Property("OsType", InputPrimitiveType.String, serializedName: "exact");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(exact, true);
            var input = InputFactory.Model("CustomProperties", properties: [normal, exact]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input], customizationSources: [customization]);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            _ = model.CanonicalView.Properties;
            var custom = model.CustomCodeView!.Properties.Single();
            plugin.Object.DateTimePropertyMatcher.RegisterCanonicalProperty(custom, model);
            Assert.That(plugin.Object.DateTimePropertyMatcher.GetSourceProperty(custom), Is.Null);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SafeFlattenRejectsUncallableCustomizedValueConstructor(bool byRef)
        {
            var propertyType = byRef ? "string" : "int?";
            var constructorParameter = byRef ? "ref string value" : "int value";
            var customization = $$"""
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        public CustomProperties({{constructorParameter}}) { OSType = value; }
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public {{propertyType}} OSType { get; private set; }
                    }
                }
                """;
            InputType inputType = byRef ? InputPrimitiveType.String : InputPrimitiveType.Int32;
            var properties = InputFactory.Model("CustomProperties", usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json, properties:
                [InputFactory.Property("osType", inputType, serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, serializedName: "config");
            var input = InputFactory.Model("ConfigData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $"namespace Samples.Models {{ public class ConfigData {{ public {propertyType} ConfigOsType {{ get; set; }} }} }}")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            var inner = plugin.Object.TypeFactory.CreateModel(properties)!;
            var customConstructor = inner.CanonicalView.Constructors.Single(c => c.Signature.Parameters.Count == 1 &&
                c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.That(customConstructor.Signature.Parameters.Single().IsRef, Is.EqualTo(byRef));
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty("ConfigOsType");
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod?.IsPublic, Is.Not.True,
                "An uncallable constructor cannot support a forwarding setter.");
        }

        [Test]
        public void SafeFlattenedSetterDoesNotCallMissingValueConstructor()
        {
            const string customization = """
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        private CustomProperties() { }
                        public CustomProperties(int value) { }
                    }
                }
                """;
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input;
            var properties = InputFactory.Model("CustomProperties", usage: inputUsage, properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, isReadOnly: true, serializedName: "config");
            var input = InputFactory.Model("ConfigData", usage: inputUsage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class ConfigData { public string ConfigOsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.ConfigData")!;
            Assert.That(type.GetProperty("ConfigOsType")?.SetMethod?.IsPublic, Is.Not.True);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FlattenedContractMatchesNestedArrayElementIdentity(bool matchingElement)
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public class A { public class Value { } }
                    public class B { public class Value { } }
                    public partial class CustomProperties
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public A.Value[] OSType { get; private set; }
                    }
                }
                """;
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input;
            var properties = InputFactory.Model("CustomProperties", usage: inputUsage, properties:
                [InputFactory.Property("osType", InputFactory.Array(InputPrimitiveType.String), isRequired: true, serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, isReadOnly: true, serializedName: "config");
            var input = InputFactory.Model("ConfigData", usage: inputUsage, properties: [wrapper]);
            var previousElement = matchingElement ? "A" : "B";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                        namespace Samples.Models
                        {
                            public class A { public class Value { } }
                            public class B { public class Value { } }
                            [System.AttributeUsage(System.AttributeTargets.Property)]
                            internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                            public class ConfigData { [WirePath("config.osType")] public {{previousElement}}.Value[] ConfigOsType { get; set; } }
                        }
                        """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.ConfigData")!;
            var current = type.GetProperty(matchingElement ? "ConfigOsType" : "ConfigOSType");
            Assert.That(current, Is.Not.Null);
            Assert.That(type.GetProperty(matchingElement ? "ConfigOSType" : "ConfigOsType"), Is.Null);
            Assert.That(current!.SetMethod?.IsPublic == true, Is.EqualTo(matchingElement));
        }

        [TestCase(true, false)]
        [TestCase(false, true)]
        public void SafeFlattenedSetterDoesNotConfuseNestedArrayElementTypes(bool leafReadOnly, bool hasCallableConstructor)
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public class A { public class Value { } }
                    public class B { public class Value { } }
                    public partial class CustomProperties
                    {
                        private CustomProperties() { }
                        public CustomProperties(B.Value[] value) { }
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public A.Value[] OSType { get; private set; }
                    }
                }
                """;
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input;
            var properties = InputFactory.Model("CustomProperties", usage: inputUsage, properties:
                [InputFactory.Property("osType", InputFactory.Array(InputPrimitiveType.String), isRequired: true, isReadOnly: leafReadOnly, serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, isReadOnly: true, serializedName: "config");
            var input = InputFactory.Model("ConfigData", usage: inputUsage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class A { public class Value { } } public class ConfigData { public A.Value[] ConfigOsType { get; set; } } }")
                ]));
            var inner = plugin.Object.TypeFactory.CreateModel(properties)!;
            var custom = inner.CustomCodeView!;
            var valueType = custom.Properties.Single(p => p.Name == "OSType").Type;
            var matcher = typeof(FlattenPropertyVisitor).GetMethod("HasAccessibleSingleValueConstructor", BindingFlags.NonPublic | BindingFlags.Static)!;
            Assert.That((bool)matcher.Invoke(null, [inner, valueType])!, Is.EqualTo(hasCallableConstructor),
                "Only a constructor taking the actual nested array type is callable.");
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var assembly = Compile(plugin.Object, customizationSource: customization);
            var type = assembly.GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty("ConfigOsType");
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod?.IsPublic == true, Is.EqualTo(hasCallableConstructor));
            if (hasCallableConstructor)
            {
                var instance = Activator.CreateInstance(type)!;
                var value = Array.CreateInstance(assembly.GetType("Samples.Models.A+Value")!, 0);
                property.SetValue(instance, value);
                Assert.That(property.GetValue(instance), Is.SameAs(value));
            }
        }

        [Test]
        public void SafeFlattenedSetterDoesNotValidateDifferentConstructorOverload()
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        public required string Marker;
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public System.Collections.Generic.IList<string> OSType { get; private set; }
                        [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
                        public CustomProperties(System.Collections.Generic.IEnumerable<string> values) { Marker = "done"; OSType = new System.Collections.Generic.List<string>(values); }
                        public CustomProperties(System.Collections.Generic.IList<string> items) { Marker = "done"; OSType = items; }
                    }
                }
                """;
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input;
            var properties = InputFactory.Model("CustomProperties", usage: inputUsage, properties:
                [InputFactory.Property("osType", InputFactory.Array(InputPrimitiveType.String), isRequired: true, serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, isReadOnly: true, serializedName: "config");
            var input = InputFactory.Model("ConfigData", usage: inputUsage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class ConfigData { public System.Collections.Generic.IList<string> ConfigOsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.ConfigData")!;
            Assert.That(type.GetProperty("ConfigOsType")?.SetMethod?.IsPublic, Is.Not.True);
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void SafeFlattenedSetterRequiresSatisfiedRequiredMembers(bool valueConstructor, bool setsRequiredMembers)
        {
            var attribute = setsRequiredMembers ? "[System.Diagnostics.CodeAnalysis.SetsRequiredMembers]" : "";
            var leaf = valueConstructor ? "[Microsoft.TypeSpec.Generator.Customizations.CodeGenMember(\"OSType\")] public string OSType { get; private set; }" : "";
            var constructor = valueConstructor
                ? "public CustomProperties(string value) { Marker = \"done\"; OSType = value; }"
                : "public CustomProperties() { Marker = \"done\"; }";
            var customization = "namespace Microsoft.TypeSpec.Generator.Customizations { [System.AttributeUsage(System.AttributeTargets.Property)] " +
                "internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } } } " +
                "namespace Samples.Models { public partial class CustomProperties { public required string Marker; " +
                leaf + attribute + constructor + " } }";
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input;
            var properties = InputFactory.Model("CustomProperties", usage: inputUsage, properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, isRequired: valueConstructor, serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, isReadOnly: true, serializedName: "config");
            var input = InputFactory.Model("ConfigData", usage: inputUsage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class ConfigData { public string ConfigOsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty("ConfigOsType");
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod?.IsPublic == true, Is.EqualTo(setsRequiredMembers));
            if (setsRequiredMembers)
            {
                var instance = Activator.CreateInstance(type)!;
                property!.SetValue(instance, "Linux");
                Assert.That(property.GetValue(instance), Is.EqualTo("Linux"));
            }
        }

        [Test]
        public void SafeFlattenUsesAnnotatedValueConstructorWhenDefaultCannotSatisfyRequiredMembers()
        {
            const string customization = """
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        public required string Marker;
                        public CustomProperties() { Marker = "default"; }
                        [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
                        public CustomProperties(string value) { Marker = "value"; OSType = value; }
                    }
                }
                """;
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input;
            var properties = InputFactory.Model("CustomProperties", usage: inputUsage, properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, isReadOnly: true, serializedName: "config");
            var input = InputFactory.Model("ConfigData", usage: inputUsage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class ConfigData { public string ConfigOsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty("ConfigOsType");
            Assert.That(property?.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property!.SetValue(instance, "Linux");
            Assert.That(property.GetValue(instance), Is.EqualTo("Linux"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SafeFlattenRetainsGeneratedLeafValueConstructorSemantics(bool hasContract)
        {
            const string customization = """
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        public CustomProperties() { }
                        public CustomProperties(string value) { OSType = value.ToUpperInvariant(); }
                    }
                }
                """;
            var properties = InputFactory.Model("CustomProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, isRequired: true, serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, serializedName: "config");
            var input = InputFactory.Model("ConfigData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: hasContract ? () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class ConfigData { public string ConfigOSType { get; set; } } }")
                ]) : null);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty("ConfigOSType");
            Assert.That(property?.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property!.SetValue(instance, "linux");
            Assert.That(property.GetValue(instance), Is.EqualTo("LINUX"));
            property.SetValue(instance, "windows");
            Assert.That(property.GetValue(instance), Is.EqualTo("WINDOWS"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SafeFlattenRetainsExistingValueConstructorSemantics(bool hasContract)
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        internal CustomProperties() { }
                        public CustomProperties(string value) { OSType = value.ToUpperInvariant(); }
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public string OSType { get; set; }
                    }
                }
                """;
            var properties = InputFactory.Model("CustomProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, isRequired: true, serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, serializedName: "config");
            var input = InputFactory.Model("ConfigData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: hasContract ? () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class ConfigData { public string ConfigOSType { get; set; } } }")
                ]) : null);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty("ConfigOSType");
            Assert.That(property?.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property!.SetValue(instance, "linux");
            Assert.That(property.GetValue(instance), Is.EqualTo("LINUX"));
            property.SetValue(instance, "windows");
            Assert.That(property.GetValue(instance), Is.EqualTo("WINDOWS"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SafeFlattenHonorsCustomConstructorSemantics(bool hasContract)
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        public CustomProperties(string value) { OSType = "fixed"; }
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public string OSType { get; private set; }
                    }
                }
                """;
            var properties = InputFactory.Model("CustomProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, isRequired: true, serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, serializedName: "config");
            var input = InputFactory.Model("ConfigData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: hasContract ? () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class ConfigData { public string ConfigOsType { get; set; } } }")
                ]) : null);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty(hasContract ? "ConfigOsType" : "ConfigOSType");
            Assert.That(property?.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property!.SetValue(instance, "Linux");
            Assert.That(property.GetValue(instance), Is.EqualTo("fixed"));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
            Assert.That(json.RootElement.GetProperty("config").GetProperty("osType").GetString(), Is.EqualTo("fixed"));
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public void SafeFlattenedCustomPrivateLeafUsesCustomizedValueConstructor(bool hasContract, bool hasDefaultConstructor)
        {
            var defaultConstructor = hasDefaultConstructor ? "public CustomProperties() { }" : "";
            var customization = $$"""
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        {{defaultConstructor}}
                        public CustomProperties(string value) { OSType = value; }
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public string OSType { get; private set; }
                    }
                }
                """;
            var properties = InputFactory.Model("CustomProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, isRequired: true, serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, serializedName: "config");
            var input = InputFactory.Model("ConfigData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: hasContract ? () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class ConfigData { public string ConfigOsType { get; set; } } }")
                ]) : null);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            var inner = plugin.Object.TypeFactory.CreateModel(properties)!;
            Assert.That(inner.CanonicalView.Constructors.Any(c => c.Signature.Parameters.Count == 1 &&
                c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)), Is.True);
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty(hasContract ? "ConfigOsType" : "ConfigOSType");
            Assert.That(property?.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property!.SetValue(instance, "Linux");
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
            Assert.That(json.RootElement.GetProperty("config").GetProperty("osType").GetString(), Is.EqualTo("Linux"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SafeFlattenedCustomPrivateLeafUsesPublicConstructor(bool hasContract)
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public string OSType { get; private set; }
                    }
                }
                """;
            var properties = InputFactory.Model("CustomProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, isRequired: true, serializedName: "osType")]);
            var wrapper = InputFactory.Property("config", properties, serializedName: "config");
            var input = InputFactory.Model("ConfigData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: hasContract ? () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class ConfigData { public string ConfigOsType { get; set; } } }")
                ]) : null);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty(hasContract ? "ConfigOsType" : "ConfigOSType");
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property.SetValue(instance, "Linux");
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
            Assert.That(json.RootElement.GetProperty("config").GetProperty("osType").GetString(), Is.EqualTo("Linux"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SafeFlattenedGeneratedRestrictedLeafUsesValueConstructorWithDefault(bool hasContract)
        {
            const string customization = "namespace Samples.Models { public partial class BaseModel { public BaseModel() { } public BaseModel(string value) { OSType = value; } } }";
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input | InputModelTypeUsage.Json;
            var readOnly = InputFactory.Property("osType", InputPrimitiveType.String, isRequired: true, isReadOnly: true, serializedName: "osType");
            var baseModel = InputFactory.Model("BaseModel", usage: inputUsage, properties: [readOnly]);
            var relaxed = InputFactory.Property("osType", InputPrimitiveType.String, isRequired: true, serializedName: "osType");
            relaxed.Update(isRequiredInConstructor: false);
            var leaf = InputFactory.Model("LeafModel", usage: inputUsage, properties: [relaxed], baseModel: baseModel);
            typeof(InputModelType).GetMethod("AddDerivedModel", BindingFlags.NonPublic | BindingFlags.Instance)!.Invoke(baseModel, [leaf]);
            var wrapper = InputFactory.Property("config", baseModel, serializedName: "config");
            var input = InputFactory.Model("ConfigData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [baseModel, leaf, input],
                customizationSources: [customization],
                lastContractCompilation: hasContract ? () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class ConfigData { public string ConfigOsType { get; set; } } }")
                ]) : null);
            var inner = plugin.Object.TypeFactory.CreateModel(baseModel)!;
            var body = inner.Properties.Single().Body as AutoPropertyBody;
            Assert.That(body!.SetterModifiers.HasFlag(MethodSignatureModifiers.Private | MethodSignatureModifiers.Protected), Is.True);
            Assert.That(inner.CanonicalView.Constructors.Any(c => c.Signature.Parameters.Count == 0 && c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)), Is.True);
            Assert.That(inner.CanonicalView.Constructors.Any(c => c.Signature.Parameters.Count == 1 && c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)), Is.True);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty(hasContract ? "ConfigOsType" : "ConfigOSType");
            Assert.That(property?.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property!.SetValue(instance, "Linux");
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("J")));
            Assert.That(json.RootElement.GetProperty("config").GetProperty("osType").GetString(), Is.EqualTo("Linux"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SafeFlattenedGeneratedGetterOnlyLeafUsesValueConstructorWithDefault(bool hasContract)
        {
            const string customization = "namespace Samples.Models { public partial class BaseModel { public BaseModel() { } public BaseModel(string value) { OSType = value; } } }";
            const InputModelTypeUsage inputUsage = InputModelTypeUsage.Input | InputModelTypeUsage.Json;
            var readOnly = InputFactory.Property("osType", InputPrimitiveType.String, isRequired: true, isReadOnly: true, serializedName: "osType");
            var baseModel = InputFactory.Model("BaseModel", usage: inputUsage, properties: [readOnly]);
            var wrapper = InputFactory.Property("config", baseModel, serializedName: "config");
            var input = InputFactory.Model("ConfigData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [baseModel, input],
                customizationSources: [customization],
                lastContractCompilation: hasContract ? () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class ConfigData { public string ConfigOsType { get; set; } } }")
                ]) : null);
            var inner = plugin.Object.TypeFactory.CreateModel(baseModel)!;
            Assert.That(inner.Properties.Single().Body.HasSetter, Is.False);
            Assert.That(inner.CanonicalView.Constructors.Any(c => c.Signature.Parameters.Count == 0 && c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)), Is.True);
            Assert.That(inner.CanonicalView.Constructors.Any(c => c.Signature.Parameters.Count == 1 && c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)), Is.True);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.ConfigData")!;
            var property = type.GetProperty(hasContract ? "ConfigOsType" : "ConfigOSType");
            Assert.That(property?.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property!.SetValue(instance, "Linux");
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("J")));
            Assert.That(json.RootElement.GetProperty("config").GetProperty("osType").GetString(), Is.EqualTo("Linux"));
        }

        [TestCase("get;", false)]
        [TestCase("get; private set;", false)]
        [TestCase("get; init;", false)]
        [TestCase("get; set;", true)]
        public void CustomScalarLeafRequiresAccessibleSetter(string accessor, bool expectedSetter)
        {
            var customization = $$"""
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class CustomProperties
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("OSType")]
                        public string OSType { {{accessor}} } = "Linux";
                    }
                }
                """;
            var properties = InputFactory.Model("CustomProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("CustomData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class CustomData { public string OSType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.CustomData")!;
            var property = type.GetProperty("OSType");
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod?.IsPublic == true, Is.EqualTo(expectedSetter));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ChainedCollectionCanDelegateThroughProtectedHistoricalSetter(bool getterOnly)
        {
            var strategy = InputFactory.Model("TestUpdateRunStrategy", properties:
                [InputFactory.Property("osType", InputFactory.Array(InputPrimitiveType.String), isRequired: true, serializedName: "osType")]);
            var strategyProperty = InputFactory.Property("strategy", strategy, serializedName: "strategy");
            var properties = InputFactory.Model("TestUpdateRunProperties", properties: [strategyProperty]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("TestUpdateRunData", properties: [wrapper]);
            var accessor = getterOnly ? "get;" : "get; protected set;";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties, strategy],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        public class TestUpdateRunProperties
                        {
                            public System.Collections.Generic.IList<string> StrategyOsType { {{accessor}} }
                        }
                        public class TestUpdateRunData
                        {
                            public System.Collections.Generic.IList<string> StrategyOsType { get; set; }
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var assembly = Compile(plugin.Object);
            var intermediate = assembly.GetType("Samples.Models.TestUpdateRunProperties")!;
            var intermediateSetter = intermediate.GetProperty("StrategyOsType")!.SetMethod!;
            Assert.That(intermediateSetter.IsPublic, Is.False);
            Assert.That(getterOnly ? intermediateSetter.IsAssembly : intermediateSetter.IsFamilyOrAssembly, Is.True);
            var type = assembly.GetType("Samples.Models.TestUpdateRunData")!;
            var property = type.GetProperty("StrategyOsType");
            Assert.That(property?.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property!.SetValue(instance, new List<string> { "Linux" });
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("strategy").GetProperty("osType")[0].GetString(), Is.EqualTo("Linux"));
        }

        [Test]
        public void DistinctSafeFlattenedSiblingDoesNotClaimHistoricalName()
        {
            var first = InputFactory.Model("FirstProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var firstWrapper = InputFactory.Property("first", first, serializedName: "first");
            Flatten(firstWrapper);
            var network = InputFactory.Model("NetworkProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var networkWrapper = InputFactory.Property("network", network, serializedName: "network");
            var input = InputFactory.Model("TestData", properties: [firstWrapper, networkWrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, first, network],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    namespace Samples.Models
                    {
                        [System.AttributeUsage(System.AttributeTargets.Property)]
                        internal sealed class WirePathAttribute : System.Attribute { public WirePathAttribute(string path) { } }
                        public class TestData { [WirePath("first.osType")] public string OsType { get; set; } }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OsType"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("NetworkOSType"));
        }

        [Test]
        public void CustomPrivateWrapperCanForwardWithinOwningType()
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class CustomProperties { }
                    public partial class CustomData
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("Properties")]
                        internal CustomProperties Properties { get; private set; }
                    }
                }
                """;
            var properties = InputFactory.Model("CustomProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("CustomData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization]);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.CustomData")!;
            var property = type.GetProperty("OSType");
            Assert.That(property?.SetMethod?.IsPublic, Is.True);
            var instance = Activator.CreateInstance(type)!;
            property!.SetValue(instance, "Linux");
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("osType").GetString(), Is.EqualTo("Linux"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void CustomInitOnlyWrapperDoesNotGenerateInvalidForwarder(bool collection)
        {
            const string customization = """
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [System.AttributeUsage(System.AttributeTargets.Property)]
                    internal sealed class CodeGenMemberAttribute : System.Attribute { public CodeGenMemberAttribute(string name) { } }
                }
                namespace Samples.Models
                {
                    public partial class CustomProperties { }
                    public partial class CustomData
                    {
                        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("Properties")]
                        internal CustomProperties Properties { get; init; }
                    }
                }
                """;
            InputType leafType = collection ? InputFactory.Array(InputPrimitiveType.String) : InputPrimitiveType.String;
            var properties = InputFactory.Model("CustomProperties", properties:
                [InputFactory.Property("osType", leafType, isReadOnly: true, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("CustomData", properties: [wrapper]);
            var contractType = collection ? "System.Collections.Generic.IReadOnlyList<string>" : "string";
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $"namespace Samples.Models {{ public class CustomData {{ public {contractType} OsType {{ get; set; }} }} }}")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.CustomData")!;
            var property = type.GetProperty("OsType");
            Assert.That(property, Is.Not.Null);
            Assert.That(property!.SetMethod?.IsPublic, Is.Not.True);
        }

        [Test]
        public void FlattenedAcronymNameDoesNotCollideWithCustomMethod()
        {
            const string customization = "namespace Samples.Models { public partial class SqlVmData { public void OsType() { } } }";
            var properties = InputFactory.Model("SqlVirtualMachineProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", properties, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                customizationSources: [customization],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class SqlVmData { public string OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OSType"));
            Assert.That(Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.SqlVmData"), Is.Not.Null);
        }

        [Test]
        public void ChainedFlattenedAcronymRespectsExactInnerWrapperType()
        {
            var inner = InputFactory.Model("DBSystemUpdateProperties", properties:
                [InputFactory.Property("source", InputPrimitiveType.String, serializedName: "source")]);
            typeof(InputType).GetProperty(nameof(InputType.IsExactName))!.SetValue(inner, true);
            var innerWrapper = InputFactory.Property("properties", inner, serializedName: "properties");
            var details = InputFactory.Model("DetailContainer", properties: [innerWrapper]);
            var wrapper = InputFactory.Property("details", details, serializedName: "details");
            Flatten(wrapper);
            var input = InputFactory.Model("PatchData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, details, inner],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class PatchData { public string DbSystemUpdateSource { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("DBSystemUpdateSource"));
            Assert.That(model.Properties.Select(p => p.Name), Does.Not.Contain("DbSystemUpdateSource"));
        }

        [Test]
        public void SafeFlattenedAcronymKeepsExactWrapperAndHistoricalLeaf()
        {
            var inner = InputFactory.Model("EndpointProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("IpAddress", inner, serializedName: "endpoint");
            typeof(InputProperty).GetProperty(nameof(InputProperty.IsExactName))!.SetValue(wrapper, true);
            var input = InputFactory.Model("EndpointData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class EndpointData { public string IpAddressOsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("IpAddressOsType"));
        }

        [Test]
        public void FlattenedAcronymIgnoresAcceptedIncompatibleCanonicalContract()
        {
            var inner = InputFactory.Model("SqlVirtualMachineProperties", properties:
                [InputFactory.Property("osType", InputPrimitiveType.String, serializedName: "osType")]);
            var wrapper = InputFactory.Property("properties", inner, serializedName: "properties");
            Flatten(wrapper);
            var input = InputFactory.Model("SqlVmData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner],
                apiCompatBaseline: ApiCompatBaseline.Parse(["MembersMustExist : Member 'Samples.Models.SqlVmData.OSType.get()' does not exist in the implementation but it does exist in the contract."]),
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", "namespace Samples.Models { public class SqlVmData { public int OSType { get; set; } public string OsType { get; set; } } }")
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Select(p => p.Name), Does.Contain("OsType"));
        }

        // Regression for #63717: a required, getter-only outer wrapper must not
        // hide the mutable collection exposed by the inner model's lazy getter.
        [Test]
        public void RequiredGetterOnlyWrapperPreservesMutableFlattenedCollection()
        {
            var resourceId = InputFactory.Primitive.String("armResourceIdentifier", "Azure.Core.armResourceIdentifier");
            const InputModelTypeUsage usage = InputModelTypeUsage.Input | InputModelTypeUsage.Json;
            var requestProperties = InputFactory.Model("ReprotectRequestProperties", usage: usage, properties:
                [InputFactory.Property("selectedResourceIds", InputFactory.Array(resourceId))]);
            var reprotectContent = InputFactory.Model("ReprotectContent", usage: usage, properties:
                [InputFactory.Property("reprotectRequestProperties", requestProperties)]);
            var wrapper = InputFactory.Property("reprotectProperties", reprotectContent, isRequired: true);
            Flatten(wrapper);
            var input = InputFactory.Model("DrillRunReprotectContent", usage: usage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, reprotectContent, requestProperties]);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);

            var internalWrapper = model.Properties.Single(p => p.Name == "ReprotectProperties");
            Assert.That(internalWrapper.WireInfo!.IsRequired, Is.True);
            Assert.That(internalWrapper.Body.HasSetter, Is.False,
                "The regression requires a wrapper that callers cannot assign.");

            var assembly = Compile(plugin.Object);
            const string collectionName = "ReprotectRequestSelectedResourceIds";
            var innerType = assembly.GetType("Samples.Models.ReprotectContent")!;
            var inner = Activator.CreateInstance(innerType)!;
            Assert.That(innerType.GetProperty(collectionName)!.GetValue(inner), Is.Not.Null,
                "The inner model already exposes a usable lazy-initialized collection.");

            var outerType = assembly.GetType("Samples.Models.DrillRunReprotectContent")!;
            var outer = Activator.CreateInstance(outerType)!;
            var collectionProperty = outerType.GetProperty(collectionName)!;
            Assert.That(collectionProperty.SetMethod, Is.Null);
            var ids = (IList<ResourceIdentifier>?)collectionProperty.GetValue(outer);
            Assert.That(ids, Is.Not.Null,
                "Public parameterless construction must expose a mutable collection, not null.");
            var id = new ResourceIdentifier("/subscriptions/sub/resourceGroups/rg/providers/Test/widgets/a");
            ids!.Add(id);
            Assert.That(collectionProperty.GetValue(outer), Is.SameAs(ids));

            using var json = JsonDocument.Parse(ModelReaderWriter.Write(outer, new ModelReaderWriterOptions("W")));
            var serializedIds = json.RootElement.GetProperty("reprotectProperties")
                .GetProperty("reprotectRequestProperties").GetProperty("selectedResourceIds");
            Assert.That(serializedIds.GetArrayLength(), Is.EqualTo(1));
            Assert.That(serializedIds[0].GetString(), Is.EqualTo(id.ToString()));
        }

        [Test]
        public void CollectionWrapperInitializerPreservesOptionalAndSerializationStates([Values] bool wrapperRequired)
        {
            const InputModelTypeUsage usage = InputModelTypeUsage.Input | InputModelTypeUsage.Json;
            var requestProperties = InputFactory.Model("ReprotectRequestProperties", usage: usage, properties:
                [InputFactory.Property("selectedResourceIds", InputFactory.Array(InputPrimitiveType.String))]);
            var reprotectContent = InputFactory.Model("ReprotectContent", usage: usage, properties:
                [InputFactory.Property("reprotectRequestProperties", requestProperties)]);
            var wrapper = InputFactory.Property("reprotectProperties", reprotectContent, isRequired: wrapperRequired);
            Flatten(wrapper);
            var input = InputFactory.Model("DrillRunReprotectContent", usage: usage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, reprotectContent, requestProperties]);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);

            var wrapperBody = (AutoPropertyBody)model.Properties.Single(p => p.Name == "ReprotectProperties").Body;
            Assert.That(wrapperBody.InitializationExpression is not null, Is.EqualTo(wrapperRequired));
            var assembly = Compile(plugin.Object);
            var outerType = assembly.GetType("Samples.Models.DrillRunReprotectContent")!;
            var innerType = assembly.GetType("Samples.Models.ReprotectContent")!;
            var wrapperProperty = outerType.GetProperty("ReprotectProperties", BindingFlags.Instance | BindingFlags.NonPublic)!;
            if (!wrapperRequired)
            {
                var publiclyConstructed = Activator.CreateInstance(outerType)!;
                Assert.That(wrapperProperty.GetValue(publiclyConstructed), Is.Null);
                using var json = JsonDocument.Parse(ModelReaderWriter.Write(publiclyConstructed, new ModelReaderWriterOptions("W")));
                Assert.That(json.RootElement.TryGetProperty("reprotectProperties", out _), Is.False,
                    "The fix must not materialize an absent optional wrapper.");
            }

            // The full constructor used by deserialization must retain its supplied
            // wrapper state, including null, rather than the public-construction default.
            var fullConstructor = outerType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null,
                [innerType, typeof(IDictionary<string, BinaryData>)], null)!;
            Assert.That(fullConstructor, Is.Not.Null);
            var absent = fullConstructor.Invoke([null, null]);
            Assert.That(wrapperProperty.GetValue(absent), Is.Null);
            if (wrapperRequired)
            {
                Assert.That(outerType.GetProperty("ReprotectRequestSelectedResourceIds")!.GetValue(absent), Is.Null);
            }

            var inner = Activator.CreateInstance(innerType)!;
            var ids = (IList<string>)innerType.GetProperty("ReprotectRequestSelectedResourceIds")!.GetValue(inner)!;
            ids.Add("selected-resource");
            var populated = fullConstructor.Invoke([inner, null]);
            Assert.That(wrapperProperty.GetValue(populated), Is.SameAs(inner));
            using var populatedJson = JsonDocument.Parse(ModelReaderWriter.Write(populated, new ModelReaderWriterOptions("W")));
            Assert.That(populatedJson.RootElement.GetProperty("reprotectProperties")
                .GetProperty("reprotectRequestProperties").GetProperty("selectedResourceIds")[0].GetString(),
                Is.EqualTo("selected-resource"));
        }

        [Test]
        public void RequiredCollectionWrapperSupportsDirectFlattening(
            [Values] bool safeFlatten, [Values] bool dictionary)
        {
            var (plugin, model) = CreateCollectionWrapperModel(safeFlatten, dictionary, wrapperRequired: true);
            Visit(model);
            var wrapper = model.Properties.Single(p => p.Name == "CollectionProperties");
            Assert.That(wrapper.Body.HasSetter, Is.False);
            Assert.That(((AutoPropertyBody)wrapper.Body).InitializationExpression, Is.Not.Null);
            Assert.That(model.Constructors.Single(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public))
                .Signature.Parameters, Is.Empty);

            var type = Compile(plugin.Object).GetType("Samples.Models.CollectionContent")!;
            var instance = Activator.CreateInstance(type)!;
            var property = type.GetProperty(safeFlatten ? "CollectionItems" : "Items")!;
            var collection = property.GetValue(instance);
            Assert.That(collection, Is.Not.Null);
            Assert.That(property.SetMethod, Is.Null);
            if (dictionary)
            {
                ((IDictionary<string, string>)collection!).Add("key", "value");
            }
            else
            {
                ((IList<string>)collection!).Add("value");
            }
            Assert.That(property.GetValue(instance), Is.SameAs(collection));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
            var items = json.RootElement.GetProperty("collectionProperties").GetProperty("items");
            Assert.That(dictionary ? items.GetProperty("key").GetString() : items[0].GetString(), Is.EqualTo("value"));
        }

        [Test]
        public void CollectionWrapperJsonReaderPreservesWireState(
            [Values] bool safeFlatten, [Values] bool dictionary, [Values] bool wrapperRequired)
        {
            var (plugin, model) = CreateCollectionWrapperModel(safeFlatten, dictionary, wrapperRequired);
            Visit(model);
            var type = Compile(plugin.Object).GetType("Samples.Models.CollectionContent")!;
            var wrapper = type.GetProperty("CollectionProperties", BindingFlags.Instance | BindingFlags.NonPublic)!;
            var collection = type.GetProperty(safeFlatten ? "CollectionItems" : "Items")!;
            var options = new ModelReaderWriterOptions("J");
            var populated = dictionary
                ? """{"collectionProperties":{"items":{"key":"value"}}}"""
                : """{"collectionProperties":{"items":["value"]}}""";
            foreach (var payload in new[] { "{}", """{"collectionProperties":null}""", """{"collectionProperties":{}}""", populated })
            {
                var instance = ModelReaderWriter.Read(new BinaryData(payload), type, options)!;
                using var inputJson = JsonDocument.Parse(payload);
                var hasWrapper = inputJson.RootElement.TryGetProperty("collectionProperties", out var inputWrapper)
                    && inputWrapper.ValueKind != JsonValueKind.Null;
                Assert.That(wrapper.GetValue(instance) is not null, Is.EqualTo(hasWrapper), payload);
                if (hasWrapper)
                {
                    var value = collection.GetValue(instance);
                    Assert.That(value, Is.Not.Null, payload);
                    var expectedCount = payload == populated ? 1 : 0;
                    Assert.That(dictionary ? ((IDictionary<string, string>)value!).Count : ((IList<string>)value!).Count,
                        Is.EqualTo(expectedCount), payload);
                }
                else if (wrapperRequired)
                {
                    Assert.That(collection.GetValue(instance), Is.Null,
                        "Reading an absent required wrapper must retain the existing deserialization state.");
                }

                using var output = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
                var hasOutputWrapper = output.RootElement.TryGetProperty("collectionProperties", out var outputWrapper);
                Assert.That(hasOutputWrapper, Is.EqualTo(hasWrapper || wrapperRequired), payload);
                if (!hasWrapper && wrapperRequired)
                {
                    Assert.That(outputWrapper.ValueKind, Is.EqualTo(JsonValueKind.Null), payload);
                }
                else if (hasWrapper)
                {
                    Assert.That(outputWrapper.TryGetProperty("items", out var items), Is.EqualTo(payload == populated), payload);
                    if (payload == populated)
                    {
                        Assert.That(dictionary ? items.GetProperty("key").GetString() : items[0].GetString(), Is.EqualTo("value"));
                    }
                }
            }
        }

        [Test]
        public void PreservesHistoricalLeafType(
            [Values] bool safeFlatten, [Values] bool previouslyNullable, [Values] bool wrapperRequired, [Values] bool leafRequired)
        {
            var propertyName = safeFlatten ? "CapacitySize" : "Size";
            var (plugin, model, inner) = CreateCapacityModel(safeFlatten, wrapperRequired, leafRequired);
            var previous = new ContractView(model.Name);
            previous.ContractProperties =
            [
                new PropertyProvider(null, MethodSignatureModifiers.Public,
                    new CSharpType(typeof(long), isNullable: previouslyNullable), propertyName,
                    new AutoPropertyBody(true), previous)
            ];
            ModelTestHelper.SetLastContractView(model, previous);

            Visit(model);

            var property = model.Properties.Single(p => p.Name == propertyName);
            Assert.That(property.Type, Is.EqualTo(new CSharpType(typeof(long), isNullable: previouslyNullable)));
            Assert.That(inner.Properties.Single(p => p.Name == "Size").Type.IsNullable, Is.EqualTo(!leafRequired),
                "Preserving the public API must not change the wire property's requiredness.");
            var text = plugin.Object.GetWriter(model).Write().Content;
            Assert.That(text, previouslyNullable || leafRequired
                ? Does.Not.Contain("Capacity.Size.GetValueOrDefault()")
                : Does.Contain("Capacity.Size.GetValueOrDefault()"));

            var type = Compile(plugin.Object).GetType("Samples.Models.CapacityModel")!;
            var instance = Activator.CreateInstance(type, nonPublic: true)!;
            var leaf = type.GetProperty(propertyName)!;
            Assert.That(leaf.GetValue(instance), Is.EqualTo(previouslyNullable ? null : (object)0L),
                "An absent wrapper must be readable without changing its wire state.");
            Assert.That(type.GetProperty("Capacity", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(instance), Is.Null);
            if (!wrapperRequired)
            {
                using var absent = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
                Assert.That(absent.RootElement.TryGetProperty("capacity", out _), Is.False);
            }
            foreach (var value in new[] { 0L, long.MinValue, long.MaxValue, 37L })
            {
                leaf.SetValue(instance, value);
                Assert.That(leaf.GetValue(instance), Is.EqualTo(value));
                using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("J")));
                Assert.That(json.RootElement.GetProperty("capacity").GetProperty("size").GetInt64(), Is.EqualTo(value));
            }
            var roundTrip = ModelReaderWriter.Read(new BinaryData("""{"capacity":{"size":19}}"""), type, new ModelReaderWriterOptions("J"));
            Assert.That(leaf.GetValue(roundTrip), Is.EqualTo(19L));
            if (!leafRequired)
            {
                var omitted = ModelReaderWriter.Read(new BinaryData("""{"capacity":{}}"""), type, new ModelReaderWriterOptions("J"));
                Assert.That(leaf.GetValue(omitted), Is.EqualTo(previouslyNullable ? null : (object)0L));
                using var absentLeaf = JsonDocument.Parse(ModelReaderWriter.Write(omitted!, new ModelReaderWriterOptions("W")));
                Assert.That(absentLeaf.RootElement.GetProperty("capacity").TryGetProperty("size", out _), Is.False);
            }
            if (previouslyNullable && !leafRequired)
            {
                leaf.SetValue(instance, null);
                Assert.That(leaf.GetValue(instance), Is.Null);
                using var cleared = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
                Assert.That(cleared.RootElement.GetProperty("capacity").TryGetProperty("size", out _), Is.False);
            }
            else if (previouslyNullable)
            {
                leaf.SetValue(instance, null);
                Assert.That(leaf.GetValue(instance), Is.EqualTo(safeFlatten ? null : (object)37L),
                    "Keep existing null-setter semantics for required wire leaves: safe flatten clears its wrapper; explicit flatten preserves siblings.");
            }
        }

        [Test]
        public void RestoredConstructorPreservesExactTypesAndValues([Values] bool previouslyNullable, [Values] bool wrapperRequired)
        {
            var oldType = previouslyNullable ? "long?" : "long";
            var sku = InputFactory.Model("CapacitySku", properties:
            [
                InputFactory.Property("name", InputPrimitiveType.String, isRequired: true),
                InputFactory.Property("tier", InputPrimitiveType.String)
            ]);
            var properties = InputFactory.Model("CapacityProperties", properties:
            [
                InputFactory.Property("sku", sku, isRequired: true),
                InputFactory.Property("baseSizeTiB", InputPrimitiveType.Int64),
                InputFactory.Property("extendedCapacitySizeTiB", InputPrimitiveType.Int64)
            ]);
            var wrapper = InputFactory.Property("properties", properties, isRequired: wrapperRequired);
            Flatten(wrapper);
            var input = InputFactory.Model("CapacityData", properties:
            [
                InputFactory.Property("location", InputFactory.Primitive.String("azureLocation", "Azure.Core.azureLocation"), isRequired: true),
                wrapper
            ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, properties, sku],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        public partial class CapacityData
                        {
                            public CapacityData(Azure.Core.AzureLocation location, CapacitySku sku, {{oldType}} baseSizeTiB, {{oldType}} extendedCapacitySizeTiB) { }
                            public Azure.Core.AzureLocation Location { get; set; }
                            public CapacitySku Sku { get; set; }
                            public {{oldType}} BaseSizeTiB { get; set; }
                            public {{oldType}} ExtendedCapacitySizeTiB { get; set; }
                        }
                        public partial class CapacitySku { }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            var skuProvider = plugin.Object.TypeFactory.CreateModel(sku)!;
            Visit(model);
            ManagementMockHelpers.ProcessTypeForBackCompatibility(model);

            var constructors = model.Constructors.Where(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)).ToArray();
            Assert.That(constructors.Any(c => c.Signature.Parameters.Count == (wrapperRequired ? 2 : 1)), Is.True);
            var compatibility = constructors.Single(c => c.Signature.Parameters.Count == 4);
            Assert.That(compatibility.Signature.Parameters.Select(p => p.Type),
                Is.EqualTo(new CSharpType[] { typeof(AzureLocation), skuProvider.Type,
                    new(typeof(long), isNullable: previouslyNullable), new(typeof(long), isNullable: previouslyNullable) }),
                "Parameter count alone does not establish binary compatibility.");
            Assert.That(compatibility.Signature.Initializer!.IsBase, Is.False);
            Assert.That(compatibility.Signature.Initializer.Arguments.Select(a => a.ToDisplayString()),
                Is.EqualTo(wrapperRequired ? new[] { "location", "sku" } : new[] { "location" }));
            var body = compatibility.BodyStatements!.ToDisplayString();
            Assert.That(body, Does.Contain("BaseSizeTiB = baseSizeTiB"));
            Assert.That(body, Does.Contain("ExtendedCapacitySizeTiB = extendedCapacitySizeTiB"));

            var assembly = Compile(plugin.Object);
            var type = assembly.GetType("Samples.Models.CapacityData")!;
            var skuType = assembly.GetType("Samples.Models.CapacitySku")!;
            var skuInstance = Activator.CreateInstance(skuType, ["Premium"])!;
            var valueType = previouslyNullable ? typeof(long?) : typeof(long);
            var constructor = type.GetConstructor([typeof(AzureLocation), skuType, valueType, valueType]);
            Assert.That(constructor, Is.Not.Null);
            var instance = constructor!.Invoke([AzureLocation.WestUS, skuInstance, 23L, 41L]);
            Assert.That(type.GetProperty("Location")!.GetValue(instance), Is.EqualTo(AzureLocation.WestUS));
            Assert.That(type.GetProperty("Sku")!.GetValue(instance), Is.SameAs(skuInstance));
            Assert.That(type.GetProperty("BaseSizeTiB")!.GetValue(instance), Is.EqualTo(23L));
            Assert.That(type.GetProperty("ExtendedCapacitySizeTiB")!.GetValue(instance), Is.EqualTo(41L));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("J")));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("baseSizeTiB").GetInt64(), Is.EqualTo(23L));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("extendedCapacitySizeTiB").GetInt64(), Is.EqualTo(41L));
            if (previouslyNullable)
            {
                var omitted = constructor.Invoke([AzureLocation.WestUS, skuInstance, null, null]);
                Assert.That(type.GetProperty("BaseSizeTiB")!.GetValue(omitted), Is.Null);
                Assert.That(type.GetProperty("ExtendedCapacitySizeTiB")!.GetValue(omitted), Is.Null);
            }
        }

        [Test]
        public void SafeFlattenRestoresExactConstructor([Values] bool previouslyNullable, [Values] bool wrapperRequired)
        {
            var oldType = previouslyNullable ? "long?" : "long";
            var inner = InputFactory.Model("CapacityProperties", properties: [InputFactory.Property("size", InputPrimitiveType.Int64)]);
            var input = InputFactory.Model("CapacityModel", properties:
            [
                InputFactory.Property("location", InputPrimitiveType.String, isRequired: true),
                InputFactory.Property("capacity", inner, isRequired: wrapperRequired)
            ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        public partial class CapacityModel
                        {
                            public CapacityModel(string location, {{oldType}} capacitySize) { }
                            public string Location { get; set; }
                            public {{oldType}} CapacitySize { get; set; }
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            ManagementMockHelpers.ProcessTypeForBackCompatibility(model);
            var type = Compile(plugin.Object).GetType("Samples.Models.CapacityModel")!;
            var constructor = type.GetConstructor([typeof(string), previouslyNullable ? typeof(long?) : typeof(long)]);
            Assert.That(constructor, Is.Not.Null);
            var instance = constructor!.Invoke(["westus", 31L]);
            Assert.That(type.GetProperty("Location")!.GetValue(instance), Is.EqualTo("westus"));
            Assert.That(type.GetProperty("CapacitySize")!.GetValue(instance), Is.EqualTo(31L));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("J")));
            Assert.That(json.RootElement.GetProperty("capacity").GetProperty("size").GetInt64(), Is.EqualTo(31L));
        }

        [Test]
        public void MixedHistoricalConstructorNullabilityPreservesAvailableSignatures(
            [Values] bool safeFlatten, [Values] bool wrapperRequired, [Values] bool nullableFirst,
            [Values("none", "custom", "partial-custom", "baseline", "baseline-nullable")] string resolution)
        {
            var name = safeFlatten ? "CapacitySize" : "Size";
            var parameterName = safeFlatten ? "capacitySize" : "size";
            var nonNullableConstructor = $"public CapacityModel(string location, long {parameterName}) {{ }}";
            var nullableConstructor = $"public CapacityModel(string location, long? {parameterName}) {{ }}";
            var inner = InputFactory.Model("CapacityProperties", properties: [InputFactory.Property("size", InputPrimitiveType.Int64)]);
            var wrapper = InputFactory.Property("capacity", inner, isRequired: wrapperRequired);
            if (!safeFlatten)
            {
                Flatten(wrapper);
            }
            var input = InputFactory.Model("CapacityModel", properties:
            [
                InputFactory.Property("location", InputPrimitiveType.String, isRequired: true),
                wrapper
            ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, inner],
                apiCompatBaseline: resolution is "baseline" or "baseline-nullable" ? ApiCompatBaseline.Parse(
                    [$"MembersMustExist : Member 'Samples.Models.CapacityModel..ctor(System.String, {(resolution == "baseline" ? "System.Int64" : "System.Nullable<System.Int64>")})' does not exist in the implementation but it does exist in the contract."]) : null,
                customizationSources: resolution is "custom" or "partial-custom"
                    ? [$$"""
                        namespace Samples.Models
                        {
                            public partial class CapacityModel
                            {
                                public CapacityModel(string location, long {{parameterName}}) : this(location)
                                {
                                    {{name}} = {{parameterName}};
                                }
                                {{(resolution == "custom" ? $"public CapacityModel(string location, long? {parameterName}) : this(location) {{ {name} = {parameterName}; }}" : "")}}
                            }
                        }
                        """]
                    : null,
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        public partial class CapacityModel
                        {
                            {{(nullableFirst ? nullableConstructor : nonNullableConstructor)}}
                            {{(nullableFirst ? nonNullableConstructor : nullableConstructor)}}
                            public string Location { get; set; }
                            public long? {{name}} { get; set; }
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            using var diagnostics = CaptureDiagnostics(plugin);
            Visit(model);
            ManagementMockHelpers.ProcessTypeForBackCompatibility(model);
            _ = plugin.Object.GetWriter(model).Write();

            var constructors = model.Constructors.Concat(model.CustomCodeView?.Constructors ?? [])
                .Where(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)
                    && c.Signature.Parameters.Count == 2).ToArray();
            Assert.That(constructors.Any(c => c.Signature.Parameters[1].Type.Equals(new CSharpType(typeof(long?)))), Is.EqualTo(resolution is not ("partial-custom" or "baseline-nullable")));
            Assert.That(constructors.Any(c => c.Signature.Parameters[1].Type.Equals(new CSharpType(typeof(long)))), Is.EqualTo(resolution is not "baseline"));
            if (resolution == "none")
            {
                var type = Compile(plugin.Object).GetType("Samples.Models.CapacityModel")!;
                foreach (object? value in new object?[] { null, 31L })
                {
                    var instance = type.GetConstructor([typeof(string), typeof(long?)])!.Invoke(["westus", value]);
                    Assert.That(type.GetProperty(name)!.GetValue(instance), Is.EqualTo(value));
                }
                var nonNullableInstance = type.GetConstructor([typeof(string), typeof(long)])!.Invoke(["westus", 31L]);
                Assert.That(type.GetProperty(name)!.GetValue(nonNullableInstance), Is.EqualTo(31L));
            }
            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
        }

        [Test]
        public void HistoricalOverloadRestorationPreservesInitializerBinding(
            [Values] bool customInitializer, [Values] bool ambiguousTargets)
        {
            var defaultArgument = ambiguousTargets ? "default(long?)" : "default";
            var customization = customInitializer ? $$"""
                namespace Samples.Models
                {
                    public partial class CapacityModel
                    {
                        public CapacityModel() : this({{defaultArgument}}) { }
                    }
                }
                """ : null;
            var inner = InputFactory.Model("CapacityProperties", properties: [InputFactory.Property("size", InputPrimitiveType.Int64)]);
            var wrapper = InputFactory.Property("capacity", inner);
            Flatten(wrapper);
            var input = InputFactory.Model("CapacityModel", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner],
                customizationSources: customization is null ? null : [customization]);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);

            var original = model.Constructors.ToArray();
            var constructors = original.Where(c => !customInitializer || c.Signature.Parameters.Count != 0).ToList();
            if (!customInitializer)
            {
                var parameterless = constructors.Single(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)
                    && c.Signature.Parameters.Count == 0);
                var signature = parameterless.Signature;
                ValueExpression argument = ambiguousTargets ? new CastExpression(Default, typeof(long?)) : Default;
                parameterless.Update(signature: new ConstructorSignature(signature.Type, signature.Description,
                    signature.Modifiers, signature.Parameters, signature.Attributes, new ConstructorInitializer(false, [argument])));
            }
            var size = new ParameterProvider("size", $"", typeof(long?));
            constructors.Add(new ConstructorProvider(
                new ConstructorSignature(model.Type, null, MethodSignatureModifiers.Public, [size]),
                new ExpressionStatement(new AssignmentExpression(new MemberExpression(This, "Size"), size)), model));
            if (ambiguousTargets)
            {
                constructors.Add(new ConstructorProvider(
                    new ConstructorSignature(model.Type, null, MethodSignatureModifiers.Public,
                        [new ParameterProvider("other", $"", typeof(string))]), MethodBodyStatement.Empty, model));
            }
            var previous = new ContractView(model.Name);
            previous.ContractConstructors =
            [
                new ConstructorProvider(new ConstructorSignature(previous.Type, null, MethodSignatureModifiers.Public,
                    [new ParameterProvider("size", $"", typeof(long?))]), MethodBodyStatement.Empty, previous),
                new ConstructorProvider(new ConstructorSignature(previous.Type, null, MethodSignatureModifiers.Public,
                    [new ParameterProvider("size", $"", typeof(long))]), MethodBodyStatement.Empty, previous)
            ];
            ModelTestHelper.SetLastContractView(model, previous);

            model.Update(constructors: ConstructorProviderHelpers.RestoreValueTypeNullabilityOverloads(model, original, constructors).ToArray());
            var type = Compile(plugin.Object, customizationSource: customization).GetType("Samples.Models.CapacityModel")!;
            var property = type.GetProperty("Size")!;
            Assert.That(property.GetValue(Activator.CreateInstance(type)), Is.Null,
                "Adding an overload must not change this(default) from a nullable default to zero.");
            foreach (object? value in new object?[] { null, 31L })
            {
                Assert.That(property.GetValue(type.GetConstructor([typeof(long?)])!.Invoke([value])), Is.EqualTo(value));
            }
            var restored = type.GetConstructors().SingleOrDefault(c => c.GetParameters().Length == 1
                && c.GetParameters()[0].ParameterType == typeof(long));
            Assert.That(restored is not null, Is.EqualTo(!customInitializer && !ambiguousTargets));
            if (restored is not null)
            {
                Assert.That(property.GetValue(restored.Invoke([31L])), Is.EqualTo(31L));
            }
        }

        [Test]
        public void MixedHistoricalConstructorNullabilityRestoresCrossedSignatures([Values] bool nullableFirst)
        {
            var inner = InputFactory.Model("CapacityProperties", properties:
            [
                InputFactory.Property("size", InputPrimitiveType.Int64),
                InputFactory.Property("count", InputPrimitiveType.Int32)
            ]);
            var wrapper = InputFactory.Property("capacity", inner);
            Flatten(wrapper);
            var input = InputFactory.Model("CapacityModel", properties:
            [
                InputFactory.Property("location", InputPrimitiveType.String, isRequired: true),
                wrapper
            ]);
            const string nullableSizeConstructor = "public CapacityModel(string location, long? size, int count) { }";
            const string nullableCountConstructor = "public CapacityModel(string location, long size, int? count) { }";
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, inner],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        public partial class CapacityModel
                        {
                            {{(nullableFirst ? nullableSizeConstructor : nullableCountConstructor)}}
                            {{(nullableFirst ? nullableCountConstructor : nullableSizeConstructor)}}
                            public string Location { get; set; }
                            public long? Size { get; set; }
                            public int? Count { get; set; }
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            ManagementMockHelpers.ProcessTypeForBackCompatibility(model);
            var type = Compile(plugin.Object).GetType("Samples.Models.CapacityModel")!;

            var nullableSize = type.GetConstructor([typeof(string), typeof(long?), typeof(int)])!.Invoke(["westus", null, 5]);
            Assert.That(type.GetProperty("Size")!.GetValue(nullableSize), Is.Null);
            Assert.That(type.GetProperty("Count")!.GetValue(nullableSize), Is.EqualTo(5));
            var nullableCount = type.GetConstructor([typeof(string), typeof(long), typeof(int?)])!.Invoke(["westus", 31L, null]);
            Assert.That(type.GetProperty("Size")!.GetValue(nullableCount), Is.EqualTo(31L));
            Assert.That(type.GetProperty("Count")!.GetValue(nullableCount), Is.Null);
            Assert.That(type.GetConstructor([typeof(string), typeof(long?), typeof(int?)]), Is.Null);
        }

        [Test]
        public void InternalHistoricalLeafDoesNotOverrideCurrentType([Values] bool safeFlatten)
        {
            var (plugin, model, _) = CreateCapacityModel(safeFlatten, wrapperRequired: false);
            var previous = new ContractView(model.Name);
            var name = safeFlatten ? "CapacitySize" : "Size";
            previous.ContractProperties =
            [
                new PropertyProvider(null, MethodSignatureModifiers.Internal, typeof(long), name, new AutoPropertyBody(true), previous)
            ];
            ModelTestHelper.SetLastContractView(model, previous);
            using var diagnostics = CaptureDiagnostics(plugin);
            Visit(model);
            _ = plugin.Object.GetWriter(model).Write();
            Assert.That(model.Properties.Single(p => p.Name == name).Type, Is.EqualTo(new CSharpType(typeof(long?))));
            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
        }

        [Test]
        public void FlattenedEnumWithSamePublicTypeDoesNotRequireMapping()
        {
            var status = InputFactory.StringEnum("ProvisioningState", [("Ready", "Ready")],
                isExtensible: true, clientNamespace: "Samples.Models");
            var inner = InputFactory.Model("StoreProperties", properties: [InputFactory.Property("provisioningState", status)]);
            var wrapper = InputFactory.Property("properties", inner);
            Flatten(wrapper);
            var input = InputFactory.Model("StoreData", properties: [wrapper]);
            const string propertyName = "ProvisioningState";
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, inner],
                inputEnums: () => [status],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        public readonly partial struct ProvisioningState { }
                        public partial class StoreData
                        {
                            public ProvisioningState? {{propertyName}} { get; set; }
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            using var diagnostics = CaptureDiagnostics(plugin);
            Visit(model);

            var previousType = model.LastContractView!.Properties.Single(p => p.Name == propertyName).Type;
            var currentType = model.Properties.Single(p => p.Name == propertyName).Type;
            Assert.That(currentType.ToString(), Is.EqualTo(previousType.ToString()));
            Assert.That(currentType.Equals(previousType), Is.False,
                "The regression requires distinct generator type metadata for the same public C# type.");
            _ = plugin.Object.GetWriter(model).Write();
            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("Cannot preserve flattened property"));
            Assert.That(Compile(plugin.Object).GetType("Samples.Models.StoreData"), Is.Not.Null);
        }

        [Test]
        public void FlattenedGenericLeafNullabilityDistinguishesValueTypesButNotReferences(
            [Values] bool valueType, [Values] bool nested)
        {
            var leaf = valueType ? (InputType)InputPrimitiveType.Int32 : InputPrimitiveType.String;
            var items = nested ? InputFactory.Array(InputFactory.Array(leaf)) : InputFactory.Array(leaf);
            var inner = InputFactory.Model("ListProperties", properties: [InputFactory.Property("items", items)]);
            var wrapper = InputFactory.Property("properties", inner);
            Flatten(wrapper);
            var input = InputFactory.Model("ListData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner]);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            var innerModel = plugin.Object.TypeFactory.CreateModel(inner)!;
            var oldType = ChangeLeafNullability(innerModel.Properties.Single(p => p.Name == "Items").Type).WithNullable(true);
            var previous = new ContractView(model.Name);
            previous.ContractProperties =
            [
                new PropertyProvider(null, MethodSignatureModifiers.Public, oldType, "Items", new AutoPropertyBody(true), previous)
            ];
            ModelTestHelper.SetLastContractView(model, previous);

            using var diagnostics = CaptureDiagnostics(plugin);
            Visit(model);
            var currentType = model.Properties.Single(p => p.Name == "Items").Type;
            Assert.That(oldType.FullyQualifiedName, Is.EqualTo(currentType.FullyQualifiedName));
            Assert.That(oldType.HasSamePublicType(currentType), Is.EqualTo(!valueType),
                "Nullable reference annotations do not change generic type identity, but Nullable<T> does.");
            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
        }

        private static CSharpType ChangeLeafNullability(CSharpType type)
            => type.Arguments.Count == 0
                ? type.WithNullable(!type.IsNullable)
                : new CSharpType(type.FrameworkType, type.IsNullable, type.Arguments.Select(ChangeLeafNullability).ToArray());

        [Test]
        public void HistoricalConstructorComparesNestedReferenceAnnotationsButKeepsValueNullability(
            [Values] bool nullableReference, [Values] bool nullableValue)
        {
            var (plugin, model, _) = CreateCapacityModel(safeFlatten: false, wrapperRequired: false);
            Visit(model);
            var flattened = model.Properties.OfType<FlattenedPropertyProvider>().Single(p => p.Name == "Size");
            var previous = new ContractView(model.Name);
            var currentKeyType = new CSharpType(typeof(KeyValuePair<,>), typeof(string), typeof(int));
            var previousKeyType = new CSharpType(typeof(KeyValuePair<,>),
                new CSharpType(typeof(string), isNullable: nullableReference),
                new CSharpType(typeof(int), isNullable: nullableValue));
            var leaf = flattened.AsParameter;
            var currentParameters = new[] { leaf, new ParameterProvider("key", $"", currentKeyType, Default) };
            var previousParameters = new[] { leaf, new ParameterProvider("key", $"", previousKeyType, Default) };
            model.Update(constructors:
            [
                new ConstructorProvider(new ConstructorSignature(model.Type, null, MethodSignatureModifiers.Public, currentParameters),
                    MethodBodyStatement.Empty, model)
            ]);
            previous.ContractConstructors =
            [
                new ConstructorProvider(new ConstructorSignature(previous.Type, null, MethodSignatureModifiers.Public, previousParameters),
                    MethodBodyStatement.Empty, previous)
            ];
            ModelTestHelper.SetLastContractView(model, previous);

            Assert.That(currentKeyType.HasSamePublicType(previousKeyType), Is.EqualTo(!nullableValue),
                "Only nullable value-type arguments change a constructed generic type's CLR signature.");
        }

        [Test]
        public void DerivedWithOwnFlattenedPropertyCompilesAndInitializesFlattenedBase()
        {
            var state = InputFactory.StringEnum("DataTypeState", [("Enabled", "Enabled"), ("Disabled", "Disabled")],
                isExtensible: true, clientNamespace: "Samples.Models");
            var common = InputFactory.Model("DataConnectorDataTypeCommon", properties:
                [InputFactory.Property("state", state, isRequired: true)]);
            var baseModel = InputFactory.Model("AlertsDataTypeOfDataConnector", properties:
                [InputFactory.Property("alerts", common, isRequired: true)]);
            var derivedModel = InputFactory.Model("McasDataConnectorDataTypes", baseModel: baseModel, properties:
                [InputFactory.Property("discoveryLogs", common)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [common, baseModel, derivedModel], inputEnums: () => [state]);
            var baseProvider = plugin.Object.TypeFactory.CreateModel(baseModel)!;
            var derivedProvider = plugin.Object.TypeFactory.CreateModel(derivedModel)!;
            _ = baseProvider.Constructors;
            _ = derivedProvider.Constructors;
            Visit(derivedProvider);

            var assembly = Compile(plugin.Object);
            var stateType = assembly.GetType("Samples.Models.DataTypeState")!;
            var derivedType = assembly.GetType("Samples.Models.McasDataConnectorDataTypes")!;
            var constructor = derivedType.GetConstructor([stateType]);
            Assert.That(constructor, Is.Not.Null);
            var enabled = Activator.CreateInstance(stateType, ["Enabled"]);
            var instance = constructor!.Invoke([enabled]);
            Assert.That(derivedType.GetProperty("AlertsState")!.GetValue(instance)!.ToString(), Is.EqualTo("Enabled"));
            var disabled = Activator.CreateInstance(stateType, ["Disabled"]);
            derivedType.GetProperty("DiscoveryLogsState")!.SetValue(instance, disabled);
            Assert.That(derivedType.GetProperty("DiscoveryLogsState")!.GetValue(instance)!.ToString(), Is.EqualTo("Disabled"));
        }

        [Test]
        public void RestoredFlattenedEnumConstructorDoesNotRequireMapping()
        {
            var status = InputFactory.StringEnum("ProvisioningState", [("Ready", "Ready")],
                isExtensible: true, clientNamespace: "Samples.Models");
            var inner = InputFactory.Model("StoreProperties", properties:
                [InputFactory.Property("provisioningState", status, isRequired: true)]);
            var wrapper = InputFactory.Property("properties", inner, isRequired: true);
            Flatten(wrapper);
            var input = InputFactory.Model("StoreData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, inner],
                inputEnums: () => [status],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    namespace Samples.Models
                    {
                        public readonly partial struct ProvisioningState { }
                        public partial class StoreData
                        {
                            public StoreData(ProvisioningState provisioningState) { }
                            public ProvisioningState ProvisioningState { get; set; }
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            using var diagnostics = CaptureDiagnostics(plugin);
            Visit(model);
            ManagementMockHelpers.ProcessTypeForBackCompatibility(model);
            _ = plugin.Object.GetWriter(model).Write();

            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("Cannot preserve historical constructor"));
            Assert.That(model.Constructors.Any(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)
                && c.Signature.Parameters.Count == 1
                && c.Signature.Parameters[0].Type.ToString() == "global::Samples.Models.ProvisioningState"), Is.True);
            var assembly = Compile(plugin.Object);
            var storeType = assembly.GetType("Samples.Models.StoreData")!;
            var statusType = assembly.GetType("Samples.Models.ProvisioningState")!;
            Assert.That(storeType.GetConstructor([statusType]), Is.Not.Null);
        }

        [Test]
        public void FlattenedTypeChangedFromEnumToStructIsNotConsideredSamePublicType()
        {
            var status = InputFactory.StringEnum("ProvisioningState", [("Ready", "Ready")],
                isExtensible: true, clientNamespace: "Samples.Models");
            var inner = InputFactory.Model("StoreProperties", properties: [InputFactory.Property("provisioningState", status)]);
            var wrapper = InputFactory.Property("properties", inner);
            Flatten(wrapper);
            var input = InputFactory.Model("StoreData", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, inner],
                inputEnums: () => [status],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    namespace Samples.Models
                    {
                        public enum ProvisioningState { Ready }
                        public partial class StoreData
                        {
                            public ProvisioningState? ProvisioningState { get; set; }
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            using var diagnostics = CaptureDiagnostics(plugin);
            Visit(model);

            var previousType = model.LastContractView!.Properties.Single(p => p.Name == "ProvisioningState").Type;
            var currentType = model.Properties.Single(p => p.Name == "ProvisioningState").Type;
            Assert.That(previousType.ToString(), Is.EqualTo(currentType.ToString()));
            Assert.That(previousType.IsStruct, Is.False);
            Assert.That(currentType.IsStruct, Is.True);
            Assert.That(previousType.HasSamePublicType(currentType), Is.False);
            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
        }

        [Test]
        public void IncompatibleLeafTypeDoesNotBlockGeneration([Values] bool safeFlatten, [Values] bool customized)
        {
            var (plugin, model, _) = CreateCapacityModel(safeFlatten, wrapperRequired: false);
            var previous = new ContractView(model.Name);
            var name = safeFlatten ? "CapacitySize" : "Size";
            previous.ContractProperties =
            [
                new PropertyProvider(null, MethodSignatureModifiers.Public, typeof(Uri), name, new AutoPropertyBody(true), previous)
            ];
            ModelTestHelper.SetLastContractView(model, previous);
            if (customized)
            {
                var custom = new ContractView(model.Name);
                custom.ContractProperties =
                [
                    new PropertyProvider(null, MethodSignatureModifiers.Public, typeof(Uri), name, new AutoPropertyBody(true), custom)
                ];
                ManagementMockHelpers.SetCustomCodeView(model, custom);
            }
            using var diagnostics = CaptureDiagnostics(plugin);
            Visit(model);
            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
            if (!customized)
            {
                Assert.That(model.Properties.Single(p => p.Name == name).Type, Is.Not.EqualTo(new CSharpType(typeof(Uri))));
            }
        }

        [Test]
        public void LostSafeFlattenedLeafDoesNotBlockGeneration([Values(false, true)] bool customProperty, [Values(false, true)] bool acceptedRemoval)
        {
            var entries = InputFactory.Model("ManagedByResources", properties:
            [
                InputFactory.Property("clientId", InputPrimitiveType.String),
                InputFactory.Property("resourceIds", InputFactory.Array(InputPrimitiveType.String))
            ]);
            var input = InputFactory.Model("VolumePatch", properties:
            [
                InputFactory.Property("managedBy", InputFactory.Array(entries))
            ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, entries],
                apiCompatBaseline: acceptedRemoval
                    ? ApiCompatBaseline.Parse(["MembersMustExist : Member 'Samples.Models.VolumePatch.ManagedByResourceId.get()' does not exist in the implementation but it does exist in the contract."])
                    : null,
                customizationSources: customProperty
                    ? ["namespace Samples.Models { public partial class VolumePatch { public Azure.Core.ResourceIdentifier ManagedByResourceId { get; set; } } }"]
                    : null,
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    namespace Samples.Models
                    {
                        public partial class VolumePatch
                        {
                            public Azure.Core.ResourceIdentifier ManagedByResourceId { get; set; }
                        }
                    }
                    """)
                ]));
            using var diagnostics = CaptureDiagnostics(plugin);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            _ = plugin.Object.GetWriter(model).Write();

            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
            Assert.That(model.Properties.Any(p => p.Name == "ManagedByResourceId"), Is.False,
                "The generator cannot invent a mapping when the wire shape changes.");
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FactoryPreservesNestedValuesWithoutGuessingChangedShapes(bool changedToArray)
        {
            var managed = InputFactory.Model("ManagedByInfo", properties: changedToArray
                ? [InputFactory.Property("clientId", InputPrimitiveType.String), InputFactory.Property("resourceIds", InputFactory.Array(InputPrimitiveType.String))]
                : [InputFactory.Property("resourceId", InputFactory.Primitive.String("armResourceIdentifier", "Azure.Core.armResourceIdentifier"))]);
            var properties = InputFactory.Model("VolumeProperties", properties:
            [
                InputFactory.Property("sizeGiB", InputPrimitiveType.Int64),
                InputFactory.Property("managedBy", changedToArray ? InputFactory.Array(managed) : managed)
            ]);
            var wrapper = InputFactory.Property("properties", properties);
            Flatten(wrapper);
            var input = InputFactory.Model("VolumePatch", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties, managed],
                configurationJson: """{"package-name":"Samples"}""");
            using var diagnostics = CaptureDiagnostics(plugin);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var previous = new ContractView(factory.Name);
            var signature = new MethodSignature("VolumePatch", null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static, model.Type, null,
                [
                    new ParameterProvider("sizeGiB", $"", typeof(long?), Default),
                    new ParameterProvider("managedByResourceId", $"", typeof(ResourceIdentifier), Default)
                ]);
            previous.ContractMethods = [new MethodProvider(signature, MethodBodyStatement.Empty, previous)];
            ModelTestHelper.SetLastContractView(factory, previous);
            ManagementMockHelpers.ProcessTypeForBackCompatibility(factory);
            _ = plugin.Object.GetWriter(factory).Write();

            var messages = Encoding.UTF8.GetString(diagnostics.ToArray());
            if (changedToArray)
            {
                var compatibility = factory.Methods.Single(ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod);
                var body = compatibility.BodyStatements!.ToDisplayString();
                Assert.That(body, Does.Contain("sizeGiB"));
                Assert.That(body, Does.Not.Contain("managedByResourceId"),
                    "A scalar resource ID cannot be mapped to a list of managed resources.");
                Assert.That(messages, Does.Not.Contain("\"severity\":\"error\""));
            }
            else
            {
                Assert.That(messages, Does.Not.Contain("\"severity\":\"error\""));
                var compatibility = factory.Methods.Single(ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod);
                var body = compatibility.BodyStatements!.ToDisplayString();
                Assert.That(body, Does.Contain("managedByResourceId"));
                Assert.That(body, Does.Contain("new global::Samples.Models.ManagedByInfo(managedByResourceId"));
                Assert.That(body, Does.Contain("sizeGiB"));
                var assembly = Compile(plugin.Object, includeFactory: true);
                var method = assembly.GetType(factory.Type.FullyQualifiedName)!.GetMethod("VolumePatch", [typeof(long?), typeof(ResourceIdentifier)])!;
                var id = new ResourceIdentifier("/subscriptions/sub/resourceGroups/rg/providers/Test/widgets/a");
                var result = method.Invoke(null, [55L, id])!;
                Assert.That(result.GetType().GetProperty("SizeGiB")!.GetValue(result), Is.EqualTo(55L));
                Assert.That(result.GetType().GetProperty("ManagedByResourceId")!.GetValue(result),
                    Is.EqualTo(id));
                using var json = JsonDocument.Parse(ModelReaderWriter.Write(result, new ModelReaderWriterOptions("J")));
                Assert.That(json.RootElement.GetProperty("properties").GetProperty("managedBy").GetProperty("resourceId").GetString(),
                    Is.EqualTo("/subscriptions/sub/resourceGroups/rg/providers/Test/widgets/a"));
                var omitted = method.Invoke(null, [null, null])!;
                Assert.That(omitted.GetType().GetProperty("ManagedByResourceId")!.GetValue(omitted), Is.Null);
            }
        }

        [Test]
        public void FactoryRetainsNonNullableValueTypeOverloadWhenFlattenedWrapperIsOptional()
        {
            // ProviderHub's shipped ResourceTypeEndpointBase factory takes FeaturesPolicy, while
            // flattening an optional properties wrapper now emits FeaturesPolicy?. Both CLR
            // signatures must remain available; the old overload must still forward its value.
            var policy = InputFactory.StringEnum("FeaturesPolicy", [("Required", "Required")],
                isExtensible: true, clientNamespace: "Samples.Models");
            var properties = InputFactory.Model("EndpointProperties", properties:
                [InputFactory.Property("requiredFeaturesPolicy", policy, isRequired: true)]);
            var wrapper = InputFactory.Property("properties", properties);
            Flatten(wrapper);
            var input = InputFactory.Model("ResourceTypeEndpointBase", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, properties], inputEnums: () => [policy],
                configurationJson: """{"package-name":"Samples"}""",
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    namespace Samples.Models
                    {
                        public readonly partial struct FeaturesPolicy { }
                        public partial class ResourceTypeEndpointBase { }
                    }
                    namespace Samples
                    {
                        public static partial class SamplesModelFactory
                        {
                            public static Samples.Models.ResourceTypeEndpointBase ResourceTypeEndpointBase(
                                Samples.Models.FeaturesPolicy requiredFeaturesPolicy = default) => default;
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            Assert.That(factory.LastContractView, Is.Not.Null);
            Assert.That(factory.LastContractView!.Methods.Single().Signature.Parameters.Single().Type.IsNullable,
                Is.False);
            Assert.That(factory.Methods.Where(m => m.Signature.Name == "ResourceTypeEndpointBase")
                    .Select(m => m.Signature.Parameters.Single().Type.IsNullable),
                Is.EquivalentTo(new[] { true }), "The primary factory should reflect the lifted leaf.");
            var visitType = typeof(LibraryVisitor).GetMethod("VisitTypeCore", BindingFlags.NonPublic | BindingFlags.Instance)!;
            foreach (var visitor in plugin.Object.Visitors)
            {
                visitType.Invoke(visitor, [factory]);
            }
            ManagementMockHelpers.ProcessTypeForBackCompatibility(factory);
            _ = plugin.Object.GetWriter(factory).Write();

            var overloads = factory.Methods.Where(m => m.Signature.Name == "ResourceTypeEndpointBase").ToArray();
            Assert.That(overloads.Any(m => !m.Signature.Parameters.Single().Type.IsNullable), Is.True,
                "A nullable value-type factory parameter must not replace a shipped non-nullable overload.");
            var oldOverload = overloads.Single(m => !m.Signature.Parameters.Single().Type.IsNullable);
            Assert.That(oldOverload.BodyStatements!.ToDisplayString(), Does.Contain("requiredFeaturesPolicy"));
        }

        [Test]
        public void LiftedFactoryDoesNotProduceAmbiguousOptionalOverloads()
        {
            // With optional parameters, both F(T = default) and F(T? = default)
            // match a call to F(). Replacing the primary method retains the GA
            // signature without introducing a source-level ambiguity.
            var policy = InputFactory.StringEnum("FeaturesPolicy", [("Required", "Required")],
                isExtensible: true, clientNamespace: "Samples.Models");
            var properties = InputFactory.Model("EndpointProperties", properties:
                [InputFactory.Property("requiredFeaturesPolicy", policy, isRequired: true)]);
            var wrapper = InputFactory.Property("properties", properties);
            Flatten(wrapper);
            var input = InputFactory.Model("ResourceTypeEndpointBase", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, properties], inputEnums: () => [policy],
                configurationJson: """{"package-name":"Samples"}""",
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    namespace Samples.Models
                    {
                        public readonly partial struct FeaturesPolicy { }
                        public partial class ResourceTypeEndpointBase { }
                    }
                    namespace Samples
                    {
                        public static partial class SamplesModelFactory
                        {
                            public static Samples.Models.ResourceTypeEndpointBase ResourceTypeEndpointBase(
                                Samples.Models.FeaturesPolicy requiredFeaturesPolicy = default) => default;
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var visitType = typeof(LibraryVisitor).GetMethod("VisitTypeCore", BindingFlags.NonPublic | BindingFlags.Instance)!;
            foreach (var visitor in plugin.Object.Visitors)
            {
                visitType.Invoke(visitor, [factory]);
            }
            ManagementMockHelpers.ProcessTypeForBackCompatibility(factory);

            var overloads = factory.Methods.Where(m => m.Signature.Name == "ResourceTypeEndpointBase").ToArray();
            Assert.That(overloads, Has.Length.EqualTo(1));
            Assert.That(overloads[0].Signature.Parameters.Single().Type.IsNullable, Is.False);
            Assert.That(ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod(overloads[0]), Is.False,
                "The shipped factory remains visible rather than becoming a hidden compatibility overload.");
            Assert.That(overloads[0].Signature.Parameters.Single().DefaultValue, Is.Not.Null,
                "A visible restored primary factory must preserve published omitted-argument calls.");
        }

        [Test]
        public void FactoryRestorationDoesNotDuplicateExistingCSharpSignature()
        {
            // An extensible enum and a previous enum have different generator metadata,
            // but both factories would be emitted with the same C# parameter type name.
            var frequency = InputFactory.StringEnum("TumblingWindowFrequency", [("Hour", "Hour")],
                isExtensible: true, clientNamespace: "Samples.Models");
            var timestamp = new InputDateTimeType(DateTimeKnownEncoding.Rfc3339, "utcDateTime", "TypeSpec.utcDateTime", InputPrimitiveType.String);
            var properties = InputFactory.Model("TumblingWindowTriggerTypeProperties", properties:
            [
                InputFactory.Property("frequency", frequency, isRequired: true),
                InputFactory.Property("interval", InputPrimitiveType.Int32, isRequired: true),
                InputFactory.Property("startsOn", timestamp, isRequired: true),
                InputFactory.Property("endsOn", timestamp)
            ]);
            var wrapper = InputFactory.Property("typeProperties", properties, isRequired: true);
            Flatten(wrapper);
            var dependency = InputFactory.Model("DependencyReference", properties: [InputFactory.Property("name", InputPrimitiveType.String)]);
            var input = InputFactory.Model("TumblingWindowTrigger", properties:
            [
                InputFactory.Property("annotations", InputFactory.Array(InputPrimitiveType.String)),
                InputFactory.Property("dependsOn", InputFactory.Array(dependency)),
                wrapper
            ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, properties, dependency], inputEnums: () => [frequency],
                configurationJson: """{"package-name":"Samples"}""",
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    using System;
                    namespace Samples.Models
                    {
                        public enum TumblingWindowFrequency { Hour }
                        public partial class DependencyReference { }
                        public partial class TumblingWindowTrigger { }
                    }
                    namespace Samples
                    {
                        public static partial class SamplesModelFactory
                        {
                            public static Samples.Models.TumblingWindowTrigger TumblingWindowTrigger(
                                System.Collections.Generic.IEnumerable<string> annotations = default,
                                System.Collections.Generic.IEnumerable<Samples.Models.DependencyReference> dependsOn = default,
                                Samples.Models.TumblingWindowFrequency frequency = default,
                                int interval = default, DateTimeOffset startsOn = default,
                                DateTimeOffset? endsOn = default) => default;
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var visitType = typeof(LibraryVisitor).GetMethod("VisitTypeCore", BindingFlags.NonPublic | BindingFlags.Instance)!;
            foreach (var visitor in plugin.Object.Visitors)
            {
                visitType.Invoke(visitor, [factory]);
            }
            ManagementMockHelpers.ProcessTypeForBackCompatibility(factory);

            var overloads = factory.Methods.Where(m => m.Signature.Name == "TumblingWindowTrigger").ToArray();
            Assert.That(overloads.Select(m => m.Signature.Parameters.Select(p => p.Type.ToString()).ToArray()).DistinctBy(types => string.Join(",", types)).Count(),
                Is.EqualTo(1), "Both methods have the same emitted C# parameter types.");
            Assert.That(overloads, Has.Length.EqualTo(1),
                "Restoring an already generated C# signature produces CS0111.");
        }

        [Test]
        public void FrameworkBackedFactoryParameterMatchesContractTypeWithSameCSharpName()
        {
            // In DataFactory, delay is emitted as DataFactoryElement<string> on both sides,
            // but only the current type has IsFrameworkType=true. Use a model and a CLR
            // type with the same C# name to isolate the signature-matching rule.
            var input = InputFactory.Model(nameof(Samples.Models.FactoryFrameworkElement));
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input]);
            var contractType = plugin.Object.TypeFactory.CreateModel(input)!.Type;
            var frameworkType = new CSharpType(typeof(Samples.Models.FactoryFrameworkElement));
            Assert.That(frameworkType.FullyQualifiedName, Is.EqualTo(contractType.FullyQualifiedName));
            Assert.That(frameworkType.IsFrameworkType, Is.True);
            Assert.That(contractType.IsFrameworkType, Is.False);

            MethodSignature Signature(CSharpType type) => new("Create", null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static, type, null,
                [new ParameterProvider("delay", $"", type, Default)]);
            var matches = typeof(ModelFactoryVisitor).GetMethod("HasSameCSharpSignature",
                BindingFlags.NonPublic | BindingFlags.Static)!;
            Assert.That(matches.Invoke(null, [Signature(frameworkType), Signature(contractType)]), Is.True,
                "The framework classification cannot create a distinct C# factory overload.");
        }

        [Test]
        public void FactoryPreservesRenamedUriWithSameWireName()
        {
            // KustoClusterPatch's historical factory accepts `uri`, while the current flattened
            // model exposes the same wire property (`properties.uri`) as `ClusterUri`.
            var properties = InputFactory.Model("ClusterProperties", properties:
            [
                InputFactory.Property("clusterUri", InputPrimitiveType.Url, wireName: "uri")
            ]);
            var wrapper = InputFactory.Property("properties", properties);
            Flatten(wrapper);
            var input = InputFactory.Model("ClusterPatch", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties],
                configurationJson: """{"package-name":"Samples"}""");
            using var diagnostics = CaptureDiagnostics(plugin);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            Assert.That(model.Properties.Single(p => p.Name == "ClusterUri").Type.FrameworkType, Is.EqualTo(typeof(Uri)));
            var leaf = plugin.Object.TypeFactory.CreateModel(properties)!.FullConstructor.Signature.Parameters
                .Single(p => p.Name == "clusterUri");
            Assert.That(leaf.Property?.WireInfo?.SerializedName, Is.EqualTo("uri"));
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var previous = new ContractView(factory.Name);
            var signature = new MethodSignature("ClusterPatch", null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static, model.Type, null,
                [new ParameterProvider("uri", $"", typeof(Uri), Default)]);
            previous.ContractMethods = [new MethodProvider(signature, MethodBodyStatement.Empty, previous)];
            ModelTestHelper.SetLastContractView(factory, previous);
            ManagementMockHelpers.ProcessTypeForBackCompatibility(factory);
            _ = plugin.Object.GetWriter(factory).Write();
            var compatibility = factory.Methods.Single(ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod);
            var body = compatibility.BodyStatements!.ToDisplayString();

            var messages = Encoding.UTF8.GetString(diagnostics.ToArray());
            Assert.That(body, Does.Contain("uri"), messages);
            Assert.That(messages, Does.Not.Contain("Cannot preserve parameter 'uri' of compatibility factory"));

            var assembly = Compile(plugin.Object, includeFactory: true);
            var uri = new Uri("https://example.com/cluster");
            var method = assembly.GetType(factory.Type.FullyQualifiedName)!.GetMethod("ClusterPatch", [typeof(Uri)])!;
            var result = method.Invoke(null, [uri])!;
            Assert.That(result.GetType().GetProperty("ClusterUri")!.GetValue(result), Is.EqualTo(uri));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(result, new ModelReaderWriterOptions("J")));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("uri").GetString(),
                Is.EqualTo(uri.ToString()));
        }

        [Test]
        public void FactoryDoesNotGuessBetweenDuplicateSerializedNames()
        {
            var primary = InputFactory.Model("PrimaryProperties", properties:
            [
                InputFactory.Property("clusterUri", InputPrimitiveType.Url, wireName: "uri")
            ]);
            var secondary = InputFactory.Model("SecondaryProperties", properties:
            [
                InputFactory.Property("backupUri", InputPrimitiveType.Url, wireName: "uri")
            ]);
            var primaryWrapper = InputFactory.Property("primary", primary);
            var secondaryWrapper = InputFactory.Property("secondary", secondary);
            Flatten(primaryWrapper);
            Flatten(secondaryWrapper);
            var input = InputFactory.Model("ClusterPatch", properties: [primaryWrapper, secondaryWrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, primary, secondary],
                configurationJson: """{"package-name":"Samples"}""");
            using var diagnostics = CaptureDiagnostics(plugin);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var previous = new ContractView(factory.Name);
            var signature = new MethodSignature("ClusterPatch", null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static, model.Type, null,
                [new ParameterProvider("uri", $"", typeof(Uri), Default)]);
            previous.ContractMethods = [new MethodProvider(signature, MethodBodyStatement.Empty, previous)];
            ModelTestHelper.SetLastContractView(factory, previous);
            ManagementMockHelpers.ProcessTypeForBackCompatibility(factory);
            _ = plugin.Object.GetWriter(factory).Write();

            // Ambiguous wire names must not silently route the old value to either branch.
            var compatibility = factory.Methods.Single(ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod);
            Assert.That(compatibility.BodyStatements!.ToDisplayString(), Does.Not.Contain("uri"));
        }

        [Test]
        public void UnmappedFactoryParameterDoesNotBlockGeneration([Values] bool customMethod, [Values] bool acceptedRemoval)
        {
            var input = InputFactory.Model("VolumePatch", properties: [InputFactory.Property("sizeGiB", InputPrimitiveType.Int64)]);
            var baseline = acceptedRemoval ? ApiCompatBaseline.Parse(
                ["MembersMustExist : Member 'Samples.SamplesModelFactory.VolumePatch(System.String)' does not exist in the implementation but it does exist in the contract."]) : null;
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input], apiCompatBaseline: baseline,
                configurationJson: """{"package-name":"Samples"}""");
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var signature = new MethodSignature("VolumePatch", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type, null, [new ParameterProvider("managedByResourceId", $"", typeof(string))],
                Attributes: [new AttributeStatement(typeof(EditorBrowsableAttribute), FrameworkEnumValue(EditorBrowsableState.Never))]);
            var method = new MethodProvider(signature, Return(Default), factory);
            factory.Update(methods: [method]);
            if (customMethod)
            {
                var custom = new ContractView(factory.Name);
                custom.ContractMethods = [new MethodProvider(signature, Return(Default), custom)];
                ManagementMockHelpers.SetCustomCodeView(factory, custom);
            }
            using var diagnostics = CaptureDiagnostics(plugin);
            _ = plugin.Object.GetWriter(factory).Write();
            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
            Assert.That(method.BodyStatements!.ToDisplayString(), Does.Not.Contain("managedByResourceId"));
        }

        // Regression for #63425: losing a value used by the historical factory is different
        // from retaining a parameter that the historical implementation already discarded.
        [TestCase(true, false)]
        [TestCase(false, false)]
        [TestCase(true, true)]
        [TestCase(false, true)]
        public void FactoryReportsNewlyDiscardedHistoricalValue(bool historicallyConsumed, bool metadataOnly)
            => AssertHistoricalFactoryValue(historicallyConsumed, metadataOnly);

        [TestCase(false)]
        [TestCase(true)]
        public void FactoryReportsNewlyDiscardedHistoricalValueWithFixedLiteral(bool metadataOnly)
            => AssertHistoricalFactoryValue(true, metadataOnly, includeFixedLiteral: true);

        [Test]
        public void SkippingUnsafeFactoryKeepsSafeHistoricalOverload()
            => AssertHistoricalFactoryValue(true, true, "safe-sibling");

        [Test]
        public void UnsafeFactoryWarnsOnceAndContinuesWithSubsequentOverloads()
            => AssertHistoricalFactoryValue(true, true, "multiple-losses");

        [TestCase("custom")]
        [TestCase("suppressed")]
        [TestCase("suppressed-type")]
        [TestCase("preview")]
        [TestCase("preview-selection")]
        [TestCase("mismatched-selection")]
        [TestCase("missing-selection")]
        [TestCase("alias")]
        [TestCase("unknown-expression")]
        public void HistoricalFactoryValidationRespectsExemptionsAndUnknownEvidence(string resolution)
            => AssertHistoricalFactoryValue(true, true, resolution);

        private static void AssertHistoricalFactoryValue(bool historicallyConsumed, bool metadataOnly, string? resolution = null, bool includeFixedLiteral = false)
        {
            using var baselineProject = new FactoryBaselineProject(resolution switch
            {
                "preview-selection" => "1.0.0-beta.1",
                "mismatched-selection" => "2.0.0",
                "missing-selection" => null,
                _ => "1.0.0"
            });
            var baselinePath = Path.Combine(baselineProject.Path, "factory-baseline.dll");
            Compilation? lastContract = null;
            Compilation? metadataContract = null;
            Compilation GetLastContract() => lastContract ??= Helpers.BuildCompilation(
            [
                ("LastContract.cs", $$"""
                [assembly: System.Reflection.AssemblyInformationalVersion("{{(resolution == "preview" ? "1.0.0-beta.1" : "1.0.0")}}")]
                namespace Samples.Models
                {
                    public partial class VolumePatch
                    {
                        public long? SizeGiB { get; set; }
                        public string ManagedByResourceId { get; set; }
                        {{(resolution == "multiple-losses" ? "public string ManagedByTenantId { get; set; }" : "")}}
                    }
                }
                namespace Samples
                {
                    public static partial class SamplesModelFactory
                    {
                        public static Samples.Models.VolumePatch VolumePatch(
                            long? sizeGiB = default, string managedByResourceId = default{{(resolution == "multiple-losses" ? ", string managedByTenantId = default" : "")}})
                            => new Samples.Models.VolumePatch
                            {
                                SizeGiB = sizeGiB,
                                ManagedByResourceId = {{(historicallyConsumed ? "managedByResourceId" : "default")}}
                                {{(resolution == "multiple-losses" ? ", ManagedByTenantId = managedByTenantId" : "")}}
                            };
                        {{(resolution is "safe-sibling" or "multiple-losses" ? "public static Samples.Models.VolumePatch VolumePatch(long sizeGiB) => new Samples.Models.VolumePatch { SizeGiB = sizeGiB };" : "")}}
                        {{(resolution == "multiple-losses" ? "public static Samples.Models.VolumePatch VolumePatch(string managedByTenantId) => new Samples.Models.VolumePatch { ManagedByTenantId = managedByTenantId };" : "")}}
                    }
                }
                """)
            ]).WithAssemblyName("Samples");

            Compilation GetBaseline()
            {
                if (!metadataOnly) return GetLastContract();
                if (metadataContract is not null) return metadataContract;
                using (var baselineFile = new FileStream(baselinePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    var baselineEmit = GetLastContract().Emit(baselineFile);
                    Assert.That(baselineEmit.Success, Is.True, string.Join(Environment.NewLine, baselineEmit.Diagnostics));
                    baselineFile.Flush();
                }
                metadataContract = GetLastContract().RemoveAllSyntaxTrees().WithAssemblyName("MetadataContract")
                    .AddReferences(MetadataReference.CreateFromFile(baselinePath));
                Assert.That(metadataContract.SyntaxTrees, Is.Empty,
                    "Exercise the production metadata-only baseline path without historical source.");
                return metadataContract;
            }

            // A scalar resource ID no longer has a lossless destination when managedBy
            // becomes an array of objects; neither guessing nor silently discarding is safe.
            var managed = InputFactory.Model("ManagedByInfo", properties:
            [
                InputFactory.Property("clientId", InputPrimitiveType.String),
                InputFactory.Property("resourceIds", InputFactory.Array(InputPrimitiveType.String))
            ]);
            var properties = InputFactory.Model("VolumeProperties", properties:
            [
                InputFactory.Property("sizeGiB", InputPrimitiveType.Int64),
                InputFactory.Property("managedBy", InputFactory.Array(managed))
            ]);
            var wrapper = InputFactory.Property("properties", properties);
            Flatten(wrapper);
            var input = InputFactory.Model("VolumePatch", properties: includeFixedLiteral
                ? [wrapper, InputFactory.Property("mode", InputFactory.Literal.String("Fixed"), isRequired: true)]
                : [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, properties, managed],
                configurationJson: """{"package-name":"Samples"}""",
                lastContractCompilation: GetBaseline,
                outputDirectory: baselineProject.Path);

            // Prove whether the old body actually preserved the value instead of inferring
            // that from the mere presence of a parameter in its public signature.
            using var contractStream = new MemoryStream();
            var emit = GetLastContract().WithAssemblyName("HistoricalFactory" + Guid.NewGuid().ToString("N")).Emit(contractStream);
            Assert.That(emit.Success, Is.True, string.Join(Environment.NewLine, emit.Diagnostics));
            var contractAssembly = Assembly.Load(contractStream.ToArray());
            const string resourceId = "/subscriptions/sub/resourceGroups/rg/providers/Test/widgets/a";
            var oldResult = contractAssembly.GetType("Samples.SamplesModelFactory")!
                .GetMethod("VolumePatch", resolution == "multiple-losses"
                    ? [typeof(long?), typeof(string), typeof(string)] : [typeof(long?), typeof(string)])!
                .Invoke(null, resolution == "multiple-losses" ? [55L, resourceId, "tenant"] : [55L, resourceId])!;
            Assert.That(oldResult.GetType().GetProperty("ManagedByResourceId")!.GetValue(oldResult),
                Is.EqualTo(historicallyConsumed ? resourceId : null));

            using var diagnostics = CaptureDiagnostics(plugin);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            Assert.That(factory.LastContractView, Is.Not.Null);
            Assert.That(factory.LastContractView!.Methods.Single(m => m.Signature.Name == "VolumePatch"
                && m.Signature.Parameters.Any(parameter => parameter.Name == "managedByResourceId"))
                .BodyStatements!.ToDisplayString(), Is.Empty,
                "Contract providers retain signatures, not the old implementation's parameter usage.");
            ManagementMockHelpers.ProcessTypeForBackCompatibility(factory);
            var primaryMethods = factory.Methods.Where(method => !ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod(method)).ToArray();
            var compatibility = factory.Methods.Single(method => ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod(method)
                && method.Signature.Parameters.Any(parameter => parameter.Name == "managedByResourceId"));
            var safeSibling = resolution is "safe-sibling" or "multiple-losses"
                ? factory.Methods.Single(method => ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod(method)
                    && method.Signature.Parameters.Count == 1 && method.Signature.Parameters[0].Name == "sizeGiB")
                : null;
            var laterUnsafe = resolution == "multiple-losses"
                ? factory.Methods.Single(method => ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod(method)
                    && method.Signature.Parameters.Count == 1 && method.Signature.Parameters[0].Name == "managedByTenantId")
                : null;
            if (laterUnsafe is not null)
            {
                // Make the outer-loop order explicit: unsafe, safe, then another unsafe overload.
                factory.Update(methods: [compatibility, safeSibling!, laterUnsafe, .. primaryMethods]);
            }
            if (resolution == "custom")
            {
                var custom = new ContractView(factory.Name);
                custom.ContractMethods = [new MethodProvider(compatibility.Signature, Return(Default), custom)];
                ManagementMockHelpers.SetCustomCodeView(factory, custom);
            }
            if (resolution is "suppressed" or "suppressed-type")
            {
                var baseline = ApiCompatBaseline.Parse(resolution == "suppressed"
                    ? ["MembersMustExist : Member 'Samples.SamplesModelFactory.VolumePatch(System.Nullable<System.Int64>, System.String)' does not exist in the implementation but it does exist in the contract."]
                    : ["TypesMustExist : Type 'Samples.Models.VolumePatch' does not exist in the implementation but it does exist in the contract."]);
                Assert.That(ModelFactoryVisitor.IsRemovalAcceptedInBaseline(factory, compatibility.Signature), Is.False);
                plugin.Setup(p => p.SourceInputModel).Returns(new SourceInputModel(null, GetBaseline(), baseline));
                Assert.That(ModelFactoryVisitor.IsRemovalAcceptedInBaseline(factory, compatibility.Signature), Is.True);
            }
            if (resolution == "alias")
            {
                var declaration = Declare("saved", typeof(string),
                    compatibility.Signature.Parameters.Single(p => p.Name == "managedByResourceId"), out var saved);
                compatibility.Update(bodyStatements: new MethodBodyStatement[]
                {
                    declaration,
                    Return(new InvokeMethodExpression(null, "PreserveViaAlias", [saved]))
                });
            }
            if (resolution == "unknown-expression")
            {
                compatibility.Update(bodyStatements: Return(new TernaryConditionalExpression(True, Default, Default)));
            }
            var writtenFactory = plugin.Object.GetWriter(factory).Write().Content;
            var shouldSkip = historicallyConsumed && resolution is null or "safe-sibling" or "multiple-losses";
            Assert.That(factory.Methods.Contains(compatibility), Is.EqualTo(!shouldSkip),
                "Warn and omit only the unsafe restoration, rather than emitting a factory that silently drops a GA value.");
            foreach (var primary in primaryMethods)
            {
                Assert.That(factory.Methods, Does.Contain(primary), "Current factory overloads must remain available.");
            }
            if (safeSibling is not null)
            {
                Assert.That(factory.Methods, Does.Contain(safeSibling), "Other safe GA overloads must remain available.");
                Assert.That(safeSibling.BodyStatements!.ToDisplayString(), Does.Contain("sizeGiB"));
            }
            if (laterUnsafe is not null)
            {
                Assert.That(factory.Methods, Does.Not.Contain(laterUnsafe), "The outer loop must continue past the first unsafe overload.");
                Assert.That(writtenFactory, Does.Not.Contain("managedByTenantId"));
            }
            Assert.That(writtenFactory, shouldSkip ? Does.Not.Contain("managedByResourceId") : Does.Contain("managedByResourceId"));
            var repeatedWrite = plugin.Object.GetWriter(factory).Write().Content;
            Assert.That(repeatedWrite, Is.EqualTo(writtenFactory), "Writing again must not restore the rejected overload.");

            Assert.That(compatibility.Signature.Parameters.Select(p => p.Name),
                Does.Contain("managedByResourceId"));
            var usage = HistoricalFactoryUsage.Read(GetBaseline(), factory.Type, "1.0.0", "Samples");
            var key = HistoricalFactoryUsage.Key(compatibility.Signature);
            Assert.That(usage.ContainsKey(key), Is.EqualTo(resolution != "preview"),
                $"The stable baseline implementation must be understood. Key: {key}; known methods: {string.Join(", ", usage.Keys)}");
            if (resolution != "preview")
            {
                Assert.That(usage[key].Contains("managedByResourceId"), Is.EqualTo(historicallyConsumed));
                if (laterUnsafe is not null)
                {
                    Assert.That(usage[key], Does.Contain("managedByTenantId"), "Both lost values must have been preserved historically.");
                    Assert.That(usage[HistoricalFactoryUsage.Key(laterUnsafe.Signature)], Does.Contain("managedByTenantId"));
                }
            }
            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""),
                "An unsafe factory restoration must not block generation.");
            if (resolution is not (null or "safe-sibling" or "multiple-losses"))
            {
                Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"warning\""));
                return;
            }
            var body = compatibility.BodyStatements!.ToDisplayString();
            Assert.That(body, Does.Contain("sizeGiB"), "The still-mappable value must remain forwarded.");
            Assert.That(body, Does.Not.Contain("managedByResourceId"),
                "The changed wire shape has no unambiguous destination for the old scalar.");
            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()).Contains("\"severity\":\"warning\""),
                Is.EqualTo(historicallyConsumed),
                "Warn about newly lost historical values, not parameters already discarded by the old factory. " +
                $"Selected version: {HistoricalFactoryUsage.SelectedVersion(plugin.Object.Configuration.OutputDirectory, "Samples")}; " +
                $"statements: {string.Join(", ", compatibility.BodyStatements!.Select(s => s.GetType().Name))}; body: {body}; " +
                $"diagnostics: {Encoding.UTF8.GetString(diagnostics.ToArray())}");
            if (historicallyConsumed)
            {
                var warnings = new List<string>();
                foreach (var line in Encoding.UTF8.GetString(diagnostics.ToArray()).Split('\n', StringSplitOptions.RemoveEmptyEntries))
                {
                    using var notification = JsonDocument.Parse(line);
                    var parameters = notification.RootElement.GetProperty("params");
                    if (parameters.GetProperty("severity").GetString() == "warning")
                    {
                        Assert.That(parameters.GetProperty("code").GetString(), Is.EqualTo("general-warning"));
                        warnings.Add(parameters.GetProperty("message").GetString()!);
                    }
                }
                Assert.That(warnings, Has.Count.EqualTo(laterUnsafe is null ? 1 : 2), "Emit one warning per omitted overload.");
                Assert.That(warnings[0], Does.Contain("Samples.SamplesModelFactory.VolumePatch"));
                Assert.That(warnings[0], Does.Contain("parameter 'managedByResourceId'"));
                Assert.That(warnings[0], Does.Not.Contain("parameter 'sizeGiB'"));
                if (laterUnsafe is not null)
                {
                    Assert.That(warnings[0], Does.Not.Contain("parameter 'managedByTenantId'"), "Only report the first lost value in an overload.");
                    Assert.That(warnings[1], Does.Contain("parameter 'managedByTenantId'"));
                    Assert.That(warnings[1], Does.Not.Contain("managedByResourceId"), "This warning must identify the later overload.");
                }
            }
        }

        private sealed class FactoryBaselineProject : IDisposable
        {
            internal string Path { get; } = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"factory-project-{Guid.NewGuid():N}");
            internal FactoryBaselineProject(string? version)
            {
                Directory.CreateDirectory(System.IO.Path.Combine(Path, "src"));
                File.WriteAllText(System.IO.Path.Combine(Path, "src", "Samples.csproj"),
                    $"<Project><PropertyGroup>{(version is null ? "" : $"<ApiCompatVersion>{version}</ApiCompatVersion>")}</PropertyGroup></Project>");
            }
            public void Dispose() => Directory.Delete(Path, recursive: true);
        }

        [Test]
        public void FactoryGuardAndNamedDefaultDoNotPreserveTheValue()
        {
            var input = InputFactory.Model("VolumePatch", properties: [InputFactory.Property("sizeGiB", InputPrimitiveType.Int64)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input]);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var parameter = new ParameterProvider("managedByResourceId", $"", typeof(string));
            var signature = new MethodSignature("VolumePatch", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type, null, [parameter],
                Attributes: [new AttributeStatement(typeof(EditorBrowsableAttribute), FrameworkEnumValue(EditorBrowsableState.Never))]);
            var method = new MethodProvider(signature,
                new MethodBodyStatement[]
                {
                    parameter.Assign(Null, nullCoalesce: true).Terminate(),
                    Return(new TernaryConditionalExpression(parameter.Is(Null), Default,
                        New.Instance(model.Type, new PositionalParameterReferenceExpression(parameter.Name, Default))))
                }, factory);
            factory.Update(methods: [method]);
            using var diagnostics = CaptureDiagnostics(plugin);
            _ = plugin.Object.GetWriter(factory).Write();
            var body = method.BodyStatements!.ToDisplayString();
            Assert.That(body, Does.Contain("managedByResourceId"));
            Assert.That(body, Does.Contain("default"));
            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
        }

        [Test]
        public void FactoryPreservesNestedRenamedAndConvertedValues()
        {
            var timestamp = new InputDateTimeType(DateTimeKnownEncoding.Rfc3339, "utcDateTime", "TypeSpec.utcDateTime", InputPrimitiveType.String);
            var properties = InputFactory.Model("PolicyProperties", properties:
            [
                InputFactory.Property("startTime", timestamp),
                InputFactory.Property("count", InputPrimitiveType.Int64, isRequired: true),
                InputFactory.Property("tags", InputFactory.Array(InputPrimitiveType.String))
            ]);
            var input = InputFactory.Model("PolicyModel", properties: [InputFactory.Property("properties", properties)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties]);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            var inner = plugin.Object.TypeFactory.CreateModel(properties)!;
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var signature = new MethodSignature("PolicyModel", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type, null,
                [
                    new ParameterProvider("legacyTimestamp", $"", typeof(DateTimeOffset?), Default,
                        property: inner.Properties.Single(p => p.Name == "StartsOn")),
                    new ParameterProvider("count", $"", typeof(long?), Default),
                    new ParameterProvider("tags", $"", typeof(IEnumerable<string>), Default)
                ]);
            var previous = new ContractView(factory.Name);
            previous.ContractMethods = [new MethodProvider(signature, MethodBodyStatement.Empty, previous)];
            ModelTestHelper.SetLastContractView(factory, previous);
            ManagementMockHelpers.ProcessTypeForBackCompatibility(factory);
            using var diagnostics = CaptureDiagnostics(plugin);
            _ = plugin.Object.GetWriter(factory).Write();
            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
            var body = factory.Methods.Single(ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod).BodyStatements!.ToDisplayString();
            Assert.That(body, Does.Contain("legacyTimestamp"));
            Assert.That(body, Does.Contain("count.GetValueOrDefault()"));
            Assert.That(body, Does.Contain("ToList()"));
        }

        private static (Moq.Mock<ManagementClientGenerator> Plugin, ModelProvider Model) CreateCollectionWrapperModel(
            bool safeFlatten, bool dictionary, bool wrapperRequired)
        {
            const InputModelTypeUsage usage = InputModelTypeUsage.Input | InputModelTypeUsage.Json;
            InputType collection = dictionary
                ? new InputDictionaryType("dictionary", InputPrimitiveType.String, InputPrimitiveType.String)
                : InputFactory.Array(InputPrimitiveType.String);
            var properties = InputFactory.Model("CollectionProperties", usage: usage, properties:
                [InputFactory.Property("items", collection)]);
            var wrapper = InputFactory.Property("collectionProperties", properties, isRequired: wrapperRequired);
            if (!safeFlatten)
            {
                Flatten(wrapper);
            }
            var input = InputFactory.Model("CollectionContent", usage: usage, properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties]);
            return (plugin, plugin.Object.TypeFactory.CreateModel(input)!);
        }

        private static (Moq.Mock<ManagementClientGenerator> Plugin, ModelProvider Model, ModelProvider Inner) CreateCapacityModel(
            bool safeFlatten, bool wrapperRequired, bool leafRequired = false)
        {
            var inner = InputFactory.Model("CapacityProperties", properties: [InputFactory.Property("size", InputPrimitiveType.Int64, isRequired: leafRequired)]);
            var wrapper = InputFactory.Property("capacity", inner, isRequired: wrapperRequired);
            if (!safeFlatten)
            {
                Flatten(wrapper);
            }
            var input = InputFactory.Model("CapacityModel", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner]);
            return (plugin, plugin.Object.TypeFactory.CreateModel(input)!, plugin.Object.TypeFactory.CreateModel(inner)!);
        }

        private static void Flatten(InputModelProperty property)
            => typeof(InputModelProperty).GetProperty(nameof(InputModelProperty.Decorators))!.SetValue(property,
                new[] { new InputDecoratorInfo("Azure.ResourceManager.@flattenProperty", new Dictionary<string, BinaryData>()) });

        private static void Visit(ModelProvider model)
        {
            var visit = typeof(LibraryVisitor).GetMethod("VisitTypeCore", BindingFlags.NonPublic | BindingFlags.Instance)!;
            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visit.Invoke(visitor, [model]);
            }
        }

        private static MemoryStream CaptureDiagnostics(Moq.Mock<ManagementClientGenerator> plugin)
        {
            var stream = new MemoryStream();
            var emitter = (Emitter)Activator.CreateInstance(typeof(Emitter),
                BindingFlags.Instance | BindingFlags.NonPublic, null, [stream], null)!;
            plugin.Setup(p => p.Emitter).Returns(emitter);
            return stream;
        }

        private static Assembly Compile(ManagementClientGenerator plugin, bool includeFactory = false, string? customizationSource = null)
        {
            var types = plugin.OutputLibrary.TypeProviders.Where(t => t is ModelProvider or EnumProvider
                || (includeFactory && t is ModelFactoryProvider)
                || t.Name is "Argument" or "Optional" or "ChangeTrackingList" or "ChangeTrackingDictionary"
                    or "ModelSerializationExtensions" or "TypeFormatters" or "SerializationFormat" or "SamplesContext").ToArray();
            var documents = types.Concat(types.SelectMany(t => t.SerializationProviders))
                .Select(t => (t.Name + ".cs", plugin.GetWriter(t).Write().Content))
                // Scalar JSON paths do not need the separately source-generated context type builders.
                .Append(("Context.cs", """
                    namespace Samples
                    {
                        public partial class SamplesContext
                        {
                            public static SamplesContext Default { get; } = new SamplesContext();
                        }
                    }
                    """))
                .Concat(customizationSource is null ? [] : new[] { ("Customization.cs", customizationSource) });
            var compilation = Helpers.BuildCompilation(documents)
                .WithAssemblyName("FlattenedCompatibility" + Guid.NewGuid().ToString("N"))
                .AddReferences(((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")!).Split(Path.PathSeparator)
                    .Select(path => MetadataReference.CreateFromFile(path)));
            using var stream = new MemoryStream();
            var result = compilation.Emit(stream);
            Assert.That(result.Success, Is.True, string.Join(Environment.NewLine, result.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error)));
            return Assembly.Load(stream.ToArray());
        }

        private sealed class ExternalOwnerA { public sealed class Value { } }
        private sealed class ExternalOwnerB { public sealed class Value { } }

        private sealed class ContractView(string name) : TypeProvider
        {
            public PropertyProvider[] ContractProperties { get; set; } = [];
            public MethodProvider[] ContractMethods { get; set; } = [];
            public ConstructorProvider[] ContractConstructors { get; set; } = [];
            protected override string BuildName() => name;
            protected override string BuildRelativeFilePath() => $"{Name}.cs";
            protected override PropertyProvider[] BuildProperties() => ContractProperties;
            protected override MethodProvider[] BuildMethods() => ContractMethods;
            protected override ConstructorProvider[] BuildConstructors() => ContractConstructors;
        }
    }
}
