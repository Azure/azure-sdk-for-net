// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignatureValidationOptions
    {
        public List<string> AccessKeys { get; } = new List<string>();
        public bool RequireValidation { get; set; } = true;
    }
}
