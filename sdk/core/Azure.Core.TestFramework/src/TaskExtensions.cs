// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.TestFramework
{
    public static class TaskExtensions
    {
        public static TimeSpan DefaultTimeout { get; } = TimeSpan.FromSeconds(10);

        public static Task<T> TimeoutAfterDefault<T>(this Task<T> task,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            return task.TimeoutAfter(DefaultTimeout, filePath, lineNumber);
        }

        public static Task TimeoutAfterDefault(this Task task,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            return task.TimeoutAfter(DefaultTimeout, filePath, lineNumber);
        }

        public static ValueTask<T> TimeoutAfterDefault<T>(this ValueTask<T> task,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            return task.TimeoutAfter(DefaultTimeout, filePath, lineNumber);
        }

        public static ValueTask TimeoutAfterDefault(this ValueTask task,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            return task.TimeoutAfter(DefaultTimeout, filePath, lineNumber);
        }

        public static async Task<T> TimeoutAfter<T>(this Task<T> task, TimeSpan timeout,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            // Don't create a timer if the task is already completed
            // or the debugger is attached
            if (task.IsCompleted || Debugger.IsAttached)
            {
                return await task;
            }

            var cts = new CancellationTokenSource();
            if (task == await Task.WhenAny(task, Task.Delay(timeout, cts.Token)))
            {
                cts.Cancel();
                return await task;
            }
            else
            {
                throw new TimeoutException(CreateMessage(timeout, filePath, lineNumber));
            }
        }

        public static async Task TimeoutAfter(this Task task, TimeSpan timeout,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            // Don't create a timer if the task is already completed
            // or the debugger is attached
            if (task.IsCompleted || Debugger.IsAttached)
            {
                await task;
                return;
            }

            var cts = new CancellationTokenSource();
            if (task == await Task.WhenAny(task, Task.Delay(timeout, cts.Token)))
            {
                cts.Cancel();
                await task;
            }
            else
            {
                throw new TimeoutException(CreateMessage(timeout, filePath, lineNumber));
            }
        }

        public static ValueTask<T> TimeoutAfter<T>(this ValueTask<T> task, TimeSpan timeout,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            return new(TimeoutAfter(task.AsTask(), timeout, filePath, lineNumber));
        }

        public static ValueTask TimeoutAfter(this ValueTask task, TimeSpan timeout,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = default)
        {
            return new(TimeoutAfter(task.AsTask(), timeout, filePath, lineNumber));
        }

        private static string CreateMessage(TimeSpan timeout, string filePath, int lineNumber)
            => string.IsNullOrEmpty(filePath)
                ? $"The operation timed out after reaching the limit of {timeout.TotalMilliseconds}ms."
                : $"The operation at {filePath}:{lineNumber} timed out after reaching the limit of {timeout.TotalMilliseconds}ms.";

        public static bool IsTaskFaulted(object taskObj)
        {
            return (bool)taskObj.GetType().GetProperty("IsFaulted").GetValue(taskObj);
        }

        public static object GetResultFromTask(object returnValue)
        {
            try
            {
                Type returnType = returnValue.GetType();
                return IsTaskType(returnType)
                    ? returnType.GetProperty("Result").GetValue(returnValue)
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
                    throw e.InnerException;
                }
            }
        }

        public static bool IsTaskType(Type type)
        {
            string name = type.Name;
            return name.StartsWith("ValueTask", StringComparison.Ordinal) ||
                   name.StartsWith("Task", StringComparison.Ordinal) ||
                   name.StartsWith("AsyncStateMachineBox", StringComparison.Ordinal); //in .net 5 the type is not task here
        }

        public static object GetValueFromTask(Type taskResultType, object instrumentedResult)
        {
            var method = typeof(Task).GetMethod("FromResult", BindingFlags.Public | BindingFlags.Static);
            var genericMethod = method.MakeGenericMethod(taskResultType);
            return genericMethod.Invoke(null, new object[] { instrumentedResult });
        }
    }
}
