// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("CopyAuthorization")]
    public partial class DocumentModelCopyAuthorization
    {
        /// <summary> Initializes a new instance of CopyAuthorization. </summary>
        /// <param name="targetResourceId"> ID of the target Azure resource where the model should be copied to. </param>
        /// <param name="targetResourceRegion"> Location of the target Azure resource where the model should be copied to. </param>
        /// <param name="targetModelId"> Identifier of the target model. </param>
        /// <param name="targetModelLocation"> URI of the copied model in the target account. </param>
        /// <param name="accessToken"> Token used to authorize the request. </param>
        /// <param name="expiresOn"> Date/time when the access token expires. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetResourceId"/>, <paramref name="targetResourceRegion"/>, <paramref name="targetModelId"/>, <paramref name="targetModelLocation"/> or <paramref name="accessToken"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="targetResourceId"/>, <paramref name="targetResourceRegion"/>, <paramref name="targetModelId"/> or <paramref name="accessToken"/> is empty. </exception>
        public DocumentModelCopyAuthorization(string targetResourceId, string targetResourceRegion, string targetModelId, Uri targetModelLocation, string accessToken, DateTimeOffset expiresOn)
        {
            Argument.AssertNotNullOrEmpty(targetResourceId, nameof(targetResourceId));
            Argument.AssertNotNullOrEmpty(targetResourceRegion, nameof(targetResourceRegion));
            Argument.AssertNotNullOrEmpty(targetModelId, nameof(targetModelId));
            Argument.AssertNotNull(targetModelLocation, nameof(targetModelLocation));
            Argument.AssertNotNullOrEmpty(accessToken, nameof(accessToken));

            TargetResourceId = targetResourceId;
            TargetResourceRegion = targetResourceRegion;
            TargetModelId = targetModelId;
            TargetModelLocation = targetModelLocation;
            AccessToken = accessToken;
            ExpiresOn = expiresOn;
        }

        /// <summary> Location of the target Azure resource where the model should be copied to. </summary>
        public string TargetResourceRegion { get; }

         /// <summary> Identifier of the target model. </summary>
         public string TargetModelId { get; }

        /// <summary> URI of the copied model in the target account. </summary>
        public Uri TargetModelLocation { get; }

        /// <summary> Date/time when the access token expires. </summary>
        [CodeGenMember("ExpirationDateTime")]
        public DateTimeOffset ExpiresOn { get; }

        /// <summary> Token used to authorize the request. </summary>
        public string AccessToken { get; }

        /// <summary> ID of the target Azure resource where the model should be copied to. </summary>
        public string TargetResourceId { get; }
    }
}
