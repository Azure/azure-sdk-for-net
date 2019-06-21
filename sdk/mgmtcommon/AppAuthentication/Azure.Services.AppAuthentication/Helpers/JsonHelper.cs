// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;
using System.Runtime.Serialization.Json;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// To deserialize JSON response from token providers. 
    /// </summary>
    internal static class JsonHelper
    {
        internal static T Deserialize<T>(byte[] byteArray)
        {
            using (MemoryStream memoryStream = new MemoryStream(byteArray))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                return (T)ser.ReadObject(memoryStream);
            }
        }
    }
}
