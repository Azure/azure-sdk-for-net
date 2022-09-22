// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    [CodeGenSuppress("LoadTestAdministrationClient", typeof(string), typeof(TokenCredential))]
    [CodeGenSuppress("LoadTestAdministrationClient", typeof(string), typeof(TokenCredential), typeof(AzureLoadTestingClientOptions))]
    public partial class LoadTestAdministrationClient
    {
    }
}
