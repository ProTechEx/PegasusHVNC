using dnlib.DotNet;
using PEGASUS.Design.RenamingObfuscation.Interfaces;

namespace PEGASUS.Design.RenamingObfuscation.Classes
{
	public class PropertiesRenaming : IRenaming
	{
		public ModuleDefMD Rename(ModuleDefMD module)
		{
			foreach (TypeDef type in module.GetTypes())
			{
				if (type.IsGlobalModuleType)
				{
					continue;
				}
				foreach (PropertyDef property in type.Properties)
				{
					property.Name = Utils.GenerateRandomString();
				}
			}
			return module;
		}
	}
}
