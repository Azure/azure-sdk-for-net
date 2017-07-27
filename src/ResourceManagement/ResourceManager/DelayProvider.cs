// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    public class DelayProvider
    {
        public virtual async Task DelayAsync(int milliseconds, CancellationToken cancellationToken)
        {
            await Task.Delay(milliseconds, cancellationToken);
        }

        public void Delay(int milliseconds)
        {
            Extensions.Synchronize(() => this.DelayAsync(milliseconds, CancellationToken.None));
        }
    }
}
