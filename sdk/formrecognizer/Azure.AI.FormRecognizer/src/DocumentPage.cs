// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentPage")]
    public partial class DocumentPage
    {
        /// <summary>
        /// The unit used by the width, height and <see cref="BoundingBox"/> properties. For images, the unit is
        /// pixel. For PDF, the unit is inch.
        /// </summary>
        public LengthUnit Unit { get; private set; }

        [CodeGenMember("Unit")]
        private V3LengthUnit UnitPrivate
        {
            get => throw new InvalidOperationException();
            set
            {
                if (value == V3LengthUnit.Inch)
                {
                    Unit = LengthUnit.Inch;
                }
                else if (value == V3LengthUnit.Pixel)
                {
                    Unit = LengthUnit.Pixel;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Unknown {nameof(LengthUnit)} value: {value}");
                }
            }
        }
    }
}
