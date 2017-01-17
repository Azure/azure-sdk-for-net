// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Resource.Fluent.Authentication
{
    public class UserLoginInformation
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ClientId {get; set;}
    }
}
