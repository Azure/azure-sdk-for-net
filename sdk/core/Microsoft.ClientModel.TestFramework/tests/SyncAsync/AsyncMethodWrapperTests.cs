// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Castle.DynamicProxy;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.ClientModel;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;

[TestFixture]
public class AsyncMethodWrapperTests
{
    #region WrapAsyncResult Method

    [Test]
    public void WrapAsyncResultHandlesNonGenericReturnType()
    {
        var target = new TestTarget();
        var interceptorMethod = typeof(TestTarget).GetMethod(nameof(TestTarget.TestInterceptor));
        var invocation = CreateMockInvocation(typeof(Task), "TestMethod");

        Assert.DoesNotThrow(() =>
            AsyncMethodWrapper.WrapAsyncResult(invocation, target, interceptorMethod));
    }

    [Test]
    public void WrapAsyncResultHandlesGenericReturnType()
    {
        var target = new TestTarget();
        var interceptorMethod = typeof(TestTarget).GetMethod(nameof(TestTarget.TestInterceptor));
        var invocation = CreateMockInvocation(typeof(Task<string>), "TestMethod");

        Assert.DoesNotThrow(() =>
            AsyncMethodWrapper.WrapAsyncResult(invocation, target, interceptorMethod));
    }

    #endregion

    #region WrapAsyncResultCore Method - Task<T>

    [Test]
    public void WrapAsyncResultCoreHandlesTaskOfT()
    {
        var interceptor = new TestInterceptor();
        var invocation = CreateMockInvocation(typeof(Task<string>), "TestMethod");
        invocation.SetReturnValue(Task.FromResult("test"));

        AsyncMethodWrapper.WrapAsyncResultCore<string>(invocation, typeof(Task<>), interceptor.Intercept);

        Assert.That(invocation.ReturnValue, Is.InstanceOf<Task<string>>());
    }

    [Test]
    public void WrapAsyncResultCoreHandlesTaskOfTWithClientResult()
    {
        var interceptor = new TestInterceptor();
        var invocation = CreateMockInvocation(typeof(Task<ClientResult<string>>), "TestMethod");
        var mockResponse = new MockPipelineResponse(200);
        var clientResult = ClientResult.FromOptionalValue("test", mockResponse);
        invocation.SetReturnValue(Task.FromResult(clientResult));

        AsyncMethodWrapper.WrapAsyncResultCore<ClientResult<string>>(invocation, typeof(Task<>), interceptor.Intercept);

        Assert.That(invocation.ReturnValue, Is.InstanceOf<Task<ClientResult<string>>>());
    }

    #endregion

    #region WrapAsyncResultCore Method - Task

    [Test]
    public void WrapAsyncResultCoreHandlesTask()
    {
        var interceptor = new TestInterceptor();
        var invocation = CreateMockInvocation(typeof(Task), "TestMethod");
        invocation.SetReturnValue(Task.CompletedTask);

        AsyncMethodWrapper.WrapAsyncResultCore<object>(invocation, typeof(Task), interceptor.Intercept);

        Assert.That(invocation.ReturnValue, Is.InstanceOf<Task>());
    }

    #endregion

    #region WrapAsyncResultCore Method - ValueTask<T>

    [Test]
    public void WrapAsyncResultCoreHandlesValueTaskOfT()
    {
        var interceptor = new TestInterceptor();
        var invocation = CreateMockInvocation(typeof(ValueTask<string>), "TestMethod");
        invocation.SetReturnValue(new ValueTask<string>("test"));

        AsyncMethodWrapper.WrapAsyncResultCore<string>(invocation, typeof(ValueTask<>), interceptor.Intercept);

        Assert.That(invocation.ReturnValue, Is.InstanceOf<ValueTask<string>>());
    }

    #endregion

    #region WrapAsyncResultCore Method - ValueTask

    [Test]
    public void WrapAsyncResultCoreHandlesValueTask()
    {
        var interceptor = new TestInterceptor();
        var invocation = CreateMockInvocation(typeof(ValueTask), "TestMethod");

        invocation.SetReturnValue(new ValueTask());

        AsyncMethodWrapper.WrapAsyncResultCore<object>(invocation, typeof(ValueTask), interceptor.Intercept);

        Assert.That(invocation.ReturnValue, Is.InstanceOf<ValueTask>());
    }

    #endregion

    #region WrapAsyncResultCore Method - Other Types

    [Test]
    public void WrapAsyncResultCoreHandlesOtherTypes()
    {
        var interceptor = new TestInterceptor();
        var invocation = CreateMockInvocation(typeof(string), "TestMethod");
        invocation.SetReturnValue("test");

        AsyncMethodWrapper.WrapAsyncResultCore<string>(invocation, typeof(string), interceptor.Intercept);

        Assert.That(invocation.ReturnValue, Is.EqualTo("test"));
    }

    #endregion

    #region Helper Classes and Methods

    private MockInvocation CreateMockInvocation(Type returnType, string methodName)
    {
        return new MockInvocation(returnType, methodName);
    }

    private class TestTarget
    {
        public ValueTask<T> TestInterceptor<T>(IInvocation invocation, Func<ValueTask<T>> innerTask)
        {
            return innerTask();
        }
    }

    private class TestInterceptor
    {
        public ValueTask<T> Intercept<T>(IInvocation invocation, Func<ValueTask<T>> innerTask)
        {
            return innerTask();
        }
    }

    private class MockInvocation : IInvocation
    {
        private readonly Type _returnType;
        private readonly string _methodName;

        public MockInvocation(Type returnType, string methodName)
        {
            _returnType = returnType;
            _methodName = methodName;
            Arguments = Array.Empty<object>();
        }

        public object[] Arguments { get; set; }
        public Type[] GenericArguments => _returnType.IsGenericType ? _returnType.GetGenericArguments() : Array.Empty<Type>();
        public object InvocationTarget => throw new NotImplementedException();
        public MethodInfo Method => new MockMethodInfo(_methodName, _returnType);
        public MethodInfo MethodInvocationTarget => throw new NotImplementedException();
        public object Proxy => throw new NotImplementedException();
        public object ReturnValue { get; private set; }
        public Type TargetType => throw new NotImplementedException();
        public bool Proceeded { get; private set; }
        object IInvocation.ReturnValue { get => ReturnValue; set => ReturnValue = value; }

        public void SetReturnValue(object value) => ReturnValue = value;

        public IInvocation GetConcreteMethod() => throw new NotImplementedException();
        public IInvocationProceedInfo GetConcreteMethodInvocationTarget() => throw new NotImplementedException();

        public void Proceed()
        {
            Proceeded = true;
        }

        public void SetArgumentValue(int index, object value) => throw new NotImplementedException();

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

        public IInvocationProceedInfo CaptureProceedInfo()
        {
            throw new NotImplementedException();
        }
    }

    private class MockMethodInfo : MethodInfo
    {
        private readonly string _name;
        private readonly Type _returnType;

        public MockMethodInfo(string name, Type returnType)
        {
            _name = name;
            _returnType = returnType;
        }

        public override string Name => _name;
        public override Type ReturnType => _returnType;
        public override Type DeclaringType => typeof(object);
        public override Type ReflectedType => typeof(object);
        public override MethodAttributes Attributes => throw new NotImplementedException();
        public override RuntimeMethodHandle MethodHandle => throw new NotImplementedException();

        public override MethodInfo GetBaseDefinition() => throw new NotImplementedException();
        public override object[] GetCustomAttributes(bool inherit) => Array.Empty<object>();
        public override object[] GetCustomAttributes(Type attributeType, bool inherit) => Array.Empty<object>();
        public override MethodImplAttributes GetMethodImplementationFlags() => throw new NotImplementedException();
        public override ParameterInfo[] GetParameters() => Array.Empty<ParameterInfo>();
        public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
        public override bool IsDefined(Type attributeType, bool inherit) => false;
        public override ParameterInfo ReturnParameter => throw new NotImplementedException();

        public override ICustomAttributeProvider ReturnTypeCustomAttributes => throw new NotImplementedException();
    }

    #endregion
}
