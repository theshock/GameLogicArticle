namespace GameLogic.Commands
{
	public class NextTurn : Command
	{
		protected override bool Run ()
		{
			// Именно тут будет вся логика хода

			Core.Turns.NextTurn();
			return true;
		}
	}
}
