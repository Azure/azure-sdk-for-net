// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace Microsoft.Azure.WebJobs.Hosting
{
    /// <summary>
    /// Allows framework Options types to be registered with an IOptionsFormatter.
    /// </summary>
    /// <typeparam name="TOptions">The options type.</typeparam>
    public interface IOptionsFormatter<TOptions>
    {
        /// <summary>
        /// Creates a string to be logged when the options are created from the IOptionsFactory.
        /// The returned value should be a JSON string with all secrets removed.
        /// </summary>
        /// <returns>A JSON string representing the options, with all secrets removed.</returns>
        string Format(TOptions options);
    }
}