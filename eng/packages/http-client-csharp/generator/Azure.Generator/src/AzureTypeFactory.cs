// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.Primitives;
using System.ClientModel;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureTypeFactory : ScmTypeFactory
    {
        /// <inheritdoc/>
        public override CSharpType ClientResponseExceptionType => typeof(RequestFailedException);

        /// <inheritdoc/>
        public override CSharpType ClientResponseType => typeof(Response);

        /// <inheritdoc/>
        public override CSharpType ClientResponseOfTType => typeof(Response<>);

        /// <inheritdoc/>
        public override CSharpType HttpResponseType => typeof(Response);
    }
}
