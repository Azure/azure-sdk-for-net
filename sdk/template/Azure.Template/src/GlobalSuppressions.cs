// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "<Pending>", Scope = "member", Target = "~M:Azure.Template.PetsClient.#ctor(System.Int32,Azure.Core.TokenCredential)")]
[assembly: SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "<Pending>", Scope = "member", Target = "~M:Azure.Template.ListPetToysResponseClient.#ctor(Azure.Core.TokenCredential)")]
[assembly: SuppressMessage("Usage", "AZC0006:DO provide constructor overloads that allow specifying additional options.", Justification = "<Pending>", Scope = "member", Target = "~M:Azure.Template.PetsClient.#ctor(System.Int32,Azure.Core.TokenCredential,System.Uri,Azure.Template.PetStoreServiceClientOptions)")]
[assembly: SuppressMessage("Usage", "AZC0006:DO provide constructor overloads that allow specifying additional options.", Justification = "<Pending>", Scope = "member", Target = "~M:Azure.Template.ListPetToysResponseClient.#ctor(Azure.Core.TokenCredential,System.Uri,Azure.Template.PetStoreServiceClientOptions)")]
[assembly: SuppressMessage("Usage", "AZC0012:Avoid single word type names", Justification = "<Pending>", Scope = "type", Target = "~T:Azure.Template.Models.Pet")]
[assembly: SuppressMessage("Usage", "AZC0012:Avoid single word type names", Justification = "<Pending>", Scope = "type", Target = "~T:Azure.Template.Models.Toy")]
