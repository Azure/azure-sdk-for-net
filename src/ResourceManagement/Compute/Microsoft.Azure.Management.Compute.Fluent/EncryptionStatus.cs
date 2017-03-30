// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    public class EncryptionStatus : ExpandableStringEnum<EncryptionStatus>
    {
        public static readonly EncryptionStatus EncryptionInProgress = Parse("EncryptionInProgress");
        public static readonly EncryptionStatus Encrypted = Parse("Encrypted");
        public static readonly EncryptionStatus NotEncrypted = Parse("NotEncrypted");
        public static readonly EncryptionStatus VMRestartPending = Parse("VMRestartPending");
        public static readonly EncryptionStatus NotMounted = Parse("NotMounted");
        public static readonly EncryptionStatus Unknown = Parse("Unknown");
    }
}
