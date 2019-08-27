namespace ManagedNetwork.Tests.Helpers
{
    using Microsoft.Azure.Management.ManagedNetwork.Models;
    using Xunit;
    using System.Collections.Generic;

    public static class Comparator
    {
        public static void CompareManagedNetwork(ManagedNetworkModel mn1, ManagedNetworkModel mn2)
        {
            Assert.Equal(mn1.Location, mn2.Location);

            CompareScope(mn1.Scope, mn2.Scope);

            if (mn1.Connectivity == null)
            {
               if(mn2.Connectivity != null)
               {
                    Assert.Equal(0, mn2.Connectivity.Groups.Count);
                    Assert.Equal(0, mn2.Connectivity.Peerings.Count);
                }
            }
            else
            {
                CompareConnectivityCollection(mn1.Connectivity, mn2.Connectivity);
            }
            
        }

        public static void CompareScope(Scope s1, Scope s2)
        {
            if (s1.ManagementGroups != null)
            { 
                Assert.Equal(s1.ManagementGroups.Count, s2.ManagementGroups.Count);
                for (int i = 0; i < s1.ManagementGroups.Count; i++)
                {
                    Assert.Equal(s1.ManagementGroups[i].Id, s2.ManagementGroups[i].Id);
                }
            }

            if (s1.Subscriptions != null)
            {
                Assert.Equal(s1.Subscriptions.Count, s2.Subscriptions.Count);
                for (int i = 0; i < s1.Subscriptions.Count; i++)
                {
                    Assert.Equal(s1.Subscriptions[i].Id, s2.Subscriptions[i].Id);
                }
            }

            if (s1.VirtualNetworks != null)
            {
                Assert.Equal(s1.VirtualNetworks.Count, s2.VirtualNetworks.Count);
                for (int i = 0; i < s1.VirtualNetworks.Count; i++)
                {
                    Assert.Equal(s1.VirtualNetworks[i].Id, s2.VirtualNetworks[i].Id);
                }
            }

            if (s1.VirtualNetworks != null)
            {
                Assert.Equal(s1.Subnets.Count, s2.Subnets.Count);
                for (int i = 0; i < s1.Subnets.Count; i++)
                {
                    Assert.Equal(s1.Subnets[i].Id, s2.Subnets[i].Id);
                }
            }
        }
		public static void CompareManagedNetworkGroup(ManagedNetworkGroup g1, ManagedNetworkGroup g2)
        {
            if (g1.ManagementGroups == null)
            {
                Assert.Equal(0, g2.ManagementGroups.Count);
            }
            else
            {
                Assert.Equal(g1.ManagementGroups.Count, g2.ManagementGroups.Count);
                for (int i = 0; i < g1.ManagementGroups.Count; i++)
                {
                    Assert.Equal(g1.ManagementGroups[i].Id, g2.ManagementGroups[i].Id);
                }
            }

            if (g1.Subscriptions == null)
            {
                Assert.Equal(0, g2.Subscriptions.Count);
            }
            else
            {
                Assert.Equal(g1.Subscriptions.Count, g2.Subscriptions.Count);
                for (int i = 0; i < g1.Subscriptions.Count; i++)
                {
                    Assert.Equal(g1.Subscriptions[i].Id, g2.Subscriptions[i].Id);
                }
            }

            if (g1.VirtualNetworks == null)
            {
                Assert.Equal(0, g2.VirtualNetworks.Count);
            }
            else
            {
                Assert.Equal(g1.VirtualNetworks.Count, g2.VirtualNetworks.Count);
                for (int i = 0; i < g1.VirtualNetworks.Count; i++)
                {
                    Assert.Equal(g1.VirtualNetworks[i].Id, g2.VirtualNetworks[i].Id);
                }
            }

            if (g1.Subnets == null)
            {
                if (g1.Subnets != null)
                {
                    Assert.Equal(0, g2.Subnets.Count);
                }
                    
            }
            else
            {
                Assert.Equal(g1.Subnets.Count, g2.Subnets.Count);
                for (int i = 0; i < g1.Subnets.Count; i++)
                {
                    Assert.Equal(g1.Subnets[i].Id, g2.Subnets[i].Id);
                }
            }
        }

		public static void CompareConnectivityCollection(ConnectivityCollection c1, ConnectivityCollection c2)
        {
            Assert.Equal(c1.Groups.Count, c2.Groups.Count);
            for (int i = 0; i < c1.Groups.Count; i++)
            {
                CompareManagedNetworkGroup(c1.Groups[i], c2.Groups[i]);
            }

            Assert.Equal(c1.Peerings.Count, c2.Peerings.Count);
            for (int i = 0; i < c1.Peerings.Count; i++)
            {
                ComparePeeringPolicy(c1.Peerings[i], c1.Peerings[i]);
            }
        }

        public static void CompareTags(IList<string> tags1, IList<string> tags2)
        {
            Assert.Equal(tags1.Count, tags2.Count);
            for (int i = 0; i < tags1.Count; i++)
            {
                Assert.Equal(tags1[i], tags2[i]);
            }
        }
 
        public static void ComparePeeringPolicy(ManagedNetworkPeeringPolicy p1, ManagedNetworkPeeringPolicy p2)
        {
            if (p1.Properties.Hub == null)
            {
                Assert.Null(p2.Properties.Hub);
            }
            else
            {
                Assert.Equal(p1.Properties.Hub.Id, p2.Properties.Hub.Id);
            }

            if (p1.Properties.Spokes == null)
            {
                if (p2.Properties.Spokes != null)
                {
                    Assert.Equal(0, p2.Properties.Spokes.Count);
                }

            }
            else
            {
                Assert.Equal(p1.Properties.Spokes.Count, p2.Properties.Spokes.Count);
                for (int i = 0; i < p1.Properties.Spokes.Count; i++)
                {
                    Assert.Equal(p1.Properties.Spokes[i].Id, p2.Properties.Spokes[i].Id);
                }
            }

            if (p1.Properties.Mesh == null)
            {
                if (p2.Properties.Mesh != null)
                {
                    Assert.Equal(0, p2.Properties.Mesh.Count);
                }
            }
            else
            {
                Assert.Equal(p1.Properties.Mesh.Count, p2.Properties.Mesh.Count);
                for (int i = 0; i < p1.Properties.Mesh.Count; i++)
                {
                    Assert.Equal(p1.Properties.Mesh[i].Id, p2.Properties.Mesh[i].Id);
                }
            }

        }
    }
}
