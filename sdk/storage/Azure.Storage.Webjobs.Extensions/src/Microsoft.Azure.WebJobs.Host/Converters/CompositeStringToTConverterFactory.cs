// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class CompositeStringToTConverterFactory : IStringToTConverterFactory
    {
        private readonly IStringToTConverterFactory[] _factories;

        public CompositeStringToTConverterFactory(params IStringToTConverterFactory[] factories)
        {
            _factories = factories;
        }

        public IConverter<string, TOutput> TryCreate<TOutput>()
        {
            foreach (IStringToTConverterFactory factory in _factories)
            {
                IConverter<string, TOutput> possibleFactory = factory.TryCreate<TOutput>();

                if (possibleFactory != null)
                {
                    return possibleFactory;
                }
            }

            return null;
        }
    }
}
