// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.CoreWCF.Azure.Tokens
{
    // Consider making this public in the future similar to System.ServiceModel.Security.Tokens.ServiceModelSecurityTokenTypes
    internal static class AzureSecurityTokenTypes
    {
        public const string Namespace = "http://schemas.microsoft.com/ws/2006/05/servicemodel/tokens/Azure";
        public const string DefaultTokenType = Namespace + "/Default";
        public const string SasTokenType = Namespace + "/Sas";
        public const string StorageSharedKeyTokenType = Namespace + "/StorageSharedKey";
        public const string TokenTokenType = Namespace + "/Token";
        public const string ConnectionStringTokenType = Namespace + "/ConnectionString";
    }
}
