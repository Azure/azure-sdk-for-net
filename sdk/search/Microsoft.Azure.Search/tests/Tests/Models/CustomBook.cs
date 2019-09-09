// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using Newtonsoft.Json;

    internal class CustomAuthor
    {
        public string FullName { get; set; }

        public override int GetHashCode() => FullName?.GetHashCode() ?? 0;

        public override bool Equals(object obj) => obj is CustomAuthor other && FullName == other.FullName;

        public override string ToString() => FullName?.ToString() ?? string.Empty;
    }

    internal abstract class CustomBookBase<T> where T : CustomAuthor
    {
        public string InternationalStandardBookNumber { get; set; }

        public string Name { get; set; }

        public T AuthorName { get; set; }

        public DateTime? PublishDateTime { get; set; }

        public override bool Equals(object obj) =>
            obj is CustomBookBase<T> other &&
            InternationalStandardBookNumber == other.InternationalStandardBookNumber &&
            Name == other.Name &&
            AuthorName.EqualsNullSafe(other.AuthorName) &&
            PublishDateTime == other.PublishDateTime;

        public override int GetHashCode() => InternationalStandardBookNumber?.GetHashCode() ?? 0;

        public override string ToString() =>
            $"ISBN: {InternationalStandardBookNumber}; Title: {Name}; Author: {AuthorName}; PublishDate: {PublishDateTime}";
    }

    internal class CustomBook : CustomBookBase<CustomAuthor>
    {
    }

    [JsonConverter(typeof(CustomAuthorConverter<CustomAuthorWithConverter>))]
    internal class CustomAuthorWithConverter : CustomAuthor
    {
    }

    [JsonConverter(typeof(CustomBookConverter<CustomBookWithConverter, CustomAuthorWithConverter>))]
    internal class CustomBookWithConverter : CustomBookBase<CustomAuthorWithConverter>
    {
    }
}
