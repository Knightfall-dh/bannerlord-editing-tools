using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Bannerlord.EditingTools.Utilities.Extensions {
	public static class XmlExtension {
		public static string SerializeObject<T>(this T toSerialize) {
			XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
			using (StringWriter textWriter = new StringWriter()) {
				xmlSerializer.Serialize(textWriter, toSerialize);
				return textWriter.ToString();
			}
		}

		public static T DeserializeObject<T>(this String toSerialize, String rootElementName) {
			T deserializedObject;
			XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootElementName));
			using (StringReader reader = new StringReader(toSerialize)) {
				deserializedObject = (T)serializer.Deserialize(reader);
			}

			return deserializedObject;
		}
	}
}
