// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.Vision.Face
{
    /// <summary> The FaceSession service client. </summary>
    public partial class FaceSessionClient
    {
        /// <summary> Create a new liveness session with verify. Provide the verify image during session creation. </summary>
        /// <param name="jsonContent"> Parameters for liveness with verify session creation. </param>
        /// <param name="verifyImage"> Image binary data for verify image, can be provided as session creation time or during the /detectLivenessWithVerify/singleModal  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jsonContent"/> is null. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/liveness-session-operations/create-liveness-with-verify-session-with-verify-image for more details. </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<LivenessWithVerifySession>> CreateLivenessWithVerifySessionAsync(CreateLivenessWithVerifySessionContent jsonContent, Stream verifyImage, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jsonContent, nameof(jsonContent));

            if (verifyImage == null)
            {
                // If no verify image is provided, fall back to regular liveness session creation
                // Note: This returns a different type (LivenessSession instead of LivenessWithVerifySession)
                // but maintains backward compatibility for the case where verifyImage was null
                var livenessContent = new CreateLivenessSessionContent(jsonContent.LivenessOperationMode)
                {
                    DeviceCorrelationIdSetInClient = jsonContent.DeviceCorrelationIdSetInClient,
                    EnableSessionImage = jsonContent.EnableSessionImage,
                    LivenessModelVersion = jsonContent.LivenessModelVersion,
                    DeviceCorrelationId = jsonContent.DeviceCorrelationId,
                    AuthTokenTimeToLiveInSeconds = jsonContent.AuthTokenTimeToLiveInSeconds
                };

                Response<LivenessSession> livenessResult = await CreateLivenessSessionAsync(livenessContent, cancellationToken).ConfigureAwait(false);
                // Note: We need to convert LivenessSession to LivenessWithVerifySession or handle this differently
                // For now, use the protocol method approach
                var requestContent = RequestContent.Create(livenessContent);
                Response result = await CreateLivenessWithVerifySessionAsync(requestContent, "application/json", cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null).ConfigureAwait(false);
                return Response.FromValue((LivenessWithVerifySession)result, result);
            }

            // Create content with the provided verify image
            var contentWithImage = new CreateLivenessWithVerifySessionContent(jsonContent.LivenessOperationMode, BinaryData.FromStream(verifyImage))
            {
                DeviceCorrelationIdSetInClient = jsonContent.DeviceCorrelationIdSetInClient,
                EnableSessionImage = jsonContent.EnableSessionImage,
                LivenessModelVersion = jsonContent.LivenessModelVersion,
                ReturnVerifyImageHash = jsonContent.ReturnVerifyImageHash,
                VerifyConfidenceThreshold = jsonContent.VerifyConfidenceThreshold,
                DeviceCorrelationId = jsonContent.DeviceCorrelationId,
                AuthTokenTimeToLiveInSeconds = jsonContent.AuthTokenTimeToLiveInSeconds
            };

            // Use the protocol method to create the session with verify
            var requestContentWithImage = RequestContent.Create(contentWithImage);
            Response resultWithImage = await CreateLivenessWithVerifySessionAsync(requestContentWithImage, "application/json", cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null).ConfigureAwait(false);
            return Response.FromValue((LivenessWithVerifySession)resultWithImage, resultWithImage);
        }

        /// <summary> Create a new liveness session with verify. Provide the verify image during session creation. </summary>
        /// <param name="jsonContent"> Parameters for liveness with verify session creation. </param>
        /// <param name="verifyImage"> Image binary data for verify image, can be provided as session creation time or during the /detectLivenessWithVerify/singleModal  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jsonContent"/> is null. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/liveness-session-operations/create-liveness-with-verify-session-with-verify-image for more details. </remarks>
        [ForwardsClientCalls]
        public virtual Response<LivenessWithVerifySession> CreateLivenessWithVerifySession(CreateLivenessWithVerifySessionContent jsonContent, Stream verifyImage, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jsonContent, nameof(jsonContent));

            if (verifyImage == null)
            {
                // If no verify image is provided, fall back to regular liveness session creation
                var livenessContent = new CreateLivenessSessionContent(jsonContent.LivenessOperationMode)
                {
                    DeviceCorrelationIdSetInClient = jsonContent.DeviceCorrelationIdSetInClient,
                    EnableSessionImage = jsonContent.EnableSessionImage,
                    LivenessModelVersion = jsonContent.LivenessModelVersion,
                    DeviceCorrelationId = jsonContent.DeviceCorrelationId,
                    AuthTokenTimeToLiveInSeconds = jsonContent.AuthTokenTimeToLiveInSeconds
                };

                // Use the protocol method approach
                var requestContent = RequestContent.Create(livenessContent);
                Response result = CreateLivenessWithVerifySession(requestContent, "application/json", cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null);
                return Response.FromValue((LivenessWithVerifySession)result, result);
            }

            // Create content with the provided verify image
            var contentWithImage = new CreateLivenessWithVerifySessionContent(jsonContent.LivenessOperationMode, BinaryData.FromStream(verifyImage))
            {
                DeviceCorrelationIdSetInClient = jsonContent.DeviceCorrelationIdSetInClient,
                EnableSessionImage = jsonContent.EnableSessionImage,
                LivenessModelVersion = jsonContent.LivenessModelVersion,
                ReturnVerifyImageHash = jsonContent.ReturnVerifyImageHash,
                VerifyConfidenceThreshold = jsonContent.VerifyConfidenceThreshold,
                DeviceCorrelationId = jsonContent.DeviceCorrelationId,
                AuthTokenTimeToLiveInSeconds = jsonContent.AuthTokenTimeToLiveInSeconds
            };

            // Use the protocol method to create the session with verify
            var requestContentWithImage = RequestContent.Create(contentWithImage);
            Response resultWithImage = CreateLivenessWithVerifySession(requestContentWithImage, "application/json", cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null);
            return Response.FromValue((LivenessWithVerifySession)resultWithImage, resultWithImage);
        }
    }
}
