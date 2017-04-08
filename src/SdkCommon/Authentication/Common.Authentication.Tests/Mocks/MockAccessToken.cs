// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Common.Authentication;
using System;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Mocks
{
    public class MockAccessToken : IAccessToken
    {
        public void AuthorizeRequest(Action<string, string> authTokenSetter)
        {
            authTokenSetter("Bearer", AccessToken);
        }

        public string AccessToken { get; set; }
        public string UserId { get; set; }
        public LoginType LoginType { get; set; }

        public string TenantId
        {
            get { return string.Empty; }
        }
    }
}
