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
	public class SerializableEquipmentRoster {
		[NonSerialized]
		public static string[] EquipmentSlot = new string[] {
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

		[XmlIgnore]
		public bool IsCivilian { get; set; }

		[XmlAttribute("civilian")]
		public string CivilianAttribute {
			get => IsCivilian ? "true" : null;
			set => IsCivilian = value == "true";
		}

		[XmlElement("equipment")]
		public List<SerializableEquipment> Equipment { get; set; } = new List<SerializableEquipment>();

		public SerializableEquipmentRoster() {}

		public static Equipment ToEquipment(SerializableEquipmentRoster roster) {
			var equipment = new Equipment(false);
			foreach (var item in roster.Equipment) {
				var itemStringId = item.Id.Replace("Item.", "");
				var itemObject = MBObjectManager.Instance.GetObject<ItemObject>(itemStringId);
				var element = new EquipmentElement(itemObject);
				equipment[EquipmentSlot.IndexOf(item.Slot)] = element;
			}
			return equipment;
		}

		public static SerializableEquipmentRoster FromEquipmentList(IEnumerable<Equipment> equipmentList, bool isCivilian) {
			var roster = new SerializableEquipmentRoster();
			roster.IsCivilian = isCivilian;
			foreach (var equipped in equipmentList) {
				for (int i = 0; i < EquipmentSlot.Length; i++) {
					if (equipped[i].Item != null) {
						roster.Equipment.Add(new SerializableEquipment(EquipmentSlot[i], $"Item.{equipped[i].Item.StringId}"));
					}
				}
			}
			return roster;
		}
	}
}
