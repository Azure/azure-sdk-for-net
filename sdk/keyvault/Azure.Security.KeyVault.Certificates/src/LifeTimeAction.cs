// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Certificates
{
    public class LifeTimeAction
    {
        public int DaysBeforeExpiry { get; set; }
        public int LifeTimePercentage { get; set; }
        public ActionType ActionType { get; set; }

    }
}
