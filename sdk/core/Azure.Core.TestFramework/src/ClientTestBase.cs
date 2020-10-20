// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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
        protected static TestLogger Logger { get; set; }
        public bool TestDiagnostics { get; set; } = true;
        public RecordedTestMode Mode { get; set; }
        public TestRecording Recording { get;  set; }

        // copied the Windows version https://github.com/dotnet/runtime/blob/master/src/libraries/System.Private.CoreLib/src/System/IO/Path.Windows.cs
        // as it is the most restrictive of all platforms
        private static readonly HashSet<char> s_invalidChars = new HashSet<char>(new char[]
        {
            '\"', '<', '>', '|', '\0',
            (char)1, (char)2, (char)3, (char)4, (char)5, (char)6, (char)7, (char)8, (char)9, (char)10,
            (char)11, (char)12, (char)13, (char)14, (char)15, (char)16, (char)17, (char)18, (char)19, (char)20,
            (char)21, (char)22, (char)23, (char)24, (char)25, (char)26, (char)27, (char)28, (char)29, (char)30,
            (char)31, ':', '*', '?', '\\', '/'
        });
        protected string GetSessionFilePath()
        {
            TestContext.TestAdapter testAdapter = TestContext.CurrentContext.Test;

            string name = new string(testAdapter.Name.Select(c => s_invalidChars.Contains(c) ? '%' : c).ToArray());
            string additionalParameterName = testAdapter.Properties.ContainsKey(ClientTestFixtureAttribute.RecordingDirectorySuffixKey) ?
                testAdapter.Properties.Get(ClientTestFixtureAttribute.RecordingDirectorySuffixKey).ToString() :
                null;

            string className = testAdapter.ClassName.Substring(testAdapter.ClassName.LastIndexOf('.') + 1);

            string fileName = name + (IsAsync ? "Async" : string.Empty) + ".json";
            return Path.Combine(TestContext.CurrentContext.TestDirectory,
                "SessionRecords",
                additionalParameterName == null ? className : $"{className}({additionalParameterName})",
                fileName);
        }
        public T InstrumentClientOptions<T>(T clientOptions) where T : ClientOptions
        {
            clientOptions.Transport = Recording.CreateTransport(clientOptions.Transport);
            if (Mode == RecordedTestMode.Playback)
            {
                // Not making the timeout zero so retry code still goes async
                clientOptions.Retry.Delay = TimeSpan.FromMilliseconds(10);
                clientOptions.Retry.Mode = RetryMode.Fixed;
            }
            return clientOptions;
        }

#if DEBUG
        /// <summary>
        /// Flag you can (temporarily) enable to save failed test recordings
        /// and debug/re-run at the point of failure without re-running
        /// potentially lengthy live tests.  This should never be checked in
        /// and will be compiled out of release builds to help make that easier
        /// to spot.
        /// </summary>
        public bool SaveDebugRecordingsOnFailure { get; set; } = false;
#endif
        public ClientTestBase(bool isAsync)
        {
            IsAsync = isAsync;
        }
        protected ValueTask<Response<T>> WaitForCompletionAsync<T>(Operation<T> operation)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return operation.WaitForCompletionAsync(TimeSpan.FromSeconds(0), default);
            }
            else
            {
                return operation.WaitForCompletionAsync();
            }
        }

        protected TClient CreateClient<TClient>(params object[] args) where TClient : class
        {
            return InstrumentClient((TClient)Activator.CreateInstance(typeof(TClient), args));
        }

        public TClient InstrumentClient<TClient>(TClient client) where TClient : class => (TClient)InstrumentClient(typeof(TClient), client, null);

        protected TClient InstrumentClient<TClient>(TClient client, IEnumerable<IInterceptor> preInterceptors) where TClient : class => (TClient)InstrumentClient(typeof(TClient), client, preInterceptors);

        internal object InstrumentClient(Type clientType, object client, IEnumerable<IInterceptor> preInterceptors)
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
