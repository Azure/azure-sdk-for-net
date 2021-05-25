﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Tests;
using Castle.DynamicProxy;

namespace Azure.Core.TestFramework
{
    public class DiagnosticScopeValidatingInterceptor : IInterceptor
    {
        private static readonly MethodInfo ValidateDiagnosticScopeMethodInfo = typeof(DiagnosticScopeValidatingInterceptor)
            .GetMethod(nameof(ValidateDiagnosticScopeInterceptor), BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new InvalidOperationException("Unable to find DiagnosticScopeValidatingInterceptor.ValidateDiagnosticScopeInterceptor method");

        private static readonly MethodInfo WrapAsyncResultCoreMethod = typeof(DiagnosticScopeValidatingInterceptor)
            .GetMethod(nameof(WrapAsyncResultCore), BindingFlags.NonPublic | BindingFlags.Static)
            ?? throw new InvalidOperationException("Unable to find DiagnosticScopeValidatingInterceptor.WrapAsyncResultCore method");

        public void Intercept(IInvocation invocation)
        {
            var type = invocation.Method.ReturnType;

            var isAsyncEnumerable = false;
            // cspell:ignore iface
            foreach (var iface in type.GetInterfaces())
            {
                if (iface.IsGenericType && iface.GetGenericTypeDefinition() == typeof(IAsyncEnumerable<>))
                {
                    isAsyncEnumerable = true;
                }
            }

            if (invocation.Method.Name.EndsWith("Async") &&
                !isAsyncEnumerable)
            {
                WrapAsyncResult(invocation, this, ValidateDiagnosticScopeMethodInfo);
                return;
            }

            if (type is {IsGenericType: true} genericType &&
                genericType.GetGenericTypeDefinition() == typeof(AsyncPageable<>))
            {
                invocation.Proceed();
                invocation.ReturnValue = Activator.CreateInstance(
                    typeof(DiagnosticScopeValidatingAsyncEnumerable<>).MakeGenericType(genericType.GenericTypeArguments[0]),
                    invocation.ReturnValue,
                    invocation.Method);
                return;
            }

            invocation.Proceed();
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
            // All this ceremony is not to await the returned Task/ValueTask synchronously
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

        internal class DiagnosticScopeValidatingAsyncEnumerable<T> : AsyncPageable<T>
        {
            private readonly AsyncPageable<T> _pageable;
            private readonly MethodInfo _methodInfo;
            private readonly bool _overridesGetAsyncEnumerator;

            public DiagnosticScopeValidatingAsyncEnumerable(AsyncPageable<T> pageable, MethodInfo methodInfo)
            {
                if (pageable == null) throw new ArgumentNullException(nameof(pageable), "Operations returning [Async]Pageable should never return null.");

                // If AsyncPageable overrides GetAsyncEnumerator we have to pass the call through to it
                // this would effectively disable the validation so avoid doing it as much as possible
                var getAsyncEnumeratorMethod = pageable.GetType().GetMethod("GetAsyncEnumerator", BindingFlags.Public | BindingFlags.Instance);
                _overridesGetAsyncEnumerator = getAsyncEnumeratorMethod.DeclaringType is {IsGenericType: true} genericType &&
                    genericType.GetGenericTypeDefinition() != typeof(AsyncPageable<>);

                _pageable = pageable;
                _methodInfo = methodInfo;
            }

            public override IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            {
                if (_overridesGetAsyncEnumerator)
                {
                    return _pageable.GetAsyncEnumerator(cancellationToken);
                }

                return base.GetAsyncEnumerator(cancellationToken);
            }

            public override async IAsyncEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await using var enumerator = _pageable.AsPages(continuationToken, pageSizeHint).GetAsyncEnumerator();

                while (await ValidateDiagnosticScope(async () =>
                {
                    bool movedNext = await enumerator.MoveNextAsync();
                    // Don't expect the MoveNextAsync call that returns false to create scope
                    return (movedNext, !movedNext);
                }, _methodInfo, $"AsPages() implementation returned from {_methodInfo.Name}"))
                {
                    yield return enumerator.Current;
                }
            }
        }
    }
}
