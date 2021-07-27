// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// A class which defines sorting options used in listing all submitted translation operations.
    /// </summary>
    public class TranslationFilterOrder
    {
        /// <summary>
        /// Initializes an instance of <see cref="TranslationFilterOrder"/>.
        /// </summary>
        public TranslationFilterOrder(TranslationFilterProperty property, bool asc = true)
        {
            Asc = asc;
            Property = property;
        }
        /// <summary>
        /// Sort results ascendingly if true, or descendingly if false.
        /// </summary>
        public bool Asc { get; set; }
        /// <summary>
        /// The <see cref="TranslationStatus"/> property to use in sorting.
        /// <see cref="TranslationFilterProperty"/> for list of properties supported.
        /// </summary>
        public TranslationFilterProperty Property { get; set; }

        /// <summary>
        /// Convert the order filter to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var direction = Asc ? "Asc" : "Desc";
            return $"{Property} {direction}";
        }
    }

    /// <summary>
    /// An enum listing the supported properties that can be used in sorting
    /// when listing all submitted translation operations.
    /// </summary>
    public enum TranslationFilterProperty
    {
        /// <summary>
        /// sorting property corresponds to <see cref="TranslationStatus.CreatedOn"/>.
        /// </summary>
        CreatedOn = 0,
    }
}
