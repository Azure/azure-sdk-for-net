// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core.Tests;
using Castle.DynamicProxy;

namespace Azure.Core.Testing
{
    public class DiagnosticScopeValidatingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;
            if (methodName.EndsWith("Async"))
            {
                Type declaringType = invocation.Method.DeclaringType;
                var ns = declaringType.Namespace;
                var expectedEventPrefix = declaringType.FullName + "." + methodName.Substring(0, methodName.Length - 5);
                var expectedEvents = new List<string>
                {
                    expectedEventPrefix + ".Start"
                };

                using TestDiagnosticListener diagnosticListener = new TestDiagnosticListener(s => s.Name.StartsWith("Azure."));
                invocation.Proceed();

                bool strict = !invocation.Method.GetCustomAttributes(true).Any(a => a.GetType().FullName == "Azure.Core.ForwardsClientCallsAttribute");
                if (invocation.Method.ReturnType.Name.Contains("Pageable") ||
                    invocation.Method.ReturnType.Name.Contains("IAsyncEnumerable"))
                {
                    return;
                }

                try
                {
                    object returnValue = invocation.ReturnValue;
                    if (returnValue is Task t)
                    {
                        t.GetAwaiter().GetResult();
                    }
                    else
                    {
                        // Await ValueTask
                        Type returnType = returnValue.GetType();
                        MethodInfo getAwaiterMethod = returnType.GetMethod("GetAwaiter", BindingFlags.Instance | BindingFlags.Public);
                        MethodInfo getResultMethod = getAwaiterMethod.ReturnType.GetMethod("GetResult", BindingFlags.Instance | BindingFlags.Public);

                        getResultMethod.Invoke(
                            getAwaiterMethod.Invoke(returnValue, Array.Empty<object>()),
                            Array.Empty<object>());

                    }

                    expectedEvents.Add(expectedEventPrefix + ".Stop");
                }
                catch (Exception ex)
                {
                    expectedEvents.Add(expectedEventPrefix + ".Exception");

                    if (ex is ArgumentException)
                    {
                        // Don't expect scope for argument validation failures
                        expectedEvents.Clear();
                    }
                }
                finally
                {
                    if (strict)
                    {
                        foreach (var expectedEvent in expectedEvents)
                        {
                            (string Key, object Value, DiagnosticListener Listener) e = diagnosticListener.Events.FirstOrDefault(e => e.Key == expectedEvent);

                            if (e == default)
                            {
                                throw new InvalidOperationException($"Expected diagnostic event not fired {expectedEvent} {Environment.NewLine}    fired events {string.Join(", ", diagnosticListener.Events)} {Environment.NewLine}    You may have forgotten to set your operationId to {expectedEvent} in {methodName} or applied the Azure.Core.ForwardsClientCallsAttribute to {methodName}.");
                            }

                            if (!ns.StartsWith(e.Listener.Name))
                            {
                                throw new InvalidOperationException($"{e.Key} event was written into wrong DiagnosticSource {e.Listener.Name}, expected: {ns}");
                            }
                        }
                    }
                    else
                    {
                        if (!diagnosticListener.Events.Any())
                        {
                            throw new InvalidOperationException($"Expected some diagnostic event to fire found none");
                        }
                    }
                }
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}
