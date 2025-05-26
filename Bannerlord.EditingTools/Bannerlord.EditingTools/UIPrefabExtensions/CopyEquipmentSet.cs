using Bannerlord.UIExtenderEx.Attributes;
using Bannerlord.UIExtenderEx.Prefabs2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Bannerlord.EditingTools.UIPrefabExtensions {
	[PrefabExtension("Inventory", "//Widget[@Id=\"RightEquipmentList\"]/Children", "Inventory")]
	internal class CopyEquipmentSet : PrefabExtensionInsertPatch {
		private readonly List<XmlNode> nodes;
		public CopyEquipmentSet() {
			var firstChild = new XmlDocument();
			firstChild.LoadXml(
				@"<ButtonWidget Id=""CopyEquipmentButton"" Command.Click=""CopyEquipmentSetToClipboard"" DoNotPassEventsToChildren=""true"" WidthSizePolicy=""Fixed"" HeightSizePolicy=""Fixed"" SuggestedWidth=""100"" SuggestedHeight=""45"" HorizontalAlignment=""Right"" VerticalAlignment=""Top"" MarginRight=""120"" MarginTop=""700"" Brush=""Header.Tab.Center"">
                          <Children>
                            <TextWidget WidthSizePolicy=""CoverChildren"" HeightSizePolicy=""CoverChildren"" HorizontalAlignment=""Center"" VerticalAlignment=""Center"" Brush=""Clan.TabControl.Text"" Text=""Set"" />
                          </Children>
                        </ButtonWidget>");
			nodes = new List<XmlNode> { firstChild };
		}

		public override InsertType Type => InsertType.Child;
		public override int Index => 1;

		[PrefabExtensionXmlNodes] public IEnumerable<XmlNode> Nodes => nodes;
	}
}
