// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Castle.DynamicProxy;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync.Interceptors;

[TestFixture]
public class GetOriginalInterceptorTests
{
    #region Constructor and Basic Properties

    [Test]
    public void ConstructorSetsOriginalValue()
    {
        var original = new object();
        var interceptor = new GetOriginalInterceptor(original);

        Assert.That(interceptor, Is.Not.Null);
    }

    [Test]
    public void ConstructorAcceptsNullOriginal()
    {
        var interceptor = new GetOriginalInterceptor(null);

        Assert.That(interceptor, Is.Not.Null);
    }

    #endregion

    #region Intercept Method

    [Test]
    public void InterceptReturnsOriginalForIProxiedClientInterface()
    {
        var original = new TestObject();
        var interceptor = new GetOriginalInterceptor(original);
        var invocation = new MockInvocation(typeof(IProxiedClient).GetProperty("Original").GetGetMethod());

        interceptor.Intercept(invocation);

        Assert.That(invocation.ReturnValue, Is.EqualTo(original));
    }

    [Test]
    public void InterceptReturnsNullWhenOriginalIsNull()
    {
        var interceptor = new GetOriginalInterceptor(null);
        var invocation = new MockInvocation(typeof(IProxiedClient).GetProperty("Original").GetGetMethod());

        interceptor.Intercept(invocation);

        Assert.That(invocation.ReturnValue, Is.Null);
    }

    [Test]
    public void InterceptProceedsForNonInterfaceMethods()
    {
        var original = new TestObject();
        var interceptor = new GetOriginalInterceptor(original);
        var invocation = new MockInvocation(typeof(TestObject).GetMethod("TestMethod"));
        invocation.ShouldProceed = true;

        interceptor.Intercept(invocation);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(invocation.Proceeded, Is.True);
            Assert.That(invocation.ReturnValue, Is.Null);
        }
    }

    [Test]
    public void InterceptHandlesMethodsFromOtherInterfaces()
    {
        var original = new TestObject();
        var interceptor = new GetOriginalInterceptor(original);
        var invocation = new MockInvocation(typeof(IDisposable).GetMethod("Dispose"));
        invocation.ShouldProceed = true;

        interceptor.Intercept(invocation);

        Assert.That(invocation.Proceeded, Is.True);
    }

    #endregion

    #region Helper Classes

    private class TestObject : IDisposable
    {
        public void TestMethod() { }
        public void Dispose() { }
    }

    private class MockInvocation : IInvocation
    {
        private readonly System.Reflection.MethodInfo _method;

        public MockInvocation(System.Reflection.MethodInfo method)
        {
            _method = method ?? throw new ArgumentNullException(nameof(method));
            Arguments = Array.Empty<object>();
        }

        public object[] Arguments { get; set; }
        public Type[] GenericArguments => Array.Empty<Type>();
        public object InvocationTarget => throw new NotImplementedException();
        public System.Reflection.MethodInfo Method => _method;
        public System.Reflection.MethodInfo MethodInvocationTarget => throw new NotImplementedException();
        public object Proxy => throw new NotImplementedException();
        public object ReturnValue { get; set; }
        public Type TargetType => throw new NotImplementedException();

        public bool Proceeded { get; private set; }
        public bool ShouldProceed { get; set; }

        public IInvocation GetConcreteMethod() => throw new NotImplementedException();
        public IInvocationProceedInfo GetConcreteMethodInvocationTarget() => throw new NotImplementedException();

        public void Proceed()
        {
            if (ShouldProceed)
            {
                Proceeded = true;
            }
        }

        public void SetArgumentValue(int index, object value) => throw new NotImplementedException();

        public IInvocationProceedInfo CaptureProceedInfo()
        {
            throw new NotImplementedException();
        }

        public object GetArgumentValue(int index)
        {
            throw new NotImplementedException();
        }

        MethodInfo IInvocation.GetConcreteMethod()
        {
            throw new NotImplementedException();
        }

        MethodInfo IInvocation.GetConcreteMethodInvocationTarget()
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}
