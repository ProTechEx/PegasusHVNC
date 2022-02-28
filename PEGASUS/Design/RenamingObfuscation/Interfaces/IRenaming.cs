using dnlib.DotNet;

namespace PEGASUS.Design.RenamingObfuscation.Interfaces
{
	public interface IRenaming
	{
		ModuleDefMD Rename(ModuleDefMD module);
	}
}
