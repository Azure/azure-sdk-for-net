// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Microsoft.ClientModel.TestFramework.Tests.LibraryClient;

public class BookCollectionOptions
{
    /// <summary>
    /// A limit on the number of objects to be returned. 
    /// Limit can range between 1 and 100, and the default is 20.
    /// </summary>
    public int? PageSizeLimit { get; set; }

    /// <summary>
    /// Filter books by author name.
    /// </summary>
    public string? Author { get; set; }

    /// <summary>
    /// A cursor for use in pagination. after is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </summary>
    public string? AfterId { get; set; }

    /// <summary>
    /// A cursor for use in pagination. before is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </summary>
    public string? BeforeId { get; set; }
}
