// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.GeoJson;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class GeoJsonSamples
    {
        [Test]
        public void CreatePoint()
        {
            #region Snippet:CreatePoint
            var point = new GeoPoint(-122.091954, 47.607148);
            #endregion
        }

        [Test]
        public void CreateLineString()
        {
            #region Snippet:CreateLineString
            var line = new GeoLineString(new[]
            {
                new GeoPosition(-122.108727, 47.649383),
                new GeoPosition(-122.081538, 47.640846),
                new GeoPosition(-122.078634, 47.576066),
                new GeoPosition(-122.112686, 47.578559),
            });
            #endregion
        }

        [Test]
        public void CreatePolygon()
        {
            #region Snippet:CreatePolygon
            var polygon = new GeoPolygon(new[]
            {
                new GeoPosition(-122.108727, 47.649383),
                new GeoPosition(-122.081538, 47.640846),
                new GeoPosition(-122.078634, 47.576066),
                new GeoPosition(-122.112686, 47.578559),
                new GeoPosition(-122.108727, 47.649383),
            });
            #endregion
        }

        [Test]
        public void CreatePolygonWithHoles()
        {
            #region Snippet:CreatePolygonWithHoles
            var polygon = new GeoPolygon(new[]
            {
                // Outer ring
                new GeoLinearRing(new[]
                {
                    new GeoPosition(-122.108727, 47.649383),
                    new GeoPosition(-122.081538, 47.640846),
                    new GeoPosition(-122.078634, 47.576066),
                    new GeoPosition(-122.112686, 47.578559),
                    // Last position same as first
                    new GeoPosition(-122.108727, 47.649383),
                }),
                // Inner ring
                new GeoLinearRing(new[]
                {
                    new GeoPosition(-122.102370, 47.607370),
                    new GeoPosition(-122.083488, 47.608007),
                    new GeoPosition(-122.085419, 47.597879),
                    new GeoPosition(-122.107005, 47.596895),
                    // Last position same as first
                    new GeoPosition(-122.102370, 47.607370),
                })
            });
            #endregion
        }
    }
}
