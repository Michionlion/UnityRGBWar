using UnityEngine;

public class Tile : MonoBehaviour {

	public const int NORTH = 0;
	public const int NORTH_EAST = 1;
	public const int EAST = 2;
	public const int SOUTH_EAST = 3;
	public const int SOUTH = 4;
	public const int SOUTH_WEST = 5;
	public const int WEST = 6;
	public const int NORTH_WEST = 7;

	[SerializeField]
	private TileType _type;
	[SerializeField]
	private Player _owner;

	[SerializeField]
	private string ownerName;

	public TileType Type {
		get {
			return _type;
		}
		set {
			_type = value;
			doInside();
		}
	}

	public Player Owner {
		get {
			return _owner;
		}
		set {
			_owner = value;
			ownerName = _owner != null ? _owner.name : "null";
			if(_owner != null) {
				doBorder(true); //ensure borders are only called when adding to a player, not removing
				doInside();
			}
			doIcon();
		}
	}


	public SpriteRenderer inside;
	[Tooltip("First entry should be north border, then proceed in clockwise fasion")]
	public SpriteRenderer[] border;
	public SpriteRenderer playerIcon;

	[HideInInspector]
	public int x, y;

	public Tile() : this(0, 0, Player.Neutral) {
	}

	public Tile(int x, int y, Player p, TileType t = TileType.NOTYPE) {
		Type = t;
		Owner = p;
		this.x = x;
		this.y = y;
	}

	public void Start() {
		doInside();
		doBorder();
		doIcon();
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

	private void colorize(int b) {
		border[b].color = Color.Lerp(Color.clear, _owner.playerColor, 0.4f);
	}

	public void doBorder(bool doN = false) {
		if(_owner == null) {
			Debug.Log("Tile without owner!!");
			return;
		}
		if(border != null) {

			foreach(var s in border) {
				s.color = _owner.playerColor;
			}

			Tile northT = getTile(0, 1);
			Tile southT = getTile(0, -1);
			Tile eastT = getTile(1, 0);
			Tile westT = getTile(-1, 0);
			Tile northwestT = getTile(-1, 1);
			Tile northeastT = getTile(1, 1);
			Tile southwestT = getTile(-1, -1);
			Tile southeastT = getTile(1, -1);

			bool northE = northT != null;
			bool southE = southT != null;
			bool eastE = eastT != null;
			bool westE = westT != null;
			bool northwestE = northwestT != null;
			bool northeastE = northeastT != null;
			bool southwestE = southwestT != null;
			bool southeastE = southeastT != null;

			bool north = northE && _owner.Equals(northT.Owner);
			bool south = southE && _owner.Equals(southT.Owner);
			bool east = eastE && _owner.Equals(eastT.Owner);
			bool west = westE && _owner.Equals(westT.Owner);
			bool northeast = northeastE && _owner.Equals(northeastT.Owner);
			bool northwest = northwestE && _owner.Equals(northwestT.Owner);
			bool southeast = southeastE && _owner.Equals(southeastT.Owner);
			bool southwest = southwestE && _owner.Equals(southwestT.Owner);


			if(north) colorize(NORTH);
			if(south) colorize(SOUTH);
			if(east) colorize(EAST);
			if(west) colorize(WEST);

			if(northeast && north && east) colorize(NORTH_EAST);
			if(northwest && north && west) colorize(NORTH_WEST);
			if(southeast && south && east) colorize(SOUTH_EAST);
			if(southwest && south && west) colorize(SOUTH_WEST);

			if(doN) {
				if(northE) northT.doBorder();
				if(northeastE) getTile(1, 1).doBorder();
				if(northwestE) getTile(-1, 1).doBorder();
				if(southE) southT.doBorder();
				if(southeastE) getTile(1, -1).doBorder();
				if(southwestE) getTile(-1, -1).doBorder();
				if(eastE) eastT.doBorder();
				if(westE) westT.doBorder();
			}
		}
	}

	public void doInside() {
		Color c = getTTColor();
		if(_owner != null) {
			Color o = _owner.playerColor;
			c.r += o.r / 2f;
			c.g += o.g / 2f;
			c.b += o.b / 2f;
		}
		if(inside != null) inside.color = c;
	}

	public Color getTTColor() {
		switch(Type) {
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

	public void doIcon() {
		if(playerIcon != null) playerIcon.color = _owner != null ? _owner.playerColor : Color.clear;
	}
}
