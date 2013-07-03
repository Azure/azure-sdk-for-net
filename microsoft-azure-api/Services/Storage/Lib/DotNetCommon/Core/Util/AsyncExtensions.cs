//-----------------------------------------------------------------------
// <copyright file="AsyncExtensions.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

#if TASK
    /// <summary>
    /// Helper class to convert an APM method to a Task method.
    /// </summary>
    internal static class AsyncExtensions
    {
        private static CancellationTokenRegistration? RegisterCancellationToken(CancellationToken cancellationToken, out CancellableOperationBase cancellableOperation)
        {
            if (cancellationToken.CanBeCanceled)
            {
                cancellableOperation = new CancellableOperationBase();
                return cancellationToken.Register(cancellableOperation.Cancel);
            }

            cancellableOperation = null;
            return null;
        }

        private static void AssignCancellableOperation(CancellableOperationBase cancellableOperation, ICancellableAsyncResult asyncResult, CancellationToken cancellationToken)
        {
            if (cancellableOperation != null)
            {
                cancellableOperation.CancelDelegate = asyncResult.Cancel;

                if (cancellationToken.IsCancellationRequested)
                {
                    cancellableOperation.Cancel();
                }
            }
        }

        private static AsyncCallback CreateCallback<TResult>(TaskCompletionSource<TResult> taskCompletionSource, CancellationTokenRegistration? registration, Func<IAsyncResult, TResult> endMethod)
        {
            return ar =>
                {
                    try
                    {
                        if (registration.HasValue)
                        {
                            registration.Value.Dispose();
                        }

                        TResult result = endMethod(ar);
                        taskCompletionSource.TrySetResult(result);
                    }
                    catch (OperationCanceledException)
                    {
                        taskCompletionSource.TrySetCanceled();
                    }
                    catch (StorageException ex)
                    {
                        bool operationCanceled = false;

                        // Iterate through all inner exceptions to find an OperationCanceledException
                        for (Exception innerException = ex.InnerException; innerException != null; innerException = innerException.InnerException)
                        {
                            if (innerException is OperationCanceledException)
                            {
                                operationCanceled = true;
                                break;
                            }
                        }

                        if (operationCanceled)
                        {
                            taskCompletionSource.TrySetCanceled();
                        }
                        else
                        {
                            taskCompletionSource.TrySetException(ex);
                        }
                    }
                    catch (Exception ex)
                    {
                        taskCompletionSource.TrySetException(ex);
                    }
                };
        }

        private static AsyncCallback CreateCallbackVoid(TaskCompletionSource<object> taskCompletionSource, CancellationTokenRegistration? registration, Action<IAsyncResult> endMethod)
        {
            return ar =>
                {
                    try
                    {
                        if (registration.HasValue)
                        {
                            registration.Value.Dispose();
                        }

                        endMethod(ar);
                        taskCompletionSource.TrySetResult(null);
                    }
                    catch (OperationCanceledException)
                    {
                        taskCompletionSource.TrySetCanceled();
                    }
                    catch (StorageException ex)
                    {
                        bool operationCanceled = false;

                        // Iterate through all inner exceptions to find an OperationCanceledException
                        for (Exception innerException = ex.InnerException; innerException != null; innerException = innerException.InnerException)
                        {
                            if (innerException is OperationCanceledException)
                            {
                                operationCanceled = true;
                                break;
                            }
                        }

                        if (operationCanceled)
                        {
                            taskCompletionSource.TrySetCanceled();
                        }
                        else
                        {
                            taskCompletionSource.TrySetException(ex);
                        }
                    }
                    catch (Exception ex)
                    {
                        taskCompletionSource.TrySetException(ex);
                    }
                };
        }

        internal static Task TaskFromVoidApm(Func<AsyncCallback, object, ICancellableAsyncResult> beginMethod, Action<IAsyncResult> endMethod, CancellationToken cancellationToken)
        {
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(CreateCallbackVoid(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task TaskFromVoidApm<T1>(Func<T1, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Action<IAsyncResult> endMethod, T1 arg1, CancellationToken cancellationToken)
        {
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(arg1, CreateCallbackVoid(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task TaskFromVoidApm<T1, T2>(Func<T1, T2, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Action<IAsyncResult> endMethod, T1 arg1, T2 arg2, CancellationToken cancellationToken)
        {
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(arg1, arg2, CreateCallbackVoid(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task TaskFromVoidApm<T1, T2, T3>(Func<T1, T2, T3, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Action<IAsyncResult> endMethod, T1 arg1, T2 arg2, T3 arg3, CancellationToken cancellationToken)
        {
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(arg1, arg2, arg3, CreateCallbackVoid(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task TaskFromVoidApm<T1, T2, T3, T4>(Func<T1, T2, T3, T4, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Action<IAsyncResult> endMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, CancellationToken cancellationToken)
        {
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(arg1, arg2, arg3, arg4, CreateCallbackVoid(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task TaskFromVoidApm<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Action<IAsyncResult> endMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, CancellationToken cancellationToken)
        {
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(arg1, arg2, arg3, arg4, arg5, CreateCallbackVoid(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task TaskFromVoidApm<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Action<IAsyncResult> endMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, CancellationToken cancellationToken)
        {
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(arg1, arg2, arg3, arg4, arg5, arg6, CreateCallbackVoid(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task TaskFromVoidApm<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Action<IAsyncResult> endMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, CancellationToken cancellationToken)
        {
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(arg1, arg2, arg3, arg4, arg5, arg6, arg7, CreateCallbackVoid(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task<TResult> TaskFromApm<TResult>(Func<AsyncCallback, object, ICancellableAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, CancellationToken cancellationToken)
        {
            TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(CreateCallback(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task<TResult> TaskFromApm<T1, TResult>(Func<T1, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, T1 arg1, CancellationToken cancellationToken)
        {
            TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(arg1, CreateCallback(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task<TResult> TaskFromApm<T1, T2, TResult>(Func<T1, T2, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, T1 arg1, T2 arg2, CancellationToken cancellationToken)
        {
            TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(arg1, arg2, CreateCallback(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task<TResult> TaskFromApm<T1, T2, T3, TResult>(Func<T1, T2, T3, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, T1 arg1, T2 arg2, T3 arg3, CancellationToken cancellationToken)
        {
            TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(arg1, arg2, arg3, CreateCallback(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task<TResult> TaskFromApm<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, CancellationToken cancellationToken)
        {
            TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(arg1, arg2, arg3, arg4, CreateCallback(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task<TResult> TaskFromApm<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, CancellationToken cancellationToken)
        {
            TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(arg1, arg2, arg3, arg4, arg5, CreateCallback(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task<TResult> TaskFromApm<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, CancellationToken cancellationToken)
        {
            TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(arg1, arg2, arg3, arg4, arg5, arg6, CreateCallback(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }

        internal static Task<TResult> TaskFromApm<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, AsyncCallback, object, ICancellableAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, CancellationToken cancellationToken)
        {
            TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
            }
            else
            {
                CancellableOperationBase cancellableOperation;
                CancellationTokenRegistration? registration = RegisterCancellationToken(cancellationToken, out cancellableOperation);
                ICancellableAsyncResult result = beginMethod(arg1, arg2, arg3, arg4, arg5, arg6, arg7, CreateCallback(taskCompletionSource, registration, endMethod), null /* state */);
                AssignCancellableOperation(cancellableOperation, result, cancellationToken);
            }

            return taskCompletionSource.Task;
        }
    }
#endif
}
