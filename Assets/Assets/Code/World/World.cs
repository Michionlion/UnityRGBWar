using UnityEngine;
using UnityEngine.UI;

public enum TileType {
	RED,
	GREEN,
	BLUE,
	NOTYPE
}

public class World : MonoBehaviour {

	public static World Instance;

	public Tile[,] tiles;
	public GameObject TileProto;

	public int Width = 8;
	public int Height = 8;

	public void Start() {
		Init();
		//center cam and zoom to right size
//		Instance = this;
	}

	private void Init() {
		Instance = this;
		tiles = new Tile[Width, Height];
		for(int x = 0; x < tiles.GetLength(0); x++) {
			for(int y = 0; y < tiles.GetLength(1); y++) {
				var gn = Instantiate(TileProto, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0), transform);
				gn.name = "Tile(" + x + ", " + y + ")";
				tiles[x, y] = gn.GetComponent<Tile>();
				tiles[x, y].x = x;
				tiles[x, y].y = y;
				int r = Random.Range(0, 100);
				tiles[x, y].Type = r < 22 ? TileType.GREEN : (r > 61 ? TileType.BLUE : TileType.RED);
				Player.Neutral.add(tiles[x, y]);
			}
		}
	}

	public Tile getTile(int x, int y) {
		if(x >= Width || x < 0 || y >= Height || y < 0) return null;
		else return tiles[x, y];
	}

	public void Refresh() {
		for(int x = 0; x < tiles.GetLength(0); x++)
			for(int y = 0; y < tiles.GetLength(1); y++)
				Destroy(tiles[x, y].gameObject);
		Player.Neutral.reset();
		Player.Player1.reset();
		Player.Player2.reset();
		Player.Player3.reset();
		Player.Player4.reset();
		Init();
	}

	public void SetWidth(Text t) {
		
		int.TryParse(t.text, out Width);
		if(Width == 0) {
			Width = 8;
			t.text = "8";
		}
	}

	public void SetHeight(Text t) {
		
		int.TryParse(t.text, out Height);
		if(Height == 0) {
			Height = 8;
			t.text = "8";
		}
	}

	public void Update() {
		if(Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftShift)) {
			Refresh();
		}
	}
}
