// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Text.Json;

[assembly:CodeGenSuppressType("ContainerServiceArmOperationOfT")]
namespace Azure.ResourceManager.ContainerService
{
#pragma warning disable SA1649 // File name should match first type name
    internal class ContainerServiceArmOperation<T> : ArmOperation<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly OperationInternal<T> _operation;

        /// <summary> Initializes a new instance of ContainerServiceArmOperation for mocking. </summary>
        protected ContainerServiceArmOperation()
        {
        }

        internal ContainerServiceArmOperation(Response<T> response)
        {
            var serializeOptions = new JsonSerializerOptions { Converters = { new NextLinkOperationImplementation.StreamConverter() } };
            var lroDetails = new Dictionary<string, string>()
            {
                ["InitialResponse"] = BinaryData.FromObjectAsJson<Response>(response.GetRawResponse(), serializeOptions).ToString()
            };
            var lroData = BinaryData.FromObjectAsJson(lroDetails);
            Id = Convert.ToBase64String(lroData.ToArray());
            _operation = OperationInternal<T>.Succeeded(response.GetRawResponse(), response.Value);
        }

        internal ContainerServiceArmOperation(IOperationSource<T> source, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, string interimApiVersion = null)
        {
            var nextLinkOperation = NextLinkOperationImplementation.Create(source, pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia, out var id, interimApiVersion);
            Id = id;
            _operation = new OperationInternal<T>(clientDiagnostics, nextLinkOperation, response, "ContainerServiceArmOperation", fallbackStrategy: new ExponentialDelayStrategy());
        }

        internal ContainerServiceArmOperation(IOperationSource<T> source, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string id, string interimApiVersion = null)
        {
            var lroDetails = BinaryData.FromBytes(Convert.FromBase64String(id)).ToObjectFromJson<Dictionary<string, string>>();
            lroDetails.TryGetValue("NextRequestUri", out string nextRequestUri);
            IDictionary<string, object> responseObj = BinaryData.FromString(lroDetails["InitialResponse"]).ToObjectFromJson<IDictionary<string, object>>();
            var content = BinaryData.FromObjectAsJson(responseObj["ContentStream"]);
            var contentStream = new MemoryStream();
            if (content != null)
                content.ToStream().CopyTo(contentStream);
            Response response = new ContainerServiceArmOperation.ContainerServiceResponse(((JsonElement)responseObj["Status"]).GetInt32(), ((JsonElement)responseObj["ReasonPhrase"]).GetString(), contentStream, ((JsonElement)responseObj["ClientRequestId"]).GetString());
            if (nextRequestUri == null)
            {
                Id = id;
                _operation = OperationInternal<T>.Succeeded(response, source.CreateResult(response, CancellationToken.None));
                return;
            }
            Uri.TryCreate(lroDetails["InitialUri"], UriKind.Absolute, out var startRequestUri);
            RequestMethod requestMethod = new RequestMethod(lroDetails["RequestMethod"]);
            bool originalResponseHasLocation = bool.Parse(lroDetails["OriginalResponseHasLocation"]);
            string lastKnownLocation = lroDetails["LastKnownLocation"];
            if (!Enum.TryParse(lroDetails["FinalStateVia"], out OperationFinalStateVia finalStateVia))
                finalStateVia = OperationFinalStateVia.Location;

            var nextLinkOperation = NextLinkOperationImplementation.Create(source, pipeline, requestMethod, startRequestUri, response, finalStateVia, nextRequestUri, lroDetails["HeaderSource"], originalResponseHasLocation, lastKnownLocation, interimApiVersion);
            Id = id;
            _operation = new OperationInternal<T>(clientDiagnostics, nextLinkOperation, response, "ContainerServiceArmOperation", fallbackStrategy: new ExponentialDelayStrategy());
        }

        /// <inheritdoc />
        public override string Id { get; }

        /// <inheritdoc />
        public override T Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.RawResponse;

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override Response<T> WaitForCompletion(CancellationToken cancellationToken = default) => _operation.WaitForCompletion(cancellationToken);

        /// <inheritdoc />
        public override Response<T> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletion(pollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
