// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    using System;
    using System.Numerics;

    internal static class Vector3Extensions
    {
        private const float normalizationAccuracy = 1.0e-4f;

        /// <summary>
        /// Determines whether the specified vector is normalized.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns><c>true</c> if the specified vector is normalized; otherwise, <c>false</c>.</returns>
        public static bool IsNormalized(this Vector3 vector)
        {
            return Math.Abs(vector.LengthSquared() - 1) < normalizationAccuracy;
        }
    }
}
