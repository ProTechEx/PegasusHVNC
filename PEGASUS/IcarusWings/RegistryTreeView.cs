using System.Windows.Forms;

namespace PEGASUS.IcarusWings
{
	public class RegistryTreeView : TreeView
	{
		public RegistryTreeView()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		}
	}
}
