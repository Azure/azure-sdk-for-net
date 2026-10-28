// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core;
using Azure.Generator.MgmtTypeSpec.Tests.Models;
using NUnit.Framework;

namespace Azure.Generator.MgmtTypeSpec.Tests
{
    internal class GenericModelFactoryTests
    {
        [Test]
        public void AnonymousAndDictionaryInputsUseCSharpNames()
        {
            var anonymous = MgmtTypeSpecTestsModelFactory.Create<FooDependency>(new { DependencyName = "storage", Version = "1" });
            IReadOnlyDictionary<string, object> bag = new Dictionary<string, object>
            {
                [nameof(FooDependency.DependencyName)] = "storage",
                [nameof(FooDependency.Version)] = "1"
            };
            var dictionary = MgmtTypeSpecTestsModelFactory.Create<FooDependency>(bag);
            Assert.That(dictionary.DependencyName, Is.EqualTo(anonymous.DependencyName));
            Assert.That(dictionary.Version, Is.EqualTo(anonymous.Version));
        }

        [Test]
        public void WritableAndIncompleteModelsAreSupported()
        {
            var writable = MgmtTypeSpecTestsModelFactory.Create<CheckNameAvailabilityRequest>(new { Name = "test" });
            Assert.That(writable.Name, Is.EqualTo("test"));
            Assert.That(writable.Type, Is.Null);
            var incomplete = MgmtTypeSpecTestsModelFactory.Create<FooData>(new { Name = "incomplete" });
            Assert.That(incomplete.Name, Is.EqualTo("incomplete"));
            Assert.That(incomplete.Something, Is.Null, "Required constructor values may be omitted for mocking.");
        }

        [TestCase(false)]
        [TestCase(true)]
        public void NestedAnonymousObjectsAndDictionaries(bool useDictionary)
        {
            object properties = useDictionary
                ? new Dictionary<string, object>
                {
                    [nameof(PrivateLink.Properties)] = new Dictionary<string, object>
                    {
                        [nameof(AzureGeneratorMgmtTypeSpecTestsPrivateLinkResourceProperties.GroupId)] = "group",
                        [nameof(AzureGeneratorMgmtTypeSpecTestsPrivateLinkResourceProperties.RequiredMembers)] = new[] { "a", "b" }
                    }
                }
                : new { Properties = new { GroupId = "group", RequiredMembers = new[] { "a", "b" } } };
            var model = MgmtTypeSpecTestsModelFactory.Create<PrivateLink>(properties);
            Assert.That(model.Properties.GroupId, Is.EqualTo("group"));
            Assert.That(model.Properties.RequiredMembers, Is.EqualTo(new[] { "a", "b" }));
        }

        [Test]
        public void ConstructedNestedModelsAreShared()
        {
            var properties = MgmtTypeSpecTestsModelFactory.Create<AzureGeneratorMgmtTypeSpecTestsPrivateLinkResourceProperties>(new { GroupId = "group" });
            var model = MgmtTypeSpecTestsModelFactory.Create<PrivateLink>(new { Properties = properties });
            Assert.That(model.Properties, Is.SameAs(properties));
        }

        [Test]
        public void CollectionsAcceptMixedConstructedAndAnonymousModels()
        {
            var constructed = MgmtTypeSpecTestsModelFactory.Create<CycleTestConnectionReference>(new { Name = "first" });
            var list = MgmtTypeSpecTestsModelFactory.Create<CycleTestStoreProperties>(new
            {
                Connections = new object[] { constructed, new { Name = "second", ProvisioningState = "Succeeded" } }
            });
            Assert.That(list.Connections.Select(item => item.Name), Is.EqualTo(new[] { "first", "second" }));
            Assert.That(list.Connections[0], Is.SameAs(constructed));
            Assert.That(list.Connections[1].ProvisioningState, Is.EqualTo("Succeeded"));
        }

        [Test]
        public void DictionaryPropertiesAcceptAnonymousAndReadOnlyBags()
        {
            var anonymous = MgmtTypeSpecTestsModelFactory.Create<FooData>(new { Tags = new { environment = "test" } });
            IReadOnlyDictionary<string, object> tags = new System.Collections.ObjectModel.ReadOnlyDictionary<string, object>(
                new Dictionary<string, object> { ["environment"] = "test" });
            var dictionary = MgmtTypeSpecTestsModelFactory.Create<FooData>(new { Tags = tags });
            Assert.That(anonymous.Tags["environment"], Is.EqualTo("test"));
            Assert.That(dictionary.Tags["environment"], Is.EqualTo("test"));
        }

        [Test]
        public void CurrentCreatesNewInstanceAndAllowsExplicitNull()
        {
            var baseline = MgmtTypeSpecTestsModelFactory.Create<FooDependency>(new { DependencyName = "original", Version = "1" });
            var changed = MgmtTypeSpecTestsModelFactory.Create<FooDependency>(new { Version = "2" }, baseline);
            var cleared = MgmtTypeSpecTestsModelFactory.Create<FooDependency>(new Dictionary<string, object> { [nameof(FooDependency.Version)] = null }, baseline);
            Assert.That(changed, Is.Not.SameAs(baseline));
            Assert.That(changed.DependencyName, Is.EqualTo("original"));
            Assert.That(changed.Version, Is.EqualTo("2"));
            Assert.That(cleared.Version, Is.Null);
            Assert.That(baseline.Version, Is.EqualTo("1"));
        }

        [Test]
        public void InheritedAndMultiLevelFlattenedValuesSurviveCopy()
        {
            var id = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Test/widgets/item");
            var baseline = MgmtTypeSpecTestsModelFactory.Create<FooData>(new
            {
                Id = id, Name = "original", Location = new AzureLocation("eastus"),
                ComputeFleetVmCapacityReservationGroupId = id, Prop1 = new[] { "first" }, BoolValue = true,
                Tags = new Dictionary<string, string> { ["environment"] = "test" }
            });
            var changed = MgmtTypeSpecTestsModelFactory.Create<FooData>(new { Name = "copy" }, baseline);
            Assert.That(changed.Id, Is.EqualTo(id));
            Assert.That(changed.Location, Is.EqualTo(baseline.Location));
            Assert.That(changed.ComputeFleetVmCapacityReservationGroupId, Is.EqualTo(id));
            Assert.That(changed.BoolValue, Is.True);
            Assert.That(changed.Prop1, Is.EqualTo(new[] { "first" }));
            changed.Prop1.Add("second");
            Assert.That(baseline.Prop1, Is.EqualTo(new[] { "first" }), "The existing list factory clones its collection.");
            Assert.That(baseline.Name, Is.EqualTo("original"));
            // Dictionary containers follow shallow sharing semantics, as documented.
            Assert.That(changed.Tags, Is.SameAs(baseline.Tags));
        }

        [Test]
        public void CopyDoesNotInvokeLazyFlattenedCollectionGettersOnTemplate()
        {
            var baseline = MgmtTypeSpecTestsModelFactory.Create<FooData>(new { Name = "empty" });
            var wrapper = typeof(FooData).GetProperty("Properties", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(wrapper.GetValue(baseline), Is.Null);
            var copy = MgmtTypeSpecTestsModelFactory.Create<FooData>(new { Name = "copy" }, baseline);
            Assert.That(wrapper.GetValue(baseline), Is.Null);
            Assert.That(copy.Name, Is.EqualTo("copy"));
        }

        [Test]
        public void DerivedModelsKeepInheritedPropertiesAndDiscriminator()
        {
            var model = MgmtTypeSpecTestsModelFactory.Create<TypeAPolyDevice>(new { Name = "device", TypeAPolyDeviceDescription = "description" });
            var copy = MgmtTypeSpecTestsModelFactory.Create<TypeAPolyDevice>(new { Name = "copy" }, model);
            Assert.That(model.Name, Is.EqualTo("device"));
            Assert.That(copy.Name, Is.EqualTo("copy"));
            Assert.That(typeof(PolyDeviceData).GetProperty("Kind", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(copy), Is.EqualTo("TypeA"));
            Assert.That(copy.TypeAPolyDeviceDescription, Is.EqualTo("description"));
        }

        [TestCase("version")]
        [TestCase("DoesNotExist")]
        public void UnknownNamesAreRejectedEvenWithCaseInsensitiveDictionary(string name)
        {
            var error = Assert.Throws<ArgumentException>(() => MgmtTypeSpecTestsModelFactory.Create<FooDependency>(
                new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase) { [name] = "bad" }));
            Assert.That(error.Message, Does.Contain(name));
        }

        [Test]
        public void IncorrectTypesAndNestedPathsAreReported()
        {
            Assert.That(Assert.Throws<ArgumentException>(() => MgmtTypeSpecTestsModelFactory.Create<FooDependency>(new { Version = 3 })).Message,
                Does.Contain("Version"));
            Assert.That(Assert.Throws<ArgumentException>(() => MgmtTypeSpecTestsModelFactory.Create<PrivateLink>(new { Properties = new { Misspelled = "bad" } })).Message,
                Does.Contain("Properties").And.Contain("Misspelled"));
            Assert.That(Assert.Throws<ArgumentException>(() => MgmtTypeSpecTestsModelFactory.Create<CycleTestStoreProperties>(new
            {
                Connections = new[] { new { ProvisioningState = 1 } }
            })).Message, Does.Contain("Connections[0]").And.Contain("ProvisioningState"));
            Assert.Throws<ArgumentException>(() => MgmtTypeSpecTestsModelFactory.Create<FooData>(new Dictionary<string, object> { [nameof(FooData.Location)] = null }));
        }

        [Test]
        public void NullAndUnsupportedInputsAreRejected()
        {
            Assert.Throws<ArgumentNullException>(() => MgmtTypeSpecTestsModelFactory.Create<FooDependency>((object)null));
            Assert.Throws<ArgumentNullException>(() => MgmtTypeSpecTestsModelFactory.Create<FooDependency>((IReadOnlyDictionary<string, object>)null));
            Assert.Throws<ArgumentException>(() => MgmtTypeSpecTestsModelFactory.Create<FooDependency>("not a bag"));
            Assert.Throws<ArgumentException>(() => MgmtTypeSpecTestsModelFactory.Create<Uri>(new { }));
        }

        [Test]
        public void OnlyGenericCreateMethodsArePublic()
        {
            var methods = typeof(MgmtTypeSpecTestsModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            Assert.That(methods.Length, Is.EqualTo(2));
            Assert.That(methods.All(method => method.Name == "Create" && method.IsGenericMethodDefinition), Is.True);
        }
    }
}