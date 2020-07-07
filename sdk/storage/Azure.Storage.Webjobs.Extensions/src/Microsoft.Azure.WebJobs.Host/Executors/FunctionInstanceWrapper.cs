// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class FunctionInstanceWrapper : IFunctionInstanceEx, IDisposable
    {
        private readonly IFunctionInstance _instance;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private IServiceScope _instanceServicesScope;
        private IServiceProvider _instanceServices;

        public FunctionInstanceWrapper(IFunctionInstance instance, IServiceScopeFactory serviceScopeFactory)
        {
            _instance = instance;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Guid Id => _instance.Id;

        public IDictionary<string, string> TriggerDetails => _instance.TriggerDetails;

        public Guid? ParentId => _instance.ParentId;

        public ExecutionReason Reason => _instance.Reason;

        public IBindingSource BindingSource => _instance.BindingSource;

        public IFunctionInvoker Invoker => _instance.Invoker;

        public FunctionDescriptor FunctionDescriptor => _instance.FunctionDescriptor;

        public IServiceProvider InstanceServices
        {
            get
            {
                if (_instanceServicesScope == null && _serviceScopeFactory != null)
                {
                    _instanceServicesScope = _serviceScopeFactory.CreateScope();
                    _instanceServices = _instanceServicesScope.ServiceProvider;
                }

                return _instanceServices;
            }
        }

        public void Dispose()
        {
            if (_instanceServicesScope != null)
            {
                _instanceServicesScope.Dispose();
            }

            _instanceServicesScope = null;
            _instanceServices = null;
        }
    }
}