using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Common.OData;
using Xunit;
using Xunit.Extensions;

namespace Microsoft.WindowsAzure.Common.Test.OData
{
    public class FilterStringTest
    {
        [Theory]
        [InlineData("Text eq foo and when = 2014-05-03 and when2 = 2014-05-01 and Amount = 10 and NullAmount = 1 and Color = Cyan", 
            "foo", "05/03/2014", "05/01/2014", 10, 1, ConsoleColor.Cyan)]
        public void GenerateWorksWithSimpleCases(string expected, string text, string when, string nullWhen, int amount, int? nullAmount, ConsoleColor color)
        {
            var filter = new SimpleDummyFilter
                {
                    Text = text,
                    When = DateTime.Parse(when),
                    Amount = amount,
                    NullAmount = nullAmount,
                    Color = color
                };
            if (nullWhen != null)
            {
                filter.NullWhen = DateTime.Parse(nullWhen);
            }
            var result = FilterString.Generate(filter);
            Assert.Equal(expected, result);
        }
    }

    public class SimpleDummyFilter
    {
        public string Text { get; set; }
        [Column(Name = "when")]
        public DateTime When { get; set; }
        [Column(Name = "when2")]
        public DateTime? NullWhen { get; set; }
        public int Amount { get; set; }
        public int? NullAmount { get; set; }
        public ConsoleColor Color { get; set; }
    }
}
