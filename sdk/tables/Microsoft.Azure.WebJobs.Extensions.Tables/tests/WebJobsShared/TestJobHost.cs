// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    public class JobHost<TProgram> : JobHost
    {
        public JobHost(
            IOptions<JobHostOptions> options,
            IJobHostContextFactory contextFactory)
            : base(options, contextFactory)
        {
        }
        public async Task CallAsync(string methodName, object arguments = null)
        {
            await base.CallAsync(methodName, arguments).ConfigureAwait(false);
        }
        public async Task CallAsync(string methodName, IDictionary<string, object> arguments)
        {
            await base.CallAsync(typeof(TProgram).GetMethod(methodName), arguments).ConfigureAwait(false);
        }
        // Helper for quickly testing indexing errors
    }
}