// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Provisioning.Tests.TestHelpers;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Azure.Generator.Provisioning.Tests
{
    public class ProvisioningTypeFactoryTests
    {
        private ProvisioningTypeFactory _factory = null!;

        [SetUp]
        public void SetUp()
        {
            _factory = ProvisioningMockHelpers.LoadMockPlugin().Object.TypeFactory;
        }

        [TestCaseSource(nameof(PrimitiveTypeCases))]
        public void PrimitiveTypeIsWrappedInBicepValue(InputPrimitiveType input, CSharpType expected, string expectedType)
        {
            var type = _factory.CreateCSharpType(input);

            // Expected: BicepValue<T>, with concrete T supplied by PrimitiveTypeCases.
            Assert.That(type, Is.EqualTo(expected), expectedType);
        }

        [Test]
        public void NullablePrimitiveTypeIsNotDoubleWrapped()
        {
            var type = _factory.CreateCSharpType(new InputNullableType(InputPrimitiveType.String));

            // Expected: BicepValue<string>?
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepValue<>), true, typeof(string))));
        }

        [Test]
        public void EnumTypeIsWrappedInBicepValue()
        {
            var input = CreateStringEnum();

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepValue<TestEnum>
            Assert.That(type, Is.Not.Null);
            Assert.That(type!.FrameworkType.GetGenericTypeDefinition(), Is.EqualTo(typeof(BicepValue<>)));
            Assert.That(type!.Arguments[0].Name, Is.EqualTo("TestEnum"));
            Assert.That(type.Arguments[0].Namespace, Is.EqualTo("Azure.Provisioning.Tests"));
        }

        [Test]
        public void NullableEnumTypeIsNotDoubleWrapped()
        {
            var input = new InputNullableType(CreateStringEnum());

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepValue<TestEnum>?
            Assert.That(type, Is.Not.Null);
            Assert.That(type!.FrameworkType.GetGenericTypeDefinition(), Is.EqualTo(typeof(BicepValue<>)));
            Assert.That(type.IsNullable, Is.True);
            Assert.That(type!.Arguments[0].Name, Is.EqualTo("TestEnum"));
            Assert.That(type.Arguments[0].Namespace, Is.EqualTo("Azure.Provisioning.Tests"));
        }

        [Test]
        public void ArrayTypeIsConvertedToBicepList()
        {
            var input = new InputArrayType("list", "list", InputPrimitiveType.String);

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepList<string>
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepList<>), typeof(string))));
        }

        [Test]
        public void NullableArrayTypeIsNotWrappedInBicepValue()
        {
            var input = new InputNullableType(new InputArrayType("list", "list", InputPrimitiveType.String));

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepList<string>?
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepList<>), true, typeof(string))));
        }

        [Test]
        public void DictionaryTypeIsConvertedToBicepDictionary()
        {
            var input = new InputDictionaryType("dictionary", InputPrimitiveType.String, InputPrimitiveType.String);

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepDictionary<string>
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepDictionary<>), typeof(string))));
        }

        [Test]
        public void NestedArrayTypeIsConvertedToNestedBicepList()
        {
            var input = new InputArrayType(
                "list",
                "list",
                new InputArrayType("list", "list", InputPrimitiveType.String));

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepList<BicepList<string>>
            Assert.That(type, Is.EqualTo(new CSharpType(
                typeof(BicepList<>),
                new CSharpType(typeof(BicepList<>), typeof(string)))));
        }

        [Test]
        public void NestedDictionaryTypeIsConvertedToNestedBicepDictionary()
        {
            var input = new InputDictionaryType(
                "dictionary",
                InputPrimitiveType.String,
                new InputDictionaryType("dictionary", InputPrimitiveType.String, InputPrimitiveType.String));

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepDictionary<BicepDictionary<string>>
            Assert.That(type, Is.EqualTo(new CSharpType(
                typeof(BicepDictionary<>),
                new CSharpType(typeof(BicepDictionary<>), typeof(string)))));
        }

        [Test]
        public void ArrayOfDictionaryTypePreservesNestedProvisioningType()
        {
            var input = new InputArrayType(
                "list",
                "list",
                new InputDictionaryType("dictionary", InputPrimitiveType.String, InputPrimitiveType.String));

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepList<BicepDictionary<string>>
            Assert.That(type, Is.EqualTo(new CSharpType(
                typeof(BicepList<>),
                new CSharpType(typeof(BicepDictionary<>), typeof(string)))));
        }

        [Test]
        public void NullableDictionaryTypeIsNotWrappedInBicepValue()
        {
            var input = new InputNullableType(new InputDictionaryType("dictionary", InputPrimitiveType.String, InputPrimitiveType.String));

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepDictionary<string>?
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepDictionary<>), true, typeof(string))));
        }

        [Test]
        public void KnownModelTypeUsesProvisioningFrameworkType()
        {
            var input = CreateKnownModel();

            var type = _factory.CreateCSharpType(input);

            // Expected: ManagedServiceIdentity
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(ManagedServiceIdentity))));
            Assert.That(type!.FrameworkType.Namespace, Is.EqualTo(typeof(ManagedServiceIdentity).Namespace));
        }

        [Test]
        public void RegularModelTypeIsNotWrappedInBicepValue()
        {
            var input = CreateRegularModel();

            var type = _factory.CreateCSharpType(input);

            // Expected: TestModel : ProvisionableConstruct
            Assert.That(type, Is.Not.Null);
            Assert.That(type!.IsFrameworkType, Is.False);
            Assert.That(type.Name, Is.EqualTo("TestModel"));
            Assert.That(type.Namespace, Is.EqualTo("Azure.Provisioning.Tests"));
            Assert.That(type.BaseType, Is.EqualTo(new CSharpType(typeof(ProvisionableConstruct))));
        }

        [Test]
        public void ArrayOfKnownModelTypeIsConvertedToBicepListOfModel()
        {
            var input = new InputArrayType("list", "list", CreateKnownModel());

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepList<ManagedServiceIdentity>
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepList<>), typeof(ManagedServiceIdentity))));
            Assert.That(type!.Arguments[0].FrameworkType.Namespace, Is.EqualTo(typeof(ManagedServiceIdentity).Namespace));
        }

        [Test]
        public void DictionaryOfKnownModelTypeIsConvertedToBicepDictionaryOfModel()
        {
            var input = new InputDictionaryType("dictionary", InputPrimitiveType.String, CreateKnownModel());

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepDictionary<ManagedServiceIdentity>
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepDictionary<>), typeof(ManagedServiceIdentity))));
            Assert.That(type!.Arguments[0].FrameworkType.Namespace, Is.EqualTo(typeof(ManagedServiceIdentity).Namespace));
        }

        [Test]
        public void ArrayOfRegularModelTypeIsConvertedToBicepListOfModel()
        {
            var input = new InputArrayType("list", "list", CreateRegularModel());

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepList<TestModel>
            Assert.That(type, Is.Not.Null);
            Assert.That(type!.FrameworkType.GetGenericTypeDefinition(), Is.EqualTo(typeof(BicepList<>)));
            Assert.That(type.Arguments[0].IsFrameworkType, Is.False);
            Assert.That(type.Arguments[0].Name, Is.EqualTo("TestModel"));
            Assert.That(type.Arguments[0].Namespace, Is.EqualTo("Azure.Provisioning.Tests"));
        }

        [Test]
        public void DictionaryOfRegularModelTypeIsConvertedToBicepDictionaryOfModel()
        {
            var input = new InputDictionaryType("dictionary", InputPrimitiveType.String, CreateRegularModel());

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepDictionary<TestModel>
            Assert.That(type, Is.Not.Null);
            Assert.That(type!.FrameworkType.GetGenericTypeDefinition(), Is.EqualTo(typeof(BicepDictionary<>)));
            Assert.That(type.Arguments[0].IsFrameworkType, Is.False);
            Assert.That(type.Arguments[0].Name, Is.EqualTo("TestModel"));
            Assert.That(type.Arguments[0].Namespace, Is.EqualTo("Azure.Provisioning.Tests"));
        }

        [Test]
        public void ArrayOfDictionaryOfRegularModelTypePreservesNestedProvisioningType()
        {
            var input = new InputArrayType(
                "list",
                "list",
                new InputDictionaryType("dictionary", InputPrimitiveType.String, CreateRegularModel()));

            var type = _factory.CreateCSharpType(input);

            // Expected: BicepList<BicepDictionary<TestModel>>
            Assert.That(type, Is.Not.Null);
            Assert.That(type!.FrameworkType.GetGenericTypeDefinition(), Is.EqualTo(typeof(BicepList<>)));
            var dictionaryType = type.Arguments[0];
            Assert.That(dictionaryType.FrameworkType.GetGenericTypeDefinition(), Is.EqualTo(typeof(BicepDictionary<>)));
            Assert.That(dictionaryType.Arguments[0].IsFrameworkType, Is.False);
            Assert.That(dictionaryType.Arguments[0].Name, Is.EqualTo("TestModel"));
            Assert.That(dictionaryType.Arguments[0].Namespace, Is.EqualTo("Azure.Provisioning.Tests"));
        }

        [Test]
        public void BytesTypeIsWrappedInBicepValueOfBinaryData()
        {
            var type = _factory.CreateCSharpType(InputPrimitiveType.Base64);

            // Expected: BicepValue<BinaryData>
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepValue<>), typeof(BinaryData))));
        }

        [Test]
        public void UnknownTypeIsWrappedInBicepValueOfBinaryData()
        {
            var type = _factory.CreateCSharpType(InputPrimitiveType.Any);

            // Expected: BicepValue<BinaryData>
            Assert.That(type, Is.EqualTo(new CSharpType(typeof(BicepValue<>), typeof(BinaryData))));
        }

        private static InputModelType CreateKnownModel()
            => new(
                "ManagedServiceIdentity",
                "Azure.ResourceManager.CommonTypes",
                "Azure.ResourceManager.CommonTypes.ManagedServiceIdentity",
                "public",
                null,
                string.Empty,
                "Managed service identity.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                [],
                null,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

        private static InputModelType CreateRegularModel()
            => new(
                "TestModel",
                "Sample.Models",
                "Sample.Models.TestModel",
                "public",
                null,
                string.Empty,
                "Test model.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                [],
                null,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

        private static IEnumerable<TestCaseData> PrimitiveTypeCases()
        {
            yield return new TestCaseData(InputPrimitiveType.String, new CSharpType(typeof(BicepValue<>), typeof(string)), "BicepValue<string>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_String");
            yield return new TestCaseData(InputPrimitiveType.Boolean, new CSharpType(typeof(BicepValue<>), typeof(bool)), "BicepValue<bool>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_Boolean");
            yield return new TestCaseData(InputPrimitiveType.Int32, new CSharpType(typeof(BicepValue<>), typeof(int)), "BicepValue<int>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_Int32");
            yield return new TestCaseData(InputPrimitiveType.Int64, new CSharpType(typeof(BicepValue<>), typeof(long)), "BicepValue<long>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_Int64");
            yield return new TestCaseData(InputPrimitiveType.Float32, new CSharpType(typeof(BicepValue<>), typeof(float)), "BicepValue<float>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_Float32");
            yield return new TestCaseData(InputPrimitiveType.Float64, new CSharpType(typeof(BicepValue<>), typeof(double)), "BicepValue<double>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_Float64");
            yield return new TestCaseData(InputPrimitiveType.PlainDate, new CSharpType(typeof(BicepValue<>), typeof(DateTimeOffset)), "BicepValue<DateTimeOffset>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_PlainDate");
            yield return new TestCaseData(InputPrimitiveType.PlainTime, new CSharpType(typeof(BicepValue<>), typeof(TimeSpan)), "BicepValue<TimeSpan>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_PlainTime");
            yield return new TestCaseData(InputPrimitiveType.Url, new CSharpType(typeof(BicepValue<>), typeof(Uri)), "BicepValue<Uri>")
                .SetName("PrimitiveTypeIsWrappedInBicepValue_Url");
        }

        private static InputEnumType CreateStringEnum()
        {
            var values = new List<InputEnumTypeValue>();
            var enumType = new InputEnumType(
                "TestEnum",
                "Sample.Models",
                "Sample.Models.TestEnum",
                "public",
                null,
                string.Empty,
                "Test enum.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                InputPrimitiveType.String,
                values,
                true);
            values.Add(new InputEnumTypeValue("One", "One", InputPrimitiveType.String, string.Empty, "One.", enumType));
            return enumType;
        }
    }
}
