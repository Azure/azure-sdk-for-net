// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Common.Authentication.Models
{
    [Serializable]
    public partial class AzureEnvironment
    {
        public AzureEnvironment()
        {
            Endpoints = new Dictionary<Endpoint, string>();
        }

        public string Name { get; set; }

        public bool OnPremise { get; set; }

        public Dictionary<Endpoint, string> Endpoints { get; set; }
    }
}
