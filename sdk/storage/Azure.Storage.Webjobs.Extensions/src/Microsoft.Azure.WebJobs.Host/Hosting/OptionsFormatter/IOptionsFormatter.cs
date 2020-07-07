// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Hosting
{
    public interface IOptionsFormatter
    {
        /// <summary>
        /// Creates a string to be logged when the options are created from the IOptionsFactory.
        /// The returned value should be a JSON string with all secrets removed.
        /// </summary>
        /// <returns>A JSON string representing the options, with all secrets removed.</returns>
        string Format();
    }
}
