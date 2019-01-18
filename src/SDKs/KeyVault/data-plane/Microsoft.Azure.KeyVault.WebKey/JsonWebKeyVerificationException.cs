// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Microsoft.Azure.KeyVault.WebKey
{
    public sealed class JsonWebKeyVerificationException : Exception
    {
        public JsonWebKeyVerificationException( string message ) : base( message )
        {
        }

        public JsonWebKeyVerificationException( string message, Exception inner ) : base( message, inner )
        {
        }
    }
}