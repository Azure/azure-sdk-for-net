// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Extension methods for Access Control List for removal.
    /// </summary>
    public static class RemovePathAccessControlExtensions
    {
        /// <summary>
        /// Converts the Access Control List for removal to a <see cref="string"/>.
        /// </summary>
        /// <param name="accessControlList">The Access Control List for removal to serialize</param>
        /// <returns>string.</returns>
        public static string ToAccessControlListString(IList<RemovePathAccessControlItem> accessControlList)
        {
            if (accessControlList == null)
            {
                return null;
            }

            IList<string> serializedAcl = new List<string>();
            foreach (RemovePathAccessControlItem ac in accessControlList)
            {
                serializedAcl.Add(ac.ToString());
            }
            return string.Join(",", serializedAcl);
        }

        /// <summary>
        /// Deseralizes an access control list string for removal into a list of RemovePathAccessControlItem.
        /// </summary>
        /// <param name="s">The string to parse.</param>
        /// <returns>A List of <see cref="RemovePathAccessControlItem"/>.</returns>
        public static IList<RemovePathAccessControlItem> ParseAccessControlList(string s)
        {
            if (s == null)
            {
                return null;
            }

            string[] strings = s.Split(',');
            List<RemovePathAccessControlItem> accessControlList = new List<RemovePathAccessControlItem>();
            foreach (string entry in strings)
            {
                accessControlList.Add(RemovePathAccessControlItem.Parse(entry));
            }
            return accessControlList;
        }
    }
}
