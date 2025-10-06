// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.Extensions.AspNetCore.DataProtection.Keys.Tests
{
    public class TypeForwardingActivatorTests : MarshalByRefObject
    {
        [Test]
        public void CreateInstance_ForwardsToNewNamespaceIfExists()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDataProtection().ProtectKeysWithAzureKeyVault(new Uri("http://localhost"), new MockCredential());

            var services = serviceCollection.BuildServiceProvider();
            var activator = services.GetRequiredService<IActivator>();

            // Act
            const string name = "Microsoft.AspNetCore.DataProtection.AzureKeyVault.AzureKeyVaultXmlDecryptor, Microsoft.AspNetCore.DataProtection.AzureKeyVault, Version=1.0.0.0";
            var instance = activator.CreateInstance(typeof(object), name);

            // Assert
            Assert.IsInstanceOf<AzureKeyVaultXmlDecryptor>(instance);
        }

        [Test]
        public void CreateInstance_DoesNotForwardIfClassDoesNotExist()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDataProtection();

            var services = serviceCollection.BuildServiceProvider();
            var activator = services.GetRequiredService<IActivator>();

            // Act & Assert
            const string name = "Microsoft.AspNet.DataProtection.TypeForwardingActivatorTests+NonExistentClassWithParameterlessCtor, Microsoft.AspNet.DataProtection.Tests";
            var ex = Assert.Throws<FileNotFoundException>(() => activator.CreateInstance(typeof(object), name));
            Assert.IsNotNull(ex);
            StringAssert.Contains("Microsoft.AspNet.DataProtection.Test", ex.Message);
        }

        [TestCase(typeof(GenericType<GenericType<ClassWithParameterlessCtor>>))]
        [TestCase(typeof(GenericType<ClassWithParameterlessCtor>))]
        [TestCase(typeof(GenericType<GenericType<string>>))]
        [TestCase(typeof(GenericType<GenericType<string, string>>))]
        [TestCase(typeof(GenericType<string>))]
        [TestCase(typeof(GenericType<int>))]
        [TestCase(typeof(List<ClassWithParameterlessCtor>))]
        public void CreateInstance_Generics(Type type)
        {
            // Arrange
            var activator = new DecryptorTypeForwardingActivator(null);
            var name = type.AssemblyQualifiedName;

            // Act & Assert
            Assert.IsNotNull(name);
            Assert.IsInstanceOf(type, activator.CreateInstance(typeof(object), name));
        }

        [TestCase(typeof(GenericType<>))]
        [TestCase(typeof(GenericType<,>))]
        public void CreateInstance_ThrowsForOpenGenerics(Type type)
        {
            // Arrange
            var activator = new DecryptorTypeForwardingActivator(null);
            var name = type.AssemblyQualifiedName;

            // Act & Assert
            Assert.IsNotNull(name);
            Assert.Throws<ArgumentException>(() => activator.CreateInstance(typeof(object), name));
        }

        [TestCase(
            "System.Tuple`1[[Some.Type, Microsoft.AspNetCore.DataProtection, Version=1.0.0.0, Culture=neutral]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Tuple`1[[Some.Type, Microsoft.AspNetCore.DataProtection, Culture=neutral]], mscorlib, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
        [TestCase(
            "Some.Type`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], Microsoft.AspNetCore.DataProtection, Version=1.0.0.0, Culture=neutral",
            "Some.Type`1[[System.Int32, mscorlib, Culture=neutral, PublicKeyToken=b77a5c561934e089]], Microsoft.AspNetCore.DataProtection, Culture=neutral")]
        [TestCase(
            "System.Tuple`1[[System.Tuple`1[[Some.Type, Microsoft.AspNetCore.DataProtection, Version=1.0.0.0, Culture=neutral]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Tuple`1[[System.Tuple`1[[Some.Type, Microsoft.AspNetCore.DataProtection, Culture=neutral]], mscorlib, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
        public void ParsesFullyQualifiedTypeName(string typeName, string expected)
        {
            Assert.AreEqual(expected, new MockTypeForwardingActivator().Parse(typeName));
        }

        [TestCase(typeof(List<string>))]
        [TestCase(typeof(TestAttribute))]
        public void CreateInstance_DoesNotForwardingTypesExternalTypes(Type type)
        {
            new DecryptorTypeForwardingActivator(null).CreateInstance(typeof(object), type.AssemblyQualifiedName, out var forwarded);
            Assert.False(forwarded, "Should not have forwarded types that are not in Microsoft.AspNetCore.DataProjection");
        }

        [TestCaseSource(nameof(AssemblyVersions))]
        public void CreateInstance_ForwardsAcrossVersionChanges(Version version)
        {
            CreateInstance_ForwardsAcrossVersionChangesImpl(version);
        }

        private static void CreateInstance_ForwardsAcrossVersionChangesImpl(Version newVersion)
        {
            var activator = new DecryptorTypeForwardingActivator(null);

            var typeInfo = typeof(ClassWithParameterlessCtor).GetTypeInfo();
            var typeName = typeInfo.FullName;
            var assemblyName = typeInfo.Assembly.GetName();

            assemblyName.Version = newVersion;
            var newName = $"{typeName}, {assemblyName}";

            Assert.AreNotEqual(typeInfo.AssemblyQualifiedName, newName);
            Assert.IsInstanceOf<ClassWithParameterlessCtor>(activator.CreateInstance(typeof(object), newName, out var forwarded));
            Assert.True(forwarded);
        }

        public static IEnumerable<Version[]> AssemblyVersions
        {
            get
            {
                var current = typeof(ClassWithParameterlessCtor).Assembly.GetName().Version!;
                yield return [new Version(Math.Max(0, current.Major - 1), 0, 0, 0)];
                yield return [new Version(current.Major + 1, 0, 0, 0)];
                yield return [new Version(current.Major, current.Minor + 1, 0, 0)];
                yield return [new Version(current.Major, current.Minor, current.Build + 1, 0)];
            }
        }

        private class MockTypeForwardingActivator : DecryptorTypeForwardingActivator
        {
            public MockTypeForwardingActivator() : base(null) { }
            public string Parse(string typeName) => RemoveVersionFromAssemblyName(typeName);
        }

        private class ClassWithParameterlessCtor
        {
        }

        private class GenericType<T>
        {
        }

        private class GenericType<T1, T2>
        {
        }
    }
}
