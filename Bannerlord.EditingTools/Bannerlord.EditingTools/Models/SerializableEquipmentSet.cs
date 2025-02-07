using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;
using TaleWorlds.ObjectSystem;
using static TaleWorlds.Core.Equipment;

namespace Bannerlord.EditingTools.Models {
	[XmlRoot("EquipmentRoster")]
	public class SerializableEquipmentSet {
		[NonSerialized]
		public static string[] EquipmentSlot = new string[]
		{
			"Item0",
			"Item1",
			"Item2",
			"Item3",
			"Item4",
			"Head",
			"Body",
			"Leg",
			"Gloves",
			"Cape",
			"Horse",
			"HorseHarness"
		};

		[XmlElement("equipment")]
		public List<SerializableEquipment> Equipment { get; set; } = new List<SerializableEquipment>();

		public SerializableEquipmentSet() { }

		public static Equipment ToEquipment(SerializableEquipmentSet equipmentSet) { 
			Equipment equipment = new Equipment(false);

			foreach (var item in equipmentSet.Equipment) {
				var itemStringId = item.Id.Replace("Item.", "");
				var itemObject = MBObjectManager.Instance.GetObject<ItemObject>(itemStringId);
				var equipmentElement = new EquipmentElement(itemObject);

				equipment[EquipmentSlot.IndexOf(item.Slot)] = equipmentElement;
			}

			return equipment;
		}
	}
}
