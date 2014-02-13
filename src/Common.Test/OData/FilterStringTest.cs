//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Linq;
using Microsoft.WindowsAzure.Common.OData;
using Xunit;

namespace Microsoft.WindowsAzure.Common.Test.OData
{
    public class FilterStringTest
    {
        [Fact]
        public void DefaultODataQueryTest()
        {
            var date = new DateTime(2013, 11, 5);

            var result = FilterString.Generate<Param1>(p => p.Foo == "foo" || p.Val < 20 || p.Foo == "bar" && p.Val == null &&
                p.Date > new DateTime(2004, 11, 5) && p.Date < date && p.Values.Contains("x"));
            Assert.Equal("foo eq 'foo' or Val lt 20 or foo eq 'bar' and Val eq null and d gt '2004-11-05T00:00:00Z' " +
                "and d lt '2013-11-05T00:00:00Z' and vals/any(c: c eq 'x')", result);
        }

        [Fact]
        public void VerifyDeepPropertiesInODataFilter()
        {
            var param = new InputParam2
            {
                Param = new InputParam1
                {
                    Value = "foo"
                }
            };
            var result = FilterString.Generate<Param1>(p => p.Foo == param.Param.Value);
            Assert.Equal("foo eq 'foo'", result);
        }

        [Fact]
        public void StartsWithWorksInODataFilter()
        {
            var param = new InputParam2
            {
                Param = new InputParam1
                {
                    Value = "foo"
                }
            };
            var result = FilterString.Generate<Param1>(p => p.Foo.StartsWith(param.Param.Value));
            Assert.Equal("startswith(foo, 'foo') eq true", result);
        }

        [Fact]
        public void EndsWithWorksInODataFilter()
        {
            var param = new InputParam2
            {
                Param = new InputParam1
                {
                    Value = "foo"
                }
            };
            var result = FilterString.Generate<Param1>(p => p.Foo.EndsWith(param.Param.Value));
            Assert.Equal("endswith(foo, 'foo') eq true", result);
        }

        [Fact]
        public void StringContainsWorksInODataFilter()
        {
            var param = new InputParam2
            {
                Param = new InputParam1
                {
                    Value = "foo"
                }
            };
            var result = FilterString.Generate<Param1>(p => p.Foo.Contains(param.Param.Value));
            Assert.Equal("foo/any(c: c eq 'foo')", result);
        }

        [Fact]
        public void ArrayContainsWorksInODataFilter()
        {
            var result = FilterString.Generate<Param1>(p => p.Values.Contains("x"));
            Assert.Equal("vals/any(c: c eq 'x')", result);
        }

        [Fact]
        public void DefaultDateTimeProducesProperStringInODataFilter()
        {
            var result = FilterString.Generate<Param1>(p => p.Date2 == new DateTime(2012, 5, 1, 11, 5, 1));
            Assert.Equal("Date2 eq '2012-05-01T11:05:01Z'", result);
        }
    }

    public class Param1
    {
        [FilterParameter("foo")]
        public string Foo { get; set; }
        public int? Val { get; set; }
        [FilterParameter("d", "yyyy-MM-ddTHH:mm:ssZ")]
        public DateTime Date { get; set; }
        public DateTime Date2 { get; set; }
        [FilterParameter("vals")]
        public string[] Values { get; set; }
    }

    public class InputParam1
    {
        public string Value { get; set; }
    }

    public class InputParam2
    {
        public InputParam1 Param { get; set; }
    }
}
