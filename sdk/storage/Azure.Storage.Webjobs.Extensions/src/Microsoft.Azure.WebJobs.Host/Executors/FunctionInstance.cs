// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class FunctionInstance : IFunctionInstance
    {
        public FunctionInstance(Guid id, IDictionary<string, string> triggerDetails, Guid? parentId, ExecutionReason reason, IBindingSource bindingSource,
            IFunctionInvoker invoker, FunctionDescriptor functionDescriptor)
        {
            Id = id;
            TriggerDetails = triggerDetails;
            ParentId = parentId;
            Reason = reason;
            BindingSource = bindingSource;
            Invoker = invoker;
            FunctionDescriptor = functionDescriptor;
        }

        public Guid Id { get; }

        public IDictionary<string, string> TriggerDetails { get; }

        public Guid? ParentId { get; }

        public ExecutionReason Reason { get; }

        public IBindingSource BindingSource { get; }

        public IFunctionInvoker Invoker { get; }

        public FunctionDescriptor FunctionDescriptor { get; }
    }
}
