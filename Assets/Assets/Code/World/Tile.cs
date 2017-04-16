using UnityEngine;
using System.ComponentModel;

public class Tile : MonoBehaviour {

	public const int NORTH = 0;
	public const int NORTH_EAST = 1;
	public const int EAST = 2;
	public const int SOUTH_EAST = 3;
	public const int SOUTH = 4;
	public const int SOUTH_WEST = 5;
	public const int WEST = 6;
	public const int NORTH_WEST = 7;

	private TileType _type;
	private Player _owner;

	public TileType type {
		get {
			return _type;
		}
		set {
			_type = value;
			doInside();
		}
	}

	public Player owner {
		get {
			return _owner;
		}
		set {
			_owner = value;
			doBorder();
		}
	}


	public SpriteRenderer inside;
	[Tooltip("First entry should be north border, then proceed in clockwise fasion")]
	public SpriteRenderer[] border;
	public SpriteRenderer playerIcon;

	public readonly int x, y;

	public Tile(int x, int y) : this(x, y, Player.Neutral) {
	}

	public Tile(int x, int y, Player p, TileType t = TileType.NOTYPE) {
		type = t;
		owner = p;
		this.x = x;
		this.y = y;
	}

	public void Start() {
		doInside();
		doBorder();
	}

	int mode = 0;

	public void OnMouseDown() {
		switch(mode = (mode + 1) % 5) {
		case 0:
//			playerIcon.sprite = null;
//			playerIcon.color = Color.white;
			Player.Player4.remove(this);
			Player.Neutral.add(this);
			break;
		case 1:
//			playerIcon.sprite = sprite1;
//			playerIcon.color = color1;
			Player.Neutral.remove(this);
			Player.Player1.add(this);
			break;
		case 2:
//			playerIcon.sprite = sprite2;
//			playerIcon.color = color1;
			Player.Player1.remove(this);
			Player.Player2.add(this);
			break;
		case 3:
//			playerIcon.sprite = sprite1;
//			playerIcon.color = color2;
			Player.Player2.remove(this);
			Player.Player3.add(this);
			break;
		case 4:
//			playerIcon.sprite = sprite2;
//			playerIcon.color = color2;
			Player.Player3.remove(this);
			Player.Player4.add(this);
			break;
		}
		doBorder(true);
	}

	public Tile getTile(int xoff, int yoff) {
		return World.Instance != null ? World.Instance.getTile(x + xoff, y + yoff) : null;

	}

	public void doBorder(bool doN = false) {
		if(border != null) {
			bool northE = getTile(0, 1) != null;
			bool southE = getTile(0, -1) != null;
			bool eastE = getTile(1, 0) != null;
			bool westE = getTile(-1, 0) != null;
			bool north = northE && getTile(0, 1).owner == owner;
			bool south = southE && getTile(0, -1).owner == owner;
			bool east = eastE && getTile(1, 0).owner == owner;
			bool west = westE && getTile(-1, 0).owner == owner;

			foreach(var s in border) {
				if(owner != null) s.color = owner.playerColor;
			}
			if(north) border[NORTH].color = getTTColor();
			if(north && east) border[NORTH_EAST].color = getTTColor();
			if(north && west) border[NORTH_WEST].color = getTTColor();
			if(south) border[SOUTH].color = getTTColor();
			if(south && east) border[SOUTH_EAST].color = getTTColor();
			if(south && west) border[SOUTH_WEST].color = getTTColor();
			if(east) border[EAST].color = getTTColor();
			if(west) border[WEST].color = getTTColor();

			if(doN) {
				if(northE) getTile(0, 1).doBorder();
				if(northE && eastE) getTile(1, 1).doBorder();
				if(northE && westE) getTile(-1, 1).doBorder();
				if(southE) getTile(0, -1).doBorder();
				if(southE && eastE) getTile(1, -1).doBorder();
				if(southE && westE) getTile(-1, -1).doBorder();
				if(eastE) getTile(1, 0).doBorder();
				if(westE) getTile(-1, 0).doBorder();
			}
		}
	}

	public void doInside() {
		if(inside != null) inside.color = getTTColor();
	}

	public Color getTTColor() {
		switch(type) {
		case TileType.RED:
			return Color.red;
		case TileType.GREEN:
			return Color.green;
		case TileType.BLUE:
			return Color.blue;
		case TileType.NOTYPE:
			return Color.grey;
		default:
			return Color.black;
		}
	}
}
