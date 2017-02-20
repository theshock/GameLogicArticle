using GameLogic;
using GameLogic.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTests
{
	[TestClass]
	public class Turns
	{
		[TestMethod]
		public void NextTurnsCommand ()
		{
			var core = new Core();

			Assert.AreEqual(0, core.Turns.CurrentTurn);

			Assert.IsTrue(
				new NextTurnCount(4)
					.Execute(core)
					.IsValid
			);

			Assert.AreEqual(4, core.Turns.CurrentTurn);
		}

		[TestMethod]
		public void TimeWarp ()
		{
			var core = new Core();
			var time = new TimeWarp(core);

			Assert.AreEqual(0, core.Turns.CurrentTurn);

			time.SetSpeed(time.Speed_X5);

			time.AddTime(50);
			time.AddTime(50);
			time.AddTime(50);
			time.AddTime(50);

			Assert.AreEqual(1, core.Turns.CurrentTurn);

			time.AddTime(199);

			Assert.AreEqual(1, core.Turns.CurrentTurn);

			time.AddTime(1);

			Assert.AreEqual(2, core.Turns.CurrentTurn);
		}
	}
}
