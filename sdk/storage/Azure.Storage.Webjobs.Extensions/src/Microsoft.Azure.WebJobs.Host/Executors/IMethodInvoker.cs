// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal interface IMethodInvoker<TReflected, TReturnValue>
    {
        // The cancellation token, if any, is provided along with the other arguments.
        Task<TReturnValue> InvokeAsync(TReflected instance, object[] arguments);
    }
}
