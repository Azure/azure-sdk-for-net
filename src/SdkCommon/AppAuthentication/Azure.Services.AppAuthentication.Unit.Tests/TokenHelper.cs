// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    /// <summary>
    /// Helper class to generate tokens for unit testing
    /// </summary>
    public class TokenHelper
    {
        /// <summary>
        /// The hardcoded user token has expiry replaced by [exp], so we can replace it with some value to test functionality. 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="secondsFromCurrent"></param>
        /// <returns></returns>
        private static string UpdateTokenTime(string accessToken, long secondsFromCurrent)
        {
            var timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);

            byte[] tokenAsBytes = Convert.FromBase64String(accessToken);
            string tokenAsString = Encoding.ASCII.GetString(tokenAsBytes);
            tokenAsString = tokenAsString.Replace("[exp]", $"{(long) timeSpan.TotalSeconds + secondsFromCurrent}");
            tokenAsBytes = Encoding.ASCII.GetBytes(tokenAsString);
            return Convert.ToBase64String(tokenAsBytes);
        }

        internal static string GetUserToken()
        {
            // Gets a user token that will expire in 10 seconds from now. 
            return GetUserToken(10);
        }

        internal static string GetUserToken(long secondsFromCurrent)
        {
            // This is a dummy user token, where exp claim is set to [exp], so can be changed for testing
            string midPart =
                "eyJhdWQiOiJodHRwczovL2RhdGFiYXNlLndpbmRvd3MubmV0LyIsImlzcyI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0LzcyZjk4OGJmLTg2ZjEtNDFhZi05MWFiLTJkN2NkMDExZGI0Ny8iLCJpYXQiOjE1MDMxOTAwNjAsIm5iZiI6MTUwMzE5MDA2MCwiZXhwIjpbZXhwXSwiX2NsYWltX25hbWVzIjp7Imdyb3VwcyI6InNyYzEifSwiX2NsYWltX3NvdXJjZXMiOnsic3JjMSI6eyJlbmRwb2ludCI6Imh0dHBzOi8vZ3JhcGgud2luZG93cy5uZXQvNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3L3VzZXJzLzljZWI0NGFmLTQ0MzctNGNjYy1hNDlhLTlhOWJkZTA2NzUyZS9nZXRNZW1iZXJPYmplY3RzIn19LCJhY3IiOiIxIiwiYWlvIjoiWTJGZ1lMRGVWT2Q4ei85cncvLzNzODdaZURHWDNTcS9taHZwSWg2bHU5am55UFNHdmxNQSIsImFtciI6WyJ3aWEiLCJtZmEiXSwiYXBwaWQiOiIwNGIwNzc5NS04ZGRiLTQ2MWEtYmJlZS0wMmY5ZTFiZjdiNDYiLCJhcHBpZGFjciI6IjAiLCJlX2V4cCI6MjYyODAwLCJmYW1pbHlfbmFtZSI6IkRvZSIsImdpdmVuX25hbWUiOiJKb2huIiwiaW5fY29ycCI6InRydWUiLCJpcGFkZHIiOiIxMC4xMC4wLjAiLCJuYW1lIjoiSm9obiBEb2UiLCJvaWQiOiI5Y2ViNDRhZi00NDM3LTRjY2MtYTQ5YS05YTliZGUwNjc1MmUiLCJzY3AiOiJ1c2VyX2ltcGVyc29uYXRpb24iLCJzdWIiOiJfVkJwSVNBZUlfS1VBVHZPdl93RWJzdlE1YlZjUERSLUhuRTVBUmszb21FIiwidGlkIjoiNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3IiwidW5pcXVlX25hbWUiOiJqb2huZG9lQGNvbnRvc28uY29tIiwidXBuIjoiam9obmRvZUBjb250b3NvLmNvbSIsInZlciI6IjEuMCJ9";

            midPart = UpdateTokenTime(midPart, secondsFromCurrent);

            return 
                "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IlZXVkljMVdEMVRrc2JiMzAxc2FzTTVrT3E1USIsImtpZCI6IlZXVkljMVdEMVRrc2JiMzAxc2FzTTVrT3E1USJ9" + "." + midPart + "." + "gGo1wCH2k8kqt6JUdjBMavZX9Sq2L_tKLvVDPUJv3NurZT5JGYyS7gJ11RMrVaxyG48dnlWat1vEBcB-YLOkpL-2gR_sSAoAStPuz8yXAFHxluw-WOqiWxlm2leENqwMmCrMYinm8ohkrScpfRFm6-4fzgczdhNi0vjkTHaycYnrPrH9cZHSL9Qyzt6MH6pEyGct4zmgASI1Vlrga5_x_x8xj-FscIRYorrvx61fThaor8M4FjzglNgum4j5yecn1pIcp75CK43xb7e4jdsfL2nl6wgn5mZj_59b_aKNa3_VA-NmZTlxjvjlL_AHdDkYPlku_B75-0EbfKN2IR5eLw";
        }

        internal static string GetUserTokenResponse(long secondsFromCurrent, bool formatForVisualStudio = false)
        {
            string tokenResult =
                "{  \"accessToken\": \"{accesstoken}\",  \"expiresOn\": \"{expireson}\",  \"subscription\": \"1135bf8c-f190-46f2-bfd6-d57c57852c04\",  \"tenant\": \"72f988bf-86f1-41af-91ab-2d7cd011db47\",  \"tokenType\": \"Bearer\"}";

            tokenResult = tokenResult.Replace("{accesstoken}", GetUserToken(secondsFromCurrent));
            tokenResult = tokenResult.Replace("{expireson}", DateTimeOffset.Now.AddSeconds(secondsFromCurrent).ToString());

            if (formatForVisualStudio)
            {
                tokenResult = tokenResult.Replace("accessToken", "access_token");
                tokenResult = tokenResult.Replace("expiresOn", "expires_on");
            }

            return tokenResult;
        }

        /// <summary>
        ///  The response has claims as expected from Azure App Service MSI response
        /// </summary>
        /// <returns></returns>
        internal static string GetMsiAppServicesTokenResponse()
        {
            return
                "{\"access_token\":\"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImEzUU4wQlpTN3M0bk4tQmRyamJGMFlfTGRNTSIsImtpZCI6ImEzUU4wQlpTN3M0bk4tQmRyamJGMFlfTGRNTSJ9.eyJhdWQiOiJodHRwczovL3ZhdWx0LmF6dXJlLm5ldCIsImlzcyI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0LzcyZjk4OGJmLTg2ZjEtNDFhZi05MWFiLTJkN2NkMDExZGI0Ny8iLCJpYXQiOjE0OTIyNjYwNjEsIm5iZiI6MTQ5MjI2NjA2MSwiZXhwIjoxNDkyMjY5OTYxLCJhaW8iOiJZMlpnWUNoTk91Yy9ZKzJMOVM3Ty8yWTBDL2lhQUFBPSIsImFwcGlkIjoiZjBiMWY4NGEtZWM3NC00Y2VmLTgwMzQtYWRiYWQxNjhjZTMzIiwiYXBwaWRhY3IiOiIyIiwiZV9leHAiOjI2MjgwMCwiaWRwIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3LyIsIm9pZCI6ImY4NDYwMGM1LWE5ZDgtNDEyOS1hMTk5LWNjNDE4MDYwNzQxMSIsInN1YiI6ImY4NDYwMGM1LWE5ZDgtNDEyOS1hMTk5LWNjNDE4MDYwNzQxMSIsInRpZCI6IjcyZjk4OGJmLTg2ZjEtNDFhZi05MWFiLTJkN2NkMDExZGI0NyIsInZlciI6IjEuMCJ9.TjnKtpTJ_dvQc3GQO9QSA0Sm9MISNakF8IT9-abzkaWqmwruhB2Tls9QTHe-P_xp09Jrt6JPhC8Z5mTTWgKqV_LV-KbJe_NmlYMTU_X5AcaPIQoi2ctSv62-wnnl-2IQjEEkyX7Vc0ixnPdWOG5LCO4ctTmURRO-tWN_jIK5up-wb0-ks1STFSBGJZtJ0xNTdTb9SSG4HpHzbLdkEmg-oAvOBX2OmwaNbBsU3chi4G5MoLtm5oXvL36z9vsf2bN_H7Sg-mss1Ua7OOwFVPMrx0rrIqXzKYQUSvNFAHLebKcp2SccpYWrgp7lKQGrbQhJsYYkzl-R-NTB5fUPUB7B3Q\",\"expires_on\":\"04/15/2017 3:26:01 PM +00:00\",\"resource\":\"https://vault.azure.net\",\"token_type\":\"Bearer\"}";
        }

        /// <summary>
        ///  The response has claims as expected from Azure VM MSI response
        /// </summary>
        /// <returns></returns>
        internal static string GetMsiAzureVmTokenResponse()
        {
            return
                "{\"access_token\":\"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImEzUU4wQlpTN3M0bk4tQmRyamJGMFlfTGRNTSIsImtpZCI6ImEzUU4wQlpTN3M0bk4tQmRyamJGMFlfTGRNTSJ9.eyJhdWQiOiJodHRwczovL3ZhdWx0LmF6dXJlLm5ldCIsImlzcyI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0LzcyZjk4OGJmLTg2ZjEtNDFhZi05MWFiLTJkN2NkMDExZGI0Ny8iLCJpYXQiOjE0OTIyNjYwNjEsIm5iZiI6MTQ5MjI2NjA2MSwiZXhwIjoxNDkyMjY5OTYxLCJhaW8iOiJZMlpnWUNoTk91Yy9ZKzJMOVM3Ty8yWTBDL2lhQUFBPSIsImFwcGlkIjoiZjBiMWY4NGEtZWM3NC00Y2VmLTgwMzQtYWRiYWQxNjhjZTMzIiwiYXBwaWRhY3IiOiIyIiwiZV9leHAiOjI2MjgwMCwiaWRwIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3LyIsIm9pZCI6ImY4NDYwMGM1LWE5ZDgtNDEyOS1hMTk5LWNjNDE4MDYwNzQxMSIsInN1YiI6ImY4NDYwMGM1LWE5ZDgtNDEyOS1hMTk5LWNjNDE4MDYwNzQxMSIsInRpZCI6IjcyZjk4OGJmLTg2ZjEtNDFhZi05MWFiLTJkN2NkMDExZGI0NyIsInZlciI6IjEuMCJ9.TjnKtpTJ_dvQc3GQO9QSA0Sm9MISNakF8IT9-abzkaWqmwruhB2Tls9QTHe-P_xp09Jrt6JPhC8Z5mTTWgKqV_LV-KbJe_NmlYMTU_X5AcaPIQoi2ctSv62-wnnl-2IQjEEkyX7Vc0ixnPdWOG5LCO4ctTmURRO-tWN_jIK5up-wb0-ks1STFSBGJZtJ0xNTdTb9SSG4HpHzbLdkEmg-oAvOBX2OmwaNbBsU3chi4G5MoLtm5oXvL36z9vsf2bN_H7Sg-mss1Ua7OOwFVPMrx0rrIqXzKYQUSvNFAHLebKcp2SccpYWrgp7lKQGrbQhJsYYkzl-R-NTB5fUPUB7B3Q\",\"refresh_token\":\"\",\"expires_in\":\"3600\",\"expires_on\":\"1492269961\",\"not_before\":\"1492266061\",\"resource\":\"https://vault.azure.net\",\"token_type\":\"Bearer\"}";
        }

        /// <summary>
        ///  The response has claims as expected from MSI response with user-assigned managed identity
        /// </summary>
        /// <returns></returns>
        internal static string GetManagedIdentityTokenResponse()
        {
            return
                "{\"access_token\":\"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjdfWnVmMXR2a3dMeFlhSFMzcTZsVWpVWUlHdyIsImtpZCI6IjdfWnVmMXR2a3dMeFlhSFMzcTZsVWpVWUlHdyJ9.eyJhdWQiOiJodHRwczovL3ZhdWx0LmF6dXJlLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83MmY5ODhiZi04NmYxLTQxYWYtOTFhYi0yZDdjZDAxMWRiNDcvIiwiaWF0IjoxNTM2MDkxMTk1LCJuYmYiOjE1MzYwOTExOTUsImV4cCI6MTUzNjEyMDI5NSwiYWlvIjoiNDJCZ1lJaW8zK3N1cE1XOVcrZWd4UGZNK3pFbUFBPT0iLCJhcHBpZCI6Ijk0MjM0M2IxLTRhZjItNDkwYy1iNmQ5LTkyNTBiOGYyODA4YyIsImFwcGlkYWNyIjoiMiIsImVfZXhwIjoyODgwMDAsImlkcCI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0LzcyZjk4OGJmLTg2ZjEtNDFhZi05MWFiLTJkN2NkMDExZGI0Ny8iLCJvaWQiOiJiMzllNTZiZS1jZThiLTQyYjAtYjY3ZS0xYWI5YmU4ODUxZmQiLCJzdWIiOiJiMzllNTZiZS1jZThiLTQyYjAtYjY3ZS0xYWI5YmU4ODUxZmQiLCJ0aWQiOiI3MmY5ODhiZi04NmYxLTQxYWYtOTFhYi0yZDdjZDAxMWRiNDciLCJ1dGkiOiJtcVk3QnJfOENVS3hnd1JteW11RkFBIiwidmVyIjoiMS4wIiwieG1zX21pcmlkIjoiL3N1YnNjcmlwdGlvbnMvYmRkNzg5ZjMtZDlkMS00YmVhLWFjMTQtMzBhMzllZDY2ZDMzL3Jlc291cmNlZ3JvdXBzL3Rlc3RiZWQvcHJvdmlkZXJzL01pY3Jvc29mdC5NYW5hZ2VkSWRlbnRpdHkvdXNlckFzc2lnbmVkSWRlbnRpdGllcy9UZXN0QmVkTWFuYWdlZElkZW50aXR5In0.ic31ZbWlTJ72DLGDmwbuPQJi1Lw_pw7UdBUauXD9MpDznSts2j3GXpa9mldiEeTeUAKtygt2ncnjStUaIlxfh94wxT37V5NElEwE2yVjY1mD1yRkTN9MIB8QQijkzNgzKms6y-zWn0i7oLCV6fdOZInrSLB9zd_X4AJI4LAGLvpzzt7cemNYRtNH4OJa3tTQP6vxh5wLY_gVlfSnOe1zX2RCXcOX3SC4YgOdo-L0n9w4iMV4HrQo6sfN5F5Rtaqi4MlwsuNuMiPZO0S8B73Qy3SFMQD3P2j_u47c5TI-PBa69ORqIEtbdg9FUIjY1_dBKgruJCXSm9tA0WvX-P0u5A\",\"client_id\":\"942343b1-4af2-490c-b6d9-9250b8f2808c\",\"expires_in\":\"28799\",\"expires_on\":\"1536120295\",\"ext_expires_in\":\"288000\",\"not_before\":\"1536091195\",\"resource\":\"https://vault.azure.net/\",\"token_type\":\"Bearer\"}";
        }

        /// <summary>
        ///  The response from MSI missing token
        /// </summary>
        /// <returns></returns>
        internal static string GetMsiMissingTokenResponse()
        {
            return
                "{\"refresh_token\":\"\",\"expires_in\":\"3600\",\"expires_on\":\"1492269961\",\"not_before\":\"1492266061\",\"resource\":\"https://vault.azure.net\",\"token_type\":\"Bearer\"}";
        }

        /// <summary>
        ///  The response has claims as expected from MSI response with invalid json
        /// </summary>
        /// <returns></returns>
        internal static string GetInvalidMsiTokenResponse()
        {
            return
                "{\"access_token\":\"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImEzUU4wQlpTN3M0bk4tQmRyamJGMFlfTGRNTSIsImtpZCI6ImEzUU4wQlpTN3M0bk4tQmRyamJGMFlfTGRNTSJ9.eyJhdWQiOiJodHRwczovL3ZhdWx0LmF6dXJlLm5ldCIsImlzcyI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0LzcyZjk4OGJmLTg2ZjEtNDFhZi05MWFiLTJkN2NkMDExZGI0Ny8iLCJpYXQiOjE0OTIyNjYwNjEsIm5iZiI6MTQ5MjI2NjA2MSwiZXhwIjoxNDkyMjY5OTYxLCJhaW8iOiJZMlpnWUNoTk91Yy9ZKzJMOVM3Ty8yWTBDL2lhQUFBPSIsImFwcGlkIjoiZjBiMWY4NGEtZWM3NC00Y2VmLTgwMzQtYWRiYWQxNjhjZTMzIiwiYXBwaWRhY3IiOiIyIiwiZV9leHAiOjI2MjgwMCwiaWRwIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3LyIsIm9pZCI6ImY4NDYwMGM1LWE5ZDgtNDEyOS1hMTk5LWNjNDE4MDYwNzQxMSIsInN1YiI6ImY4NDYwMGM1LWE5ZDgtNDEyOS1hMTk5LWNjNDE4MDYwNzQxMSIsInRpZCI6IjcyZjk4OGJmLTg2ZjEtNDFhZi05MWFiLTJkN2NkMDExZGI0NyIsInZlciI6IjEuMCJ9.TjnKtpTJ_dvQc3GQO9QSA0Sm9MISNakF8IT9-abzkaWqmwruhB2Tls9QTHe-P_xp09Jrt6JPhC8Z5mTTWgKqV_LV-KbJe_NmlYMTU_X5AcaPIQoi2ctSv62-wnnl-2IQjEEkyX7Vc0ixnPdWOG5LCO4ctTmURRO-tWN_jIK5up-wb0-ks1STFSBGJZtJ0xNTdTb9SSG4HpHzbLdkEmg-oAvOBX2OmwaNbBsU3chi4G5MoLtm5oXvL36z9vsf2bN_H7Sg-mss1Ua7OOwFVPMrx0rrIqXzKYQUSvNFAHLebKcp2SccpYWrgp7lKQGrbQhJsYYkzl-R-NTB5fUPUB7B3Q\",\"refresh_token\"\"\",\"expires_in\":\"3600\",\"expires_on\":\"1492269961\",\"not_before\":\"1492266061\",\"resource\":\"https://vault.azure.net\",\"token_type\":\"Bearer\"";
        }

        /// <summary>
        ///  The response has claims as expected from Client Credentials flow response. 
        /// </summary>
        /// <returns></returns>
        internal static string GetAppToken()
        {
            return
                "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IlZXVkljMVdEMVRrc2JiMzAxc2FzTTVrT3E1USIsImtpZCI6IlZXVkljMVdEMVRrc2JiMzAxc2FzTTVrT3E1USJ9.eyJhdWQiOiJodHRwczovL2RhdGFiYXNlLndpbmRvd3MubmV0LyIsImlzcyI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0LzcyZjk4OGJmLTg2ZjEtNDFhZi05MWFiLTJkN2NkMDExZGI0Ny8iLCJpYXQiOjE1MDMxOTAwNjAsIm5iZiI6MTUwMzE5MDA2MCwiZXhwIjoxNTAzMTkzOTYwLCJfY2xhaW1fbmFtZXMiOnsiZ3JvdXBzIjoic3JjMSJ9LCJfY2xhaW1fc291cmNlcyI6eyJzcmMxIjp7ImVuZHBvaW50IjoiaHR0cHM6Ly9ncmFwaC53aW5kb3dzLm5ldC83MmY5ODhiZi04NmYxLTQxYWYtOTFhYi0yZDdjZDAxMWRiNDcvdXNlcnMvOWNlYjQ0YWYtNDQzNy00Y2NjLWE0OWEtOWE5YmRlMDY3NTJlL2dldE1lbWJlck9iamVjdHMifX0sImFjciI6IjEiLCJhaW8iOiJZMkZnWUxEZVZPZDh6Lzlydy8vM3M4N1plREdYM1NxL21odnBJaDZsdTlqbnlQU0d2bE1BIiwiYW1yIjpbIndpYSIsIm1mYSJdLCJhcHBpZCI6IjA0YjA3Nzk1LThkZGItNDYxYS1iYmVlLTAyZjllMWJmN2I0NiIsImFwcGlkYWNyIjoiMCIsImVfZXhwIjoyNjI4MDAsImZhbWlseV9uYW1lIjoiU2hhcm1hIiwiZ2l2ZW5fbmFtZSI6IlZhcnVuIiwiaW5fY29ycCI6InRydWUiLCJpcGFkZHIiOiIxNjcuMjIwLjAuMjExIiwibmFtZSI6IlZhcnVuIFNoYXJtYSIsIm9pZCI6IjljZWI0NGFmLTQ0MzctNGNjYy1hNDlhLTlhOWJkZTA2NzUyZSIsIm9ucHJlbV9zaWQiOiJTLTEtNS0yMS0yMTI3NTIxMTg0LTE2MDQwMTI5MjAtMTg4NzkyNzUyNy0xODMzNjYyMSIsInB1aWQiOiIxMDAzM0ZGRjgwMUI5MTg4Iiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoiX1ZCcElTQWVJX0tVQVR2T3Zfd0Vic3ZRNWJWY1BEUi1IbkU1QVJrM29tRSIsInRpZCI6IjcyZjk4OGJmLTg2ZjEtNDFhZi05MWFiLTJkN2NkMDExZGI0NyIsInVuaXF1ZV9uYW1lIjoidmFydW5zaEBtaWNyb3NvZnQuY29tIiwidXBuIjoidmFydW5zaEBtaWNyb3NvZnQuY29tIiwidmVyIjoiMS4wIn0.gGo1wCH2k8kqt6JUdjBMavZX9Sq2L_tKLvVDPUJv3NurZT5JGYyS7gJ11RMrVaxyG48dnlWat1vEBcB-YLOkpL-2gR_sSAoAStPuz8yXAFHxluw-WOqiWxlm2leENqwMmCrMYinm8ohkrScpfRFm6-4fzgczdhNi0vjkTHaycYnrPrH9cZHSL9Qyzt6MH6pEyGct4zmgASI1Vlrga5_x_x8xj-FscIRYorrvx61fThaor8M4FjzglNgum4j5yecn1pIcp75CK43xb7e4jdsfL2nl6wgn5mZj_59b_aKNa3_VA-NmZTlxjvjlL_AHdDkYPlku_B75-0EbfKN2IR5eLw";
        }

        /// <summary>
        ///  Invalid AppToken. 
        /// </summary>
        /// <returns></returns>
        internal static string GetInvalidAppToken()
        {
            return
                "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IlZXVkljMVdEMVRrc2JiMzAxc2FzTTVrT3E1USIsImtpZCI6IlZXVkljMVdEMVRrc2JiMzAxc2FzTTVrT3E1USJ9";
        }
    }
}
