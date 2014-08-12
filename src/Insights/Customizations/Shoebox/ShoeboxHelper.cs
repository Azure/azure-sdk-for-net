using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.Azure.Insights
{
    internal static class ShoeboxHelper
    {
        private const int KeyLimit = 432;
        private const int KeyTrimPadding = 17;

        /// <summary>
        /// Encoding function for use with Shoebox table Partition and Row Keys
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The encoded key</returns>
        public static string TrimAndEscapeKey(string key)
        {
            return TrimKey(EscapeStorageKey(key), KeyLimit);
        }

        public static string UnEscapeKey(string key)
        {
            StringBuilder unescapedKey = new StringBuilder();

            try
            {
                for (int i = 0; i < key.Length; i++)
                {
                    if (key[i] == ':')
                    {
                        string hexString = key.Substring(i + 1, 4);
                        unescapedKey.Append(char.ConvertFromUtf32(Int32.Parse(hexString, NumberStyles.AllowHexSpecifier)));

                        i += 4;
                    }
                    else
                    {
                        unescapedKey.Append(key[i]);
                    }
                }
            }
            catch (FormatException)
            {
                // If unable to decode, return the original string
                return key;
            }

            return unescapedKey.ToString();
        }

        public static string GenerateMetricDefinitionFilterString(IEnumerable<string> names)
        {
            return names == null || !names.Any() ? null : names.Select(n => "name.value eq '" + n + "'").Aggregate((a, b) => a + " or " + b);
        }

        public static string GenerateMetricFilterString(MetricFilter filter)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}timeGrain eq duration'{1}' and startTime eq {2} and endTime eq {3}",
                filter.Names == null || !filter.Names.Any() ? string.Empty : "(" + GenerateMetricDefinitionFilterString(filter.Names) + ") and ",
                filter.TimeGrain.To8601String(),
                filter.StartTime.ToString("O"),
                filter.EndTime.ToString("O"));
        }

        private static string EscapeStorageKey(string key)
        {
            StringBuilder escapedkey = new StringBuilder(key.Length);
            foreach (char c in key)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    escapedkey.Append(string.Format(CultureInfo.InvariantCulture, ":{0:X4}", (ushort)c));
                }
                else
                {
                    escapedkey.Append(c);
                }
            }

            return escapedkey.ToString();
        }

        private static string TrimKey(string key, int limit)
        {
            if (limit < KeyTrimPadding)
            {
                throw new ArgumentException(string.Format("The key limit should be at least {0} characters.", KeyTrimPadding), "limit");
            }

            if (key.Contains('|'))
            {
                throw new ArgumentException(
                    string.Format("The key '{0}' is not properly encoded. Use EscapeKey for encoding.", key), "key");
            }

            if (key.Length > limit)
            {
                // Note(ilygre): The murmur hash is used here to generate fixed size unique thumbprint of storage key.
                // The seed value(0) or hashing algorithm should not be changed. You could lose your records.
                ulong hash64 = MurmurHash64(Encoding.UTF8.GetBytes(key));
                return string.Concat(key.Substring(0, limit - KeyTrimPadding), "|", hash64.ToString("X16"));
            }

            return key;
        }

        private static ulong MurmurHash64(byte[] data, uint seed = 0)
        {
            const uint C1 = 0x239b961b;
            const uint C2 = 0xab0e9789;
            const uint C3 = 0x561ccd1b;
            const uint C4 = 0x0bcaa747;
            const uint C5 = 0x85ebca6b;
            const uint C6 = 0xc2b2ae35;

            int length = data.Length;

            unchecked
            {
                uint h1 = seed;
                uint h2 = seed;

                int index = 0;
                while (index + 7 < length)
                {
                    uint k1 = (uint)(data[index + 0] | data[index + 1] << 8 | data[index + 2] << 16 | data[index + 3] << 24);
                    uint k2 = (uint)(data[index + 4] | data[index + 5] << 8 | data[index + 6] << 16 | data[index + 7] << 24);

                    k1 *= C1;
                    k1 = k1.RotateLeft32(15);
                    k1 *= C2;
                    h1 ^= k1;
                    h1 = h1.RotateLeft32(19);
                    h1 += h2;
                    h1 = (h1 * 5) + C3;

                    k2 *= C2;
                    k2 = k2.RotateLeft32(17);
                    k2 *= C1;
                    h2 ^= k2;
                    h2 = h2.RotateLeft32(13);
                    h2 += h1;
                    h2 = (h2 * 5) + C4;

                    index += 8;
                }

                int tail = length - index;
                if (tail > 0)
                {
                    uint k1 = (tail >= 4) ? (uint)(data[index + 0] | data[index + 1] << 8 | data[index + 2] << 16 | data[index + 3] << 24) :
                              (tail == 3) ? (uint)(data[index + 0] | data[index + 1] << 8 | data[index + 2] << 16) :
                              (tail == 2) ? (uint)(data[index + 0] | data[index + 1] << 8) :
                                            (uint)data[index + 0];

                    k1 *= C1;
                    k1 = k1.RotateLeft32(15);
                    k1 *= C2;
                    h1 ^= k1;

                    if (tail > 4)
                    {
                        uint k2 = (tail == 7) ? (uint)(data[index + 4] | data[index + 5] << 8 | data[index + 6] << 16) :
                                  (tail == 6) ? (uint)(data[index + 4] | data[index + 5] << 8) :
                                                (uint)data[index + 4];

                        k2 *= C2;
                        k2 = k2.RotateLeft32(17);
                        k2 *= C1;
                        h2 ^= k2;
                    }
                }

                h1 ^= (uint)length;
                h2 ^= (uint)length;

                h1 += h2;
                h2 += h1;

                h1 ^= h1 >> 16;
                h1 *= C5;
                h1 ^= h1 >> 13;
                h1 *= C6;
                h1 ^= h1 >> 16;

                h2 ^= h2 >> 16;
                h2 *= C5;
                h2 ^= h2 >> 13;
                h2 *= C6;
                h2 ^= h2 >> 16;

                h1 += h2;
                h2 += h1;

                return ((ulong)h2 << 32) | (ulong)h1;
            }
        }

        private static uint RotateLeft32(this uint value, int count)
        {
            return (value << count) | (value >> (32 - count));
        }
    }
}
