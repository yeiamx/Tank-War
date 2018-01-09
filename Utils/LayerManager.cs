using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils {
	public class LayerManager: MonoBehaviour {

		static int greenLayer = 15;
		static int redLayer = 16;
		static int blueLayer = 17;

		static public LayerMask getEnemyLayer(Team team) {
			LayerMask mask = 0;

			switch (team) {
			case Team.Blue:
				mask = (1 << redLayer) | (1 << greenLayer);
				break;
			case Team.Green:
				mask = (1 << blueLayer) | (1 << redLayer);
				break;
			case Team.Red:
				mask = (1 << greenLayer) | (1 << blueLayer);
				break;
			}

			return mask;
		}
	}
}
