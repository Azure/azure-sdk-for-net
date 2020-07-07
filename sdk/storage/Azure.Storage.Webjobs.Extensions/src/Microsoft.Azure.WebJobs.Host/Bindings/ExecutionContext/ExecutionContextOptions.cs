// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    public class ExecutionContextOptions
    {
        /// <summary>
        /// The application directory to be used when creating <see cref="ExecutionContext"/> instances.
        /// </summary>
        public string AppDirectory { get; set; }
    }
}