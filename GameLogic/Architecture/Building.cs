using System;
using System.Collections.Generic;

namespace GameLogic.Architecture
{
	public class Building
	{
		// Ограничим количество модулей, которые можно поставить в строение
		public readonly int ModulesLimit;

		public readonly BuildingConfig Config;
		public readonly BuildingType Type;
		public readonly Progression Constructible;

		// Каждый модуль может иметь свою сообтвенную позицию
		private readonly Dictionary<int, Module> modules = new Dictionary<int, Module>();

		public IEnumerable<Module> Modules {
			get { return modules.Values; }
		}

		public Building (BuildingConfig config)
		{
			Type = config.Type;
			ModulesLimit = config.ModulesLimit;
			Config = config;
			Constructible = new Progression(config.ConstructionTime);
		}

		public Module GetModule (int position)
		{
			return modules.ContainsKey(position)
				? modules[position]
				: null;
		}

		public void SetModule (int position, Module module)
		{
			if (position < 0 || position >= ModulesLimit) {
				throw new IndexOutOfRangeException(
					"Position " + position + " is out of range [0:" + ModulesLimit + "]"
				);
			}

			modules[position] = module;
		}
	}
}
