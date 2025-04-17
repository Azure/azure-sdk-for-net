// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using Azure.IoT.DeviceOnboarding.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Threading.Tasks;
using Azure.IoT.DeviceOnboarding.Models.Providers;
using System.Diagnostics.CodeAnalysis;

namespace Azure.IoT.DeviceOnboarding
{
    /// <summary>
    /// Http Client and Methods Provider
    /// </summary>
    [SuppressMessage("Azure Analysis", "AZC0007", Justification = "Analyzer is incorrectly flagging the constructor for mocking.")]
    public abstract class FDOClient: DeviceOnboardingClient
    {
        #region Private variables
        internal string _serverUrl;

        /// <summary>
        /// Constant for Cbor Media Type
        /// </summary>
        private const string CborMediaType = "application/cbor";

        /// <summary>
        /// Error Code
        /// </summary>
        private const int _errorCode = 255;

        /// <summary>
        /// Client Version
        /// </summary>
        private readonly string _clientVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for mocking FDOClient
        /// </summary>
        public FDOClient() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FDOClient"/> class.
        /// </summary>
        /// <param name="cborConverter"></param>
        /// <param name="credProvider"></param>
        public FDOClient(CBORConverterProvider cborConverter, DeviceCredentialProvider credProvider): base(cborConverter, credProvider) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FDOClient"/> class.
        /// </summary>
        /// <param name="cborConverter"></param>
        /// <param name="credProvider"></param>
        /// <param name="options"></param>
        public FDOClient(CBORConverterProvider cborConverter, DeviceCredentialProvider credProvider, DeviceOnboardingClientOptions options)
            : base (cborConverter, credProvider, options) { }
        #endregion

        #region Internal Methods

        /// <summary>
        /// Send Message to Server and Construct Response Message
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response Message</returns>
        internal async Task<ProtocolMessage> SendMessage(ProtocolMessage request)
        {
            Console.WriteLine("Sending message");
            using var response = await Send(request.Url, request.Payload, CborMediaType, request.AuthorizationToken).ConfigureAwait(false);
            Console.WriteLine("Response is sent {req}");
            var responseMessage = new ProtocolMessage();

            if (request.MessageType == _errorCode)
            {
                return responseMessage;
            }

            if (response == null || response.Content == null)
            {
                // Only Scenario Content is null is when service is responding to a client Error Request
                throw new RequestFailedException("Unexpected null response returned by the server");
            }

            responseMessage.Payload = response.Content.ToArray();

            if (!response.IsError)
            {
                var errorDetails = this._CBORConverterProvider.Deserialize<ErrorMessage>(responseMessage.Payload);
                var errorMessage = $"Received an error from server at {errorDetails.TimeStamp} with FDO Error Code {errorDetails.ErrorCode} , Correlation ID {errorDetails.CorrelationID} and ErrorMessage {errorDetails.Message}";
                throw new RequestFailedException(errorMessage);
            }

            response.Headers.TryGetValue("message-type", out var msgType);
            if (!int.TryParse(msgType, out var messageType))
            {
                throw new RequestFailedException($"Invalid message type {msgType} sent by the server");
            }

            responseMessage.MessageType = messageType;
            response.Headers.TryGetValues("Authorization", out var authTokens);
            if (authTokens != null)
            {
                responseMessage.AuthorizationToken = authTokens.FirstOrDefault();
            }
            else
            {
                responseMessage.AuthorizationToken = string.Empty;
            }

            return responseMessage;
        }

        /// <summary>
        /// Http Send
        /// </summary>
        /// <param name="url">Url for the request</param>
        /// <param name="content">Request Content</param>
        /// <param name="mediaType">Media Type for Header</param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        internal async Task<Response> Send(string url, byte[] content, string mediaType, string authToken)
        {
            HttpPipeline pipeline = HttpPipelineBuilder.Build(this.options);
            using (Request request = pipeline.CreateRequest())
            {
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri(url));
                request.Content = RequestContent.Create(content);
                request.Headers.Add(new HttpHeader(HttpHeader.Names.ContentType, mediaType));
                request.Headers.Add(new HttpHeader(HttpHeader.Names.UserAgent, new ProductInfoHeaderValue("FDOAgentVersion", _clientVersion).ToString()));
                if (!string.IsNullOrEmpty(authToken))
                {
                    request.Headers.Add(new HttpHeader(HttpHeader.Names.Authorization, authToken));
                }
                return await pipeline.SendRequestAsync(request, new System.Threading.CancellationToken()).ConfigureAwait(false);
            }
        }
        internal void AssertMessageType(int actualType, TOMessageTypes expectedType)
        {
            if ((int)expectedType != actualType)
            {
                throw new Exception($"Invalid message type sent by server expected {expectedType} actual {actualType}");
            }
        }

        internal ProtocolMessage ValidateAndSendRequestMessage(ProtocolMessage RequestMessage, ProtocolMessage previousResponse = null)
        {
            Console.WriteLine(RequestMessage.Url);
            Console.WriteLine(RequestMessage.MessageType);
            var actualMsgType = RequestMessage.MessageType;

            if (previousResponse != null && !string.IsNullOrEmpty(previousResponse.AuthorizationToken)
                && !actualMsgType.Equals(TOMessageTypes.TO1_HelloRV) && !actualMsgType.Equals(TOMessageTypes.TO2_HelloDevice))
            {
                RequestMessage.AuthorizationToken = previousResponse.AuthorizationToken;
            }
            return SendMessage(RequestMessage).Result;
        }

        internal ProtocolMessage ConstructAndSendMessage(TOMessageTypes messageType, byte[] payload)
        {
            var request = new ProtocolMessage()
            {
                MessageType = (int)messageType,
                Payload = payload
            };
            request.Url = ConstructFullURL(messageType);
            return ValidateAndSendRequestMessage(request);
        }

        internal string ConstructFullURL(TOMessageTypes messageType)
        {
            var deviceProtocolVersion = this._deviceCredentialProvider.GetDeviceCredentials().DeviceProtocolVersion;
            var url = string.Concat(_serverUrl,
                "/",
                "fdo",
                "/",
                (int)deviceProtocolVersion,
                "/",
                "msg",
                "/",
                (int)messageType);
            return url;
        }
        #endregion
    }
}
