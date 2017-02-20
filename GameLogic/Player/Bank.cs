using System;
using System.Collections.Generic;

namespace GameLogic.Player
{
	public class Bank
	{
		private readonly Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

		public int Get (ResourceType type)
		{
			return resources.ContainsKey(type) ? resources[type] : 0;
		}

		public void Change (ResourceType type, int value)
		{
			var current = Get(type);

			if (current + value < 0) {
				throw new ArgumentOutOfRangeException("Not enought " + type + " in bank");
			}

			resources[type] = current + value;
		}
	}

}
