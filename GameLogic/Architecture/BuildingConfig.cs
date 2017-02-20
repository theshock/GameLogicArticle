using System.Collections.Generic;
using GameLogic.Player;

namespace GameLogic.Architecture
{
	public class BuildingConfig
	{
		public BuildingType Type;
		public int ModulesLimit;
		public ModuleType[] AvailableModules;
		public int ConstructionTime;
		public Dictionary<ResourceType, int> ConstructionCost;
	}
}
