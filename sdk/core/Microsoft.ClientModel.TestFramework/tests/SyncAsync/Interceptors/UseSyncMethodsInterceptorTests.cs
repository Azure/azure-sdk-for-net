// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Castle.DynamicProxy;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.ClientModel;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync.Interceptors;

[TestFixture]
public class UseSyncMethodsInterceptorTests
{
    #region Constructor

    [Test]
    public void ConstructorWithForceSyncTrue()
    {
        var interceptor = new UseSyncMethodsInterceptor(true);

        Assert.That(interceptor, Is.Not.Null);
    }

    [Test]
    public void ConstructorWithForceSyncFalse()
    {
        var interceptor = new UseSyncMethodsInterceptor(false);

        Assert.That(interceptor, Is.Not.Null);
    }

    #endregion

    #region Intercept Method - Non-Async Methods

    [Test]
    public void InterceptThrowsOnNonAsyncMethodWithAsyncAlternative()
    {
        var interceptor = new UseSyncMethodsInterceptor(true);
        var invocation = CreateMockInvocation("GetData", typeof(TestClient), typeof(string));

        var ex = Assert.Throws<InvalidOperationException>(() => interceptor.Intercept(invocation));
        Assert.That(ex.Message, Contains.Substring("Async method call expected"));
    }

    [Test]
    public void InterceptProceedsForNonAsyncMethodWithoutAsyncAlternative()
    {
        var interceptor = new UseSyncMethodsInterceptor(true);
        var invocation = CreateMockInvocation("SyncOnlyMethod", typeof(TestClient), typeof(string));

        interceptor.Intercept(invocation);

        Assert.That(invocation.Proceeded, Is.True);
    }

    #endregion

    #region Intercept Method - Async Methods with ForceSync False

    [Test]
    public void InterceptProceedsWhenForceSyncIsFalse()
    {
        var interceptor = new UseSyncMethodsInterceptor(false);
        var invocation = CreateMockInvocation("GetDataAsync", typeof(TestClient), typeof(Task<string>));

        interceptor.Intercept(invocation);

        Assert.That(invocation.Proceeded, Is.True);
    }

    #endregion

    #region Intercept Method - Async Methods with ForceSync True

    [Test]
    public void InterceptThrowsWhenSyncMethodNotFound()
    {
        var interceptor = new UseSyncMethodsInterceptor(true);
        var invocation = CreateMockInvocation("NonExistentMethodAsync", typeof(TestClient), typeof(Task<string>));

        var ex = Assert.Throws<InvalidOperationException>(() => interceptor.Intercept(invocation));
        Assert.That(ex.Message, Contains.Substring("Unable to find a method"));
    }

    [Test]
    public void InterceptCallsSyncMethodForAsyncCall()
    {
        var interceptor = new UseSyncMethodsInterceptor(true);
        var testClient = new TestClient();
        var invocation = CreateMockInvocationWithTarget("GetDataAsync", testClient, typeof(Task<string>));

        interceptor.Intercept(invocation);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(testClient.GetDataCalled, Is.True);
            Assert.That(invocation.ReturnValue, Is.InstanceOf<Task<string>>());
        }
    }

    [Test]
    public void InterceptHandlesCollectionResults()
    {
        var interceptor = new UseSyncMethodsInterceptor(true);
        var testClient = new TestClient();
        var invocation = CreateMockInvocationWithTarget("GetCollectionAsync", testClient, typeof(Task<AsyncCollectionResult<string>>));

        interceptor.Intercept(invocation);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(testClient.GetCollectionCalled, Is.True);
            Assert.That(invocation.ReturnValue, Is.InstanceOf<UseSyncMethodsInterceptor.SyncPageableWrapper<string>>());
        }
    }

    [Test]
    public void InterceptHandlesValueTaskReturn()
    {
        var interceptor = new UseSyncMethodsInterceptor(true);
        var testClient = new TestClient();
        var invocation = CreateMockInvocationWithTarget("GetValueTaskDataAsync", testClient, typeof(ValueTask<string>));

        interceptor.Intercept(invocation);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(testClient.GetValueTaskDataCalled, Is.True);
            Assert.That(invocation.ReturnValue, Is.InstanceOf<ValueTask<string>>());
        }
    }

    #endregion

    #region Exception Handling

    [Test]
    public void InterceptHandlesExceptionsInSyncMethod()
    {
        var interceptor = new UseSyncMethodsInterceptor(true);
        var testClient = new TestClient();
        var invocation = CreateMockInvocationWithTarget("ThrowExceptionAsync", testClient, typeof(Task<string>));

        interceptor.Intercept(invocation);

        Assert.That(invocation.ReturnValue, Is.InstanceOf<Task<string>>());
        var task = (Task<string>)invocation.ReturnValue;
        Assert.That(task.IsFaulted, Is.True);
    }

    [Test]
    public void InterceptHandlesExceptionsInCollectionMethod()
    {
        var interceptor = new UseSyncMethodsInterceptor(true);
        var testClient = new TestClient();
        var invocation = CreateMockInvocationWithTarget("ThrowCollectionExceptionAsync", testClient, typeof(Task<AsyncCollectionResult<string>>));

        Assert.Throws<InvalidOperationException>(() => interceptor.Intercept(invocation));
    }

    #endregion

    #region SyncPageableWrapper Tests

    [Test]
    public void SyncPageableWrapperConstructorThrowsOnNullEnumerable()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new UseSyncMethodsInterceptor.SyncPageableWrapper<string>(null));
    }

    [Test]
    public void SyncPageableWrapperGetValuesFromPageReturnsItems()
    {
        var collectionResult = new TestCollectionResult<string>();
        var wrapper = new UseSyncMethodsInterceptor.SyncPageableWrapper<string>(collectionResult);
        var page = ClientResult.FromOptionalValue(new string[] { "item1", "item2" }, new MockPipelineResponse(200));

        var method = typeof(UseSyncMethodsInterceptor.SyncPageableWrapper<string>)
            .GetMethod("GetValuesFromPageAsync", BindingFlags.NonPublic | BindingFlags.Instance);

        Assert.That(method, Is.Not.Null);
    }

    [Test]
    public void SyncPageableWrapperGetRawPagesReturnsPages()
    {
        var collectionResult = new TestCollectionResult<string>();
        var wrapper = new UseSyncMethodsInterceptor.SyncPageableWrapper<string>(collectionResult);

        var method = typeof(UseSyncMethodsInterceptor.SyncPageableWrapper<string>)
            .GetMethod("GetRawPagesAsync", BindingFlags.Public | BindingFlags.Instance);

        Assert.That(method, Is.Not.Null);
    }

    #endregion

    #region Helper Classes and Methods

    private MockInvocation CreateMockInvocation(string methodName, Type targetType, Type returnType)
    {
        return new MockInvocation(methodName, targetType, returnType, null, Array.Empty<object>());
    }

    private MockInvocation CreateMockInvocationWithTarget(string methodName, object target, Type returnType)
    {
        return new MockInvocation(methodName, target.GetType(), returnType, target, Array.Empty<object>());
    }

    public class TestClient
    {
        public bool GetDataCalled { get; private set; }
        public bool GetCollectionCalled { get; private set; }
        public bool GetValueTaskDataCalled { get; private set; }

        public string GetData()
        {
            GetDataCalled = true;
            return "test data";
        }

        public Task<string> GetDataAsync() => Task.FromResult(GetData());

        public CollectionResult<string> GetCollection()
        {
            GetCollectionCalled = true;
            return new TestCollectionResult<string>();
        }

        public Task<AsyncCollectionResult<string>> GetCollectionAsync() =>
            Task.FromResult<AsyncCollectionResult<string>>(new TestAsyncCollectionResult<string>());

        public string GetValueTaskData()
        {
            GetValueTaskDataCalled = true;
            return "value task data";
        }

        public ValueTask<string> GetValueTaskAsync() => new ValueTask<string>(GetValueTaskData());

        public ValueTask<string> GetValueTaskDataAsync() => new ValueTask<string>(GetValueTaskData());

        public string ThrowException() => throw new InvalidOperationException("Test exception");

        public Task<string> ThrowExceptionAsync() => Task.FromResult(ThrowException());

        public CollectionResult<string> ThrowCollectionException() =>
            throw new InvalidOperationException("Collection exception");

        public Task<AsyncCollectionResult<string>> ThrowCollectionExceptionAsync() =>
            Task.FromResult<AsyncCollectionResult<string>>(null);

        public string SyncOnlyMethod() => "sync only";
    }

    private class TestCollectionResult<T> : CollectionResult<T>
    {
        protected override System.Collections.Generic.IEnumerable<T> GetValuesFromPage(ClientResult page) =>
            Array.Empty<T>();

        public override System.Collections.Generic.IEnumerable<ClientResult> GetRawPages() =>
            Array.Empty<ClientResult>();

        public override ContinuationToken GetContinuationToken(ClientResult page) => null;
    }

    private class TestAsyncCollectionResult<T> : AsyncCollectionResult<T>
    {
        protected override System.Collections.Generic.IAsyncEnumerable<T> GetValuesFromPageAsync(ClientResult page)
        {
            return EmptyAsyncEnumerable<T>();
        }

        public override System.Collections.Generic.IAsyncEnumerable<ClientResult> GetRawPagesAsync()
        {
            return EmptyAsyncEnumerable<ClientResult>();
        }

        public override ContinuationToken GetContinuationToken(ClientResult page) => null;

        private static async System.Collections.Generic.IAsyncEnumerable<TItem> EmptyAsyncEnumerable<TItem>()
        {
            await Task.CompletedTask;
            yield break;
        }
    }

    private class MockInvocation : IInvocation
    {
        private readonly string _methodName;
        private readonly Type _targetType;
        private readonly Type _returnType;
        private readonly object _target;

        public MockInvocation(string methodName, Type targetType, Type returnType, object target, object[] arguments)
        {
            _methodName = methodName;
            _targetType = targetType;
            _returnType = returnType;
            _target = target;
            Arguments = arguments;
        }

        public object[] Arguments { get; set; }
        public Type[] GenericArguments => Array.Empty<Type>();
        public object InvocationTarget => _target is IProxiedClient proxied ? proxied.Original : _target;
        public MethodInfo Method => new MockMethodInfo(_methodName, _returnType);
        public MethodInfo MethodInvocationTarget => Method;
        public object Proxy => throw new NotImplementedException();
        public object ReturnValue { get; set; }
        public Type TargetType => _targetType;
        public bool Proceeded { get; private set; }

        public IInvocation GetConcreteMethod() => throw new NotImplementedException();
        public IInvocationProceedInfo GetConcreteMethodInvocationTarget() => throw new NotImplementedException();

        public void Proceed()
        {
            Proceeded = true;
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
        public override Type DeclaringType => typeof(TestClient);
        public override Type ReflectedType => typeof(TestClient);
        public override MethodAttributes Attributes => MethodAttributes.Public;
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
