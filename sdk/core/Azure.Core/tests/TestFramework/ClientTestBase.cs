// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Castle.DynamicProxy;
using NUnit.Framework;

namespace Azure.Core.Testing
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class ClientTestBase
    {
        private static readonly ProxyGenerator s_proxyGenerator = new ProxyGenerator();

        private static readonly IInterceptor s_useSyncInterceptor = new UseSyncMethodsInterceptor(forceSync: true);
        private static readonly IInterceptor s_avoidSyncInterceptor = new UseSyncMethodsInterceptor(forceSync: false);
        private static readonly IInterceptor s_diagnosticScopeValidatingInterceptor = new DiagnosticScopeValidatingInterceptor();

        public bool IsAsync { get; }

        public bool TestDiagnostics { get; set; } = true;

        public ClientTestBase(bool isAsync)
        {
            IsAsync = isAsync;
        }

        public virtual TClient CreateClient<TClient>(params object[] args) where TClient : class
        {

            return InstrumentClient((TClient)Activator.CreateInstance(typeof(TClient), args));
        }

        public virtual TClient InstrumentClient<TClient>(TClient client) where TClient : class
        {
            Debug.Assert(!client.GetType().Name.EndsWith("Proxy"), $"{nameof(client)} was already instrumented");

            if (ClientValidation<TClient>.Validated == false)
            {
                foreach (MethodInfo methodInfo in typeof(TClient).GetMethods(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (methodInfo.Name.EndsWith("Async") && !methodInfo.IsVirtual)
                    {
                        ClientValidation<TClient>.ValidationException = new InvalidOperationException($"Client type contains public non-virtual async method {methodInfo.Name}");

                        break;
                    }
                }

                ClientValidation<TClient>.Validated = true;
            }

            if (ClientValidation<TClient>.ValidationException != null)
            {
                throw ClientValidation<TClient>.ValidationException;
            }

            List<IInterceptor> interceptors = new List<IInterceptor>();

            if (TestDiagnostics)
            {
                interceptors.Add(s_diagnosticScopeValidatingInterceptor);
            }

            interceptors.Add(IsAsync ? s_avoidSyncInterceptor : s_useSyncInterceptor);

            return s_proxyGenerator.CreateClassProxyWithTarget(client, interceptors.ToArray());
        }


        private static class ClientValidation<TClient>
        {
            public static bool Validated;

            public static Exception ValidationException;
        }
    }
}
