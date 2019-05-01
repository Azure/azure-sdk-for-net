// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Castle.DynamicProxy;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class ClientTestBase
    {
        private static readonly ProxyGenerator _proxyGenerator = new ProxyGenerator();

        private static readonly UseSyncMethodsInterceptor _interceptor = new UseSyncMethodsInterceptor();


        public bool IsAsync { get; }

        public ClientTestBase(bool isAsync)
        {
            IsAsync = isAsync;
        }

        public virtual TClient CreateClient<TClient>(params object[] args) where TClient: class
        {

            return WrapClient((TClient)Activator.CreateInstance(typeof(TClient), args));
        }

        public virtual TClient WrapClient<TClient>(TClient client) where TClient: class
        {
            if (ClientValidation<TClient>.Validated == false)
            {
                foreach (var methodInfo in typeof(TClient).GetMethods(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (methodInfo.Name.EndsWith("Async") && !methodInfo.IsVirtual)
                    {
                        ClientValidation<TClient>.ValidationException = new InvalidOperationException($"Client type contains public non-virtual async method {methodInfo.Name}");
                    }
                }

                ClientValidation<TClient>.Validated = true;
            }

            if (ClientValidation<TClient>.ValidationException != null)
            {
                throw ClientValidation<TClient>.ValidationException;
            }

            return !IsAsync ? _proxyGenerator.CreateClassProxyWithTarget(client, _interceptor) : client;
        }


        private static class ClientValidation<TClient>
        {
            public static bool Validated;

            public static Exception ValidationException;
        }
    }
}
