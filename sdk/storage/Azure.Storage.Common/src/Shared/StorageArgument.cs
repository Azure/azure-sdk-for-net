// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

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
            Argument.AssertNotNull(
                value.InitialTransferSize,
                $"{name}.{nameof(StorageTransferOptions.InitialTransferSize)}");
            Argument.AssertNotNull(
                value.MaximumTransferSize,
                $"{name}.{nameof(StorageTransferOptions.MaximumTransferSize)}");
            Argument.AssertNotNull(
                value.MaximumConcurrency,
                $"{name}.{nameof(StorageTransferOptions.MaximumConcurrency)}");
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
            Argument.AssertInRange(
                value.InitialTransferSize.Value,
                1,
                upperBoundInitial,
                $"{name}.{nameof(StorageTransferOptions.InitialTransferSize)}");

            Argument.AssertInRange(
                value.MaximumTransferSize.Value,
                1,
                upperBoundMaximum,
                $"{name}.{nameof(StorageTransferOptions.MaximumTransferSize)}");

            Argument.AssertInRange(
                value.MaximumConcurrency.Value,
                1,
                upperBoundConcurrency,
                $"{name}.{nameof(StorageTransferOptions.MaximumConcurrency)}");
        }
    }
}