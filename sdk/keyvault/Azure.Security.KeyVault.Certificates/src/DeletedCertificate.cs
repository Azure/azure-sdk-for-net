// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault.Certificates
{
    public class DeletedCertificate : Certificate
    {
        public string RecoveryId { get; private set; }

        public DateTimeOffset? DeletedDate { get; private set; }

        public DateTimeOffset? ScheduledPurgeDate { get; private set; }

        public DeletedCertificate(string name, string recoveryId, DateTimeOffset? deletedDate, DateTimeOffset? scheduledPurge)
            : base(name)
        {
            RecoveryId = recoveryId;
            DeletedDate = deletedDate;
            ScheduledPurgeDate = scheduledPurge;
        }
    }
}
