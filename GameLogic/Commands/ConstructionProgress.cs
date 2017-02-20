using GameLogic.Architecture;

namespace GameLogic.Commands
{
	public class ConstructionProgress : Command
	{
		protected override bool Run ()
		{
			foreach (var room in Core.Ship.Rooms) {
				BuildingProgress(room.Building);
			}

			return true;
		}

		private void BuildingProgress (Building building)
		{
			building.Constructible.AddProgress();

			foreach (var module in building.Modules) {
				module.Constructible.AddProgress();
			}
		}
	}

}
