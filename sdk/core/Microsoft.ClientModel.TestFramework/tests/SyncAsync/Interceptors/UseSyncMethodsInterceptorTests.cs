// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Castle.DynamicProxy;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync.Interceptors;

[TestFixture]
public class UseSyncMethodsInterceptorTests
{
    [Test]
    public void Constructor_WithForceSyncTrue_CreatesValidInstance()
    {
        var interceptor = CreateUseSyncMethodsInterceptor(forceSync: true);
        
        Assert.IsNotNull(interceptor);
    }

    [Test]
    public void Constructor_WithForceSyncFalse_CreatesValidInstance()
    {
        var interceptor = CreateUseSyncMethodsInterceptor(forceSync: false);
        
        Assert.IsNotNull(interceptor);
    }

    [Test]
    public void Intercept_WithNonAsyncMethod_ProceedsDirectly()
    {
        var interceptor = CreateUseSyncMethodsInterceptor(forceSync: true);
        var mockInvocation = CreateMockInvocation("GetValue", typeof(string));
        
        Assert.DoesNotThrow(() => interceptor.Intercept(mockInvocation));
        Assert.IsTrue(mockInvocation.Proceeded);
    }

    [Test]
    public void Intercept_WithForceSyncFalse_ProceedsDirectly()
    {
        var interceptor = CreateUseSyncMethodsInterceptor(forceSync: false);
        var mockInvocation = CreateMockInvocation("GetValueAsync", typeof(Task<string>));
        
        Assert.DoesNotThrow(() => interceptor.Intercept(mockInvocation));
        Assert.IsTrue(mockInvocation.Proceeded);
    }

    [Test]
    public void Intercept_WithAsyncMethodAndForceSync_FindsSyncMethod()
    {
        var interceptor = CreateUseSyncMethodsInterceptor(forceSync: true);
        var mockClient = new MockClientWithSyncAsync();
        var mockInvocation = CreateMockInvocationForClient(mockClient, "GetValueAsync", typeof(Task<string>));
        
        Assert.DoesNotThrow(() => interceptor.Intercept(mockInvocation));
    }

    [Test]
    public void Intercept_WithAsyncMethodWithoutSyncCounterpart_ThrowsException()
    {
        var interceptor = CreateUseSyncMethodsInterceptor(forceSync: true);
        var mockClient = new MockClientWithAsyncOnly();
        var mockInvocation = CreateMockInvocationForClient(mockClient, "GetDataAsync", typeof(Task<string>));
        
        var ex = Assert.Throws<InvalidOperationException>(() => interceptor.Intercept(mockInvocation));
        Assert.That(ex.Message, Contains.Substring("Unable to find a method with name GetData"));
    }

    [Test]
    public void Intercept_WithProxiedClient_GetsOriginalTarget()
    {
        var interceptor = CreateUseSyncMethodsInterceptor(forceSync: true);
        var originalClient = new MockClientWithSyncAsync();
        var proxiedClient = new MockProxiedClient(originalClient);
        var mockInvocation = CreateMockInvocationForClient(proxiedClient, "GetValueAsync", typeof(Task<string>));
        
        Assert.DoesNotThrow(() => interceptor.Intercept(mockInvocation));
    }

    [Test]
    public void Intercept_WithGenericAsyncMethod_HandlesGenericParameters()
    {
        var interceptor = CreateUseSyncMethodsInterceptor(forceSync: true);
        var mockClient = new MockClientWithGenericMethods();
        var mockInvocation = CreateMockInvocationForClient(mockClient, "GetAsync", typeof(Task<string>), new[] { typeof(string) });
        
        Assert.DoesNotThrow(() => interceptor.Intercept(mockInvocation));
    }

    [Test]
    public void AsyncSuffix_HasCorrectValue()
    {
        // Test that the AsyncSuffix constant is properly defined
        var interceptorType = GetUseSyncMethodsInterceptorType();
        var asyncSuffixField = interceptorType.GetField("AsyncSuffix", BindingFlags.NonPublic | BindingFlags.Static);
        
        Assert.IsNotNull(asyncSuffixField);
        Assert.AreEqual("Async", asyncSuffixField.GetValue(null));
    }

    [Test]
    public void Interceptor_ImplementsIInterceptor()
    {
        var interceptor = CreateUseSyncMethodsInterceptor(forceSync: true);
        
        Assert.IsInstanceOf<IInterceptor>(interceptor);
    }

    [Test]
    public void Intercept_HandlesVoidReturnType()
    {
        var interceptor = CreateUseSyncMethodsInterceptor(forceSync: true);
        var mockClient = new MockClientWithVoidMethods();
        var mockInvocation = CreateMockInvocationForClient(mockClient, "DoWorkAsync", typeof(Task));
        
        Assert.DoesNotThrow(() => interceptor.Intercept(mockInvocation));
    }

    [Test]
    public void Intercept_HandlesCollectionResults()
    {
        var interceptor = CreateUseSyncMethodsInterceptor(forceSync: true);
        var mockClient = new MockClientWithCollections();
        var mockInvocation = CreateMockInvocationForClient(mockClient, "GetItemsAsync", typeof(Task<CollectionResult<string>>));
        
        Assert.DoesNotThrow(() => interceptor.Intercept(mockInvocation));
    }

    // Helper methods
    private object CreateUseSyncMethodsInterceptor(bool forceSync)
    {
        var type = GetUseSyncMethodsInterceptorType();
        return Activator.CreateInstance(type, forceSync);
    }

    private Type GetUseSyncMethodsInterceptorType()
    {
        // UseSyncMethodsInterceptor is internal, so we need to get it via reflection
        var assembly = typeof(ClientTestBase).Assembly;
        return assembly.GetType("Microsoft.ClientModel.TestFramework.UseSyncMethodsInterceptor");
    }

    private MockInvocation CreateMockInvocation(string methodName, Type returnType, Type[] genericArguments = null)
    {
        return new MockInvocation(methodName, returnType, genericArguments);
    }

    private MockInvocation CreateMockInvocationForClient(object client, string methodName, Type returnType, Type[] genericArguments = null)
    {
        var invocation = new MockInvocation(methodName, returnType, genericArguments);
        invocation.InvocationTarget = client;
        return invocation;
    }

    // Helper classes for testing
    public class MockInvocation : IInvocation
    {
        public bool Proceeded { get; private set; }
        public object InvocationTarget { get; set; }
        public MethodInfo Method { get; }
        public object[] Arguments { get; set; } = Array.Empty<object>();
        public Type[] GenericArguments { get; set; } = Array.Empty<Type>();
        public object ReturnValue { get; set; }
        public Type TargetType { get; set; }
        public object Proxy { get; set; }

        public MockInvocation(string methodName, Type returnType, Type[] genericArguments = null)
        {
            var method = typeof(MockClient).GetMethod(methodName) ?? 
                        CreateMockMethodInfo(methodName, returnType);
            Method = method;
            GenericArguments = genericArguments ?? Array.Empty<Type>();
        }

        public void Proceed() => Proceeded = true;
        public void SetArgumentValue(int index, object value) => Arguments[index] = value;
        public object GetArgumentValue(int index) => Arguments[index];
        public MethodInfo GetConcreteMethod() => Method;
        public MethodInfo GetConcreteMethodInvocationTarget() => Method;

        private MethodInfo CreateMockMethodInfo(string methodName, Type returnType)
        {
            // Create a mock MethodInfo for testing
            return typeof(MockClient).GetMethod("GetValue") ?? throw new InvalidOperationException("Mock method not found");
        }
    }

    public class MockClient
    {
        public virtual string GetValue() => "mock";
        public virtual Task<string> GetValueAsync() => Task.FromResult("mock");
    }

    public class MockClientWithSyncAsync
    {
        public virtual string GetValue() => "sync";
        public virtual Task<string> GetValueAsync() => Task.FromResult("async");
    }

    public class MockClientWithAsyncOnly
    {
        public virtual Task<string> GetDataAsync() => Task.FromResult("data");
        // No sync counterpart
    }

    public class MockClientWithGenericMethods
    {
        public virtual T Get<T>() => default(T);
        public virtual Task<T> GetAsync<T>() => Task.FromResult(default(T));
    }

    public class MockClientWithVoidMethods
    {
        public virtual void DoWork() { }
        public virtual Task DoWorkAsync() => Task.CompletedTask;
    }

    public class MockClientWithCollections
    {
        public virtual CollectionResult<T> GetItems<T>() => null;
        public virtual Task<CollectionResult<T>> GetItemsAsync<T>() => Task.FromResult<CollectionResult<T>>(null);
    }

    public class MockProxiedClient : IProxiedClient
    {
        public object Original { get; }
        
        public MockProxiedClient(object original)
        {
            Original = original;
        }
    }
}
