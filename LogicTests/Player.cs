using System.Collections.Generic;
using GameLogic;
using GameLogic.Commands;
using GameLogic.Player;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTests
{
	[TestClass]
	public class Player
	{
		[TestMethod]
		public void Payment ()
		{
			var core = new Core();

			core.Bank.Change(ResourceType.Metal, 100);
			core.Bank.Change(ResourceType.Ore, 150);

			Assert.IsFalse(
				new Pay(new Dictionary<ResourceType, int>{
				{ ResourceType.Metal, 100 },
				{ ResourceType.Ore, 2000 }
				})
				.Execute(core)
				.IsValid
			);

			Assert.AreEqual(100, core.Bank.Get(ResourceType.Metal));
			Assert.AreEqual(150, core.Bank.Get(ResourceType.Ore));

			Assert.IsTrue(
				new Pay(new Dictionary<ResourceType, int>{
				{ ResourceType.Metal, 100 },
				{ ResourceType.Ore, 30 }
				})
				.Execute(core)
				.IsValid
			);

			Assert.AreEqual(0, core.Bank.Get(ResourceType.Metal));
			Assert.AreEqual(120, core.Bank.Get(ResourceType.Ore));
		}
	}
}
