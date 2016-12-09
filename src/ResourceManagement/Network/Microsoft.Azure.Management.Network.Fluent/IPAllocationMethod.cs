// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// Defines values for IPAllocationMethod.
    /// </summary>
    public class IPAllocationMethod
    {
    public static readonly IPAllocationMethod STATIC = new IPAllocationMethod("Static");
    public static readonly IPAllocationMethod DYNAMIC = new IPAllocationMethod("Dynamic");

    private string value;

    public override int GetHashCode()
    {
        return this.value.GetHashCode();
    }

    public static bool operator ==(IPAllocationMethod lhs, IPAllocationMethod rhs)
    {
        if (object.ReferenceEquals(lhs, null))
        {
            return object.ReferenceEquals(rhs, null);
        }
        return lhs.Equals(rhs);
    }

    public static bool operator !=(IPAllocationMethod lhs, IPAllocationMethod rhs)
    {
        return !(lhs == rhs);
    }

    public override bool Equals(object obj)
    {
        string value = this.ToString();
        if (!(obj is IPAllocationMethod))
        {
            return false;
        }

        if (object.ReferenceEquals(obj, this))
        {
            return true;
        }
            IPAllocationMethod rhs = (IPAllocationMethod)obj;
        if (value == null)
        {
            return rhs.value == null;
        }
        return value.Equals(rhs.value);
    }

    public override string ToString()
    {
        return this.value;
    }

    /// <summary>
    /// Creates IPVersion.
    /// </summary>
    /// <param name="value">The value.</param>
    public IPAllocationMethod(string value)
    {
        this.value = value;
    }
}
}
