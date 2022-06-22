// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.TestFramework
{
    internal readonly struct VersionString : IComparable
    {
        //length of yyyy-MM-dd string
        private const int DateStringSize = 10;

        private bool IsGa { get; }
        private string PreviewString { get; }
        private string RawVersion { get; }
        private DateTime VersionDate { get; }

        public VersionString(string version)
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
            VersionDate = DateTime.Parse(datePortion);
#else
            VersionDate = DateTime.Parse(datePortion.ToString());
#endif
        }

        private bool IsGreaterThan(VersionString other)
        {
            if (VersionDate != other.VersionDate)
                return VersionDate > other.VersionDate;

            if (IsGa)
                return !other.IsGa;

            if (other.IsGa)
                return false;

            return PreviewString.CompareTo(other.PreviewString) > 0;
        }

        public static VersionString FromString(object version)
        {
            string vStr = version as string;
            if (vStr is null)
                throw new FormatException();

            return new VersionString(vStr);
        }

        public int CompareTo(object obj)
        {
            if (obj is not VersionString other)
            {
                if (obj is not string otherStr)
                    return 1;
                other = new VersionString(otherStr);
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
