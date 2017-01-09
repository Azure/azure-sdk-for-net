// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// Implementation for Elastic Pool DatabaseActivity interface.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5FbGFzdGljUG9vbERhdGFiYXNlQWN0aXZpdHlJbXBs
    internal partial class ElasticPoolDatabaseActivityImpl :
        Wrapper<Models.ElasticPoolDatabaseActivityInner>,
        IElasticPoolDatabaseActivity
    {
        private ResourceId resourceId;

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:9FE42D967416923E070F823D07063A47
        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        ///GENMHASH:E7ABDAFE895DE30905D46D515062DB59:44F5F71CD9996FE437F3FF8F3E8E46F9
        public string DatabaseName()
        {
            return this.Inner.DatabaseName;
        }

        internal ElasticPoolDatabaseActivityImpl(ElasticPoolDatabaseActivityInner innerObject) : base(innerObject)
        {
            this.resourceId = ResourceId.FromString(this.Inner.Id);
        }

        ///GENMHASH:C6D8988AF7EA777E24996BD3189A69D3:1DCBD2B51CFB22959B5134B47BA63D40
        public string CurrentElasticPoolName()
        {
            return this.Inner.CurrentElasticPoolName;
        }

        ///GENMHASH:7EC64CE674517E507F9E7D72F93A7DF6:83C9FF1F82052A9E5127DEA47990F4A0
        public string ErrorMessage()
        {
            return this.Inner.ErrorMessage;
        }

        ///GENMHASH:FA2CBCD1D0B27E5D168FBB43CC86517C:A0A5B3AF0643F29A7053E5BEE8C9882A
        public int ErrorSeverity()
        {
            return this.Inner.ErrorSeverity.GetValueOrDefault();
        }

        ///GENMHASH:6CEDF49FFA73F9F5E2F923E4726F2EFA:DCD9AD663CBDFACD6E94C20AED2FD63A
        public int ErrorCode()
        {
            return this.Inner.ErrorCode.GetValueOrDefault();
        }

        ///GENMHASH:20676CF3647D516CBCCD0807065BACB9:55F0618BF6BD745C131C2BBD910CE4A0
        public string ServerName()
        {
            return this.Inner.ServerName;
        }

        ///GENMHASH:64FDD7DAC0F2CAB9406652DA7545E8AA:3F5BF88EAEB847CE67B8C16A5FDD2D28
        public int PercentComplete()
        {
            return this.Inner.PercentComplete.GetValueOrDefault();
        }

        ///GENMHASH:3D9A06EC84CFE73C305A81706B77C1A3:E8933007717208AA135329DCCCF79625
        public string CurrentServiceObjective()
        {
            return this.Inner.CurrentServiceObjective;
        }

        ///GENMHASH:1C96DDC2D75E02C621FE6D4174D08795:A5C5C3EE08E59E95C0BE7571AEFDDAD8
        public string RequestedElasticPoolName()
        {
            return this.Inner.RequestedElasticPoolName;
        }

        ///GENMHASH:7EF5DD4988F82E20D7D72ED9999E024F:3003FB38DE4922367278348E6CECB9E5
        public string RequestedServiceObjective()
        {
            return this.Inner.RequestedServiceObjective;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner.Name;
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

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
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
