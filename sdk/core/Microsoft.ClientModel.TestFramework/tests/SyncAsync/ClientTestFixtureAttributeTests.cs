// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;

[TestFixture]
public class ClientTestFixtureAttributeTests
{
    #region Constructor

    [Test]
    public void ConstructorWithNoParameters()
    {
        var attribute = new ClientTestFixtureAttribute();

        Assert.That(attribute, Is.Not.Null);
    }

    [Test]
    public void ConstructorWithParameters()
    {
        var parameters = new object[] { "param1", 42, true };
        var attribute = new ClientTestFixtureAttribute(parameters);

        Assert.That(attribute, Is.Not.Null);
    }

    [Test]
    public void ConstructorHandlesNullParameters()
    {
        var attribute = new ClientTestFixtureAttribute(null);

        Assert.That(attribute, Is.Not.Null);
    }

    #endregion

    #region Constants

    [Test]
    public void SyncOnlyKeyIsNotNullOrEmpty()
    {
        Assert.That(ClientTestFixtureAttribute.SyncOnlyKey, Is.Not.Null);
        Assert.That(ClientTestFixtureAttribute.SyncOnlyKey, Is.Not.Empty);
        Assert.That(ClientTestFixtureAttribute.SyncOnlyKey, Is.EqualTo("SyncOnly"));
    }

    [Test]
    public void RecordingDirectorySuffixKeyIsNotNullOrEmpty()
    {
        Assert.That(ClientTestFixtureAttribute.RecordingDirectorySuffixKey, Is.Not.Null);
        Assert.That(ClientTestFixtureAttribute.RecordingDirectorySuffixKey, Is.Not.Empty);
        Assert.That(ClientTestFixtureAttribute.RecordingDirectorySuffixKey, Is.EqualTo("RecordingDirectory"));
    }

    #endregion

    #region BuildFrom Method - Single Parameter

    [Test]
    public void BuildFromWithoutParametersCreatesBothSyncAndAsyncSuites()
    {
        var attribute = new ClientTestFixtureAttribute();
        var typeInfo = new MockTypeInfo(typeof(TestClass));

        var suites = attribute.BuildFrom(typeInfo).ToList();

        Assert.That(suites, Has.Count.EqualTo(2));
    }

    [Test]
    public void BuildFromWithSyncOnlyAttributeCreatesOnlySyncSuite()
    {
        var attribute = new ClientTestFixtureAttribute();
        var typeInfo = new MockTypeInfo(typeof(SyncOnlyTestClass));

        var suites = attribute.BuildFrom(typeInfo).ToList();

        Assert.That(suites, Has.Count.EqualTo(1));
    }

    [Test]
    public void BuildFromWithAsyncOnlyAttributeCreatesOnlyAsyncSuite()
    {
        var attribute = new ClientTestFixtureAttribute();
        var typeInfo = new MockTypeInfo(typeof(AsyncOnlyTestClass));

        var suites = attribute.BuildFrom(typeInfo).ToList();

        Assert.That(suites, Has.Count.EqualTo(1));
    }

    #endregion

    #region BuildFrom Method - Two Parameters

    [Test]
    public void BuildFromTwoParametersCreatesBothSyncAndAsyncSuites()
    {
        var attribute = new ClientTestFixtureAttribute();
        var typeInfo = new MockTypeInfo(typeof(TestClass));
        var filter = new MockPreFilter();

        var suites = attribute.BuildFrom(typeInfo, filter).ToList();

        Assert.That(suites, Has.Count.EqualTo(2));
    }

    [Test]
    public void BuildFromWithAdditionalParametersCreatesMultipleSuites()
    {
        var attribute = new ClientTestFixtureAttribute("param1", "param2");
        var typeInfo = new MockTypeInfo(typeof(TestClass));
        var filter = new MockPreFilter();

        var suites = attribute.BuildFrom(typeInfo, filter).ToList();

        // Should create 2 parameters × 2 modes (sync/async) = 4 suites
        Assert.That(suites, Has.Count.EqualTo(4));
    }

    #endregion

    #region IPreFilter Implementation

    [Test]
    public void IsMatchTypeAlwaysReturnsTrue()
    {
        var attribute = new ClientTestFixtureAttribute();
        IPreFilter filter = attribute;

        var result = filter.IsMatch(typeof(TestClass));

        Assert.That(result, Is.True);
    }

    [Test]
    public void IsMatchMethodAlwaysReturnsTrue()
    {
        var attribute = new ClientTestFixtureAttribute();
        IPreFilter filter = attribute;
        var method = typeof(TestClass).GetMethod("TestMethod");

        var result = filter.IsMatch(typeof(TestClass), method);

        Assert.That(result, Is.True);
    }

    [Test]
    public void IsMatchHandlesNullType()
    {
        var attribute = new ClientTestFixtureAttribute();
        IPreFilter filter = attribute;

        var result = filter.IsMatch(null);

        Assert.That(result, Is.True);
    }

    [Test]
    public void IsMatchHandlesNullMethod()
    {
        var attribute = new ClientTestFixtureAttribute();
        IPreFilter filter = attribute;

        var result = filter.IsMatch(typeof(TestClass), null);

        Assert.That(result, Is.True);
    }

    #endregion

    #region Edge Cases

    [Test]
    public void BuildFromHandlesNullTypeInfo()
    {
        var attribute = new ClientTestFixtureAttribute();

        Assert.Throws<ArgumentNullException>(() =>
            attribute.BuildFrom(null).ToList());
    }

    [Test]
    public void BuildFromTwoParametersHandlesNullTypeInfo()
    {
        var attribute = new ClientTestFixtureAttribute();
        var filter = new MockPreFilter();

        Assert.Throws<ArgumentNullException>(() =>
            attribute.BuildFrom(null, filter).ToList());
    }

    [Test]
    public void BuildFromHandlesEmptyAdditionalParameters()
    {
        var attribute = new ClientTestFixtureAttribute(Array.Empty<object>());
        var typeInfo = new MockTypeInfo(typeof(TestClass));

        var suites = attribute.BuildFrom(typeInfo).ToList();

        Assert.That(suites, Has.Count.EqualTo(2));
    }

    #endregion

    #region Helper Classes

    public class TestClass
    {
        public void TestMethod() { }
    }

    [SyncOnly]
    public class SyncOnlyTestClass
    {
        public void TestMethod() { }
    }

    [AsyncOnly]
    public class AsyncOnlyTestClass
    {
        public void TestMethod() { }
    }

    private class MockTypeInfo : ITypeInfo
    {
        private readonly Type _type;

        public MockTypeInfo(Type type)
        {
            _type = type;
        }

        public Type Type => _type;
        public Assembly Assembly => _type.Assembly;
        public string FullName => _type.FullName;
        public string Name => _type.Name;
        public string Namespace => _type.Namespace;
        public bool IsAbstract => _type.IsAbstract;
        public bool IsGenericType => _type.IsGenericType;
        public bool IsGenericTypeDefinition => _type.IsGenericTypeDefinition;
        public bool IsSealed => _type.IsSealed;
        public bool IsStaticClass => _type.IsAbstract && _type.IsSealed;

        public IMethodInfo[] GetMethods(BindingFlags bindingFlags) =>
            Array.Empty<IMethodInfo>();

        public bool HasMethodWithAttribute(Type attributeType) => false;
        public object[] GetCustomAttributes(Type attributeType, bool inherit) => Array.Empty<object>();
        public bool IsDefined(Type attributeType, bool inherit) => false;
        public ITypeInfo MakeGenericType(Type[] typeArgs) => this;
        public ITypeInfo BaseType => null;

        public bool ContainsGenericParameters => _type.ContainsGenericParameters;

        public ITypeInfo[] GetInterfaces() => Array.Empty<ITypeInfo>();
        public bool IsType(Type type) => _type == type;
        public bool IsAssignableFrom(ITypeInfo typeInfo) => false;

        public string GetDisplayName()
        {
            return _type.Name;
        }

        public string GetDisplayName(object[] args)
        {
            if (args == null || args.Length == 0)
                return _type.Name;

            var argsString = string.Join(", ", args.Select(a => a?.ToString() ?? "null"));
            return $"{_type.Name}({argsString})";
        }

        public Type GetGenericTypeDefinition()
        {
            throw new NotImplementedException();
        }

        public ConstructorInfo GetConstructor(Type[] argTypes)
        {
            throw new NotImplementedException();
        }

        public bool HasConstructor(Type[] argTypes)
        {
            throw new NotImplementedException();
        }

        public object Construct(object[] args)
        {
            throw new NotImplementedException();
        }

        public IMethodInfo[] GetMethodsWithAttribute<T>(bool inherit) where T : class
        {
            // Return empty array since we don't need actual method info for these tests
            return Array.Empty<IMethodInfo>();
        }

        public bool IsDefined<T>(bool inherit) where T : class
        {
            throw new NotImplementedException();
        }

        T[] IReflectionInfo.GetCustomAttributes<T>(bool inherit)
        {
            if (typeof(T) == typeof(SyncOnlyAttribute))
            {
                if (_type == typeof(SyncOnlyTestClass))
                {
                    return new T[] { (T)(object)new SyncOnlyAttribute() };
                }
            }
            else if (typeof(T) == typeof(AsyncOnlyAttribute))
            {
                if (_type == typeof(AsyncOnlyTestClass))
                {
                    return new T[] { (T)(object)new AsyncOnlyAttribute() };
                }
            }

            return Array.Empty<T>();
        }
    }

    private class MockPreFilter : IPreFilter
    {
        public bool IsMatch(Type type) => true;
        public bool IsMatch(Type type, MethodInfo method) => true;
    }

    #endregion
}
