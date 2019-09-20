// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;

namespace Azure.Data.AppConfiguration
{
    internal class SyncTokenUtils
    {
        // Sync-Token Syntax: <id>=<value>;sn=<sn>
        internal static bool TryParse(string value, out SyncToken result)
        {
            result = new SyncToken();

            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            string tokenId = null;
            string tokenValue = null;
            long sequenceNumber = 0;

            int pos = 0;
            string name = null;
            string val = null;

            for (int i = 0; i < value.Length; i++)
            {
                char ch = value[i];

                if (name == null)
                {
                    if (ch == '=')
                    {
                        name = value.Substring(pos, i - pos);
                        pos = i + 1;

                        continue;
                    }
                }

                if (ch == ';' || i == value.Length - 1)
                {
                    //
                    // Done with the current name-value pair
                    if (i == value.Length - 1)
                    {
                        i++;
                    }

                    string fragment = value.Substring(pos, i - pos);

                    if (name != null)
                    {
                        val = fragment;
                    }
                    else
                    {
                        name = fragment;
                    }

                    name = name.Trim();

                    //
                    // Sequence Number
                    if (name == "sn")
                    {
                        if (!long.TryParse(val, NumberStyles.None, CultureInfo.InvariantCulture, out sequenceNumber))
                        {
                            return false;
                        }
                    }
                    //
                    // id-value
                    else if (tokenId == null)
                    {
                        tokenValue = val;
                        tokenId = name;
                    }

                    //
                    // Reset current
                    name = null;
                    val = null;

                    pos = i + 1;
                }
            }

            //
            // Validate
            bool success = false;
            if (!(tokenId == null || tokenValue == null))
            {
                result = new SyncToken(tokenId, tokenValue, sequenceNumber);
                success = true;
            }

            return success;
        }
    }
}
