// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.DocumentTranslation.Models
{
    /// <summary> Definition for the input batch translation request. </summary>
    [CodeGenModel("BatchRequest")]
    public partial class TranslationConfiguration
    {
        /// <summary> Initializes a new instance of TranslationOperationConfiguration. </summary>
        /// <param name="source"> Source of the input documents. </param>
        /// <param name="targets"> Location of the destination for the output. </param>
        /// <param name="storageType"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="source"/> or <paramref name="targets"/> is null. </exception>
        public TranslationConfiguration(TranslationSource source, IEnumerable<TranslationTarget> targets, StorageType storageType)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (targets == null)
            {
                throw new ArgumentNullException(nameof(targets));
            }

            Source = source;
            Targets = targets.ToList();
            StorageType = storageType;
        }
    }
}
