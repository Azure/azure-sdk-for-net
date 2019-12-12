﻿using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataBoxEdge.Tests
{
    public static partial class TestUtilities
    {
        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetTags(this DataBoxEdgeDevice device)
        {
            var Tags = new Dictionary<string, string>();
            if (device.Tags != null)
            {
                Tags = device.Tags.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }
            Tags.Add("tag3", "value3");
            Tags.Add("tag4", "value4");

            return Tags;
        }
    }
}
