// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using Castle.DynamicProxy;
using OpenAI.TestFramework.Adapters;
using Ext = OpenAI.TestFramework.Utils.TypeExtensions;

namespace OpenAI.TestFramework.AutoSyncAsync;

/// <summary>
/// An interceptor for Castle dynamic proxies that allows you to call the synchronous version of a method when the asynchronous one
/// is called on the proxy. This is useful for testing where you can write the async version of a test, and then automatically test
/// both async and sync methods with the same test code.
/// </summary>
[DebuggerStepThrough]
public class AsyncToSyncInterceptor : IInterceptor
{
    private const string AsyncSuffix = "Async";

    private static readonly TypeArrayEquality s_typeArrayEquality = new();
    private static readonly ConcurrentDictionary<Type, ISet<string>> s_syncAsyncPairs = new();
    private static readonly MethodInfo s_taskFromResult = typeof(Task).GetMethod(nameof(Task.FromResult), BindingFlags.Public | BindingFlags.Static)!;
    private static readonly MethodInfo s_taskFromException = typeof(Task)
        .GetMethods(BindingFlags.Static | BindingFlags.Public)
        .Where(m => m.Name == nameof(Task.FromException) && m.IsGenericMethodDefinition)
        .First();

    private readonly BindingFlags _flags;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="useAsync">True if you want to use async methods, false otherwise.</param>
    /// <param name="flags">The binding flags to use when searching for methods. Default is public instance methods.</param>
    public AsyncToSyncInterceptor(bool useAsync, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance)
    {
        UseAsync = useAsync;
        _flags = flags;
    }

    /// <summary>
    /// Gets the shared use sync methods instance.
    /// </summary>
    public static AsyncToSyncInterceptor UseSyncMethods { get; } = new(false);

    /// <summary>
    /// Gets the shared use async methods instance.
    /// </summary>
    public static AsyncToSyncInterceptor UseAsyncMethods { get; } = new(true);

    /// <inheritdoc />
    [DebuggerStepThrough]
    public virtual void Intercept(IInvocation invocation)
    {
        // 1. Should we even intercept this?
        if (ShouldSkipIntercepting(invocation.Method))
        {
            invocation.Proceed();
            return;
        }

        // 2. Check if this method is one of a pair of Operation and OperationAsync methods.
        bool isSyncAsyncPair = IsMethodSyncAsyncPair(invocation.Method);
        if (!isSyncAsyncPair)
        {
            throw CreateEx("Method does not have a synchronous and asynchronous pair", invocation.Method);
        }

        // 3. If it is, check if the method is the synchronous version. We only allow async versions in the test code
        bool isAsyncMethod = invocation.Method.Name.EndsWith(AsyncSuffix);
        if (!isAsyncMethod)
        {
            throw CreateEx("You must use the asynchronous versions of the methods when writing your tests", invocation.Method);
        }

        Type asyncReturnType = invocation.Method.ReturnType;

        // 4. Call the correct synchronous or asynchronous method and warp the returned result or exception
        if (UseAsync)
        {
            // Async method running in async mode, no need to do anything, special, continue normally
            invocation.Proceed();
        }
        else
        {
            // Call the equivalent sync method
            string methodName = RemoveAsyncSuffix(invocation.Method.Name);
            Type expectedReturnType = ToSyncRetType(asyncReturnType);
            Type[] expectedArgs = invocation.Method.GetParameters().Select(p => p.ParameterType).ToArray();

            MethodInfo syncMethod = invocation.TargetType.GetMethod(
                methodName, _flags, binder: null, expectedArgs, modifiers: null)!;

            // this should never happen since we've already checked for the existence of the expected method
            Debug.Assert(syncMethod != null);
            if (syncMethod == null)
            {
                throw CreateEx("Could not find the synchronous version of the method", invocation.Method);
            }

            if (syncMethod.ContainsGenericParameters)
            {
                syncMethod = syncMethod.MakeGenericMethod(invocation.Method.GetGenericArguments());
            }

            // Call the synchronous method
            try
            {
                object? result = syncMethod.Invoke(invocation.InvocationTarget, invocation.Arguments);
                if (result != null && !expectedReturnType.IsAssignableFrom(result.GetType()))
                {
                    throw CreateEx("The synchronous method returned an unexpected type", invocation.Method);
                }

                invocation.ReturnValue = ToAsyncResult(asyncReturnType, result);
            }
            catch (TargetInvocationException ex)
            {
                invocation.ReturnValue = ToAsyncException(asyncReturnType, ex.InnerException ?? ex);
            }
        }
    }

    /// <summary>
    /// Whether or not we are using async methods.
    /// </summary>
    public bool UseAsync { get; }

    /// Determines whether or not we should skip intercepting this method or not.
    /// </summary>
    /// <param name="method">The method we are inspecting.</param>
    /// <returns>True to skip intercepting this method, false otherwise.</returns>
    protected virtual bool ShouldSkipIntercepting(MethodInfo? method)
    {
        return method == null
            // Skip for special names (i.e. getters and setters)
            || method.IsSpecialName
            // Also for dispose methods
            || method.Name == nameof(IDisposable.Dispose)
            || method.Name == nameof(IAsyncDisposable.DisposeAsync);
    }

    /// <summary>
    /// Determines whether or not the specified method is part of a pair of synchronous and asynchronous methods. This will
    /// check based on 3 factors:
    /// <list type="bullet">
    /// <item>If there is a "???" and "???Async" pair of named methods</item>
    /// <item>If the arguments are exactly the same for both methods</item>
    /// <item>If we know how to determine the expected return type for the synchronous method, from the asynchronous one</item>
    /// </list>
    /// </summary>
    /// <param name="method">The method to check.</param>
    /// <returns>True if it is, false otherwise.</returns>
    protected virtual bool IsMethodSyncAsyncPair(MethodInfo? method)
    {
        if (method == null || method.DeclaringType == null)
        {
            return false;
        }

        ISet<string> validPrefixes = s_syncAsyncPairs.GetOrAdd(method.DeclaringType, t => DetermineValidSyncAsyncPairs(t, _flags));
        return validPrefixes.Contains(RemoveAsyncSuffix(method.Name));
    }

    /// <summary>
    /// Determines what the corresponding synchronous return type would be for the specified asynchronous return type.
    /// </summary>
    /// <param name="asyncReturnType">The asynchronous return type.</param>
    /// <returns>The corresponding synchronous return type.</returns>
    /// <exception cref="NotSupportedException">If we don't know what the equivalent would be.</exception>
    protected virtual Type ToSyncRetType(Type asyncReturnType)
    {
        if (typeof(Task) == asyncReturnType || typeof(ValueTask) == asyncReturnType)
        {
            return typeof(void);
        }
        else if (Ext.IsClosedGenericOf(asyncReturnType, typeof(Task<>), out Type[] genericTypes))
        {
            return genericTypes[0];
        }
        else if (Ext.IsClosedGenericOf(asyncReturnType, typeof(ValueTask<>), out genericTypes))
        {
            return genericTypes[0];
        }
        else if (Ext.IsClosedGenericOf(asyncReturnType, typeof(AsyncCollectionResult<>), out genericTypes))
        {
            return typeof(CollectionResult<>).MakeGenericType(genericTypes);
        }
        else if (typeof(AsyncCollectionResult).IsAssignableFrom(asyncReturnType))
        {
            return typeof(CollectionResult);
        }
        else if (Ext.IsClosedGenericOf(asyncReturnType, typeof(IAsyncEnumerable<>), out genericTypes))
        {
            return typeof(IEnumerable<>).MakeGenericType(genericTypes);
        }
        else
        {
            throw new NotSupportedException("Don't know how to create the sync to async wrapper for " + asyncReturnType.FullName);
        }
    }

    /// <summary>
    /// Wraps the result from a synchronous method into the equivalent asynchronous return type.
    /// </summary>
    /// <param name="asyncReturnType">The asynchronous return type.</param>
    /// <param name="result">The result to wrap.</param>
    /// <returns>The wrapped result.</returns>
    /// <exception cref="NotSupportedException">If we don't support the conversion.</exception>
    protected virtual object? ToAsyncResult(Type asyncReturnType, object? result)
    {
        if (typeof(Task) == asyncReturnType)
        {
            return Task.CompletedTask;
        }
        else if (Ext.IsClosedGenericOf(asyncReturnType, typeof(Task<>), out Type[] genericTypes))
        {
            return s_taskFromResult
                .MakeGenericMethod(genericTypes)
                .Invoke(null, [result]);
        }
        else if (typeof(ValueTask) == asyncReturnType)
        {
            return new ValueTask();
        }
        else if (Ext.IsClosedGenericOf(asyncReturnType, typeof(ValueTask<>), out genericTypes))
        {
            return Activator.CreateInstance(
                typeof(ValueTask<>).MakeGenericType(genericTypes),
                result);
        }
        else if (Ext.IsClosedGenericOf(asyncReturnType, typeof(AsyncCollectionResult<>), out genericTypes))
        {
            return Activator.CreateInstance(
                typeof(SyncToAsyncCollectionResult<>).MakeGenericType(genericTypes),
                result);
        }
        else if (typeof(AsyncCollectionResult).IsAssignableFrom(asyncReturnType))
        {
            return Activator.CreateInstance(
                typeof(SyncToAsyncCollectionResult),
                result);
        }
        else if (Ext.IsClosedGenericOf(asyncReturnType, typeof(IAsyncEnumerable<>), out genericTypes))
        {
            return Activator.CreateInstance(
                typeof(SyncToAsyncEnumerable<>).MakeGenericType(genericTypes),
                result);
        }
        else
        {
            throw new NotSupportedException("Don't know how to wrap the exception for " + asyncReturnType.FullName);
        }
    }

    /// <summary>
    /// Wraps the exception from a synchronous method into the equivalent asynchronous return type.
    /// </summary>
    /// <param name="asyncReturnType">The asynchronous return type.</param>
    /// <param name="ex">The exception to wrap.</param>
    /// <returns>The wrapped exception.</returns>
    /// <exception cref="NotSupportedException">If we don't support the conversion.</exception>
    protected virtual object? ToAsyncException(Type asyncReturnType, Exception ex)
    {
        if (typeof(Task) == asyncReturnType)
        {
            return Task.FromException(ex);
        }
        else if (Ext.IsClosedGenericOf(asyncReturnType, typeof(Task<>), out Type[] genericTypes))
        {
            return s_taskFromException
                .MakeGenericMethod(genericTypes)
                .Invoke(null, [ex]);
        }
        else if (typeof(ValueTask) == asyncReturnType)
        {
            return new ValueTask(Task.FromException(ex));
        }
        else if (Ext.IsClosedGenericOf(asyncReturnType, typeof(ValueTask<>), out genericTypes))
        {
            var failedTask = s_taskFromException
                .MakeGenericMethod(genericTypes)
                .Invoke(null, [ex]);
            return Activator.CreateInstance(
                typeof(ValueTask<>).MakeGenericType(genericTypes),
                failedTask);
        }
        else if (Ext.IsClosedGenericOf(asyncReturnType, typeof(AsyncCollectionResult<>), out genericTypes))
        {
            return Activator.CreateInstance(
                typeof(SyncToAsyncCollectionResult<>).MakeGenericType(genericTypes),
                ex);
        }
        else if (typeof(AsyncCollectionResult).IsAssignableFrom(asyncReturnType))
        {
            return Activator.CreateInstance(
                typeof(SyncToAsyncCollectionResult),
                ex);
        }
        else if (Ext.IsClosedGenericOf(asyncReturnType, typeof(IAsyncEnumerable<>), out genericTypes))
        {
            return Activator.CreateInstance(
                typeof(SyncToAsyncEnumerable<>).MakeGenericType(genericTypes),
                ex);
        }
        else
        {
            throw new NotSupportedException("Don't know how to determine the synchronous equivalent return type of " + asyncReturnType.FullName);
        }
    }

    private static InvalidOperationException CreateEx(string description, MethodInfo method)
    {
        return new InvalidOperationException($"{description}. '{method.DeclaringType?.Name} -> {method.Name}'");
    }

    private static string RemoveAsyncSuffix(string? name)
    {
        if (name == null)
            return string.Empty;

        int index = name.LastIndexOf(AsyncSuffix);
        return index >= 0
            ? name.Substring(0, index)
            : name;
    }

    [DebuggerStepperBoundary]
    private ISet<string> DetermineValidSyncAsyncPairs(Type declaringType, BindingFlags flags)
    {
        // Group potential pairs based only on the method name removing the "Async" postfix
        var potentialPairs = declaringType.GetMethods(flags)
            .Where(m => !m.IsSpecialName)
            .GroupBy(m => RemoveAsyncSuffix(m.Name))
            .OrderBy(g => g.Key)
            .Select(g => new
            {
                g.Key,
                Potentials = g.Select(m => new
                {
                    m.Name,
                    Args = m.GetParameters().Select(p => p.ParameterType).ToArray(),
                    Return = m.ReturnType,
                })
                // Order by name to ensure OperationName comes before OperationNameAsync
                .OrderBy(p => p.Name)
                // Match on method arguments
                .GroupBy(g => g.Args, s_typeArrayEquality)
                .Select(g => g.ToArray())
            });

        // Now evaluate potential pairs to ensure that for each argument list for that method, there exists both a synchronous
        // and asynchronous version with equivalent return types
        HashSet<string> validPairPrefixes = new();

        foreach (var entry in potentialPairs)
        {
            bool allValid = entry.Potentials.All(matchedPair =>
            {
                // because of the way we sorted above, we should have exactly 2 entries here, the first is the synchronous method
                // the second the corresponding asynchronous method
                return matchedPair.Length == 2
                    && matchedPair[0].Name + AsyncSuffix == matchedPair[1].Name
                    && matchedPair[0].Return == ToSyncRetType(matchedPair[1].Return);
            });

            if (allValid)
            {
                validPairPrefixes.Add(entry.Key);
            }
        }

        return validPairPrefixes;
    }

    /// <summary>
    /// Helper comparer that compares all of the Types in an array for equality.
    /// </summary>
    private class TypeArrayEquality : IEqualityComparer<Type[]>
    {
        /// <inheritdoc />
        public bool Equals(Type[]? x, Type[]? y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            else if (x == null || y == null)
            {
                return false;
            }
            else if (x.LongLength != y.LongLength)
            {
                return false;
            }

            for (long i = 0; i < x.LongLength; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc />
        public int GetHashCode(Type[] obj)
        {
            if (obj == null)
            {
                return 0;
            }

            int rollingHash = 1; // to distinguish empty case from null case
            for (long i = 0; i < obj.LongLength; i++)
            {
                rollingHash = (rollingHash, obj[i].GetHashCode()).GetHashCode();
            }

            return rollingHash;
        }
    }
}
