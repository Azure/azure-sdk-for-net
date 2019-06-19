// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Certificates
{
    public class ErrorModel
    {
        public string ErrorCode { get; set; }
        public ErrorModel InnerError { get; set; }
        public string Message { get; set; }
    }
}
