// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using NUnit.Framework;

namespace Azure.Core.TestFramework
{
    [ClientTestFixture]
    public abstract class ClientTestBase
    {
        private static readonly ProxyGenerator s_proxyGenerator = new ProxyGenerator();

        private static readonly IInterceptor s_useSyncInterceptor = new UseSyncMethodsInterceptor(forceSync: true);
        private static readonly IInterceptor s_avoidSyncInterceptor = new UseSyncMethodsInterceptor(forceSync: false);
        private static readonly IInterceptor s_diagnosticScopeValidatingInterceptor = new DiagnosticScopeValidatingInterceptor();
        private static Dictionary<Type, Exception> s_clientValidation = new Dictionary<Type, Exception>();
        public bool IsAsync { get; }

        public bool TestDiagnostics { get; set; } = true;

        public ClientTestBase(bool isAsync)
        {
            IsAsync = isAsync;
        }

        protected TClient CreateClient<TClient>(params object[] args) where TClient : class
        {
            return InstrumentClient((TClient)Activator.CreateInstance(typeof(TClient), args));
        }

        public TClient InstrumentClient<TClient>(TClient client) where TClient : class => (TClient)InstrumentClient(typeof(TClient), client, null);

        protected TClient InstrumentClient<TClient>(TClient client, IEnumerable<IInterceptor> preInterceptors) where TClient : class => (TClient)InstrumentClient(typeof(TClient), client, preInterceptors);

        protected internal virtual object InstrumentClient(Type clientType, object client, IEnumerable<IInterceptor> preInterceptors)
        {
            if (client is IProxyTargetAccessor)
            {
                // Already instrumented
                return client;
            }

            lock (s_clientValidation)
            {
                if (!s_clientValidation.TryGetValue(clientType, out var validationException))
                {
                    foreach (MethodInfo methodInfo in clientType.GetMethods(BindingFlags.Instance | BindingFlags.Public))
                    {
                        if (methodInfo.Name.EndsWith("Async") && !methodInfo.IsVirtual)
                        {
                            validationException = new InvalidOperationException($"Client type contains public non-virtual async method {methodInfo.Name}");

                            break;
                        }

                        if (methodInfo.Name.EndsWith("Client") &&
                            methodInfo.Name.StartsWith("Get") &&
                            !methodInfo.IsVirtual)
                        {
                            validationException = new InvalidOperationException($"Client type contains public non-virtual Get*Client method {methodInfo.Name}");

                            break;
                        }
                    }

                    s_clientValidation[clientType] = validationException;
                }

                if (validationException != null)
                {
                    throw validationException;
                }
            }

            List<IInterceptor> interceptors = new List<IInterceptor>();
            if (preInterceptors != null)
            {
                interceptors.AddRange(preInterceptors);
            }

            if (TestDiagnostics)
            {
                interceptors.Add(s_diagnosticScopeValidatingInterceptor);
            }

            // Ignore the async method interceptor entirely if we're running a
            // a SyncOnly test
            TestContext.TestAdapter test = TestContext.CurrentContext.Test;
            bool? isSyncOnly = (bool?)test.Properties.Get(ClientTestFixtureAttribute.SyncOnlyKey);
            if (isSyncOnly != true)
            {
                interceptors.Add(IsAsync ? s_avoidSyncInterceptor : s_useSyncInterceptor);
            }

            interceptors.Add(new InstrumentClientInterceptor(this));

            return s_proxyGenerator.CreateClassProxyWithTarget(clientType, client, interceptors.ToArray());
        }
    }
}
