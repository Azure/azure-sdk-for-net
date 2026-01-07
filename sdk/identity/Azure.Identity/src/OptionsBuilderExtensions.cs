// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Microsoft.Extensions.Options;

namespace Azure.Identity
{
    /// <summary>
    /// .
    /// </summary>
    public static class OptionsBuilderExtensions
    {
        /// <summary>
        /// .
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static OptionsBuilder<T> WithAzureCredential<T>(this OptionsBuilder<T> builder)
            where T : ClientSettings
        {
            builder.PostConfigure(options =>
            {
                options.CredentialObject = new ConfigurableCredential(options.Credential);
            });
            return builder;
        }
    }
}
