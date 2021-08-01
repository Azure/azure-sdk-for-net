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
        public DocumentFilterOrder(DocumentFilterProperty property, bool asc = true)
        {
            Property = property;
            Asc = asc;
        }
        /// <summary>
        /// Sort results ascendingly if true, or descendingly if false.
        /// </summary>
        public bool Asc { get; set; }
        /// <summary>
        /// The <see cref="DocumentStatus"/> property to use in sorting.
        /// See <see cref="DocumentFilterProperty"/> for list of properties supported.
        /// </summary>
        public DocumentFilterProperty Property { get; set; }
        /// <summary>
        /// Convert the order filter to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var direction = Asc ? "Asc" : "Desc";
            var property = ConvertDocumentFilterEnumPropertyToModelAttribute(Property);
            return $"{property} {direction}";
        }

        /// <summary>
        /// Converts enum property in <see cref="DocumentFilterProperty"/> to corresponding generated model property name in <see cref="DocumentStatus"/>.
        /// </summary>
        /// <returns></returns>
        private static string ConvertDocumentFilterEnumPropertyToModelAttribute(DocumentFilterProperty enumProperty)
        {
            switch (enumProperty)
            {
                case DocumentFilterProperty.CreatedOn:
                    return "createdDateTimeUtc";
                default:
                    return string.Empty;
            }
        }
    }
}
