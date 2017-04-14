using UnityEngine;

public class Tile : MonoBehaviour {
	
	private TileType _type;
	private SpriteRenderer spRen;

	public static Color RED_TILE_COLOR = Color.red;
	public static Color BLUE_TILE_COLOR = Color.blue;
	public static Color GREEN_TILE_COLOR = Color.green;
	public static Color NONE_TILE_COLOR = Color.grey;


	public TileType type {
		get {
			return _type;
		}
		set {
			_type = value;
			doColors();
		}
	}

	public Player owner;

	public Tile() : this(Player.Neutral) {
	}

	public Tile(Player p, TileType t = TileType.NOTYPE) {
		type = t;
	}

	public void Awake() {
		if(spRen == null) {
			spRen = gameObject.GetComponent<SpriteRenderer>();
		}
		doColors();
	}

	public void doColors() {
		if(spRen != null) switch(_type) {
			case TileType.BLUE:
				spRen.color = BLUE_TILE_COLOR;
				break;
			case TileType.GREEN:
				spRen.color = GREEN_TILE_COLOR;
				break;
			case TileType.RED:
				spRen.color = RED_TILE_COLOR;
				break;
			case TileType.NOTYPE:
				spRen.color = NONE_TILE_COLOR;
				break;
			}
	}
}
