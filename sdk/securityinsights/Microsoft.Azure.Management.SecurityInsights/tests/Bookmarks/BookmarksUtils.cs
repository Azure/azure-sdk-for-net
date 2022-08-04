using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.SecurityInsights.Models;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public static class BookmarksUtils
    {
        public static Bookmark GetDefaultBookmarkProperties() => new Bookmark()
        {
            DisplayName = "SDKTestBookmark",
            Query = "SecurityEvent | take 10",
            Labels = new List<string>(),
            EventTime = DateTime.Now
        };
    }
}
