﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Interface that helps mock invoking a process and getting the result from standard output and error streams. 
    /// </summary>
    internal interface IProcessManager
    {
        Task<string> ExecuteAsync(Process process, CancellationToken cancellationToken);
    }
}
