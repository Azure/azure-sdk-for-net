// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implementation for RecommendedElasticPool and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5SZWNvbW1lbmRlZEVsYXN0aWNQb29sSW1wbA==
    internal partial class RecommendedElasticPoolImpl :
        Wrapper<Models.RecommendedElasticPoolInner>,
        IRecommendedElasticPool
    {
        private IDatabasesOperations databasesInner;
        private IRecommendedElasticPoolsOperations recommendedElasticPoolsInner;
        private ResourceId resourceId;

        ///GENMHASH:DF46C62E0E8998CD0340B3F8A136F135:2EE5EC6E56E27CC62928F7FDA722AB08
        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> Databases()
        {
            return Inner.Databases.Select(databaseInner => (ISqlDatabase)new SqlDatabaseImpl(databaseInner.Name, databaseInner, databasesInner, Manager)).ToList();
        }

        ///GENMHASH:F018FD6E531156DFCBAA9FAE7F4D8519:F548C4892951BC9F8563B941B288836A
        public double DatabaseDtuMax()
        {
            return Inner.DatabaseDtuMax.GetValueOrDefault();
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:9FE42D967416923E070F823D07063A47
        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        ///GENMHASH:3C9B0CE07C64DBB8CF2AEF14E330501A:2E8B0A743655F7A17FCDF72496CA11B0
        internal RecommendedElasticPoolImpl(RecommendedElasticPoolInner innerObject,
            IDatabasesOperations databasesInner,
            IRecommendedElasticPoolsOperations recommendedElasticPoolsInner,
            ISqlManager manager)
            : base(innerObject)
        {
            this.databasesInner = databasesInner;
            this.recommendedElasticPoolsInner = recommendedElasticPoolsInner;
            resourceId = ResourceId.FromString(Inner.Id);
            Manager = manager;
        }

        public ISqlManager Manager { get; private set; }

        ///GENMHASH:88F495E6170B34BE98D7ECF345A40578:945958DE33096D51BB9DD38A7F3CDAD0
        public double Dtu()
        {
            return Inner.Dtu.GetValueOrDefault();
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:E469BC0EB728512D322663135CC847D6
        public string SqlServerName()
        {
            return this.resourceId.Parent.Name;
        }

        ///GENMHASH:8F7792CF2DCF26479B67E8050646FE84:7C6E87BC11D3AC90258D9ACB04506338
        public double MaxObservedDtu()
        {
            return Inner.MaxObservedDtu.GetValueOrDefault();
        }

        ///GENMHASH:CD775E31F43CBA6304D6EEA9E01682A1:FE7D9343E169D0420CF0E1FC9A9A3736
        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListDatabases()
        {
            var databases = this.recommendedElasticPoolsInner.ListDatabases(
                this.ResourceGroupName(),
                this.SqlServerName(),
                this.Name());

            return databases.Select(databaseInner => (ISqlDatabase)new SqlDatabaseImpl(databaseInner.Name, databaseInner, databasesInner, Manager)).ToList();
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:887D95D040FBCBF81B9BA7419D7F3A39
        public IRecommendedElasticPool Refresh()
        {
            this.SetInner(this.recommendedElasticPoolsInner.Get(this.ResourceGroupName(), this.SqlServerName(), this.Name()));
            return this;
        }

        ///GENMHASH:0A59E82904CE8BB24F650E93009FF62F:554D1CBF22D4FFEB3B544B44B1374357
        public double MaxObservedStorageMB()
        {
            return Inner.MaxObservedStorageMB.GetValueOrDefault();
        }

        ///GENMHASH:C4B4BF3321B70686AA3906F2295146C1:C8E7AAD6A3E0CD79087919190171E915
        public DateTime ObservationPeriodEnd()
        {
            return Inner.ObservationPeriodEnd.GetValueOrDefault();
        }

        ///GENMHASH:65131A7039722B315DD5137C9DE38A3F:7157334C1BFA649E27CA8B6E9688E986
        public string DatabaseEdition()
        {
            return Inner.DatabaseEdition;
        }

        ///GENMHASH:5AD4BED8CF2346B6D40F11D14D91854E:DF850590D9C93BFBF3C7222561137EEB
        public double DatabaseDtuMin()
        {
            return Inner.DatabaseDtuMin.GetValueOrDefault();
        }

        ///GENMHASH:1C25D7B8D9084176A24655682A78634D:F7EA0DF49958322A52E6952D781B9782
        public ISqlDatabase GetDatabase(string databaseName)
        {
            DatabaseInner databaseInner = this.recommendedElasticPoolsInner.GetDatabases(
                this.ResourceGroupName(),
                this.SqlServerName(),
                this.Name(),
                databaseName);

            return new SqlDatabaseImpl(databaseInner.Name, databaseInner, this.databasesInner, Manager);
        }

        ///GENMHASH:77909FCEE2BCE7A1585A5D65D695B384:13846C17B14D55E5F3A4AE220EAFBEDC
        public IList<Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPoolMetric> ListMetrics()
        {
            var metricInner = this.recommendedElasticPoolsInner.ListMetrics(
                this.ResourceGroupName(),
                this.SqlServerName(),
                this.Name());
            return metricInner.Select(recommendedElasticPoolMetricInner => (IRecommendedElasticPoolMetric)new RecommendedElasticPoolMetricImpl(recommendedElasticPoolMetricInner)).ToList();
        }

        ///GENMHASH:E1D13665116B8ECA351FF7B3C332BAF4:132F6DAA63B96E3D5A5059C74C281394
        public DateTime ObservationPeriodStart()
        {
            return Inner.ObservationPeriodStart.GetValueOrDefault();
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:FB97B6A01BB44DE1679EAB5070CAB853:22EC24984E8319C6ED4EE03CBB19BAE4
        public double StorageMB()
        {
            return Inner.StorageMB.GetValueOrDefault();
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return Inner.Id;
        }
    }
}
