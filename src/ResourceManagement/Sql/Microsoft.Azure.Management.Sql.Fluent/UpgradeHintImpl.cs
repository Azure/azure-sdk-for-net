// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// Implementation for Upgrade hint interface.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5VcGdyYWRlSGludEltcGw=
    internal partial class UpgradeHintImpl :
        Wrapper<Models.UpgradeHint>,
        IUpgradeHint
    {

        ///GENMHASH:47B0CCFDDE32BC2E26AB51DB1F9DA342:507DFB69022C36CEE10273849AA5004C
        public Guid TargetServiceLevelObjectiveId()
        {
            return Inner.TargetServiceLevelObjectiveId.GetValueOrDefault();
        }

        ///GENMHASH:D5C9144F34CDE74E76FA4B029FD4C6BF:C0C35E00AF4E17F141675A2C05C7067B
        internal UpgradeHintImpl(UpgradeHint innerObject)
            : base(innerObject)
        {
        }

        ///GENMHASH:50212B0935C6C914B9E96569CFD74DE2:C119A85170FBF3FBAE458A726CF7D732
        public string TargetServiceLevelObjective()
        {
            return Inner.TargetServiceLevelObjective;
        }
    }
}
