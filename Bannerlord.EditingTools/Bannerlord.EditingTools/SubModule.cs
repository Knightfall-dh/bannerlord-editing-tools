using Bannerlord.UIExtenderEx;
using TaleWorlds.MountAndBlade;


namespace Bannerlord.EditingTools {
	public class BannerlordEditingTools : MBSubModuleBase {
		private UIExtender _extender;
		protected override void OnSubModuleLoad() {
			base.OnSubModuleLoad();
			_extender = new UIExtender("Bannerlord.EditingTools");
			_extender.Register(typeof(BannerlordEditingTools).Assembly);
			_extender.Enable();
		}
	}
}