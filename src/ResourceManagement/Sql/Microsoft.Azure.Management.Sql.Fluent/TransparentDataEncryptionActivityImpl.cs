// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    /// <summary>
    /// Implementation for TransparentDataEncryptionActivity.
    /// </summary>
    internal partial class TransparentDataEncryptionActivityImpl :
        Wrapper<Models.TransparentDataEncryptionActivity>,
        ITransparentDataEncryptionActivity
    {
        private ResourceId resourceId;

        internal TransparentDataEncryptionActivityImpl(TransparentDataEncryptionActivity innerObject) : base(innerObject)
        {
            this.resourceId = ResourceId.ParseResourceId(this.Inner.Id);
        }

        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        public string DatabaseName()
        {
            return resourceId.Parent.Name;
        }

        public string SqlServerName()
        {
            return resourceId.Parent.Parent.Name;
        }

        public string Name()
        {
            return this.resourceId.Name;
        }

        public string Id()
        {
            return this.resourceId.Id;
        }

        public double PercentComplete()
        {
            return this.Inner.PercentComplete.GetValueOrDefault();
        }

        public string Status()
        {
            return this.Inner.Status;
        }
    }
}