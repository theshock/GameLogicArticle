namespace GameLogic.Commands
{
	public class NextTurn : Command
	{
		protected override bool Run ()
		{
			new CycleProgress().Execute(Core);
			new ConstructionProgress().Execute(Core);
			Core.Turns.NextTurn();
			return true;
		}
	}
}
