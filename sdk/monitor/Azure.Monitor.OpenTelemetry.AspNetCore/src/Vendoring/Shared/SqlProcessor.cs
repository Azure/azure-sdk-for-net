// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using System.Collections;
using System.Text;

namespace OpenTelemetry.Instrumentation;

internal static class SqlProcessor
{
    private const int CacheCapacity = 1000;
    private static readonly Hashtable Cache = [];

    public static string GetSanitizedSql(string? sql)
    {
        if (sql == null)
        {
            return string.Empty;
        }

        if (Cache[sql] is not string sanitizedSql)
        {
            sanitizedSql = SanitizeSql(sql);

            if (Cache.Count == CacheCapacity)
            {
                return sanitizedSql;
            }

            lock (Cache)
            {
                if ((Cache[sql] as string) == null)
                {
                    if (Cache.Count < CacheCapacity)
                    {
                        Cache[sql] = sanitizedSql;
                    }
                }
            }
        }

        return sanitizedSql!;
    }

    private static string SanitizeSql(string sql)
    {
        var sb = new StringBuilder(capacity: sql.Length);
        for (var i = 0; i < sql.Length; ++i)
        {
            if (SkipComment(sql, ref i))
            {
                continue;
            }

            if (SanitizeStringLiteral(sql, ref i) ||
                SanitizeHexLiteral(sql, ref i) ||
                SanitizeNumericLiteral(sql, ref i))
            {
                sb.Append('?');
                continue;
            }

            WriteToken(sql, ref i, sb);
        }

        return sb.ToString();
    }

    private static bool SkipComment(string sql, ref int index)
    {
        var i = index;
        var ch = sql[i];
        var length = sql.Length;

        // Scan past multi-line comment
        if (ch == '/' && i + 1 < length && sql[i + 1] == '*')
        {
            for (i += 2; i < length; ++i)
            {
                ch = sql[i];
                if (ch == '*' && i + 1 < length && sql[i + 1] == '/')
                {
                    i += 1;
                    break;
                }
            }

            index = i;
            return true;
        }

        // Scan past single-line comment
        if (ch == '-' && i + 1 < length && sql[i + 1] == '-')
        {
            for (i += 2; i < length; ++i)
            {
                ch = sql[i];
                if (ch is '\r' or '\n')
                {
                    i -= 1;
                    break;
                }
            }

            index = i;
            return true;
        }

        return false;
    }

    private static bool SanitizeStringLiteral(string sql, ref int index)
    {
        var ch = sql[index];
        if (ch == '\'')
        {
            var i = index + 1;
            var length = sql.Length;
            for (; i < length; ++i)
            {
                ch = sql[i];
                if (ch == '\'' && i + 1 < length && sql[i + 1] == '\'')
                {
                    ++i;
                    continue;
                }

                if (ch == '\'')
                {
                    break;
                }
            }

            index = i;
            return true;
        }

        return false;
    }

    private static bool SanitizeHexLiteral(string sql, ref int index)
    {
        var i = index;
        var ch = sql[i];
        var length = sql.Length;

        if (ch == '0' && i + 1 < length && (sql[i + 1] == 'x' || sql[i + 1] == 'X'))
        {
            for (i += 2; i < length; ++i)
            {
                ch = sql[i];
                if (char.IsDigit(ch) ||
                    ch == 'A' || ch == 'a' ||
                    ch == 'B' || ch == 'b' ||
                    ch == 'C' || ch == 'c' ||
                    ch == 'D' || ch == 'd' ||
                    ch == 'E' || ch == 'e' ||
                    ch == 'F' || ch == 'f')
                {
                    continue;
                }

                i -= 1;
                break;
            }

            index = i;
            return true;
        }

        return false;
    }

    private static bool SanitizeNumericLiteral(string sql, ref int index)
    {
        var i = index;
        var ch = sql[i];
        var length = sql.Length;

        // Scan past leading sign
        if ((ch == '-' || ch == '+') && i + 1 < length && (char.IsDigit(sql[i + 1]) || sql[i + 1] == '.'))
        {
            i += 1;
            ch = sql[i];
        }

        // Scan past leading decimal point
        var periodMatched = false;
        if (ch == '.' && i + 1 < length && char.IsDigit(sql[i + 1]))
        {
            periodMatched = true;
            i += 1;
            ch = sql[i];
        }

        if (char.IsDigit(ch))
        {
            var exponentMatched = false;
            for (i += 1; i < length; ++i)
            {
                ch = sql[i];
                if (char.IsDigit(ch))
                {
                    continue;
                }

                if (!periodMatched && ch == '.')
                {
                    periodMatched = true;
                    continue;
                }

                if (!exponentMatched && (ch == 'e' || ch == 'E'))
                {
                    // Scan past sign in exponent
                    if (i + 1 < length && (sql[i + 1] == '-' || sql[i + 1] == '+'))
                    {
                        i += 1;
                    }

                    exponentMatched = true;
                    continue;
                }

                i -= 1;
                break;
            }

            index = i;
            return true;
        }

        return false;
    }

    private static void WriteToken(string sql, ref int index, StringBuilder sb)
    {
        var i = index;
        var ch = sql[i];

        if (char.IsLetter(ch) || ch == '_')
        {
            for (; i < sql.Length; i++)
            {
                ch = sql[i];
                if (char.IsLetter(ch) || ch == '_' || char.IsDigit(ch))
                {
                    sb.Append(ch);
                    continue;
                }

                break;
            }

            i -= 1;
        }
        else
        {
            sb.Append(ch);
        }

        index = i;
    }
}
