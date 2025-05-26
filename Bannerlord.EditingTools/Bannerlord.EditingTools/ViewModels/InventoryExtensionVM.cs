using Bannerlord.EditingTools.Models;
using Bannerlord.EditingTools.Utilities;
using Bannerlord.EditingTools.Utilities.Extensions;
using Bannerlord.UIExtenderEx.Attributes;
using Bannerlord.UIExtenderEx.ViewModels;
using SandBox.GauntletUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Inventory;
using TaleWorlds.CampaignSystem.ViewModelCollection.Inventory;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;
using TaleWorlds.ScreenSystem;

namespace Bannerlord.EditingTools.ViewModels {
	[ViewModelMixin]
	internal class InventoryExtensionVM : BaseViewModelMixin<SPInventoryVM> {
		private SPInventoryVM _inventoryVM;
        private InventoryLogic? _inventoryLogic;

        public InventoryExtensionVM(SPInventoryVM vm) : base(vm)
        {
            _inventoryVM = vm;
            var inventoryLogicField = ReflectionUtility.GetFieldValue(vm, "_inventoryLogic");

            if (inventoryLogicField != null)
            {
                _inventoryLogic = (InventoryLogic)inventoryLogicField;
            }
        }

        #region Copy Roster
        [DataSourceMethod]
        public void CopyEquipmentRosterToClipboard()
        {
            try
            {
                Input.SetClipboardText(XmlExtension.SerializeObject(
                    SerializableEquipmentRoster.FromEquipmentList(
                        _inventoryVM.IsInWarSet
                            ? _inventoryLogic.InitialEquipmentCharacter.BattleEquipments
                            : _inventoryLogic.InitialEquipmentCharacter.CivilianEquipments,
                        !_inventoryVM.IsInWarSet
                    ),
                    true,
                    true));
            }
            catch (Exception ex)
            {
                InformationManager.DisplayMessage(new InformationMessage($"Could not copy the equipment roster to clipboard. Error: {ex.Message}"));
            }
        }
        #endregion

        #region Copy Set
        [DataSourceMethod]
		public void CopyEquipmentSetToClipboard() {
			CopyAsEquipmentRoster();
		}
		private void CopyAsEquipmentRoster() {
			try {
				Input.SetClipboardText(XmlExtension.SerializeObject(
					SerializableEquipmentSet.FromEquipmentList(_inventoryVM.IsInWarSet
                                                                            ? _inventoryLogic!.InitialEquipmentCharacter.BattleEquipments
                                                                            : _inventoryLogic!.InitialEquipmentCharacter.CivilianEquipments,
																!_inventoryVM.IsInWarSet),
					true,
					true));
			}
			catch(Exception ex) {
				InformationManager.DisplayMessage(new InformationMessage($"Could not copy the equipment set to clipboard. Error: {ex.Message}"));
			}
		}
        #endregion

        #region Import Set
        [DataSourceMethod]
        public void ImportEquipmentSetFromClipboard()
        {
            try
            {
                var clipboardText = Input.GetClipboardText();

                Equipment equipment;

                if (clipboardText.Contains("<EquipmentRoster"))
                {
                    var deserializedRoster = XmlExtension.DeserializeObject<SerializableEquipmentRoster>(clipboardText, "EquipmentRoster");
                    equipment = SerializableEquipmentRoster.ToEquipment(deserializedRoster);
                }
                else if (clipboardText.Contains("<EquipmentSet"))
                {
                    var deserializedSet = XmlExtension.DeserializeObject<SerializableEquipmentSet>(clipboardText, "EquipmentSet");
                    equipment = SerializableEquipmentSet.ToEquipment(deserializedSet);
                }
                else
                {
                    throw new Exception("Unknown format. Expected <EquipmentRoster> or <EquipmentSet> as root element.");
                }

                Equipment setReference = _inventoryVM.IsInWarSet ? Hero.MainHero.BattleEquipment : Hero.MainHero.CivilianEquipment;
                setReference.FillFrom(equipment);

                InventoryManager.Instance.CloseInventoryPresentation(false);
                InventoryManager.OpenScreenAsInventory();
            }
            catch (Exception ex)
            {
                InformationManager.DisplayMessage(new InformationMessage($"Could not import from clipboard. Error: {ex.Message}"));
            }
        }
        #endregion
    }
}
