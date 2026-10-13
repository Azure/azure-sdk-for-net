// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
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

        private static Regex AttributeNameRegex = new Regex(@"^[a-z\._]+$", RegexOptions.Compiled);
        public void Intercept(IInvocation invocation)
        {
            var type = invocation.Method.ReturnType;
            Type asyncEnumerableItemType = AsyncEnumerableType.GetItemType(type);

            if (invocation.Method.Name.EndsWith("Async") &&
                asyncEnumerableItemType is null)
            {
                WrapAsyncResult(invocation, this, ValidateDiagnosticScopeMethodInfo);
                return;
            }

            if (asyncEnumerableItemType is not null && AsyncEnumerableType.IsInterface(type))
            {
                invocation.Proceed();
                invocation.ReturnValue = Activator.CreateInstance(
                    typeof(DiagnosticScopeValidatingEnumerable<>).MakeGenericType(asyncEnumerableItemType),
                    invocation.ReturnValue,
                    invocation.Method);
                return;
            }

            if (type is { IsGenericType: true } genericType &&
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
            if (invocation.Method.ReturnType is { IsGenericType: true, GenericTypeArguments: { Length: 1 } genericTypeArguments })
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
                    var signatureResponseType = typeof(T);
                    if (signatureResponseType.IsGenericType && signatureResponseType.GetGenericTypeDefinition().Equals(typeof(Response<>)))
                    {
                        //guaranteed only one generic arg with Response<T>
                        var signatureGenericType = signatureResponseType.GetGenericArguments()[0];
                        var runtimeTaskType = invocation.ReturnValue.GetType();
                        Type runtimeGenericType = null;
                        if (runtimeTaskType.IsGenericType && runtimeTaskType.GetGenericTypeDefinition().Equals(typeof(Task<>)))
                        {
                            var runtimeResponseType = runtimeTaskType.GetGenericArguments()[0];
                            if (!runtimeResponseType.Equals(signatureResponseType) && runtimeResponseType.IsGenericType && runtimeResponseType.GetGenericTypeDefinition().Equals(typeof(Response<>)))
                            {
                                runtimeGenericType = runtimeResponseType.GetGenericArguments()[0];
                            }
                        }
                        if (runtimeGenericType is not null && runtimeGenericType.IsSubclassOf(signatureGenericType))
                        {
                            //keep async nature of the call and guaratee we are complete at this point
                            await (Task)invocation.ReturnValue;
                            var runtimeResponseObject = TaskExtensions.GetResultFromTask(invocation.ReturnValue);
                            var runtimeRawResponse = runtimeResponseObject.GetType().GetMethod("GetRawResponse", BindingFlags.Instance | BindingFlags.Public).Invoke(runtimeResponseObject, null);
                            var runtimeValue = runtimeResponseObject.GetType().GetProperty("Value", BindingFlags.Public | BindingFlags.Instance).GetValue(runtimeResponseObject);

                            //reconstruct
                            var signatureFromValueMethod = typeof(Response).GetMethod("FromValue", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(signatureGenericType);
                            var convertedResponseObject = signatureFromValueMethod.Invoke(null, new object[] { runtimeValue, runtimeRawResponse });
                            return (T)convertedResponseObject;
                        }
                    }
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
            source ??= methodInfo.Name;

            Exception lastException = null;
            bool skipChecks = false;
            T result;

            using ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure."), asyncLocal: true);

            try
            {
                // activities may be suppressed if they are called in scope of other activities create by other SDK methods.
                // Let's unsuppress the so we are able to check all the attributes and properties regardless of the test setup.
                Activity.Current?.SetCustomProperty("az.sdk.scope", null);
                (result, skipChecks) = await action();
            }
            catch (Exception ex)
            {
                lastException = ex;

                if (ex is ArgumentException)
                {
                    // Don't expect scope for argument validation failures
                    skipChecks = true;
                }

                throw;
            }
            finally
            {
                ValidateDiagnosticScopes(diagnosticListener, methodInfo, source, lastException, skipChecks);
            }

            return result;
        }

        private static void ValidateDiagnosticScopes(
            ClientDiagnosticListener diagnosticListener,
            MethodInfo methodInfo,
            string source,
            Exception lastException,
            bool skipChecks)
        {
            diagnosticListener.Dispose();

            string methodName = methodInfo.Name;
            Type declaringType = methodInfo.DeclaringType;
            string methodNameWithoutSuffix = methodName.EndsWith("Async", StringComparison.OrdinalIgnoreCase)
                ? methodName.Substring(0, methodName.Length - 5)
                : methodName;
            if (methodInfo.IsFamily && methodNameWithoutSuffix.EndsWith("Core"))
            {
                methodNameWithoutSuffix = methodNameWithoutSuffix.Substring(0, methodNameWithoutSuffix.Length - 4);
            }

            string expectedName = declaringType.Name + "." + methodNameWithoutSuffix;
            object forwardAttribute = methodInfo.GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType().FullName == "Azure.Core.ForwardsClientCallsAttribute");
            PropertyInfo skipOverrideProperty = forwardAttribute?.GetType().GetProperty("SkipChecks");
            skipChecks |= skipOverrideProperty is not null && (bool)skipOverrideProperty.GetValue(forwardAttribute);
            if (skipChecks)
            {
                return;
            }

            bool strict = forwardAttribute is null;
            diagnosticListener.Scopes.ForEach(s => CheckAttributes(s.Activity, strict));

            if (strict)
            {
                ClientDiagnosticListener.ProducedDiagnosticScope scope = diagnosticListener.Scopes
                    .FirstOrDefault(e => e.Name == expectedName);
                if (scope == default)
                {
                    throw new InvalidOperationException($"Expected diagnostic scope not created {expectedName} {Environment.NewLine}" +
                                                        $"    created {diagnosticListener.Scopes.Count} scopes [{string.Join(", ", diagnosticListener.Scopes)}] {Environment.NewLine}" +
                                                        $"    You may have forgotten to add clientDiagnostics.CreateScope(...), set your operationId to {expectedName} in {source} or applied the Azure.Core.ForwardsClientCallsAttribute to {source}.");
                }

                if (lastException != null && !scope.IsFailed)
                {
                    throw new InvalidOperationException($"Expected scope {expectedName} to be marked as failed but it succeeded{Environment.NewLine}Exception: {lastException}");
                }
            }
            else if (!diagnosticListener.Scopes.Any(e => !e.Name.StartsWith("Azure.Core")))
            {
                throw new InvalidOperationException(
                    "Expected some diagnostic scopes to be created other than the Azure.Core scopes, but no such scopes were present. " +
                    $"Ensure that the inner method that client calls are being forwarded to from the '{source}' method has diagnostic scopes " +
                    "defined by using clientDiagnostics.CreateScope(...).");
            }
        }

        private static void CheckAttributes(Activity activity, bool strict)
        {
            foreach (var tag in activity.TagObjects)
            {
                if (tag.Key == "kind" || tag.Key.StartsWith("otel.") || tag.Key == "requestId" || tag.Key == "serviceRequestId")
                {
                    // TODO: these are populated on DiagnosticSource path. We should rewrite this to ActivitySource and remove those.
                    continue;
                }

                if (!AttributeNameRegex.IsMatch(tag.Key))
                {
                    throw new InvalidOperationException("Attribute name can only have lowercase letters, dot (`.`), and underscore (`_`). " +
                        "Use dot to separate namespaces and underscore to separate words (e.g. http.request.status_code). " + $"Attribute name: {tag.Key}");
                }

                int dot = tag.Key.IndexOf('.');
                if (dot == -1)
                {
                    throw new InvalidOperationException("Attribute names must be namespaced. Use OpenTelemetry attributes whenever possible - https://github.com/open-telemetry/semantic-conventions/blob/main/docs/README.md. " +
                        "Custom Azure-specific attributes must start with `az.` and should have library-specific namespaces (e.g. `az.digital_twin.twin_id`). " + $"Attribute name: {tag.Key}");
                }

                string ns = tag.Key.Substring(0, dot);
                if ("az" != ns && "messaging" != ns && "http" != ns && "error" != ns && "url" != ns)
                {
                    throw new InvalidOperationException("Unknown attribute namespace. Use OpenTelemetry attributes whenever possible - https://github.com/open-telemetry/semantic-conventions/blob/main/docs/README.md." +
                        "Custom Azure-specific attributes must start with `az.` and should have library-specific namespaces (e.g. `az.digital_twin.twin_id`). " + $"Attribute name: {tag.Key}");
                }

                string tagValueStr = tag.Value?.ToString();
                if (string.IsNullOrEmpty(tagValueStr) || (tag.Key.StartsWith("az.") && tagValueStr.Length > 256))
                {
                    throw new InvalidOperationException("Attribute values must not be null, empty, or longer than 256 characters. "
                        + $"Attribute name: `{tag.Key}`, value: `{tag.Value}`, activity name: `{activity.OperationName}`");
                }
            }

            if (strict)
            {
                if (!activity.Tags.Any(tag => tag.Key == "az.namespace"))
                {
                    throw new InvalidOperationException($"All diagnostic scopes should have 'az.namespace' attribute, make sure the assembly containing **ClientOptions type is marked with the AzureResourceProviderNamespace attribute specifying the appropriate provider. This attribute should be included in AssemblyInfo, and can be included by pulling in AzureResourceProviderNamespaceAttribute.cs using the AzureCoreSharedSources alias. " +
                                                        $"\nActivity name: {activity.OperationName}, Source name: {activity?.Source.Name}");
                }
            }

            if (activity.Status == ActivityStatusCode.Error && activity.Source?.HasListeners() == true && !activity.TagObjects.Any(kvp => kvp.Key == "error.type"))
            {
                throw new InvalidOperationException("All failed activities must have `error.type` attribute set to known or documented error code or a full name of exception type");
            }
        }

        internal class DiagnosticScopeValidatingAsyncEnumerable<T> : AsyncPageable<T>
        {
            private readonly AsyncPageable<T> _pageable;
            private readonly MethodInfo _methodInfo;
            private readonly bool _overridesGetAsyncEnumerator;

            //for mocking
            protected DiagnosticScopeValidatingAsyncEnumerable()
            {
            }

            public DiagnosticScopeValidatingAsyncEnumerable(AsyncPageable<T> pageable, MethodInfo methodInfo)
            {
                if (pageable == null)
                    throw new ArgumentNullException(nameof(pageable), "Operations returning [Async]Pageable should never return null.");

                // If AsyncPageable overrides GetAsyncEnumerator we have to pass the call through to it
                // this would effectively disable the validation so avoid doing it as much as possible
                var getAsyncEnumeratorMethod = pageable.GetType().GetMethod("GetAsyncEnumerator", BindingFlags.Public | BindingFlags.Instance);
                _overridesGetAsyncEnumerator = getAsyncEnumeratorMethod.DeclaringType is { IsGenericType: true } genericType &&
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

        internal sealed class DiagnosticScopeValidatingEnumerable<T> : IAsyncEnumerable<T>
        {
            private readonly IAsyncEnumerable<T> _enumerable;
            private readonly MethodInfo _methodInfo;

            public DiagnosticScopeValidatingEnumerable(
                IAsyncEnumerable<T> enumerable,
                MethodInfo methodInfo)
            {
                _enumerable = enumerable ?? throw new ArgumentNullException(
                    nameof(enumerable),
                    "Operations returning IAsyncEnumerable should never return null.");
                _methodInfo = methodInfo;
            }

            public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
                => new DiagnosticScopeValidatingEnumerator(
                    _enumerable,
                    _methodInfo,
                    cancellationToken);

            private sealed class DiagnosticScopeValidatingEnumerator : IAsyncEnumerator<T>
            {
                private readonly ClientDiagnosticListener _diagnosticListener;
                private readonly IAsyncEnumerator<T> _enumerator;
                private readonly MethodInfo _methodInfo;
                private readonly object _operationToken = new object();
                private bool _moveNextStarted;
                private bool _validationCompleted;

                public DiagnosticScopeValidatingEnumerator(
                    IAsyncEnumerable<T> enumerable,
                    MethodInfo methodInfo,
                    CancellationToken cancellationToken)
                {
                    _methodInfo = methodInfo;

                    // Bind the listener to this enumerator so interleaved streams on the same async flow do not
                    // record, or validate, each other's scopes.
                    _diagnosticListener = new ClientDiagnosticListener(
                        s => s.StartsWith("Azure."),
                        asyncLocal: true,
                        scopeStartCallback: null,
                        operationToken: _operationToken);
                    UnsuppressCurrentActivity();
                    try
                    {
                        _enumerator = enumerable.GetAsyncEnumerator(cancellationToken);
                    }
                    catch
                    {
                        _diagnosticListener.Dispose();
                        throw;
                    }
                }

                public T Current => _enumerator.Current;

                public async ValueTask<bool> MoveNextAsync()
                {
                    _moveNextStarted = true;

                    // The iterator body runs lazily, so the activity that hosts its scopes is only
                    // known here rather than when the enumerator was created.
                    ClientDiagnosticListener.EnterOperation(_operationToken);
                    UnsuppressCurrentActivity();
                    try
                    {
                        bool movedNext = await _enumerator.MoveNextAsync();
                        if (!movedNext)
                        {
                            CompleteValidation(null, false);
                        }

                        return movedNext;
                    }
                    catch (Exception ex)
                    {
                        CompleteValidation(ex, ex is ArgumentException);
                        throw;
                    }
                }

                public async ValueTask DisposeAsync()
                {
                    Exception exception = null;
                    ClientDiagnosticListener.EnterOperation(_operationToken);
                    UnsuppressCurrentActivity();
                    try
                    {
                        await _enumerator.DisposeAsync();
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                        throw;
                    }
                    finally
                    {
                        if (_moveNextStarted)
                        {
                            CompleteValidation(exception, exception is ArgumentException);
                        }
                        else
                        {
                            _diagnosticListener.Dispose();
                        }
                    }
                }

                private static void UnsuppressCurrentActivity()
                {
                    // Activities may be suppressed if they are called in scope of other activities created by
                    // other SDK methods. Unsuppress them so all attributes and properties can be checked
                    // regardless of the test setup.
                    Activity.Current?.SetCustomProperty("az.sdk.scope", null);
                }

                private void CompleteValidation(Exception exception, bool skipChecks)
                {
                    if (_validationCompleted)
                    {
                        return;
                    }

                    _validationCompleted = true;
                    ValidateDiagnosticScopes(
                        _diagnosticListener,
                        _methodInfo,
                        _methodInfo.Name,
                        exception,
                        skipChecks);
                }
            }
        }
    }
}
