using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo {

	private static int selectedIndex;

	public static int SelectedPet{
		get{
			return selectedIndex;
		}
		set{
			selectedIndex = value;
		}

	}
}
