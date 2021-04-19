// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// Constants useful for use with the digital twins client.
    /// </summary>
    internal static class ModelsConstants
    {
        /// <summary>
        /// The application/json-patch+json operation to decommission a model.
        /// </summary>
        internal static readonly IEnumerable<string> DecommissionModelOperationList = new[] { @"{ ""op"": ""replace"", ""path"": ""/decommissioned"", ""value"": true }" };
    }
}
