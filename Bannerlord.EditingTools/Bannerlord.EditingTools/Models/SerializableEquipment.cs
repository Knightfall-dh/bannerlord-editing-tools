using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using TaleWorlds.Core;

namespace Bannerlord.EditingTools.Models {
	public class SerializableEquipment {
		[XmlAttribute("slot")]
		public string Slot { get; set; }

		[XmlAttribute("id")]
		public string Id { get; set; }

		public SerializableEquipment(string slot, string id) {
			Slot = slot;
			Id = id;
		}

		public SerializableEquipment() { }
	}
}
