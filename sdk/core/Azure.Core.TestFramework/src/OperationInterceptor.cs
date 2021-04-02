// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using Castle.DynamicProxy;

namespace Azure.Core.TestFramework
{
    internal class OperationInterceptor : IInterceptor
    {
        private static readonly object NoWaitDelay = TimeSpan.FromMilliseconds(1);
        private static readonly string WaitForCompletionMethodName = nameof(Operation<object>.WaitForCompletionAsync);
        private static readonly MethodInfo WaitForCompletionResponseAsync = typeof(Operation).GetMethod(nameof(Operation.WaitForCompletionResponseAsync), new[]{typeof(TimeSpan), typeof(CancellationToken)});

        private readonly bool _noWait;

        public OperationInterceptor(bool noWait)
        {
            _noWait = noWait;
        }

        public void Intercept(IInvocation invocation)
        {
            if (_noWait)
            {
                if (invocation.Method.Name == WaitForCompletionMethodName)
                {
                    var cancellationToken = invocation.Arguments.Last();
                    var waitForCompletionMethod = invocation.TargetType.GetMethod(WaitForCompletionMethodName, new[]{typeof(TimeSpan), typeof(CancellationToken)});
                    invocation.ReturnValue = waitForCompletionMethod.Invoke(invocation.InvocationTarget, new[] {NoWaitDelay, cancellationToken});
                    return;
                }

                if (invocation.Method.Name == WaitForCompletionResponseAsync.Name)
                {
                    var cancellationToken = invocation.Arguments.Last();
                    invocation.ReturnValue = WaitForCompletionResponseAsync.Invoke(invocation.InvocationTarget, new[] {NoWaitDelay, cancellationToken});
                    return;
                }
            }

            invocation.Proceed();
        }
    }
}