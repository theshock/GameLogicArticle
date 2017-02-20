using GameLogic.Architecture;

namespace GameLogic.Commands
{
	public class CycleProgress : Command
	{
		protected override bool Run ()
		{
			foreach (var room in Core.Ship.Rooms) {
				BuildingProgress(room.Building);
			}

			return true;
		}

		private void BuildingProgress (Building building)
		{
			if (!building.Constructible.IsReady) return;

			foreach (var module in building.Modules) {
				ModuleProgress(module);
			}
		}

		private void ModuleProgress (Module module)
		{
			if (!module.Constructible.IsReady || module.Cycle.IsFake) {
				return;
			}

			// Добавляем прогресс только если модуль уже запущен (ресурсы были заплачены)
			// Или если мы можем запустить его сейчас (заплатить ресурсы)
			if (module.Cycle.IsRunning || TryStartCycle(module)) {
				AddStep(module);
			}
		}

		private void AddStep (Module module)
		{
			module.Cycle.AddProgress();

			// Если после добавления прогресса работа модуля завершена
			if (module.Cycle.IsReady) {
				// Отдаем игроку его ресурсы
				CycleOutput(module);
				// И обнуляем прогресс, следующий раз еему придется запускаться сначала
				module.Cycle.Reset();
			}
		}

		private bool TryStartCycle (Module module)
		{
			if (module.Config.CycleInput == null) {
				return true;
			}

			// Пытаемся заплатить ресурсы и если удается - модуль запущен
			return new Pay(module.Config.CycleInput).Execute(Core).IsValid;
		}

		private void CycleOutput (Module module)
		{
			foreach (var item in module.Config.CycleOutput) {
				// Отдаем игроку каждый ресурс, который ему был нужен
				Core.Bank.Change(item.Key, item.Value);
			}
		}
	}

}
