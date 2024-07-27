// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Castle.DynamicProxy;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenAI.TestFramework.Mocks.Client;

namespace OpenAI.TestFramework;

/// <summary>
/// Base class for client test cases. This provides support for writing only a test that uses the Async version of
/// methods, and automatically creating a test that uses the equivalent Sync version of a method. Please note that
/// this will only work for public virtual methods. In order for this to work, you should write a test that uses the
/// async version of a method.
/// </summary>
[TestFixture(true)]
[TestFixture(false)]
public abstract class SyncAsyncTestBase
{
    private static ProxyGenerator? s_proxyGenerator = null;
    private static ThisLeakInterceptor? s_thisLeakInterceptor = null;
    private static AsyncToSyncInterceptor? s_asyncInterceptor = null;
    private static AsyncToSyncInterceptor? s_syncInterceptor = null;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="isAsync">True to run the async version of a test, false to run the sync version of a test.</param>
    public SyncAsyncTestBase(bool isAsync)
    {
        IsAsync = isAsync;
    }

    /// <summary>
    /// Gets whether or not we are running async tests.
    /// </summary>
    public virtual bool IsAsync { get; }

    /// <summary>
    /// Gets the start time of the test.
    /// </summary>
    public virtual DateTimeOffset TestStartTime => TestExecutionContext.CurrentContext.StartTime.ToUniversalTime();

    /// <summary>
    /// Gets the <see cref="Castle.DynamicProxy.ProxyGenerator"/> instance to use to create proxies of classes
    /// that allow you inject additional functionality in for testing.
    /// </summary>
    protected static ProxyGenerator ProxyGenerator => s_proxyGenerator ??= new ProxyGenerator();

    /// <summary>
    /// An interceptor that prevents leaking a reference to the original instance as a return value from methods.
    /// </summary>
    protected static ThisLeakInterceptor ThisLeakInterceptor => s_thisLeakInterceptor ??= new ThisLeakInterceptor();

    /// <summary>
    /// An interceptor to force the use of async version of a method.
    /// </summary>
    protected static AsyncToSyncInterceptor UseSyncMethodInterceptor => s_syncInterceptor ??= new AsyncToSyncInterceptor(false);

    /// <summary>
    /// An interceptor to force the use of sync version of a method.
    /// </summary>
    protected static AsyncToSyncInterceptor UseAsyncMethodInterceptor => s_asyncInterceptor ??= new AsyncToSyncInterceptor(true);

    /// <summary>
    /// Wraps an instance for automatic sync/async testing. This will return a proxied version of the client that will allow you to
    /// automatically use the sync versions of a method.
    /// </summary>
    /// <typeparam name="T">The type of the client instance.</typeparam>
    /// <param name="instance">The client instance to instrument for testing.</param>
    /// <param name="context">(Optional) Any additional context to associate with the instrumented client.</param>
    /// <param name="interceptors">(Optional) Any additional interceptors to use.</param>
    /// <returns>The proxied version of the client.</returns>
    public T WrapForSyncAsync<T>(T instance, object? context = null, params IInterceptor[] interceptors) where T : class
        => (T)WrapForSyncAsync(typeof(T), instance, context, interceptors);

    /// <summary>
    /// Gets the original un-instrumented instance from an instrumented client.
    /// </summary>
    /// <typeparam name="T">The type of the client.</typeparam>
    /// <param name="wrapped">The instrumented client instance.</param>
    /// <returns>The original instance.</returns>
    /// <exception cref="NotSupportedException">The the instance passed was not wrapped.</exception>
    public virtual T UnWrap<T>(T wrapped) where T : class
    {
        if (wrapped is IInstrumented instrumented)
        {
            return (T)instrumented.Original;
        }

        throw new NotSupportedException($"That instance was not wrapped using {nameof(WrapForSyncAsync)}");
    }

    /// <summary>
    /// Gets the context associated with the wrapped instance.
    /// </summary>
    /// <typeparam name="T">The type of the client.</typeparam>
    /// <param name="wrapped">The wrapped instance.</param>
    /// <returns>The associated context for the wrapped instance. Will be null if none was set.</returns>
    /// <exception cref="NotSupportedException">The the instance passed was not wrapped.</exception>
    public virtual object? GetWrappedContext<T>(T wrapped) where T : class
    {
        if (wrapped is IInstrumented instrumented)
        {
            return instrumented.Context;
        }

        throw new NotSupportedException($"That instance was not wrapped using {nameof(WrapForSyncAsync)}");
    }

    /// <summary>
    /// Wraps an instance with sync/async equivalent methods for testing. This enables the automatic testing of the sync version
    /// of methods if you write an async test case.
    /// </summary>
    /// <param name="instanceType">The type of the client.</param>
    /// <param name="instance">The instance.</param>
    /// <param name="context">(Optional) Any additional context to associate with the instrumented client.</param>
    /// <param name="interceptors">(Optional) Any additional interceptors to include.</param>
    /// <returns>The wrapped version of the instance.</returns>
    protected internal virtual object WrapForSyncAsync(Type instanceType, object instance, object? context, IEnumerable<IInterceptor>? interceptors)
    {
        List<IInterceptor> allInterceptors = new();

        if (interceptors != null)
        {
            allInterceptors.AddRange(interceptors);
        }

        allInterceptors.Add(ThisLeakInterceptor);
        allInterceptors.Add(IsAsync ? UseAsyncMethodInterceptor : UseSyncMethodInterceptor);

        ProxyGenerationOptions options = new();
        options.AddMixinInstance(new InstrumentedMixIn(instance, context));

        object proxy = ProxyGenerator.CreateClassProxyWithTarget(
            instanceType,
            [],
            instance,
            options,
            allInterceptors.ToArray());

        return proxy;
    }
}
