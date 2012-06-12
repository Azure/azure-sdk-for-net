//-----------------------------------------------------------------------
// <copyright file="SharedAccessSignatureHelper.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
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
        /// <param name="accessPolicyIdentifier">An optional identifier for the policy.</param>
        /// <param name="resourceName">The canonical resource string, unescaped.</param>
        /// <param name="client">The client whose credentials are to be used for signing.</param>
        /// <returns>The signed hash.</returns>
        internal static string GetSharedAccessSignatureHashImpl(
            SharedAccessBlobPolicy policy,
            string accessPolicyIdentifier,
            string resourceName,
            CloudBlobClient client)
        {
            if (policy == null)
            {
                return GetSharedAccessSignatureHashImpl(
                    null /* policy.Permissions */,
                    null /* policy.SharedAccessStartTime */,
                    null /* policy.SharedAccessExpiryTime */,
                    null /* startPatitionKey (table only) */,
                    null /* startRowKey (table only) */,
                    null /* endPatitionKey (table only) */,
                    null /* endRowKey (table only) */,
                    false /* not using table SAS */,
                    accessPolicyIdentifier,
                    resourceName,
                    client.Credentials);
            }

            return GetSharedAccessSignatureHashImpl(
                SharedAccessBlobPolicy.PermissionsToString(policy.Permissions),
                policy.SharedAccessStartTime,
                policy.SharedAccessExpiryTime,
                null /* startPatitionKey (table only) */,
                null /* startRowKey (table only) */,
                null /* endPatitionKey (table only) */,
                null /* endRowKey (table only) */,
                false /* not using table SAS */,
                accessPolicyIdentifier,
                resourceName,
                client.Credentials);
        }

        /// <summary>
        /// Get the signature hash embedded inside the Shared Access Signature.
        /// </summary>
        /// <param name="policy">The shared access policy to hash.</param>
        /// <param name="accessPolicyIdentifier">An optional identifier for the policy.</param>
        /// <param name="resourceName">The canonical resource string, unescaped.</param>
        /// <param name="client">The client whose credentials are to be used for signing.</param>
        /// <returns>The signed hash.</returns>
        internal static string GetSharedAccessSignatureHashImpl(
            SharedAccessQueuePolicy policy,
            string accessPolicyIdentifier,
            string resourceName,
            CloudQueueClient client)
        {
            if (policy == null)
            {
                return GetSharedAccessSignatureHashImpl(
                    null /* policy.Permissions */,
                    null /* policy.SharedAccessStartTime */,
                    null /* policy.SharedAccessExpiryTime */,
                    null /* startPatitionKey (table only) */,
                    null /* startRowKey (table only) */,
                    null /* endPatitionKey (table only) */,
                    null /* endRowKey (table only) */,
                    false /* not using table SAS */,
                    accessPolicyIdentifier,
                    resourceName,
                    client.Credentials);
            }

            return GetSharedAccessSignatureHashImpl(
                SharedAccessQueuePolicy.PermissionsToString(policy.Permissions),
                policy.SharedAccessStartTime,
                policy.SharedAccessExpiryTime,
                null /* startPatitionKey (table only) */,
                null /* startRowKey (table only) */,
                null /* endPatitionKey (table only) */,
                null /* endRowKey (table only) */,
                false /* not using table SAS */,
                accessPolicyIdentifier,
                resourceName,
                client.Credentials);
        }

        /// <summary>
        /// Get the signature hash embedded inside the Shared Access Signature.
        /// </summary>
        /// <param name="policy">The shared access policy to hash.</param>
        /// <param name="accessPolicyIdentifier">An optional identifier for the policy.</param>
        /// <param name="startPartitionKey">The start partition key, or null.</param>
        /// <param name="startRowKey">The start row key, or null.</param>
        /// <param name="endPartitionKey">The end partition key, or null.</param>
        /// <param name="endRowKey">The end row key, or null.</param>
        /// <param name="resourceName">The canonical resource string, unescaped.</param>
        /// <param name="client">The client whose credentials are to be used for signing.</param>
        /// <returns>The signed hash.</returns>
        internal static string GetSharedAccessSignatureHashImpl(
            SharedAccessTablePolicy policy,
            string accessPolicyIdentifier,
            string startPartitionKey,
            string startRowKey,
            string endPartitionKey,
            string endRowKey,
            string resourceName,
            CloudTableClient client)
        {
            if (policy == null)
            {
                return GetSharedAccessSignatureHashImpl(
                    null /* policy.Permissions */,
                    null /* policy.SharedAccessStartTime */,
                    null /* policy.SharedAccessExpiryTime */,
                    startPartitionKey,
                    startRowKey,
                    endPartitionKey,
                    endRowKey,
                    true /* using table SAS */,
                    accessPolicyIdentifier,
                    resourceName,
                    client.Credentials);
            }

            return GetSharedAccessSignatureHashImpl(
                SharedAccessTablePolicy.PermissionsToString(policy.Permissions),
                policy.SharedAccessStartTime,
                policy.SharedAccessExpiryTime,
                startPartitionKey,
                startRowKey,
                endPartitionKey,
                endRowKey,
                true /* using table SAS */,
                accessPolicyIdentifier,
                resourceName,
                client.Credentials);
        }

        /// <summary>
        /// Get the complete query builder for creating the Shared Access Signature query.
        /// </summary>
        /// <param name="policy">The shared access policy to hash.</param>
        /// <param name="accessPolicyIdentifier">An optional identifier for the policy.</param>
        /// <param name="resourceType">Either "b" for blobs or "c" for containers.</param>
        /// <param name="signature">The signature to use.</param>
        /// <param name="accountKeyName">The name of the key used to create the signature, or null if the key is implicit.</param>
        /// <returns>The finished query builder.</returns>
        internal static UriQueryBuilder GetSharedAccessSignatureImpl(
            SharedAccessBlobPolicy policy,
            string accessPolicyIdentifier,
            string resourceType,
            string signature,
            string accountKeyName)
        {
            CommonUtils.AssertNotNullOrEmpty("resourceType", resourceType);
            CommonUtils.AssertNotNull("signature", signature);

            if (policy == null)
            {
                return GetSharedAccessSignatureImpl(
                    null /* policy.Permissions */,
                    null /* policy.SharedAccessStartTime */,
                    null /* policy.SharedAccessExpiryTime */,
                    null /* startPatitionKey (table only) */,
                    null /* startRowKey (table only) */,
                    null /* endPatitionKey (table only) */,
                    null /* endRowKey (table only) */,
                    accessPolicyIdentifier,
                    resourceType,
                    null /* tableName (table only) */,
                    signature,
                    accountKeyName);
            }

            string permissions = SharedAccessBlobPolicy.PermissionsToString(policy.Permissions);
            if (String.IsNullOrEmpty(permissions))
            {
                permissions = null;
            }

            return GetSharedAccessSignatureImpl(
                permissions,
                policy.SharedAccessStartTime,
                policy.SharedAccessExpiryTime,
                null /* startPatitionKey (table only) */,
                null /* startRowKey (table only) */,
                null /* endPatitionKey (table only) */,
                null /* endRowKey (table only) */,
                accessPolicyIdentifier,
                resourceType,
                null /* tableName (table only) */,
                signature,
                accountKeyName);
        }

        /// <summary>
        /// Get the complete query builder for creating the Shared Access Signature query.
        /// </summary>
        /// <param name="policy">The shared access policy to hash.</param>
        /// <param name="accessPolicyIdentifier">An optional identifier for the policy.</param>
        /// <param name="signature">The signature to use.</param>
        /// <param name="accountKeyName">The name of the key used to create the signature, or null if the key is implicit.</param>
        /// <returns>The finished query builder.</returns>
        internal static UriQueryBuilder GetSharedAccessSignatureImpl(
            SharedAccessQueuePolicy policy,
            string accessPolicyIdentifier,
            string signature,
            string accountKeyName)
        {
            CommonUtils.AssertNotNull("signature", signature);

            if (policy == null)
            {
                return GetSharedAccessSignatureImpl(
                    null /* policy.Permissions */,
                    null /* policy.SharedAccessStartTime */,
                    null /* policy.SharedAccessExpiryTime */,
                    null /* startPatitionKey (table only) */,
                    null /* startRowKey (table only) */,
                    null /* endPatitionKey (table only) */,
                    null /* endRowKey (table only) */,
                    accessPolicyIdentifier,
                    null /* resourceType (blob only) */,
                    null /* tableName (table only) */,
                    signature,
                    accountKeyName);
            }

            string permissions = SharedAccessQueuePolicy.PermissionsToString(policy.Permissions);
            if (string.IsNullOrEmpty(permissions))
            {
                permissions = null;
            }

            return GetSharedAccessSignatureImpl(
                permissions,
                policy.SharedAccessStartTime,
                policy.SharedAccessExpiryTime,
                null /* startPatitionKey (table only) */,
                null /* startRowKey (table only) */,
                null /* endPatitionKey (table only) */,
                null /* endRowKey (table only) */,
                accessPolicyIdentifier,
                null /* resourceType (blob only) */,
                null /* tableName (table only) */,
                signature,
                accountKeyName);
        }

        /// <summary>
        /// Get the complete query builder for creating the Shared Access Signature query.
        /// </summary>
        /// <param name="policy">The shared access policy to hash.</param>
        /// <param name="tableName">The name of the table associated with this shared access signature.</param>
        /// <param name="accessPolicyIdentifier">An optional identifier for the policy.</param>
        /// <param name="startPartitionKey">The start partition key, or null.</param>
        /// <param name="startRowKey">The start row key, or null.</param>
        /// <param name="endPartitionKey">The end partition key, or null.</param>
        /// <param name="endRowKey">The end row key, or null.</param>
        /// <param name="signature">The signature to use.</param>
        /// <param name="accountKeyName">The name of the key used to create the signature, or null if the key is implicit.</param>
        /// <returns>The finished query builder.</returns>
        internal static UriQueryBuilder GetSharedAccessSignatureImpl(
            SharedAccessTablePolicy policy,
            string tableName,
            string accessPolicyIdentifier,
            string startPartitionKey,
            string startRowKey,
            string endPartitionKey,
            string endRowKey,
            string signature,
            string accountKeyName)
        {
            CommonUtils.AssertNotNull("signature", signature);

            if (policy == null)
            {
                return GetSharedAccessSignatureImpl(
                    null /* policy.Permissions */,
                    null /* policy.SharedAccessStartTime */,
                    null /* policy.SharedAccessExpiryTime */,
                    startPartitionKey,
                    startRowKey,
                    endPartitionKey,
                    endRowKey,
                    accessPolicyIdentifier,
                    null /* resourceType (blob only) */,
                    tableName,
                    signature,
                    accountKeyName);
            }

            string permissions = SharedAccessTablePolicy.PermissionsToString(policy.Permissions);
            if (String.IsNullOrEmpty(permissions))
            {
                permissions = null;
            }

            return GetSharedAccessSignatureImpl(
                permissions,
                policy.SharedAccessStartTime,
                policy.SharedAccessExpiryTime,
                startPartitionKey,
                startRowKey,
                endPartitionKey,
                endRowKey,
                accessPolicyIdentifier,
                null /* resourceType (blob only) */,
                tableName,
                signature,
                accountKeyName);
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

        /// <summary>
        /// Get the signature hash embedded inside the Shared Access Signature.
        /// </summary>
        /// <param name="permissions">The permissions string for the resource, or null.</param>
        /// <param name="startTime">The start time, or null.</param>
        /// <param name="expiryTime">The expiration time, or null.</param>
        /// <param name="startPatitionKey">The start partition key, or null.</param>
        /// <param name="startRowKey">The start row key, or null.</param>
        /// <param name="endPatitionKey">The end partition key, or null.</param>
        /// <param name="endRowKey">The end row key, or null.</param>
        /// <param name="useTableSas">Whether to use the table string-to-sign.</param>
        /// <param name="accessPolicyIdentifier">An optional identifier for the policy.</param>
        /// <param name="resourceName">The canonical resource string, unescaped.</param>
        /// <param name="credentials">The credentials to be used for signing.</param>
        /// <returns>The signed hash.</returns>
        private static string GetSharedAccessSignatureHashImpl(
            string permissions,
            DateTime? startTime,
            DateTime? expiryTime,
            string startPatitionKey,
            string startRowKey,
            string endPatitionKey,
            string endRowKey,
            bool useTableSas,
            string accessPolicyIdentifier,
            string resourceName,
            StorageCredentials credentials)
        {
            CommonUtils.AssertNotNullOrEmpty("resourceName", resourceName);
            CommonUtils.AssertNotNull("credentials", credentials);

            //// StringToSign =      signedpermissions + "\n" +
            ////                     signedstart + "\n" +
            ////                     signedexpiry + "\n" +
            ////                     canonicalizedresource + "\n" +
            ////                     signedidentifier + "\n" +
            ////                     signedversion
            ////
            //// TableStringToSign = StringToSign + "\n" +
            ////                     startpk + "\n" +
            ////                     startrk + "\n" +
            ////                     endpk + "\n" +
            ////                     endrk
            ////
            //// HMAC-SHA256(UTF8.Encode(StringToSign))

            string stringToSign = string.Format(
                "{0}\n{1}\n{2}\n{3}\n{4}\n{5}",
                permissions,
                GetDateTimeOrEmpty(startTime),
                GetDateTimeOrEmpty(expiryTime),
                resourceName,
                accessPolicyIdentifier,
                Constants.HeaderConstants.TargetStorageVersion);

            if (useTableSas)
            {
                stringToSign = string.Format(
                    "{0}\n{1}\n{2}\n{3}\n{4}",
                    stringToSign,
                    startPatitionKey,
                    startRowKey,
                    endPatitionKey,
                    endRowKey);
            }

            string signature = credentials.ComputeHmac(stringToSign);

            return signature;
        }

        /// <summary>
        /// Get the complete query builder for creating the Shared Access Signature query.
        /// </summary>
        /// <param name="permissions">The permissions string for the resource, or null.</param>
        /// <param name="startTime">The start time, or null.</param>
        /// <param name="expiryTime">The expiration time, or null.</param>
        /// <param name="startPatitionKey">The start partition key, or null.</param>
        /// <param name="startRowKey">The start row key, or null.</param>
        /// <param name="endPatitionKey">The end partition key, or null.</param>
        /// <param name="endRowKey">The end row key, or null.</param>
        /// <param name="accessPolicyIdentifier">An optional identifier for the policy.</param>
        /// <param name="resourceType">Either "b" for blobs or "c" for containers, or null if neither.</param>
        /// <param name="tableName">The name of the table this signature is associated with,
        ///     or null if not using table SAS.</param>
        /// <param name="signature">The signature to use.</param>
        /// <param name="accountKeyName">The name of the key used to create the signature, or null if the key is implicit.</param>
        /// <returns>The finished query builder.</returns>
        private static UriQueryBuilder GetSharedAccessSignatureImpl(
            string permissions,
            DateTime? startTime,
            DateTime? expiryTime,
            string startPatitionKey,
            string startRowKey,
            string endPatitionKey,
            string endRowKey,
            string accessPolicyIdentifier,
            string resourceType,
            string tableName,
            string signature,
            string accountKeyName)
        {
            UriQueryBuilder builder = new UriQueryBuilder();

            AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedVersion, Constants.HeaderConstants.TargetStorageVersion);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedStart, GetDateTimeOrNull(startTime));
            AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedExpiry, GetDateTimeOrNull(expiryTime));
            AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedResource, resourceType);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.SasTableName, tableName);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedPermissions, permissions);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.StartPartitionKey, startPatitionKey);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.StartRowKey, startRowKey);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.EndPartitionKey, endPatitionKey);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.EndRowKey, endRowKey);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedIdentifier, accessPolicyIdentifier);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedKey, accountKeyName);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.Signature, signature);

            return builder;
        }
    }
}
