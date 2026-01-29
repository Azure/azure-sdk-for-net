// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace System.ClientModel.Tests.Internal;

public class ReferenceConfigurationSectionTests
{
    [Test]
    public void BasicValueAccess()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Section:Key"] = "Value"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");

        Assert.AreEqual("Value", section["Key"]);
    }

    [Test]
    public void DirectValue()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Section"] = "DirectValue"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");

        Assert.AreEqual("DirectValue", section.Value);
    }

    [Test]
    public void DereferenceSimpleValue()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Target"] = "RealValue",
                ["Reference"] = "$Target"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Reference");

        Assert.AreEqual("RealValue", section.Value);
    }

    [Test]
    public void DereferenceNestedValue()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Target:Nested"] = "NestedValue",
                ["Reference"] = "$Target:Nested"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Reference");

        Assert.AreEqual("NestedValue", section.Value);
    }

    [Test]
    public void DereferenceChainedReferences()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Final"] = "FinalValue",
                ["Middle"] = "$Final",
                ["Reference"] = "$Middle"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Reference");

        Assert.AreEqual("FinalValue", section.Value);
    }

    [Test]
    public void NonExistentReferenceReturnsOriginalValue()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Reference"] = "$NonExistent"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Reference");

        Assert.AreEqual("$NonExistent", section.Value);
    }

    [Test]
    public void ValueNotStartingWithDollarReturnsAsIs()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Section"] = "NormalValue"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");

        Assert.AreEqual("NormalValue", section.Value);
    }

    [Test]
    public void SingleDollarReturnsAsIs()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Section"] = "$"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");

        Assert.AreEqual("$", section.Value);
    }

    [Test]
    public void NullValueReturnsNull()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>())
            .Build();

        ReferenceConfigurationSection section = new(config, "NonExistent");

        Assert.IsNull(section.Value);
    }

    [Test]
    public void ExplicitNullValueReturnsNull()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>()
            {
                ["Section"] = null
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");

        Assert.IsNull(section.Value);
    }

    [Test]
    public void GetSectionReturnsReferencedSection()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Target:SubKey"] = "SubValue",
                ["Section:Child"] = "$Target"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");
        IConfigurationSection child = section.GetSection("Child");

        Assert.AreEqual("SubValue", child["SubKey"]);
    }

    [Test]
    public void GetSectionHandlesNonExistentReference()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Section:Child"] = "$NonExistent"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");
        IConfigurationSection child = section.GetSection("Child");

        Assert.AreEqual("$NonExistent", child.Value);
    }

    [Test]
    public void GetChildrenReturnsAllChildren()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Section:Child1"] = "Value1",
                ["Section:Child2"] = "Value2",
                ["Section:Child3"] = "Value3"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");
        List<IConfigurationSection> children = section.GetChildren().ToList();

        Assert.AreEqual(3, children.Count);
        Assert.IsTrue(children.Any(c => c.Key == "Child1" && c.Value == "Value1"));
        Assert.IsTrue(children.Any(c => c.Key == "Child2" && c.Value == "Value2"));
        Assert.IsTrue(children.Any(c => c.Key == "Child3" && c.Value == "Value3"));
    }

    [Test]
    public void GetChildrenWithReferences()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Section:Target"] = "ReferencedValue",
                ["Section:Child1"] = "NormalValue",
                ["Section:Child2"] = "$Section:Target"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");
        List<IConfigurationSection> children = section.GetChildren().ToList();

        Assert.AreEqual(3, children.Count);
        IConfigurationSection child1 = children.First(c => c.Key == "Child1");
        IConfigurationSection child2 = children.First(c => c.Key == "Child2");

        Assert.AreEqual("NormalValue", child1.Value);
        Assert.AreEqual("ReferencedValue", child2.Value);
    }

    [Test]
    public void GetChildrenCanReferenceRootConfiguration()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["RootLevel:SharedValue"] = "ValueFromRoot",
                ["Section:Child1"] = "NormalValue",
                ["Section:Child2"] = "$RootLevel:SharedValue"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");
        List<IConfigurationSection> children = section.GetChildren().ToList();

        Assert.AreEqual(2, children.Count);
        IConfigurationSection child1 = children.First(c => c.Key == "Child1");
        IConfigurationSection child2 = children.First(c => c.Key == "Child2");

        Assert.AreEqual("NormalValue", child1.Value);
        Assert.AreEqual("ValueFromRoot", child2.Value);
    }

    [Test]
    public void NestedChildrenCanReferenceRootConfiguration()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["SharedConfig:ApiKey"] = "root-api-key",
                ["Section:Level1:Level2:Reference"] = "$SharedConfig:ApiKey"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");
        IConfigurationSection level1 = section.GetSection("Level1");
        IConfigurationSection level2 = level1.GetSection("Level2");
        IConfigurationSection reference = level2.GetSection("Reference");

        Assert.AreEqual("root-api-key", reference.Value);
    }

    [Test]
    public void KeyReturnsCorrectKey()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["MySection:MyKey"] = "Value"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "MySection");
        IConfigurationSection subsection = section.GetSection("MyKey");

        Assert.AreEqual("MyKey", subsection.Key);
    }

    [Test]
    public void PathReturnsCorrectPath()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["MySection:MyKey"] = "Value"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "MySection");

        Assert.AreEqual("MySection", section.Path);
    }

    [Test]
    public void IndexerSetter()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Section:Key"] = "OldValue"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");
        section["Key"] = "NewValue";

        Assert.AreEqual("NewValue", section["Key"]);
    }

    [Test]
    public void ValueSetter()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Section"] = "OldValue"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");
        section.Value = "NewValue";

        Assert.AreEqual("NewValue", section.Value);
    }

    [Test]
    public void ComplexScenarioWithMultipleLevels()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Credentials:ApiKey"] = "secret-key",
                ["Credentials:Type"] = "ApiKey",
                ["ServiceA:Endpoint"] = "https://service-a.com",
                ["ServiceA:Credential"] = "$Credentials",
                ["ServiceB:Endpoint"] = "https://service-b.com",
                ["ServiceB:Credential"] = "$Credentials"
            })
            .Build();

        ReferenceConfigurationSection serviceA = new(config, "ServiceA");
        IConfigurationSection credentialSection = serviceA.GetSection("Credential");

        Assert.AreEqual("secret-key", credentialSection["ApiKey"]);
        Assert.AreEqual("ApiKey", credentialSection["Type"]);
    }

    [Test]
    public void GetReloadTokenReturnsToken()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Section"] = "Value"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");
        IChangeToken token = section.GetReloadToken();

        Assert.IsNotNull(token);
    }

    [Test]
    public void CircularReferenceValue_ThrowsInvalidOperationException()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["A"] = "$B",
                ["B"] = "$A"
            })
            .Build();

        ReferenceConfigurationSection sectionA = new(config, "A");

        InvalidOperationException? ex = Assert.Throws<InvalidOperationException>(() => { var value = sectionA.Value; });
        Assert.That(ex!.Message, Does.Contain("Circular reference detected"));
        Assert.That(ex.Message, Does.Contain("reference chain"));
    }

    [Test]
    public void CircularReferenceSection_ThrowsInvalidOperationException()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Section:A"] = "$Section:B",
                ["Section:B"] = "$Section:A"
            })
            .Build();

        ReferenceConfigurationSection section = new(config, "Section");

        InvalidOperationException? ex = Assert.Throws<InvalidOperationException>(() => { var childA = section.GetSection("A"); });
        Assert.That(ex!.Message, Does.Contain("Circular reference detected"));
        Assert.That(ex.Message, Does.Contain("reference chain"));
    }

    [Test]
    public void CircularReferenceChain_ThrowsInvalidOperationException()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["A"] = "$B",
                ["B"] = "$C",
                ["C"] = "$A"
            })
            .Build();

        ReferenceConfigurationSection sectionA = new(config, "A");

        InvalidOperationException? ex = Assert.Throws<InvalidOperationException>(() => { var value = sectionA.Value; });
        Assert.That(ex!.Message, Does.Contain("Circular reference detected"));
        Assert.That(ex.Message, Does.Contain("reference chain"));
    }

    [Test]
    public void CircularReferenceSelfReference_ThrowsInvalidOperationException()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["A"] = "$A"
            })
            .Build();

        ReferenceConfigurationSection sectionA = new(config, "A");

        InvalidOperationException? ex = Assert.Throws<InvalidOperationException>(() => { var value = sectionA.Value; });
        Assert.That(ex!.Message, Does.Contain("Circular reference detected"));
        Assert.That(ex.Message, Does.Contain("'A'"));
    }

    [Test]
    public void ReferenceToNonExistentSection_ReturnsOriginalReferenceString()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["A"] = "$NonExistent"
            })
            .Build();

        ReferenceConfigurationSection sectionA = new(config, "A");

        Assert.That(sectionA.Value, Is.EqualTo("$NonExistent"));
    }

    [Test]
    public void CircularReferenceAfterValidReference_ThrowsInvalidOperationException()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["A"] = "$B",
                ["B"] = "$C",
                ["C"] = "$D",
                ["D"] = "$B"  // Loop back to B
            })
            .Build();

        ReferenceConfigurationSection sectionA = new(config, "A");

        InvalidOperationException? ex = Assert.Throws<InvalidOperationException>(() => { var value = sectionA.Value; });
        Assert.That(ex!.Message, Does.Contain("Circular reference detected"));
        Assert.That(ex.Message, Does.Contain("reference chain"));
    }
}
