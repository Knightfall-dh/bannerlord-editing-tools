using Bannerlord.UIExtenderEx.Attributes;
using Bannerlord.UIExtenderEx.Prefabs2;
using System.Collections.Generic;
using System.Xml;

namespace Bannerlord.EditingTools.UIPrefabExtensions
{
    [PrefabExtension("Inventory", "//Widget[@Id=\"RightEquipmentList\"]/Children", "Inventory")]
    internal class CopyEquipmentRoster : PrefabExtensionInsertPatch
    {
        private readonly List<XmlNode> nodes;
        public CopyEquipmentRoster()
        {
            var doc = new XmlDocument();
            doc.LoadXml(@"
<ButtonWidget Id=""CopyRosterButton"" Command.Click=""CopyEquipmentRosterToClipboard"" DoNotPassEventsToChildren=""true""
              WidthSizePolicy=""Fixed"" HeightSizePolicy=""Fixed"" SuggestedWidth=""100"" SuggestedHeight=""45""
              HorizontalAlignment=""Right"" VerticalAlignment=""Top"" MarginRight=""120"" MarginTop=""750"" Brush=""Header.Tab.Center"">
  <Children>
    <TextWidget WidthSizePolicy=""CoverChildren"" HeightSizePolicy=""CoverChildren"" HorizontalAlignment=""Center"" VerticalAlignment=""Center""
                Brush=""Clan.TabControl.Text"" Text=""Roster"" />
  </Children>
</ButtonWidget>");
            nodes = new List<XmlNode> { doc };
        }

        public override InsertType Type => InsertType.Child;
        public override int Index => 2;
        [PrefabExtensionXmlNodes] public IEnumerable<XmlNode> Nodes => nodes;
    }
}
