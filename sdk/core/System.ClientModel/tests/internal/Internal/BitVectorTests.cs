// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Internal;

namespace System.ClientModel.Tests.Internal;

public class BitVectorTests
{
    [Test]
    public void BitsInitializedToFalse()
    {
        BitVector640 vector = new();

        for (int i = 0; i < 640; i++)
        {
            Assert.That(vector[i], Is.False);
        }
    }

    [Test]
    public void CanSetBitsToTrue()
    {
        BitVector640 vector = new();

        for (int i = 0; i < 640; i++)
        {
            vector[i] = true;
            Assert.That(vector[i], Is.True);
        }
    }

    [Test]
    public void CanSetBitsToFalse()
    {
        BitVector640 vector = new();

        for (int i = 0; i < 640; i++)
        {
            vector[i] = true;
        }

        for (int i = 0; i < 640; i++)
        {
            Assert.That(vector[i], Is.True);
        }

        for (int i = 0; i < 640; i++)
        {
            vector[i] = false;
        }

        for (int i = 0; i < 640; i++)
        {
            Assert.That(vector[i], Is.False);
        }
    }
}
