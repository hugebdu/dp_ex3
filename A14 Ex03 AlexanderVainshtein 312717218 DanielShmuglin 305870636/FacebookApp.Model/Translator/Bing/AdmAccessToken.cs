using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Ex2.FacebookApp.Model.Translator
{
	[DataContract]
	public class AdmAccessToken
	{
		[DataMember]
		public string access_token { get; set; }
		[DataMember]
		public string token_type { get; set; }
		[DataMember]
		public string expires_in { get; set; }
		[DataMember]
		public string scope { get; set; }
	}
}
