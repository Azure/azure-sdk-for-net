// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "False positives on minimal constructors", Scope = "namespaceanddescendants", Target = "~N:Azure.Developer.DevCenter")]
[assembly: SuppressMessage("Usage", "AZC0006:DO provide constructor overloads that allow specifying additional options.", Justification = "False positives on options constructors", Scope = "namespaceanddescendants", Target = "~N:Azure.Developer.DevCenter")]
