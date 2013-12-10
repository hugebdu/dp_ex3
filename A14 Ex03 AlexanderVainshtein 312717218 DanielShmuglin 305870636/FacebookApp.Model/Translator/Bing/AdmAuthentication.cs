using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Web;

namespace Ex2.FacebookApp.Model.Translator
{
	/// <summary>
	/// http://msdn.microsoft.com/en-us/library/ff512437.aspx
	/// </summary>
	public class AdmAuthentication
	{
        private const int k_RefreshTokenDuration = 9;
        
        public const string DatamarketAccessUri = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";

		private string m_ClientId;
		private string m_ClientSecret;
		private string m_Request;
		private AdmAccessToken m_Token;
		private Timer m_AccessTokenRenewer;

		public AdmAuthentication(string i_ClientId, string i_ClientSecret)
		{
			this.m_ClientId = i_ClientId;
			this.m_ClientSecret = i_ClientSecret;

			// If clientid or client secret has special characters, encode before sending request
			this.m_Request = string.Format(
				"grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com", 
				HttpUtility.UrlEncode(i_ClientId), 
                HttpUtility.UrlEncode(i_ClientSecret));
			this.m_Token = httpPost(DatamarketAccessUri, this.m_Request);

			// renew the token every specfied minutes
			m_AccessTokenRenewer = new Timer(OnTokenExpiredCallback, this, TimeSpan.FromMinutes(k_RefreshTokenDuration), TimeSpan.FromMilliseconds(-1));
		}

		public AdmAccessToken GetAccessToken()
		{
			return this.m_Token;
		}

		private void RenewAccessToken()
		{
			// swap the new token with old one
			// Note: the swap is thread unsafe
			this.m_Token = httpPost(DatamarketAccessUri, this.m_Request); 
			Trace.WriteLine(string.Format("Renewed token for user: {0} is: {1}", this.m_ClientId, this.m_Token.access_token));
		}

		private void OnTokenExpiredCallback(object i_StateInfo)
		{
			try
			{
				RenewAccessToken();
			}
			catch (Exception ex)
			{
				Trace.WriteLine(string.Format("Failed renewing access token. Details: {0}", ex.Message));
			}
			finally
			{
				try
				{
					m_AccessTokenRenewer.Change(TimeSpan.FromMinutes(k_RefreshTokenDuration), TimeSpan.FromMilliseconds(-1));
				}
				catch (Exception ex)
				{
					Trace.WriteLine(string.Format("Failed to reschedule the timer to renew access token. Details: {0}", ex.Message));
				}
			}
		}

		private AdmAccessToken httpPost(string i_DatamarketAccessUri, string i_RequestDetails)
		{
			// Prepare OAuth request 
			var webRequest = WebRequest.Create(i_DatamarketAccessUri);
			webRequest.ContentType = "application/x-www-form-urlencoded";
			webRequest.Method = "POST";
			byte[] bytes = Encoding.ASCII.GetBytes(i_RequestDetails);
			webRequest.ContentLength = bytes.Length;

			using (var outputStream = webRequest.GetRequestStream())
			{
				outputStream.Write(bytes, 0, bytes.Length);
			}

			using (var webResponse = webRequest.GetResponse())
			{
				var serializer = new DataContractJsonSerializer(typeof(AdmAccessToken));

                // Get deserialized object from JSON stream
				return (AdmAccessToken)serializer.ReadObject(webResponse.GetResponseStream());
			}
		}
	}
}
