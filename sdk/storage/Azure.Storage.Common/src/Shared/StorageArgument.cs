// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage
{
    internal static partial class StorageArgument
    {
        /// <summary>
        /// Asserts all values in a given <see cref="StorageTransferOptions"/> value
        /// are populated.
        /// </summary>
        /// <param name="value">
        /// Transfer options to validate.
        /// </param>
        /// <param name="name">
        /// The name of the parameter.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Any property in <paramref name="value"/> is not populated.
        /// </exception>
        public static void AssertTransferOptionsDefined(
            StorageTransferOptions value,
            string name)
        {
            if (value.InitialTransferSize == null)
            {
                throw new ArgumentNullException($"{name}.{nameof(StorageTransferOptions.InitialTransferSize)}");
            }
            if (value.MaximumTransferSize == null)
            {
                throw new ArgumentNullException($"{name}.{nameof(StorageTransferOptions.MaximumTransferSize)}");
            }
            if (value.MaximumConcurrency == null)
            {
                throw new ArgumentNullException($"{name}.{nameof(StorageTransferOptions.MaximumConcurrency)}");
            }
        }

        /// <summary>
        /// Asserts all values in a given <see cref="StorageTransferOptions"/> value
        /// are populated and within a given set of bounds.
        /// </summary>
        /// <param name="value">
        /// Transfer options to validate.
        /// </param>
        /// <param name="name">
        /// The name of the parameter.
        /// </param>
        /// <param name="upperBoundInitial">
        /// Max value for <see cref="StorageTransferOptions.InitialTransferSize"/>.
        /// </param>
        /// <param name="upperBoundMaximum">
        /// Max value for <see cref="StorageTransferOptions.MaximumTransferSize"/>.
        /// </param>
        /// <param name="upperBoundConcurrency">
        /// Max value for <see cref="StorageTransferOptions.MaximumConcurrency"/>.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Any property in <paramref name="value"/> is outside valid range.
        /// </exception>
        /// <remarks>
        /// All minimum values for a bounds check are 1.
        /// </remarks>
        public static void AssertTransferOptionsDefinedInBounds(
            StorageTransferOptions value,
            string name,
            long upperBoundInitial = long.MaxValue,
            long upperBoundMaximum = long.MaxValue,
            int upperBoundConcurrency = int.MaxValue)
        {
            if (value.InitialTransferSize.Value < 1)
            {
                throw new ArgumentOutOfRangeException($"{name}.{nameof(StorageTransferOptions.InitialTransferSize)}", "Value is less than the minimum allowed.");
            }
            if (value.InitialTransferSize.Value > upperBoundInitial)
            {
                throw new ArgumentOutOfRangeException($"{name}.{nameof(StorageTransferOptions.InitialTransferSize)}", "Value is greater than the maximum allowed.");
            }

            if (value.MaximumTransferSize.Value < 1)
            {
                throw new ArgumentOutOfRangeException($"{name}.{nameof(StorageTransferOptions.MaximumTransferSize)}", "Value is less than the minimum allowed.");
            }
            if (value.MaximumTransferSize.Value > upperBoundMaximum)
            {
                throw new ArgumentOutOfRangeException($"{name}.{nameof(StorageTransferOptions.MaximumTransferSize)}", "Value is greater than the maximum allowed.");
            }

            if (value.MaximumConcurrency.Value < 1)
            {
                throw new ArgumentOutOfRangeException($"{name}.{nameof(StorageTransferOptions.MaximumConcurrency)}", "Value is less than the minimum allowed.");
            }
            if (value.MaximumConcurrency.Value > upperBoundConcurrency)
            {
                throw new ArgumentOutOfRangeException($"{name}.{nameof(StorageTransferOptions.MaximumConcurrency)}", "Value is greater than the maximum allowed.");
            }
        }
    }
}
