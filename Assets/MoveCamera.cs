using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MoveCamera : MonoBehaviour {

	[Range(0.000001f, 0.25f)]
	public float SpeedDelta = 0.02f;

	[Range(0.000001f, 0.25f)]
	public float ZoomDelta = 0.025f;

	[Range(0.001f, 1f)]
	public float Scale = 0.1f;

	float x = 0, y = 0, z = 0;

	public void Update() {
		if(Input.GetKey(KeyCode.W)) y += SpeedDelta;
		else if(Input.GetKey(KeyCode.S)) y -= SpeedDelta;
		if(Input.GetKey(KeyCode.D)) x += SpeedDelta;
		else if(Input.GetKey(KeyCode.A)) x -= SpeedDelta;
		if(Input.GetKey(KeyCode.UpArrow)) z = -ZoomDelta;
		else if(Input.GetKey(KeyCode.DownArrow)) z = ZoomDelta;
		else z = 0;
		transform.Translate(x * Scale, y * Scale, 0);

		if(x > SpeedDelta / 1.1f) x -= SpeedDelta / 1.1f;
		else if(x < -SpeedDelta / 1.1f) x += SpeedDelta / 1.1f;
		else x = 0;


		if(y > SpeedDelta / 1.1f) y -= SpeedDelta / 1.1f;
		else if(y < -SpeedDelta / 1.1f) y += SpeedDelta / 1.1f;
		else y = 0;

		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + z * Scale, 0.1f, 50f);
	}
}
