﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys
{
    public class DeletedKey : Key
    {
        public string RecoveryId { get; private set; }

        public DateTime? DeletedDate { get; private set; }

        public DateTime? ScheduledPurgeDate { get; private set; }

        public DeletedKey(string name, string recoveryId, DateTime? deletedDate, DateTime? scheduledPurge)
            : base(name)
        {
            RecoveryId = recoveryId;
            DeletedDate = deletedDate;
            ScheduledPurgeDate = scheduledPurge;
        }
    }
}
