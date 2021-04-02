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
        private static readonly MethodInfo ValidateDiagnosticScopeMethodInfo = typeof(DiagnosticScopeValidatingInterceptor).
            GetMethod(nameof(ValidateDiagnosticScopeInterceptor), BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly MethodInfo WrapAsyncResultCoreMethod = typeof(DiagnosticScopeValidatingInterceptor).
            GetMethod(nameof(WrapAsyncResultCore), BindingFlags.NonPublic | BindingFlags.Static);

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.Name.EndsWith("Async") &&
                !invocation.Method.ReturnType.Name.Contains("IAsyncEnumerable"))
            {
                WrapAsyncResult(invocation, this, ValidateDiagnosticScopeMethodInfo);
            }
            else
            {
                invocation.Proceed();
            }
        }

        internal static void WrapAsyncResult(IInvocation invocation, object target, MethodInfo interceptorMethod)
        {
            Type genericArgument = typeof(object);
            Type awaitableType = invocation.Method.ReturnType;
            if (invocation.Method.ReturnType is {IsGenericType: true, GenericTypeArguments: {Length: 1} genericTypeArguments})
            {
                genericArgument = genericTypeArguments[0];
                awaitableType = invocation.Method.ReturnType.GetGenericTypeDefinition();
            }

            WrapAsyncResultCoreMethod.MakeGenericMethod(genericArgument)
                .Invoke(null, new object[]
                {
                    invocation,
                    awaitableType,
                    interceptorMethod
                        .MakeGenericMethod(genericArgument)
                        .CreateDelegate(typeof(AsyncCallInterceptor<>).MakeGenericType(genericArgument), target)
                });
        }

        internal static void WrapAsyncResultCore<T>(IInvocation invocation, Type genericType, AsyncCallInterceptor<T> wrap)
        {
            // All this ceremony is not to await the returned Task/ValueTask syncronously
            // instead we are replacing the invocation.ReturnValue with the ValidateDiagnosticScope task
            // but we need to make sure the types match
            if (genericType == typeof(Task<>))
            {
                async ValueTask<T> Await()
                {
                    invocation.Proceed();
                    return await (Task<T>)invocation.ReturnValue;
                }

                invocation.ReturnValue = wrap(invocation, Await).AsTask();
            }
            else if (genericType == typeof(Task))
            {
                async ValueTask<T> Await()
                {
                    invocation.Proceed();
                    await (Task)invocation.ReturnValue;
                    return default;
                }

                invocation.ReturnValue = wrap(invocation, Await).AsTask();
            }
            else if (genericType == typeof(ValueTask<>))
            {
                ValueTask<T> Await()
                {
                    invocation.Proceed();
                    return (ValueTask<T>)invocation.ReturnValue;
                }

                invocation.ReturnValue = wrap(invocation, Await);
            }
            else if (genericType == typeof(ValueTask))
            {
                async ValueTask<T> Await()
                {
                    invocation.Proceed();
                    await (ValueTask)invocation.ReturnValue;
                    return default;
                }

                invocation.ReturnValue = new ValueTask(wrap(invocation, Await).AsTask());
            }
            else
            {
                ValueTask<T> Await()
                {
                    invocation.Proceed();
                    return default;
                }

                invocation.ReturnValue = wrap(invocation, Await).GetAwaiter().GetResult();
            }
        }

        internal ValueTask<T> ValidateDiagnosticScopeInterceptor<T>(IInvocation invocation, Func<ValueTask<T>> innerTask)
        {
            return ValidateDiagnosticScope(async () => (await innerTask(), false), invocation.Method);
        }

        internal static async ValueTask<T> ValidateDiagnosticScope<T>(Func<ValueTask<(T Result, bool SkipChecks)>> action, MethodInfo methodInfo, string source = null)
        {
            var methodName = methodInfo.Name;
            source ??= methodName;

            Type declaringType = methodInfo.DeclaringType;
            var methodNameWithoutSuffix = methodName.EndsWith("Async", StringComparison.OrdinalIgnoreCase) ?
                methodName.Substring(0, methodName.Length - 5) :
                methodName;

            var expectedName = declaringType.Name + "." + methodNameWithoutSuffix;
            bool strict = !methodInfo.GetCustomAttributes(true).Any(a => a.GetType().FullName == "Azure.Core.ForwardsClientCallsAttribute");

            bool expectFailure = false;
            bool skipChecks = false;
            T result;

            using ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure."), asyncLocal: true);
            try
            {
                (result, skipChecks) = await action();
            }
            catch (Exception ex)
            {
                expectFailure = true;

                if (ex is ArgumentException)
                {
                    // Don't expect scope for argument validation failures
                    skipChecks = true;
                }

                throw;
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
                            throw new InvalidOperationException($"Expected diagnostic scope not created {expectedName} {Environment.NewLine}" +
                                                                $"    created {diagnosticListener.Scopes.Count} scopes [{string.Join(", ", diagnosticListener.Scopes)}] {Environment.NewLine}" +
                                                                $"    You may have forgotten to add clientDiagnostics.CreateScope(...), set your operationId to {expectedName} in {source} or applied the Azure.Core.ForwardsClientCallsAttribute to {source}.");
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

            return result;
        }
    }
}
