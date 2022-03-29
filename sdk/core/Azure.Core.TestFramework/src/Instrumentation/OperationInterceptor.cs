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
            var genericMethod = poller.GetType().GetMethods().Where(m => m.Name == PollerWaitForCompletionAsyncName).FirstOrDefault(m => m.GetParameters().Length == 6);
            var method = genericMethod.MakeGenericMethod(GetOperationOfT(targetType).GetGenericArguments());

            var methodParams = method.GetParameters();
            var updateStatus = Delegate.CreateDelegate(methodParams[0].ParameterType, target, targetType.GetMethod("UpdateStatusAsync"));
            var hasCompleted = Delegate.CreateDelegate(methodParams[1].ParameterType, target, targetType.GetMethod("get_HasCompleted"));
            var value = Delegate.CreateDelegate(methodParams[2].ParameterType, target, targetType.GetMethod("get_Value"));
            var getResponse = Delegate.CreateDelegate(methodParams[3].ParameterType, target, targetType.GetMethod("GetRawResponse"));
            //need to call the method that takes in the delegates so we used the runtime versions which allows mocking
            //public virtual async ValueTask<Response<T>> WaitForCompletionAsync<T>(UpdateStatusAsync updateStatusAsync, HasCompleted hasCompleted, Value<T> value, GetRawResponse getRawResponse, TimeSpan? suggestedInterval, CancellationToken cancellationToken)
            return method.Invoke(poller, new object[] { updateStatus, hasCompleted, value, getResponse, null, cancellationToken});
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
