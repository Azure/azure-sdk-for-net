// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Azure.Core.TestFramework
{
    internal class InstrumentResultInterceptor : IInterceptor
    {
        private static readonly MethodInfo InstrumentOperationInterceptorMethodInfo = typeof(InstrumentResultInterceptor)
            .GetMethod(nameof(InstrumentOperationInterceptor), BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new InvalidOperationException("Unable to find InstrumentOperationInterceptor method");

        private readonly ClientTestBase _testBase;
        private readonly RecordedTestMode _testMode;

        public InstrumentResultInterceptor(ClientTestBase testBase)
        {
            _testBase = testBase;
            // non-recorded tests are treated like Playback mode
            _testMode = testBase is RecordedTestBase recordedTestBase ? recordedTestBase.Mode : RecordedTestMode.Playback;
        }

        public void Intercept(IInvocation invocation)
        {
            var type = invocation.Method.ReturnType;

            // We don't want to instrument generated rest clients.
            if (IsInstrumentableClientType(invocation))
            {
                if (IsNullResult(invocation))
                    return;

                invocation.ReturnValue = _testBase.InstrumentClient(type, invocation.ReturnValue, Array.Empty<IInterceptor>());
                return;
            }

            if (
                // Generated ARM clients will have a property containing the sub-client that ends with Operations.
                (invocation.Method.Name.StartsWith("get_") && ManagementInterceptor.InheritsFromArmResource(type)) ||
                // Instrument the container construction methods inside Operations objects
                // Instrument the operations construction methods inside Operations objects
                (invocation.Method.Name.StartsWith("Get") && ManagementInterceptor.InheritsFromArmResource(type)))
            {
                if (IsNullResult(invocation))
                    return;

                invocation.ReturnValue = _testBase.InstrumentClient(type, invocation.ReturnValue, new IInterceptor[] { new ManagementInterceptor(_testBase) });
                return;
            }

            if (type is {IsGenericType: true, GenericTypeArguments: {} arguments } &&
                type.GetGenericTypeDefinition() == typeof(Task<>) &&
                typeof(Operation).IsAssignableFrom(arguments[0]))
            {
                bool swappedWaitUntilArg = false;
                WaitUntil? current = invocation.Arguments[0] as WaitUntil?;

                // We swap out WaitUntil.Completed for WaitUntil.Started when in Playback because otherwise the operation
                // would not be instrumented when WaitForCompletion is called on it, which would mean that
                // the zero polling strategy wouldn't be used.
                if (current == WaitUntil.Completed && _testMode == RecordedTestMode.Playback)
                {
                    swappedWaitUntilArg = true;
                    invocation.Arguments[0] = WaitUntil.Started;
                }

                // This will asynchronously invoke the operation and instrument it.
                DiagnosticScopeValidatingInterceptor.WrapAsyncResult(invocation, this, InstrumentOperationInterceptorMethodInfo);

                // if we swapped out WaitUntil.Completed, we now will need to call WaitForCompletion.
                if (swappedWaitUntilArg)
                {
                    if (TaskExtensions.IsTaskFaulted(invocation.ReturnValue))
                        return;

                    object lro = TaskExtensions.GetResultFromTask(invocation.ReturnValue);
                    CancellationToken token = invocation.Arguments.Last() switch
                    {
                        RequestContext requestContext => requestContext.CancellationToken,
                        CancellationToken cancellationToken => cancellationToken,
                        _ => CancellationToken.None
                    };
                    var valueTask = lro.GetType().BaseType.IsGenericType
                        ? OperationInterceptor.InvokeWaitForCompletion(lro, lro.GetType(), token)
                        : OperationInterceptor.InvokeWaitForCompletionResponse(lro as Operation, token);
                    _ = TaskExtensions.GetResultFromTask(valueTask);
                }
                return;
            }

            invocation.Proceed();
        }

        private static bool IsInstrumentableClientType(IInvocation invocation)
        {
            var type = invocation.Method.ReturnType;
            // We don't want to instrument generated rest clients or extension clients
            if (type.Name.EndsWith("RestClient") || type.Name.EndsWith("ExtensionClient"))
            {
                return false;
            }

            if (type.Name.EndsWith("Client"))
            {
                return true;
            }

            // Skip system types
            if (type.Name.StartsWith("System."))
            {
                return false;
            }

            //TODO: remove after all track2 .net mgmt libraries are updated to the new generation
            if (invocation.Method.Name.StartsWith("get_") && type.Name.EndsWith("Operations"))
            {
                return true;
            }

            // Some libraries have subclients that do not end with Client. Instrument any type that has a Pipeline property.
            // This is the most expensive check so we do it last.
            return type.GetProperty("Pipeline") != null;
        }

        internal async ValueTask<T> InstrumentOperationInterceptor<T>(IInvocation invocation, Func<ValueTask<T>> innerTask)
        {
            return (T) _testBase.InstrumentOperation(typeof(T), await innerTask());
        }

        private bool IsNullResult(IInvocation invocation)
        {
            invocation.Proceed();
            return invocation.ReturnValue == null;
        }
    }
}
