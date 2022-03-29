// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("CopyAuthorization")]
    public partial class CopyAuthorization
    {
        /// <summary>
        /// Initializes a new instance of CopyAuthorization. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal CopyAuthorization(string targetResourceRegion, string targetModelId, string targetModelLocation, DateTimeOffset expirationDateTime)
        {
            TargetResourceRegion = targetResourceRegion;
            TargetModelId = targetModelId;
            TargetModelLocation = targetModelLocation;
            ExpirationDateTime = expirationDateTime;
        }

        /// <summary> Initializes a new instance of CopyAuthorization. </summary>
        /// <param name="targetResourceId"> ID of the target Azure resource where the model should be copied to. </param>
        /// <param name="targetResourceRegion"> Location of the target Azure resource where the model should be copied to. </param>
        /// <param name="targetModelId"> Identifier of the target model. </param>
        /// <param name="targetModelLocation"> URL of the copied model in the target account. </param>
        /// <param name="accessToken"> Token used to authorize the request. </param>
        /// <param name="expirationDateTime"> Date/time when the access token expires. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetResourceId"/>, <paramref name="targetResourceRegion"/>, <paramref name="targetModelId"/>, <paramref name="targetModelLocation"/>, or <paramref name="accessToken"/> is null. </exception>
        internal CopyAuthorization(string targetResourceId, string targetResourceRegion, string targetModelId, string targetModelLocation, string accessToken, DateTimeOffset expirationDateTime)
        {
            if (targetResourceId == null)
            {
                throw new ArgumentNullException(nameof(targetResourceId));
            }
            if (targetResourceRegion == null)
            {
                throw new ArgumentNullException(nameof(targetResourceRegion));
            }
            if (targetModelId == null)
            {
                throw new ArgumentNullException(nameof(targetModelId));
            }
            if (targetModelLocation == null)
            {
                throw new ArgumentNullException(nameof(targetModelLocation));
            }
            if (accessToken == null)
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            TargetResourceId = targetResourceId;
            TargetResourceRegion = targetResourceRegion;
            TargetModelId = targetModelId;
            TargetModelLocation = targetModelLocation;
            AccessToken = accessToken;
            ExpirationDateTime = expirationDateTime;
        }
        /// <summary> Location of the target Azure resource where the model should be copied to. </summary>
        [CodeGenMember("TargetResourceRegion")]
        public string TargetResourceRegion { get; }

        /// <summary> Identifier of the target model. </summary>
        [CodeGenMember("TargetModelId")]
        public string TargetModelId { get; }

        /// <summary> URL of the copied model in the target account. </summary>
        [CodeGenMember("TargetModelLocation")]
        public string TargetModelLocation { get; }

        /// <summary> Date/time when the access token expires. </summary>
        [CodeGenMember("ExpirationDateTime")]
        public DateTimeOffset ExpirationDateTime { get; }

        /// <summary> Token used to authorize the request. </summary>
        [CodeGenMember("AccessToken")]
        internal string AccessToken { get; set; }

        /// <summary> ID of the target Azure resource where the model should be copied to. </summary>
        [CodeGenMember("TargetResourceId")]
        internal string TargetResourceId { get; set; }
    }
}
