using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour {

	Text text;
	RectTransform trans;


	public void Awake() {
		text = GetComponent<Text>();
		trans = GetComponent<RectTransform>();
		trans.sizeDelta = new Vector2(Screen.width, 30);
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.B)) trans.sizeDelta = new Vector2(Screen.width, 30);
		text.text = "Player1: " + Player.Player1.RGB + "   Player2: " + Player.Player2.RGB + "   Player3: " + Player.Player3.RGB + "   Player4: " + Player.Player4.RGB + "   Neutral: " + Player.Neutral.RGB;
	}
}
