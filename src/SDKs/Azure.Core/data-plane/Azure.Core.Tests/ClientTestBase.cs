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
    public class ClientTestBase<TClient> where TClient : class
    {
        private static readonly ProxyGenerator _proxyGenerator = new ProxyGenerator();

        private static readonly UseSyncMethodsInterceptor _interceptor = new UseSyncMethodsInterceptor();

        private static bool _validated;

        private static Exception _validationException;

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
            if (_validated == false)
            {
                foreach (var methodInfo in typeof(TClient).GetMethods(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (methodInfo.Name.EndsWith("Async") && !methodInfo.IsVirtual)
                    {
                        _validationException = new InvalidOperationException($"Client type contains public non-virtual async method {methodInfo.Name}");
                    }
                }

                _validated = true;
            }

            if (_validationException != null)
            {
                throw _validationException;
            }

            return !IsAsync ? _proxyGenerator.CreateClassProxyWithTarget(t, _interceptor) : t;
        }
    }
}
