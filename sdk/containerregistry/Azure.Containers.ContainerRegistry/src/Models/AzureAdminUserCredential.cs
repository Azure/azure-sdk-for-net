// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Containers.ContainerRegistry.Models
{
    public class AzureAdminUserCredential
    {
        public AzureAdminUserCredential(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        internal string UserName { get; }

        internal string Password { get; private set; }

        public void Update(string password)
        {
            Password = password;
        }
    }
}
