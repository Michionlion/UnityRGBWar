using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour {

	Text text;
	RectTransform trans;


	public void Awake() {
		text = GetComponent<Text>();
		trans = GetComponent<RectTransform>();
//		trans.sizeDelta = new Vector2(Screen.width / 4f, Screen.height);
	}

	void Update() {
//		if(Input.GetKeyDown(KeyCode.B)) trans.sizeDelta = new Vector2(Screen.width, 30);
		text.text = "Player1:\n" + Player.Player1.RGB + "\nPlayer2:\n" + Player.Player2.RGB + "\nPlayer3:\n" + Player.Player3.RGB + "\nPlayer4:\n" + Player.Player4.RGB + "\nNeutral:\n" + Player.Neutral.RGB;
	}
}
