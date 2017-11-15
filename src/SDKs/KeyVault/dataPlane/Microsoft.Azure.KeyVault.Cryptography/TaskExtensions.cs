//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

#if FullNetFx

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.KeyVault.Cryptography
{
    internal static class TaskException
    {
        /// <summary>
        /// Downlevel support for tasks that throw.
        /// </summary>
        /// <typeparam name="T">The parameterized type of the Task</typeparam>
        /// <param name="ex">The exception result.</param>
        /// <returns>A Task.</returns>
        internal static Task<T> FromException<T>( Exception ex )
        {
            var source = new TaskCompletionSource<T>();

            source.SetException( ex );

            return source.Task;
        }
    }
}

#endif