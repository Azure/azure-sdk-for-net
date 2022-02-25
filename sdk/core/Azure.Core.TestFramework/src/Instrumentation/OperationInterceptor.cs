﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        internal static readonly string WaitForCompletionMethodName = nameof(Operation<object>.WaitForCompletionAsync);
        internal static readonly MethodInfo WaitForCompletionResponseAsync = typeof(Operation).GetMethod(nameof(Operation.WaitForCompletionResponseAsync), new[] { typeof(TimeSpan), typeof(CancellationToken) });

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
                    Operation<object> operation = invocation.InvocationTarget as Operation<object>;
                    invocation.ReturnValue = GetZeroPoller(operation).WaitForCompletionAsync(operation, null, default);
                    return;
                }

                if (invocation.Method.Name == WaitForCompletionResponseAsync.Name)
                {
                    CheckArguments(invocation.Arguments);
                    Operation operation = invocation.InvocationTarget as Operation;
                    invocation.ReturnValue = GetZeroPoller(operation).WaitForCompletionResponseAsync(operation, null, default);
                    return;
                }
            }

            invocation.Proceed();
        }

        internal static object InvokeWaitForCompletionResponse(Operation operation, CancellationToken cancellationToken)
        {
            return GetZeroPoller(operation).WaitForCompletionResponseAsync(operation, null, (CancellationToken)cancellationToken);
        }

        internal static object InvokeWaitForCompletion(Operation<object> operation, CancellationToken cancellationToken)
        {
            return GetZeroPoller(operation).WaitForCompletionAsync(operation, null, (CancellationToken)cancellationToken);
        }

        private void CheckArguments(object[] invocationArguments)
        {
            if (invocationArguments.Length == 2)
            {
                var interval = (TimeSpan)invocationArguments[0];
                if (interval < TimeSpan.FromSeconds(1))
                {
                    throw new InvalidOperationException($"Fast polling interval of {interval} detected in playback mode. " +
                                                        $"Please use the default WaitForCompletion(). " +
                                                        $"The test framework would automatically reduce the interval in playback.");
                }
            }
        }

        private static OperationPoller GetZeroPoller(object operation)
        {
            OperationPoller poller = new OperationPoller();
            poller.GetType().GetField("_delayStrategy", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(poller, new ZeroPollingStrategy());
            return poller;
        }
    }
}
