using System.Collections.Generic;
using GameLogic.Player;

namespace GameLogic.Architecture
{
	public class ModuleConfig
	{
		public ModuleType Type;
		public int ConstructionTime;
		public Dictionary<ResourceType, int> ConstructionCost;

		public int CycleTime; // ������� ������� ������ ����� �������������� �����
		public Dictionary<ResourceType, int> CycleInput; // ������� �����
		public Dictionary<ResourceType, int> CycleOutput; // ����� ����� ������� ���������
	}
}
