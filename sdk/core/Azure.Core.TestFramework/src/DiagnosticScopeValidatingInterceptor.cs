// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;

            Type declaringType = invocation.Method.DeclaringType;
            var expectedName = declaringType.Name + "." + methodName.Substring(0, methodName.Length - 5);
            bool strict = !invocation.Method.GetCustomAttributes(true).Any(a => a.GetType().FullName == "Azure.Core.ForwardsClientCallsAttribute");

            if (invocation.Method.ReturnType is {IsGenericType: true} genericType &&
                genericType.GetGenericTypeDefinition() == typeof(AsyncPageable<>))
            {
                invocation.Proceed();
                invocation.ReturnValue = Activator.CreateInstance(typeof(DiagnosticScopeValidatingAsyncEnumerable<>).MakeGenericType(genericType.GenericTypeArguments[0]), invocation.ReturnValue, expectedName, strict);
            }
            else if (methodName.EndsWith("Async") &&
                      !invocation.Method.ReturnType.Name.Contains("IAsyncEnumerable"))
            {
                ValidateDiagnosticScope<object>(() =>
                {
                    invocation.Proceed();

                    object returnValue = invocation.ReturnValue;
                    if (returnValue is Task t)
                    {
                        t.GetAwaiter().GetResult();
                    }
                    else
                    {
                        // Await ValueTask or Task<T>
                        Type returnType = returnValue.GetType();
                        MethodInfo getAwaiterMethod = returnType.GetMethod("GetAwaiter", BindingFlags.Instance | BindingFlags.Public);
                        MethodInfo getResultMethod = getAwaiterMethod.ReturnType.GetMethod("GetResult", BindingFlags.Instance | BindingFlags.Public);

                        getResultMethod.Invoke(
                            getAwaiterMethod.Invoke(returnValue, Array.Empty<object>()),
                            Array.Empty<object>());
                    }
                    return default;
                }, expectedName, methodName, strict).GetAwaiter().GetResult();
            }
            else
            {
                invocation.Proceed();
            }
        }

        internal static async ValueTask<T> ValidateDiagnosticScope<T>(Func<ValueTask<(T Result, bool SkipChecks)>> action, string expectedName, string methodName, bool strict)
        {
            bool expectFailure = false;
            bool skipChecks = false;
            T result = default;

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
                                                                $"    You may have forgotten to add clientDiagnostics.CreateScope(...), set your operationId to {expectedName} in {methodName} or applied the Azure.Core.ForwardsClientCallsAttribute to {methodName}.");
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
            private readonly string _expectedName;
            private readonly bool _strict;
            private bool _overridesGetAsyncEnumerator;

            public DiagnosticScopeValidatingAsyncEnumerable(AsyncPageable<T> pageable, string expectedName, bool strict)
            {
                if (pageable == null) throw new ArgumentNullException(nameof(pageable), "Operations returning [Async]Pageable should never return null.");

                // If AsyncPageable overrides GetAsyncEnumerator we have to pass the call through to it
                // this would effectively disable the validation so avoid doing it as much as possible
                var getAsyncEnumeratorMethod = pageable.GetType().GetMethod("GetAsyncEnumerator", BindingFlags.Public | BindingFlags.Instance);
                _overridesGetAsyncEnumerator = getAsyncEnumeratorMethod.DeclaringType is {IsGenericType: true} genericType &&
                    genericType.GetGenericTypeDefinition() != typeof(AsyncPageable<>);

                _pageable = pageable;
                _expectedName = expectedName;
                _strict = strict;
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
                    return (movedNext, !movedNext);
                }, _expectedName, "AsPages() implementation", _strict))
                {
                    yield return enumerator.Current;
                }
            }
        }
    }
}
