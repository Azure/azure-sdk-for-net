// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Castle.DynamicProxy;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class ClientTestBase<TClient> where TClient : class
    {
        private static readonly ProxyGenerator _proxyGenerator = new ProxyGenerator();

        private static readonly UseSyncMethodsInterceptor _interceptor = new UseSyncMethodsInterceptor();

        public bool IsAsync { get; }

        public ClientTestBase(bool isAsync)
        {
            IsAsync = isAsync;
        }

        public virtual TClient CreateClient(params object[] args)
        {
            return WrapClient((TClient)Activator.CreateInstance(typeof(TClient), args));
        }

        public virtual TClient WrapClient(TClient t)
        {
            return !IsAsync ? _proxyGenerator.CreateClassProxyWithTarget(t, _interceptor) : t;
        }
    }

    public abstract class PolicyTestBase
    {
        protected static Task<Response> SendGetRequest(HttpPipelineTransport transport, HttpPipelinePolicy policy, ResponseClassifier responseClassifier = null)
        {
            Assert.IsInstanceOf<SynchronousHttpPipelinePolicy>(policy, "Use SyncAsyncPolicyTestBase base type for non-sync policies");

            using (Request request = transport.CreateRequest(null))
            {
                request.Method = HttpPipelineMethod.Get;
                request.UriBuilder.Uri = new Uri("http://example.com");
                var pipeline = new HttpPipeline(transport, new [] { policy }, responseClassifier);
                return pipeline.SendRequestAsync(request, CancellationToken.None);
            }
        }
    }
}
