// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace Az.Auth.NetCore.Test
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure.Authentication;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;

    public class LoginTests
    {
        //[Fact]
        public void TestCertAuthWithCertRotation()
        {
            string certFilePath = @"C:\Users\Desktop\CertRotation\testAme.crt";
            string tenantId = @"";
            string clientId = @"";

            ServiceClientCredentials creds = ApplicationTokenProvider.LoginSilentAsync(tenantId, clientId, certFilePath, true).GetAwaiter().GetResult();
            Assert.NotNull(creds);
        }
    }
}
