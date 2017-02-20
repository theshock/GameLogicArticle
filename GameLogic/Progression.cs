namespace GameLogic
{
	public class Progression
	{
		public readonly int Time;

		public int Progress { get; private set; }

		public bool IsFake {
			get { return Time == 0; }
		}

		public bool IsReady {
			get { return IsFake || Progress >= Time; }
		}

		public bool IsRunning {
			get { return !IsReady && Progress > 0; }
		}

		public Progression (int time)
		{
			Time = time;
			Progress = 0;
		}

		public void AddProgress ()
		{
			if (!IsReady) Progress++;
		}

		public void Complete ()
		{
			if (!IsReady) Progress = Time;
		}

		public void Reset ()
		{
			Progress = 0;
		}
	}

}
