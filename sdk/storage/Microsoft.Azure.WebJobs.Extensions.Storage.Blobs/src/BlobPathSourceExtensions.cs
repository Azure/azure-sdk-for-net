// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal static class BlobPathSourceExtensions
    {
        public static IReadOnlyDictionary<string, Type> CreateBindingDataContract(this IBlobPathSource path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            Dictionary<string, Type> contract = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

            foreach (string parameterName in path.ParameterNames)
            {
                contract.Add(parameterName, typeof(string));
            }

            return contract;
        }
    }
}
