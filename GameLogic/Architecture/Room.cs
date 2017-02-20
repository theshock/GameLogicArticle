namespace GameLogic.Architecture
{
	public class Room
	{
		public readonly int Index;

		// каждая комната является пристанищем для строения
		public Building Building { get; set; }

		public Room (int index)
		{
			Index = index;

			// и по-умолчанию - это пустое строение
			Building = new Building(BuildingType.Empty);
		}
	}
}
