// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core
{
    /// <summary>
    /// A concrete ClientOptions for use by client with no additonal options other than the common ones.
    /// </summary>
#pragma warning disable AZC0008 // ClientOptions should have a nested enum called ServiceVersion
    public class ProtocolClientOptions : ClientOptions
#pragma warning restore AZC0008 // ClientOptions should have a nested enum called ServiceVersion
    {
    }
}
