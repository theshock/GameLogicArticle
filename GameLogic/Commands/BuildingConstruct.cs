using GameLogic.Architecture;

namespace GameLogic.Commands
{
	public class BuildingConstruct : Command
	{
		public readonly Room Room;
		public readonly Building Building;

		public BuildingConstruct (Room room, Building building)
		{
			Room = room;
			Building = building;
		}

		protected override bool Run ()
		{
			// Нельзя строить там, где уже что-то есть
			if (Room.Building.Type != BuildingType.Empty) {
				return false;
			}
			// Нельзя строить пустую комнату
			if (Building.Type == BuildingType.Empty) {
				return false;
			}

			Room.Building = Building;
			return true;
		}
	}
}
