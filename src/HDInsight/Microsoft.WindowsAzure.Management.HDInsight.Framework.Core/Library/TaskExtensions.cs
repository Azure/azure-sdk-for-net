// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides useful extensions to task when working in a NetFx 4.0 environment.
    /// </summary>
#if Non_Public_SDK
    public static class TaskExtensions
#else
    internal static class TaskExtensions
#endif
    {
        internal static Exception GetInnerException(this AggregateException aggregateException)
        {
            Exception innerExcception = aggregateException;
            while (aggregateException is AggregateException)
            {
                innerExcception = aggregateException.InnerExceptions[0];
                aggregateException = innerExcception.As<AggregateException>();
                if (aggregateException.IsNull())
                {
                    break;
                }
            }
            return innerExcception;
        }

        /// <summary>
        /// Waits for the task to complete.  This works for tasks that
        /// have no return values.  As such, this name is misleading but correct
        /// from a consistency standpoint because all Wait request should use this
        /// to ensure proper processing of exceptions.
        /// </summary>
        /// <param name="task">
        /// The task parameter.
        /// </param>
        /// <param name="timeout">
        /// The timeout period to wait.
        /// </param>
        public static void WaitForResult(this Task task, TimeSpan timeout)
        {
            if (task.IsNull())
            {
                throw new ArgumentNullException("task");
            }
            try
            {
                task.Wait(timeout);
            }
            catch (AggregateException aggregateException)
            {
                var ie = GetInnerException(aggregateException);
                typeof(Exception).GetMethod("PrepForRemoting", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(ie, new object[0]);
                throw ie;
            }
            if (task.Status != TaskStatus.RanToCompletion && task.Status != TaskStatus.Faulted && task.Status != TaskStatus.Canceled)
            {
                throw new TimeoutException(string.Format(CultureInfo.InvariantCulture, "The requested task failed to complete in the allotted time ({0}).", timeout));
            }
        }

        /// <summary>
        /// Waits for the task to complete.  This works for tasks that
        /// have no return values.  As such, this name is misleading but correct
        /// from a consistency standpoint because all Wait request should use this
        /// to ensure proper processing of exceptions.
        /// </summary>
        /// <param name="task">
        /// The task parameter.
        /// </param>
        public static void WaitForResult(this Task task)
        {
            WaitForResult(task, new TimeSpan(0, 0, 0, 0, int.MaxValue));
        }

        /// <summary>
        /// Waits for the task to complete and then returns the result.
        /// </summary>
        /// <typeparam name="T">
        /// The type of return value for the task.
        /// </typeparam>
        /// <param name="task">
        /// The task parameter.
        /// </param>
        /// <returns>
        /// The result of the task execution.
        /// </returns>
        public static T WaitForResult<T>(this Task<T> task)
        {
            return WaitForResult(task, new TimeSpan(0, 0, 0, 0, int.MaxValue));
        }

        /// <summary>
        /// Waits for the task to complete for a given timeout and then returns the result.
        /// </summary>
        /// <typeparam name="T">
        /// The type of return value for the task.
        /// </typeparam>
        /// <param name="task">
        /// The task parameter.
        /// </param>
        /// <param name="timeout">
        /// The timeout period to wait.
        /// </param>
        /// <returns>
        /// The result of the task execution.
        /// </returns>
        public static T WaitForResult<T>(this Task<T> task, TimeSpan timeout)
        {
            if (task.IsNull())
            {
                throw new ArgumentNullException("task");
            }
            try
            {
                task.Wait(timeout);
            }
            catch (AggregateException aggregateException)
            {
                var ie = GetInnerException(aggregateException);
                typeof(Exception).GetMethod("PrepForRemoting", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(ie, new object[0]);
                throw ie;
            }
            if (task.Status != TaskStatus.RanToCompletion && task.Status != TaskStatus.Faulted && task.Status != TaskStatus.Canceled)
            {
                throw new TimeoutException(string.Format(CultureInfo.InvariantCulture, "The requested task failed to complete in the allotted time ({0}).", timeout));
            }
            return task.Result;
        }

        /// <summary>
        /// Performs a conversion from one task type to another.
        /// </summary>
        /// <typeparam name="TOriginalReturnType">
        /// The original task return type.
        /// </typeparam>
        /// <typeparam name="TNewReturnType">
        /// The new task return type.
        /// </typeparam>
        /// <param name="task">
        /// The task to execute.
        /// </param>
        /// <param name="timeout">
        /// A time out period to wait for the task execution.
        /// </param>
        /// <param name="convert">
        /// The conversion method that performs the conversion.
        /// </param>
        /// <returns>
        /// A new task that will execute the conversion with the original task 
        /// is completed.
        /// </returns>
        public static Task<TNewReturnType> AsyncConvert<TOriginalReturnType, TNewReturnType>(this Task<TOriginalReturnType> task, TimeSpan timeout, Func<TOriginalReturnType, TNewReturnType> convert)
        {
            if (task.IsNull())
            {
                throw new ArgumentNullException("task");
            }
            if (convert.IsNull())
            {
                throw new ArgumentNullException("convert");
            }

            Task<TNewReturnType> retval = null;
            try
            {
                retval = Help.SafeCreate(() => new Task<TNewReturnType>(() => convert(task.WaitForResult(timeout))));
                retval.Start();
                return retval;
            }
            catch (Exception)
            {
                if (retval.IsNotNull())
                {
                    retval.Dispose();
                }
                throw;
            }
        }
    }
}
