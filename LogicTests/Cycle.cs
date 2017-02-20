using System.Collections.Generic;
using GameLogic;
using GameLogic.Architecture;
using GameLogic.Commands;
using GameLogic.Player;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTests
{
	[TestClass]
	public class Cycle
	{
		[TestMethod]
		public void CheckCycle ()
		{
			var buildingConfig = new BuildingConfig() {
				Type = BuildingType.Smeltery,
				ModulesLimit = 1,
				AvailableModules = new[] { ModuleType.Furnace }
			};

			var moduleConfig = new ModuleConfig() {
				Type = ModuleType.Furnace,

				ConstructionTime = 2,
				ConstructionCost = new Dictionary<ResourceType, int>() {
				{ ResourceType.Metal, 10 }
			},

				CycleTime = 4,
				CycleInput = new Dictionary<ResourceType, int>() {
				{ ResourceType.Ore, 10 },
				{ ResourceType.Energy, 5 }
			},
				CycleOutput = new Dictionary<ResourceType, int>() {
				{ ResourceType.Metal, 1 }
			}
			};

			var core = new Core();
			core.Bank.Change(ResourceType.Metal, 10);
			core.Bank.Change(ResourceType.Ore, 80);
			core.Bank.Change(ResourceType.Energy, 10);

			var building = new Building(buildingConfig);
			core.Ship.GetRoom(0).Building = building;

			var module = new Module(moduleConfig);

			Assert.IsTrue(
				new ModuleConstruct(building, module, 0)
					.Execute(core)
					.IsValid
			);

			new NextTurn().Execute(core);

			Assert.IsFalse(module.Cycle.IsRunning);

			new NextTurn().Execute(core);

			Assert.IsTrue(module.Constructible.IsReady);
			Assert.IsFalse(module.Cycle.IsRunning);

			new NextTurn().Execute(core);
			Assert.IsTrue(module.Cycle.IsRunning);
			Assert.AreEqual(1, module.Cycle.Progress);

			Assert.AreEqual(70, core.Bank.Get(ResourceType.Ore));
			Assert.AreEqual(5, core.Bank.Get(ResourceType.Energy));
			Assert.AreEqual(0, core.Bank.Get(ResourceType.Metal));

			new NextTurnCount(3).Execute(core);
			Assert.IsFalse(module.Cycle.IsRunning);

			Assert.AreEqual(70, core.Bank.Get(ResourceType.Ore));
			Assert.AreEqual(5, core.Bank.Get(ResourceType.Energy));
			Assert.AreEqual(1, core.Bank.Get(ResourceType.Metal));

			new NextTurn().Execute(core);
			Assert.IsTrue(module.Cycle.IsRunning);

			Assert.AreEqual(60, core.Bank.Get(ResourceType.Ore));
			Assert.AreEqual(0, core.Bank.Get(ResourceType.Energy));
			Assert.AreEqual(1, core.Bank.Get(ResourceType.Metal));

			new NextTurnCount(3).Execute(core);
			Assert.IsFalse(module.Cycle.IsRunning);

			Assert.AreEqual(2, core.Bank.Get(ResourceType.Metal));

			new NextTurn().Execute(core); // Cant launch because of Energy leak
			Assert.IsFalse(module.Cycle.IsRunning);
			Assert.AreEqual(60, core.Bank.Get(ResourceType.Ore));
			Assert.AreEqual(0, core.Bank.Get(ResourceType.Energy));

		}
	}

}
