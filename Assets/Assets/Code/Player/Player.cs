using UnityEngine;


public class Player {
	public string name;
	public static readonly Player Neutral = new Player("Neutral");

	public Player(string name) {
		this.name = name;
	}

}