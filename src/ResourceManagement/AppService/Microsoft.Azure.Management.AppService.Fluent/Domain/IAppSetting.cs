// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    /// <summary>
    /// An immutable client-side representation of an app setting on a web app.
    /// </summary>
    public interface IAppSetting 
    {
        bool Sticky { get; }

        string Value { get; }

        string Key { get; }
    }
}