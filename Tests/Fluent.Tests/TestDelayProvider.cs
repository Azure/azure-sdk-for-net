// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Test.HttpRecorder;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Tests
{
    public class TestDelayProvider : DelayProvider
    {
        public async override Task DelayAsync(int milliseconds, CancellationToken cancellationToken)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                await base.DelayAsync(milliseconds, cancellationToken);
            }
        }
    }
}