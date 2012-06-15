using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using SecureString = System.Security.SecureString;
using RuntimeHelpers = System.Runtime.CompilerServices.RuntimeHelpers;

namespace APITests
{
    internal class CertificateCreator
    {
        public static byte[] CreateSelfSignCertificatePfx(
            string x500,
            DateTime startTime,
            DateTime endTime)
        {
            byte[] pfxData = CreateSelfSignCertificatePfx(
                x500,
                startTime,
                endTime,
                (SecureString)null);
            return pfxData;
        }

        public static byte[] CreateSelfSignCertificatePfx(
            string x500,
            DateTime startTime,
            DateTime endTime,
            string insecurePassword)
        {
            byte[] pfxData;
            SecureString password = null;

            try
            {
                if (!string.IsNullOrEmpty(insecurePassword))
                {
                    password = new SecureString();
                    foreach (char ch in insecurePassword)
                    {
                        password.AppendChar(ch);
                    }

                    password.MakeReadOnly();
                }

                pfxData = CreateSelfSignCertificatePfx(
                    x500,
                    startTime,
                    endTime,
                    password);
            }
            finally
            {
                if (password != null)
                {
                    password.Dispose();
                }
            }

            return pfxData;
        }

        public static byte[] CreateSelfSignCertificatePfx(
            string x500,
            DateTime startTime,
            DateTime endTime,
            SecureString password)
        {
            byte[] pfxData;

            if (x500 == null)
            {
                x500 = "";
            }

            SystemTime startSystemTime = ToSystemTime(startTime);
            SystemTime endSystemTime = ToSystemTime(endTime);
            string containerName = Guid.NewGuid().ToString();

            GCHandle dataHandle = new GCHandle();
            IntPtr providerContext = IntPtr.Zero;
            IntPtr cryptKey = IntPtr.Zero;
            IntPtr certContext = IntPtr.Zero;
            IntPtr certStore = IntPtr.Zero;
            IntPtr storeCertContext = IntPtr.Zero;
            IntPtr passwordPtr = IntPtr.Zero;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                Check(NativeMethods.CryptAcquireContextW(
                    out providerContext,
                    containerName,
                    null,
                    1, // PROV_RSA_FULL
                    8)); // CRYPT_NEWKEYSET

                Check(NativeMethods.CryptGenKey(
                    providerContext,
                    1, // AT_KEYEXCHANGE
                    1, // CRYPT_EXPORTABLE
                    out cryptKey));

                IntPtr errorStringPtr;
                int nameDataLength = 0;
                byte[] nameData;

                // errorStringPtr gets a pointer into the middle of the x500 string,
                // so x500 needs to be pinned until after we've copied the value
                // of errorStringPtr.
                dataHandle = GCHandle.Alloc(x500, GCHandleType.Pinned);

                if (!NativeMethods.CertStrToNameW(
                    0x00010001, // X509_ASN_ENCODING | PKCS_7_ASN_ENCODING
                    dataHandle.AddrOfPinnedObject(),
                    3, // CERT_X500_NAME_STR = 3
                    IntPtr.Zero,
                    null,
                    ref nameDataLength,
                    out errorStringPtr))
                {
                    string error = Marshal.PtrToStringUni(errorStringPtr);
                    throw new ArgumentException(error);
                }

                nameData = new byte[nameDataLength];

                if (!NativeMethods.CertStrToNameW(
                    0x00010001, // X509_ASN_ENCODING | PKCS_7_ASN_ENCODING
                    dataHandle.AddrOfPinnedObject(),
                    3, // CERT_X500_NAME_STR = 3
                    IntPtr.Zero,
                    nameData,
                    ref nameDataLength,
                    out errorStringPtr))
                {
                    string error = Marshal.PtrToStringUni(errorStringPtr);
                    throw new ArgumentException(error);
                }

                dataHandle.Free();

                dataHandle = GCHandle.Alloc(nameData, GCHandleType.Pinned);
                CryptoApiBlob nameBlob = new CryptoApiBlob(
                    nameData.Length,
                    dataHandle.AddrOfPinnedObject());

                CryptKeyProviderInformation kpi = new CryptKeyProviderInformation();
                kpi.ContainerName = containerName;
                kpi.ProviderType = 1; // PROV_RSA_FULL
                kpi.KeySpec = 1; // AT_KEYEXCHANGE

                certContext = NativeMethods.CertCreateSelfSignCertificate(
                    providerContext,
                    ref nameBlob,
                    0,
                    ref kpi,
                    IntPtr.Zero, // default = SHA1RSA
                    ref startSystemTime,
                    ref endSystemTime,
                    IntPtr.Zero);
                Check(certContext != IntPtr.Zero);
                dataHandle.Free();

                certStore = NativeMethods.CertOpenStore(
                    "Memory", // sz_CERT_STORE_PROV_MEMORY
                    0,
                    IntPtr.Zero,
                    0x2000, // CERT_STORE_CREATE_NEW_FLAG
                    IntPtr.Zero);
                Check(certStore != IntPtr.Zero);

                Check(NativeMethods.CertAddCertificateContextToStore(
                    certStore,
                    certContext,
                    1, // CERT_STORE_ADD_NEW
                    out storeCertContext));

                NativeMethods.CertSetCertificateContextProperty(
                    storeCertContext,
                    2, // CERT_KEY_PROV_INFO_PROP_ID
                    0,
                    ref kpi);

                if (password != null)
                {
                    passwordPtr = Marshal.SecureStringToCoTaskMemUnicode(password);
                }

                CryptoApiBlob pfxBlob = new CryptoApiBlob();
                Check(NativeMethods.PFXExportCertStoreEx(
                    certStore,
                    ref pfxBlob,
                    passwordPtr,
                    IntPtr.Zero,
                    7)); // EXPORT_PRIVATE_KEYS | REPORT_NO_PRIVATE_KEY | REPORT_NOT_ABLE_TO_EXPORT_PRIVATE_KEY

                pfxData = new byte[pfxBlob.DataLength];
                dataHandle = GCHandle.Alloc(pfxData, GCHandleType.Pinned);
                pfxBlob.Data = dataHandle.AddrOfPinnedObject();
                Check(NativeMethods.PFXExportCertStoreEx(
                    certStore,
                    ref pfxBlob,
                    passwordPtr,
                    IntPtr.Zero,
                    7)); // EXPORT_PRIVATE_KEYS | REPORT_NO_PRIVATE_KEY | REPORT_NOT_ABLE_TO_EXPORT_PRIVATE_KEY
                dataHandle.Free();
            }
            finally
            {
                if (passwordPtr != IntPtr.Zero)
                {
                    Marshal.ZeroFreeCoTaskMemUnicode(passwordPtr);
                }

                if (dataHandle.IsAllocated)
                {
                    dataHandle.Free();
                }

                if (certContext != IntPtr.Zero)
                {
                    NativeMethods.CertFreeCertificateContext(certContext);
                }

                if (storeCertContext != IntPtr.Zero)
                {
                    NativeMethods.CertFreeCertificateContext(storeCertContext);
                }

                if (certStore != IntPtr.Zero)
                {
                    NativeMethods.CertCloseStore(certStore, 0);
                }

                if (cryptKey != IntPtr.Zero)
                {
                    NativeMethods.CryptDestroyKey(cryptKey);
                }

                if (providerContext != IntPtr.Zero)
                {
                    NativeMethods.CryptReleaseContext(providerContext, 0);
                    NativeMethods.CryptAcquireContextW(
                        out providerContext,
                        containerName,
                        null,
                        1, // PROV_RSA_FULL
                        0x10); // CRYPT_DELETEKEYSET
                }
            }

            return pfxData;
        }

        private static SystemTime ToSystemTime(DateTime dateTime)
        {
            long fileTime = dateTime.ToFileTime();
            SystemTime systemTime;
            Check(NativeMethods.FileTimeToSystemTime(ref fileTime, out systemTime));
            return systemTime;
        }

        private static void Check(bool nativeCallSucceeded)
        {
            if (!nativeCallSucceeded)
            {
                int error = Marshal.GetHRForLastWin32Error();
                Marshal.ThrowExceptionForHR(error);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SystemTime
        {
            public short Year;
            public short Month;
            public short DayOfWeek;
            public short Day;
            public short Hour;
            public short Minute;
            public short Second;
            public short Milliseconds;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CryptoApiBlob
        {
            public int DataLength;
            public IntPtr Data;

            public CryptoApiBlob(int dataLength, IntPtr data)
            {
                DataLength = dataLength;
                Data = data;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CryptKeyProviderInformation
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string ContainerName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string ProviderName;
            public int ProviderType;
            public int Flags;
            public int ProviderParameterCount;
            public IntPtr ProviderParameters; // PCRYPT_KEY_PROV_PARAM
            public int KeySpec;
        }

        private static class NativeMethods
        {
            [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool FileTimeToSystemTime(
                [In] ref long fileTime,
                out SystemTime systemTime);

            [DllImport("AdvApi32.dll", SetLastError = true, ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CryptAcquireContextW(
                out IntPtr providerContext,
                [MarshalAs(UnmanagedType.LPWStr)] string container,
                [MarshalAs(UnmanagedType.LPWStr)] string provider,
                int providerType,
                int flags);

            [DllImport("AdvApi32.dll", SetLastError = true, ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CryptReleaseContext(
                IntPtr providerContext,
                int flags);

            [DllImport("AdvApi32.dll", SetLastError = true, ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CryptGenKey(
                IntPtr providerContext,
                int algorithmId,
                int flags,
                out IntPtr cryptKeyHandle);

            [DllImport("AdvApi32.dll", SetLastError = true, ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CryptDestroyKey(
                IntPtr cryptKeyHandle);

            [DllImport("Crypt32.dll", SetLastError = true, ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CertStrToNameW(
                int certificateEncodingType,
                IntPtr x500,
                int strType,
                IntPtr reserved,
                [MarshalAs(UnmanagedType.LPArray)] [Out] byte[] encoded,
                ref int encodedLength,
                out IntPtr errorString);

            [DllImport("Crypt32.dll", SetLastError = true, ExactSpelling = true)]
            public static extern IntPtr CertCreateSelfSignCertificate(
                IntPtr providerHandle,
                [In] ref CryptoApiBlob subjectIssuerBlob,
                int flags,
                [In] ref CryptKeyProviderInformation keyProviderInformation,
                IntPtr signatureAlgorithm,
                [In] ref SystemTime startTime,
                [In] ref SystemTime endTime,
                IntPtr extensions);

            [DllImport("Crypt32.dll", SetLastError = true, ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CertFreeCertificateContext(
                IntPtr certificateContext);

            [DllImport("Crypt32.dll", SetLastError = true, ExactSpelling = true)]
            public static extern IntPtr CertOpenStore(
                [MarshalAs(UnmanagedType.LPStr)] string storeProvider,
                int messageAndCertificateEncodingType,
                IntPtr cryptProvHandle,
                int flags,
                IntPtr parameters);

            [DllImport("Crypt32.dll", SetLastError = true, ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CertCloseStore(
                IntPtr certificateStoreHandle,
                int flags);

            [DllImport("Crypt32.dll", SetLastError = true, ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CertAddCertificateContextToStore(
                IntPtr certificateStoreHandle,
                IntPtr certificateContext,
                int addDisposition,
                out IntPtr storeContextPtr);

            [DllImport("Crypt32.dll", SetLastError = true, ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CertSetCertificateContextProperty(
                IntPtr certificateContext,
                int propertyId,
                int flags,
                [In] ref CryptKeyProviderInformation data);

            [DllImport("Crypt32.dll", SetLastError = true, ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool PFXExportCertStoreEx(
                IntPtr certificateStoreHandle,
                ref CryptoApiBlob pfxBlob,
                IntPtr password,
                IntPtr reserved,
                int flags);
        }
    }
}
