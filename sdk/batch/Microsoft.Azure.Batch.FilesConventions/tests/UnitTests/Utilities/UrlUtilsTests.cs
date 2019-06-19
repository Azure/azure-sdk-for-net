// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using Microsoft.Azure.Batch.Conventions.Files.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Batch.Conventions.Files.UnitTests.Utilities
{
    public class UrlUtilsTests
    {
        [Fact]
        public void ItIsAnErrorToCallGetValueSegmentOnANullUrl()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => UrlUtils.GetUrlValueSegment(null, "jobs"));
            Assert.Equal("url", ex.ParamName);
        }

        [Fact]
        public void ItIsAnErrorToCallGetValueSegmentOnAnEmptyUrl()
        {
            var ex = Assert.Throws<ArgumentException>(() => UrlUtils.GetUrlValueSegment(String.Empty, "jobs"));
            Assert.Equal("url", ex.ParamName);
        }

        [Fact]
        public void ItIsAnErrorToCallGetValueSegmentOnAnInvalidUrl()
        {
            var ex = Assert.Throws<ArgumentException>(() => UrlUtils.GetUrlValueSegment("contoso\\litware test environment***", "jobs"));
            Assert.Equal("url", ex.ParamName);
        }

        [Fact]
        public void ItIsAnErrorToCallGetValueSegmentOnARelativeUrl()
        {
            var ex = Assert.Throws<ArgumentException>(() => UrlUtils.GetUrlValueSegment("jobs/myjob/tasks/mytask", "jobs"));
            Assert.Equal("url", ex.ParamName);
        }

        [Fact]
        public void ItIsAnErrorToCallGetValueSegmentForANullContainerSegment()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => UrlUtils.GetUrlValueSegment("http://example.test/jobs/myjob/tasks/mytask", null));
            Assert.Equal("containerSegment", ex.ParamName);
        }

        [Fact]
        public void ItIsAnErrorToCallGetValueSegmentForAnEmptyContainerSegment()
        {
            var ex = Assert.Throws<ArgumentException>(() => UrlUtils.GetUrlValueSegment("http://example.test/jobs/myjob/tasks/mytask", String.Empty));
            Assert.Equal("containerSegment", ex.ParamName);
        }

        [Fact]
        public void IfTheContainerSegmentIsNotPresentThenGetValueSegmentReturnsNoValue()
        {
            var value = UrlUtils.GetUrlValueSegment("http://example.test/jobs/myjob/tasks/mytask", "pools");
            Assert.Null(value);
        }

        [Fact]
        public void IfTheContainerSegmentIsTheLastSegmentThenGetValueSegmentReturnsNoValue()
        {
            var value = UrlUtils.GetUrlValueSegment("http://example.test/jobs/myjob/tasks", "tasks");
            Assert.Null(value);
        }

        [Fact]
        public void IfTheContainerSegmentIsPresentThenGetValueSegmentReturnsTheNextSegment()
        {
            var value = UrlUtils.GetUrlValueSegment("http://example.test/jobs/myjob/tasks/mytask", "jobs");
            Assert.Equal("myjob", value);
        }

        [Fact]
        public void GetValueSegmentRemovedAnyTrailingSlash()
        {
            var value = UrlUtils.GetUrlValueSegment("http://example.test/jobs/myjob/tasks/mytask/", "tasks");
            Assert.Equal("mytask", value);
        }
    }
}
