// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        private const int GLOBAL_TEST_TIMEOUT_IN_SECONDS = 25;
        private const int GLOBAL_LOCAL_TEST_TIMEOUT_IN_SECONDS = 10;
        public bool IsAsync { get; }

        public bool TestDiagnostics { get; set; } = true;

        public ClientTestBase(bool isAsync)
        {
            IsAsync = isAsync;
        }

        protected IReadOnlyCollection<IInterceptor> AdditionalInterceptors { get; set; }

        protected virtual DateTime TestStartTime => TestExecutionContext.CurrentContext.StartTime;

        [TearDown]
        public virtual void GlobalTimeoutTearDown()
        {
            if (Debugger.IsAttached)
            {
                return;
            }

            var executionContext = TestExecutionContext.CurrentContext;
            var duration = DateTime.UtcNow - TestStartTime;
            var timeout = TestEnvironment.GlobalIsRunningInCI ? GLOBAL_TEST_TIMEOUT_IN_SECONDS : GLOBAL_LOCAL_TEST_TIMEOUT_IN_SECONDS;
            if (duration > TimeSpan.FromSeconds(timeout))
            {
                string message = $"Test exceeded global time limit of {timeout} seconds. Duration: {duration} ";
                if (this is RecordedTestBase &&
                    !executionContext.CurrentTest.GetCustomAttributes<RecordedTestAttribute>(true).Any())
                {
                    message += Environment.NewLine + "Replace the [Test] attribute with the [RecordedTest] attribute in your test to allow an automatic retry for timeouts.";
                }
                throw new TestTimeoutException(message);
            }
        }

        protected TClient CreateClient<TClient>(params object[] args) where TClient : class
        {
            return InstrumentClient((TClient)Activator.CreateInstance(typeof(TClient), args));
        }

        public TClient InstrumentClient<TClient>(TClient client) where TClient : class => (TClient)InstrumentClient(typeof(TClient), client, null);

        protected TClient InstrumentClient<TClient>(TClient client, IEnumerable<IInterceptor> preInterceptors) where TClient : class =>
            (TClient)InstrumentClient(typeof(TClient), client, preInterceptors);

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
                    var coreMethods = new Dictionary<string, MethodInfo>();

                    foreach (MethodInfo methodInfo in clientType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic))
                    {
                        if (methodInfo.Name.EndsWith("CoreAsync") && (methodInfo.IsVirtual || methodInfo.IsAbstract))
                        {
                            coreMethods.Add(methodInfo.Name.Substring(0, methodInfo.Name.Length - 9) + "Async", methodInfo);
                        }
                    }

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
                            // if an async method is not virtual, we should find if we have a corresponding virtual or abstract Core method
                            // if no, we throw the validation failed exception
                            if (!coreMethods.ContainsKey(methodInfo.Name))
                            {
                                validationException = new InvalidOperationException($"Client type contains public non-virtual async method {methodInfo.Name}");

                                break;
                            }
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
                new[] { typeof(IInstrumented) },
                client,
                interceptors.ToArray());
        }

        protected internal virtual object InstrumentOperation(Type operationType, object operation)
        {
            var interceptors = AdditionalInterceptors ?? Array.Empty<IInterceptor>();

            // The assumption is that any recorded or live tests deriving from RecordedTestBase, and that any unit tests deriving directly from ClientTestBase are equivalent to playback.
            var interceptorArray = interceptors.Concat(new IInterceptor[] { new GetOriginalInterceptor(operation), new OperationInterceptor(RecordedTestMode.Playback) }).ToArray();
            return ProxyGenerator.CreateClassProxyWithTarget(
                operationType,
                new[] { typeof(IInstrumented) },
                operation,
                interceptorArray);
        }

        protected internal T InstrumentOperation<T>(T operation) where T : Operation =>
            (T)InstrumentOperation(typeof(T), operation);

        protected T GetOriginal<T>(T instrumented)
        {
            if (instrumented == null) throw new ArgumentNullException(nameof(instrumented));
            var i = instrumented as IInstrumented ?? throw new InvalidOperationException($"{instrumented.GetType()} is not an instrumented type");
            return (T)i.Original;
        }
    }
}
