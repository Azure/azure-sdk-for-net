// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Instance of this exception is thrown if access token cannot be acquired. 
    /// </summary>
#if FullNetFx
    [Serializable]
#endif
    public class AzureServiceTokenProviderException : Exception
    {
        internal const string MsiEndpointNotListening = "Unable to connect to the Managed Service Identity (MSI) endpoint. Please check that you are running on an Azure resource that has MSI setup.";

        internal const string UnableToParseMsiTokenResponse = "A successful response was received from Managed Service Identity, but it could not be parsed.";

        internal const string GenericErrorMessage = "Access token could not be acquired.";

        internal const string ActiveDirectoryIntegratedAuthUsed = "Tried to get token using Active Directory Integrated Authentication.";

        internal const string ManagedServiceIdentityUsed = "Tried to get token using Managed Service Identity.";

        internal const string AzureCliUsed = "Tried to get token using Azure CLI.";

        internal const string VisualStudioUsed = "Tried to get token using Visual Studio.";

        internal const string CertificateNotFound = "Specified certificate was not found. ";

        internal const string MissingResource = "Resouce must be specified.";
        

        /// <summary>
        /// Creates an instance of AzureServiceTokenProviderException. 
        /// </summary>
        /// <param name="connectionString">Connection string used.</param>
        /// <param name="resource">Resource for which token was expected.</param>
        /// <param name="authority">Authority for which token was expected.</param>
        /// <param name="message">Reason why token could not be acquired.</param>
        internal AzureServiceTokenProviderException(string connectionString, string resource, string authority, string message) : 
            base($"Parameters: Connection String: {connectionString ?? "[No connection string specified]"}, " +
                 $"Resource: {resource}, Authority: {authority ?? "[No authority specified]"}. Exception Message: {message}")
        {
        }
    }
}
