// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.DataMovement
{
    internal enum JobPartPlanCredentialType
    {
        Unknown = 0,
        /// <summary>
        /// For Azure, OAuth
        /// </summary>
        OAuthToken = 1,
        /// <summary>
        /// For Azure, SAS or public.
        /// </summary>
        Anonymous = 2,
        /// <summary>
        /// For Azure, SharedKey
        /// </summary>
        SharedKey = 3,
        /// <summary>
        /// For S3, AccessKeyID and SecretAccessKey.
        /// TODO: future use
        /// </summary>
        S3AccessKey = 4,
        /// <summary>
        /// For Google App credentials.TODO: future use
        /// </summary>
        GoogleAppCredentials = 5,
        /// <summary>
        /// For S3, Anon Credentials and public bucket. TODO: future use
        /// </summary>
        S3PublicBucket = 6,
    }
}
