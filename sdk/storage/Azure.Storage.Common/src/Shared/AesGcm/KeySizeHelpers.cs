// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Security.Cryptography;

namespace Azure.Storage.Shared.AesGcm
{
#if !(NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER)
    /// <summary>
    /// Taken from
    /// https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/System/Security/Cryptography/KeySizeHelpers.cs
    ///
    /// SHOULD NOT BE CHANGED WITHOUT COORDINATING WITH BCL TEAM
    /// </summary>
    internal static class KeySizeHelpers
    {
        internal static KeySizes[] CloneKeySizesArray(this KeySizes[] src)
        {
            return (KeySizes[])(src.Clone());
        }

        internal static bool IsLegalSize(this int size, KeySizes legalSizes)
        {
            return size.IsLegalSize(legalSizes, out _);
        }

        internal static bool IsLegalSize(this int size, KeySizes[] legalSizes)
        {
            return size.IsLegalSize(legalSizes, out _);
        }

        internal static bool IsLegalSize(this int size, KeySizes legalSizes, out bool validatedByZeroSkipSizeKeySizes)
        {
            validatedByZeroSkipSizeKeySizes = false;

            // If a cipher has only one valid key size, MinSize == MaxSize and SkipSize will be 0
            if (legalSizes.SkipSize == 0)
            {
                if (legalSizes.MinSize == size)
                {
                    // Signal that we were validated by a 0-skipsize KeySizes entry. Needed to preserve a very obscure
                    // piece of back-compat behavior.
                    validatedByZeroSkipSizeKeySizes = true;
                    return true;
                }
            }
            else if (size >= legalSizes.MinSize && size <= legalSizes.MaxSize)
            {
                // If the number is in range, check to see if it's a legal increment above MinSize
                int delta = size - legalSizes.MinSize;

                // While it would be unusual to see KeySizes { 10, 20, 5 } and { 11, 14, 1 }, it could happen.
                // So don't return false just because this one doesn't match.
                if (delta % legalSizes.SkipSize == 0)
                {
                    return true;
                }
            }

            return false;
        }

        internal static bool IsLegalSize(this int size, KeySizes[] legalSizes, out bool validatedByZeroSkipSizeKeySizes)
        {
            for (int i = 0; i < legalSizes.Length; i++)
            {
                if (size.IsLegalSize(legalSizes[i], out validatedByZeroSkipSizeKeySizes))
                {
                    return true;
                }
            }

            validatedByZeroSkipSizeKeySizes = false;
            return false;
        }
    }
#endif
}
