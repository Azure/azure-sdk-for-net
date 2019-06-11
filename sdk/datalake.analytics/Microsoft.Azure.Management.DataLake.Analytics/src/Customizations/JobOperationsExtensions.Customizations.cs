// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.DataLake.Analytics
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure.OData;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for JobOperations.
    /// </summary>
    public static partial class JobOperationsExtensions
    {
            /// <summary>
            /// Tests the existence of job information for the specified job ID.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accountName'>
            /// The Azure Data Lake Analytics account to execute job operations on.
            /// </param>
            /// <param name='jobIdentity'>
            /// JobInfo ID to test the existence of.
            /// </param>
            public static bool Exists(this IJobOperations operations, string accountName, Guid jobIdentity)
            {
                return Task.Factory.StartNew(s => ((IJobOperations)s).ExistsAsync(accountName, jobIdentity), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Tests the existence of job information for the specified job ID.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accountName'>
            /// The Azure Data Lake Analytics account to execute job operations on.
            /// </param>
            /// <param name='jobIdentity'>
            /// JobInfo ID to test the existence of.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<bool> ExistsAsync(this IJobOperations operations, string accountName, Guid jobIdentity, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ExistsWithHttpMessagesAsync(accountName, jobIdentity, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }
    }
}
