// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Test.Shared
{
    /// <summary>
    /// To test if a SAS generated in different methods will be
    /// accepted and not altered by the storage clients
    ///
    /// The orignal AccountSasBuilder usually will fix the order of the
    /// resource types, permissions etc
    ///
    /// Looking at the Account SAS docs
    /// https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas#specify-the-account-sas-parameters
    /// There's no requirement on ordering of the Resource Types, Signed Services or Signed Permissions
    /// </summary>
    internal class TestAccountSasBuilder : AccountSasBuilder
    {
        /// <summary>
        /// Custom set Resource Account Types in a specific order
        /// e.g. "sco", "cso", "osc", "ocs", "cos", "soc".
        /// </summary>
        public string CustomResourceTypes { get; internal set; }

        /// <summary>
        /// Custom set Resource Signed Services
        /// e.g. "bqtf", "qtfb", "fbtq" and more
        /// </summary>
        public string CustomSignedServices { get; internal set; }

        /// <summary>
        /// Custom set Resource Account Types
        /// e.g. "rwdylacuptfi", "tfirwdylacup"
        /// </summary>
        public string CustomSignedPermissions { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountSasBuilder"/>
        /// class to create a Blob Container Service Sas.
        /// </summary>
        /// <param name="permissions">
        /// The time at which the shared access signature becomes invalid.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </param>
        /// <param name="expiresOn">
        /// The time at which the shared access signature becomes invalid.
        /// This field must be omitted if it has been specified in an
        /// associated stored access policy.
        /// </param>
        /// <param name="services">
        /// Specifies the services accessible from an account level shared access
        /// signature.
        /// </param>
        /// <param name="resourceTypes">
        /// Specifies the resource types accessible from an account level shared
        /// access signature.
        /// </param>
        public TestAccountSasBuilder(
            string permissions,
            DateTimeOffset expiresOn,
            string services,
            string resourceTypes)
        {
            ExpiresOn = expiresOn;
            SetCustomPermissions(permissions);
            SetCustomSignedServices(services);
            SetCustomResourcesTypes(resourceTypes);
        }

        /// <summary>
        /// Sets the custom permissions for an account SAS.
        /// </summary>
        /// <param name="permissions">
        /// Contains custom permissions
        /// </param>
        public void SetCustomPermissions(string permissions)
        {
            // If any of the permission characters are invalid, this will throw.
            // We're using the SetPermissions because it uses the s_validPermissionsInOrder
            SetPermissions(permissions);
            CustomSignedPermissions = permissions;
        }

        /// <summary>
        /// Sets the custom resource types for an account SAS.
        /// </summary>
        /// <param name="signedServices">
        /// Contains custom signed services
        /// </param>
        public void SetCustomSignedServices(string signedServices)
        {
            ValidateAndRawTypes(signedServices, s_signedServices);
            CustomSignedServices = signedServices;
        }

        /// <summary>
        /// Sets the custom resource types for an account SAS.
        /// </summary>
        /// <param name="resourceTypes">
        /// Contains custom resource types
        /// </param>
        public void SetCustomResourcesTypes(string resourceTypes)
        {
            ValidateAndRawTypes(resourceTypes, s_resourceTypes);
            CustomResourceTypes = resourceTypes;
        }

        internal static void ValidateAndRawTypes(string rawString,
            List<char> validCharacters)
        {
            if (string.IsNullOrEmpty(rawString))
            {
                throw new ArgumentException($"{rawString} is empty or null, pass valid type");
            }

            // Convert permissions string to lower case.
            rawString = rawString.ToLowerInvariant();

            HashSet<char> validPermissionsSet = new HashSet<char>(validCharacters);

            foreach (char validString in rawString)
            {
                // Check that each permission is a real SAS permission.
                if (!validPermissionsSet.Contains(validString))
                {
                    throw new ArgumentException($"{validString} is not a valid SAS character string");
                }
            }
        }

        /// <summary>
        /// Use an account's <see cref="StorageSharedKeyCredential"/> to sign this
        /// shared access signature values to produce the proper SAS query
        /// parameters for authenticating requests.
        /// </summary>
        /// <param name="sharedKeyCredential">
        /// The storage account's <see cref="StorageSharedKeyCredential"/>.
        /// </param>
        /// <returns>
        /// The <see cref="SasQueryParameters"/> used for authenticating
        /// requests.
        /// </returns>
        public TestSasQueryParameters ToTestSasQueryParameters(StorageSharedKeyCredential sharedKeyCredential)
        {
            // https://docs.microsoft.com/en-us/rest/api/storageservices/Constructing-an-Account-SAS
            sharedKeyCredential = sharedKeyCredential ?? throw Errors.ArgumentNull(nameof(sharedKeyCredential));

            if (ExpiresOn == default || string.IsNullOrEmpty(CustomSignedPermissions) || string.IsNullOrEmpty(CustomResourceTypes) || string.IsNullOrEmpty(CustomSignedServices))
            {
                throw Errors.AccountSasMissingData();
            }

            Version = SasQueryParametersInternals.DefaultSasVersionInternal;

            string startTime = SasExtensions.FormatTimesForSasSigning(StartsOn);
            string expiryTime = SasExtensions.FormatTimesForSasSigning(ExpiresOn);

            // String to sign: http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            // If the string to sign changes, we need to update this)
            string stringToSign = string.Join("\n",
                sharedKeyCredential.AccountName,
                // Use Permissions if the CustomPermissions is not used
                string.IsNullOrEmpty(CustomSignedPermissions) ? Permissions : CustomSignedPermissions,
                // Use Services if the services is not used
                string.IsNullOrEmpty(CustomSignedServices) ? Services.ToPermissionsString() : CustomSignedServices,
                // Use ResourceTypes if the CustomResourceTypes is not used
                string.IsNullOrEmpty(CustomResourceTypes) ? ResourceTypes.ToPermissionsString() : CustomResourceTypes,
                startTime,
                expiryTime,
                IPRange.ToString(),
                Protocol.ToProtocolString(),
                Version,
                EncryptionScope,
                string.Empty);  // That's right, the account SAS requires a terminating extra newline

            string signature = StorageSharedKeyCredentialInternals.ComputeSasSignature(sharedKeyCredential, stringToSign);
            TestSasQueryParameters sasQueryParameters = new TestSasQueryParameters(
                Version,
                string.IsNullOrEmpty(CustomSignedServices) ? Services.ToPermissionsString() : CustomSignedServices,
                string.IsNullOrEmpty(CustomResourceTypes) ? ResourceTypes.ToPermissionsString() : CustomResourceTypes,
                Protocol,
                StartsOn,
                ExpiresOn,
                IPRange,
                identifier: null,
                resource: null,
                string.IsNullOrEmpty(CustomSignedPermissions) ? Permissions : CustomSignedPermissions,
                signature,
                encryptionScope: EncryptionScope);
            return sasQueryParameters;
        }

        /// <summary>
        /// All the signed resource types that are possible
        /// See <see cref="AccountSasResourceTypes"/>
        /// Might have to update if any other resource type gets added
        /// See <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas#specify-the-account-sas-parameters"/>
        /// </summary>
        private static readonly List<char> s_resourceTypes = new List<char>
        {
            // Service
            's',
            // Container
            'c',
            // Object
            'o'
        };

        /// <summary>
        /// All the signed services that are possible
        /// See <see cref="AccountSasServices"/>
        /// Might have to update if any other service gets added
        /// See <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas#specify-the-account-sas-parameters"/>
        /// </summary>
        private static readonly List<char> s_signedServices = new List<char>
        {
            // Blobs
            'b',
            // Files
            'f',
            // Queues
            'q',
            // Table
            't',
        };
    }
}
