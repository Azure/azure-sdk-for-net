// ----------------------------------------------------------------------------
// <copyright file="NoCredentials.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------
namespace Microsoft.Azure.Management.MixedReality
{
    using System;
    using Rest;

    internal class NoCredentials : ServiceClientCredentials
    {
        private static Lazy<NoCredentials> instance = new Lazy<NoCredentials>(true);

        internal static NoCredentials Instance => instance.Value;
    }
}
