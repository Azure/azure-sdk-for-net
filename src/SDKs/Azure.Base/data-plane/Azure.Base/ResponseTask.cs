// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Threading;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Azure
{
    [AsyncMethodBuilder(typeof(AsyncResponseTaskMethodBuilder<>))]
    public struct ResponseTask<T>
    {
        private readonly Task<T> _parent;

        public ResponseTask(Task<T> parent, Response response)
        {
            _parent = parent;
            Response = response;
        }

        public ResponseTask(Task<T> parent) : this(parent, default) { }
               
        public T Result => _parent.Result;

        public Response Response { get; set; }

        public TaskAwaiter<T> GetAwaiter() => _parent.GetAwaiter();

        public ConfiguredTaskAwaitable<T> ConfigureAwait(bool continueOnCapturedContext) 
            => _parent.ConfigureAwait(continueOnCapturedContext);

        public static implicit operator Task<T>(ResponseTask<T> t) => t._parent;
    }

    public static class ResponseTask
    {
        public static ResponseTask<T> FromResult<T>(T result, Response response)
            => new ResponseTask<T>(Task.FromResult(result), response);

        public static async ResponseTask<T> Await<T>(this ResponseTask<T> task)
        {
            var result = await task;
            return await FromResult(result, task.Response);
        }
    }
}

namespace Azure.Base.Threading { 

    public struct AsyncResponseTaskMethodBuilder<T>
    {
        private AsyncTaskMethodBuilder<T> _methodBuilder;

        public static AsyncResponseTaskMethodBuilder<T> Create() => default;

        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine => _methodBuilder.Start(ref stateMachine);

        public void SetStateMachine(IAsyncStateMachine stateMachine) => _methodBuilder.SetStateMachine(stateMachine);

        public void SetResult(T result) => _methodBuilder.SetResult(result);

        public void SetException(Exception exception) => _methodBuilder.SetException(exception);

        public ResponseTask<T> Task => new ResponseTask<T>(_methodBuilder.Task);

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine => _methodBuilder.AwaitOnCompleted(ref awaiter, ref stateMachine);

        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine => _methodBuilder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
    }
}
