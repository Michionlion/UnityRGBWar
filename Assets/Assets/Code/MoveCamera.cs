using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.EventSystems;

public class MoveCamera : MonoBehaviour {
	[Range(0.05f, 2f)]
	public float ZoomScale = 1f;

	Vector3 lastMouse = Vector3.zero;

	public void Update() {
//		Input.simulateMouseWithTouches = false;
//		Input.multiTouchEnabled = true;
		Move();
	}

	public void Move() {

//		Debug.Log("Last: " + lastMouse + " Now: " + Input.mousePosition);

		if(Input.GetMouseButton(0)) {
			transform.Translate((lastMouse - Input.mousePosition) * ((Camera.main.orthographicSize * 2) / (float) Screen.height));
		}
		lastMouse = Input.mousePosition;

		Camera.main.orthographicSize = Mathf.Clamp(
			Camera.main.orthographicSize + Input.mouseScrollDelta.y * ZoomScale,
			1f,
			30f);
	}
}
