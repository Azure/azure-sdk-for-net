// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage.Fluent.Models;

namespace Microsoft.Azure.Management.Storage.Fluent
{
    public class AccountStatuses
    {
        public AccountStatuses(AccountStatus? primary, AccountStatus? secondary)
        {
            Primary = primary;
            Secondary = secondary;
        }

        public AccountStatus? Primary
        {
            get; private set;
        }

        public AccountStatus? Secondary
        {
            get; private set;
        }
    }

}
