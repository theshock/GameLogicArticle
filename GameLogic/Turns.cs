namespace GameLogic
{
	public class Turns
	{
		public int CurrentTurn { get; private set; }

		internal void NextTurn ()
		{
			CurrentTurn++;
		}
	}
}
