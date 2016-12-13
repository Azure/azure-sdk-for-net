// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5SZXN0b3JlUG9pbnRJbXBs
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// Implementation for Restore point interface.
    /// </summary>
    internal partial class RestorePointImpl :
        Wrapper<Models.RestorePointInner>,
        IRestorePoint
    {
        private ResourceId resourceId;

        internal RestorePointImpl(RestorePointInner innerObject)
            : base(innerObject)
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

        ///GENMHASH:5D8C32D2751B491914616D667B547A6C:7EDB4220F88516901344158E2ED52A30
        public DateTime RestorePointCreationDate()
        {
            return this.Inner.RestorePointCreationDate.GetValueOrDefault();
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

        ///GENMHASH:F2ABE029F6A55328DAF428566FF166D9:AA34FA1E27583C49DDBE6DC99C3A871E
        public RestorePointTypes RestorePointType()
        {
            return this.Inner.RestorePointType.GetValueOrDefault();
        }

        ///GENMHASH:FA6C4C8AE7729C6D128F00A0883B7A82:050D474227760B6267EFCEC6085DD2B2
        public DateTime EarliestRestoreDate()
        {
            return this.Inner.EarliestRestoreDate.GetValueOrDefault();
        }
    }
}
