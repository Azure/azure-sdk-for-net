// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for GeographicLocation.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLmltcGxlbWVudGF0aW9uLkdlb2dyYXBoaWNMb2NhdGlvbkltcGw=
    internal partial class GeographicLocationImpl  :
        Wrapper<Microsoft.Azure.Management.TrafficManager.Fluent.Models.RegionInner>,
        IGeographicLocation
    {
        ///GENMHASH:9167A56971CBBB9DBAE843BD16B55E09:A40EE04ACAF480ADBC5A9B1AF6DE59FB
        public string Code()
        {
            return this.Inner.Code;
        }

        ///GENMHASH:9C54BB8204CECFD9D4623AA9EDB80CB5:E5F3C3CAF25E9571C4C8F320A95B9A32
        public IReadOnlyList<Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation> DescendantLocations()
        {
            var descendantsLocations = new List<Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation> ();
            var childLocations = ChildLocations();
            descendantsLocations.AddRange(childLocations);
            foreach(var childLocation in childLocations)
            {
                descendantsLocations.AddRange(childLocation.DescendantLocations);
            }
            return descendantsLocations;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:378A836B3346C77AC5B1821D475B4470:9209058628BD683151F6EBF71D1A5265
        public IReadOnlyList<Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation> ChildLocations()
        {
            if (this.Inner.Regions == null || this.Inner.Regions.Count == 0)
            {
                return new List<Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation>();
            }
            var subLocations = new List<Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation>();
            foreach(var innerRegion in this.Inner.Regions)
            {
                subLocations.Add(new GeographicLocationImpl(innerRegion));
            }
            return subLocations;
        }

        ///GENMHASH:E8EC13929422DA79B0B116D6563434FC:D848E871267ECCC2026BC54C7D939143
        internal GeographicLocationImpl(Microsoft.Azure.Management.TrafficManager.Fluent.Models.RegionInner innerRegion) : base(innerRegion)
        {}
    }
}