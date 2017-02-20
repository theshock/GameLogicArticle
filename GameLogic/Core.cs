using GameLogic.Architecture;
using GameLogic.Player;

namespace GameLogic
{
	public class Core
	{
		public static void Main() { }

		public readonly Ship Ship = new Ship();
		public readonly Factory Factory = new Factory();
		public readonly Turns Turns = new Turns();
		public readonly Bank Bank = new Bank();

		public Core ()
		{
			Ship.CreateEmptyRooms(Factory);
		}
	}
}
