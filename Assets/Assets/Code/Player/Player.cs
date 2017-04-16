using UnityEngine;
using System.Collections.Generic;

public class Player {
	public string name;
	public static readonly Player Neutral = new Player("Neutral", new Color(0 / 256f, 0 / 256f, 0 / 256f));
	public static readonly Player Player1 = new Player("Player1", new Color(100 / 256f, 0 / 256f, 100 / 256f));
	public static readonly Player Player2 = new Player("Player2", new Color(100 / 256f, 150 / 256f, 0 / 256f));
	public static readonly Player Player3 = new Player("Player3", new Color(0 / 256f, 100 / 256f, 150 / 256f));
	public static readonly Player Player4 = new Player("Player4", new Color(175 / 256f, 50 / 256f, 50 / 256f));

	public string RGB = "R:0 G:0 B:0";

	public Color playerColor;

	LinkedList<Tile> R, G, B;


	public Player(string name, Color color) {
		this.name = name;
		this.playerColor = color;
		R = new LinkedList<Tile>();
		G = new LinkedList<Tile>();
		B = new LinkedList<Tile>();
	}

	public void remove(Tile t) {
		t.Owner = null;
		switch(t.Type) {
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

	public void reset() {
//		foreach(var t in R) {
//			t.owner = null;
//		}
//		foreach(var t in G) {
//			t.owner = null;
//		}
//		foreach(var t in B) {
//			t.owner = null;
//		}
		R.Clear();
		G.Clear();
		B.Clear();
	}

	public void add(Tile t) {
		t.Owner = this;
		switch(t.Type) {
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

	public bool Equals(Player other) {
		
		return name == (other != null ? other.name : null);
	}

}