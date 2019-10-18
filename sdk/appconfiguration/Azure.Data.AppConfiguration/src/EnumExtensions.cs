// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Globalization;

namespace Azure.Data.AppConfiguration
{
    internal static class EnumExtensions
    {
        public static string FlagsToString(this ulong flags, IReadOnlyList<string> names, IReadOnlyList<ulong> values)
        {
            var remaining = flags;
            var flagsCount = 0;
            var flagsLength = 0;
            for (var i = 0; i < names.Count; i++)
            {
                var flag = values[i];
                if (flags == flag)
                {
                    return names[i];
                }

                if ((flags & flag) == flag)
                {
                    flagsCount++;
                    flagsLength += names[i].Length;
                    remaining -= flag;
                }
            }

            if (remaining > 0)
            {
                return flags.ToString(NumberFormatInfo.InvariantInfo);
            }

            if (flags == 0)
            {
                return "0";
            }

            var index = 0;
            const string delimiter = ", ";
            var result = new char[flagsLength + 2 * (flagsCount - 1)];

            for (var i = 0; i < names.Count; i++)
            {
                var flag = values[i];
                if ((flags & flag) != flag)
                {
                    continue;
                }

                if (index > 0)
                {
                    delimiter.CopyTo(0, result, index, delimiter.Length);
                    index += delimiter.Length;
                }

                var name = names[i];
                name.CopyTo(0, result, index, name.Length);
                index += name.Length;
            }

            return new string(result);
        }
    }
}
