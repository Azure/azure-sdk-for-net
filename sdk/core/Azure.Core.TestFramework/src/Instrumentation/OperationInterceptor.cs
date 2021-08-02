// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading;
using Castle.DynamicProxy;

namespace Azure.Core.TestFramework
{
    internal class OperationInterceptor : IInterceptor
    {
        private static readonly object NoWaitDelay = TimeSpan.Zero;
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
                    CheckArguments(invocation.Arguments);
                    var cancellationToken = invocation.Arguments.Last();
                    var waitForCompletionMethod = invocation.TargetType.GetMethod(WaitForCompletionMethodName, new[]{typeof(TimeSpan), typeof(CancellationToken)});
                    try
                    {
                        invocation.ReturnValue = waitForCompletionMethod.Invoke(invocation.InvocationTarget, new[] {NoWaitDelay, cancellationToken});
                    }
                    catch (TargetInvocationException ex)
                    {
                        ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                    }
                    return;
                }

                if (invocation.Method.Name == WaitForCompletionResponseAsync.Name)
                {
                    CheckArguments(invocation.Arguments);
                    var cancellationToken = invocation.Arguments.Last();
                    try
                    {
                        invocation.ReturnValue = WaitForCompletionResponseAsync.Invoke(invocation.InvocationTarget, new[] {NoWaitDelay, cancellationToken});
                    }
                    catch (TargetInvocationException ex)
                    {
                        ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                    }
                    return;
                }
            }

            invocation.Proceed();
        }

        private void CheckArguments(object[] invocationArguments)
        {
            if (invocationArguments.Length == 2)
            {
                var interval = (TimeSpan) invocationArguments[0];
                if (interval < TimeSpan.FromSeconds(1))
                {
                    throw new InvalidOperationException($"Fast polling interval of {interval} detected in playback mode. " +
                                                        $"Please use the default WaitForCompletion(). " +
                                                        $"The test framework would automatically reduce the interval in playback.");
                }
            }
        }
    }
}
