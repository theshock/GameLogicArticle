using System;
using System.Collections.Generic;

namespace GameLogic.Architecture
{
	public class Factory
	{
		private readonly Dictionary<BuildingType, BuildingConfig> buildings = new Dictionary<BuildingType, BuildingConfig>() {
			{ BuildingType.Empty, new BuildingConfig() {
				Type = BuildingType.Empty
			}},
			{ BuildingType.PowerPlant, new BuildingConfig() {
				Type = BuildingType.PowerPlant,
				ModulesLimit = 5,
				AvailableModules = new[]{ ModuleType.Generator }
			}},
			{ BuildingType.Smeltery, new BuildingConfig() {
				Type = BuildingType.Smeltery,
				ModulesLimit = 4,
				AvailableModules = new[]{ ModuleType.Furnace }
			}},
			{ BuildingType.Roboport, new BuildingConfig() {
				Type = BuildingType.Roboport,
				ModulesLimit = 3,
				AvailableModules = new[]{
					ModuleType.Digger,
					ModuleType.Miner
				}
			}}
		};

		private readonly Dictionary<ModuleType, ModuleConfig> modules = new Dictionary<ModuleType, ModuleConfig>() {
			{ ModuleType.Generator, new ModuleConfig() {
				Type = ModuleType.Generator
			}},
			{ ModuleType.Furnace, new ModuleConfig() {
				Type = ModuleType.Furnace
			}},
			{ ModuleType.Digger, new ModuleConfig() {
				Type = ModuleType.Digger
			}},
			{ ModuleType.Miner, new ModuleConfig() {
				Type = ModuleType.Miner
			}}
		};

		public Building ProduceBuilding (BuildingType type)
		{
			if (!buildings.ContainsKey(type)) {
				throw new ArgumentException("Unknown building type: " + type);
			}

			return new Building(buildings[type]);
		}
		public Module ProduceModule (ModuleType type)
		{
			if (!modules.ContainsKey(type)) {
				throw new ArgumentException("Unknown module type: " + type);
			}

			return new Module(modules[type]);
		}
	}

}
