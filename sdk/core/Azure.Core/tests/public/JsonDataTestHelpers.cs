// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Tests.Public
{
    public class JsonDataTestHelpers
    {
        public static dynamic CreateEmpty()
        {
            return BinaryData.FromString("{}").ToDynamicFromJson();
        }

        public static dynamic CreateFromJson(string json)
        {
            return BinaryData.FromString(json).ToDynamicFromJson();
        }

        public static T JsonAsType<T>(string json)
        {
            dynamic jsonData = new BinaryData(json).ToDynamicFromJson();
            return (T)jsonData;
        }
    }

#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
#pragma warning disable SA1402 // File may only contain a single type
    public class SampleModel : IEquatable<SampleModel>
#pragma warning restore SA1402 // File may only contain a single type
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        public SampleModel() { }

        public string Message { get; set; }
        public int Number { get; set; }

        public SampleModel(string message, int number)
        {
            Message = message;
            Number = number;
        }

        public override bool Equals(object obj)
        {
            SampleModel other = obj as SampleModel;
            if (other == null)
            {
                return false;
            }

            return Equals(other);
        }

        public bool Equals(SampleModel obj)
        {
            return Message == obj.Message && Number == obj.Number;
        }
    }
}
