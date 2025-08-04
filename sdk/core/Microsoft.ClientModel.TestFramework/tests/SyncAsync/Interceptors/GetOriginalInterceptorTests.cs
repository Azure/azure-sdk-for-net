// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Castle.DynamicProxy;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync.Interceptors;

[TestFixture]
public class GetOriginalInterceptorTests
{
    private object _originalObject;
    private object _interceptor;

    [SetUp]
    public void Setup()
    {
        _originalObject = new MockOriginalClient();
        _interceptor = CreateGetOriginalInterceptor(_originalObject);
    }

    [Test]
    public void Constructor_WithValidOriginal_CreatesInstance()
    {
        var original = new object();
        var interceptor = CreateGetOriginalInterceptor(original);
        
        Assert.IsNotNull(interceptor);
    }

    [Test]
    public void Constructor_WithNullOriginal_AllowsNull()
    {
        var interceptor = CreateGetOriginalInterceptor(null);
        
        Assert.IsNotNull(interceptor);
    }

    [Test]
    public void Intercept_WithIProxiedClientOriginalCall_ReturnsOriginalObject()
    {
        var mockInvocation = CreateMockInvocation(typeof(IProxiedClient), "get_Original");
        
        CallIntercept(_interceptor, mockInvocation);
        
        Assert.AreSame(_originalObject, mockInvocation.ReturnValue);
        Assert.IsFalse(mockInvocation.Proceeded);
    }

    [Test]
    public void Intercept_WithIProxiedOperationResultOriginalCall_ReturnsOriginalObject()
    {
        var mockInvocation = CreateMockInvocation(typeof(IProxiedOperationResult), "get_Original");
        
        CallIntercept(_interceptor, mockInvocation);
        
        Assert.AreSame(_originalObject, mockInvocation.ReturnValue);
        Assert.IsFalse(mockInvocation.Proceeded);
    }

    [Test]
    public void Intercept_WithNonOriginalMethodCall_ProceedsNormally()
    {
        var mockInvocation = CreateMockInvocation(typeof(MockOriginalClient), "GetValue");
        
        CallIntercept(_interceptor, mockInvocation);
        
        Assert.IsTrue(mockInvocation.Proceeded);
        Assert.IsNull(mockInvocation.ReturnValue);
    }

    [Test]
    public void Intercept_WithDifferentInterface_ProceedsNormally()
    {
        var mockInvocation = CreateMockInvocation(typeof(IDisposable), "Dispose");
        
        CallIntercept(_interceptor, mockInvocation);
        
        Assert.IsTrue(mockInvocation.Proceeded);
    }

    [Test]
    public void Intercept_WithNullOriginal_ReturnsNull()
    {
        var interceptor = CreateGetOriginalInterceptor(null);
        var mockInvocation = CreateMockInvocation(typeof(IProxiedClient), "get_Original");
        
        CallIntercept(interceptor, mockInvocation);
        
        Assert.IsNull(mockInvocation.ReturnValue);
        Assert.IsFalse(mockInvocation.Proceeded);
    }

    [Test]
    public void Interceptor_ImplementsIInterceptor()
    {
        Assert.IsInstanceOf<IInterceptor>(_interceptor);
    }

    [Test]
    public void GetOriginalInterceptor_IsInternal()
    {
        var type = GetGetOriginalInterceptorType();
        
        Assert.IsTrue(type.IsNotPublic); // Internal classes are not public
    }

    [Test]
    public void Intercept_WithPropertyGetter_HandlesCorrectly()
    {
        var originalProperty = typeof(IProxiedClient).GetProperty("Original");
        var getterMethod = originalProperty.GetGetMethod();
        var mockInvocation = new MockInvocation(getterMethod);
        
        CallIntercept(_interceptor, mockInvocation);
        
        Assert.AreSame(_originalObject, mockInvocation.ReturnValue);
    }

    [Test]
    public void Intercept_WithMultipleCalls_ConsistentlyReturnsOriginal()
    {
        var mockInvocation1 = CreateMockInvocation(typeof(IProxiedClient), "get_Original");
        var mockInvocation2 = CreateMockInvocation(typeof(IProxiedClient), "get_Original");
        
        CallIntercept(_interceptor, mockInvocation1);
        CallIntercept(_interceptor, mockInvocation2);
        
        Assert.AreSame(_originalObject, mockInvocation1.ReturnValue);
        Assert.AreSame(_originalObject, mockInvocation2.ReturnValue);
        Assert.AreSame(mockInvocation1.ReturnValue, mockInvocation2.ReturnValue);
    }

    [Test]
    public void Intercept_WithBothProxiedInterfaces_HandlesBothCorrectly()
    {
        var clientInvocation = CreateMockInvocation(typeof(IProxiedClient), "get_Original");
        var operationInvocation = CreateMockInvocation(typeof(IProxiedOperationResult), "get_Original");
        
        CallIntercept(_interceptor, clientInvocation);
        CallIntercept(_interceptor, operationInvocation);
        
        Assert.AreSame(_originalObject, clientInvocation.ReturnValue);
        Assert.AreSame(_originalObject, operationInvocation.ReturnValue);
    }

    // Helper methods
    private object CreateGetOriginalInterceptor(object original)
    {
        var type = GetGetOriginalInterceptorType();
        return Activator.CreateInstance(type, original);
    }

    private Type GetGetOriginalInterceptorType()
    {
        var assembly = typeof(ClientTestBase).Assembly;
        return assembly.GetType("Microsoft.ClientModel.TestFramework.GetOriginalInterceptor");
    }

    private void CallIntercept(object interceptor, IInvocation invocation)
    {
        var interceptMethod = interceptor.GetType().GetMethod("Intercept");
        interceptMethod.Invoke(interceptor, new object[] { invocation });
    }

    private MockInvocation CreateMockInvocation(Type declaringType, string methodName)
    {
        var method = declaringType.GetMethod(methodName) ?? 
                    declaringType.GetProperty("Original")?.GetGetMethod();
        return new MockInvocation(method ?? throw new ArgumentException($"Method {methodName} not found"));
    }

    // Helper classes for testing
    public class MockInvocation : IInvocation
    {
        public bool Proceeded { get; private set; }
        public object ReturnValue { get; set; }
        public MethodInfo Method { get; }
        public object[] Arguments { get; set; } = Array.Empty<object>();
        public Type[] GenericArguments { get; set; } = Array.Empty<Type>();
        public object InvocationTarget { get; set; }
        public Type TargetType { get; set; }
        public object Proxy { get; set; }

        public MockInvocation(MethodInfo method)
        {
            Method = method;
        }

        public void Proceed() => Proceeded = true;
        public void SetArgumentValue(int index, object value) => Arguments[index] = value;
        public object GetArgumentValue(int index) => Arguments[index];
        public MethodInfo GetConcreteMethod() => Method;
        public MethodInfo GetConcreteMethodInvocationTarget() => Method;
    }

    public class MockOriginalClient
    {
        public string GetValue() => "original";
    }
}
