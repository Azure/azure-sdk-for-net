// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.GeoJson;

namespace Azure.Maps.Render
{
    /// <summary> The utilities for tile index and pixel calculation. </summary>
    public static class TileMath
    {
        //Earth radius in meters.
        private const double EarthRadius = 6378137;

        private const double MinLatitude = -85.05112878;
        private const double MaxLatitude = 85.05112878;
        private const double MinLongitude = -180;
        private const double MaxLongitude = 180;

        /// <summary>
        /// Clips a number to the specified minimum and maximum values.
        /// </summary>
        /// <param name="n">The number to clip.</param>
        /// <param name="minValue">Minimum allowable value.</param>
        /// <param name="maxValue">Maximum allowable value.</param>
        /// <returns>The clipped value.</returns>
        private static double Clip(double n, double minValue, double maxValue)
        {
            return Math.Min(Math.Max(n, minValue), maxValue);
        }

        /// <summary>
        /// Calculates width and height of the map in pixels at a specific zoom level from -180 degrees to 180 degrees.
        /// </summary>
        /// <param name="zoom">Zoom Level to calculate width at.</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <returns>Width and height of the map in pixels</returns>
        private static double MapSize(double zoom, int tileSize)
        {
            return Math.Ceiling(tileSize * Math.Pow(2, zoom));
        }

        /// <summary>
        /// Calculates the Ground resolution at a specific degree of latitude in meters per pixel.
        /// </summary>
        /// <param name="latitude">Degree of latitude to calculate resolution at</param>
        /// <param name="zoom">Zoom level to calculate resolution at.</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <returns>Ground resolution in meters per pixels</returns>
        private static double GroundResolution(double latitude, double zoom, int tileSize)
        {
            latitude = Clip(latitude, MinLatitude, MaxLatitude);
            return Math.Cos(latitude * Math.PI / 180) * 2 * Math.PI * EarthRadius / MapSize(zoom, tileSize);
        }

        /// <summary>
        /// Determines the map scale at a specified latitude, level of detail, and screen resolution.
        /// </summary>
        /// <param name="latitude">Latitude (in degrees) at which to measure the map scale.</param>
        /// <param name="zoom">Level of detail, from 1 (lowest detail) to 23 (highest detail).</param>
        /// <param name="screenDpi">Resolution of the screen, in dots per inch.</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <returns>The map scale, expressed as the denominator N of the ratio 1 : N.</returns>
        private static double MapScale(double latitude, double zoom, int screenDpi, int tileSize)
        {
            return GroundResolution(latitude, zoom, tileSize) * screenDpi / 0.0254;
        }

        /// <summary>
        /// Global Converts a Pixel coordinate into a geospatial coordinate at a specified zoom level.
        /// Global Pixel coordinates are relative to the top left corner of the map (90, -180)
        /// </summary>
        /// <param name="pixel">Pixel coordinates in the format of GeoPosition.</param>
        /// <param name="zoom">Zoom level</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <returns>A position value in the format GeoPosition.</returns>
        private static GeoPosition GlobalPixelToPosition(GeoPosition pixel, double zoom, int tileSize)
        {
            var mapSize = MapSize(zoom, tileSize);

            var x = (Clip(pixel.Longitude, 0, mapSize - 1) / mapSize) - 0.5;
            var y = 0.5 - (Clip(pixel.Latitude, 0, mapSize - 1) / mapSize);

            return new GeoPosition(
                360 * x,    //Longitude
                90 - 360 * Math.Atan(Math.Exp(-y * 2 * Math.PI)) / Math.PI  //Latitude
            );
        }

        /// <summary>
        /// Converts a point from latitude/longitude WGS-84 coordinates (in degrees) into pixel XY coordinates at a specified level of detail.
        /// </summary>
        /// <param name="position">Position coordinate in the format of GeoPosition</param>
        /// <param name="zoom">Zoom level.</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <returns>A global pixel coordinate.</returns>
        private static GeoPosition PositionToGlobalPixel(GeoPosition position, int zoom, int tileSize)
        {
            var latitude = Clip(position.Latitude, MinLatitude, MaxLatitude);
            var longitude = Clip(position.Longitude, MinLongitude, MaxLongitude);

            var x = (longitude + 180) / 360;
            var sinLatitude = Math.Sin(latitude * Math.PI / 180);
            var y = 0.5 - Math.Log((1 + sinLatitude) / (1 - sinLatitude)) / (4 * Math.PI);

            var mapSize = MapSize(zoom, tileSize);

            return new GeoPosition(
                Clip(x * mapSize + 0.5, 0, mapSize - 1),
                Clip(y * mapSize + 0.5, 0, mapSize - 1)
            );
        }

        /// <summary>
        /// Converts pixel XY coordinates into tile XY coordinates of the tile containing the specified pixel.
        /// </summary>
        /// <param name="pixel">Pixel coordinates in the format of GeoPosition.</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <param name="tileX">Output parameter receiving the tile X coordinate.</param>
        /// <param name="tileY">Output parameter receiving the tile Y coordinate.</param>
        private static void GlobalPixelToTileXY(GeoPosition pixel, int tileSize, out int tileX, out int tileY)
        {
            tileX = (int)(pixel.Longitude / tileSize);
            tileY = (int)(pixel.Latitude / tileSize);
        }

        /// <summary>
        /// Performs a scale transform on a global pixel value from one zoom level to another.
        /// </summary>
        /// <param name="pixel">Pixel coordinates in the format of GeoPosition.</param>
        /// <param name="oldZoom">The zoom level in which the input global pixel value is from.</param>
        /// <param name="newZoom">The new zoom level in which the output global pixel values should be aligned with.</param>
        /// <returns>A scale pixel coordinate.</returns>
        private static GeoPosition ScaleGlobalPixel(GeoPosition pixel, double oldZoom, double newZoom)
        {
            var scale = Math.Pow(2, oldZoom - newZoom);

            return new GeoPosition(pixel.Longitude * scale, pixel.Latitude * scale);
        }

        /// <summary>
        /// Converts tile XY coordinates into a global pixel XY coordinates of the upper-left pixel of the specified tile.
        /// </summary>
        /// <param name="tileX">Tile X coordinate.</param>
        /// <param name="tileY">Tile Y coordinate.</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        private static GeoPosition TileXYToGlobalPixel(int tileX, int tileY, int tileSize)
        {
            return new GeoPosition(tileX * tileSize, tileY * tileSize);
        }

        /// <summary>
        /// Converts tile XY coordinates into a quadkey at a specified level of detail.
        /// </summary>
        /// <param name="tileX">Tile X coordinate.</param>
        /// <param name="tileY">Tile Y coordinate.</param>
        /// <param name="zoom">Zoom level</param>
        /// <returns>A string containing the quadkey.</returns>
        private static string TileXYToQuadKey(int tileX, int tileY, int zoom)
        {
            var quadKey = new StringBuilder();
            for (int i = zoom; i > 0; i--)
            {
                char digit = '0';
                int mask = 1 << (i - 1);
                if ((tileX & mask) != 0)
                {
                    digit++;
                }
                if ((tileY & mask) != 0)
                {
                    digit++;
                    digit++;
                }
                quadKey.Append(digit);
            }
            return quadKey.ToString();
        }

        /// <summary>
        /// Converts a quadkey into tile XY coordinates.
        /// </summary>
        /// <param name="quadKey">Quadkey of the tile.</param>
        /// <param name="tileX">Output parameter receiving the tile X coordinate.</param>
        /// <param name="tileY">Output parameter receiving the tile Y coordinate.</param>
        /// <param name="zoom">Output parameter receiving the zoom level.</param>
        private static void QuadKeyToTileXY(string quadKey, out int tileX, out int tileY, out int zoom)
        {
            tileX = tileY = 0;
            zoom = quadKey.Length;
            for (int i = zoom; i > 0; i--)
            {
                int mask = 1 << (i - 1);
                switch (quadKey[zoom - i])
                {
                    case '0':
                        break;

                    case '1':
                        tileX |= mask;
                        break;

                    case '2':
                        tileY |= mask;
                        break;

                    case '3':
                        tileX |= mask;
                        tileY |= mask;
                        break;

                    default:
                        throw new ArgumentException("Invalid QuadKey digit sequence.");
                }
            }
        }

        /// <summary>
        /// Calculates the XY tile coordinates that a coordinate falls into for a specific zoom level.
        /// </summary>
        /// <param name="position">Position coordinate in the format of GeoPosition</param>
        /// <param name="zoom">Zoom level</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <param name="tileX">Output parameter receiving the tile X position.</param>
        /// <param name="tileY">Output parameter receiving the tile Y position.</param>
        public static void PositionToTileXY(GeoPosition position, int zoom, int tileSize, out int tileX, out int tileY)
        {
            var latitude = Clip(position.Latitude, MinLatitude, MaxLatitude);
            var longitude = Clip(position.Longitude, MinLongitude, MaxLongitude);

            var x = (longitude + 180) / 360;
            var sinLatitude = Math.Sin(latitude * Math.PI / 180);
            var y = 0.5 - Math.Log((1 + sinLatitude) / (1 - sinLatitude)) / (4 * Math.PI);

            //tileSize needed in calculations as in rare cases the multiplying/rounding/dividing can make the difference of a pixel which can result in a completely different tile.
            var mapSize = MapSize(zoom, tileSize);
            tileX = (int)Math.Floor(Clip(x * mapSize + 0.5, 0, mapSize - 1) / tileSize);
            tileY = (int)Math.Floor(Clip(y * mapSize + 0.5, 0, mapSize - 1) / tileSize);
        }

        /// <summary>
        /// Calculates the tile quadkey strings that are within a specified viewport.
        /// </summary>
        /// <param name="position">Position coordinate in the format of GeoPosition</param>
        /// <param name="zoom">Zoom level</param>
        /// <param name="width">The width of the map viewport in pixels.</param>
        /// <param name="height">The height of the map viewport in pixels.</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <returns>A list of quadkey strings that are within the specified viewport.</returns>
        private static string[] GetQuadkeysInView(GeoPosition position, int zoom, int width, int height, int tileSize)
        {
            var p = PositionToGlobalPixel(position, zoom, tileSize);

            var top = p.Latitude - height * 0.5;
            var left = p.Longitude - width * 0.5;

            var bottom = p.Latitude + height * 0.5;
            var right = p.Longitude + width * 0.5;

            var tl = GlobalPixelToPosition(new GeoPosition(left, top), zoom, tileSize);
            var br = GlobalPixelToPosition(new GeoPosition(right, bottom), zoom, tileSize);

            var boundingBox = new GeoBoundingBox(tl.Longitude, br.Latitude, br.Longitude, tl.Latitude);

            return GetQuadkeysInBoundingBox(boundingBox, zoom, tileSize);
        }

        /// <summary>
        /// Calculates the tile quadkey strings that are within a bounding box at a specific zoom level.
        /// </summary>
        /// <param name="boundingBox">A geo bounding box defined the west, south, east, north coordinates of the rectangle region on the map.</param>
        /// <param name="zoom">Zoom level to calculate tiles for.</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <returns>A list of quadkey strings.</returns>
        private static string[] GetQuadkeysInBoundingBox(GeoBoundingBox boundingBox, int zoom, int tileSize)
        {
            var keys = new List<string>();

            if (boundingBox != null)
            {
                PositionToTileXY(new GeoPosition(boundingBox.North, boundingBox.West), zoom, tileSize, out int tlX, out int tlY);
                PositionToTileXY(new GeoPosition(boundingBox.South, boundingBox.East), zoom, tileSize, out int brX, out int brY);

                for (int x = tlX; x <= brX; x++)
                {
                    for (int y = tlY; y <= brY; y++)
                    {
                        keys.Add(TileXYToQuadKey(x, y, zoom));
                    }
                }
            }

            return keys.ToArray();
        }

        /// <summary>
        /// Calculates the bounding box of a tile.
        /// </summary>
        /// <param name="tileX">Tile X coordinate</param>
        /// <param name="tileY">Tile Y coordinate</param>
        /// <param name="zoom">Zoom level</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <returns>A bounding box of the tile defined as an array of numbers in the format of GeoBoundingBox.</returns>
        public static GeoBoundingBox TileXYToBoundingBox(int tileX, int tileY, double zoom, int tileSize)
        {
            //Top left corner pixel coordinates
            var x1 = (double)(tileX * tileSize);
            var y1 = (double)(tileY * tileSize);

            //Bottom right corner pixel coordinates
            var x2 = (double)(x1 + tileSize);
            var y2 = (double)(y1 + tileSize);

            var nw = GlobalPixelToPosition(new GeoPosition(x1, y1), zoom, tileSize);
            var se = GlobalPixelToPosition(new GeoPosition(x2, y2), zoom, tileSize);

            return new GeoBoundingBox(nw.Longitude, se.Latitude, se.Longitude, nw.Latitude);
        }

        /// <summary>
        /// Calculates the best map view (center, zoom) for a bounding box on a map.
        /// </summary>
        /// <param name="boundingBox">A geo bounding box defined the west, south, east, north coordinates of the rectangle region on the map.</param>
        /// <param name="mapWidth">Map width in pixels.</param>
        /// <param name="mapHeight">Map height in pixels.</param>
        /// <param name="padding">Width in pixels to use to create a buffer around the map. This is to keep markers from being cut off on the edge</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <param name="centerLat">Output parameter receiving the center latitude coordinate.</param>
        /// <param name="centerLon">Output parameter receiving the center longitude coordinate.</param>
        /// <param name="zoom">Output parameter receiving the zoom level</param>
        public static void BestMapView(GeoBoundingBox boundingBox, double mapWidth, double mapHeight, int padding, int tileSize, out double centerLat, out double centerLon, out double zoom)
        {
            if (boundingBox == null)
            {
                centerLat = 0;
                centerLon = 0;
                zoom = 1;
                return;
            }

            double boundsDeltaX;

            //Check if east value is greater than west value which would indicate that bounding box crosses the antimeridian.
            if (boundingBox.East > boundingBox.West)
            {
                boundsDeltaX = boundingBox.East - boundingBox.West;
                centerLon = (boundingBox.East + boundingBox.West) / 2;
            }
            else
            {
                boundsDeltaX = 360 - (boundingBox.West - boundingBox.East);
                centerLon = ((boundingBox.East + boundingBox.West) / 2 + 360) % 360 - 180;
            }

            var ry1 = Math.Log((Math.Sin(boundingBox.South * Math.PI / 180) + 1) / Math.Cos(boundingBox.South * Math.PI / 180));
            var ry2 = Math.Log((Math.Sin(boundingBox.North * Math.PI / 180) + 1) / Math.Cos(boundingBox.North * Math.PI / 180));
            var ryc = (ry1 + ry2) / 2;

            centerLat = Math.Atan(Math.Sinh(ryc)) * 180 / Math.PI;

            var resolutionHorizontal = boundsDeltaX / (mapWidth - padding * 2);

            var vy0 = Math.Log(Math.Tan(Math.PI * (0.25 + centerLat / 360)));
            var vy1 = Math.Log(Math.Tan(Math.PI * (0.25 + boundingBox.North / 360)));
            var zoomFactorPowered = (mapHeight * 0.5 - padding) / (40.7436654315252 * (vy1 - vy0));
            var resolutionVertical = 360.0 / (zoomFactorPowered * tileSize);

            var resolution = Math.Max(resolutionHorizontal, resolutionVertical);

            zoom = Math.Log(360 / (resolution * tileSize), 2);
        }
    }
}
