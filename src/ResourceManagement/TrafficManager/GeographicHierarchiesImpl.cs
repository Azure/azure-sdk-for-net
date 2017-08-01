// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.TrafficManager.Fluent.Models;

    /// <summary>
    /// Implementation for GeographicHierarchies.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLmltcGxlbWVudGF0aW9uLkdlb2dyYXBoaWNIaWVyYXJjaGllc0ltcGw=
    internal partial class GeographicHierarchiesImpl  :
        Wrapper<Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicHierarchiesOperations>,
        IGeographicHierarchiesBeta
    {
        private ITrafficManager manager;
        ///GENMHASH:0A1A0463CFC77314424EC4A0283ED5A4:431E308A3744A61C1195798E3EE20640
        internal  GeographicHierarchiesImpl(ITrafficManager trafficManager, IGeographicHierarchiesOperations inner) : base(inner)
        {
            this.manager = trafficManager;
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:168EFDB95EECDB98D4BDFCCA32101AC1
        public ITrafficManager Manager()
        {
            return this.manager;
        }

        ///GENMHASH:5D46046CA62DA28A3B0AB7AAE38F5338:25E1D5A2A6C98FF4818C93F1AAE47D6D
        public IGeographicLocation GetRoot()
        {
            TrafficManagerGeographicHierarchyInner defaultHierarchy = Extensions.Synchronize(() => this.Inner.GetDefaultAsync());
            if (defaultHierarchy == null)
            {
                return null;
            }
            return new GeographicLocationImpl(defaultHierarchy.GeographicHierarchy);
        }
    }
}