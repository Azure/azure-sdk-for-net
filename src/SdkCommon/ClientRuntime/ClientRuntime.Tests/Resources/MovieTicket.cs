// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microsoft.Rest.ClientRuntime.Tests.Resources
{

    internal class DaysOfWeekExtensibleEnum : Microsoft.Rest.ExtensibleEnum<DaysOfWeekExtensibleEnum, string>
    {
        private DaysOfWeekExtensibleEnum(string value) : base(value)
        {
        }

        public static readonly DaysOfWeekExtensibleEnum Monday = "Monday";
        public static readonly DaysOfWeekExtensibleEnum Tuesday = "Tuesday";
        public static readonly DaysOfWeekExtensibleEnum Wednesday = "Wednesday";
        public static readonly DaysOfWeekExtensibleEnum Thursday = "Thursday";
        public static readonly DaysOfWeekExtensibleEnum Friday = "Friday";
        public static readonly DaysOfWeekExtensibleEnum Saturday = "Saturday";
        public static readonly DaysOfWeekExtensibleEnum Sunday = "Sunday";

        /// <summary>
        /// Defines ctor/explicit conversion from value type to
        /// DaysOfWeekExtensibleEnum.
        /// </summary>
        /// <param name="value">string to convert.</param>
        public static implicit operator DaysOfWeekExtensibleEnum(string value) => Create(value);

        public static DaysOfWeekExtensibleEnum Create(string value) => _valueMap.GetOrAdd(value, (v) => new DaysOfWeekExtensibleEnum(v));

    }

    public sealed class TaxAmount : Microsoft.Rest.ExtensibleEnum<TaxAmount, string>
    {
        private TaxAmount(string value) : base(value)
        {
        }

        public static readonly TaxAmount One = "1";
        public static readonly TaxAmount Two = "2";
        public static readonly TaxAmount Three = "3";

        public static implicit operator TaxAmount(string value) => Create(value);

        public static TaxAmount Create(string value)
        {
            System.Console.Error.WriteLine("we're trying to deserialize "+value);
            if (AllowedValuesMap.ContainsKey(value))
            {
                return AllowedValuesMap[value];
            }

            return _valueMap.GetOrAdd(value, (v) => new TaxAmount(v));
        }

        static TaxAmount()
        {
            AllowedValuesMap = new Dictionary<string, TaxAmount>();
            AllowedValuesMap.Add("1.1", One);
            AllowedValuesMap.Add("1.2", One);
            AllowedValuesMap.Add("1.3", One);
            AllowedValuesMap.Add("2.1", Two);
            AllowedValuesMap.Add("2.2", Two);
            AllowedValuesMap.Add("3.1", Three);
            AllowedValuesMap.Add("3.3", Three);
        }
        
    }

    internal class MovieTicket
    {
        public double Price { get; set; }

        [JsonConverter(typeof(Serialization.ExtensibleEnumConverter<DaysOfWeekExtensibleEnum, string>))]
        public DaysOfWeekExtensibleEnum Day { get; set; }

        public string MovieName { get; set; }

        public TaxAmount Tax { get; set; }

    }
}
