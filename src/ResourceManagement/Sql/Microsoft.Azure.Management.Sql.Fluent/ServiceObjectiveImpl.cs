// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;

    /// <summary>
    /// Implementation for Azure SQL Server's Service Objective.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TZXJ2aWNlT2JqZWN0aXZlSW1wbA==
    internal partial class ServiceObjectiveImpl :
        Wrapper<ServiceObjectiveInner>,
        IServiceObjective
    {
        private ResourceId resourceId;
        private IServersOperations serversInner;

        ///GENMHASH:889A7F8637F19A4ED19E45F820660A34:B16DDC09F7A2219086D4252E79738610
        public bool IsSystem()
        {
            return Inner.IsSystem.GetValueOrDefault();
        }

        ///GENMHASH:CDF93F9784B71C89BE4A0C05251822C7:B800FA8E3517BE137F6E49C8775C0FA6
        public bool IsDefault()
        {
            return Inner.IsDefault.GetValueOrDefault();
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:9FE42D967416923E070F823D07063A47
        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:E469BC0EB728512D322663135CC847D6
        public string SqlServerName()
        {
            return this.resourceId.Parent.Name;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:D0058F471249EF9DC848FC249DF641F9:896ECA7AFE82035F26A379486227ABF8
        public string ServiceObjectiveName()
        {
            return Inner.ServiceObjectiveName;
        }

        ///GENMHASH:7B3CA3D467253D93C6FF7587C3C0D0B7:F5293CC540B22E551BB92F6FCE17DE2C
        public string Description()
        {
            return Inner.Description;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:D6BF73A4CFB4DF465653CAFA9E2F5177
        public IServiceObjective Refresh()
        {
            this.SetInner(this.serversInner.GetServiceObjective(this.ResourceGroupName(), this.SqlServerName(), this.Name()));
            return this;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return Inner.Id;
        }

        ///GENMHASH:1AB678115EC14BC6A56602D164114315:BE55E38683913BEF23106A037A3E9F1C
        internal ServiceObjectiveImpl(ServiceObjectiveInner innerObject, IServersOperations serversInner)
            : base(innerObject)
        {
            this.resourceId = ResourceId.FromString(Inner.Id);
            this.serversInner = serversInner;
        }

        ///GENMHASH:1703877FCECC33D73EA04EEEF89045EF:EB71563FB99F270D0827FDCDA083A584
        public bool Enabled()
        {
            return Inner.Enabled.GetValueOrDefault();
        }
    }
}
