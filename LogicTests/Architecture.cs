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
					new Building(BuildingType.PowerPlant)
				)
				.Execute(core)
				.IsValid
			);

			Assert.AreEqual(BuildingType.PowerPlant, room.Building.Type);
			Assert.AreEqual(0, room.Building.Modules.Count());

			Assert.IsTrue(
				new ModuleConstruct(
					room.Building,
					new Module(ModuleType.Generator),
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
					new Building(BuildingType.Empty)
				)
				.Execute(core)
				.IsValid
			);

			Assert.IsFalse(
				new ModuleConstruct(
					room.Building,
					new Module(ModuleType.Generator),
					2
				)
				.Execute(core)
				.IsValid
			);

			new BuildingConstruct(
				room,
				new Building(BuildingType.PowerPlant)
			)
			.Execute(core);

			Assert.IsFalse(
				new BuildingConstruct(
					room,
					new Building(BuildingType.PowerPlant)
				)
				.Execute(core)
				.IsValid
			);

			Assert.IsFalse(
				new ModuleConstruct(
					room.Building,
					new Module(ModuleType.Generator),
					666
				)
				.Execute(core)
				.IsValid
			);
		}
	}
}
