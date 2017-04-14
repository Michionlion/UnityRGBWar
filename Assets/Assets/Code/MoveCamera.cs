using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MoveCamera : MonoBehaviour {

	[Range(0.05f, 5f)]
	public float SpeedDelta = 1.0f;

	[Range(0.05f, 2f)]
	public float ZoomDelta = 0.2f;

	[Range(0.01f, 2f)]
	public float Scale = 1f;

	[Range(0f, 10f)]
	public float SlowDownModifier = 2.15f;

	float x = 0, y = 0, z = 0;

	public void Update() {
		if(Input.GetKey(KeyCode.W)) y += SpeedDelta;
		else if(Input.GetKey(KeyCode.S)) y -= SpeedDelta;
		if(Input.GetKey(KeyCode.D)) x += SpeedDelta;
		else if(Input.GetKey(KeyCode.A)) x -= SpeedDelta;
		if(Input.GetKey(KeyCode.UpArrow)) z = -ZoomDelta;
		else if(Input.GetKey(KeyCode.DownArrow)) z = ZoomDelta;
		else z = 0;
		transform.Translate(x * Scale * Time.deltaTime, y * Scale * Time.deltaTime, 0);

		if(x > SpeedDelta / SlowDownModifier) x -= SpeedDelta / SlowDownModifier;
		else if(x < -SpeedDelta / SlowDownModifier) x += SpeedDelta / SlowDownModifier;
		else x = 0;


		if(y > SpeedDelta / SlowDownModifier) y -= SpeedDelta / SlowDownModifier;
		else if(y < -SpeedDelta / SlowDownModifier) y += SpeedDelta / SlowDownModifier;
		else y = 0;

		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + z * Scale, 2f, 32f);
	}
}
