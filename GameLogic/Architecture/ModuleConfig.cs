using System.Collections.Generic;
using GameLogic.Player;

namespace GameLogic.Architecture
{
	public class ModuleConfig
	{
		public ModuleType Type;
		public int ConstructionTime;
		public Dictionary<ResourceType, int> ConstructionCost;
	}
}
