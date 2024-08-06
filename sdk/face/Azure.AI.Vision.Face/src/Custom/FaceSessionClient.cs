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
        /// <remarks>
        /// A session is best for client device scenarios where developers want to authorize a client device to perform only a liveness detection without granting full access to their resource. Created sessions have a limited life span and only authorize clients to perform the desired action before access is expired.
        ///
        /// Permissions includes...
        /// &gt;
        /// *
        ///   * Ability to call /detectLivenessWithVerify/singleModal for up to 3 retries.
        ///   * A token lifetime of 10 minutes.
        ///
        /// &gt; [!NOTE]
        /// &gt;
        /// &gt; *
        /// &gt;   * Client access can be revoked by deleting the session using the Delete Liveness With Verify Session operation.
        /// &gt;   * To retrieve a result, use the Get Liveness With Verify Session.
        /// &gt;   * To audit the individual requests that a client has made to your resource, use the List Liveness With Verify Session Audit Entries.
        ///
        /// Recommended Option: VerifyImage is provided during session creation.
        /// Alternative Option: Client device submits VerifyImage during the /detectLivenessWithVerify/singleModal call.
        /// &gt; [!NOTE]
        /// &gt; Extra measures should be taken to validate that the client is sending the expected VerifyImage.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<CreateLivenessWithVerifySessionResult>> CreateLivenessWithVerifySessionAsync(CreateLivenessWithVerifySessionJsonContent jsonContent, Stream verifyImage, CancellationToken cancellationToken = default)
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
        /// <remarks>
        /// A session is best for client device scenarios where developers want to authorize a client device to perform only a liveness detection without granting full access to their resource. Created sessions have a limited life span and only authorize clients to perform the desired action before access is expired.
        ///
        /// Permissions includes...
        /// &gt;
        /// *
        ///   * Ability to call /detectLivenessWithVerify/singleModal for up to 3 retries.
        ///   * A token lifetime of 10 minutes.
        ///
        /// &gt; [!NOTE]
        /// &gt;
        /// &gt; *
        /// &gt;   * Client access can be revoked by deleting the session using the Delete Liveness With Verify Session operation.
        /// &gt;   * To retrieve a result, use the Get Liveness With Verify Session.
        /// &gt;   * To audit the individual requests that a client has made to your resource, use the List Liveness With Verify Session Audit Entries.
        ///
        /// Recommended Option: VerifyImage is provided during session creation.
        /// Alternative Option: Client device submits VerifyImage during the /detectLivenessWithVerify/singleModal call.
        /// &gt; [!NOTE]
        /// &gt; Extra measures should be taken to validate that the client is sending the expected VerifyImage.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<CreateLivenessWithVerifySessionResult> CreateLivenessWithVerifySession(CreateLivenessWithVerifySessionJsonContent jsonContent, Stream verifyImage, CancellationToken cancellationToken = default)
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
