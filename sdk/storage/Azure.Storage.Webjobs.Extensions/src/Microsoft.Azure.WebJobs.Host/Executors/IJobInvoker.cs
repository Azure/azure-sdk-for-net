// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host
{
    internal interface IJobInvoker
    {
        /// <summary>
        /// Calls a job method.
        /// </summary>
        /// <param name="name">The name of the function to call.</param>
        /// <param name="arguments">The argument names and values to bind to parameters in the job method. In addition to parameter values, these may also include binding data values. </param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> that will call the job method.</returns>
        Task CallAsync(
            string name, 
            IDictionary<string, object> arguments = null,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
