// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.TestProxy.Admin;

public partial class TestProxyAdminClient
{
    /// <summary>
    /// Adds a ContentDispositionFilePathSanitizer to the test proxy. If a recording ID is provided,
    /// the sanitizer will only be added for that session. Otherwise, it will be set globally.
    /// </summary>
    /// <param name="recordingId">The recording ID for the test recording.</param>
    /// <param name="cancellationToken">The cancellation token that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    public virtual async Task<ClientResult> AddContentDispositionFilePathSanitizer(string? recordingId = default, CancellationToken cancellationToken = default)
    {
        using BinaryContent content = BinaryContentHelper.FromEnumerable(new[]
         {
            new Dictionary<string, object>
            {
                ["Name"] = "ContentDispositionFilePathSanitizer",
                ["Body"] = new Dictionary<string, object>()
            }
        });

        return await AddSanitizersAsync(content, recordingId, new RequestOptions() { CancellationToken = cancellationToken }).ConfigureAwait(false);
    }
}
