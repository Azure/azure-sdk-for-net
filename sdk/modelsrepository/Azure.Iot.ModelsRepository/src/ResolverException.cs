// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Iot.ModelsRepository
{
    /// <summary>
    /// TODO: Paymaun: Exception comments.
    /// </summary>
    public class ResolverException : Exception
    {
        /// <summary>
        /// TODO: Paymaun: Exception comments.
        /// </summary>
        /// <param name="dtmi"></param>
        public ResolverException(string dtmi)
            : base(string.Format(CultureInfo.CurrentCulture, ServiceStrings.GenericResolverError, dtmi)) { }

        /// <summary>
        /// TODO: Paymaun: Exception comments.
        /// </summary>
        /// <param name="dtmi"></param>
        /// <param name="message"></param>
        public ResolverException(string dtmi, string message)
            : base($"{string.Format(CultureInfo.CurrentCulture, ServiceStrings.GenericResolverError, dtmi)} {message}") { }

        /// <summary>
        /// TODO: Paymaun: Exception comments.
        /// </summary>
        /// <param name="dtmi"></param>
        /// <param name="innerException"></param>
        public ResolverException(string dtmi, Exception innerException)
            : base(string.Format(CultureInfo.CurrentCulture, ServiceStrings.GenericResolverError, dtmi), innerException) { }

        /// <summary>
        /// TODO: Paymaun: Exception comments.
        /// </summary>
        /// <param name="dtmi"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ResolverException(string dtmi, string message, Exception innerException)
            : base($"{string.Format(CultureInfo.CurrentCulture, ServiceStrings.GenericResolverError, dtmi)} {message}", innerException) { }
    }
}
