// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for TransparentDataEncryption.
    /// </summary>
    internal partial class TransparentDataEncryptionImpl :
        Wrapper<Models.TransparentDataEncryptionInner>,
        ITransparentDataEncryption
    {
        private ResourceId resourceId;
        private IDatabasesOperations databasesInner;

        public IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity> ListActivities()
        {
            Func<TransparentDataEncryptionActivity, ITransparentDataEncryptionActivity> convertor = (transparentDataEncryptionActivity) => new TransparentDataEncryptionActivityImpl(transparentDataEncryptionActivity);
            return PagedListConverter.Convert(this.databasesInner.ListTransparentDataEncryptionActivity(
                this.ResourceGroupName(),
                this.SqlServerName(),
                this.DatabaseName()), convertor);
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

        public ITransparentDataEncryption UpdateStatus(TransparentDataEncryptionStates transparentDataEncryptionState)
        {
            this.Inner.Status = transparentDataEncryptionState;
            this.SetInner(
                this.databasesInner.CreateOrUpdateTransparentDataEncryptionConfiguration(
                    this.ResourceGroupName(),
                    this.SqlServerName(),
                    this.DatabaseName(),
                    this.Inner));

            return this;
        }

        public string Name()
        {
            return this.resourceId.Name;
        }

        internal TransparentDataEncryptionImpl(TransparentDataEncryptionInner innerObject, IDatabasesOperations databasesInner)
            : base(innerObject)
        {
            this.resourceId = ResourceId.ParseResourceId(this.Inner.Id);
            this.databasesInner = databasesInner;
        }

        public string Id()
        {
            return this.resourceId.Id;
        }

        public TransparentDataEncryptionStates Status()
        {
            return this.Inner.Status.GetValueOrDefault();
        }
    }
}