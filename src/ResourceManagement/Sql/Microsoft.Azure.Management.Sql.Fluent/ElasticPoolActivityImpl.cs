// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5FbGFzdGljUG9vbEFjdGl2aXR5SW1wbA==
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// Implementation for Elastic Pool Activity interface.
    /// </summary>
    internal partial class ElasticPoolActivityImpl :
        Wrapper<Models.ElasticPoolActivityInner>,
        IElasticPoolActivity
    {
        private ResourceId resourceId;

        ///GENMHASH:957BA7B4E61C9B91983ED17E2B61DBD7:9549FCCFE13908133153A6585989F147
        public string ElasticPoolName()
        {
            return this.Inner.ElasticPoolName;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:9FE42D967416923E070F823D07063A47
        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        ///GENMHASH:8F0EFF0AACCEFD64C58E15E16D3EC64E:70C70E99D62337F4F9F74F367F59294D
        public int RequestedDatabaseDtuMin()
        {
            return this.Inner.RequestedDatabaseDtuMin.GetValueOrDefault();
        }

        ///GENMHASH:7EC64CE674517E507F9E7D72F93A7DF6:83C9FF1F82052A9E5127DEA47990F4A0
        public string ErrorMessage()
        {
            return this.Inner.ErrorMessage;
        }

        ///GENMHASH:FA2CBCD1D0B27E5D168FBB43CC86517C:A6A90D47E8DA21F45A16E7EE88010601
        public int ErrorSeverity()
        {
            return this.Inner.ErrorSeverity.GetValueOrDefault();
        }

        ///GENMHASH:6CEDF49FFA73F9F5E2F923E4726F2EFA:739A3B25CE36543C9E40B0962F594D09
        public int ErrorCode()
        {
            return this.Inner.ErrorCode.GetValueOrDefault();
        }

        ///GENMHASH:20676CF3647D516CBCCD0807065BACB9:55F0618BF6BD745C131C2BBD910CE4A0
        public string ServerName()
        {
            return this.Inner.ServerName;
        }

        ///GENMHASH:64FDD7DAC0F2CAB9406652DA7545E8AA:60E139E176D51169A736C4BE93730827
        public int PercentComplete()
        {
            return this.Inner.PercentComplete.GetValueOrDefault();
        }

        ///GENMHASH:7E31FD4694B88FC2F9C1EE28D77055ED:CA86D45826B2E49129DE863D3F255A39
        public int RequestedDtu()
        {
            return this.Inner.RequestedDtu.GetValueOrDefault();
        }

        ///GENMHASH:1C96DDC2D75E02C621FE6D4174D08795:A5C5C3EE08E59E95C0BE7571AEFDDAD8
        public string RequestedElasticPoolName()
        {
            return this.Inner.RequestedElasticPoolName;
        }

        internal ElasticPoolActivityImpl(ElasticPoolActivityInner innerObject) : base(innerObject)
        {
            this.resourceId = ResourceId.ParseResourceId(this.Inner.Id);
        }

        ///GENMHASH:579156BC87293AD83F70BBF347CFEF47:40F8C0C1F215FC2B52066186AE13B563
        public long RequestedStorageLimitInGB()
        {
            return this.Inner.RequestedStorageLimitInGB.GetValueOrDefault();
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:A08302619254C2A4BBCEC7165449AD96
        public string Name()
        {
            return this.resourceId.Name;
        }

        ///GENMHASH:7EF3D853483A47D9B9984C075548A5DB:B29ADBDD046DABE4C442108174E534D6
        public int RequestedDatabaseDtuMax()
        {
            return this.Inner.RequestedDatabaseDtuMax.GetValueOrDefault();
        }

        ///GENMHASH:03526126BC38B1E6BD9561737558EC5D:BA5AF11F0F62FFF9B79F496BD38C3EB8
        public string OperationId()
        {
            return this.Inner.OperationId;
        }

        ///GENMHASH:8550B4F26F41D82222F735D9324AEB6D:42AE1A0453935D9BF88147F2F9C3EC20
        public DateTime StartTime()
        {
            return this.Inner.StartTime.GetValueOrDefault();
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:003E1843567E7760DFADC015F30E6AF4
        public string Id()
        {
            return this.resourceId.Id;
        }

        ///GENMHASH:3C1909F3137E91E93C57B90768BECD1A:561DFB636B157F511DFC1C40D1BDE39E
        public DateTime EndTime()
        {
            return this.Inner.EndTime.GetValueOrDefault();
        }

        ///GENMHASH:AEE17FD09F624712647F5EBCEC141EA5:F31B0F3D0CD1A4C57DB28EB70C9E094A
        public string State()
        {
            return this.Inner.State;
        }

        ///GENMHASH:01229D1464D8E021DA051A6483890125:1E5595F4838189B1321C43E5E3F05009
        public string Operation()
        {
            return this.Inner.Operation;
        }
    }
}
