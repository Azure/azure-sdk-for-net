// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Translation.Document
{
    internal static class ClientCommon
    {
        /// <summary>
        /// Used as part of argument validation. Attempts to create a <see cref="Guid"/> from a <c>string</c> and
        /// throws an <see cref="ArgumentException"/> in case of failure.
        /// </summary>
        /// <param name="possibleGuid">The identifier to be parsed into a <see cref="Guid"/>.</param>
        /// <param name="paramName">The original parameter name of the <paramref name="possibleGuid"/>. Used to create exceptions in case of failure.</param>
        /// <returns>The <see cref="Guid"/> instance created from the <paramref name="possibleGuid"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when parsing fails.</exception>
        public static Guid ValidateModelId(string possibleGuid, string paramName)
        {
            Guid guid;

            try
            {
                guid = new Guid(possibleGuid);
            }
            catch (Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                throw new ArgumentException($"The {paramName} must be a valid GUID.", paramName, ex);
            }

            return guid;
        }
    }
}
