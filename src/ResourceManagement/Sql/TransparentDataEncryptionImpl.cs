// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implementation for TransparentDataEncryption.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5UcmFuc3BhcmVudERhdGFFbmNyeXB0aW9uSW1wbA==
    internal partial class TransparentDataEncryptionImpl :
        Wrapper<Models.TransparentDataEncryptionInner>,
        ITransparentDataEncryption
    {
        private ResourceId resourceId;
        private IDatabasesOperations databasesInner;

        ///GENMHASH:C183D7089E5DF699C59758CC103308DF:0F2852A05859CF21CF78B54DB31431CD
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity> ListActivities()
        {
            return Extensions.Synchronize(() => this.databasesInner.ListTransparentDataEncryptionActivityAsync(
                    this.ResourceGroupName(),
                    this.SqlServerName(),
                    this.DatabaseName()))
                .Select(transparentDataEncryptionActivity => new TransparentDataEncryptionActivityImpl(transparentDataEncryptionActivity)).ToList();
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:9FE42D967416923E070F823D07063A47
        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        ///GENMHASH:E7ABDAFE895DE30905D46D515062DB59:4FF2FEC4B193B40F5666C7C0244DEB2E
        public string DatabaseName()
        {
            return resourceId.Parent.Name;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:1DE3B7D49F042BF9BD713FC79256757A
        public string SqlServerName()
        {
            return resourceId.Parent.Parent.Name;
        }

        ///GENMHASH:963770852AF9FA245B7756A9091BA5E1:35EFB9F3197D86AF34A553208A6A8B5E
        public ITransparentDataEncryption UpdateStatus(TransparentDataEncryptionStates transparentDataEncryptionState)
        {
            Inner.Status = transparentDataEncryptionState;
            this.SetInner(
                Extensions.Synchronize(() => this.databasesInner.CreateOrUpdateTransparentDataEncryptionConfigurationAsync(
                    this.ResourceGroupName(),
                    this.SqlServerName(),
                    this.DatabaseName(),
                    Inner.Status)));

            return this;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:A08302619254C2A4BBCEC7165449AD96
        public string Name()
        {
            return this.resourceId.Name;
        }

        ///GENMHASH:1777CD6BECD021A68EC284951D197658:A677B0C455E56513C192E43F117D71E1
        internal TransparentDataEncryptionImpl(TransparentDataEncryptionInner innerObject, IDatabasesOperations databasesInner)
            : base(innerObject)
        {
            this.resourceId = ResourceId.FromString(Inner.Id);
            this.databasesInner = databasesInner;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:003E1843567E7760DFADC015F30E6AF4
        public string Id()
        {
            return this.resourceId.Id;
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:1ABA34EF946CBD0278FAD778141792B2
        public TransparentDataEncryptionStates Status()
        {
            return Inner.Status.GetValueOrDefault();
        }
    }
}
