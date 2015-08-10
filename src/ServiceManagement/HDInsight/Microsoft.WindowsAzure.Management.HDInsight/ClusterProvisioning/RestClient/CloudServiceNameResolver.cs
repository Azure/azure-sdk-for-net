// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    internal class CloudServiceNameResolver : ICloudServiceNameResolver
    {
        // TODO: REMOVE THIS AND HAVE A LOOKUP ON AZURE LOGIC
        public string GetCloudServiceName(Guid subscriptionId, string extensionPrefix, string region)
        {
            region.ArgumentNotNullOrEmpty("region");
            string hashedSubId = string.Empty;

            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
            {
                hashedSubId = Base32NoPaddingEncode(sha256.ComputeHash(Encoding.UTF8.GetBytes(subscriptionId.ToString())));
            }

            return string.Format(CultureInfo.InvariantCulture,
                                 "{0}{1}-{2}",
                                 extensionPrefix,
                                 hashedSubId,
                                 region.Replace(' ', '-'));
        }

        // TODO: REMOVE THIS AND HAVE A LOOKUP ON AZURE LOGIC
        private static string Base32NoPaddingEncode(byte[] data)
        {
            const string Base32StandardAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

            var result = new StringBuilder(Math.Max((int)Math.Ceiling(data.Length * 8 / 5.0), 1));

            var emptyBuffer = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            var workingBuffer = new byte[8];

            // Process input 5 bytes at a time
            for (int i = 0; i < data.Length; i += 5)
            {
                int bytes = Math.Min(data.Length - i, 5);
                Array.Copy(emptyBuffer, workingBuffer, emptyBuffer.Length);
                Array.Copy(data, i, workingBuffer, workingBuffer.Length - (bytes + 1), bytes);
                Array.Reverse(workingBuffer);
                ulong val = BitConverter.ToUInt64(workingBuffer, 0);

                for (int bitOffset = ((bytes + 1) * 8) - 5; bitOffset > 3; bitOffset -= 5)
                {
                    result.Append(Base32StandardAlphabet[(int)((val >> bitOffset) & 0x1f)]);
                }
            }

            return result.ToString();
        }
    }
}
