namespace GameLogic.Commands
{
	public class NextTurnCount : Command
	{
		public const int Max = 32;

		public readonly int Count;

		public NextTurnCount (int count)
		{
			Count = count;
		}

		protected override bool Run ()
		{
			if (Count < 0 || Count > Max) {
				return false;
			}

			for (var i = 0; i < Count; i++) {
				var nextTurn = new NextTurn().Execute(Core);

				if (!nextTurn.IsValid) return false;
			}

			return true;
		}
	}

}
