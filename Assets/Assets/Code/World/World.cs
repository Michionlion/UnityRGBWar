using UnityEngine;
using UnityEngine.UI;

public enum TileType { RED, GREEN, BLUE, NOTYPE }

public class World : MonoBehaviour {
		
	readonly Tile[,] tiles;
	public GameObject TileProto;

	public int Width = 200;
	public int Height = 200;

	public World() {
		tiles = new Tile[Width, Height];
	}

	public void Awake() {
		Init();
	}

	public void Init() {
		for(int x = 0; x < Width; x++) {
			for(int y = 0; y < Height; y++) {
				var gn = Instantiate(TileProto, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0), transform);
				tiles[x, y] = gn.GetComponent<Tile>();
				int r = Random.Range(0, 2);
				tiles[x, y].type = r == 0 ? TileType.RED : (r == 1 ? TileType.BLUE : TileType.GREEN);
			}
		}
	}


}
