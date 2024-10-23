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
                return await CreateLivenessWithVerifySessionAsync(jsonContent, cancellationToken).ConfigureAwait(false);
            }

            CreateLivenessWithVerifySessionMultipartContent multipartContent = new CreateLivenessWithVerifySessionMultipartContent(jsonContent, verifyImage);
            return await CreateLivenessWithVerifySessionWithVerifyImageAsync(multipartContent, cancellationToken).ConfigureAwait(false);
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
                return CreateLivenessWithVerifySession(jsonContent, cancellationToken);
            }

            CreateLivenessWithVerifySessionMultipartContent multipartContent = new CreateLivenessWithVerifySessionMultipartContent(jsonContent, verifyImage);
            return CreateLivenessWithVerifySessionWithVerifyImage(multipartContent, cancellationToken);
        }
    }
}
