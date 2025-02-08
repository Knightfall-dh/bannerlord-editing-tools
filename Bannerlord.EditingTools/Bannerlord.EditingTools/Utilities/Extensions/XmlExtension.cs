using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Bannerlord.EditingTools.Utilities.Extensions {
	public static class XmlExtension {
		public static string SerializeObject<T>(this T objectToSerialize, Boolean omitXmlDeclaration, Boolean suppressNamespaces) {
			if(objectToSerialize == null) 
				throw new ArgumentNullException(nameof(objectToSerialize));

			XmlSerializer xmlSerializer = new XmlSerializer(objectToSerialize.GetType());

			XmlWriterSettings settings = new XmlWriterSettings {
				Indent = true,
				OmitXmlDeclaration = omitXmlDeclaration,
				NamespaceHandling = NamespaceHandling.OmitDuplicates
			};

			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
			if(suppressNamespaces)
				ns.Add("", "");

			StringBuilder outputXml = new StringBuilder();
			using (XmlWriter writer = XmlWriter.Create(outputXml, settings)) {
				xmlSerializer.Serialize(writer, objectToSerialize, ns);
			}

			return outputXml.ToString();
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
