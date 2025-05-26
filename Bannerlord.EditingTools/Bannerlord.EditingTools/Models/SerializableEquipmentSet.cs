using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;
using TaleWorlds.ObjectSystem;
using static TaleWorlds.Core.Equipment;

namespace Bannerlord.EditingTools.Models
{
    [XmlRoot("EquipmentSet")]
    public class SerializableEquipmentSet
    {
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

        [XmlIgnore]
        public bool IsCivilian { get; set; }

        [XmlAttribute("civilian")]
        public string CivilianAttribute
        {
            get => IsCivilian ? "true" : null;
            set => IsCivilian = value == "true";
        }

        // This is the element name used in <EquipmentSet>
        [XmlElement("Equipment")]
        public List<SerializableEquipment> Equipment { get; set; } = new();

        public SerializableEquipmentSet() { }

        public static Equipment ToEquipment(SerializableEquipmentSet set)
        {
            Equipment equipment = new Equipment(false);

            foreach (var item in set.Equipment)
            {
                var itemStringId = item.Id.Replace("Item.", "");
                var itemObj = MBObjectManager.Instance.GetObject<ItemObject>(itemStringId);
                if (itemObj != null)
                {
                    var index = Array.IndexOf(EquipmentSlot, item.Slot);
                    if (index >= 0)
                        equipment[index] = new EquipmentElement(itemObj);
                }
            }

            return equipment;
        }

        public static SerializableEquipmentSet FromEquipmentList(IEnumerable<Equipment> list, bool isCivilian)
        {
            var result = new SerializableEquipmentSet();
            result.IsCivilian = isCivilian;

            foreach (var set in list)
            {
                for (int i = 0; i < EquipmentSlot.Length; i++)
                {
                    if (set[i].Item != null)
                    {
                        result.Equipment.Add(new SerializableEquipment(EquipmentSlot[i], $"Item.{set[i].Item.StringId}"));
                    }
                }
            }

            return result;
        }
    }
}
