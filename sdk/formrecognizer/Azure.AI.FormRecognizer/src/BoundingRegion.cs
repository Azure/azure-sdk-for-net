// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenSuppress(nameof(BoundingRegion), typeof(int), typeof(IEnumerable<float>), typeof(IDictionary<string, BinaryData>))]
    //[CodeGenSuppress("Polygon")]
    public readonly partial struct BoundingRegion : IEquatable<BoundingRegion>
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private readonly IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary>
        /// Initializes a new instance of BoundingRegion. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal BoundingRegion(int pageNumber, IReadOnlyList<PointF> boundingPolygon)
        {
            PageNumber = pageNumber;
            BoundingPolygon = boundingPolygon;
        }

        /// <summary>
        /// 1-based page number of page containing the bounding region.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// The bounding polygon that outlines this region. Units are in pixels for images and inches for
        /// PDF. The <see cref="DocumentPageLengthUnit"/> type of a recognized page can be found at <see cref="DocumentPage.Unit"/>.
        /// </summary>
        [CodeGenMemberSerializationHooks(SerializationValueHook = nameof(WriteBoundingPolygon), DeserializationValueHook = nameof(ReadBoundingPolygon))]
        [CodeGenMember("Polygon")]
        public IReadOnlyList<PointF> BoundingPolygon { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteBoundingPolygon(Utf8JsonWriter writer)
        {
            writer.WriteStartArray();
            foreach (var item in BoundingPolygon)
            {
                writer.WriteNumberValue(item.X);
                writer.WriteNumberValue(item.Y);
            }
            writer.WriteEndArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadBoundingPolygon(JsonProperty property, ref IReadOnlyList<PointF> boundingPolygon)
        {
            List<float> array = new List<float>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(item.GetSingle());
            }
            boundingPolygon = ClientCommon.ConvertToListOfPointF(array);
        }

        /// <summary>
        /// Indicates whether the current <see cref="BoundingRegion"/> is equal to another object of the same type.
        /// They are considered equal if they have the same type, the same <see cref="PageNumber"/>, and the same point
        /// coordinates in <see cref="BoundingPolygon"/>.
        /// </summary>
        /// <param name="obj">An object to compare with this <see cref="BoundingRegion"/>.</param>
        /// <returns><c>true</c> if the current <see cref="BoundingRegion"/> is equal to the <paramref name="obj"/> parameter; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BoundingRegion other && Equals(other);

        /// <summary>
        /// Indicates whether the current <see cref="BoundingRegion"/> is equal to another object of the same type.
        /// They are considered equal if they have the same <see cref="PageNumber"/> and the same point coordinates
        /// in <see cref="BoundingPolygon"/>.
        /// </summary>
        /// <param name="other">An object to compare with this <see cref="BoundingRegion"/>.</param>
        /// <returns><c>true</c> if the current <see cref="BoundingRegion"/> is equal to the <paramref name="other"/> parameter; otherwise, <c>false</c>.</returns>
        public bool Equals(BoundingRegion other)
        {
            if (PageNumber != other.PageNumber)
            {
                return false;
            }

            if (BoundingPolygon == null)
            {
                return other.BoundingPolygon == null;
            }

            if (BoundingPolygon.Count != other.BoundingPolygon.Count)
            {
                return false;
            }

            // Since points in a polygon are cyclical, two polygons could still be considered the same
            // if points were shifted. For example, [(1,2),(3,4),(5,6),(7,8)] and [(7,8),(1,2),(3,4),(5,6)]
            // represent the same polygon.

            int j;

            // Search for the first point in 'other.BoundingPolygon', storing the index in 'j'.
            for (j = 0; j < other.BoundingPolygon.Count; j++)
            {
                if (BoundingPolygon[0] == other.BoundingPolygon[j])
                {
                    break;
                }
            }

            if (j >= other.BoundingPolygon.Count)
            {
                return false;
            }

            for (int i = 1; i < BoundingPolygon.Count; i++)
            {
                // Cycles back to index 0 after the last element.
                j = (j + 1) % other.BoundingPolygon.Count;

                if (BoundingPolygon[i] != other.BoundingPolygon[j])
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            var builder = new HashCodeBuilder();

            builder.Add(PageNumber);

            // Since points in a polygon are cyclical, two polygons could still be considered the same
            // if points were shifted. For example, [(1,2),(3,4),(5,6),(7,8)] and [(7,8),(1,2),(3,4),(5,6)]
            // represent the same polygon. For this reason, sort the points to ensure we have a consistent
            // order for the same set of points.
            IOrderedEnumerable<PointF> orderedPoints = BoundingPolygon.OrderBy(p => p, PointFComparer.Instance);

            foreach (PointF point in orderedPoints)
            {
                builder.Add(point.GetHashCode());
            }

            return builder.ToHashCode();
        }

        /// <summary>
        /// Returns a <c>string</c> representation of this <see cref="BoundingRegion"/>.
        /// </summary>
        /// <returns>A <c>string</c> representation of this <see cref="BoundingRegion"/>.</returns>
        public override string ToString()
        {
            string points = string.Join(",", BoundingPolygon.Select(p => p.ToString()));

            return $"Page: {PageNumber}, Polygon: {points}";
        }

        /// <summary>
        /// Helper comparer used by the <see cref="GetHashCode"/> method. Implemented with the singleton
        /// pattern to avoid unnecessary allocations.
        /// </summary>
        private class PointFComparer : IComparer<PointF>
        {
            public static readonly PointFComparer Instance = new PointFComparer();

            private PointFComparer()
            {
            }

            public int Compare(PointF p1, PointF p2)
            {
                int x = p1.X.CompareTo(p2.X);

                if (x != 0)
                {
                    return x;
                }

                return p1.Y.CompareTo(p2.Y);
            }
        }
    }
}
