// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Castle.DynamicProxy;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Azure.Core.TestFramework
{
    [ClientTestFixture]
    public abstract class ClientTestBase
    {
        protected static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();

        private static readonly IInterceptor s_useSyncInterceptor = new UseSyncMethodsInterceptor(forceSync: true);
        private static readonly IInterceptor s_avoidSyncInterceptor = new UseSyncMethodsInterceptor(forceSync: false);
        private static readonly IInterceptor s_diagnosticScopeValidatingInterceptor = new DiagnosticScopeValidatingInterceptor();
        private static Dictionary<Type, Exception> s_clientValidation = new Dictionary<Type, Exception>();
        private const int GLOBAL_TEST_TIMEOUT_IN_SECONDS = 10;
        public bool IsAsync { get; }

        public bool TestDiagnostics { get; set; } = true;

        public ClientTestBase(bool isAsync)
        {
            IsAsync = isAsync;
        }

        protected virtual DateTime TestStartTime => TestExecutionContext.CurrentContext.StartTime;

        [TearDown]
        public virtual void GlobalTimeoutTearDown()
        {
            var executionContext = TestExecutionContext.CurrentContext;
            var duration = DateTime.UtcNow - TestStartTime;
            if (duration > TimeSpan.FromSeconds(GLOBAL_TEST_TIMEOUT_IN_SECONDS) && !Debugger.IsAttached)
            {
                executionContext.CurrentResult.SetResult(ResultState.Failure,
                    $"Test exceeded global time limit of {GLOBAL_TEST_TIMEOUT_IN_SECONDS} seconds. Duration: {duration}");
            }
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

            interceptors.Add(new GetOriginalInterceptor(client));

            if (TestDiagnostics)
            {
                interceptors.Add(s_diagnosticScopeValidatingInterceptor);
            }

            interceptors.Add(new InstrumentResultInterceptor(this));

            // Ignore the async method interceptor entirely if we're running a
            // a SyncOnly test
            TestContext.TestAdapter test = TestContext.CurrentContext.Test;
            bool? isSyncOnly = (bool?)test.Properties.Get(ClientTestFixtureAttribute.SyncOnlyKey);
            if (isSyncOnly != true)
            {
                interceptors.Add(IsAsync ? s_avoidSyncInterceptor : s_useSyncInterceptor);
            }

            return ProxyGenerator.CreateClassProxyWithTarget(
                clientType,
                new[] {typeof(IInstrumented)},
                client,
                interceptors.ToArray());
        }

        protected internal virtual object InstrumentOperation(Type operationType, object operation)
        {
            return operation;
        }

        protected T GetOriginal<T>(T instrumented)
        {
            if (instrumented == null) throw new ArgumentNullException(nameof(instrumented));
            var i = instrumented as IInstrumented ?? throw new InvalidOperationException($"{instrumented.GetType()} is not an instrumented type");
            return (T) i.Original;
        }
    }
}
