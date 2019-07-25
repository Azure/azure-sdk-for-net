// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
                var expectedEventPrefix = invocation.Method.DeclaringType.FullName + "." + methodName.Substring(0, methodName.Length - 5);
                var expectedEvents = new List<string>();
                expectedEvents.Add(expectedEventPrefix + ".Start");

                TestDiagnosticListener diagnosticListener = new TestDiagnosticListener("Azure.Clients");
                invocation.Proceed();

                bool strict = !invocation.Method.GetCustomAttributes(true).Any(a => a.GetType().FullName == "Azure.Core.ForwardsClientCallsAttribute");
                if (invocation.Method.ReturnType.Name.Contains("AsyncCollection") ||
                    invocation.Method.ReturnType.Name.Contains("IAsyncEnumerable"))
                {
                    return;
                }

                var result = (Task)invocation.ReturnValue;
                try
                {
                    result.GetAwaiter().GetResult();
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
                    diagnosticListener.Dispose();
                    if (strict)
                    {
                        foreach (var expectedEvent in expectedEvents)
                        {
                            if (!diagnosticListener.Events.Any(e => e.Key == expectedEvent))
                            {
                                throw new InvalidOperationException($"Expected diagnostic event not fired {expectedEvent} {Environment.NewLine}    fired events {string.Join(", ", diagnosticListener.Events)}");
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
