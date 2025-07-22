// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.AI.Projects
{
    /// <summary></summary>
    public partial class Datasets
    {
        internal PipelineMessage CreateDeleteRequest(string name, string version, RequestOptions options)
        {
            PipelineMessage message = Pipeline.CreateMessage();
            // # TODO: Uncomment this line when the server supports 204 No Content response.
            // message.ResponseClassifier = PipelineMessageClassifier204;
            PipelineRequest request = message.Request;
            request.Method = "DELETE";
            ClientUriBuilder uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datasets/", false);
            uri.AppendPath(name, true);
            uri.AppendPath("/versions/", false);
            uri.AppendPath(version, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }
    }
}
