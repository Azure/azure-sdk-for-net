// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.DAG;
using System.Threading;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions
{
    /// <summary>
    /// The base class for all executable model.
    /// </summary>
    /// <typeparam name="IFluentResourceT">The fluent model type representing the executable</typeparam>
    public abstract class Executable<IFluentResourceT> :
                Indexable, IExecutable<IFluentResourceT>
    {
        protected Executable()
        {
        }

        public abstract Task<IFluentResourceT> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true);

        public IFluentResourceT Execute()
        {
            return Extensions.Synchronize(() => ExecuteAsync(CancellationToken.None));
        }
    }
}
