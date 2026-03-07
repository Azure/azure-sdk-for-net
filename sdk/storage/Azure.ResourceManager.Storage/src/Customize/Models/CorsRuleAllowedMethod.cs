// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct CorsRuleAllowedMethod
    {
        /// <summary> CONNECT. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CorsRuleAllowedMethod Connect => CONNECT;

        /// <summary> DELETE. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CorsRuleAllowedMethod Delete => DELETE;

        /// <summary> GET. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CorsRuleAllowedMethod Get => GET;

        /// <summary> HEAD. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CorsRuleAllowedMethod Head => HEAD;

        /// <summary> MERGE. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CorsRuleAllowedMethod Merge => MERGE;

        /// <summary> OPTIONS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CorsRuleAllowedMethod Options => OPTIONS;

        /// <summary> PATCH. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CorsRuleAllowedMethod Patch => PATCH;

        /// <summary> POST. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CorsRuleAllowedMethod Post => POST;

        /// <summary> PUT. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CorsRuleAllowedMethod Put => PUT;

        /// <summary> TRACE. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CorsRuleAllowedMethod Trace => TRACE;
    }
}
