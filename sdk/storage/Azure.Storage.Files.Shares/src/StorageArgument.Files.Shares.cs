// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage
{
    internal static partial class StorageArgument
    {
        /// <summary>
        /// Populates empty values.
        /// </summary>
        /// <param name="value">
        /// Transfer options to apply defaults to.
        /// </param>
        /// <returns>
        /// A <see cref="StorageTransferOptions"/> value retaining any
        /// caller-provided values and library defaults for all others.
        /// </returns>
        public static StorageTransferOptions PopulateShareFileUploadTransferOptionDefaults(
            StorageTransferOptions value)
        {
            // File shares do not support concurrent upload
            value.MaximumConcurrency ??= 1;
            value.InitialTransferSize ??= Constants.File.MaxFileUpdateRange;
            value.MaximumTransferSize ??= Constants.File.MaxFileUpdateRange;
            return value;
        }

        /// <summary>
        /// Asserts provided values are within service limits.
        /// Populates default values.
        /// </summary>
        /// <param name="value">
        /// Transfer options to validate and apply defaults to.
        /// </param>
        /// <param name="name">
        /// The name of the parameter.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Any pre-polupated property in <paramref name="value"/> is outside
        /// service max ranges.
        /// </exception>
        public static void AssertShareFileUploadTransferOptionBounds(
            StorageTransferOptions value,
            string name)
        {
            AssertTransferOptionsDefinedInBounds(
                value,
                name,
                upperBoundMaximum: Constants.File.MaxFileUpdateRange,
                upperBoundInitial: Constants.File.MaxFileUpdateRange,
                // File shares do not support concurrent upload
                upperBoundConcurrency: 1);
        }
    }
}