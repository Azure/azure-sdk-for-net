//-----------------------------------------------------------------------
// <copyright file="SharedAccessSignatureHelper.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the SharedAccessSignatureHelper.cs class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure
{
    using System;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Web;
    using Microsoft.WindowsAzure.StorageClient;
    using Microsoft.WindowsAzure.StorageClient.Protocol;

    /// <summary>
    /// Contains helper methods for implementing shared access signatures.
    /// </summary>
    internal static class SharedAccessSignatureHelper
    {
        /// <summary>
        /// Get the signature hash embedded inside the Shared Access Signature.
        /// </summary>
        /// <param name="policy">The shared access policy to hash.</param>
        /// <param name="groupPolicyIdentifier">An optional identifier for the policy.</param>
        /// <param name="resourceName">The canonical resource string, unescaped.</param>
        /// <param name="client">The client whose credentials are to be used for signing.</param>
        /// <returns>The signed hash.</returns>
        internal static string GetSharedAccessSignatureHashImpl(
            SharedAccessPolicy policy,
            string groupPolicyIdentifier,
            string resourceName,
            CloudBlobClient client)
        {
            CommonUtils.AssertNotNull("policy", policy);
            CommonUtils.AssertNotNullOrEmpty("resourceName", resourceName);
            CommonUtils.AssertNotNull("client", client);

            ////StringToSign = signedpermissions + "\n"
            ////               signedstart + "\n"
            ////               signedexpiry + "\n"
            ////               canonicalizedresource + "\n"
            ////               signedidentifier
            ////HMAC-SHA256(URL.Decode(UTF8.Encode(StringToSign)))

            string stringToSign = string.Format(
                "{0}\n{1}\n{2}\n{3}\n{4}",
                SharedAccessPolicy.PermissionsToString(policy.Permissions),
                GetDateTimeOrEmpty(policy.SharedAccessStartTime),
                GetDateTimeOrEmpty(policy.SharedAccessExpiryTime),
                resourceName,
                groupPolicyIdentifier);

            string signature = client.Credentials.ComputeHmac(stringToSign);

            return signature;
        }

        /// <summary>
        /// Get the complete query builder for creating the Shared Access Signature query.
        /// </summary>
        /// <param name="policy">The shared access policy to hash.</param>
        /// <param name="groupPolicyIdentifier">An optional identifier for the policy.</param>
        /// <param name="resourceType">Either "b" for blobs or "c" for containers.</param>
        /// <param name="signature">The signature to use.</param>
        /// <returns>The finished query builder.</returns>
        internal static UriQueryBuilder GetShareAccessSignatureImpl(
            SharedAccessPolicy policy,
            string groupPolicyIdentifier,
            string resourceType,
            string signature)
        {
            CommonUtils.AssertNotNull("policy", policy);
            CommonUtils.AssertNotNullOrEmpty("resourceType", resourceType);
            CommonUtils.AssertNotNull("signature", signature);

            UriQueryBuilder builder = new UriQueryBuilder();

            // FUTURE blob for blob and container for container
            string permissions = SharedAccessPolicy.PermissionsToString(policy.Permissions);
            if (String.IsNullOrEmpty(permissions))
            {
                permissions = null;
            }

            AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedStart, GetDateTimeOrNull(policy.SharedAccessStartTime));
            AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedExpiry, GetDateTimeOrNull(policy.SharedAccessExpiryTime));
            builder.Add(Constants.QueryConstants.SignedResource, resourceType);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedPermissions, permissions);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedIdentifier, groupPolicyIdentifier);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.Signature, signature);

            return builder;
        }

        /// <summary>
        /// Converts the specified value to either a string representation or <see cref="String.Empty"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A string representing the specified value.</returns>
        internal static string GetDateTimeOrEmpty(DateTime? value)
        {
            string result = GetDateTimeOrNull(value) ?? string.Empty;
            return result;
        }

        /// <summary>
        /// Converts the specified value to either a string representation or <c>null</c>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A string representing the specified value.</returns>
        internal static string GetDateTimeOrNull(DateTime? value)
        {
            string result = value != null ? value.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ") : null;
            return result;
        }

        /// <summary>
        /// Escapes and adds the specified name/value pair to the query builder if it is not null.
        /// </summary>
        /// <param name="builder">The builder to add the value to.</param>
        /// <param name="name">The name of the pair.</param>
        /// <param name="value">The value to be escaped.</param>
        internal static void AddEscapedIfNotNull(UriQueryBuilder builder, string name, string value)
        {
            if (value != null)
            {
                builder.Add(name, value);
            }
        }

        /// <summary>
        /// Parses the query.
        /// </summary>
        /// <param name="queryParameters">The query parameters.</param>
        /// <param name="credentials">The credentials.</param>
        internal static void ParseQuery(NameValueCollection queryParameters, out StorageCredentialsSharedAccessSignature credentials)
        {
            string signature = null;
            string signedStart = null;
            string signedExpiry = null;
            string signedResource = null;
            string sigendPermissions = null;
            string signedIdentifier = null;
            string signedVersion = null;

            bool sasParameterFound = false;

            credentials = null;

            foreach (var key in queryParameters.AllKeys)
            {
                switch (key.ToLower())
                {
                    case Constants.QueryConstants.SignedStart:
                        signedStart = queryParameters[key];
                        sasParameterFound = true;
                        break;

                    case Constants.QueryConstants.SignedExpiry:
                        signedExpiry = queryParameters[key];
                        sasParameterFound = true;
                        break;

                    case Constants.QueryConstants.SignedPermissions:
                        sigendPermissions = queryParameters[key];
                        sasParameterFound = true;
                        break;

                    case Constants.QueryConstants.SignedResource:
                        signedResource = queryParameters[key];
                        sasParameterFound = true;
                        break;

                    case Constants.QueryConstants.SignedIdentifier:
                        signedIdentifier = queryParameters[key];
                        sasParameterFound = true;
                        break;

                    case Constants.QueryConstants.Signature:
                        signature = queryParameters[key];
                        sasParameterFound = true;
                        break;

                    case Constants.QueryConstants.SignedVersion:
                        signedVersion = queryParameters[key];
                        sasParameterFound = true;
                        break;

                    default:
                        break;
                    //// string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.InvalidQueryParametersInsideBlobAddress, key.ToLower());
                    //// throw new ArgumentException(errorMessage);
                }
            }

            if (sasParameterFound)
            {
                if (signature == null || signedResource == null)
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.MissingMandatoryParamtersForSAS);
                    throw new ArgumentException(errorMessage);
                }

                UriQueryBuilder builder = new UriQueryBuilder();
                AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedStart, signedStart);
                AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedExpiry, signedExpiry);
                AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedPermissions, sigendPermissions);
                builder.Add(Constants.QueryConstants.SignedResource, signedResource);
                AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedIdentifier, signedIdentifier);
                AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedVersion, signedVersion);
                AddEscapedIfNotNull(builder, Constants.QueryConstants.Signature, signature);

                string token = builder.ToString();
                credentials = new StorageCredentialsSharedAccessSignature(token);
            }
        }
    }
}
