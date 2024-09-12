// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.Primitives;

namespace Azure.Generator
{
    /// <summary>
    /// The type factory for azure client plugin
    /// </summary>
    public class AzureTypeFactory : ScmTypeFactory
    {
        /// <inheritdoc/>
        public override CSharpType KeyCredentialType => typeof(AzureKeyCredential);

        /// <inheritdoc/>
        public override CSharpType TokenCredentialType => typeof(TokenCredential);
    }
}
