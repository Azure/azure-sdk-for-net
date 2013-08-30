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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Auth
{
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    /// <summary>
    /// Contains helper methods for implementing shared access signatures.
    /// </summary>
    internal static class SharedAccessSignatureHelper
    {
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
            CommonUtility.AssertNotNullOrEmpty("resourceType", resourceType);
            CommonUtility.AssertNotNull("signature", signature);

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
            if (string.IsNullOrEmpty(permissions))
            {
                permissions = null;
            }

            return GetSharedAccessSignatureImpl(
                permissions,
                policy.SharedAccessStartTime,
                policy.SharedAccessExpiryTime,
                null /* startPartitionKey (table only) */,
                null /* startRowKey (table only) */,
                null /* endPartitionKey (table only) */,
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
            CommonUtility.AssertNotNull("signature", signature);

            if (policy == null)
            {
                return GetSharedAccessSignatureImpl(
                        null /* permissions*/,
                        null /* policy.SharedAccessStartTime*/,
                        null /* policy.SharedAccessExpiryTime*/,
                        null /* startPartitionKey (table only) */,
                        null /* startRowKey (table only) */,
                        null /* endPartitionKey (table only) */,
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
                null /* startPartitionKey (table only) */,
                null /* startRowKey (table only) */,
                null /* endPartitionKey (table only) */,
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
            CommonUtility.AssertNotNull("signature", signature);

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
            if (string.IsNullOrEmpty(permissions))
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
        internal static string GetDateTimeOrEmpty(DateTimeOffset? value)
        {
            string result = GetDateTimeOrNull(value) ?? string.Empty;
            return result;
        }

        /// <summary>
        /// Converts the specified value to either a string representation or <c>null</c>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A string representing the specified value.</returns>
        internal static string GetDateTimeOrNull(DateTimeOffset? value)
        {
            string result = value != null ? value.Value.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture) : null;
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
        /// <param name="mandatorySignedResource">A boolean that represents whether SignedResource is part of Sas or not. True for blobs, False for Queues and Tables.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1304:SpecifyCultureInfo", MessageId = "System.String.ToLower", Justification = "ToLower(CultureInfo) is not present in RT and ToLowerInvariant() also violates FxCop")]
        internal static StorageCredentials ParseQuery(IDictionary<string, string> queryParameters, bool mandatorySignedResource)
        {
            string signature = null;
            string signedStart = null;
            string signedExpiry = null;
            string signedResource = null;
            string sigendPermissions = null;
            string signedIdentifier = null;
            string signedVersion = null;
            string tableName = null;

            bool sasParameterFound = false;

            foreach (KeyValuePair<string, string> parameter in queryParameters)
            {
                switch (parameter.Key.ToLower())
                {
                    case Constants.QueryConstants.SignedStart:
                        signedStart = parameter.Value;
                        sasParameterFound = true;
                        break;

                    case Constants.QueryConstants.SignedExpiry:
                        signedExpiry = parameter.Value;
                        sasParameterFound = true;
                        break;

                    case Constants.QueryConstants.SignedPermissions:
                        sigendPermissions = parameter.Value;
                        sasParameterFound = true;
                        break;

                    case Constants.QueryConstants.SignedResource:
                        signedResource = parameter.Value;
                        sasParameterFound = true;
                        break;

                    case Constants.QueryConstants.SignedIdentifier:
                        signedIdentifier = parameter.Value;
                        sasParameterFound = true;
                        break;

                    case Constants.QueryConstants.Signature:
                        signature = parameter.Value;
                        sasParameterFound = true;
                        break;

                    case Constants.QueryConstants.SignedVersion:
                        signedVersion = parameter.Value;
                        sasParameterFound = true;
                        break;

                    case Constants.QueryConstants.SasTableName:
                        tableName = parameter.Value;
                        sasParameterFound = true;
                        break;

                    default:
                        break;
                }
            }

            if (sasParameterFound)
            {
                if (signature == null || (mandatorySignedResource && signedResource == null))
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.MissingMandatoryParametersForSAS);
                    throw new ArgumentException(errorMessage);
                }

                UriQueryBuilder builder = new UriQueryBuilder();
                AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedStart, signedStart);
                AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedExpiry, signedExpiry);
                AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedPermissions, sigendPermissions);
                if (signedResource != null)
                {
                    builder.Add(Constants.QueryConstants.SignedResource, signedResource);
                }

                AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedIdentifier, signedIdentifier);
                AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedVersion, signedVersion);
                AddEscapedIfNotNull(builder, Constants.QueryConstants.Signature, signature);
                AddEscapedIfNotNull(builder, Constants.QueryConstants.SasTableName, tableName);
               
                return new StorageCredentials(builder.ToString());
            }

            return null;
        }

        /// <summary>
        /// Get the complete query builder for creating the Shared Access Signature query.
        /// </summary>
        /// <param name="permissions">The permissions string for the resource, or null.</param>
        /// <param name="startTime">The start time, or null.</param>
        /// <param name="expiryTime">The expiration time, or null.</param>
        /// <param name="startPartitionKey">The start partition key, or null.</param>
        /// <param name="startRowKey">The start row key, or null.</param>
        /// <param name="endPartitionKey">The end partition key, or null.</param>
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
            DateTimeOffset? startTime,
            DateTimeOffset? expiryTime,
            string startPartitionKey,
            string startRowKey,
            string endPartitionKey,
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
            AddEscapedIfNotNull(builder, Constants.QueryConstants.StartPartitionKey, startPartitionKey);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.StartRowKey, startRowKey);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.EndPartitionKey, endPartitionKey);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.EndRowKey, endRowKey);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedIdentifier, accessPolicyIdentifier);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.SignedKey, accountKeyName);
            AddEscapedIfNotNull(builder, Constants.QueryConstants.Signature, signature);

            return builder;
        }

        /// <summary>
        /// Get the signature hash embedded inside the Shared Access Signature.
        /// </summary>
        /// <param name="policy">The shared access policy to hash.</param>
        /// <param name="accessPolicyIdentifier">An optional identifier for the policy.</param>
        /// <param name="resourceName">The canonical resource string, unescaped.</param>
        /// <param name="keyValue">The key value retrieved as an atomic operation used for signing.</param>
        /// <returns>The signed hash.</returns>
        internal static string GetSharedAccessSignatureHashImpl(
            SharedAccessBlobPolicy policy,
            string accessPolicyIdentifier,
            string resourceName,
            byte[] keyValue)
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
                    keyValue);
            }

            return GetSharedAccessSignatureHashImpl(
                SharedAccessBlobPolicy.PermissionsToString(policy.Permissions),
                policy.SharedAccessStartTime,
                policy.SharedAccessExpiryTime,
                null /* startPartitionKey (table only) */,
                null /* startRowKey (table only) */,
                null /* endPartitionKey (table only) */,
                null /* endRowKey (table only) */,
                false /* not using table SAS */,
                accessPolicyIdentifier,
                resourceName,
                keyValue);
        }

        /// <summary>
        /// Get the signature hash embedded inside the Shared Access Signature.
        /// </summary>
        /// <param name="policy">The shared access policy to hash.</param>
        /// <param name="accessPolicyIdentifier">An optional identifier for the policy.</param>
        /// <param name="resourceName">The canonical resource string, unescaped.</param>
        /// <param name="keyValue">The key value retrieved as an atomic operation used for signing.</param>
        /// <returns>The signed hash.</returns>
        internal static string GetSharedAccessSignatureHashImpl(
            SharedAccessQueuePolicy policy,
            string accessPolicyIdentifier,
            string resourceName,
            byte[] keyValue)
        {
            if (policy == null)
            {
                return GetSharedAccessSignatureHashImpl(
                    null /*SharedAccessQueuePolicy.Permissions */,
                    null /*policy.SharedAccessStartTime*/,
                    null /*policy.SharedAccessExpiryTime*/,
                    null /* startPartitionKey (table only) */,
                    null /* startRowKey (table only) */,
                    null /* endPartitionKey (table only) */,
                    null /* endRowKey (table only) */,
                    false /* not using table SAS */,
                    accessPolicyIdentifier,
                    resourceName,
                    keyValue);
            }
            else
            {
                return GetSharedAccessSignatureHashImpl(
                    SharedAccessQueuePolicy.PermissionsToString(policy.Permissions),
                    policy.SharedAccessStartTime,
                    policy.SharedAccessExpiryTime,
                    null /* startPartitionKey (table only) */,
                    null /* startRowKey (table only) */,
                    null /* endPartitionKey (table only) */,
                    null /* endRowKey (table only) */,
                    false /* not using table SAS */,
                    accessPolicyIdentifier,
                    resourceName,
                    keyValue);
            }
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
        /// <param name="keyValue">The key value retrieved as an atomic operation used for signing.</param>
        /// <returns>The signed hash.</returns>
        internal static string GetSharedAccessSignatureHashImpl(
            SharedAccessTablePolicy policy,
            string accessPolicyIdentifier,
            string startPartitionKey,
            string startRowKey,
            string endPartitionKey,
            string endRowKey,
            string resourceName,
            byte[] keyValue)
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
                    keyValue);
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
                keyValue);
        }

        /// <summary>
        /// Get the signature hash embedded inside the Shared Access Signature.
        /// </summary>
        /// <param name="permissions">The permissions string for the resource, or null.</param>
        /// <param name="startTime">The start time, or null.</param>
        /// <param name="expiryTime">The expiration time, or null.</param>
        /// <param name="startPartitionKey">The start partition key, or null.</param>
        /// <param name="startRowKey">The start row key, or null.</param>
        /// <param name="endPartitionKey">The end partition key, or null.</param>
        /// <param name="endRowKey">The end row key, or null.</param>
        /// <param name="useTableSas">Whether to use the table string-to-sign.</param>
        /// <param name="accessPolicyIdentifier">An optional identifier for the policy.</param>
        /// <param name="resourceName">The canonical resource string, unescaped.</param>
        /// <param name="keyValue">The key value retrieved as an atomic operation used for signing.</param>
        /// <returns>The signed hash.</returns>
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Microsoft.WindowsAzure.Storage.Core.Util.CryptoUtility.ComputeHmac256(System.Byte[],System.String)", Justification = "Reviewed")]
        private static string GetSharedAccessSignatureHashImpl(
            string permissions,
            DateTimeOffset? startTime,
            DateTimeOffset? expiryTime,
            string startPartitionKey,
            string startRowKey,
            string endPartitionKey,
            string endRowKey,
            bool useTableSas,
            string accessPolicyIdentifier,
            string resourceName,
            byte[] keyValue)
        {
            CommonUtility.AssertNotNullOrEmpty("resourceName", resourceName);
            CommonUtility.AssertNotNull("keyValue", keyValue);

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
                                     CultureInfo.InvariantCulture,
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
                    CultureInfo.InvariantCulture,
                    "{0}\n{1}\n{2}\n{3}\n{4}",
                    stringToSign,
                    startPartitionKey,
                    startRowKey,
                    endPartitionKey,
                    endRowKey);
            }

            string signature = CryptoUtility.ComputeHmac256(keyValue, stringToSign);

            return signature;
        }
    }
}
