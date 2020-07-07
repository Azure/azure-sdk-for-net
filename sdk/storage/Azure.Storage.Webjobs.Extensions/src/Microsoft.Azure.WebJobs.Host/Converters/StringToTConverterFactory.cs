// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal static class StringToTConverterFactory
    {
        private static readonly IStringToTConverterFactory Singleton = new CompositeStringToTConverterFactory(
            new IdentityStringToTConverterFactory(),
            new KnownTypesParseToStringConverterFactory(),
            new TryParseStringToTConverterFactory(),
            new TypeConverterStringToTConverterFactory());

        public static IStringToTConverterFactory Instance
        {
            get { return Singleton; }
        }
    }
}
