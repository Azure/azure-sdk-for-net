// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    /// <summary>
    /// Utility class.
    /// </summary>
    internal static class ComputeUtils
    {
        /// <summary>
        /// Given an object holding a numeric in Integer or String format, convert that to Integer.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <return>The integer value.</return>
        ///GENMHASH:663112EB0F1DE517DFEE2A837DECC2B6:E55F34EE6CDFC6C04AA107D22EE30395
        public static int? ObjectToInteger(object obj)
        {
            int? result = null;
            if (obj != null)
            {
                if (obj is Int16)
                {
                    result = (int)((Int16)obj);
                }
                else if (obj is Int32)
                {
                    result = (int)obj;
                }
                else if (obj is Int64)
                {
                    result = (int)((Int64)obj);
                }
                else
                {
                    int parsed;
                    if (int.TryParse((string)obj, out parsed))
                    {
                        result = parsed;
                    }
                }
            }
            return result;
        }
    }
}
