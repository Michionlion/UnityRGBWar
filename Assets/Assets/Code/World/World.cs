using UnityEngine;


public enum TileType {
	RED,
	GREEN,
	BLUE,
	NOTYPE
}

public class World : MonoBehaviour {

	public static World Instance;

	public readonly Tile[,] tiles;
	public GameObject TileProto;

	public int Width = 15;
	public int Height = 15;

	public World() {
		tiles = new Tile[Width, Height];
	}

	public void Start() {
		Init();
		//center cam and zoom to right size
//		Instance = this;
	}

	public void Init() {
		Instance = this;
		for(int x = 0; x < Width; x++) {
			for(int y = 0; y < Height; y++) {
				var gn = Instantiate(TileProto, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0), transform);
				gn.name = "Tile(" + x + ", " + y + ")";
				tiles[x, y] = gn.GetComponent<Tile>();
				int r = Random.Range(0, 100);
				tiles[x, y].type = r < 22 ? TileType.GREEN : (r > 61 ? TileType.BLUE : TileType.RED);
				Player.Neutral.add(tiles[x, y]);
			}
		}
	}

	public Tile getTile(int x, int y) {
		if(x >= Width || x < 0 || y >= Height || y < 0) return null;
		else return tiles[x, y];
	}

	public void Update() {
		if(Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftShift)) {
			for(int x = 0; x < Width; x++)
				for(int y = 0; y < Height; y++)
					Destroy(tiles[x, y].gameObject);
			Player.Neutral.reset();
			Player.Player1.reset();
			Player.Player2.reset();
			Player.Player3.reset();
			Player.Player4.reset();
			Init();

		}
	}


}
