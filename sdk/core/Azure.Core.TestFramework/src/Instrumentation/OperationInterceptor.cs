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
        private static readonly object NoWaitDelay = TimeSpan.Zero;
        internal static readonly string WaitForCompletionMethodName = nameof(Operation<object>.WaitForCompletionAsync);
        internal static readonly MethodInfo WaitForCompletionResponseAsync = typeof(Operation).GetMethod(nameof(Operation.WaitForCompletionResponseAsync), new[] { typeof(TimeSpan), typeof(CancellationToken) });

        internal static readonly string PollerWaitForCompletionAsyncName = nameof(OperationPoller.WaitForCompletionAsync);

        private readonly RecordedTestMode _mode;

        public OperationInterceptor(RecordedTestMode mode)
        {
            _mode = mode;
        }

        public void Intercept(IInvocation invocation)
        {
            if (_mode == RecordedTestMode.Playback)
            {
                if (invocation.Method.Name == WaitForCompletionMethodName)
                {
                    CheckArguments(invocation.Arguments);
                    invocation.ReturnValue = InvokeWaitForCompletion(invocation.InvocationTarget, invocation.TargetType, (CancellationToken)invocation.Arguments.Last());
                    return;
                }

                if (invocation.Method.Name == WaitForCompletionResponseAsync.Name)
                {
                    CheckArguments(invocation.Arguments);
                    invocation.ReturnValue = InvokeWaitForCompletionResponse(invocation.InvocationTarget as Operation, (CancellationToken)invocation.Arguments.Last());
                    return;
                }
            }

            invocation.Proceed();
        }

        internal static object InvokeWaitForCompletionResponse(Operation operation, CancellationToken cancellationToken)
        {
            return InjectZeroPoller().WaitForCompletionResponseAsync(operation, null, cancellationToken);
        }

        internal static object InvokeWaitForCompletion(object target, Type targetType, CancellationToken cancellationToken)
        {
            // get the concrete instance of OperationPoller.ValueTask<Response<T>> WaitForCompletionAsync<T>(Operation<T>, TimeSpan?, CancellationToken)
            var poller = InjectZeroPoller();
            var genericMethod = poller.GetType().GetMethods().Where(m => m.Name == PollerWaitForCompletionAsyncName).FirstOrDefault(m => m.GetParameters().Length == 3);
            var method = genericMethod.MakeGenericMethod(GetOperationOfT(targetType).GetGenericArguments());

            return method.Invoke(InjectZeroPoller(), new object[] { target, null, cancellationToken});
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

        private static OperationPoller InjectZeroPoller()
        {
            OperationPoller poller = new OperationPoller();
            poller.GetType().GetField("_delayStrategy", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(poller, new ZeroPollingStrategy());
            return poller;
        }

        private static Type GetOperationOfT(Type type)
        {
            while (type != null && type.Name != typeof(Operation<object>).Name)
            {
                type = type.BaseType;
            }
            return type;
        }
    }
}
