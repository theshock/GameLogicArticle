using GameLogic.Architecture;

namespace GameLogic
{
	public class Core
	{
		public static void Main() { }

		public readonly Ship Ship = new Ship();

		public Core ()
		{
			Ship.CreateEmptyRooms();
		}
	}
}
