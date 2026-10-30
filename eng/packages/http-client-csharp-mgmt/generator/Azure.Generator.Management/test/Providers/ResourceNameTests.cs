// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Reflection;
using Generated = Azure.Generator.MgmtTypeSpec.Tests;

namespace Azure.Generator.Management.Tests.Providers;

internal class ResourceNameTests
{
    [TestCase("IpAddress", "IPAddress", "GetIPAddresses")]
    [TestCase("DbCluster", "DBCluster", "GetDBClusters")]
    [TestCase("OsImage", "OSImage", "GetOSImages")]
    [TestCase("Ipv4Address", "IPv4Address", "GetIPv4Addresses")]
    [TestCase("Ipv6Address", "IPv6Address", "GetIPv6Addresses")]
    [TestCase("IpAddressIp", "IPAddressIP", "GetIPAddressIPs")]
    [TestCase("DbClusterDb", "DBClusterDB", "GetDBClusterDBs")]
    [TestCase("OsImageOs", "OSImageOS", "GetAllOSImageOS")]
    [TestCase("Ipv4ToIpv4Address", "IPv4ToIPv4Address", "GetIPv4ToIPv4Addresses")]
    [TestCase("Ipv6ToIpv6Address", "IPv6ToIPv6Address", "GetIPv6ToIPv6Addresses")]
    [TestCase("IpAddresses", "IPAddresses", "GetAllIPAddresses")]
    [TestCase("IpAddressResource", "IPAddressResource", "GetIPAddressResources")]
    [TestCase("ShippingDepot", "ShippingDepot", "GetShippingDepots")]
    [TestCase("Dbase", "Dbase", "GetDbases")]
    [TestCase("Oslo", "Oslo", "GetOslos")]
    [TestCase("Ipam", "Ipam", "GetIpams")]
    [TestCase("IpDbOsIpv4Ipv6", "IPDBOSIPv4IPv6", "GetIPDBOSIPv4IPv6s")]
    [TestCase("IPV4Address", "IPV4Address", "GetIPV4Addresses")]
    [TestCase("IPV6Address", "IPV6Address", "GetIPV6Addresses")]
    public void DerivedNamesUseSharedAcronymRules(string input, string expected, string getter)
    {
        var resource = CreateResource(input, false);
        Assert.That(resource.ResourceName, Is.EqualTo(expected));
        Assert.That(resource.Name, Is.EqualTo(expected.EndsWith("Resource") ? expected : $"{expected}Resource"));
        Assert.That(resource.RelativeFilePath, Does.EndWith($"{resource.Name}.cs"));
        Assert.That(resource.ResourceCollection!.Name, Is.EqualTo($"{expected}Collection"));
        Assert.That(resource.FactoryMethodSignature.Name, Is.EqualTo(getter));
        Assert.That(resource.FactoryMethodSignature.ReturnType, Is.EqualTo(resource.ResourceCollection.Type));
        Assert.That(resource.ResourceTypeValue, Is.EqualTo("Microsoft.Tests/tests"));
        Assert.That(resource.ResourceIdPattern.SerializedPath, Does.EndWith("/providers/Microsoft.Tests/tests/{testName}"));

        var rendered = new TypeProviderWriter(resource).Write().Content;
        Assert.That(rendered, Does.Contain($"partial class {resource.Name}"));
        Assert.That(rendered, Does.Contain($"internal {resource.Name}("));
    }

    [TestCase("Os", "OS", "GetAllOS")]
    [TestCase("IP", "IP", "GetIPs")]
    [TestCase("DB", "DB", "GetDBs")]
    public void TerminalAcronymsKeepCollectionAccessorCasing(string input, string expected, string getter)
    {
        var resource = CreateResource(input, false);
        Assert.That(resource.ResourceName, Is.EqualTo(expected));
        Assert.That(resource.FactoryMethodSignature.Name, Is.EqualTo(getter));
        Assert.That(ResourceHelpers.GetExtensionOperationMethodName(ResourceOperationKind.List, resource.ResourceName, false,
            resource.PluralResourceName), Is.EqualTo($"Get{resource.PluralResourceName}"));
    }

    [Test]
    public void PublishedTerminalAcronymKeepsLegacyAccessor()
    {
        var (client, models) = InputResourceData.ClientWithResource(resourceName: "OS", resourceNameIsExplicit: false);
        var compilation = Helpers.BuildCompilation([("Contract.cs", "namespace Samples { public class OSResource { } }")]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client],
            lastContractCompilation: () => compilation);
        var resource = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single();
        Assert.That(resource.FactoryMethodSignature.Name, Is.EqualTo("GetOs"));
    }

    [TestCase("OS", false, false)]
    [TestCase("OS", true, false)]
    [TestCase("OS", false, true)]
    [TestCase("OS", true, true)]
    [TestCase("OSImageOS", false, false)]
    [TestCase("OSImageOS", true, false)]
    [TestCase("OSImageOS", false, true)]
    [TestCase("OSImageOS", true, true)]
    public void PublishedCollectionAccessorSurvivesRegeneration(string name, bool legacy, bool child)
    {
        var (client, models) = InputResourceData.ClientWithResource(resourceName: name, resourceNameIsExplicit: false);
        var (parentClient, childClient, childModels) = InputResourceData.ClientWithNestedChildResource(childResourceName: name, resourceNameIsExplicit: false);
        var clients = child ? new[] { parentClient, childClient } : new[] { client };
        var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => child ? childModels : models, clients: () => clients);
        var resource = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single(r => r.ResourceName == name);
        var getter = legacy ? name.GetCollectionMethodName() : resource.FactoryMethodSignature.Name;
        var parentDeclaration = child
            ? $"namespace Samples {{ public class ParentTypeResource {{ public virtual {name}Collection {getter}(string nestedTypeName) => throw null; }} }}"
            : $"namespace Samples.Mocking {{ public class MockableSamplesResourceGroupResource {{ public virtual global::Samples.{name}Collection {getter}() => throw null; }} }}";
        var contract = Helpers.BuildCompilation([
            ("Resources.cs", $"namespace Samples {{ public class {name}Resource {{ }} public class {name}Collection {{ }} }}"),
            ("Parent.cs", parentDeclaration)
        ]);

        for (var generation = 0; generation < 2; generation++)
        {
            plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => child ? childModels : models,
                clients: () => clients, lastContractCompilation: () => contract);
            resource = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single(r => r.ResourceName == name);
            Assert.That(resource.FactoryMethodSignature.Name, Is.EqualTo(getter));
            var parentMethods = child
                ? plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single(r => r.ResourceName == "ParentType").Methods
                : plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>()
                    .Single(p => p.ArmCoreType.Equals(typeof(Azure.ResourceManager.Resources.ResourceGroupResource))).Methods;
            Assert.That(parentMethods.Any(m => m.Signature.Name == getter &&
                m.Signature.ReturnType?.Equals(resource.ResourceCollection!.Type) == true), Is.True);
        }
    }

    [Test]
    public void PublishedCollectionAccessorIgnoresUnrelatedOverloads(
        [Values(false, true)] bool child,
        [Values(false, true)] bool unrelatedFirst,
        [Values("extra", "type", "name", "ref", "static", "generic")] string shape)
    {
        var (client, models) = InputResourceData.ClientWithResource(resourceName: "OS", resourceNameIsExplicit: false);
        var (parentClient, childClient, childModels) = InputResourceData.ClientWithNestedChildResource(childResourceName: "OS", resourceNameIsExplicit: false);
        var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => child ? childModels : models,
            clients: () => child ? [parentClient, childClient] : [client]);
        var parameters = child ? "string nestedTypeName" : "";
        var unrelatedParameters = shape switch
        {
            "extra" => child ? "string nestedTypeName, bool includeHidden" : "bool includeHidden",
            "type" => "bool nestedTypeName",
            "name" => "string otherName",
            "ref" => "ref string nestedTypeName",
            _ => parameters
        };
        var modifiers = shape == "static" ? "public static" : "public virtual";
        var genericParameters = shape == "generic" ? "<T>" : "";
        var factory = $"public virtual global::Samples.OSCollection GetOs({parameters}) => throw null;";
        var unrelated = $"{modifiers} global::Samples.OSCollection GetAllOS{genericParameters}({unrelatedParameters}) => throw null;";
        var members = unrelatedFirst ? $"{unrelated}\n{factory}" : $"{factory}\n{unrelated}";
        var parentNamespace = child ? "Samples" : "Samples.Mocking";
        var parentName = child ? "ParentTypeResource" : "MockableSamplesResourceGroupResource";
        var contract = Helpers.BuildCompilation([
            ("Resources.cs", "namespace Samples { public class OSResource { } public class OSCollection { } }"),
            ("Parent.cs", $"namespace {parentNamespace} {{ public partial class {parentName} {{ {members} }} }}")
        ]);
        var customization = Helpers.BuildCompilation([
            ("Resources.cs", "namespace Samples { public class OSCollection { } }"),
            ("Parent.cs", $"namespace {parentNamespace} {{ public partial class {parentName} {{ {unrelated} }} }}")
        ]);
        plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => child ? childModels : models,
            clients: () => child ? [parentClient, childClient] : [client],
            customizationCompilation: () => customization, lastContractCompilation: () => contract);
        var resource = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single(r => r.ResourceName == "OS");
        Assert.That(resource.FactoryMethodSignature.Name, Is.EqualTo("GetOs"));
        Assert.That(resource.FactoryMethodSignature.Parameters.Select(p => p.Name),
            Is.EqualTo(child ? new[] { "nestedTypeName" } : Array.Empty<string>()));
        var parentMethods = child
            ? plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single(r => r.ResourceName == "ParentType").Methods
            : plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>()
                .Single(p => p.ArmCoreType.Equals(typeof(Azure.ResourceManager.Resources.ResourceGroupResource))).Methods;
        Assert.That(parentMethods.Any(m => m.Signature.Name == "GetOs" &&
            m.Signature.ReturnType?.Equals(resource.ResourceCollection!.Type) == true), Is.True);
    }

    [TestCase(false)]
    [TestCase(true)]
    public void PublishedExtensionFactoryMatchesScopeParameter(bool unrelatedFirst)
    {
        var (parentClient, childClient, models) = InputResourceData.ClientWithNestedExtensionChildResource("OS", false);
        ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [parentClient, childClient]);
        const string factory = "public virtual global::Samples.OSCollection GetOs(global::Azure.Core.ResourceIdentifier scope) => throw null;";
        const string unrelated = "public virtual global::Samples.OSCollection GetAllOS() => throw null;";
        var members = unrelatedFirst ? $"{unrelated}\n{factory}" : $"{factory}\n{unrelated}";
        var contract = Helpers.BuildCompilation([
            ("Resources.cs", "namespace Samples { public class OSResource { } public class OSCollection { } }"),
            ("Parent.cs", $"namespace Samples.Mocking {{ public class MockableSamplesArmClient {{ {members} }} }}")
        ]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [parentClient, childClient],
            lastContractCompilation: () => contract);
        var resource = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single(r => r.ResourceName == "OS");
        Assert.That(resource.FactoryMethodSignature.Name, Is.EqualTo("GetOs"));
        var mockable = plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>()
            .Single(p => p.ArmCoreType.Equals(typeof(Azure.ResourceManager.ArmClient)));
        var getter = mockable.Methods.Single(m => m.Signature.Name == "GetOs" &&
            m.Signature.ReturnType?.Equals(resource.ResourceCollection!.Type) == true);
        Assert.That(getter.Signature.Parameters.Select(p => p.Name), Is.EqualTo(new[] { "scope" }));
    }

    [Test]
    public void PublishedCollectionAccessorIgnoresRetainedAlias(
        [Values(false, true)] bool child,
        [Values(false, true)] bool aliasFirst,
        [Values(false, true)] bool legacy)
    {
        var (client, models) = InputResourceData.ClientWithResource(resourceName: "OS", resourceNameIsExplicit: false);
        var (parentClient, childClient, childModels) = InputResourceData.ClientWithNestedChildResource(childResourceName: "OS", resourceNameIsExplicit: false);
        ManagementMockHelpers.LoadMockPlugin(inputModels: () => child ? childModels : models,
            clients: () => child ? [parentClient, childClient] : [client]);
        var getter = legacy ? "GetOs" : "GetAllOS";
        var aliasName = legacy ? "GetAllOS" : "GetOs";
        var parameters = child ? "string nestedTypeName" : "";
        var arguments = child ? "nestedTypeName" : "";
        var factory = $"public virtual global::Samples.OSCollection {getter}({parameters}) => throw null;";
        var alias = $"public virtual global::Samples.OSCollection {aliasName}({parameters}) => {getter}({arguments});";
        var members = aliasFirst ? $"{alias}\n{factory}" : $"{factory}\n{alias}";
        var parentNamespace = child ? "Samples" : "Samples.Mocking";
        var parentName = child ? "ParentTypeResource" : "MockableSamplesResourceGroupResource";
        var contract = Helpers.BuildCompilation([
            ("Resources.cs", "namespace Samples { public class OSResource { } public class OSCollection { } }"),
            ("Parent.cs", $"namespace {parentNamespace} {{ public partial class {parentName} {{ {members} }} }}")
        ]);
        var customization = Helpers.BuildCompilation([
            ("Resources.cs", "namespace Samples { public class OSCollection { } }"),
            ("Parent.cs", $"namespace {parentNamespace} {{ public partial class {parentName} {{ {alias} }} }}")
        ]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => child ? childModels : models,
            clients: () => child ? [parentClient, childClient] : [client],
            customizationCompilation: () => customization, lastContractCompilation: () => contract);
        var resource = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single(r => r.ResourceName == "OS");
        Assert.That(resource.FactoryMethodSignature.Name, Is.EqualTo(getter));
        var parent = child
            ? (TypeProvider)plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single(r => r.ResourceName == "ParentType")
            : plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>()
                .Single(p => p.ArmCoreType.Equals(typeof(Azure.ResourceManager.Resources.ResourceGroupResource)));
        Assert.That(parent.CustomCodeView!.Methods.Any(m => m.Signature.Name == aliasName), Is.True);
        Assert.That(parent.Methods.Any(m => m.Signature.Name == getter &&
            m.Signature.ReturnType?.Equals(resource.ResourceCollection!.Type) == true), Is.True,
            "The retained alias must still have a generated forwarding target.");
    }

    [TestCase(false)]
    [TestCase(true)]
    public void PublishedAccessorCasingIsUsedInExtensionLists(bool legacy)
    {
        var (client, models) = InputResourceData.ClientWithExtensionScopedResourceList(resourceName: "OS", resourceNameIsExplicit: false);
        var getter = legacy ? "GetOs" : "GetAllOS";
        var listName = legacy ? "GetOs" : "GetOS";
        var contract = Helpers.BuildCompilation([
            ("Resources.cs", "namespace Samples { public class OSResource { } public class OSCollection { } }"),
            ("Parent.cs", $$"""
                namespace Samples.Mocking
                {
                    public class MockableSamplesSubscriptionResource
                    {
                        public virtual global::Samples.OSCollection {{getter}}() => throw null;
                    }
                }
                """)
        ]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client],
            lastContractCompilation: () => contract);
        var resource = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single();
        Assert.That(resource.FactoryMethodSignature.Name, Is.EqualTo(getter));
        var mockable = plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>()
            .Single(p => p.ArmCoreType.Equals(typeof(Azure.ResourceManager.ArmClient)));
        var extensions = plugin.Object.OutputLibrary.TypeProviders.OfType<ExtensionProvider>().Single();
        foreach (var provider in new TypeProvider[] { mockable, extensions })
        {
            Assert.That(provider.Methods.Any(m => m.Signature.Name == listName), Is.True);
            Assert.That(provider.Methods.Any(m => m.Signature.Name == $"{listName}Async"), Is.True);
        }
    }

    [TestCase("IpAddress")]
    [TestCase("DbCluster")]
    [TestCase("OsImage")]
    [TestCase("Ipv4Address")]
    [TestCase("Ipv6Address")]
    [TestCase("IPV4Address")]
    [TestCase("IPV6Address")]
    public void ExplicitAndLegacyNamesAreNotNormalized(string name)
    {
        Assert.That(CreateResource(name, true).ResourceName, Is.EqualTo(name));
        Assert.That(CreateResource(name, null).ResourceName, Is.EqualTo(name));
    }

    [TestCase("IpAddress", "IPAddress")]
    [TestCase("DbCluster", "DBCluster")]
    [TestCase("OsImage", "OSImage")]
    [TestCase("Ipv4Address", "IPv4Address")]
    [TestCase("Ipv6Address", "IPv6Address")]
    public void SingletonAndExtensionGettersUseFinalStem(string input, string expected)
    {
        var resource = CreateResource(input, false, singleton: true);
        Assert.That(resource.ResourceCollection, Is.Null);
        Assert.That(resource.FactoryMethodSignature.Name, Is.EqualTo($"Get{expected}"));
        Assert.That(resource.FactoryMethodSignature.ReturnType, Is.EqualTo(resource.Type));
        foreach (var kind in new[] { ResourceOperationKind.Read, ResourceOperationKind.Create, ResourceOperationKind.Update, ResourceOperationKind.Delete, ResourceOperationKind.List })
        {
            var prefix = kind switch
            {
                ResourceOperationKind.Create => "CreateOrUpdate",
                ResourceOperationKind.Update => "Update",
                ResourceOperationKind.Delete => "Delete",
                _ => "Get"
            };
            var stem = kind == ResourceOperationKind.List ? $"{expected}s" : expected;
            // Address pluralizes to Addresses rather than Addresss.
            if (kind == ResourceOperationKind.List && expected.EndsWith("Address"))
            {
                stem = $"{expected}es";
            }
            Assert.That(ResourceHelpers.GetExtensionOperationMethodName(kind, resource.ResourceName, false), Is.EqualTo($"{prefix}{stem}"));
            Assert.That(ResourceHelpers.GetExtensionOperationMethodName(kind, resource.ResourceName, true), Is.EqualTo($"{prefix}{stem}Async"));
        }
    }

    [TestCase("IpAddress", "GetIPAddresses")]
    [TestCase("DbCluster", "GetDBClusters")]
    [TestCase("OsImage", "GetOSImages")]
    [TestCase("Ipv4Address", "GetIPv4Addresses")]
    [TestCase("Ipv6Address", "GetIPv6Addresses")]
    public void ChildGettersUseFinalStem(string input, string getter)
    {
        var (parent, child, models) = InputResourceData.ClientWithNestedChildResource(childResourceName: input, resourceNameIsExplicit: false);
        var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [parent, child]);
        var parentResource = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>()
            .Single(r => r.ResourceName == "ParentType");
        var method = parentResource.Methods.Single(m => m.Signature.Name == getter);
        Assert.That(method.Signature.ReturnType, Is.EqualTo(parentResource.ChildResources.Single().ResourceCollection!.Type));
    }

    private static IEnumerable<TestCaseData> PreservedIdentities()
    {
        foreach (var name in new[] { "IpAddress", "DbCluster", "OsImage", "Ipv4Address", "Ipv6Address", "IPV4Address", "IPV6Address" })
        {
            foreach (var suffix in new[] { "Resource", "Collection" })
            {
                foreach (var lastContract in new[] { false, true })
                {
                    yield return new TestCaseData(name, suffix, lastContract);
                }
            }
        }
    }

    [TestCaseSource(nameof(PreservedIdentities))]
    public void CustomAndPublishedIdentitiesPreserveStem(string name, string suffix, bool lastContract)
    {
        var typeName = $"{name}{suffix}";
        var (client, models) = InputResourceData.ClientWithResource(resourceName: name, resourceNameIsExplicit: false);
        var compilation = Helpers.BuildCompilation([("Preserved.cs", $"namespace Samples {{ public partial class {typeName} {{ }} }}")]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(
            inputModels: () => models,
            clients: () => [client],
            customizationCompilation: lastContract ? null : () => compilation,
            lastContractCompilation: lastContract ? () => compilation : null);
        var resource = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single();
        Assert.That(resource.ResourceName, Is.EqualTo(name));
        Assert.That(resource.Name, Is.EqualTo($"{name}Resource"));
        Assert.That(resource.ResourceCollection!.Name, Is.EqualTo($"{name}Collection"));
        Assert.That(resource.FactoryMethodSignature.Name, Is.EqualTo(name.GetCollectionMethodName()));
        Assert.That(lastContract ? (typeName.EndsWith("Resource") ? resource.LastContractView : resource.ResourceCollection.LastContractView)
            : (typeName.EndsWith("Resource") ? resource.CustomCodeView : resource.ResourceCollection.CustomCodeView), Is.Not.Null);
    }

    [Test]
    public void GeneratedAcronymResourceUsesConsistentTypesAndAccessors()
    {
        var resource = typeof(Generated.IPAddressResource);
        var collection = typeof(Generated.IPAddressCollection);
        Assert.That(resource.GetProperty("Data")!.PropertyType, Is.EqualTo(typeof(Generated.IPAddressData)));
        Assert.That(resource.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)
            .Any(c => c.GetParameters().Any(p => p.ParameterType == typeof(Generated.IPAddressData))), Is.True);
        Assert.That(collection.GetMethod("GetAll")!.ReturnType, Is.EqualTo(typeof(Pageable<Generated.IPAddressResource>)));
        Assert.That(typeof(Generated.AzureGeneratorMgmtTypeSpecTestsExtensions).GetMethod("GetIPAddresses")!.ReturnType, Is.EqualTo(collection));
        Assert.That(typeof(Generated.AzureGeneratorMgmtTypeSpecTestsExtensions).GetMethod("GetIPAddressResource")!.ReturnType, Is.EqualTo(resource));
        Assert.That(resource.Assembly.GetType("Azure.Generator.MgmtTypeSpec.Tests.IpAddressResource"), Is.Null);
        Assert.That(Generated.IPAddressResource.ResourceType.ToString(), Is.EqualTo("MgmtTypeSpec/ipAddresses"));
    }

    [Test]
    public void CodeGenTypeIdentityIsFoundBeforeNormalization()
    {
        var (client, models) = InputResourceData.ClientWithResource(resourceName: "IpAddress", resourceNameIsExplicit: false);
        var plugin = ManagementMockHelpers.LoadMockPlugin(
            inputModels: () => models,
            clients: () => [client],
            customizationSources: ["""
                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    internal class CodeGenTypeAttribute : System.Attribute
                    {
                        public CodeGenTypeAttribute(string originalName) { }
                    }
                }
                namespace Samples
                {
                    [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("IpAddressResource")]
                    public partial class CustomIPResource { }
                }
                """]);
        var resource = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single();
        Assert.That(resource.ResourceName, Is.EqualTo("IpAddress"));
        Assert.That(resource.CustomCodeView!.Name, Is.EqualTo("CustomIPResource"));
    }

    private static ResourceClientProvider CreateResource(string name, bool? isExplicit, bool singleton = false)
    {
        var (client, models) = InputResourceData.ClientWithResource(
            resourceName: name, resourceNameIsExplicit: isExplicit, singletonResourceName: singleton ? "default" : null);
        var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
        return plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single();
    }
}
