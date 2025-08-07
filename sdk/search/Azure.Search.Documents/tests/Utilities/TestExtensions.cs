// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using Azure.Search.Documents.Models;
using Microsoft.Spatial;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Extension methods for writing tests.
    /// </summary>
    internal static partial class TestExtensions
    {
        /// <summary>
        /// Get the first element in an AsyncPageable.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="pageable">The AsyncPageable.</param>
        /// <returns>The first element.</returns>
        public static async Task<T> FirstAsync<T>(this AsyncPageable<T> pageable)
        {
            await foreach (T value in pageable)
            {
                return value;
            }
            Assert.Fail("No elements in pageable!");
            return default; // The compiler doesn't know that'll throw...
        }

        /// <summary>
        /// Get the first element in an async enumerable.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="sequence">The async enumerable.</param>
        /// <returns>The first element.</returns>
        public static async Task<T> FirstAsync<T>(this IAsyncEnumerable<T> sequence)
        {
            await foreach (T value in sequence)
            {
                return value;
            }
            Assert.Fail("No elements in sequence!");
            return default; // The compiler doesn't know that'll throw...
        }

        /// <summary>
        /// Convert an AsyncPageable into a List.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="pageable">The AsyncPageable.</param>
        /// <returns>A list of the elements.</returns>
        public static async Task<List<T>> ToListAsync<T>(this AsyncPageable<T> pageable)
        {
            List<T> values = new List<T>();
            await foreach (T value in pageable)
            {
                values.Add(value);
            }
            return values;
        }

        /// <summary>
        /// Convert an AsyncPageable into a List of pages
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="pageable">The AsyncPageable.</param>
        /// <returns>A list of the pages.</returns>
        public static async Task<List<Page<T>>> ToPagesListAsync<T>(this AsyncPageable<T> pageable)
        {
            List<Page<T>> pages = new List<Page<T>>();
            await foreach (Page<T> page in pageable.AsPages())
            {
                pages.Add(page);
            }
            return pages;
        }

        /// <summary>
        /// Generate a random name of alphabetic characters.
        /// </summary>
        /// <param name="random">
        /// The random number generator to use.  This can be Recording.Random
        /// when used with recordings.
        /// </param>
        /// <param name="length">
        /// The length of the random name.  The default value is 8.
        /// </param>
        /// <returns>A random name.</returns>
        public static string GetName(this Random random, int length = 8)
        {
            var buffer = new char[length];
            for (var i = 0; i < length; i++)
            {
                char ch = (char)random.Next((int)'a', (int)'z');
                buffer[i] = ch;
            }
            return new string(buffer);
        }

        /// <summary>
        /// Check if two doubles are equal, with respect to NaN.
        /// </summary>
        public static bool EqualsDouble(this double? x, double? y) =>
            (x == null) ? y == null :
            double.IsNaN(x.Value) ?  y != null && double.IsNaN(y.Value) :
            x == y;

        /// <summary>
        /// Check if two DateTimeOffsets are equal or close.
        /// </summary>
        public static bool EqualsDateTimeOffset(this DateTimeOffset? a, DateTimeOffset? b) =>
            (a == null) ? b == null :
            (b == null) ? false :
            a.Value.EqualsExact(b.Value) ? true :
            // Allow for some loss of precision in the tick count
            (a.Value.UtcTicks / 10000) == (b.Value.UtcTicks / 10000);

        /// <summary>
        /// Check if two values are equal according to their Equals methods.
        /// </summary>
        public static bool EqualsNullSafe<T>(this T a, T b) where T : class =>
            (a == null) ? b == null : a.Equals(b);

        /// <summary>
        /// Check if two sequences are equal.
        /// </summary>
        public static bool SequenceEqualsNullSafe<T>(this T[] a, T[] b) =>
            (a == null) ? (b == null || b.Length == 0) : a.SequenceEqual(b ?? new T[0]);

        /// <summary>
        /// Converts the elements of a collection to strings and concatenates
        /// them into a comma-separated list, or returns null for null or
        /// empty collections.
        /// </summary>
        /// <typeparam name="T">
        /// The type of elements that will be converted to strings.
        /// </typeparam>
        /// <param name="seq">
        /// The collection to turn into a comma-separated string.
        /// </param>
        /// <returns>
        /// A comma-separated string, or null if enumerable is null or empty.
        /// </returns>
        public static string ToCommaSeparatedString<T>(this IEnumerable<T> seq) =>
            (seq == null || !seq.Any()) ?
            null :
            string.Join(",", seq);

        /// <summary>
        /// Create a geography point.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns></returns>
        public static GeoPoint CreateGeoPoint(double longitude, double latitude) =>
            new GeoPoint(new GeoPosition(longitude, latitude));

        public static GeoPoint CreateDynamicGeoPoint(double longitude, double latitude) =>
            CreateGeoPoint(longitude, latitude);

        public static GeographyPoint CreatePoint(double longitude, double latitude) =>
            // Note: GeographyPoint takes latitude first, unlike GeoPoint
            GeographyPoint.Create(latitude, longitude);

        public static SearchDocument CreateDynamicPoint(double longitude, double latitude) =>
            CreatePoint(longitude, latitude).AsDocument();

        /// <summary>
        /// Converts the <see cref="GeographyPoint"/> to a <see cref="SearchDocument"/>.
        /// </summary>
        /// <param name="value">The <see cref="GeographyPoint"/> to convert.</param>
        /// <returns>A <see cref="SearchDocument"/> for the given <paramref name="value"/>.</returns>
        public static SearchDocument AsDocument(this GeographyPoint value)
        {
            if (value == null)
            {
                return null;
            }

            List<double> coords = new List<double>
            {
                value.Longitude,
                value.Latitude,
            };

            if (value.Z != null)
            {
                coords.Add(value.Z.Value);
            }

            return new SearchDocument()
            {
                ["type"] = "Point",
                ["coordinates"] = coords.ToArray()
            };
        }
    }
}
