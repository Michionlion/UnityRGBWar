using UnityEngine;
using System.Collections.Generic;

public class Player {
	public string name;
	public static readonly Player Neutral = new Player("Neutral");
	public static readonly Player Player1 = new Player("Player1");
	public static readonly Player Player2 = new Player("Player2");
	public static readonly Player Player3 = new Player("Player3");
	public static readonly Player Player4 = new Player("Player4");

	public string RGB = "R:0 G:0 B:0";

	LinkedList<Tile> R, G, B;


	public Player(string name) {
		this.name = name;
		R = new LinkedList<Tile>();
		G = new LinkedList<Tile>();
		B = new LinkedList<Tile>();
	}

	public void remove(Tile t) {
		switch(t.type) {
		case TileType.BLUE:
			B.Remove(t);
			break;
		case TileType.RED:
			R.Remove(t);
			break;
		case TileType.GREEN:
			G.Remove(t);
			break;
		}
		RGB = "R:" + R.Count + " G:" + G.Count + " B:" + B.Count;
	}

	public void add(Tile t) {
		switch(t.type) {
		case TileType.BLUE:
			B.AddLast(t);
			break;
		case TileType.RED:
			R.AddLast(t);
			break;
		case TileType.GREEN:
			G.AddLast(t);
			break;
		}
		RGB = "R:" + R.Count + " G:" + G.Count + " B:" + B.Count;
	}

}