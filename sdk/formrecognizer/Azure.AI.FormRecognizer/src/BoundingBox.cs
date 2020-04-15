// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public readonly struct BoundingBox
    {
        internal BoundingBox(IReadOnlyList<float> boundingBox)
        {
            // TODO: improve perf here?
            // https://github.com/Azure/azure-sdk-for-net/issues/10358
            float[] bbPoints = boundingBox.ToArray();

            int count = bbPoints.Length / 2;

            Points = new PointF[count];
            for (int i = 0; i < count; i++)
            {
                Points[i] = new PointF(bbPoints[2 * i], bbPoints[(2 * i) + 1]);
            }
        }

        /// <summary>
        /// </summary>
        internal PointF[] Points { get; }

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
#pragma warning disable CA1822 // mark as static
        public PointF this[int index] =>
#pragma warning restore CA1822 // mark as static
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                throw new NotImplementedException();
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations

    }
}
