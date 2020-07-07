// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class TaskMethodInvoker<TReflected, TReturnType> : IMethodInvoker<TReflected, TReturnType>
    {
        private readonly Func<TReflected, object[], Task<TReturnType>> _lambda;

        public TaskMethodInvoker(Func<TReflected, object[], Task<TReturnType>> lambda)
        {
            _lambda = lambda;
        }

        public Task<TReturnType> InvokeAsync(TReflected instance, object[] arguments)
        {
            Task<TReturnType> task = _lambda.Invoke(instance, arguments);
            ThrowIfWrappedTaskInstance(task);
            return task;
        }

        private static void ThrowIfWrappedTaskInstance(Task task)
        {
            if (task == null)
            {
                return;
            }

            Type taskType = task.GetType();
            Debug.Assert(taskType != null);

            Type innerTaskType = GetTaskInnerTypeOrNull(taskType);

            if (innerTaskType != null && typeof(Task).IsAssignableFrom(innerTaskType))
            {
                throw new InvalidOperationException("Returning a nested Task is not supported. Did you mean to await " +
                    "or Unwrap the task instead of returning it?");
            }
        }

        private static Type GetTaskInnerTypeOrNull(Type taskType)
        {
            Debug.Assert(taskType != null);

            // Fast path: check if type is exactly Task first.
            if (taskType == typeof(Task))
            {
                return null;
            }

            // Secondary check: static Task methods sometimes return nested Task types which
            // fail the first check, but aren't generic types and throw an exception below.
            if (!taskType.IsGenericType)
            {
                return null;
            }

            Debug.Assert(taskType.IsGenericType);
            Debug.Assert(!taskType.IsGenericTypeDefinition);

            // verify that the generic type is a Task
            Type genericTypeDefinition = taskType.GetGenericTypeDefinition();
            Debug.Assert(typeof(Task).IsAssignableFrom(genericTypeDefinition));

            return taskType.GetGenericArguments()[0];
        }
    }
}
