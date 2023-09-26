// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Core;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public partial class MessagePipelineTransport : PipelineTransport<PipelineMessage>, IDisposable
{
    private sealed class MessagePipelineMessage : PipelineMessage
    {
        // TODO: should these be readonly?
        private PipelineRequest _request;
        private ResponseErrorClassifier _classifier;

        private PipelineResponse? _response;

        public MessagePipelineMessage(PipelineRequest request, ResponseErrorClassifier classifier) : base(request, classifier)
        {
            _request = request;
            _classifier = classifier;
        }
        public override PipelineRequest PipelineRequest
        {
            get => _request;
            set => _request = value;
        }

        public override PipelineResponse? PipelineResponse
        {
            get => _response;
            set => _response = value;
        }

        public override ResponseErrorClassifier ResponseErrorClassifier
        {
            get => _classifier;
            set => _classifier = value;
        }

        public override void Dispose()
        {
            // TODO: implement Dispose pattern properly
            _request.Dispose();

            // TODO: should response be disposable?
        }
    }
}
