using UnityEngine;

class Tile : MonoBehaviour {
	
	private TileType _type;
	private SpriteRenderer spRen;

	public TileType type {
		get {
			return _type;
		}
		set {
			
			_type = value;
			if(spRen != null) switch(_type) {
				case TileType.BLUE:
					spRen.color = Color.blue;
					break;
				case TileType.GREEN:
					spRen.color = Color.green;
					break;
				case TileType.RED:
					spRen.color = Color.red;
					break;
				case TileType.NOTYPE:
					spRen.color = Color.grey;
					break;
				}
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
		type = _type;
	}
}
