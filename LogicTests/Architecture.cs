using System.Linq;
using GameLogic;
using GameLogic.Architecture;
using GameLogic.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTests
{
	[TestClass]
	public class Architecture
	{
		[TestMethod]
		public void CorrectConstruction ()
		{
			var core = new Core();
			var room = core.Ship.GetRoom(0);

			Assert.AreEqual(BuildingType.Empty, room.Building.Type);
			Assert.AreEqual(0, room.Building.Modules.Count());

			Assert.IsTrue(
				new BuildingConstruct(
					room,
					core.Factory.ProduceBuilding(BuildingType.PowerPlant)
				)
				.Execute(core)
				.IsValid
			);

			Assert.AreEqual(BuildingType.PowerPlant, room.Building.Type);
			Assert.AreEqual(0, room.Building.Modules.Count());

			Assert.IsTrue(
				new ModuleConstruct(
					room.Building,
					core.Factory.ProduceModule(ModuleType.Generator),
					2
				)
				.Execute(core)
				.IsValid
			);

			Assert.AreEqual(BuildingType.PowerPlant, room.Building.Type);
			Assert.AreEqual(ModuleType.Generator, room.Building.GetModule(2).Type);
			Assert.AreEqual(1, room.Building.Modules.Count());
		}

		[TestMethod]
		public void IncorrectConstruction ()
		{
			var core = new Core();
			var room = core.Ship.GetRoom(0);

			Assert.IsFalse(
				new BuildingConstruct(
					room,
					core.Factory.ProduceBuilding(BuildingType.Empty)
				)
				.Execute(core)
				.IsValid
			);

			Assert.IsFalse(
				new ModuleConstruct(
					room.Building,
					core.Factory.ProduceModule(ModuleType.Generator),
					2
				)
				.Execute(core)
				.IsValid
			);

			new BuildingConstruct(
				room,
				core.Factory.ProduceBuilding(BuildingType.PowerPlant)
			)
			.Execute(core);

			Assert.IsFalse(
				new BuildingConstruct(
					room,
					core.Factory.ProduceBuilding(BuildingType.PowerPlant)
				)
				.Execute(core)
				.IsValid
			);

			Assert.IsFalse(
				new ModuleConstruct(
					room.Building,
					core.Factory.ProduceModule(ModuleType.Generator),
					666
				)
				.Execute(core)
				.IsValid
			);
		}


		[TestMethod]
		public void CantConstructInWrongBuilding ()
		{
			var core = new GameLogic.Core();
			var room = core.Ship.GetRoom(0);

			new BuildingConstruct(
				room,
				core.Factory.ProduceBuilding(BuildingType.PowerPlant)
			)
			.Execute(core);

			Assert.IsFalse(
				new ModuleConstruct(
					room.Building,
					core.Factory.ProduceModule(ModuleType.Furnace),
					2
				)
				.Execute(core)
				.IsValid
			);

			Assert.AreEqual(null, room.Building.GetModule(2));
		}


		[TestMethod]
		public void ModulesLimits ()
		{
			var core = new GameLogic.Core();
			var roomRoboport = core.Ship.GetRoom(0);
			var roomPowerPlant = core.Ship.GetRoom(1);


			Assert.IsTrue(
				new BuildingConstruct(
					roomRoboport,
					core.Factory.ProduceBuilding(BuildingType.Roboport)
				)
				.Execute(core)
				.IsValid
			);

			Assert.IsTrue(
				new BuildingConstruct(
					roomPowerPlant,
					core.Factory.ProduceBuilding(BuildingType.PowerPlant)
				)
				.Execute(core)
				.IsValid
			);

			Assert.IsFalse(
				new ModuleConstruct(
					roomRoboport.Building,
					core.Factory.ProduceModule(ModuleType.Miner),
					3
				)
				.Execute(core)
				.IsValid
			);

			Assert.IsTrue(
				new ModuleConstruct(
					roomPowerPlant.Building,
					core.Factory.ProduceModule(ModuleType.Generator),
					3
				)
				.Execute(core)
				.IsValid
			);
		}
	}
}
