// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core.Tests;
using Castle.DynamicProxy;

namespace Azure.Core.TestFramework
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
                var expectedName = declaringType.Name + "." + methodName.Substring(0, methodName.Length - 5);
                using ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure."));
                invocation.Proceed();

                bool expectFailure = false;
                bool skipChecks = false;

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
                }
                catch (Exception ex)
                {
                    expectFailure = true;

                    if (ex is ArgumentException)
                    {
                        // Don't expect scope for argument validation failures
                        skipChecks = true;
                    }
                }
                finally
                {
                    // Remove subscribers before enumerating events.
                    diagnosticListener.Dispose();
                    if (!skipChecks)
                    {
                        if (strict)
                        {
                            ClientDiagnosticListener.ProducedDiagnosticScope e = diagnosticListener.Scopes.FirstOrDefault(e => e.Name == expectedName);

                            if (e == default)
                            {
                                throw new InvalidOperationException($"Expected diagnostic scope not created {expectedName} {Environment.NewLine}    created scopes {string.Join(", ", diagnosticListener.Scopes)} {Environment.NewLine}    You may have forgotten to set your operationId to {expectedName} in {methodName} or applied the Azure.Core.ForwardsClientCallsAttribute to {methodName}.");
                            }

                            if (!e.Activity.Tags.Any(tag => tag.Key == "az.namespace"))
                            {
                                throw new InvalidOperationException($"All diagnostic scopes should have 'az.namespace' attribute, make sure the assembly containing **ClientOptions type is marked with the AzureResourceProviderNamespace attribute specifying the appropriate provider. This attribute should be included in AssemblyInfo, and can be included by pulling in AzureResourceProviderNamespaceAttribute.cs using the AzureCoreSharedSources alias.");
                            }

                            if (expectFailure && !e.IsFailed)
                            {
                                throw new InvalidOperationException($"Expected scope {expectedName} to be marked as failed but it succeeded");
                            }
                        }
                        else
                        {
                            if (!diagnosticListener.Scopes.Any())
                            {
                                throw new InvalidOperationException($"Expected some diagnostic scopes to be created, found none");
                            }
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
