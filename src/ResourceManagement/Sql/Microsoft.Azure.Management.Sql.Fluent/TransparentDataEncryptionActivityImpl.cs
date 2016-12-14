// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5UcmFuc3BhcmVudERhdGFFbmNyeXB0aW9uQWN0aXZpdHlJbXBs
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

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:A08302619254C2A4BBCEC7165449AD96
        public string Name()
        {
            return this.resourceId.Name;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:003E1843567E7760DFADC015F30E6AF4
        public string Id()
        {
            return this.resourceId.Id;
        }

        ///GENMHASH:64FDD7DAC0F2CAB9406652DA7545E8AA:60E139E176D51169A736C4BE93730827
        public double PercentComplete()
        {
            return this.Inner.PercentComplete.GetValueOrDefault();
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:1ABA34EF946CBD0278FAD778141792B2
        public string Status()
        {
            return this.Inner.Status;
        }
    }
}
