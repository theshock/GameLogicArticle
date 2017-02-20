using System;
using GameLogic.Commands;

namespace GameLogic
{
	public class TimeWarp
	{
		public readonly int Speed_Stop = 0;
		public readonly int Speed_X1 = 1000;
		public readonly int Speed_X2 = 500;
		public readonly int Speed_X5 = 200;

		public readonly Core Core;

		private int currentSpeed;

		public int currentTime { get; private set; }

		public TimeWarp (Core core)
		{
			currentSpeed = Speed_Stop;
			Core = core;
		}

		public void SetSpeed (int speed)
		{
			currentSpeed = speed;
			currentTime = Math.Min(speed, currentTime);
		}

		public int GetSpeed ()
		{
			return currentSpeed;
		}

		public bool IsStopped ()
		{
			return currentSpeed == Speed_Stop;
		}

		public void AddTime (int ms)
		{
			if (IsStopped()) return;

			currentTime += ms;

			// Тут можно написать через
			// while (currentTime >= currentSpeed) NextTurn
			// Но зачем запускать каждый кадр больше одного хода? 
			// Даже 20 ходов в секунду будет более чем достаточно
			if (currentTime < currentSpeed) return;

			currentTime -= currentSpeed;

			new NextTurn().Execute(Core);
		}
	}

}
