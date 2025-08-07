// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.KeyVault.Certificates.Samples
{
    public partial class ImportCertificate
    {
    #region Certificates
#if !SNIPPET
        // Taken from CertificateClientLiveTestsConstants

        // Expires: 2031-11-01T14:38:51.0000000-07:00
        private static readonly string s_pem =
        "-----BEGIN CERTIFICATE-----\n" +
        "MIIDBjCCAe6gAwIBAgIJAIp6zuzS7TciMA0GCSqGSIb3DQEBCwUAMBQxEjAQBgNVBAMTCUF6dXJl\n" +
        "IFNESzAeFw0yMTExMDEyMTM4NTFaFw0zMTExMDEyMTM4NTFaMBQxEjAQBgNVBAMTCUF6dXJlIFNE\n" +
        "SzCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAJThmsquiv9NpJkzpugEu/6/GIUVmpy3\n" +
        "CsjWmtfvFNL5UrGvI/YSZCEt4VRvI3TlcRxw+ewOSAIPSLMXwN6Qj5Edw07CKNhfXNtrdP7ATTox\n" +
        "AUD/pOiw8/7NOs+tQ2UVEpbzHYTCHGZ7OiL/ffc6EptptLyiP83YAiTLXE1ayFMiKegqv52dPxja\n" +
        "0gRXycBdqx5w5lARN/cYzbukFetO3At4Wjp8+pl/h2GkfK18SK1F+63jpkA0CaW+b6mwSZgJYZGR\n" +
        "SGJjITJ8/T32RIP1wt01KmqElS6/kqsInwVuYHQkn8HJBJfu6qD3MfmzpYMMXwNqzc+2pERLnvIP\n" +
        "zzXys+0CAwEAAaNbMFkwDwYDVR0TAQH/BAUwAwEB/zAhBgNVHREEGjAYgRZhenVyZXNka0BtaWNy\n" +
        "b3NvZnQuY29tMA4GA1UdDwEB/wQEAwIF4DATBgNVHSUEDDAKBggrBgEFBQcDATANBgkqhkiG9w0B\n" +
        "AQsFAAOCAQEAVNty5AeZZBBbPgVb1s8+GAPTTxo3xMVq2kv3zPkFbOgL8T8VRfb1Bs9gPGDm9pfQ\n" +
        "H3h2n0SXB4hUcV8vOFLZsQo+Kms8LjK2oej0ReB33SSg/vo8lR9RA0cGjLn/Zpz6+PI+W4TM3ujb\n" +
        "aw7HTnnAMYBtnOU7vJbXvIzJEg64pHJyJhipwT6uJz3S3FnGxT7iW6CdYNKxIW5+BW8YO8YIONFd\n" +
        "b4HBw/bQfD/xfH4iDYTQqpmlce1UVh4NJ1oqAENQAmuyDt0RyCtxATrtXXTE9JAh8tV36zgRRDXB\n" +
        "E4qx9fQ7+8qOLw+b/S0pbbPJtOGZAZtaaYJTRwz21AGxjKemNQ==\n" +
        "-----END CERTIFICATE-----\n" +
        "-----BEGIN PRIVATE KEY-----\n" +
        "MIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQCU4ZrKror/TaSZM6boBLv+vxiF\n" +
        "FZqctwrI1prX7xTS+VKxryP2EmQhLeFUbyN05XEccPnsDkgCD0izF8DekI+RHcNOwijYX1zba3T+\n" +
        "wE06MQFA/6TosPP+zTrPrUNlFRKW8x2Ewhxmezoi/333OhKbabS8oj/N2AIky1xNWshTIinoKr+d\n" +
        "nT8Y2tIEV8nAXasecOZQETf3GM27pBXrTtwLeFo6fPqZf4dhpHytfEitRfut46ZANAmlvm+psEmY\n" +
        "CWGRkUhiYyEyfP099kSD9cLdNSpqhJUuv5KrCJ8FbmB0JJ/ByQSX7uqg9zH5s6WDDF8Das3PtqRE\n" +
        "S57yD8818rPtAgMBAAECggEAMcC25tavcqPyxpPBSjYS0Q3xVsAifA6bVwSImHK4JczV+rUJsnjw\n" +
        "5zma3ImLcsweIaALlPwsyitrYxYkCPyMTbWBiDdQSQaNVHIzldKTvEeWIK+N34kK8PKKnc5MAGKr\n" +
        "ZLB4A96OeRzjD8ELymuovjD0Cjm6UsLF7J/dB6i32zfEA67wVMi7q65xNxnoSMqAyIVuTL9/T/Gg\n" +
        "9IZ/qv+AbalSxTbZcACx2p9TtNNW9fUjOoNQ5mFrVch4Li2jCfuXeiGduvvJuFi1YEGR8RXVMjTb\n" +
        "K3XGL9LAy4b7nlk9HX0bdnpqUuFjPxmT2PF6zaLx1iYEQ7C3Kg6osJwq5koLTQKBgQDANIxqOG+b\n" +
        "JPbLQRFmsCm9lc/WSN0/6GPvgTQk67zLgLz4KssLhSBq6K6b5egMgQB8Mf9E3VrPEz+6FGv9A5uN\n" +
        "jS3RJjvr/vUBppafVChfJ2j8Ym+M2lERsxXnHEUalOPV2xIBY7P6CJkd8AFvJ0g7qodiHiWKtd17\n" +
        "vrYHKSE1RwKBgQDGS94nt86Ln4S6PZA+uc/sDIZg+Nzup4RcLNB3c18DkLU6x7UJGdclmQ5lzFj8\n" +
        "dvB+YKmCjR+xdVVRsXxwTkO1HWDiVX0gCu4uwRqVpPmhAbGDTIKP8C0VygZXq/KiH+P0mxm0ar0/\n" +
        "NZ8F1Gb/L2jUfgyelEBItlmgVukDFe+3KwKBgHkxqUhhBZ6iFCvdf4dslSVCDadkkn31nu4qXiLZ\n" +
        "slXvezhQY2+EJgjDZzZOJZ+cyB2HuRpHKTdhP9Gpht4nJDKBTt6OaUJJpVvBG0Cj5ED7rKtXtlbu\n" +
        "Yify8GCl5rz4HSF/3T6bC6UhPsstxvm7n0RgJrWrpKhuPJYGjui8+n+JAoGAPXuIhggXonLzVEuC\n" +
        "TfCO50F66NZAqj6Ga435lQ/Qhep4RqFlIE1CyAWM0UNq09yM9KJD7JaVHRCkQ5AkZS3fEGjrgUHA\n" +
        "ag75isWU2JEuVR2RTISMdtShJgBdtxE5SctZgp4UejweMVsO01/oD3dDqZ7rir+srt7bKzvHQ42p\n" +
        "pcECgYBO8pp9l3P18f7Pr1B9/A+yD+55g1p4xYxxFZIk0XRDM0M74m8VN1xkiPcsk/qKtX/aHxZW\n" +
        "BQ1nsjz+ehwp5gqrflywQM6o5jevUH3WGujKDZvVKE0M79MbrEwurZz57DRSx35146ngbYcM4iAX\n" +
        "r+jbJ/mZF13/0dsQIUuD1Cn3Qw==\n" +
        "-----END PRIVATE KEY-----\n";

        // Expires: 2031-11-01T14:04:31.0000000-07:00
        private static readonly string s_pfxBase64 =
        "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" +
        "eSILBgICB9A=";
#endif
        #endregion
    }
}
