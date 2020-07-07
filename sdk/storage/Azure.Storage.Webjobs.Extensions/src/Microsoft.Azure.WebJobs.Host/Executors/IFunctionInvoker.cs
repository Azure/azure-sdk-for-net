// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    public interface IFunctionInvoker
    {
        IReadOnlyList<string> ParameterNames { get; }

        // The cancellation token, if any, is provided along with the other arguments.
        // Caller can get an instance via NewInstance(). 
        // Caller is responsible for calling dispose. 
        Task<object> InvokeAsync(object instance, object[] arguments);

        // Create an instance that can be passed into Invoke. 
        // This exists separately so that callers can inspect the instance before it is invoked. 
        object CreateInstance();
    }
}
