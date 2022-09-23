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
    [CodeGenSuppress("UploadTestFile", typeof(string), typeof(string), typeof(RequestContent), typeof(int?), typeof(RequestContent))]
    [CodeGenSuppress("UploadTestFileAsync", typeof(string), typeof(string), typeof(RequestContent), typeof(int?), typeof(RequestContent))]
    public partial class LoadTestAdministrationClient { }
}
