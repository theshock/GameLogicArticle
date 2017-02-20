using System.Collections.Generic;
using System.Linq;
using GameLogic.Player;

namespace GameLogic.Commands
{
	public class Pay : Command
	{
		public readonly Dictionary<ResourceType, int> Cost;

		public Pay (Dictionary<ResourceType, int> cost)
		{
			Cost = cost;
		}

		protected override bool Run ()
		{
			// Если хотя бы одного ресурса не хватаем - отменяем всю оплату и возвращаем ошибку
			if (Cost.Any(item => Core.Bank.Get(item.Key) < item.Value)) {
				return false;
			}

			// Если всех хватает - забираем из банка
			foreach (var item in Cost) {
				Core.Bank.Change(item.Key, -item.Value);
			}

			return true;
		}
	}

}
