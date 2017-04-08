// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.Common.Authentication
{
    public interface IAccessToken
    {
        void AuthorizeRequest(Action<string, string> authTokenSetter);

        string AccessToken { get; }

        string UserId { get; }

        string TenantId { get; }
        
        LoginType LoginType { get; }
    }
}
