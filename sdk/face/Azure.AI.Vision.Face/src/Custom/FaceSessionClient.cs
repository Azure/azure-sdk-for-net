// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

// Type alias to maintain backward compatibility
using CreateLivenessWithVerifySessionResult = Azure.AI.Vision.Face.LivenessWithVerifySession;

namespace Azure.AI.Vision.Face
{
    /// <summary> The FaceSession service client. </summary>
    public partial class FaceSessionClient
    {
        /// <summary> Create a new liveness session with verify. Provide the verify image during session creation. </summary>
        /// <param name="jsonContent"> Parameters for liveness with verify session creation. </param>
        /// <param name="verifyImage"> Image binary data for verify image, can be provided as session creation time or during the /detectLivenessWithVerify/singleModal  </param>///
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jsonContent"/> is null. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/liveness-session-operations/create-liveness-with-verify-session-with-verify-image for more details. </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<CreateLivenessWithVerifySessionResult>> CreateLivenessWithVerifySessionAsync(CreateLivenessWithVerifySessionContent jsonContent, Stream verifyImage, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jsonContent, nameof(jsonContent));

            if (verifyImage == null)
            {
                // Create without verify image using protocol method
                using var simpleRequestContent = RequestContent.Create(jsonContent);
                Response result = await CreateLivenessWithVerifySessionAsync(simpleRequestContent, "application/json", cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null).ConfigureAwait(false);
                return Response.FromValue((CreateLivenessWithVerifySessionResult)result, result);
            }

            // Create multipart content with verify image
            using var multipartContent = new MultiPartFormDataBinaryContent();

            // Add the JSON parameters - serialize to JSON string
            var jsonString = System.Text.Json.JsonSerializer.Serialize(jsonContent);
            multipartContent.Add(jsonString, "Parameters");

            // Add the verify image
            multipartContent.Add(verifyImage, "VerifyImage", "VerifyImage", "application/octet-stream");

            // Convert multipart content to RequestContent
            using var memoryStream = new MemoryStream();
            multipartContent.WriteTo(memoryStream, CancellationToken.None);
            var requestContent = RequestContent.Create(BinaryData.FromBytes(memoryStream.ToArray()));

            Response resultWithImage = await CreateLivenessWithVerifySessionAsync(requestContent, multipartContent.ContentType, cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null).ConfigureAwait(false);
            return Response.FromValue((CreateLivenessWithVerifySessionResult)resultWithImage, resultWithImage);
        }

        /// <summary> Create a new liveness session with verify. Provide the verify image during session creation. </summary>
        /// <param name="jsonContent"> Parameters for liveness with verify session creation. </param>
        /// <param name="verifyImage"> Image binary data for verify image, can be provided as session creation time or during the /detectLivenessWithVerify/singleModal  </param>///
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jsonContent"/> is null. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/liveness-session-operations/create-liveness-with-verify-session-with-verify-image for more details. </remarks>
        [ForwardsClientCalls]
        public virtual Response<CreateLivenessWithVerifySessionResult> CreateLivenessWithVerifySession(CreateLivenessWithVerifySessionContent jsonContent, Stream verifyImage, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jsonContent, nameof(jsonContent));

            if (verifyImage == null)
            {
                // Create without verify image using protocol method
                using var simpleRequestContent = RequestContent.Create(jsonContent);
                Response result = CreateLivenessWithVerifySession(simpleRequestContent, "application/json", cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null);
                return Response.FromValue((CreateLivenessWithVerifySessionResult)result, result);
            }

            // Create multipart content with verify image
            using var multipartContent = new MultiPartFormDataBinaryContent();

            // Add the JSON parameters - serialize to JSON string
            var jsonString = System.Text.Json.JsonSerializer.Serialize(jsonContent);
            multipartContent.Add(jsonString, "Parameters");

            // Add the verify image
            multipartContent.Add(verifyImage, "VerifyImage", "VerifyImage", "application/octet-stream");

            // Convert multipart content to RequestContent
            using var memoryStream = new MemoryStream();
            multipartContent.WriteTo(memoryStream, CancellationToken.None);
            var requestContent = RequestContent.Create(BinaryData.FromBytes(memoryStream.ToArray()));

            Response resultWithImage = CreateLivenessWithVerifySession(requestContent, multipartContent.ContentType, cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null);
            return Response.FromValue((CreateLivenessWithVerifySessionResult)resultWithImage, resultWithImage);
        }
    }
}
