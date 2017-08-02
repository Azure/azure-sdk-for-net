// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;
using Newtonsoft.Json;
using Xunit;
using System.Collections.Generic;

namespace Microsoft.Rest.ClientRuntime.Azure.Test
{
    public class ODataTests
    {
        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void DefaultODataQueryTest()
        {
            var date = DateTime.SpecifyKind(new DateTime(2013, 11, 5), DateTimeKind.Utc);
            var date2 = DateTime.SpecifyKind(new DateTime(2004, 11, 5), DateTimeKind.Utc);

            var result = FilterString.Generate<Param1>(p => p.Foo == "foo" || p.Val < 20 || p.Foo == "bar" && p.Val == null &&
                p.Date > date2 &&
                p.Date < date && p.Values.Contains("x"), false);
            string time1 = Uri.EscapeDataString("2004-11-05T00:00:00Z");
            string time2 = Uri.EscapeDataString("2013-11-05T00:00:00Z");
            string expected = string.Format("foo eq 'foo' or Val lt 20 or foo eq 'bar' and Val eq null and d gt '{0}' " +
                "and d lt '{1}' and vals/any(c: c eq 'x')", time1, time2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void ParenthesisAreIgnoredInExpression()
        {
            var result = FilterString.Generate<Param1>(p => p.Foo == "bar" && (p.Foo == "foo" || p.Val < 20));
            Assert.Equal("foo eq 'bar' and foo eq 'foo' or Val lt 20", result);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void NullParametersAreIgnoredInTheBeginningOfExpression()
        {
            string foo = null;
            var result = FilterString.Generate<Param1>(p => p.Foo == foo || p.Val == null || p.Val == 10);
            Assert.Equal("Val eq 10", result);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void NullParametersAreIgnoredInTheMiddleOfExpression()
        {
            var result = FilterString.Generate<Param1>(p => p.Foo == "bar" || p.Val == null || p.Val == 10);
            Assert.Equal("foo eq 'bar' or Val eq 10", result);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void NullParametersAreIgnoredInTheEndOfExpression()
        {
            var result = FilterString.Generate<Param1>(p => p.Foo == "bar" && p.Val == 20 || p.Val == null);
            Assert.Equal("foo eq 'bar' and Val eq 20", result);
        }

        [Fact]
        public void NullParametersAreNotIgnoredInExpression()
        {
            string foo = null;
            var result = FilterString.Generate<Param1>(p => p.Foo == foo || p.Val == null || p.Val == 10, false);
            Assert.Equal("foo eq null or Val eq null or Val eq 10", result);
        }

        [Fact]
        public void NotEqualsIsSupported()
        {
            var result = FilterString.Generate<Param1>(p => p.Val != 20);
            Assert.Equal("Val ne 20", result);
        }

        [Fact]
        public void CompositePropertyIsSupported()
        {
            var result = FilterString.Generate<Param1>(p => p.Param2.Bar == "test" && 
                p.Param2.Param3.Bar == "test2");
            Assert.Equal("param2/bar eq 'test' and param2/param3/bar eq 'test2'", result);
        }

        [Fact]
        public void NullExpressionReturnsExptyString()
        {
            var result = FilterString.Generate<Param1>(null);
            Assert.Equal("", result);
        }

        [Fact]
        public void ResourcePropertyIsSupported()
        {
            var result = FilterString.Generate<AzureResource>(p => p.Size > 10);
            Assert.Equal("properties/size gt 10", result);
        }

        [Fact]
        public void ConditionalOperatorNotSupported()
        {
            Assert.Throws<NotSupportedException>(
                () => FilterString.Generate<Param1>(p => p.Val == (p.Boolean ? 20 : 30)));
        }

        [Fact]
        public void NotEqualsUnaryExpressionIsNotSupported()
        {
            Assert.Throws<NotSupportedException>(() => FilterString.Generate<Param1>(p => !p.Boolean));
            Assert.Throws<NotSupportedException>(() => FilterString.Generate<Param1>(p => !(p.Boolean)));
        }

        [Fact]
        public void ComplexUnaryOperatorsAreNotSupported()
        {
            Assert.Throws<NotSupportedException>(() => FilterString.Generate<Param1>(p => !(p.Boolean || p.Foo == "foo")));
        }

        [Fact]
        public void BooleansAreSupported()
        {
            var result = FilterString.Generate<Param1>(p => p.Boolean == true);
            Assert.Equal("Boolean eq true", result);
            result = FilterString.Generate<Param1>(p => p.Boolean);
            Assert.Equal("Boolean eq true", result);
            result = FilterString.Generate<Param1>(p => p.Boolean && p.Foo == "foo");
            Assert.Equal("Boolean eq true and foo eq 'foo'", result);
            result = FilterString.Generate<Param1>(p => p.Foo == "foo" && p.Boolean);
            Assert.Equal("foo eq 'foo' and Boolean eq true", result);
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
            Assert.Equal("startswith(foo,'foo')", result);
        }

        [Fact]
        public void StartsWithWorksWihNullInODataFilter()
        {
            var param = new InputParam2
            {
                Param = new InputParam1
                {
                    Value = null
                }
            };
            var result = FilterString.Generate<Param1>(p => p.Foo.StartsWith(param.Param.Value));
            Assert.Equal("", result);
        }

        [Fact]
        public void EndsWithWorksInODataFilter()
        {
            var result = FilterString.Generate<Param1>(p => p.Foo.EndsWith("foo"));
            Assert.Equal("endswith(foo, 'foo')", result);
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
            var result = FilterString.Generate<Param1>(p => p.Date2 == new DateTime(2012, 5, 1, 11, 5, 1, DateTimeKind.Utc));
            Assert.Equal("Date2 eq '" + Uri.EscapeDataString("2012-05-01T11:05:01Z") + "'", result);
        }

        [Fact]
        public void DateTimeIsConvertedToUtc()
        {
            var localDate = new DateTime(2012, 5, 1, 11, 5, 1, DateTimeKind.Local);
            var utcDate = localDate.ToUniversalTime();
            var result = FilterString.Generate<Param1>(p => p.Date2 == localDate);
            Assert.Equal("Date2 eq '" + Uri.EscapeDataString(utcDate.ToString("yyyy-MM-ddTHH:mm:ssZ")) + "'", result);
        }

        [Fact]
        public void EncodingTheParameters()
        {
            var param = new InputParam1
            {
                Value = "Microsoft.Web/sites"
            };
            var result = FilterString.Generate<Param1>(p => p.Foo == param.Value);
            Assert.Equal("foo eq 'Microsoft.Web%2Fsites'", result);
        }

        [Fact]
        public void ODataQuerySupportsAllParameters()
        {
            var query = new ODataQuery<Param1>(p => p.Foo == "bar")
            {
                Expand = "param1",
                OrderBy = "d",
                Skip = 10,
                Top = 100
            };
            Assert.Equal("$filter=foo eq 'bar'&$orderby=d&$expand=param1&$top=100&$skip=10", query.ToString());
        }

        [Fact]
        public void ODataQuerySupportsEmptyState()
        {
            var query = new ODataQuery<Param1>();
            Assert.Equal("", query.ToString());
            query = new ODataQuery<Param1>(p => p.Foo == null);
            Assert.Equal("", query.ToString());
            var param = new InputParam1
            {
                Value = null
            };
            var paramEncoded = new InputParam1
            {
                Value = "bar/car"
            };
            query = new ODataQuery<Param1>(p => p.Foo == param.Value);
            Assert.Equal("", query.ToString());
            query = new ODataQuery<Param1>(p => p.Foo == param.Value && p.AssignedTo(param.Value));
            Assert.Equal("", query.ToString());
            query = new ODataQuery<Param1>(p => p.AssignedTo(param.Value));
            Assert.Equal("", query.ToString());
            query = new ODataQuery<Param1>(p => p.AssignedTo(paramEncoded.Value));
            Assert.Equal("$filter=assignedTo('bar%2Fcar')", query.ToString());
        }

        [Fact]
        public void ODataQuerySupportsCustomDateTimeOffsetFilter()
        {
            var param = new Param1
            {
                SubmitTime = DateTimeOffset.Parse("2016-03-28T08:15:00.0971693+00:00"),
                State = "Ended"

            };

            var filter = new List<string>();
            filter.Add(string.Format("submitTime lt datetimeoffset'{0}'", Uri.EscapeDataString(param.SubmitTime.Value.ToString("O"))));
            filter.Add(string.Format("state ne '{0}'", param.State));
            var filterString = string.Join(" and ", filter.ToArray());


            var query = new ODataQuery<Param1>
            {
                Filter = filterString
            };
            Assert.Equal("$filter=submitTime lt datetimeoffset'2016-03-28T08%3A15%3A00.0971693%2B00%3A00' and state ne 'Ended'", query.ToString());
        }


        [Fact]
        public void ODataQuerySupportsPartialState()
        {
            var query = new ODataQuery<Param1>(p => p.Foo == "bar")
            {
                Top = 100
            };
            Assert.Equal("$filter=foo eq 'bar'&$top=100", query.ToString());
        }

        [Fact]
        public void ODataQuerySupportsPartialStateWithSlashes()
        {
            var queryString = "$filter=foo eq 'bar%2Fclub'&$top=100";
            var query = new ODataQuery<Param1>(p => p.Foo == "bar/club")
            {
                Top = 100
            };
            Assert.Equal(queryString, query.ToString());
        }

        [Fact]
        public void ODataQuerySupportsImplicitConversionFromFilterString()
        {
            ODataQuery<Param1> query = "foo eq 'bar'";
            query.Top = 100;
            Assert.Equal("$filter=foo eq 'bar'&$top=100", query.ToString());
        }

        [Fact]
        public void ODataQuerySupportsImplicitConversionFromFullFilterString()
        {
            ODataQuery<Param1> query = "$filter=foo eq 'bar'";
            query.Top = 100;
            Assert.Equal("$filter=foo eq 'bar'&$top=100", query.ToString());
        }

        [Fact]
        public void ODataQuerySupportsImplicitConversionFromQueryString()
        {
            ODataQuery<Param1> query = "$filter=foo eq 'bar'&$top=100";
            Assert.Equal("$filter=foo eq 'bar'&$top=100", query.ToString());
        }

        [Fact]
        public void ODataQuerySupportsTimeSpan()
        {
            var timeSpan = TimeSpan.FromMinutes(5);
            var filterString = FilterString.Generate<Parameters>(parameters => parameters.TimeGrain == timeSpan);
 
            Assert.Equal(filterString, "timeGrain eq duration'PT5M'");
        }
 
        [Fact]
        public void ODataQuerySupportsEnum()
        {
            var timeSpan = TimeSpan.FromMinutes(5);
            var filterString = FilterString.Generate<Parameters>(parameters => parameters.EventChannels == EventChannels.Admin);
            Console.WriteLine(filterString);

            Assert.Equal(filterString, "eventChannels eq 'Admin'");
        }

        [Fact]
        public void ODataQuerySupportsMethod()
        {
            var param = new InputParam1
            {
                Value = "Microsoft.Web/sites"
            };
            var filterString = FilterString.Generate<Param1>(parameters => parameters.AtScope() && 
                parameters.AssignedTo(param.Value));

            Assert.Equal("atScope() and assignedTo('Microsoft.Web%2Fsites')", filterString);
        }
    }

    [Flags]
    public enum EventChannels
    {
        Admin = 1,
        Operation = 2,
        Debug = 4,
        Analytics = 8
    }

    public class Parameters
    {
        [JsonProperty("startTime")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("eventChannels")]
        public EventChannels? EventChannels { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timeGrain")]
        public TimeSpan? TimeGrain { get; set; }

    }

    public class Param1
    {
        [JsonProperty("foo")]
        public string Foo { get; set; }
        public int? Val { get; set; }
        public bool Boolean { get; set; }
        [JsonProperty("d")]
        public DateTime Date { get; set; }
        public DateTime Date2 { get; set; }
        [JsonProperty("submitTime")]
        public DateTimeOffset? SubmitTime { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("vals")]
        public string[] Values { get; set; }
        [JsonProperty("param2")]
        public Param2 Param2 { get; set; }

        [ODataMethodAttribute("assignedTo")]
        public bool AssignedTo(string parameter)
        {
            return true;
        }
        [ODataMethodAttribute("atScope")]
        public bool AtScope()
        {
            return true;
        }
    }

    public class Param2
    {
        [JsonProperty("bar")]
        public string Bar { get; set; }

        [JsonProperty("param3")]
        public Param3 Param3 { get; set; }
    }

    public class Param3
    {
        [JsonProperty("bar")]
        public string Bar { get; set; }
    }

    public class AzureResource : IResource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("properties.size")]
        public int Size { get; set; }
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
