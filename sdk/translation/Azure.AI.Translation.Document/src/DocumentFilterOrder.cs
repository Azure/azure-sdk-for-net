// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// A class which defines sorting options
    /// used in listing all document statuses for a certain translation operation.
    /// </summary>
    public class DocumentFilterOrder
    {
        /// <summary>
        /// Initializes an instance of <see cref="DocumentFilterOrder"/>.
        /// </summary>
        public DocumentFilterOrder(DocumentFilterProperty property, DocumentTranslationFilterMode orderBy)
        {
            Property = property;
            OrderBy = orderBy;
        }
        /// <summary>
        /// The order by which we sort results.
        /// </summary>
        public DocumentTranslationFilterMode OrderBy { get; set; }
        /// <summary>
        /// The <see cref="DocumentStatus"/> property to use in sorting.
        /// <see cref="DocumentFilterProperty"/> for list of properties supported.
        /// </summary>
        public DocumentFilterProperty Property { get; set; }
        /// <summary>
        /// Convert the order filter to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Property} {OrderBy}";
        }
    }

    /// <summary>
    /// An enum listing the supported properties that can be used in sorting
    /// when listing all document statuses for a certain translation operation.
    /// </summary>
    public enum DocumentFilterProperty
    {
        /// <summary>
        /// sorting property corresponds tp <see cref="DocumentStatus.CreatedOn"/>.
        /// </summary>
        CreatedOn = 0,
    }
}
