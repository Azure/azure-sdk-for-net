// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Provides extension methods for working with asynchronous operations in testing scenarios,
/// including timeout handling, task completion verification, and synchronous execution patterns.
/// </summary>
public static class TaskExtensions
{
    /// <summary>
    /// Gets the default timeout duration used by timeout extension methods when no specific timeout is provided.
    /// </summary>
    /// <value>A <see cref="TimeSpan"/> representing 10 seconds.</value>
    public static TimeSpan DefaultTimeout { get; } = TimeSpan.FromSeconds(10);

    /// <summary>
    /// Applies the default timeout to a task that returns a value. If the task does not complete within
    /// the default timeout period, a <see cref="TimeoutException"/> is thrown with caller information.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="task">The task to apply the timeout to.</param>
    /// <param name="filePath">The source file path of the caller. This parameter is automatically populated by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file of the caller. This parameter is automatically populated by the compiler.</param>
    /// <returns>A task that completes with the original task's result or throws a <see cref="TimeoutException"/>.</returns>
    /// <exception cref="TimeoutException">Thrown when the task does not complete within the default timeout period.</exception>
    public static Task<T> TimeoutAfterDefault<T>(this Task<T> task,
        [CallerFilePath] string? filePath = null,
        [CallerLineNumber] int lineNumber = default)
    {
        return task.TimeoutAfter(DefaultTimeout, filePath, lineNumber);
    }

    /// <summary>
    /// Applies the default timeout to a task. If the task does not complete within
    /// the default timeout period, a <see cref="TimeoutException"/> is thrown with caller information.
    /// </summary>
    /// <param name="task">The task to apply the timeout to.</param>
    /// <param name="filePath">The source file path of the caller. This parameter is automatically populated by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file of the caller. This parameter is automatically populated by the compiler.</param>
    /// <returns>A task that completes when the original task completes or throws a <see cref="TimeoutException"/>.</returns>
    /// <exception cref="TimeoutException">Thrown when the task does not complete within the default timeout period.</exception>
    public static Task TimeoutAfterDefault(this Task task,
        [CallerFilePath] string? filePath = null,
        [CallerLineNumber] int lineNumber = default)
    {
        return task.TimeoutAfter(DefaultTimeout, filePath, lineNumber);
    }

    /// <summary>
    /// Applies the default timeout to a <see cref="ValueTask{T}"/> that returns a value. If the task does not complete within
    /// the default timeout period, a <see cref="TimeoutException"/> is thrown with caller information.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="task">The <see cref="ValueTask{T}"/> to apply the timeout to.</param>
    /// <param name="filePath">The source file path of the caller. This parameter is automatically populated by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file of the caller. This parameter is automatically populated by the compiler.</param>
    /// <returns>A <see cref="ValueTask{T}"/> that completes with the original task's result or throws a <see cref="TimeoutException"/>.</returns>
    /// <exception cref="TimeoutException">Thrown when the task does not complete within the default timeout period.</exception>
    public static ValueTask<T> TimeoutAfterDefault<T>(this ValueTask<T> task,
        [CallerFilePath] string? filePath = null,
        [CallerLineNumber] int lineNumber = default)
    {
        return task.TimeoutAfter(DefaultTimeout, filePath, lineNumber);
    }

    /// <summary>
    /// Applies the default timeout to a <see cref="ValueTask"/>. If the task does not complete within
    /// the default timeout period, a <see cref="TimeoutException"/> is thrown with caller information.
    /// </summary>
    /// <param name="task">The <see cref="ValueTask"/> to apply the timeout to.</param>
    /// <param name="filePath">The source file path of the caller. This parameter is automatically populated by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file of the caller. This parameter is automatically populated by the compiler.</param>
    /// <returns>A <see cref="ValueTask"/> that completes when the original task completes or throws a <see cref="TimeoutException"/>.</returns>
    /// <exception cref="TimeoutException">Thrown when the task does not complete within the default timeout period.</exception>
    public static ValueTask TimeoutAfterDefault(this ValueTask task,
        [CallerFilePath] string? filePath = null,
        [CallerLineNumber] int lineNumber = default)
    {
        return task.TimeoutAfter(DefaultTimeout, filePath, lineNumber);
    }

    /// <summary>
    /// Applies a custom timeout to a task that returns a value. If the task does not complete within
    /// the specified timeout period, a <see cref="TimeoutException"/> is thrown. The timeout is ignored
    /// if a debugger is attached or if the task is already completed.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="task">The task to apply the timeout to.</param>
    /// <param name="timeout">The maximum time to wait for the task to complete.</param>
    /// <param name="filePath">The source file path of the caller. This parameter is automatically populated by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file of the caller. This parameter is automatically populated by the compiler.</param>
    /// <returns>A task that completes with the original task's result or throws a <see cref="TimeoutException"/>.</returns>
    /// <exception cref="TimeoutException">Thrown when the task does not complete within the specified timeout period.</exception>
    public static async Task<T> TimeoutAfter<T>(this Task<T> task, TimeSpan timeout,
        [CallerFilePath] string? filePath = null,
        [CallerLineNumber] int lineNumber = default)
    {
        // Don't create a timer if the task is already completed
        // or the debugger is attached
        if (task.IsCompleted || Debugger.IsAttached)
        {
            return await task.ConfigureAwait(false);
        }

        var cts = new CancellationTokenSource();
        if (task == await Task.WhenAny(task, Task.Delay(timeout, cts.Token)).ConfigureAwait(false))
        {
            cts.Cancel();
            return await task.ConfigureAwait(false);
        }
        else
        {
            throw new TimeoutException(CreateMessage(timeout, filePath, lineNumber));
        }
    }

    /// <summary>
    /// Applies a custom timeout to a task. If the task does not complete within
    /// the specified timeout period, a <see cref="TimeoutException"/> is thrown. The timeout is ignored
    /// if a debugger is attached or if the task is already completed.
    /// </summary>
    /// <param name="task">The task to apply the timeout to.</param>
    /// <param name="timeout">The maximum time to wait for the task to complete.</param>
    /// <param name="filePath">The source file path of the caller. This parameter is automatically populated by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file of the caller. This parameter is automatically populated by the compiler.</param>
    /// <returns>A task that completes when the original task completes or throws a <see cref="TimeoutException"/>.</returns>
    /// <exception cref="TimeoutException">Thrown when the task does not complete within the specified timeout period.</exception>
    public static async Task TimeoutAfter(this Task task, TimeSpan timeout,
        [CallerFilePath] string? filePath = null,
        [CallerLineNumber] int lineNumber = default)
    {
        // Don't create a timer if the task is already completed
        // or the debugger is attached
        if (task.IsCompleted || Debugger.IsAttached)
        {
            await task.ConfigureAwait(false);
            return;
        }

        var cts = new CancellationTokenSource();
        if (task == await Task.WhenAny(task, Task.Delay(timeout, cts.Token)).ConfigureAwait(false))
        {
            cts.Cancel();
            await task.ConfigureAwait(false);
        }
        else
        {
            throw new TimeoutException(CreateMessage(timeout, filePath, lineNumber));
        }
    }

    /// <summary>
    /// Applies a custom timeout to a <see cref="ValueTask{T}"/>. This method converts the <see cref="ValueTask{T}"/>
    /// to a <see cref="Task{T}"/> and applies the timeout logic.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="task">The <see cref="ValueTask{T}"/> to apply the timeout to.</param>
    /// <param name="timeout">The maximum time to wait for the task to complete.</param>
    /// <param name="filePath">The source file path of the caller. This parameter is automatically populated by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file of the caller. This parameter is automatically populated by the compiler.</param>
    /// <returns>A <see cref="ValueTask{T}"/> that completes with the original task's result or throws a <see cref="TimeoutException"/>.</returns>
    /// <exception cref="TimeoutException">Thrown when the task does not complete within the specified timeout period.</exception>
    public static ValueTask<T> TimeoutAfter<T>(this ValueTask<T> task, TimeSpan timeout,
        [CallerFilePath] string? filePath = null,
        [CallerLineNumber] int lineNumber = default)
    {
        return new(TimeoutAfter(task.AsTask(), timeout, filePath, lineNumber));
    }

    /// <summary>
    /// Applies a custom timeout to a <see cref="ValueTask"/>. This method converts the <see cref="ValueTask"/>
    /// to a <see cref="Task"/> and applies the timeout logic.
    /// </summary>
    /// <param name="task">The <see cref="ValueTask"/> to apply the timeout to.</param>
    /// <param name="timeout">The maximum time to wait for the task to complete.</param>
    /// <param name="filePath">The source file path of the caller. This parameter is automatically populated by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file of the caller. This parameter is automatically populated by the compiler.</param>
    /// <returns>A <see cref="ValueTask"/> that completes when the original task completes or throws a <see cref="TimeoutException"/>.</returns>
    /// <exception cref="TimeoutException">Thrown when the task does not complete within the specified timeout period.</exception>
    public static ValueTask TimeoutAfter(this ValueTask task, TimeSpan timeout,
        [CallerFilePath] string? filePath = null,
        [CallerLineNumber] int lineNumber = default)
    {
        return new(TimeoutAfter(task.AsTask(), timeout, filePath, lineNumber));
    }

    private static string CreateMessage(TimeSpan timeout, string? filePath, int lineNumber)
        => string.IsNullOrEmpty(filePath)
            ? $"The operation timed out after reaching the limit of {timeout.TotalMilliseconds}ms."
            : $"The operation at {filePath}:{lineNumber} timed out after reaching the limit of {timeout.TotalMilliseconds}ms.";

    /// <summary>
    /// Determines whether a task object is in a faulted state using reflection.
    /// This method is used for runtime task inspection when the exact task type is not known at compile time.
    /// </summary>
    /// <param name="taskObj">The task object to inspect.</param>
    /// <returns>
    /// <see langword="true"/> if the task is faulted; <see langword="false"/> if the task is not faulted;
    /// <see langword="null"/> if the object does not have an IsFaulted property or reflection fails.
    /// </returns>
    public static bool? IsTaskFaulted(object taskObj)
    {
        var result = taskObj.GetType().GetProperty("IsFaulted")?.GetValue(taskObj);
        return result == null ? null : (bool)result;
    }

    /// <summary>
    /// Extracts the result value from a task object using reflection. This method handles both
    /// regular objects and task types, unwrapping task results and properly handling exceptions.
    /// </summary>
    /// <param name="returnValue">The object to extract a result from, which may be a task or a regular value.</param>
    /// <returns>
    /// The unwrapped result value. For non-task objects, returns the object itself.
    /// For task objects, returns the task's Result property value.
    /// </returns>
    /// <exception cref="Exception">
    /// Throws the original exception if the task is faulted, unwrapping <see cref="TargetInvocationException"/>
    /// and <see cref="AggregateException"/> to expose the underlying cause.
    /// </exception>
    public static object? GetResultFromTask(object returnValue)
    {
        try
        {
            Type returnType = returnValue.GetType();
            return IsTaskType(returnType)
                ? returnType.GetProperty("Result")?.GetValue(returnValue)
                : returnValue;
        }
        catch (TargetInvocationException e)
        {
            if (e.InnerException is AggregateException aggException)
            {
                throw aggException.InnerExceptions.First();
            }
            else
            {
                throw e.InnerException ?? e;
            }
        }
    }

    /// <summary>
    /// Determines whether a given type represents a task-like type that can be awaited.
    /// This includes <see cref="Task"/>, <see cref="ValueTask"/>, and their generic variants,
    /// as well as internal .NET types like AsyncStateMachineBox used in .NET 5+.
    /// </summary>
    /// <param name="type">The type to check.</param>
    /// <returns>
    /// <see langword="true"/> if the type represents a task-like type; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool IsTaskType(Type type)
    {
        string name = type.Name;
        return name.StartsWith("ValueTask", StringComparison.Ordinal) ||
               name.StartsWith("Task", StringComparison.Ordinal) ||
               name.StartsWith("AsyncStateMachineBox", StringComparison.Ordinal); //in .net 5 the type is not task here
    }

    /// <summary>
    /// Creates a <see cref="Task"/> from a result value using <see cref="Task.FromResult{TResult}"/> via reflection.
    /// This method is used when the result type is determined at runtime.
    /// </summary>
    /// <param name="taskResultType">The type of the result value that will be wrapped in a task.</param>
    /// <param name="instrumentedResult">The result value to wrap in a completed task.</param>
    /// <returns>
    /// A completed <see cref="Task{TResult}"/> containing the provided result value, or <see langword="null"/>
    /// if reflection fails to create the generic method.
    /// </returns>
    public static object? GetValueFromTask(Type taskResultType, object instrumentedResult)
    {
        var method = typeof(Task).GetMethod("FromResult", BindingFlags.Public | BindingFlags.Static);
        var genericMethod = method?.MakeGenericMethod(taskResultType);
        return genericMethod?.Invoke(null, new object[] { instrumentedResult });
    }

    /// <summary>
    /// Creates an awaitable wrapper that allows a <see cref="Task"/> to be awaited with cancellation support.
    /// The returned awaitable will complete when either the task completes or the cancellation token is triggered.
    /// </summary>
    /// <param name="task">The task to wrap with cancellation support.</param>
    /// <param name="cancellationToken">The cancellation token to observe.</param>
    /// <returns>An awaitable that supports cancellation.</returns>
    public static WithCancellationTaskAwaitable AwaitWithCancellation(this Task task, CancellationToken cancellationToken)
        => new WithCancellationTaskAwaitable(task, cancellationToken);

    /// <summary>
    /// Creates an awaitable wrapper that allows a <see cref="Task{T}"/> to be awaited with cancellation support.
    /// The returned awaitable will complete when either the task completes or the cancellation token is triggered.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="task">The task to wrap with cancellation support.</param>
    /// <param name="cancellationToken">The cancellation token to observe.</param>
    /// <returns>An awaitable that supports cancellation and returns the task result.</returns>
    public static WithCancellationTaskAwaitable<T> AwaitWithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
        => new WithCancellationTaskAwaitable<T>(task, cancellationToken);

    /// <summary>
    /// Creates an awaitable wrapper that allows a <see cref="ValueTask{T}"/> to be awaited with cancellation support.
    /// The returned awaitable will complete when either the task completes or the cancellation token is triggered.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="task">The <see cref="ValueTask{T}"/> to wrap with cancellation support.</param>
    /// <param name="cancellationToken">The cancellation token to observe.</param>
    /// <returns>An awaitable that supports cancellation and returns the task result.</returns>
    public static WithCancellationValueTaskAwaitable<T> AwaitWithCancellation<T>(this ValueTask<T> task, CancellationToken cancellationToken)
        => new WithCancellationValueTaskAwaitable<T>(task, cancellationToken);

    /// <summary>
    /// Synchronously waits for a <see cref="Task{T}"/> to complete and returns its result.
    /// This method is compliant with Azure SDK guidelines (AZC0102) and includes debug-time
    /// verification that the task is already completed to avoid blocking.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="task">The task to wait for completion.</param>
    /// <returns>The result of the completed task.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown in debug builds if the task is not already completed, indicating a potential deadlock scenario.
    /// </exception>
    /// <remarks>
    /// This method should only be used when the task is expected to be already completed.
    /// In debug builds, it verifies this assumption to help catch potential deadlock issues.
    /// </remarks>
    public static T EnsureCompleted<T>(this Task<T> task)
    {
#if DEBUG
        VerifyTaskCompleted(task.IsCompleted);
#endif
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        return task.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
    }

    /// <summary>
    /// Synchronously waits for a <see cref="Task"/> to complete.
    /// This method is compliant with Azure SDK guidelines (AZC0102) and includes debug-time
    /// verification that the task is already completed to avoid blocking.
    /// </summary>
    /// <param name="task">The task to wait for completion.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown in debug builds if the task is not already completed, indicating a potential deadlock scenario.
    /// </exception>
    /// <remarks>
    /// This method should only be used when the task is expected to be already completed.
    /// In debug builds, it verifies this assumption to help catch potential deadlock issues.
    /// </remarks>
    public static void EnsureCompleted(this Task task)
    {
#if DEBUG
        VerifyTaskCompleted(task.IsCompleted);
#endif
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        task.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
    }

    /// <summary>
    /// Synchronously waits for a <see cref="ValueTask{T}"/> to complete and returns its result.
    /// This method is compliant with Azure SDK guidelines (AZC0102) and includes debug-time
    /// verification that the task is already completed to avoid blocking.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="task">The <see cref="ValueTask{T}"/> to wait for completion.</param>
    /// <returns>The result of the completed task.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown in debug builds if the task is not already completed, indicating a potential deadlock scenario.
    /// </exception>
    /// <remarks>
    /// This method should only be used when the task is expected to be already completed.
    /// In debug builds, it verifies this assumption to help catch potential deadlock issues.
    /// </remarks>
    public static T EnsureCompleted<T>(this ValueTask<T> task)
    {
#if DEBUG
        VerifyTaskCompleted(task.IsCompleted);
#endif
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        return task.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
    }

    /// <summary>
    /// Synchronously waits for a <see cref="ValueTask"/> to complete.
    /// This method is compliant with Azure SDK guidelines (AZC0102) and includes debug-time
    /// verification that the task is already completed to avoid blocking.
    /// </summary>
    /// <param name="task">The <see cref="ValueTask"/> to wait for completion.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown in debug builds if the task is not already completed, indicating a potential deadlock scenario.
    /// </exception>
    /// <remarks>
    /// This method should only be used when the task is expected to be already completed.
    /// In debug builds, it verifies this assumption to help catch potential deadlock issues.
    /// </remarks>
    public static void EnsureCompleted(this ValueTask task)
    {
#if DEBUG
        VerifyTaskCompleted(task.IsCompleted);
#endif
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        task.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
    }

    /// <summary>
    /// Converts an <see cref="IAsyncEnumerable{T}"/> to a synchronous enumerable that can be used
    /// in scenarios where async enumeration is not supported. This method provides a bridge between
    /// asynchronous and synchronous enumeration patterns.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
    /// <param name="asyncEnumerable">The asynchronous enumerable to convert.</param>
    /// <returns>A synchronous enumerable that wraps the async enumerable.</returns>
    /// <remarks>
    /// The returned enumerable will synchronously wait for each <c>MoveNextAsync</c> call,
    /// which may cause blocking if the async enumerable is not ready.
    /// </remarks>
    public static Enumerable<T> EnsureSyncEnumerable<T>(this IAsyncEnumerable<T> asyncEnumerable) => new Enumerable<T>(asyncEnumerable);

    /// <summary>
    /// Conditionally verifies that a <see cref="ConfiguredValueTaskAwaitable{T}"/> is completed when not running asynchronously.
    /// This method is used in dual sync/async patterns to ensure tasks are completed before synchronous access.
    /// </summary>
    /// <typeparam name="T">The type of the awaitable result.</typeparam>
    /// <param name="awaitable">The configured awaitable to check.</param>
    /// <param name="async">If <see langword="true"/>, no verification is performed. If <see langword="false"/>, verifies the awaitable is completed in debug builds.</param>
    /// <returns>The original awaitable, unchanged.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown in debug builds when <paramref name="async"/> is <see langword="false"/> and the awaitable is not completed.
    /// </exception>
#pragma warning disable AZC0105
    public static ConfiguredValueTaskAwaitable<T> EnsureCompleted<T>(this ConfiguredValueTaskAwaitable<T> awaitable, bool async)
#pragma warning restore AZC0105
    {
        if (!async)
        {
#if DEBUG
            VerifyTaskCompleted(awaitable.GetAwaiter().IsCompleted);
#endif
        }
        return awaitable;
    }

    /// <summary>
    /// Conditionally verifies that a <see cref="ConfiguredValueTaskAwaitable"/> is completed when not running asynchronously.
    /// This method is used in dual sync/async patterns to ensure tasks are completed before synchronous access.
    /// </summary>
    /// <param name="awaitable">The configured awaitable to check.</param>
    /// <param name="async">If <see langword="true"/>, no verification is performed. If <see langword="false"/>, verifies the awaitable is completed in debug builds.</param>
    /// <returns>The original awaitable, unchanged.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown in debug builds when <paramref name="async"/> is <see langword="false"/> and the awaitable is not completed.
    /// </exception>
#pragma warning disable AZC0105
    public static ConfiguredValueTaskAwaitable EnsureCompleted(this ConfiguredValueTaskAwaitable awaitable, bool async)
#pragma warning restore AZC0105
    {
        if (!async)
        {
#if DEBUG
            VerifyTaskCompleted(awaitable.GetAwaiter().IsCompleted);
#endif
        }
        return awaitable;
    }

    [Conditional("DEBUG")]
    private static void VerifyTaskCompleted(bool isCompleted)
    {
        if (!isCompleted)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
            // Throw an InvalidOperationException instead of using
            // Debug.Assert because that brings down nUnit immediately
            throw new InvalidOperationException("Task is not completed");
        }
    }

    /// <summary>
    /// A synchronous enumerable wrapper for <see cref="IAsyncEnumerable{T}"/> that allows async enumerables
    /// to be used in synchronous foreach loops. Both <see cref="Enumerable{T}"/> and <see cref="Enumerator{T}"/>
    /// are defined as public structs so that foreach can use duck typing to call
    /// <see cref="Enumerable{T}.GetEnumerator"/> and avoid heap memory allocation.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
    public readonly struct Enumerable<T> : IEnumerable<T>
    {
        private readonly IAsyncEnumerable<T> _asyncEnumerable;

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumerable{T}"/> struct.
        /// </summary>
        /// <param name="asyncEnumerable">The async enumerable to wrap.</param>
        public Enumerable(IAsyncEnumerable<T> asyncEnumerable) => _asyncEnumerable = asyncEnumerable;

        /// <summary>
        /// Returns an enumerator that synchronously iterates through the async collection.
        /// This method is used by foreach loops via duck typing.
        /// </summary>
        /// <returns>A <see cref="Enumerator{T}"/> that can iterate through the collection.</returns>
        public Enumerator<T> GetEnumerator() => new Enumerator<T>(_asyncEnumerable.GetAsyncEnumerator());

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> that can be used to iterate through the collection.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator<T>(_asyncEnumerable.GetAsyncEnumerator());

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// A synchronous enumerator that wraps an <see cref="IAsyncEnumerator{T}"/> to provide
    /// synchronous enumeration over asynchronous sequences. This struct is designed to work
    /// efficiently with foreach loops and avoid heap allocations.
    /// </summary>
    /// <typeparam name="T">The type of elements being enumerated.</typeparam>
    public readonly struct Enumerator<T> : IEnumerator<T>
    {
        private readonly IAsyncEnumerator<T> _asyncEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumerator{T}"/> struct.
        /// </summary>
        /// <param name="asyncEnumerator">The async enumerator to wrap.</param>
        public Enumerator(IAsyncEnumerator<T> asyncEnumerator) => _asyncEnumerator = asyncEnumerator;

        /// <summary>
        /// Synchronously advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the enumerator was successfully advanced to the next element;
        /// <see langword="false"/> if the enumerator has passed the end of the collection.
        /// </returns>
#pragma warning disable AZC0107 // Do not call public asynchronous method in synchronous scope.
        public bool MoveNext() => _asyncEnumerator.MoveNextAsync().EnsureCompleted();
#pragma warning restore AZC0107 // Do not call public asynchronous method in synchronous scope.

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Always thrown because async enumerators cannot be reset.
        /// </exception>
        public void Reset() => throw new NotSupportedException($"{GetType()} is a synchronous wrapper for {_asyncEnumerator.GetType()} async enumerator, which can't be reset, so IEnumerable.Reset() calls aren't supported.");

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        /// <value>The element in the collection at the current position of the enumerator.</value>
        public T Current => _asyncEnumerator.Current;

        /// <summary>
        /// Gets the current element in the collection.
        /// </summary>
        /// <value>The current element in the collection.</value>
        object? IEnumerator.Current => Current;

        /// <summary>
        /// Synchronously performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
#pragma warning disable AZC0107 // Do not call public asynchronous method in synchronous scope.
        public void Dispose() => _asyncEnumerator.DisposeAsync().EnsureCompleted();
#pragma warning restore AZC0107 // Do not call public asynchronous method in synchronous scope.
    }

    /// <summary>
    /// An awaitable wrapper that adds cancellation support to a <see cref="Task"/>.
    /// This struct allows tasks to be awaited with cancellation token observation.
    /// </summary>
    public readonly struct WithCancellationTaskAwaitable
    {
        private readonly CancellationToken _cancellationToken;
        private readonly ConfiguredTaskAwaitable _awaitable;

        /// <summary>
        /// Initializes a new instance of the <see cref="WithCancellationTaskAwaitable"/> struct.
        /// </summary>
        /// <param name="task">The task to make cancellation-aware.</param>
        /// <param name="cancellationToken">The cancellation token to observe.</param>
        public WithCancellationTaskAwaitable(Task task, CancellationToken cancellationToken)
        {
            _awaitable = task.ConfigureAwait(false);
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Returns an awaiter for this awaitable.
        /// </summary>
        /// <returns>An awaiter that supports cancellation.</returns>
        public WithCancellationTaskAwaiter GetAwaiter() => new WithCancellationTaskAwaiter(_awaitable.GetAwaiter(), _cancellationToken);
    }

    /// <summary>
    /// An awaitable wrapper that adds cancellation support to a <see cref="Task{T}"/>.
    /// This struct allows tasks to be awaited with cancellation token observation.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    public readonly struct WithCancellationTaskAwaitable<T>
    {
        private readonly CancellationToken _cancellationToken;
        private readonly ConfiguredTaskAwaitable<T> _awaitable;

        /// <summary>
        /// Initializes a new instance of the <see cref="WithCancellationTaskAwaitable{T}"/> struct.
        /// </summary>
        /// <param name="task">The task to make cancellation-aware.</param>
        /// <param name="cancellationToken">The cancellation token to observe.</param>
        public WithCancellationTaskAwaitable(Task<T> task, CancellationToken cancellationToken)
        {
            _awaitable = task.ConfigureAwait(false);
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Returns an awaiter for this awaitable.
        /// </summary>
        /// <returns>An awaiter that supports cancellation.</returns>
        public WithCancellationTaskAwaiter<T> GetAwaiter() => new WithCancellationTaskAwaiter<T>(_awaitable.GetAwaiter(), _cancellationToken);
    }

    /// <summary>
    /// An awaitable wrapper that adds cancellation support to a <see cref="ValueTask{T}"/>.
    /// This struct allows value tasks to be awaited with cancellation token observation.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    public readonly struct WithCancellationValueTaskAwaitable<T>
    {
        private readonly CancellationToken _cancellationToken;
        private readonly ConfiguredValueTaskAwaitable<T> _awaitable;

        /// <summary>
        /// Initializes a new instance of the <see cref="WithCancellationValueTaskAwaitable{T}"/> struct.
        /// </summary>
        /// <param name="task">The value task to make cancellation-aware.</param>
        /// <param name="cancellationToken">The cancellation token to observe.</param>
        public WithCancellationValueTaskAwaitable(ValueTask<T> task, CancellationToken cancellationToken)
        {
            _awaitable = task.ConfigureAwait(false);
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Returns an awaiter for this awaitable.
        /// </summary>
        /// <returns>An awaiter that supports cancellation.</returns>
        public WithCancellationValueTaskAwaiter<T> GetAwaiter() => new WithCancellationValueTaskAwaiter<T>(_awaitable.GetAwaiter(), _cancellationToken);
    }

    /// <summary>
    /// An awaiter that adds cancellation support to a <see cref="Task"/>.
    /// This awaiter will complete when either the task completes or the cancellation token is triggered.
    /// </summary>
    public readonly struct WithCancellationTaskAwaiter : ICriticalNotifyCompletion
    {
        private readonly CancellationToken _cancellationToken;
        private readonly ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _taskAwaiter;

        /// <summary>
        /// Initializes a new instance of the <see cref="WithCancellationTaskAwaiter"/> struct.
        /// </summary>
        /// <param name="awaiter">The task awaiter to wrap.</param>
        /// <param name="cancellationToken">The cancellation token to observe.</param>
        public WithCancellationTaskAwaiter(ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter, CancellationToken cancellationToken)
        {
            _taskAwaiter = awaiter;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Gets a value indicating whether the awaitable has completed.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the task is completed or the cancellation token has been triggered; otherwise, <see langword="false"/>.
        /// </value>
        public bool IsCompleted => _taskAwaiter.IsCompleted || _cancellationToken.IsCancellationRequested;

        /// <summary>
        /// Schedules the continuation action that's invoked when the instance completes.
        /// </summary>
        /// <param name="continuation">The action to invoke when the operation completes.</param>
        public void OnCompleted(Action continuation) => _taskAwaiter.OnCompleted(WrapContinuation(continuation));

        /// <summary>
        /// Schedules the continuation action that's invoked when the instance completes.
        /// </summary>
        /// <param name="continuation">The action to invoke when the operation completes.</param>
        public void UnsafeOnCompleted(Action continuation) => _taskAwaiter.UnsafeOnCompleted(WrapContinuation(continuation));

        /// <summary>
        /// Ends the wait for the completion of the awaitable and returns the result.
        /// </summary>
        /// <exception cref="OperationCanceledException">
        /// Thrown if the cancellation token was triggered before the task completed.
        /// </exception>
        public void GetResult()
        {
            Debug.Assert(IsCompleted);
            if (!_taskAwaiter.IsCompleted)
            {
                _cancellationToken.ThrowIfCancellationRequested();
            }
            _taskAwaiter.GetResult();
        }

        private Action WrapContinuation(in Action originalContinuation)
            => _cancellationToken.CanBeCanceled
                ? new WithCancellationContinuationWrapper(originalContinuation, _cancellationToken).Continuation
                : originalContinuation;
    }

    /// <summary>
    /// An awaiter that adds cancellation support to a <see cref="Task{T}"/>.
    /// This awaiter will complete when either the task completes or the cancellation token is triggered.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    public readonly struct WithCancellationTaskAwaiter<T> : ICriticalNotifyCompletion
    {
        private readonly CancellationToken _cancellationToken;
        private readonly ConfiguredTaskAwaitable<T>.ConfiguredTaskAwaiter _taskAwaiter;

        /// <summary>
        /// Initializes a new instance of the <see cref="WithCancellationTaskAwaiter{T}"/> struct.
        /// </summary>
        /// <param name="awaiter">The task awaiter to wrap.</param>
        /// <param name="cancellationToken">The cancellation token to observe.</param>
        public WithCancellationTaskAwaiter(ConfiguredTaskAwaitable<T>.ConfiguredTaskAwaiter awaiter, CancellationToken cancellationToken)
        {
            _taskAwaiter = awaiter;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Gets a value indicating whether the awaitable has completed.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the task is completed or the cancellation token has been triggered; otherwise, <see langword="false"/>.
        /// </value>
        public bool IsCompleted => _taskAwaiter.IsCompleted || _cancellationToken.IsCancellationRequested;

        /// <summary>
        /// Schedules the continuation action that's invoked when the instance completes.
        /// </summary>
        /// <param name="continuation">The action to invoke when the operation completes.</param>
        public void OnCompleted(Action continuation) => _taskAwaiter.OnCompleted(WrapContinuation(continuation));

        /// <summary>
        /// Schedules the continuation action that's invoked when the instance completes.
        /// </summary>
        /// <param name="continuation">The action to invoke when the operation completes.</param>
        public void UnsafeOnCompleted(Action continuation) => _taskAwaiter.UnsafeOnCompleted(WrapContinuation(continuation));

        /// <summary>
        /// Ends the wait for the completion of the awaitable and returns the result.
        /// </summary>
        /// <returns>The result of the completed task.</returns>
        /// <exception cref="OperationCanceledException">
        /// Thrown if the cancellation token was triggered before the task completed.
        /// </exception>
        public T GetResult()
        {
            Debug.Assert(IsCompleted);
            if (!_taskAwaiter.IsCompleted)
            {
                _cancellationToken.ThrowIfCancellationRequested();
            }
            return _taskAwaiter.GetResult();
        }

        private Action WrapContinuation(in Action originalContinuation)
            => _cancellationToken.CanBeCanceled
                ? new WithCancellationContinuationWrapper(originalContinuation, _cancellationToken).Continuation
                : originalContinuation;
    }

    /// <summary>
    /// An awaiter that adds cancellation support to a <see cref="ValueTask{T}"/>.
    /// This awaiter will complete when either the value task completes or the cancellation token is triggered.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    public readonly struct WithCancellationValueTaskAwaiter<T> : ICriticalNotifyCompletion
    {
        private readonly CancellationToken _cancellationToken;
        private readonly ConfiguredValueTaskAwaitable<T>.ConfiguredValueTaskAwaiter _taskAwaiter;

        /// <summary>
        /// Initializes a new instance of the <see cref="WithCancellationValueTaskAwaiter{T}"/> struct.
        /// </summary>
        /// <param name="awaiter">The value task awaiter to wrap.</param>
        /// <param name="cancellationToken">The cancellation token to observe.</param>
        public WithCancellationValueTaskAwaiter(ConfiguredValueTaskAwaitable<T>.ConfiguredValueTaskAwaiter awaiter, CancellationToken cancellationToken)
        {
            _taskAwaiter = awaiter;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Gets a value indicating whether the awaitable has completed.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the value task is completed or the cancellation token has been triggered; otherwise, <see langword="false"/>.
        /// </value>
        public bool IsCompleted => _taskAwaiter.IsCompleted || _cancellationToken.IsCancellationRequested;

        /// <summary>
        /// Schedules the continuation action that's invoked when the instance completes.
        /// </summary>
        /// <param name="continuation">The action to invoke when the operation completes.</param>
        public void OnCompleted(Action continuation) => _taskAwaiter.OnCompleted(WrapContinuation(continuation));

        /// <summary>
        /// Schedules the continuation action that's invoked when the instance completes.
        /// </summary>
        /// <param name="continuation">The action to invoke when the operation completes.</param>
        public void UnsafeOnCompleted(Action continuation) => _taskAwaiter.UnsafeOnCompleted(WrapContinuation(continuation));

        /// <summary>
        /// Ends the wait for the completion of the awaitable and returns the result.
        /// </summary>
        /// <returns>The result of the completed value task.</returns>
        /// <exception cref="OperationCanceledException">
        /// Thrown if the cancellation token was triggered before the value task completed.
        /// </exception>
        public T GetResult()
        {
            Debug.Assert(IsCompleted);
            if (!_taskAwaiter.IsCompleted)
            {
                _cancellationToken.ThrowIfCancellationRequested();
            }
            return _taskAwaiter.GetResult();
        }

        private Action WrapContinuation(in Action originalContinuation)
            => _cancellationToken.CanBeCanceled
                ? new WithCancellationContinuationWrapper(originalContinuation, _cancellationToken).Continuation
                : originalContinuation;
    }

    /// <summary>
    /// A wrapper class that manages continuation callbacks for cancellation-aware awaitables.
    /// This class ensures that continuations are invoked exactly once, either when the task completes
    /// or when cancellation is requested.
    /// </summary>
    private class WithCancellationContinuationWrapper
    {
        private Action? _originalContinuation;
        private readonly CancellationTokenRegistration _registration;

        /// <summary>
        /// Initializes a new instance of the <see cref="WithCancellationContinuationWrapper"/> class.
        /// </summary>
        /// <param name="originalContinuation">The continuation to invoke when the operation completes or is cancelled.</param>
        /// <param name="cancellationToken">The cancellation token to observe.</param>
        public WithCancellationContinuationWrapper(Action originalContinuation, CancellationToken cancellationToken)
        {
            Action continuation = ContinuationImplementation;
            _originalContinuation = originalContinuation;
            _registration = cancellationToken.Register(continuation);
            Continuation = continuation;
        }

        /// <summary>
        /// Gets the continuation action that should be used by the awaiter.
        /// </summary>
        /// <value>The wrapped continuation action.</value>
        public Action Continuation { get; }

        /// <summary>
        /// The implementation of the continuation that ensures the original continuation is called exactly once.
        /// This method handles both task completion and cancellation scenarios.
        /// </summary>
        private void ContinuationImplementation()
        {
            Action? originalContinuation = Interlocked.Exchange(ref _originalContinuation, null);
            if (originalContinuation != null)
            {
                _registration.Dispose();
                originalContinuation();
            }
        }
    }
}
