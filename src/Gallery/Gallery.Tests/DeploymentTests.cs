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

using Hyak.Common;

using Microsoft.Azure;
using Microsoft.Azure.Common.OData;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Gallery.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace ResourceGroups.Tests
{
    public class DeploymentTests : TestBase
    {
        public GalleryClient GetClient(RecordedDelegatingHandler handler)
        {
            var cred = new AnonymousCloudCredentials();
            handler.IsPassThrough = true;
            return new GalleryClient(cred, new Uri("https://gallery.azure.com")).WithHandler(handler);
        }

        static void ValidateGalleryItem(GalleryItem item)
        {
            Assert.NotEmpty(item.Identity);
            Assert.NotEmpty(item.Name);
            Assert.NotEmpty(item.DisplayName);
            Assert.NotNull(item.Publisher);
            Assert.NotNull(item.PublisherDisplayName);
            Assert.NotEmpty(item.Version);
            Assert.NotNull(item.Summary);
            Assert.NotNull(item.Description);
            Assert.True(item.IconFileUris.Any());
            Assert.NotEmpty(item.UiDefinitionUri);

            // Icons
            if (item.IconFileUris != null)
            {
                Assert.True(DictionaryHasNonNullProperty(item.IconFileUris, "small"));
                Assert.True(DictionaryHasNonNullProperty(item.IconFileUris, "medium"));
                Assert.True(DictionaryHasNonNullProperty(item.IconFileUris, "large"));
                Assert.True(DictionaryHasNonNullProperty(item.IconFileUris, "wide"));
            }

            // Links
            if ((item.Links != null) && (item.Links.Count > 0))
            {
                foreach (Link link in item.Links)
                {
                    Assert.NotEmpty(link.DisplayName);
                }
            }

            // Properties
            if ((item.Properties != null) && (item.Properties.Keys.Count > 0))
            {
                foreach (string key in item.Properties.Keys)
                {
                    Assert.NotEmpty(key);
                    Assert.NotNull(key);
                }
            }

            // Metadata
            if ((item.Metadata != null) && (item.Metadata.Keys.Count > 0))
            {
                foreach (string key in item.Metadata.Keys)
                {
                    Assert.NotEmpty(key);
                    Assert.NotNull(key);
                }
            }

            // Products
            if ((item.Products != null) && (item.Products.Count > 0))
            {
                foreach (Product product in item.Products)
                {
                    Assert.NotNull(product.DisplayName);
                    Assert.NotNull(product.PublisherDisplayName);

                    if (product.OfferDetails != null)
                    {
                        Assert.NotNull(product.OfferDetails.OfferIdentifier);
                        Assert.NotNull(product.OfferDetails.PublisherIdentifier);

                        if (product.OfferDetails.Plans != null)
                        {
                            foreach (Plan plan in product.OfferDetails.Plans)
                            {
                                Assert.NotNull(plan.PlanIdentifier);
                                Assert.NotNull(plan.Description);
                                Assert.NotNull(plan.DisplayName);
                                Assert.NotNull(plan.Summary);
                            }
                        }
                    } 
                }
            }
        }

        //Can only run live
        //[Fact]
        public void ListWorksWithoutParameters()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetClient(handler);

            var result = client.Items.List(null);

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);

            // Validate result
            Assert.True(result.Items.Any());
            foreach (var item in result.Items)
            {
                ValidateGalleryItem(item);
            }
        }

        //Can only run live
        //[Fact]
        public void ListWorksWithFilterByPublisherParameters()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetClient(handler);

            var result = client.Items.List(new ItemListParameters
                {
                    Filter = FilterString.Generate<ItemListFilter>(f => f.Publisher == "Microsoft")
                });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);

            // Validate result
            Assert.True(result.Items.Any());
            foreach (var item in result.Items)
            {
                Assert.True(string.Equals(item.Publisher, "Microsoft", StringComparison.OrdinalIgnoreCase), 
                    string.Format(CultureInfo.InvariantCulture, "Failed on publisher filter, expected 'Microsoft', found {0}", item.Publisher));
                ValidateGalleryItem(item);
            }
        }

        //Can only run live
        //[Fact]
        public void ListWorksWithFilterByCategoryParameters()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetClient(handler);

            var result = client.Items.List(new ItemListParameters
            {
                Filter = FilterString.Generate<ItemListFilter>(f => f.CategoryIds.Contains("azure") && f.CategoryIds.Contains("database"))
            });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);

            // Validate result
            Assert.True(result.Items.Any());
            foreach (var item in result.Items)
            {
                Assert.Contains("azure", item.Categories);
                Assert.Contains("database", item.Categories);
                ValidateGalleryItem(item);
            }
        }

        //Can only run live
        //[Fact]
        public void ListWorksWithFilterByItemParameters()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetClient(handler);

            var resultFromList = client.Items.List(new ItemListParameters { Top = 1 });

            var result = client.Items.List(new ItemListParameters
            {
                Filter = FilterString.Generate<ItemListFilter>(f => f.Name == resultFromList.Items[0].Name)
            });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);

            // Validate result
            Assert.True(result.Items.Any());
            Assert.True(resultFromList.Items.Any());
            Assert.Equal<int>(1, result.Items.Count);
            Assert.Equal<int>(1, resultFromList.Items.Count);
            Assert.Equal<string>(resultFromList.Items[0].Name, result.Items[0].Name);
        }

        //Can only run live
        //[Fact]
        public void GetReturnsAnItem()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetClient(handler);

            var list = client.Items.List(null);

            foreach (var item in list.Items)
            {
                var result = client.Items.Get(item.Identity);

                // Validate headers
                Assert.Equal(HttpMethod.Get, handler.Method);

                // Validate result
                Assert.Equal<string>(item.Identity, result.Item.Identity);
                ValidateGalleryItem(result.Item);
            }
        }

        private static string ToCamelCase(string other)
        {
            TracingAdapter.Information("[ToCamelCase]: Changing Key {0}", other);
            StringBuilder builder = new StringBuilder(other);
            builder[0] = char.ToLower(builder[0]);
            return builder.ToString();
        }

        private static bool DictionaryHasNonNullProperty<T>(IDictionary<string, T> dictionary, string propertyName)
        {
            T propertyValue;
            return dictionary.TryGetValue(propertyName, out propertyValue) && (propertyValue != null);
        }
    }
}
