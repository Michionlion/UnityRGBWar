using UnityEngine;

public class PlayerChange : MonoBehaviour {

	SpriteRenderer spRen;

	public Sprite sprite1;
	public Sprite sprite2;
	public Color color1 = Color.black;
	public Color color2 = Color.white;

	int mode = 0;

	Tile t;


	public void Awake() {
		spRen = GetComponent<SpriteRenderer>();
		t = GetComponentInParent<Tile>();
	}

	public void OnMouseDown() {
		switch(mode = (mode + 1) % 5) {
		case 0:
			spRen.sprite = null;
			spRen.color = Color.white;
			Player.Player4.remove(t);
			Player.Neutral.add(t);
			break;
		case 1:
			spRen.sprite = sprite1;
			spRen.color = color1;
			Player.Neutral.remove(t);
			Player.Player1.add(t);
			break;
		case 2:
			spRen.sprite = sprite2;
			spRen.color = color1;
			Player.Player1.remove(t);
			Player.Player2.add(t);
			break;
		case 3:
			spRen.sprite = sprite1;
			spRen.color = color2;
			Player.Player2.remove(t);
			Player.Player3.add(t);
			break;
		case 4:
			spRen.sprite = sprite2;
			spRen.color = color2;
			Player.Player3.remove(t);
			Player.Player4.add(t);
			break;
		}
	}
}
