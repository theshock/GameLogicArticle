namespace GameLogic.Architecture
{
	public class Module
	{
		public readonly ModuleConfig Config;
		public readonly ModuleType Type;
		public readonly Progression Constructible;
		public readonly Progression Cycle;

		public Module (ModuleConfig config)
		{
			Type = config.Type;
			Config = config;
			Constructible = new Progression(config.ConstructionTime);
			Cycle = new Progression(config.CycleTime);
		}
	}

}
