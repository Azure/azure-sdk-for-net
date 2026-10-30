// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Storage;
using NUnit.Framework;

namespace Azure.Provisioning.Tests;

public class BicepExtensionConstructTests
{
    private const string GraphReference = "br:mcr.microsoft.com/bicep/extensions/microsoftgraph/v1.0:1.0.0";

    [Test]
    public void DeclareGraphExtension()
    {
        #region Snippet:DeclareBicepExtension
        Infrastructure infrastructure = new();
        BicepExtensionConstruct graph = new(
            "br:mcr.microsoft.com/bicep/extensions/microsoftgraph/v1.0:1.0.0",
            alias: "graph");
        infrastructure.Add(graph);

        string bicep = infrastructure.Build().Compile()["main.bicep"];
        #endregion
        Assert.That(bicep, Is.EqualTo($"extension '{GraphReference}' as graph"));
    }

    [TestCase("kubernetes", null, "extension kubernetes")]
    [TestCase("kubernetes", "k8s", "extension kubernetes as k8s")]
    [TestCase(GraphReference, null, "extension '" + GraphReference + "'")]
    [TestCase(GraphReference, "graph", "extension '" + GraphReference + "' as graph")]
    [TestCase("./extension.tgz", "local", "extension './extension.tgz' as local")]
    [TestCase("./it's-an-extension.tgz", null, "extension './it\\'s-an-extension.tgz'")]
    public void CompilesReferenceAndOptionalAlias(string reference, string? alias, string expected)
    {
        Infrastructure infrastructure = new();
        infrastructure.Add(new BicepExtensionConstruct(reference, alias));

        Assert.That(infrastructure.Build().Compile()["main.bicep"], Is.EqualTo(expected));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void RejectsMissingReference(string? reference)
    {
        Assert.That(() => new BicepExtensionConstruct(reference!), Throws.InstanceOf<ArgumentException>());
    }

    [TestCase("")]
    [TestCase("1graph")]
    [TestCase("my-graph")]
    [TestCase("graph\nresource")]
    public void RejectsInvalidAlias(string alias)
    {
        Assert.Throws<ArgumentException>(() => new BicepExtensionConstruct(GraphReference, alias));

        BicepExtensionConstruct extension = new(GraphReference);
        Assert.Throws<ArgumentException>(() => extension.Alias = alias);
        Assert.That(extension.Alias, Is.Null);
    }

    [Test]
    public void AliasCanBeChangedOrRemoved()
    {
        Infrastructure infrastructure = new();
        BicepExtensionConstruct extension = new(GraphReference, "graph");
        infrastructure.Add(extension);
        extension.Alias = "otherGraph";
        Assert.That(infrastructure.Build().Compile()["main.bicep"], Does.EndWith(" as otherGraph"));

        extension.Alias = null;
        Assert.That(infrastructure.Build().Compile()["main.bicep"], Is.EqualTo($"extension '{GraphReference}'"));
    }

    [Test]
    public void CompilesDirectConfigurationWithParametersAndNestedValues()
    {
        Infrastructure infrastructure = new();
        ProvisioningParameter kubeConfig = new("kubeConfig", typeof(string)) { IsSecure = true };
        BicepExtensionConstruct extension = new("kubernetes", "k8s");
        extension.ProvisionableProperties["namespace"] = new BicepValue<string>("default");
        extension.ProvisionableProperties["kubeConfig"] = (BicepValue<string>)kubeConfig;
        extension.ProvisionableProperties["settings"] = new BicepDictionary<object>
        {
            ["enabled"] = true,
            ["retryCount"] = 3
        };
        extension.ProvisionableProperties["names"] = new BicepList<string> { "first", "second" };
        BicepValue<string> unset = new(string.Empty);
        unset.ClearValue();
        extension.ProvisionableProperties["unset"] = unset;
        infrastructure.Add(kubeConfig);
        infrastructure.Add(extension);

        AssertBicep(
            """
            extension kubernetes with {
              namespace: 'default'
              kubeConfig: kubeConfig
              settings: {
                enabled: true
                retryCount: 3
              }
              names: [
                'first'
                'second'
              ]
            } as k8s

            @secure()
            param kubeConfig string
            """,
            infrastructure);
    }

    [Test]
    public void EscapesConfigurationKeysAndValues()
    {
        BicepExtensionConstruct extension = new("custom");
        extension.ProvisionableProperties["it's-a-key"] = new BicepValue<string>("it's a value\n${notAnExpression}");
        extension.ProvisionableProperties[""] = new BicepValue<bool>(false);
        extension.ProvisionableProperties["1key"] = new BicepValue<int>(1);
        Infrastructure infrastructure = new();
        infrastructure.Add(extension);

        AssertBicep(
            """
            extension custom with {
              'it\'s-a-key': 'it\'s a value\n\${notAnExpression}'
              '': false
              '1key': 1
            }
            """,
            infrastructure);
    }

    [Test]
    public void OmitsConfigurationWhenAllValuesAreUnset()
    {
        BicepExtensionConstruct extension = new("kubernetes");
        BicepValue<string> unset = new(string.Empty);
        unset.ClearValue();
        extension.ProvisionableProperties["unset"] = unset;
        Infrastructure infrastructure = new();
        infrastructure.Add(extension);

        AssertBicep("extension kubernetes", infrastructure);
    }

    [Test]
    public void TypedSubclassSupportsDirectEntriesAndNestedPropertyPaths()
    {
        TypedExtension extension = new();
        extension.ProvisionableProperties["extra"] = new BicepValue<bool>(true);
        Infrastructure infrastructure = new();
        infrastructure.Add(extension);

        Assert.Throws<InvalidOperationException>(() => infrastructure.Build());

        extension.Cluster = "clusterName";
        AssertBicep(
            """
            extension custom with {
              extra: true
              connection: {
                cluster: 'clusterName'
              }
            } as typed
            """,
            infrastructure);
    }

    [Test]
    public void RejectsExpressionOverride()
    {
        ValidatableExtension extension = new();
        ((IBicepValue)extension).Expression = new IdentifierExpression("other");
        Assert.Throws<InvalidOperationException>(() => extension.ValidateDeclaration());
    }

    [Test]
    public void DirectConfigurationUsesDictionaryKeyForResourceReferences()
    {
        ApplicationResource app = new("app", "graph") { DisplayName = "example" };
        BicepExtensionConstruct extension = new("custom");
        extension.ProvisionableProperties["applicationId"] = app.Id;
        Infrastructure infrastructure = new();
        infrastructure.Add(extension);

        AssertBicep(
            """
            extension custom with {
              applicationId: app.id
            }
            """,
            infrastructure);
    }

    [Test]
    public void PreservesMultipleInstancesWithDifferentAliases()
    {
        Infrastructure infrastructure = new();
        infrastructure.Add(new BicepExtensionConstruct(GraphReference, "graph1"));
        infrastructure.Add(new BicepExtensionConstruct(GraphReference, "graph2"));

        AssertBicep(
            $"""
            extension '{GraphReference}' as graph1

            extension '{GraphReference}' as graph2
            """,
            infrastructure);
    }

    [Test]
    public void CanAddAndRemoveExtension()
    {
        Infrastructure infrastructure = new();
        BicepExtensionConstruct extension = new(GraphReference, "graph");
        infrastructure.Add(extension);
        infrastructure.Add(extension);
        Assert.That(infrastructure.GetProvisionableResources().Count(), Is.EqualTo(1));
        Assert.That(extension.ParentInfrastructure, Is.SameAs(infrastructure));

        infrastructure.Remove(extension);
        Assert.That(extension.ParentInfrastructure, Is.Null);
        Assert.That(infrastructure.Build().Compile()["main.bicep"], Is.Empty);
    }

    [Test]
    public void ComposesWithArmAndExtensionResourcesAndOutputs()
    {
        Infrastructure infrastructure = new();
        BicepExtensionConstruct graph = new(GraphReference, "graph");
        ApplicationResource app = new("app", graph.Alias!) { DisplayName = "example" };
        ApplicationResource dependent = new("dependent", graph.Alias!) { DisplayName = "dependent" };
        dependent.DependsOn.Add(app);
        StorageAccount storage = new("storage")
        {
            Name = "examplestorage",
            Location = AzureLocation.WestUS2,
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs }
        };
        infrastructure.Add(app);
        infrastructure.Add(dependent);
        infrastructure.Add(storage);
        infrastructure.Add(new ProvisioningOutput("appId", typeof(string)) { Value = app.Id });
        infrastructure.Add(graph);

        string source = infrastructure.Build().Compile()["main.bicep"].NormalizeLineEndings();
        Assert.That(source, Does.StartWith($"extension '{GraphReference}' as graph"));
        Assert.That(source, Does.Contain("resource app 'graph:Microsoft.Graph/applications@v1.0'"));
        Assert.That(source, Does.Contain("resource storage 'Microsoft.Storage/storageAccounts@"));
        Assert.That(source, Does.Contain("dependsOn: [\n    app\n  ]"));
        Assert.That(source, Does.Contain("output appId string = app.id"));
    }

    [Test]
    public void CompileAndSaveKeepDeclarationsInTheirOwningModule()
    {
        Infrastructure root = new("main");
        root.Add(new ProvisioningOutput("message", typeof(string)) { Value = "root" });
        Infrastructure child = new("child");
        child.Add(new BicepExtensionConstruct(GraphReference, "graph"));
        ProvisioningBuildOptions options = new();
        options.InfrastructureResolvers.Add(new ChildInfrastructureResolver(child));
        ProvisioningPlan plan = root.Build(options);

        IDictionary<string, string> files = plan.Compile();
        Assert.That(files["main.bicep"], Does.Not.Contain("extension "));
        Assert.That(files["child.bicep"], Is.EqualTo($"extension '{GraphReference}' as graph"));

        string directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            string[] paths = plan.Save(directory).ToArray();
            Assert.That(paths.Length, Is.EqualTo(2));
            foreach (string path in paths)
            {
                Assert.That(File.ReadAllText(path), Is.EqualTo(files[Path.GetFileName(path)]));
            }
        }
        finally
        {
            Directory.Delete(directory, recursive: true);
        }
    }

    private static void AssertBicep(string expected, Infrastructure infrastructure) =>
        Assert.That(infrastructure.Build().Compile()["main.bicep"].NormalizeLineEndings(),
            Is.EqualTo(expected.NormalizeLineEndings()));

    private sealed class TypedExtension() : BicepExtensionConstruct("custom", "typed")
    {
        public BicepValue<string> Cluster
        {
            get { Initialize(); return _cluster!; }
            set { Initialize(); _cluster!.Assign(value); }
        }

        private BicepValue<string>? _cluster;

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _cluster = DefineProperty<string>(nameof(Cluster), ["connection", "cluster"], isRequired: true);
        }
    }

    private sealed class ValidatableExtension() : BicepExtensionConstruct("kubernetes")
    {
        public void ValidateDeclaration() => Validate();
    }

    private sealed class ApplicationResource(string name, string extensionAlias)
        : ProvisionableResource(name, $"{extensionAlias}:Microsoft.Graph/applications", "v1.0")
    {
        public BicepValue<string> DisplayName
        {
            get { Initialize(); return _displayName!; }
            set { Initialize(); _displayName!.Assign(value); }
        }
        private BicepValue<string>? _displayName;

        public BicepValue<string> Id { get { Initialize(); return _id!; } }
        private BicepValue<string>? _id;

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _displayName = DefineProperty<string>(nameof(DisplayName), ["displayName"], isRequired: true);
            _id = DefineProperty<string>(nameof(Id), ["id"], isOutput: true);
        }
    }

    private sealed class ChildInfrastructureResolver(Infrastructure child) : InfrastructureResolver
    {
        public override IEnumerable<Infrastructure> GetNestedInfrastructure(
            Infrastructure infrastructure, ProvisioningBuildOptions options) => [child];
    }
}
