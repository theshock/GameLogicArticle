using GameLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTests
{
	[TestClass]
	public class Init
	{
		[TestMethod]
		public void TestMethod1 ()
		{
			Assert.IsInstanceOfType(new Core(), typeof(Core));
		}
	}
}
