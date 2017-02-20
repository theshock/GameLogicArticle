using System.Collections.Generic;

namespace GameLogic.Architecture
{
	public class Ship
	{
		// Временно добавим некоторое количество комнат
		public readonly int RoomsLimit = 10;

		private readonly List<Room> rooms = new List<Room>();

		public IEnumerable<Room> Rooms {
			get { return rooms; }
		}

		public void CreateEmptyRooms ()
		{
			for (var i = 0; i < RoomsLimit; i++) {
				rooms.Add(new Room(i));
			}
		}

		public Room GetRoom (int index)
		{
			return rooms[index];
		}
	}
}
