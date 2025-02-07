using Bannerlord.UIExtenderEx.Attributes;
using Bannerlord.UIExtenderEx.Prefabs2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Bannerlord.EditingTools.UIPrefabExtensions {
	[PrefabExtension("Inventory", "//Widget[@Id=\"RightEquipmentList\"]/Children", "Inventory")]
	internal class ImportEquipmentSet : PrefabExtensionInsertPatch {
		private readonly List<XmlNode> nodes;
		public ImportEquipmentSet() {
			var firstChild = new XmlDocument();
			firstChild.LoadXml(
				@"<ButtonWidget Id=""ImportEquipmentButton"" Command.Click=""ImportEquipmentSetFromClipboard"" DoNotPassEventsToChildren=""true"" WidthSizePolicy=""Fixed"" HeightSizePolicy=""Fixed"" SuggestedWidth=""120"" SuggestedHeight=""42"" HorizontalAlignment=""Right"" VerticalAlignment=""Top"" MarginRight=""120"" MarginTop=""770"" Brush=""Header.Tab.Center"">
                          <Children>
                            <TextWidget WidthSizePolicy=""CoverChildren"" HeightSizePolicy=""CoverChildren"" HorizontalAlignment=""Center"" VerticalAlignment=""Center"" Brush=""Clan.TabControl.Text"" Text=""Import Set"" />
                          </Children>
                        </ButtonWidget>");
			nodes = new List<XmlNode> { firstChild };
		}

		public override InsertType Type => InsertType.Child;
		public override int Index => 1;

		[PrefabExtensionXmlNodes] public IEnumerable<XmlNode> Nodes => nodes;
	}
}
