// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// Implementation for Elastic Pool Activity interface.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5FbGFzdGljUG9vbEFjdGl2aXR5SW1wbA==
    internal partial class ElasticPoolActivityImpl :
        Wrapper<Models.ElasticPoolActivityInner>,
        IElasticPoolActivity
    {
        private ResourceId resourceId;

        ///GENMHASH:957BA7B4E61C9B91983ED17E2B61DBD7:9549FCCFE13908133153A6585989F147
        public string ElasticPoolName()
        {
            return Inner.ElasticPoolName;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:9FE42D967416923E070F823D07063A47
        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        ///GENMHASH:8F0EFF0AACCEFD64C58E15E16D3EC64E:337753FAB2FD3F556E28B3B41F66A995
        public int RequestedDatabaseDtuMin()
        {
            return Inner.RequestedDatabaseDtuMin.GetValueOrDefault();
        }

        ///GENMHASH:7EC64CE674517E507F9E7D72F93A7DF6:83C9FF1F82052A9E5127DEA47990F4A0
        public string ErrorMessage()
        {
            return Inner.ErrorMessage;
        }

        ///GENMHASH:FA2CBCD1D0B27E5D168FBB43CC86517C:A0A5B3AF0643F29A7053E5BEE8C9882A
        public int ErrorSeverity()
        {
            return Inner.ErrorSeverity.GetValueOrDefault();
        }

        ///GENMHASH:6CEDF49FFA73F9F5E2F923E4726F2EFA:DCD9AD663CBDFACD6E94C20AED2FD63A
        public int ErrorCode()
        {
            return Inner.ErrorCode.GetValueOrDefault();
        }

        ///GENMHASH:20676CF3647D516CBCCD0807065BACB9:55F0618BF6BD745C131C2BBD910CE4A0
        public string ServerName()
        {
            return Inner.ServerName;
        }

        ///GENMHASH:64FDD7DAC0F2CAB9406652DA7545E8AA:3F5BF88EAEB847CE67B8C16A5FDD2D28
        public int PercentComplete()
        {
            return Inner.PercentComplete.GetValueOrDefault();
        }

        ///GENMHASH:7E31FD4694B88FC2F9C1EE28D77055ED:EDE1E4292DB486E168AE4CFE8282FCA2
        public int RequestedDtu()
        {
            return Inner.RequestedDtu.GetValueOrDefault();
        }

        ///GENMHASH:1C96DDC2D75E02C621FE6D4174D08795:A5C5C3EE08E59E95C0BE7571AEFDDAD8
        public string RequestedElasticPoolName()
        {
            return Inner.RequestedElasticPoolName;
        }

        ///GENMHASH:B045F78FBBD13C1DFD9AB3659442B01B:95FDB4476A86D2D89C844159139FF9F4
        internal ElasticPoolActivityImpl(ElasticPoolActivityInner innerObject) : base(innerObject)
        {
            this.resourceId = ResourceId.FromString(Inner.Id);
        }

        ///GENMHASH:579156BC87293AD83F70BBF347CFEF47:8ACA8E03B61F5FC45CB2DFEE3F51696A
        public long RequestedStorageLimitInGB()
        {
            return Inner.RequestedStorageLimitInGB.GetValueOrDefault();
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:A08302619254C2A4BBCEC7165449AD96
        public string Name()
        {
            return this.resourceId.Name;
        }

        ///GENMHASH:7EF3D853483A47D9B9984C075548A5DB:740F056656F4A0D00BEAED4AA4FBF109
        public int RequestedDatabaseDtuMax()
        {
            return Inner.RequestedDatabaseDtuMax.GetValueOrDefault();
        }

        ///GENMHASH:03526126BC38B1E6BD9561737558EC5D:BA5AF11F0F62FFF9B79F496BD38C3EB8
        public string OperationId()
        {
            return Inner.OperationId;
        }

        ///GENMHASH:8550B4F26F41D82222F735D9324AEB6D:42AE1A0453935D9BF88147F2F9C3EC20
        public DateTime StartTime()
        {
            return Inner.StartTime.GetValueOrDefault();
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:003E1843567E7760DFADC015F30E6AF4
        public string Id()
        {
            return this.resourceId.Id;
        }

        ///GENMHASH:3C1909F3137E91E93C57B90768BECD1A:561DFB636B157F511DFC1C40D1BDE39E
        public DateTime EndTime()
        {
            return Inner.EndTime.GetValueOrDefault();
        }

        ///GENMHASH:AEE17FD09F624712647F5EBCEC141EA5:F31B0F3D0CD1A4C57DB28EB70C9E094A
        public string State()
        {
            return Inner.State;
        }

        ///GENMHASH:01229D1464D8E021DA051A6483890125:1E5595F4838189B1321C43E5E3F05009
        public string Operation()
        {
            return Inner.Operation;
        }
    }
}
