namespace GameLogic
{
	public abstract class Command
	{
		public Core Core { get; private set; }
		public bool IsValid { get; private set; }

		public Command Execute (Core core)
		{
			Core = core;
			IsValid = Run();
			return this;
		}

		protected abstract bool Run ();
	}
}
