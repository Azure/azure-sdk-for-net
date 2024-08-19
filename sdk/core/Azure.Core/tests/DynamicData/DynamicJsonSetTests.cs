// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    internal class DynamicJsonSetTests
    {
        [Test]
        [Ignore("Disallowing POCO support in current version.")]
        public void CanAssignTopDown()
        {
            dynamic json = BinaryData.FromString("""{"a":1}""").ToDynamicFromJson(JsonPropertyNames.CamelCase);

            // Existing property
            json.A = new AModel("a");

            ValidateSetTopDown(json);

            // New property
            json = BinaryData.FromString("""{}""").ToDynamicFromJson(JsonPropertyNames.CamelCase);
            json.A = new AModel("a");

            ValidateSetTopDown(json);

            static void ValidateSetTopDown(dynamic json)
            {
                // Verify original
                string orig = """
                {
                  "a": {
                    "id": "a",
                    "ba": {
                      "id": "a*ba",
                      "ca": {
                        "id": "a*ba*ca"
                      },
                      "cb": {
                        "id": "a*ba*cb"
                      }
                    },
                    "bb": {
                      "id": "a*bb",
                      "ca": {
                        "id": "a*bb*ca"
                      },
                      "cb": {
                        "id": "a*bb*cb"
                      }
                    },
                    "bc": {
                      "id": "a*bc",
                      "ca": {
                        "id": "a*bc*ca"
                      },
                      "cb": {
                        "id": "a*bc*cb"
                      }
                    }
                  }
                }
                """;

                Assert.AreEqual(orig.Replace("\r", "").Replace("\n", "").Replace(" ", ""), json.ToString());

                // Make changes from the top down.

                // Changes to A - marked with 0
                json.A.Id = "a0";
                json.A.BA = new BModel("ba0");
                json.A.BB = new BModel("bb0");
                json.A.BC = new BModel("bc0");

                // Changes to B - marked with 1
                json.A.BA.Id = "ba1";
                json.A.BA.CA = new CModel("ca1");
                json.A.BA.CB = new CModel("cb1");

                json.A.BB.Id = "bb1";
                json.A.BB.CA = new CModel("ca1");
                json.A.BB.CB = new CModel("cb1");

                json.A.BC.Id = "bc1";
                json.A.BC.CA = new CModel("ca1");
                json.A.BC.CB = new CModel("cb1");

                // Changes to C - marked with 2
                json.A.BA.CA.Id = "ca2";
                json.A.BA.CB.Id = "cb2";
                json.A.BB.CA.Id = "ca2";
                json.A.BB.CB.Id = "cb2";
                json.A.BC.CA.Id = "ca2";
                json.A.BC.CB.Id = "cb2";

                string changed = """
                {
                  "a": {
                    "id": "a0",
                    "ba": {
                      "id": "ba1",
                      "ca": {
                        "id": "ca2"
                      },
                      "cb": {
                        "id": "cb2"
                      }
                    },
                    "bb": {
                      "id": "bb1",
                      "ca": {
                        "id": "ca2"
                      },
                      "cb": {
                        "id": "cb2"
                      }
                    },
                    "bc": {
                      "id": "bc1",
                      "ca": {
                        "id": "ca2"
                      },
                      "cb": {
                        "id": "cb2"
                      }
                    }
                  }
                }
                """;

                Assert.AreEqual(changed.Replace("\r", "").Replace("\n", "").Replace(" ", ""), json.ToString());
            }
        }

        [Test]
        [Ignore("Disallowing POCO support in current version.")]
        public void CanAssignBottomUp()
        {
            dynamic json = BinaryData.FromString("""{"a":1}""").ToDynamicFromJson(JsonPropertyNames.CamelCase);

            // Existing property
            json.A = new AModel("a");

            ValidateSetBottomUp(json);

            // New property
            json = BinaryData.FromString("""{}""").ToDynamicFromJson(JsonPropertyNames.CamelCase);
            json.A = new AModel("a");

            ValidateSetBottomUp(json);

            static void ValidateSetBottomUp(dynamic json)
            {
                // Verify original
                string orig = """
                {
                  "a": {
                    "id": "a",
                    "ba": {
                      "id": "a*ba",
                      "ca": {
                        "id": "a*ba*ca"
                      },
                      "cb": {
                        "id": "a*ba*cb"
                      }
                    },
                    "bb": {
                      "id": "a*bb",
                      "ca": {
                        "id": "a*bb*ca"
                      },
                      "cb": {
                        "id": "a*bb*cb"
                      }
                    },
                    "bc": {
                      "id": "a*bc",
                      "ca": {
                        "id": "a*bc*ca"
                      },
                      "cb": {
                        "id": "a*bc*cb"
                      }
                    }
                  }
                }
                """;

                Assert.AreEqual(orig.Replace("\r", "").Replace("\n", "").Replace(" ", ""), json.ToString());

                // Make changes from the bottom up
                // Changes to C - marked with 0
                json.A.BA.CA.Id = "ca0";
                json.A.BA.CB.Id = "cb0";
                json.A.BB.CA.Id = "ca0";
                json.A.BB.CB.Id = "cb0";
                json.A.BC.CA.Id = "ca0";
                json.A.BC.CB.Id = "cb0";

                // Changes to B - marked with 1
                json.A.BA.Id = "ba1";
                json.A.BA.CA = new CModel("ca1");
                json.A.BA.CB = new CModel("cb1");

                json.A.BB.Id = "bb1";
                json.A.BB.CA = new CModel("ca1");
                json.A.BB.CB = new CModel("cb1");

                json.A.BC.Id = "bc1";
                json.A.BC.CA = new CModel("ca1");
                json.A.BC.CB = new CModel("cb1");

                // Changes to A - marked with 2
                json.A.Id = "a2";
                json.A.BA = new BModel("ba2");
                json.A.BB = new BModel("bb2");
                json.A.BC = new BModel("bc2");

                string changed = """
                {
                  "a": {
                    "id": "a2",
                    "ba": {
                      "id": "ba2",
                      "ca": {
                        "id": "ba2*ca"
                      },
                      "cb": {
                        "id": "ba2*cb"
                      }
                    },
                    "bb": {
                      "id": "bb2",
                      "ca": {
                        "id": "bb2*ca"
                      },
                      "cb": {
                        "id": "bb2*cb"
                      }
                    },
                    "bc": {
                      "id": "bc2",
                      "ca": {
                        "id": "bc2*ca"
                      },
                      "cb": {
                        "id": "bc2*cb"
                      }
                    }
                  }
                }
                """;

                Assert.AreEqual(changed.Replace("\r", "").Replace("\n", "").Replace(" ", ""), json.ToString());
            }
        }

        [Test]
        [Ignore("Disallowing POCO support in current version.")]
        public void CanAssignLeftRight()
        {
            dynamic json = BinaryData.FromString("""{"a":1}""").ToDynamicFromJson(JsonPropertyNames.CamelCase);

            // Existing property
            json.A = new AModel("a");

            ValidateSetLeftRight(json);

            // New property
            json = BinaryData.FromString("""{}""").ToDynamicFromJson(JsonPropertyNames.CamelCase);
            json.A = new AModel("a");

            ValidateSetLeftRight(json);

            static void ValidateSetLeftRight(dynamic json)
            {
                // Verify original
                string orig = """
                {
                  "a": {
                    "id": "a",
                    "ba": {
                      "id": "a*ba",
                      "ca": {
                        "id": "a*ba*ca"
                      },
                      "cb": {
                        "id": "a*ba*cb"
                      }
                    },
                    "bb": {
                      "id": "a*bb",
                      "ca": {
                        "id": "a*bb*ca"
                      },
                      "cb": {
                        "id": "a*bb*cb"
                      }
                    },
                    "bc": {
                      "id": "a*bc",
                      "ca": {
                        "id": "a*bc*ca"
                      },
                      "cb": {
                        "id": "a*bc*cb"
                      }
                    }
                  }
                }
                """;

                Assert.AreEqual(orig.Replace("\r", "").Replace("\n", "").Replace(" ", ""), json.ToString());

                // Make changes from the left to the right

                // Left - 0
                json.A.BA.CA.Id = "ca0";
                json.A.BA = new BModel("ba0");
                json.A.BA.CB.Id = "cb0";

                // Center, e.g. root - 1
                json.A = new AModel("a1");

                // Right - 2
                json.A.BC.CA.Id = "ca2";
                json.A.BC = new BModel("bc2");
                json.A.BC.CB.Id = "cb2";

                string changed = """
                {
                  "a": {
                    "id": "a1",
                    "ba": {
                      "id": "a1*ba",
                      "ca": {
                        "id": "a1*ba*ca"
                      },
                      "cb": {
                        "id": "a1*ba*cb"
                      }
                    },
                    "bb": {
                      "id": "a1*bb",
                      "ca": {
                        "id": "a1*bb*ca"
                      },
                      "cb": {
                        "id": "a1*bb*cb"
                      }
                    },
                    "bc": {
                      "id": "bc2",
                      "ca": {
                        "id": "bc2*ca"
                      },
                      "cb": {
                        "id": "cb2"
                      }
                    }
                  }
                }
                """;

                Assert.AreEqual(changed.Replace("\r", "").Replace("\n", "").Replace(" ", ""), json.ToString());
            }
        }
    }

    #region Helpers
#pragma warning disable SA1402 // File may only contain a single type
    // Nested model, can have infinite levels
    // Root - 0th level
    public class AModel
    {
        public AModel() { }

        public AModel(string id)
        {
            Id = id;
            BA = new BModel(id + "*ba");
            BB = new BModel(id + "*bb");
            BC = new BModel(id + "*bc");
        }
        public string Id { get; set; }
        public BModel BA { get; set; }
        public BModel BB { get; set; }
        public BModel BC { get; set; }
    }

    // 1st level
    public class BModel
    {
        public BModel() { }

        public BModel(string id)
        {
            Id = id;
            CA = new CModel(id + "*ca");
            CB = new CModel(id + "*cb");
        }
        public string Id { get; set; }
        public CModel CA { get; set; }
        public CModel CB { get; set; }
    }

    // 2nd level
    public class CModel
    {
        public CModel() { }

        public CModel(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
#pragma warning restore SA1402 // File may only contain a single type
    #endregion
}
