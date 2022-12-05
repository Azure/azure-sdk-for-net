// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Core
{
    internal readonly struct ApiVersionString : IComparable
    {
        //length of yyyy-MM-dd string
        private const int DateStringSize = 10;

        private bool IsGa { get; }
        private string PreviewString { get; }
        private string RawVersion { get; }
        private DateTime VersionDate { get; }

        public ApiVersionString(string version)
        {
            Argument.AssertNotNull(version, nameof(version));

            RawVersion = version;
            ReadOnlySpan<char> chars = version.AsSpan();
            IsGa = true;
            int index = -1;
            PreviewString = null;
            if (chars.Length > DateStringSize)
            {
                index = chars.LastIndexOf('-');
                IsGa = false;
                PreviewString = chars.Slice(index + 1).ToString();
            }
            ReadOnlySpan<char> datePortion = chars.Slice(0, IsGa ? chars.Length : index);
#if NET6_0_OR_GREATER
            VersionDate = DateTime.Parse(datePortion, CultureInfo.InvariantCulture);
#else
            VersionDate = DateTime.Parse(datePortion.ToString(), CultureInfo.InvariantCulture);
#endif
        }

        private bool IsGreaterThan(ApiVersionString other)
        {
            if (VersionDate != other.VersionDate)
                return VersionDate > other.VersionDate;

            if (IsGa)
                return !other.IsGa;

            if (other.IsGa)
                return false;

            return string.CompareOrdinal(PreviewString, other.PreviewString) > 0;
        }

        public static ApiVersionString FromString(object version)
        {
            string vStr = version as string;
            if (vStr is null)
                throw new FormatException();

            return new ApiVersionString(vStr);
        }

        public int CompareTo(object obj)
        {
            if (obj is not ApiVersionString other)
            {
                if (obj is not string otherStr)
                    return 1;
                other = new ApiVersionString(otherStr);
            }

            if (RawVersion.Equals(other.RawVersion))
                return 0;

            return IsGreaterThan(other) ? 1 : -1;
        }

        public override string ToString()
        {
            return RawVersion;
        }
    }
}
