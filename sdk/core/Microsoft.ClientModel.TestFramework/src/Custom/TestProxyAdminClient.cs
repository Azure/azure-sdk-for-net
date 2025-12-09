// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.TestProxy.Admin;

public partial class TestProxyAdminClient
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="recordingId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    public virtual async Task<ClientResult> AddContentDispositionFilePathSanitizer(string? recordingId = default, CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = Pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        PipelineRequest request = message.Request;
        request.Method = "POST";
        ClientUriBuilder uri = new();
        uri.Reset(_endpoint);
        uri.AppendPath("/Admin/AddSanitizer", false);
        request.Uri = uri.ToUri();
        if (recordingId != null)
        {
            request.Headers.Set("x-recording-id", recordingId);
        }
        request.Headers.Set("Content-Type", "application/json");
        request.Headers.Set("Accept", "application/json");
        request.Headers.Set("x-abstraction-identifier", "ContentDispositionFilePathSanitizer");
        message.Apply(new RequestOptions());

        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, null).ConfigureAwait(false));
    }
}
