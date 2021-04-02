// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Castle.DynamicProxy;

namespace Azure.Core.TestFramework
{
    internal class InstrumentResultInterceptor : IInterceptor
    {
        private readonly ClientTestBase _testBase;

        public InstrumentResultInterceptor(ClientTestBase testBase)
        {
            _testBase = testBase;
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();

            var result = invocation.ReturnValue;
            if (result == null)
            {
                return;
            }

            var type = result.GetType();

            // We don't want to instrument generated rest clients.
            if ((type.Name.EndsWith("Client") && !type.Name.EndsWith("RestClient")) ||
                // Generated ARM clients will have a property containing the sub-client that ends with Operations.
                (invocation.Method.Name.StartsWith("get_") && type.Name.EndsWith("Operations")))
            {
                invocation.ReturnValue = _testBase.InstrumentClient(type, result, Array.Empty<IInterceptor>());
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

            if (typeof(Operation).IsAssignableFrom(type))
            {

            }
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

                while (await DiagnosticScopeValidatingInterceptor.ValidateDiagnosticScope(async () =>
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
