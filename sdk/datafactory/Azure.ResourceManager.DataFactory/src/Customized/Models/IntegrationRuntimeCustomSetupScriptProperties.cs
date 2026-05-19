// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customization to restore properties dropped by MPG generator due to
// @@alternateType identity-aliasing on SecureString (issue #59298).

#nullable disable

using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    public partial class IntegrationRuntimeCustomSetupScriptProperties
    {
        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactorySecretString SasToken { get; set; }
    }
}
