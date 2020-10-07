// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Media.LiveVideoAnalytics.Edge.Models
{
    public partial class MediaGraphInstanceSetRequest
    {
        /// <summary>
        ///  Serialize .
        /// </summary>
        /// <returns></returns>
        public string GetPayloadAsJSON()
        {
            return Instance.Serialize();
        }
    }
}
